using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BOM_Builder.Models;
using Microsoft.JScript;
using Microsoft.JScript.Vsa;
using Simpro.Expr;

namespace BOM_Builder.Controllers
{
    public class EvaluacionFormulasController
    {
        //SQLServer sql = new SQLServer();
        //CondicionalesController condicionalesContr = new CondicionalesController();

        /// <summary>
        /// Obtiene las variables disponibles en la formula asignada
        /// </summary>
        /// <param name="formula">Formula para evaluacion y extraccion de variables</param>
        /// <returns></returns>
        public List<string> GetVariables(string formula)
        {
            //string remove = Regex.Replace(formula, "[^a-zA-Z0-9]+", " ", RegexOptions.Compiled);
            string remove = Regex.Replace(formula, "[^a-zA-Z]+", " ", RegexOptions.Compiled);

            string[] split = remove.Split(' ');
            List<string> variables = split.ToList();
            return RemoveBlankSpaces(variables);
        }

        public List<string> GetVariablesIds(string formula)
        {
            string remove = Regex.Replace(formula, "[^a-zA-Z0-9]+", " ", RegexOptions.Compiled);

            string[] split = remove.Split(' ');
            List<string> variables = split.ToList();
            return RemoveBlankSpaces(variables);
        }

        public List<string> GetDecimal(string expresion)
        {
            string exp = string.Empty;
            MatchCollection matchCollection = Regex.Matches(expresion, @"\d+(\.\d*)?|\.\d+", RegexOptions.Compiled);
            List<string> decimals = new List<string>();

            foreach (var match in matchCollection)
            {
                if (match.ToString().Contains("."))
                {
                    decimals.Add(match.ToString());
                }
            }
            return decimals;
        }

        public string ReplaceDecimalToFraction(string expresion)
        {
            List<string> decimales = GetDecimal(expresion);
            Fraccion fraccion;
            string aux = string.Empty;

            if (decimales.Count > 0)
            {
                foreach (var _decimal in decimales)
                {
                    fraccion = new Fraccion();
                    fraccion = DecimalToFraccion(System.Convert.ToDouble(_decimal));
                    aux = string.Format("({0}/{1})", fraccion.Numerador, fraccion.Denominador);
                    expresion = expresion.Replace(_decimal, aux);
                }
            }
            return expresion;
        }

        public Fraccion DecimalToFraccion(double num)
        {
            Fraccion fraccion = new Fraccion();
            double a, b;
            double aux = 0;
            a = 1;
            b = 1;

            while (!(aux == num))
            {
                aux = a / b;
                if (aux < num)
                {
                    a++;
                }
                else if (aux > num)
                {
                    a--;
                    b++;
                }
            }
            fraccion.Numerador = a;
            fraccion.Denominador = b;
            return fraccion;
        }

        /// <summary>
        /// Elimina registros vacios
        /// </summary>
        /// <param name="variables">variables</param>
        /// <returns></returns>
        private List<string> RemoveBlankSpaces(List<string> variables)
        {
            int cont = variables.Count;

            for (int i = 0; i < cont; i++)
            {
                variables.Remove("");
            }

            return variables;
        }

        /// <summary>
        /// Remplaza los valores a cada una de las variables de la formula
        /// </summary>
        /// <param name="formula">Formula</param>
        /// <param name="values">Valores a remplazar por las variables</param>
        /// <param name="error">Error</param>
        public string ReplaceVariables(string formula, List<FormulaVariableModel> variablesValues, out string error)
        {
            List<string> variablesFormula = GetVariables(formula);
            int contador = 0;
            error = string.Empty;

            if (variablesValues.Count > 0)
            {
                if (variablesValues.Count == variablesFormula.Count)
                {
                    foreach (var variable in variablesValues)
                    {
                        formula = formula.Replace(variablesFormula[contador], variable.Valor);
                        contador++;
                    }
                }
                else
                {
                    error = "La lista de valores no coincide con la cantidad de variables en la formula.";
                }
            }
            else
            {
                error = "La lista de valores no puede estar vacia.";
            }

            return formula;
        }

