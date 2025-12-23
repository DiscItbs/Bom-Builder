using BOM_Builder.Models;
using Simpro.Expr;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOM_Builder.Controllers
{
    public class CondicionalesController
    {
        EvaluacionFormulasController eval = new EvaluacionFormulasController();
        SQLServer sql = new SQLServer();
        ExprParser exp = new ExprParser();

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
            double auxDecimal = 0;
            string[] decimalespunto = new string[] { };

            if (decimales.Count > 0)
            {
                foreach (var _decimal in decimales)
                {
                    decimalespunto = _decimal.Split('.');
                    if(decimalespunto[1].Length>6)
                    {
                        auxDecimal = Math.Round(System.Convert.ToDouble(_decimal), 6);
                        expresion = expresion.Replace(_decimal, auxDecimal.ToString());
                    }
                    else
                    {
                        auxDecimal = System.Convert.ToDouble(_decimal);
                    }
                    fraccion = new Fraccion();
                    fraccion = DecimalToFraccion(auxDecimal);
                    aux = string.Format("({0}/{1})", fraccion.Numerador, fraccion.Denominador);
                    expresion = expresion.Replace(auxDecimal.ToString(), aux);
                }
            }
            return expresion;
        }

        public Fraccion DecimalToFraccion(double num)
        {
            //num = Math.Round(num,6);
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

        public string ExecuteCondicional(NM_Condicional condicional)
        {
            ExprParser ep = new ExprParser();
            LambdaExpression lambda;
            bool result = false;
            bool validMaster = isValidToMasterEvaluator(condicional.Condicional);

            try
            {
                condicional.Condicional = ReplaceDecimalToFraction(condicional.Condicional);
                lambda = ep.Parse(condicional.Condicional);
                result = (bool)ep.Run(lambda);
            }
            catch (ExprException e)
            {
                MessageBox.Show(e.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return result ? condicional.Verdadero : condicional.Falso;
        }

        public string ExecuteCondicional(NM_Condicional condicional, List<Elemento> elementos)
        {
            ExprParser ep = new ExprParser();
            LambdaExpression lambda;
            bool result = false;
            bool validMaster = isValidToMasterEvaluator(condicional.Condicional);

            if(validMaster)
            {
                condicional.Condicional = MasterEvaluator(condicional.Condicional, elementos);
            }

            string condicional_ = ReplaceVariableComplex(condicional.Condicional, elementos); 

            try
            {
                condicional_ = GetSimpleConditional(condicional_);
                condicional_ = ReplaceDecimalToFraction(condicional_);
                lambda = ep.Parse(condicional_);
                result = (bool)ep.Run(lambda);
            }
            catch (ExprException e)
            {
                if(string.Equals(condicional_,"True") || string.Equals(condicional_, "False"))
                {
                    if(string.Equals(condicional_, "True"))
                    {
                        result = true;
                    }
                    else if(string.Equals(condicional_, "False"))
                    {
                        result = false;
                    }
                }
                else
                {
                    MessageBox.Show(e.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }

            return result ? condicional.Verdadero : condicional.Falso;
        }

        public string GetSimpleConditional(string condicional)
        {
            string[] separators = new string[] { "&&", "||" };
            string[] parts = condicional.Split(separators,StringSplitOptions.RemoveEmptyEntries);
            string[] separatorsSecondLevel = new string[] { "<", ">","<=",">=","==","!="};
            string[] partsSecondLevel;
            string result = string.Empty;
            bool resultParentesis = false;
            string aux = string.Empty;
            Dictionary<string, int> parentesis = new Dictionary<string, int>();

            if (parts.Length>0)
            {
                foreach(var part in parts)
                {
                    partsSecondLevel = part.Split(separatorsSecondLevel, StringSplitOptions.RemoveEmptyEntries);

                    if(partsSecondLevel.Length > 0)
                    {
                        resultParentesis = eval.ValidateParentesis(partsSecondLevel[0]);

                        if (!resultParentesis)
                        {
                            parentesis = eval.CountParentesis(partsSecondLevel[0]);
                            if(parentesis.ContainsKey("("))
                            {
                                aux = partsSecondLevel[0];
                                aux = aux.Trim();
                                if (aux[0].Equals('('))
                                {
                                    partsSecondLevel[0] = aux.Remove(0, 1);
                                }
                            }
                            else
                            {
                                aux = partsSecondLevel[0];
                                aux = aux.Trim();
                                if (aux[0].Equals(")"))
                                {
                                    partsSecondLevel[0] = aux.Remove(0, 1);
                                }
                            }
                            
                            result = eval.ExecuteSimpleFormula(partsSecondLevel[0]);
                            condicional = condicional.Replace(partsSecondLevel[0], result);
                        }
                    }
                }
            }

            return condicional;
        }

        public bool ValidateConditional(string condicional)
        {
            List<string> variables = eval.GetVariables(condicional);
            List<string> values = new List<string>();
            Random ran = new Random();
            string newCondicional = string.Empty;
            ExprParser ep = new ExprParser();
            LambdaExpression lambda;
            bool result = false;
            for (int i = 0; i < variables.Count; i++)
            {
                values.Add(ran.Next(1, 20).ToString());
            }

            newCondicional = ReplaceVariables(condicional, values);

            try
            {
                lambda = ep.Parse(newCondicional);
                result = (bool)ep.Run(lambda);
            }
            catch (ExprException e)
            {
                string message = e.Message;
                return false;
            }

            return true;
        }

        public string ReplaceVariables(string condicional, List<string> values)
        {
            int contador = 0;

            List<string> variables = eval.GetVariables(condicional);
            //variables = VariablesToLower(variables);

            foreach (var variable in variables)
            {
                condicional = condicional.Replace(variable, values[contador]);
                contador++;
            }
            return condicional;
        }

        public string ReplaceVariableComplex(string condicional, List<Elemento> elementos)
        {
            List<string> variables = eval.GetVariables(condicional);
            CultureInfo culture = new CultureInfo("es-ES");
            Elemento totalCantidad = GetElemento(elementos, "totalcantidad");
            Elemento totalMedida = GetElemento(elementos, "totalmedida");
            //variables = VariablesToLower(variables);
            int index = 0;

            foreach (Elemento elemento in elementos)
            {
                //if (variables.Contains(elemento.Elemento_, System.StringComparison.CurrentCultureIgnoreCase))
                if(culture.CompareInfo.IndexOf(condicional,elemento.Elemento_,CompareOptions.IgnoreCase) >=0)
                {
                    if(!condicional.Contains("totalcantidad") && !condicional.Contains("totalmedida"))
                    {
                        index = variables.IndexOf(elemento.Elemento_);
                        //condicional = condicional.Replace(variables[index], elemento.Value);
                        condicional = Regex.Replace(condicional, elemento.Elemento_, elemento.Value, RegexOptions.IgnoreCase);
                    }
                    else if(condicional.Contains("totalcantidad"))
                    {
                        condicional = condicional.Replace("totalcantidad", totalCantidad.Value);
                    }
                    else if (condicional.Contains("totalmedida"))
                    {
                        condicional = condicional.Replace("totalmedida", totalMedida.Value);
                    }
                    //break;
                }
            }
            return condicional;
        }

        public Elemento GetElemento(List<Elemento> elementos, string nameElement)
        {
            foreach(var elemento in elementos)
            {
                if(elemento.Elemento_.Equals(nameElement))
                {
                    return elemento;
                }
            }

            return null;
        }

        public List<string> VariablesToLower(List<string> variables)
        {
            List<string> variablesLower = new List<string>();

            foreach(var variable in variables)
            {
                variablesLower.Add(variable.ToLower());
            }

            return variablesLower;
        }

        public string ReplaceCondicional(string expresion, List<Elemento> elementos)
        {
            char caracter;
            char tipoCondicional = 'X';
            bool flag = false;
            int corcheteInicial = 0;
            int corcheteFinal = 0;
            string idCondicional = string.Empty;
            string backupCondicional = string.Empty;
            string condicionalResult = string.Empty;
            NM_Condicional condicional = new NM_Condicional();
            NM_CondicionalMaster master = new NM_CondicionalMaster();

            if (expresion.Contains("CONDICIONAL"))
            {
                for (int i = 0; i < expresion.Length; i++)
                {
                    caracter = expresion[i];

                    if (caracter == 'C' && expresion[i + 1] == 'O' && expresion[i + 2] == 'N' && expresion[i + 3] == 'D' && expresion[i + 4] == 'I' &&
                        expresion[i + 5] == 'C' && expresion[i + 6] == 'I' && expresion[i + 7] == 'O' && expresion[i + 8] == 'N' && expresion[i + 9] == 'A' && expresion[i + 10] == 'L')
                    {
                        tipoCondicional = expresion[i + 11]; 
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
                            if (caracter != '(' && caracter != ')')
                            {
                                idCondicional += caracter;
                            }
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

                
                
                if(tipoCondicional.Equals('M'))
                {
                    backupCondicional = "CONDICIONALM(" + idCondicional + ")";
                    master = sql.GetCondicionalMasterInfo(idCondicional);
                    condicionalResult = ExecuteMasterConditional(master.IdCondicionalMaster.ToString(), master.IdCompuesto, master.Nombre, elementos);
                }
                else
                {
                    backupCondicional = "CONDICIONALC(" + idCondicional + ")";
                    condicional = sql.GetCondicional(idCondicional);
                    condicional.Condicional = ReplaceVariableComplex(condicional.Condicional, elementos);
                    condicionalResult = ExecuteCondicional(condicional);
                }
                condicionalResult = "(" + condicionalResult + ")";
                expresion = expresion.Replace(backupCondicional, condicionalResult);

            }

            return expresion;
        }

        public string ExecuteMasterConditional(string idMaster,string idCompuesto,string nombreMaster, List<Elemento> valores)
        {
            ExprParser ep = new ExprParser();
            LambdaExpression lambda;
            bool result = false;
            List<NM_CondicionalMaster> nodos = sql.GetElementsMasterCondicional(idMaster,idCompuesto,nombreMaster);
            NM_Condicional condicional = sql.GetCondicional(idMaster);
            string currentCondicional = string.Empty;
            string currentFormula = string.Empty;
            int currentLevel = 0;
            List<NM_CondicionalMaster> aux = new List<NM_CondicionalMaster>();
            string executedResult = string.Empty;
            string posicion = string.Empty;
            bool validMaster = false;
            string path = string.Empty;
            
            while (true)
            {
                try
                {
                    condicional.Condicional = ReplaceVariableComplex(condicional.Condicional, valores);
                    sql.GetPathAndFatherCondicional(idMaster, idCompuesto, ref condicional);

                    validMaster = isValidToMasterEvaluator(condicional.Condicional);

                    //Valida si dentro de esa condicional no existen palabras reservadas (ID,ENTERO,REDONDEAR.MAS,etc)
                    if(validMaster)
                    {
                        condicional.Condicional = MasterEvaluator(condicional.Condicional, elementos: valores);
                        condicional.Condicional = ReplaceVariableComplex(condicional.Condicional, valores);

                        if (string.Equals(condicional.Condicional,"True"))
                        {
                            result = true;
                        }
                        else if(string.Equals(condicional.Condicional, "False"))
                        {
                            result = false;
                        }
                    }
                    //else
                    //{
                    //condicional.Condicional = eval.ReplaceDecimalToFraction(condicional.Condicional);
                    result = GetResultCondicional(condicional.Condicional);
                    //lambda = exp.Parse(condicional.Condicional);//ep.Parse(condicional.Condicional);
                    //result = (bool)exp.Run(lambda);
                    //}
                    currentLevel += 2;

                    if (result)
                    {
                        posicion = "Verdadero";
                    }
                    else
                    {
                        posicion = "Falso";
                    }

                    if(!string.IsNullOrEmpty(condicional.Path))
                    {
                        path = condicional.Path + "\\" + posicion;
                        aux[0] = FindNodoPath(nodos,path, currentLevel);
                    }
                    else
                    {
                        aux = (from nodo in nodos where nodo.Nivel == currentLevel && nodo.Posicion == posicion select nodo).ToList();
                    }

                    if (aux.Count > 0 && aux[0]!=null)
                    {
                        if (aux[0].Tipo == "Formula")
                        {
                            condicional.Condicional = sql.GetDataFromElement(aux[0].IdElemento.ToString(), "Formula");
                            condicional.Condicional = ReplaceVariableComplex(condicional.Condicional, valores);
                            if (condicional.Condicional.Contains("ENTERO") || condicional.Condicional.Contains("REDONDEAR.MAS") || condicional.Condicional.Contains("CONDICIONALM") ||
                                condicional.Condicional.Contains("CONDICIONALC") || condicional.Condicional.Contains("ID") || condicional.Condicional.Contains("RESULT"))
                            {
                                executedResult = MasterEvaluator(condicional.Condicional, valores);
                            }
                            else
                            {
                                executedResult = eval.ExecuteSimpleFormula(condicional.Condicional).ToString();
                            }
                            break;
                        }
                        else
                        {
                            condicional = sql.GetCondicional(aux[0].IdElemento.ToString());
                        }
                    }
                    else
                    {
                        if (posicion == "Verdadero")
                            executedResult = condicional.Verdadero;
                        else
                            executedResult = condicional.Falso;
                        break;
                    }
                }
                catch (ExprException e)
                {
                    string message = e.Message;
                }
            }

            return executedResult;
        }

        public NM_CondicionalMaster FindNodoPath(List<NM_CondicionalMaster> nodos, string path, int level)
        {
            string pathAux = string.Empty;

            foreach(var nodo in nodos)
            {
                //pathAux = path + "\\" + nodo.NodoPadre;
                if (nodo.Path.Contains(path) && nodo.Nivel == level)
                {
                    return nodo;
                }
                pathAux = string.Empty;
            }

            return null;
        }

        public string FindIndex(List<NM_CondicionalMaster> nodos, List<string> variables)
        {
            string idElemento = string.Empty;

            foreach (NM_CondicionalMaster nodo in nodos)
            {
                if (string.Equals(nodo.Tipo, "Raiz"))
                {
                    idElemento = nodo.IdElemento.ToString();
                }
            }

            return idElemento;
        }

        public string makeIdComposed(List<NM_CondicionalMaster> nodos)
        {
            string id = string.Empty;

            foreach(NM_CondicionalMaster nodo in nodos)
            {
                id += nodo.IdElemento + nodo.Nivel;
            }

            return id;
        }

        public int makeIdMaster()
        {
            Random random = new Random();
            int rand = 0;
            string query = string.Empty;
            bool flag = true;
            string value = string.Empty;
            while(flag)
            {
                rand = random.Next(1000, 9999);
                query = string.Format("SELECT id FROM NM_CondicionalMaster WHERE IdCondicionalMaster = '{0}'",rand);
                value = sql.Select(query, "id");
                if (string.IsNullOrEmpty(value))
                    flag = false;
            }
            
            return rand;
        }

        public string MasterEvaluator(string expresion, List<Elemento> elementos, List<Result> results = null, string optFormula = "")
        {
            int opt = 0;
            string result = string.Empty;

            while(true)
            {
                if (expresion.Contains("CONDICIONALM"))
                {
                    //opt = 1;
                    expresion = ReplaceCondicional(expresion, elementos);
                }
                else if (expresion.Contains("CONDICIONALC"))
                {
                    expresion = ReplaceCondicional(expresion, elementos);
                    //opt = 2;
                }
                else if (expresion.Contains("ID"))
                {
                    expresion = ReplaceIds(expresion, elementos);
                    //opt = 3;
                }
                else if (expresion.Contains("ENTERO"))
                {
                    expresion = ReplaceEntero(expresion, elementos,results);
                    //opt = 4;
                }
                else if (expresion.Contains("REDONDEAR.MAS"))
                {
                    expresion = ReplaceRedondearMas(expresion, elementos);
                    //opt = 5;
                }
                else if (expresion.Contains("REDONDEAR"))
                {
                    expresion = eval.ReplaceRedondear(expresion, elementos);
                    //opt = 6;
                }
                else if (expresion.Contains("RESULT"))
                {
                    expresion = ReplaceResult(expresion, results, optFormula);
                    //opt = 7;
                }
                else if (expresion.Contains("REDOND.MULT"))
                {
                    expresion = ReplaceMRound(expresion, elementos);
                    //opt = 7;
                }
                else
                {
                    break;
                }
            }

            return expresion;
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
            formula = eval.ExecuteRedondear(formula, elementos);

            try
            {
                backupFormula = "REDONDEAR" + backupFormula;
                expresion = expresion.Replace(backupFormula, formula);
                expresion = ReplaceVariableComplex(expresion, elementos);
                if (expresion.Contains("ENTERO") || expresion.Contains("CONDICIONALM") || expresion.Contains("CONDICIONALC"))
                {
                    return expresion;
                }
                expresion = eval.ExecuteSimpleFormula(expresion);
            }
            catch (ExprException e)
            {
                string message = e.Message;
            }

            return expresion;

        }

        public string ReplaceEntero(string expresion, List<Elemento> elementos, List<Result> results)
         {
            int corcheteInicial = 0;
            int corcheteFinal = 0;
            char caracter;
            bool flag = false;
            int countEntero = 0;
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
                        flag = true;
                        countEntero++;
                        if(countEntero==1)
                        {
                            i = i + 5;
                        }
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

                    //formula += caracter;
                    if (flag)
                    {
                        formula += caracter;
                    }
                    //if(string.Equals(caracter,'E'))
                    //{
                    //    EFlag = true;
                    //}
                }
            }
            else
            {
                return expresion;
            }

            if (formula.StartsWith("E"))
                formula = formula.TrimStart('E');

            if (formula.Contains("E("))
                formula = formula.Replace("E(","(");

            backupFormula = formula;
            formula = CleanExpresion(formula, elementos);
            try
            {
                evaluacion = eval.ExecuteSimpleFormula(formula);
                aux = System.Convert.ToDecimal(evaluacion);
                evaluacion = Math.Truncate(aux).ToString();
                evaluacion = "(" + evaluacion + ")";
                formula = "ENTERO" + backupFormula;
                expresion = expresion.Replace(formula, evaluacion);

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
            bool validToMaster = false;
            int countRedondearMas = 0;
            bool exitWhile = false;
            string error = string.Empty;

            if (expresion.Contains("REDONDEAR.MAS"))
            {
                for (int i = 0; i < expresion.Length; i++)
                {

                    if (expresion[i] == 'R' && expresion[i + 1] == 'E' && expresion[i + 2] == 'D' && expresion[i + 3] == 'O' && expresion[i + 4] == 'N' && expresion[i + 5] == 'D' &&
                        expresion[i + 6] == 'E' && expresion[i + 7] == 'A' && expresion[i + 8] == 'R' &&
                        expresion[i + 9] == '.' && expresion[i + 10] == 'M' && expresion[i + 11] == 'A' && expresion[i + 12] == 'S')
                    {
                        flag = true;
                        countRedondearMas++;
                        if (countRedondearMas == 1)
                        {
                            i = i + 13;
                        }
                    }

                    if (expresion[i] == '(' && flag)
                    {
                        corcheteInicial++;
                    }
                    if (expresion[i] == ')' && flag)
                    {
                        corcheteFinal++;

                        if (corcheteInicial == corcheteFinal)
                        {
                            formula += expresion[i];
                            break;
                        }
                    }
                    if (flag)
                    {
                        //if (caracter != 'R')
                        //{
                        //    formula += caracter;
                        //}
                        formula += expresion[i];
                    }

                }
            }
            else
            {
                return expresion;
            }

            if (formula.StartsWith("R"))
                formula = formula.TrimStart('R');

            if (formula.Contains("R("))
                formula = formula.Replace("R(", "(");

            if (formula.Contains("REDONDEA("))
                formula = formula.Replace("REDONDEA(", "REDONDEAR(");

            backupFormula = formula;
            if (isValidToMasterEvaluator(formula))//formula.Contains("ENTERO") || formula.Contains("ID") || formula.Contains("REDONDEAR.MAS"))
            {
                formula = MasterEvaluator(formula, elementos);
            }
            if (formula.Contains(",0") || formula.Contains(",1") || formula.Contains(",-1"))
            {
                formula = ReplaceVariableComplex(formula, elementos);
                formula = eval.ExecuteRedondearMas(formula, elementos);
            }

            try
            {

                while(!exitWhile)
                {
                    backupFormula = "REDONDEAR.MAS" + backupFormula;
                    expresion = expresion.Replace(backupFormula, formula);
                    expresion = ReplaceVariableComplex(expresion, elementos);

                    if (expresion.Contains(",0") || expresion.Contains(",1") || expresion.Contains(",-1"))
                    {
                        if (isValidToMasterEvaluator(expresion))
                        {
                            expresion = MasterEvaluator(expresion, elementos);
                        }
                        else
                        {
                            expresion = eval.ExecuteRedondearMas(expresion, elementos);
                        }
                    }
                    else
                    {
                        exitWhile = true;
                    }
                }

                if (expresion.Contains("<") || expresion.Contains(">") || expresion.Contains("==") || expresion.Contains("<=") ||
                       expresion.Contains(">=") || expresion.Contains("!="))
                {
                    return expresion;
                }

                expresion = eval.ExecuteSimpleFormula(expresion);
            }
            catch (ExprException e)
            {
                string message = e.Message;
            }

            return expresion;

        }

        public string ReplaceIds(string expresion, List<Elemento> elementos)
        {
            List<string> idsAux = new List<string>();
            NM_Condicional condicional = new NM_Condicional();
            NM_Formula formula = new NM_Formula();
            NM_CondicionalMaster master = new NM_CondicionalMaster();
            string error = string.Empty;
            List<string> variables = new List<string>();
            string value = string.Empty;
            string expresionBackup = expresion;
            string aux = string.Empty;
            char caracter;
            bool flag = false;
            int corcheteInicial = 0;
            int corcheteFinal = 0;
            string expresionIds = string.Empty;
            string expresionIdsBackup = string.Empty;
            bool validToMaster = false;

            expresion = ReplaceVariableComplex(expresion, elementos);

            if (expresion.Contains("ID"))
            {

                expresionIdsBackup = expresion;
                idsAux = GetIds(expresion);

                foreach (var id in idsAux)
                {
                    if(id.Contains("F"))
                    {
                        aux = id.Trim('F','(',')');
                        formula = sql.GetFormula(aux);
                        value = MasterEvaluator(formula.Formula, elementos);
                        value = eval.ExecuteFormula(value, elementos,out error).ToString();
                        expresion = expresion.Replace("ID"+id, "(" + value +")");
                    }
                    else if(id.Contains("C"))
                    {
                        aux = id.Trim('C','(',')');
                        condicional = sql.GetCondicional(aux);
                        condicional.Condicional = ReplaceVariableComplex(condicional.Condicional, elementos);
                        value = ExecuteCondicional(condicional,elementos);
                        value = MasterEvaluator(value, elementos);
                        expresion = expresion.Replace("ID"+id, "(" + value + ")");
                    }
                    else
                    {
                        aux = id.Trim('M','(',')');
                        master = sql.GetCondicionalMasterById(aux);
                        value = ExecuteMasterConditional(aux, master.IdCompuesto, master.Nombre, elementos);
                        value = MasterEvaluator(value, elementos);
                        expresion = expresion.Replace("ID"+id, "("+value+")");
                    }
                }

                validToMaster = isValidToMasterEvaluator(expresion);

                
                while(validToMaster)
                {
                    expresion = MasterEvaluator(expresion, elementos);

                    validToMaster = isValidToMasterEvaluator(expresion);
                }

                variables = GetVariables(expresion);

                if(variables.Count>0)
                {
                    if(expresion.Contains("<") || expresion.Contains(">") || expresion.Contains("==") || expresion.Contains("<=") ||
                       expresion.Contains(">=") || expresion.Contains("!="))
                    {
                        return expresion;
                    }
                    else if(expresion.Contains("True") || expresion.Contains("False"))
                    {
                        return expresion;
                    }
                    else
                    {
                        expresion = eval.ExecuteFormula(expresion, elementos, out error).ToString();
                    }
                    
                }
                else
                {
                    if (expresion.Contains("<") || expresion.Contains(">") || expresion.Contains("==") || expresion.Contains("<=") ||
                       expresion.Contains(">=") || expresion.Contains("!="))
                    {
                        return expresion;
                    }
                    else
                    {
                        expresion = eval.ExecuteFormula(expresion, elementos, out error).ToString();
                    }
                }
            }
            return expresion;
        }

        public string ReplaceResult(string expresion, List<Result> results, string optFormula)
        {
            char caracter;
            bool flag = false;
            int corcheteInicial = 0;
            int corcheteFinal = 0;
            string expresionResult = string.Empty;
            string expresionResultBackup = string.Empty;
            List<string> variables = new List<string>();
            string finalResult = string.Empty;

            if (expresion.Contains("RESULT"))
            {
                for (int i = 0; i < expresion.Length; i++)
                {
                    caracter = expresion[i];

                    if (caracter == 'R' && expresion[i + 1] == 'E' && expresion[i + 2] == 'S' && expresion[i + 3] == 'U'
                        && expresion[i + 4] == 'L' && expresion[i + 5] == 'T')
                    {
                        i = i + 5;
                        flag = true;
                    }
                    if (caracter != 'R' && caracter != 'E' && caracter != 'S' && caracter != 'U' &&
                        caracter != 'L' && caracter != 'T')
                    {
                        expresionResult += caracter;
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
                            break;
                        }
                    }
                }

                expresionResultBackup = expresionResult;
                finalResult = GetResult(results, expresionResult,optFormula);
                expresion = expresion.Replace(expresionResultBackup, finalResult);
                expresion = expresion.TrimStart('R', 'E','S','U','L','T');
                expresion = eval.ExecuteSimpleFormula(expresion);

            }

            return expresion;
        }

        public string ReplaceMRound(string expresion, List<Elemento> elementos)
        {
            char caracter;
            int corcheteInicial = 0;
            int corcheteFinal = 0;
            string expresionResult = string.Empty;
            bool flag = false;
            bool parentesis = false;
            string[] resultSplit = new string[] { };
            string backupExpresion = string.Empty;

            if (expresion.Contains("REDOND.MULT"))
            {
                for (int i = 0; i < expresion.Length; i++)
                {
                    caracter = expresion[i];

                    if (caracter == 'R' && expresion[i + 1] == 'E' && expresion[i + 2] == 'D' && expresion[i + 3] == 'O'
                        && expresion[i + 4] == 'N' && expresion[i + 5] == 'D' && expresion[i + 6] == '.' && expresion[i + 7] == 'M'
                        && expresion[i + 8] == 'U' && expresion[i + 9] == 'L' && expresion[i + 10] == 'T')
                    {
                        i = i + 11;
                        flag = true;
                        caracter = expresion[i];
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
                            expresionResult += caracter;
                            break;
                        }
                    }

                    if(flag)
                    {
                        expresionResult += caracter;
                    }
                }
                backupExpresion = expresionResult;
                resultSplit = expresionResult.Split(',');
                parentesis = eval.ValidateParentesis(resultSplit[0]);
                if(!parentesis)
                {
                    if(resultSplit[0][0]=='(')
                    {
                        resultSplit[0] = resultSplit[0].Remove(0, 1);
                    }
                }
                resultSplit[0] = CleanExpresion(resultSplit[0], elementos);

                parentesis = eval.ValidateParentesis(resultSplit[1]);
                if(!parentesis)
                {
                    if (resultSplit[1][resultSplit[1].Length-1] == ')')
                    {
                        resultSplit[1] = resultSplit[1].Remove(resultSplit[1].Length-1, 1);
                    }
                }
                resultSplit[1] = CleanExpresion(resultSplit[1], elementos);
                expresionResult = ExecuteRoundMult(resultSplit[0], resultSplit[1]);
                expresion = expresion.Replace("REDOND.MULT" +backupExpresion, "(" + expresionResult + ")");
                expresion = CleanExpresion(expresion, elementos);
            }
            return expresion;
        }

        public string ExecuteRoundMult(string numero, string multiplo)
        {
            string result = string.Empty;

            if(!string.IsNullOrEmpty(numero) && !string.IsNullOrEmpty(multiplo))
            {
                result = ((Math.Round(Convert.ToDouble(numero)/ Convert.ToDouble(multiplo),0))*Convert.ToDouble(multiplo)).ToString();
                return result;
            }

            return null;
        }

        public string CleanExpresion(string expresion, List<Elemento> elementos)
        {
            bool validToMaster = false;
            List<string> variables = new List<string>();
            string error = string.Empty;

            if(!string.IsNullOrEmpty(expresion) && elementos!=null)
            {
                validToMaster = isValidToMasterEvaluator(expresion);

                while (validToMaster)
                {
                    expresion = MasterEvaluator(expresion, elementos);

                    validToMaster = isValidToMasterEvaluator(expresion);
                }

                variables = GetVariables(expresion);

                if (variables.Count > 0)
                {
                    expresion = eval.ExecuteFormula(expresion, elementos, out error).ToString();
                }
                else
                {
                    expresion = eval.ExecuteSimpleFormula(expresion);
                }

                return expresion;
            }
            
            return null;
        }

        public List<string> GetIds(string expresion)
        {
            char caracter;
            bool flag = false;
            int corcheteInicial = 0;
            int corcheteFinal = 0;
            string expresionIds = string.Empty;
            string expresionBackup = expresion;
            List<string> ids = new List<string>();

            if(expresion.Contains("CANTIDAD"))
            {
                expresion = expresion.Replace("CANTIDAD", "cantidad");
            }

            while(expresion.Contains("ID"))
            {
                for (int i = 0; i < expresion.Length; i++)
                {
                    caracter = expresion[i];

                    if (caracter == 'I' && expresion[i + 1] == 'D')
                    {
                        i = i + 1;
                        flag = true;
                    }
                    if (caracter != 'I' && flag == true)
                    {
                        expresionIds += caracter;
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
                            break;
                        }
                    }
                }
                flag = false;
                ids.Add(expresionIds);
                expresion = expresion.Replace("ID"+expresionIds, "");
                expresionIds = string.Empty;
            }

            return ids;
        }

        public string ReplaceVariableComplexEntero(string condicional, List<Elemento> elementos)
        {
            List<string> variables = GetVariables(condicional);
            int index = 0;

            foreach (Elemento elemento in elementos)
            {
                if (variables.Contains(elemento.Elemento_))
                {
                    index = variables.IndexOf(elemento.Elemento_);
                    condicional = condicional.Replace(variables[index], elemento.Value);
                    break;
                }
            }
            return condicional;
        }

        public List<string> GetVariables(string formula)
        {
            //string remove = Regex.Replace(formula, "[^a-zA-Z0-9]+", " ", RegexOptions.Compiled);
            string remove = Regex.Replace(formula, "[^a-zA-Z]+", " ", RegexOptions.Compiled);

            string[] split = remove.Split(' ');
            List<string> variables = split.ToList();
            return RemoveBlankSpaces(variables);
        }
        public NM_CondicionalMaster NextNodo(List<NM_CondicionalMaster> nodos, int level, string posicion)
        {
            foreach(NM_CondicionalMaster nodo in nodos)
            {
                if(nodo.Nivel==level)
                {
                    if(nodo.Posicion==posicion)
                    {
                        return nodo;
                    }
                }
            }
            return null;
        }

        private List<string> RemoveBlankSpaces(List<string> variables)
        {
            //for (int i = 0; i < variables.Count; i++)
            //{
            //    variables.Remove("");
            //}
            List<string> aux = variables.ToList();

            foreach (var variable in aux)
            {
                if(string.IsNullOrEmpty(variable))
                {
                    variables.Remove(variable);
                }
            }

            return variables;
        }

        public string GetResult(List<Result> results, string expresion, string optFormula)
        {
            List<Result> findResults = new List<Result>();
            List<string> variables = eval.GetVariablesIds(expresion);
            int resultado = 0;

            foreach(var variable in variables)
            {
                foreach(var result in results)
                {
                    if(result.Itemno.Contains(variable))
                    {
                        if(!result.IsUsed)
                        {
                            findResults.Add(result);
                            result.IsUsed = true;
                        }
                    }
                }
            }

            if (findResults.Count == variables.Count)
            {
                foreach (var result_ in findResults)
                {
                    switch(optFormula)
                    {
                        case "qty":
                            resultado += Convert.ToInt32(result_.resultQty);
                            break;

                        case "md":
                            resultado += Convert.ToInt32(result_.resultQty);
                            break;

                        case "total":
                            resultado += Convert.ToInt32(result_.resultQty);
                            break;
                    }
                    
                }
            }

            return "(" + resultado.ToString() + ")";
        }

        

        public bool AritmeticOptions(string value)
        {
            string[] result = new string[] { };
            string[] spliter_equal = new string[] {"=="};
            string[] spliter_lessThan = new string[] { "<=" };
            string[] spliter_moreThan = new string[] { ">=" };
            string[] spliter_notEqual = new string[] { "!=" };
            double valueLeft = 0;
            double valueRight = 0;

            

            if (value.Contains("=="))
            {
                result = value.Split(spliter_equal, StringSplitOptions.RemoveEmptyEntries);

                result[0] = CleanExpresion(result[0]);
                result[1] = CleanExpresion(result[1]);

                valueLeft = Convert.ToDouble(eval.ExecuteSimpleFormula(result[0]));
                valueRight = Convert.ToDouble(eval.ExecuteSimpleFormula(result[1]));

                if (valueLeft == valueRight)
                {
                    return true;
                }

                return false;
            }

            else if (value.Contains("<="))
            {
                result = value.Split(spliter_lessThan, StringSplitOptions.RemoveEmptyEntries);

                result[0] = CleanExpresion(result[0]);
                result[1] = CleanExpresion(result[1]);

                valueLeft = Convert.ToDouble(eval.ExecuteSimpleFormula(result[0]));
                valueRight = Convert.ToDouble(eval.ExecuteSimpleFormula(result[1]));

                if (valueLeft <= valueRight)
                {
                    return true;
                }

                return false;
            }
            else if (value.Contains(">="))
            {
                result = value.Split(spliter_moreThan, StringSplitOptions.RemoveEmptyEntries);

                result[0] = CleanExpresion(result[0]);
                result[1] = CleanExpresion(result[1]);

                valueLeft = Convert.ToDouble(eval.ExecuteSimpleFormula(result[0]));
                valueRight = Convert.ToDouble(eval.ExecuteSimpleFormula(result[1]));

                if (valueLeft >= valueRight)
                {
                    return true;
                }

                return false;
            }

            else if (value.Contains("!="))
            {
                result = value.Split(spliter_notEqual, StringSplitOptions.RemoveEmptyEntries);

                result[0] = CleanExpresion(result[0]);
                result[1] = CleanExpresion(result[1]);

                valueLeft = Convert.ToDouble(eval.ExecuteSimpleFormula(result[0]));
                valueRight = Convert.ToDouble(eval.ExecuteSimpleFormula(result[1]));

                if (valueLeft != valueRight)
                {
                    return true;
                }

                return false;
            }

            else if (value.Contains('<'))
            {
                result = value.Split('<');

                result[0] = CleanExpresion(result[0]);
                result[1] = CleanExpresion(result[1]);

                valueLeft = Convert.ToDouble(eval.ExecuteSimpleFormula(result[0]));
                valueRight = Convert.ToDouble(eval.ExecuteSimpleFormula(result[1]));

                if (valueLeft < valueRight)
                {
                    return true;
                }

                return false;
            }

            else if (value.Contains('>'))
            {
                result = value.Split('>');

                result[0] = CleanExpresion(result[0]);
                result[1] = CleanExpresion(result[1]);

                valueLeft = Convert.ToDouble(eval.ExecuteSimpleFormula(result[0]));
                valueRight = Convert.ToDouble(eval.ExecuteSimpleFormula(result[1]));

                if (valueLeft > valueRight)
                {
                    return true;
                }

                return false;
            }

            return false;

        }

        public string[] GetValuesConditionalAndOr(string expresion)
        {
            string[] separators = new string[] { "||","&&" };
            string[] split = expresion.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (split[0].StartsWith("(") && !split[0].EndsWith(")"))
            {
                split[0] = split[0].Substring(1);
            }
            else if (!split[0].StartsWith("(") && split[0].EndsWith(")"))
            {
                split[0] = split[0].Substring(0, split[0].Length - 1);
            }
            if (split[split.Length - 1].EndsWith(")") && !split[split.Length - 1].StartsWith("("))
            {
                split[split.Length - 1] = split[split.Length - 1].Substring(0, split[split.Length - 1].Length - 1);
            }
            else if (!split[split.Length - 1].EndsWith(")") && split[split.Length - 1].StartsWith("("))
            {
                split[split.Length - 1] = split[split.Length - 1].Substring(1);
            }

            return split;
        }

        public bool GetResultCondicional(string expresion)
        {
            List<bool> trueOrFalse = new List<bool>();
            string[] values = GetValuesConditionalAndOr(expresion);
            int cont = 0;
            bool or = expresion.Contains("||");

            while(cont<values.Length)
            {
                trueOrFalse.Add(AritmeticOptions(values[cont]));

                cont++;
            }

            if(or && trueOrFalse.Contains(true) && trueOrFalse.Contains(false))
            {
                return true;
            }
            else if(or && !trueOrFalse.Contains(false))
            {
                return true;
            }
            else if(!or && !trueOrFalse.Contains(false))
            {
                return true;
            }

            return false;
        }

        public string CleanExpresion(string expresion)
        {
            expresion = expresion.Trim();

            Dictionary<string,int> result = eval.CountParentesis(expresion);

            if(result.ContainsKey("("))
            {
                if (expresion.StartsWith("("))// && !expresion.EndsWith(")"))
                {
                    expresion = expresion.Substring(1);
                }
                //else if (!expresion.StartsWith("(") && expresion.EndsWith(")"))
                //{
                //    expresion = expresion.Substring(0, expresion.Length - 1);
                //}
            }
            else if(result.ContainsKey(")"))
            {
                if (expresion.EndsWith(")"))// && !expresion.StartsWith("("))
                {
                    expresion = expresion.Substring(0, expresion.Length - 1);
                }
                //else if (!expresion.EndsWith(")") && expresion.StartsWith("("))
                //{
                //    expresion = expresion.Substring(1);
                //}
            }

            return expresion;
        }

    }
}