        //public string ReplaceVariableComplex(string condicional, List<Elemento> elementos)
        //{
        //    List<string> variables = GetVariables(condicional);
        //    int index = 0;

        //    if(variables.Count>0)
        //    {
        //        foreach (Elemento elemento in elementos)
        //        {
        //            if (variables.Contains(elemento.Elemento_))
        //            {
        //                index = variables.IndexOf(elemento.Elemento_);
        //                condicional = condicional.Replace(variables[index], elemento.Value);
        //            }
        //        }
        //    }

        //    return condicional;
        //}
        public string ReplaceVariableComplex(string condicional, List<Elemento> elementos)
        {
            List<string> variables = GetVariables(condicional);
            CultureInfo culture = new CultureInfo("es-ES");
            int index = 0;
            //condicional = condicional.ToLower();

            foreach (Elemento elemento in elementos)
            {
                if (culture.CompareInfo.IndexOf(condicional, elemento.Elemento_, CompareOptions.IgnoreCase) >= 0)
                //if(condicional.Contains(elemento.Elemento_))
                {
                    //index = variables.IndexOf(elemento.Elemento_);
                    condicional = Regex.Replace(condicional, elemento.Elemento_, elemento.Value, RegexOptions.IgnoreCase);

                }
            }
            return condicional;
        }

        public string ReplaceVariableComplexEntero(string condicional, List<Elemento> elementos)
        {
            List<string> variables = GetVariables(condicional);
            int index = 0;
            CultureInfo culture = new CultureInfo("es-ES");

            foreach (Elemento elemento in elementos)
            {
                if (culture.CompareInfo.IndexOf(condicional, elemento.Elemento_, CompareOptions.IgnoreCase) >= 0)
                {
                    index = variables.IndexOf(elemento.Elemento_);
                    condicional = Regex.Replace(condicional, elemento.Elemento_, elemento.Value, RegexOptions.IgnoreCase);
                    break;
                }
                //if (variables.Contains(elemento.Elemento_))
                //{
                //    index = variables.IndexOf(elemento.Elemento_);
                //    condicional = condicional.Replace(variables[index], elemento.Value);
                //    break;
                //}
            }
            return condicional;
        }

        public string ReplaceEntero(string expresion, List<Elemento> elementos)
        {
            int corcheteInicial = 0;
            int corcheteFinal = 0;
            char caracter;
            bool flag = false;
            string formula = string.Empty;
            ExprParser ep = new ExprParser();
            string evaluacion = string.Empty;
            decimal aux = 0;
            string backupFormula = string.Empty;

            if (expresion.Contains("ENTERO"))
            {
                for (int i = 0; i < expresion.Length; i++)
                {
                    caracter = expresion[i];

                    if (caracter == 'E' && expresion[i + 1] == 'N' && expresion[i + 2] == 'T' && expresion[i + 3] == 'E' && expresion[i + 4] == 'R' && expresion[i + 5] == 'O')
                    {
                        i = i + 5;
                        flag = true;
                    }

                    if (caracter == '(' && flag)
                    {
                        corcheteInicial++;
                    }
                    if (caracter == ')' && flag)
                    {
                        corcheteFinal++;

                        if (corcheteInicial == corcheteFinal)
                        {
                            formula += caracter;
                            break;
                        }
                    }
                    if (flag)
                    {
                        if (caracter != 'E')
                        {
                            formula += caracter;
                        }
                    }

                }
            }
            else
            {
                return expresion;
            }

            backupFormula = formula;
            
            formula = ReplaceVariableComplexEntero(formula, elementos);

            try
            {
                evaluacion = ExecuteSimpleFormula(formula);
                aux = System.Convert.ToDecimal(evaluacion);
                evaluacion = Math.Truncate(aux).ToString();
                evaluacion = "(" + evaluacion + ")";
                formula = "ENTERO" + backupFormula;
                expresion = expresion.Replace(formula, evaluacion);

                //if(!evaluacion.Contains("ENTERO"))
                //{
                //    return evaluacion;
                //}
            }
            catch (ExprException e)
            {
                string message = e.Message;
            }

            return expresion;

        }

        public string ReplaceRedondearMas(string expresion, List<Elemento> elementos)
        {
            int corcheteInicial = 0;
            int corcheteFinal = 0;
            char caracter;
            bool flag = false;
            string formula = string.Empty;
            ExprParser ep = new ExprParser();
            string evaluacion = string.Empty;
            decimal aux = 0;
            string backupFormula = string.Empty;

            if (expresion.Contains("REDONDEAR.MAS"))
            {
                for (int i = 0; i < expresion.Length; i++)
                {
                    caracter = expresion[i];

                    if (caracter == 'R' && expresion[i + 1] == 'E' && expresion[i + 2] == 'D' && expresion[i + 3] == 'O' && expresion[i + 4] == 'N' && expresion[i + 5] == 'D' &&
                        expresion[i + 6] == 'E' && expresion[i + 7] == 'A' && expresion[i + 8] == 'R' &&
                        expresion[i + 9] == '.' && expresion[i + 10] == 'M' && expresion[i + 11] == 'A' && expresion[i + 12] == 'S')
                    {
                        i = i + 12;
                        flag = true;
                    }

                    if (caracter == '(' && flag)
                    {
                        corcheteInicial++;
                    }
                    if (caracter == ')' && flag)
                    {
                        corcheteFinal++;

                        if (corcheteInicial == corcheteFinal)
                        {
                            formula += caracter;
                            break;
                        }
                    }
                    if (flag)
                    {
                        if (caracter != 'R')
                        {
                            formula += caracter;
                        }
                    }

                }
            }
            else
            {
                return expresion;
            }

            backupFormula = formula;
            formula = ExecuteRedondearMas(formula, elementos);

            try
            {
                backupFormula = "REDONDEAR.MAS" + backupFormula;
                expresion = expresion.Replace(backupFormula, formula);
                expresion = ReplaceVariableComplex(expresion, elementos);
                if(expresion.Contains("ENTERO") || expresion.Contains("CONDICIONALM") || expresion.Contains("CONDICIONALC"))
                {
                    return expresion;
                }
                expresion = ExecuteSimpleFormula(expresion);
            }
            catch (ExprException e)
            {
                string message = e.Message;
            }

            return expresion;

        }

        public string ReplaceRedondear(string expresion, List<Elemento> elementos)
        {
            int corcheteInicial = 0;
            int corcheteFinal = 0;
            char caracter;
            bool flag = false;
            string formula = string.Empty;
            ExprParser ep = new ExprParser();
            string evaluacion = string.Empty;
            decimal aux = 0;
            string backupFormula = string.Empty;

            if (expresion.Contains("REDONDEAR"))
            {
                for (int i = 0; i < expresion.Length; i++)
                {
                    caracter = expresion[i];

                    if (caracter == 'R' && expresion[i + 1] == 'E' && expresion[i + 2] == 'D' && expresion[i + 3] == 'O' && expresion[i + 4] == 'N' && expresion[i + 5] == 'D' &&
                        expresion[i + 6] == 'E' && expresion[i + 7] == 'A' && expresion[i + 8] == 'R')
                    {
                        i = i + 8;
                        flag = true;
                    }

                    if (caracter == '(' && flag)
                    {
                        corcheteInicial++;
                    }
                    if (caracter == ')' && flag)
                    {
                        corcheteFinal++;

                        if (corcheteInicial == corcheteFinal)
                        {
                            formula += caracter;
                            break;
                        }
                    }
                    if (flag)
                    {
                        if (caracter != 'R')
                        {
                            formula += caracter;
                        }
                    }

                }
            }
            else
            {
                return expresion;
            }

            backupFormula = formula;
            formula = ExecuteRedondear(formula, elementos);

            try
            {
                backupFormula = "REDONDEAR" + backupFormula;
                expresion = expresion.Replace(backupFormula, formula);
                expresion = ReplaceVariableComplex(expresion, elementos);
                if (expresion.Contains("ENTERO") || expresion.Contains("CONDICIONALM") || expresion.Contains("CONDICIONALC"))
                {
                    return expresion;
                }
                if (expresion.Contains(",0") || expresion.Contains(",1") || expresion.Contains(",-1"))
                {
                    expresion = ReplaceVariableComplex(expresion, elementos);
                    expresion = ExecuteRedondearMas(expresion, elementos);
                }
                expresion = ExecuteSimpleFormula(expresion);
            }
            catch (ExprException e)
            {
                string message = e.Message;
            }

            return expresion;

        }


        public string GetIdCondicional(string expresion)
        {
            char caracter;
            bool flag = false;
            int corcheteInicial = 0;
            int corcheteFinal = 0;
            string idCondicional = string.Empty;

            if (expresion.Contains("CONDICIONAL"))
            {
                for (int i = 0; i < expresion.Length; i++)
                {
                    caracter = expresion[i];

                    if (caracter == 'C' && expresion[i + 1] == 'O' && expresion[i + 2] == 'N' && expresion[i + 3] == 'D' && expresion[i + 4] == 'I' &&
                        expresion[i + 5] == 'C' && expresion[i + 6] == 'I' && expresion[i + 7] == 'O' && expresion[i + 8] == 'N' && expresion[i + 9] == 'A' && expresion[i + 10] == 'L')
                    {
                        i = i + 11;
                        flag = true;
                    }

                    if (caracter == '(' && flag)
                    {
                        corcheteInicial++;
                    }
                    if (caracter == ')' && flag)
                    {
                        corcheteFinal++;

                        if (corcheteInicial == corcheteFinal)
                        {
                            idCondicional += caracter;
                            break;
                        }
                    }
                    if (flag)
                    {
                        if (caracter != 'C' && caracter != '(' && caracter != ')')
                        {
                            idCondicional += caracter;
                        }
                    }

                }

            }

            return idCondicional;
        }

        public string ExecuteRedondear(string formula, List<Elemento> elementos)
        {
            formula = ReplaceVariableComplex(formula, elementos);
            string[] divForm = formula.Split(',');
            string opt = divForm[1][0].ToString();
            formula = divForm[0].ToString() + ")";

            string result = string.Empty;
            result = ExecuteSimpleFormula(formula);
            result = Math.Round(System.Convert.ToDecimal(result), System.Convert.ToInt32(opt)).ToString();

            return result;
        }
        
        public string ExecuteRedondearMas(string formula, List<Elemento> elementos)
        {
            formula = ReplaceVariableComplex(formula, elementos);
            string[] divForm = formula.Split(',');
            string opt = divForm[1][0].ToString();
            formula = divForm[0].ToString() + ")";

            string result = string.Empty;

            switch(opt)
            {
                case "0":
                    result = ExecuteSimpleFormula(formula);
                    result = Math.Ceiling(System.Convert.ToDecimal(result)).ToString();
                    break;

                case "1":
                    result = ExecuteSimpleFormula(formula);
                    result = Math.Ceiling(System.Convert.ToDecimal(result)).ToString();
                    break;

                case "-1":
                    result = ExecuteSimpleFormula(formula);
                    result = Math.Floor(System.Convert.ToDecimal(result)).ToString();
                    break;
            }
            result = "(" + result + ")";

            return result;
        }

        /// <summary>
        /// Ejecuta la formula y obtiene el valor retornado
        /// </summary>
        /// <param name="formula">Formula</param>
        /// <param name="error"></param>
        /// <returns></returns>
        public double ExecuteFormula(string formula, List<Elemento> values,out string error)
        {
            //formula = ReplaceVariables(formula, values,out error);
            formula = ReplaceVariableComplex(formula, values);
            error = string.Empty;
            VsaEngine engine = VsaEngine.CreateEngine();
            object result = null;

            
            if (!string.IsNullOrEmpty(formula))
            {
                try
                {
                    result = Eval.JScriptEvaluate(formula, engine);
                }
                catch(Exception e)
                {
                    if (string.Equals("n/a", formula))
                        error = "";
                    else
                        error = e.Message;
                    return 0;
                }
            }
            else
            {
                error = "La formula no puede estar vacia";
            }

            if(Double.IsInfinity(System.Convert.ToDouble(result)))
            {
                return 0;
            }

            return System.Convert.ToDouble(result);
        }

        public string ExecuteSimpleFormula(string formula)
        {
            VsaEngine engine = VsaEngine.CreateEngine();
            object result = null;

            if (!string.IsNullOrEmpty(formula))
            {
                try
                {
                    result = Eval.JScriptEvaluate(formula, engine);
                    if (Double.IsInfinity(System.Convert.ToDouble(result)))
                    {
                        return "0";
                    }
                }
                catch (Exception e)
                {
                    return "0";
                }
            }

            return result.ToString();
        }

        public bool FormulaValidator(string formula)
        {
            List<string> variables = GetVariables(formula);
            List<Elemento> variableList = new List<Elemento>();
            Random ran = new Random();
            string error = string.Empty;
            
            for(int i = 0; i<variables.Count;i++)
            {
                Elemento var = new Elemento();
                var.Elemento_ = variables[i];
                var.Value = ran.Next(1,20).ToString();
                variableList.Add(var);
            }

            double result = ExecuteFormula(formula, variableList, out error);

            if(result == 0)
            {
                return false;
            }

            return true;
        }

        //public bool FormulaEval(string formula)
        //{
        //    List<string> variables = GetVariables(formula);


        //}

        public bool ValidateParentesis(string expresion)
        {
            int corcheteInicial = 0;
            int corcheteFinal = 0;

            for(int i=0;i<expresion.Length;i++)
            {
                if(expresion[i].Equals('('))
                {
                    corcheteInicial++;
                }
                if(expresion[i].Equals(')'))
                {
                    corcheteFinal++;
                }
            }
            if(corcheteInicial==corcheteFinal)
            {
                return true;
            }
            return false;
        }

        public bool isValidToMasterEvaluator(string expresion)
        {

            if (expresion.Contains("ENTERO") || expresion.Contains("REDONDEAR.MAS") || expresion.Contains("CONDICIONALM") ||
                expresion.Contains("CONDICIONALC") || expresion.Contains("REDONDEAR") || expresion.Contains("ID") ||
                expresion.Contains("RESULT") || expresion.Contains("REDOND.MULT"))
            {
                return true;
            }
            return false;
        }

        public Dictionary<string,int> CountParentesis(string expresion)
        {
            int corcheteInicial = 0;
            int corcheteFinal = 0;
            Dictionary<string, int> parentesis = new Dictionary<string, int>(); 

            for (int i = 0; i < expresion.Length; i++)
            {
                if (expresion[i].Equals('('))
                {
                    corcheteInicial++;
                }
                if (expresion[i].Equals(')'))
                {
                    corcheteFinal++;
                }
            }
            if (corcheteInicial > corcheteFinal)
            {
                parentesis.Add("(", corcheteInicial);
                return parentesis;
            }
            else if(corcheteInicial < corcheteFinal)
            {
                parentesis.Add(")", corcheteFinal);
            }
            else
            {
                parentesis.Add("|", 0);
            }

            return parentesis;
        }

    }
}
