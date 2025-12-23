using BOM_Builder.Controllers;
using BOM_Builder.Models;
using System;
using System.Collections.Generic;

namespace BOM_Builder.BL
{
  public class GeneratorBomsComponents
  {
    #region VARIABLES GLOBALES

    ModeladoBomController modeladoBomController = new ModeladoBomController();
    EvaluacionFormulasController evaluadorController = new EvaluacionFormulasController();
    CondicionalesController condicionalesController = new CondicionalesController();
    SQLServer sql = new SQLServer();
    List<Result> results = new List<Result>();

    #endregion

    /// <summary>
    /// Funcion para obtener la lista de componentes con sus respetivos resultados en formulas y cantidades
    /// </summary>
    /// <param name="modelCompleteBom">Nombre del modelo ensamblado o submodelo</param>
    /// <param name="dataListVariables">Lista de variables para calcular formulas y sustituir valores</param>
    /// <param name="finishes">Acabado del componente</param>
    /// <param name="errorMethod">Mensaje de error ocacionado en el proceso</param>
    /// <returns>Lista de componentes</returns>
    public List<ComponenteModel> GetComponents(string modelCompleteBom, BomForm form, string finishes, out string errorMethod,
                                               ref int totalCantidad, ref double totalMedida, ref double totalPerfil)
    {
      List<ComponenteModel> list_components = new List<ComponenteModel>();
      ComponenteModel componente;
      string error = string.Empty;

      try
      {
        List<ModeladoBomModel> data_list = new List<ModeladoBomModel>();
        data_list = modeladoBomController.GetBomModels(modelCompleteBom, finishes, out error);

        if (data_list.Count != 0)
        {
          foreach (var item in data_list)
          {
            componente = new ComponenteModel();
            componente = GetDataComponents(item.Itemno, item.Class, item.Nombre_Componente, item.FormulaQty,
                item.FormulaMd, item.FormulaTotal, item.FormulaPeso, item.IdCondicionalTotal, item.IdCondicionalQty, item.IdCondicionalMd,
                item.Type_ConditionalQty, item.Type_ConditionalMd, item.IdCompuestoQty, item.IdCompuestoMd, item.NombreMasterMd,
                item.NombreMasterQty, form, out error, ref totalCantidad, ref totalMedida, ref totalPerfil);
            componente.Seccion = item.Seccion;
            componente.Linea = item.Linea;
            componente.Descripcion = item.Descripcion;

            list_components.Add(componente);
          }
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        list_components = null;
      }

      errorMethod = error;
      return list_components;
    }

    /// <summary>
    /// Funcion para crear el componente individual del bom
    /// </summary>
    /// <param name="itemno">Numero de parte del item</param>
    /// <param name="pClass">Clase del item</param>
    /// <param name="nameComponent">Nombre del componente</param>
    /// <param name="formulaQty">Formula para cantidad</param>
    /// <param name="formulaMd">Formula para meidad</param>
    /// <param name="formulaTotal">Formula para totales</param>
    /// <param name="dataListVariables">Lista de variables para calcular formulas y sustituir valores</param>
    /// <param name="errorMethod">Mensaje de error ocacionado en el proceso</param>
    /// <returns>Componente completo con valores</returns>
    public ComponenteModel GetDataComponents(string itemno, string pClass, string nameComponent, string formulaQty, string formulaMd,
                                            string formulaTotal, string idFormulaPeso, int IdCondicionalTotal, int IdCondicionalQty, int IdCondicionalMd,
                                            string typeConditionalQty, string typeConditionalMd, string idCompuestoQty, string idCompuestoMd,
                                            string nombreMasterMd, string nombreMasterQty, BomForm form,
                                            out string errorMethod, ref int totalCantidad, ref double totalMedida, ref double totalPerfil)
    {

      List<Elemento> data_list_variables_totales = new List<Elemento>();
      Elemento data_model_variables_totales = new Elemento();
      List<FormulaVariableModel> data_list_variables_temp = new List<FormulaVariableModel>();
      FormulaVariableModel data_model_variables_temp = new FormulaVariableModel();
      ComponenteModel data_model = new ComponenteModel();
      List<Elemento> data_list_elements = new List<Elemento>();
      Elemento data_element_special = new Elemento();
      List<Elemento> data_list_elements_special = new List<Elemento>();
      Elemento data_model_element = new Elemento();
      NM_Condicional condicional = new NM_Condicional();
      NM_Formula formulaPeso = new NM_Formula();
      EvaluacionFormulasController eval = new EvaluacionFormulasController();
      //int totalCantidad = 0;
      //double totalMedida = 0;
      //double totalPerfil = 0;
      //double totalTotal = 0;

      double resultQty = 0;
      double resultMd = 0;
      double temQty = 0;
      double temMd = 0;
      double tempTt = 0;
      double resultTotal = 0;
      double resultPesoKg = 0;
      string resultConditionalQty = "";
      string resultConditionalMd = "";
      string resultCondicionalTt = "";
      string error = string.Empty;



      try
      {
        data_model_element = new Elemento { Elemento_ = "largo", Value = form.Largo.ToString() };
        data_list_elements.Add(data_model_element);
        data_model_element = new Elemento { Elemento_ = "ancho", Value = form.Ancho.ToString() };
        data_list_elements.Add(data_model_element);
        data_model_element = new Elemento { Elemento_ = "cantidad", Value = form.Cantidad.ToString() };
        data_list_elements.Add(data_model_element);
        data_model_element = new Elemento { Elemento_ = "horizontal", Value = form.Horizontal.ToString() };
        data_list_elements.Add(data_model_element);
        data_model_element = new Elemento { Elemento_ = "vertical", Value = form.Vertical.ToString() };
        data_list_elements.Add(data_model_element);
        data_model_element = new Elemento { Elemento_ = "ranuras", Value = form.Ranuras.ToString() };
        data_list_elements.Add(data_model_element);
        data_model_element = new Elemento { Elemento_ = "diametro", Value = form.Diametro.ToString() };
        data_list_elements.Add(data_model_element);
        data_model_element = new Elemento { Elemento_ = "pies", Value = form.Pies.ToString() };
        data_list_elements.Add(data_model_element);

        //string expresion = "ENTERO((8-0.625)/0.989)";
        //string expresion = "REDONDEAR.MAS((REDONDEAR((ID(1410)-0.5625)/6,0)/2),0)6-0.125-0.3125";
        //string expresion = "REDONDEAR.MAS((REDONDEAR((((((35*12)-((ENTERO((35*12)/REDONDEAR.MAS((35*12)/144,0))+0)*((REDONDEAR.MAS((35*12)/144,0))-2)))/2)-0.125)-0.5625)/6,0)/2),0)*6-0.125-0.3125";
        //string expresion = "ID(F3146)";
        //string expresion = "ID(M1757)";
        //condicionalesController.LessThan(expresion);


        //expresion = condicionalesController.MasterEvaluator(expresion, data_list_elements, results, "qty");
        //expresion = eval.ExecuteSimpleFormula(expresion);
        //condicionalesController.GetResultCondicional(expresion);

        Result result = new Result();
        result.Itemno = itemno;
        result.Description = nameComponent;
        result.IsUsed = false;

        #region CALCULOS DE CANTIDADES

        if (IdCondicionalQty > 0)
        {
          if (typeConditionalQty == "M")
          {
            resultConditionalQty = condicionalesController.ExecuteMasterConditional(IdCondicionalQty.ToString(), idCompuestoQty, nombreMasterQty, data_list_elements);

            if (Double.TryParse(resultConditionalQty, out temQty))
            {
              resultQty = Convert.ToDouble(resultConditionalQty);
            }
            else
            {
              if (resultConditionalQty.Contains("ENTERO") || resultConditionalQty.Contains("REDONDEAR.MAS") || resultConditionalQty.Contains("CONDICIONALM") ||
                  resultConditionalQty.Contains("CONDICIONALC") || resultConditionalQty.Contains("REDONDEAR") || resultConditionalQty.Contains("ID") ||
                  resultConditionalQty.Contains("RESULT") || resultConditionalQty.Contains("REDOND.MULT"))
              {
                resultConditionalQty = condicionalesController.MasterEvaluator(resultConditionalQty, data_list_elements, results, "qty");
              }

              resultQty = evaluadorController.ExecuteFormula(resultConditionalQty, data_list_elements, out error);
            }
          }
          else
          {
            condicional = sql.GetCondicional(IdCondicionalQty.ToString());
            resultConditionalQty = condicionalesController.ExecuteCondicional(condicional, data_list_elements);

            if (Double.TryParse(resultConditionalQty, out temQty))
            {
              resultQty = Convert.ToDouble(resultConditionalQty);
            }
            else
            {
              if (resultConditionalQty.Contains("ENTERO") || resultConditionalQty.Contains("REDONDEAR.MAS") || resultConditionalQty.Contains("CONDICIONALM") ||
                  resultConditionalQty.Contains("CONDICIONALC") || resultConditionalQty.Contains("REDONDEAR") || resultConditionalQty.Contains("ID") ||
                  resultConditionalQty.Contains("RESULT") || resultConditionalQty.Contains("REDOND.MULT"))
              {
                resultConditionalQty = condicionalesController.MasterEvaluator(resultConditionalQty, data_list_elements, results, "qty");
              }

              resultQty = evaluadorController.ExecuteFormula(resultConditionalQty, data_list_elements, out error);
            }
          }
        }
        else
        {
          if (formulaQty.Contains("totallargo"))
          {
            //data_model_element = new Elemento { Elemento_ = "totallargo", Value = large.ToString() };
            data_model_element = new Elemento { Elemento_ = "totallargo", Value = form.Largo.ToString() };
            data_list_elements.Insert(0, data_model_element);
            resultQty = evaluadorController.ExecuteFormula(formulaQty, data_list_elements, out error);
          }

          if (formulaQty.Contains("totalancho"))
          {
            //data_model_element = new Elemento { Elemento_ = "totalancho", Value = large.ToString() };
            data_model_element = new Elemento { Elemento_ = "totallargo", Value = form.Largo.ToString() };
            data_list_elements.Add(data_model_element);
            resultQty = evaluadorController.ExecuteFormula(formulaQty, data_list_elements, out error);
          }
          else
          {
            if (formulaQty.Contains("ENTERO") || formulaQty.Contains("REDONDEAR.MAS") || formulaQty.Contains("CONDICIONALM") ||
                formulaQty.Contains("CONDICIONALC") || formulaQty.Contains("REDONDEAR") || formulaQty.Contains("ID") ||
                formulaQty.Contains("RESULT") || formulaQty.Contains("REDOND.MULT"))
            {
              formulaQty = condicionalesController.MasterEvaluator(formulaQty, data_list_elements, results, "qty");
            }

            resultQty = evaluadorController.ExecuteFormula(formulaQty, data_list_elements, out error);
          }
        }

        result.resultQty = System.Convert.ToDouble(Math.Round(resultQty)).ToString();
        totalCantidad += Convert.ToInt32(result.resultQty);

        #endregion

        #region CALCULOS DE MEDIDAS

        if (Convert.ToInt32(result.resultQty) >= 1)
        {
          if (IdCondicionalMd > 0)
          {
            data_model_element = new Elemento { Elemento_ = "totalcantidad", Value = resultQty.ToString() };
            data_list_elements.Insert(0, data_model_element);



            if (typeConditionalMd == "M")
            {
              resultConditionalMd = condicionalesController.ExecuteMasterConditional(IdCondicionalMd.ToString(), idCompuestoMd, nombreMasterMd, data_list_elements);

              if (Double.TryParse(resultConditionalMd, out temMd))
              {
                resultMd = Convert.ToDouble(resultConditionalMd);
              }
              else
              {
                if (resultConditionalMd.Contains("ENTERO") || resultConditionalMd.Contains("REDONDEAR.MAS") || resultConditionalMd.Contains("CONDICIONALM") ||
                    resultConditionalMd.Contains("CONDICIONALC") || resultConditionalMd.Contains("ID") || resultConditionalMd.Contains("RESULT") ||
                    resultConditionalMd.Contains("REDOND.MULT"))
                {
                  resultConditionalMd = condicionalesController.MasterEvaluator(resultConditionalMd, data_list_elements, results, "md");
                }

                resultMd = evaluadorController.ExecuteFormula(resultConditionalMd, data_list_elements, out error);
              }
            }
            else
            {
              condicional = sql.GetCondicional(IdCondicionalMd.ToString());
              resultConditionalMd = condicionalesController.ExecuteCondicional(condicional, data_list_elements);

              if (Double.TryParse(resultConditionalMd, out temMd))
              {
                resultMd = Convert.ToDouble(resultConditionalMd);
              }
              else
              {
                if (resultConditionalMd.Contains("ENTERO") || resultConditionalMd.Contains("REDONDEAR.MAS") || resultConditionalMd.Contains("CONDICIONALM") ||
                    resultConditionalMd.Contains("CONDICIONALC") || resultConditionalMd.Contains("ID") || resultConditionalMd.Contains("RESULT") ||
                    resultConditionalMd.Contains("REDOND.MULT"))
                {
                  resultConditionalMd = condicionalesController.MasterEvaluator(resultConditionalMd, data_list_elements, results, "md");
                }

                resultMd = evaluadorController.ExecuteFormula(resultConditionalMd, data_list_elements, out error);
              }
            }
          }
          else
          {
            data_model_element = new Elemento { Elemento_ = "totalcantidad", Value = resultQty.ToString() };
            data_list_elements.Insert(0, data_model_element);

            if (formulaMd.Contains("totallargo"))
            {
              data_model_element = new Elemento { Elemento_ = "totallargo", Value = form.Largo.ToString() };
              data_list_elements.Insert(0, data_model_element);
              resultMd = evaluadorController.ExecuteFormula(formulaMd, data_list_elements, out error);
            }

            if (formulaMd.Contains("totalancho"))
            {
              data_model_element = new Elemento { Elemento_ = "totalancho", Value = form.Largo.ToString() };
              data_list_elements.Insert(0, data_model_element);
              resultMd = evaluadorController.ExecuteFormula(formulaMd, data_list_elements, out error);
            }

            if (formulaMd.Contains("totalcantidad"))
            {
              data_model_element = new Elemento { Elemento_ = "totalcantidad", Value = form.Largo.ToString() };
              data_list_elements.Insert(0, data_model_element);
              resultMd = evaluadorController.ExecuteFormula(formulaMd, data_list_elements, out error);
            }
            else
            {
              if (formulaMd.Contains("ENTERO") || formulaMd.Contains("REDONDEAR.MAS") || formulaMd.Contains("CONDICIONALM") ||
                  formulaMd.Contains("CONDICIONALC") || formulaMd.Contains("REDONDEAR") || formulaMd.Contains("ID") ||
                  formulaMd.Contains("RESULT") || formulaMd.Contains("REDOND.MULT"))
              {
                formulaMd = condicionalesController.MasterEvaluator(formulaMd, data_list_elements, results, "md");
              }

              resultMd = evaluadorController.ExecuteFormula(formulaMd, data_list_elements, out error);
            }
          }
        }
        else
        {
          resultMd = 0;
        }


        result.resultMd = resultMd.ToString();
        totalMedida += Convert.ToDouble(result.resultMd);

        #endregion

        #region CALCULOS DE TOTALES

        if (resultQty >= 0)
        {
          //data_model_variables_totales = new Elemento { Elemento_ = "totalcantidad", Value = Math.Truncate(resultQty).ToString() };
          data_model_element = new Elemento { Elemento_ = "cantidad", Value = form.Cantidad.ToString() };
          data_list_variables_totales.Insert(0, data_model_element);
          data_model_variables_totales = new Elemento { Elemento_ = "totalcantidad", Value = Math.Round(resultQty).ToString() };
          data_list_variables_totales.Insert(0, data_model_variables_totales);
          data_model_variables_totales = new Elemento { Elemento_ = "totalmedida", Value = resultMd.ToString() };
          data_list_variables_totales.Insert(0, data_model_variables_totales);



          if (formulaTotal.Contains("ENTERO") || formulaTotal.Contains("REDONDEAR.MAS") || formulaTotal.Contains("CONDICIONALM") ||
              formulaTotal.Contains("CONDICIONALC") || formulaTotal.Contains("REDONDEAR") || formulaTotal.Contains("ID") ||
              formulaTotal.Contains("RESULT") || formulaTotal.Contains("REDOND.MULT"))
          {
            formulaTotal = condicionalesController.MasterEvaluator(formulaTotal, data_list_elements, results);
          }

          if (formulaTotal.Contains("largo") || formulaTotal.Contains("ancho"))
          {
            data_model_element = new Elemento { Elemento_ = "largo", Value = form.Largo.ToString() };
            data_list_elements_special.Add(data_model_element);
            data_model_element = new Elemento { Elemento_ = "ancho", Value = form.Ancho.ToString() };
            data_list_elements_special.Add(data_model_element);
            data_model_element = new Elemento { Elemento_ = "cantidad", Value = form.Cantidad.ToString() };
            data_list_elements_special.Add(data_model_element);
            data_model_element = new Elemento { Elemento_ = "horizontal", Value = form.Horizontal.ToString() };
            data_list_elements_special.Add(data_model_element);
            data_model_element = new Elemento { Elemento_ = "vertical", Value = form.Vertical.ToString() };
            data_list_elements_special.Add(data_model_element);
            data_model_element = new Elemento { Elemento_ = "ranuras", Value = form.Ranuras.ToString() };
            data_list_elements_special.Add(data_model_element);
            data_model_element = new Elemento { Elemento_ = "diametro", Value = form.Diametro.ToString() };
            data_list_elements_special.Add(data_model_element);
            data_model_element = new Elemento { Elemento_ = "pies", Value = form.Pies.ToString() };
            data_list_elements_special.Add(data_model_element);
            data_element_special = new Elemento { Elemento_ = "totalcantidad", Value = Math.Truncate(resultQty).ToString() };
            data_list_elements_special.Insert(0, data_element_special);
            data_element_special = new Elemento { Elemento_ = "totalmedida", Value = resultMd.ToString() };
            data_list_elements_special.Insert(0, data_element_special);

            resultTotal = evaluadorController.ExecuteFormula(formulaTotal, data_list_elements_special, out error);
          }
          else
          {
            resultTotal = evaluadorController.ExecuteFormula(formulaTotal, data_list_variables_totales, out error);
          }
          //}

          result.resultTotal = resultTotal.ToString();
          totalPerfil += Convert.ToDouble(result.resultTotal);
        }
        else
        {
          result.resultTotal = "0";
        }


        #endregion

        #region PESO

        if (resultQty >= 0)
        {
          data_element_special = new Elemento { Elemento_ = "totalcantidad", Value = Math.Truncate(resultQty).ToString() };
          data_list_elements.Insert(0, data_element_special);
          data_element_special = new Elemento { Elemento_ = "totalmedida", Value = resultMd.ToString() };
          data_list_elements.Insert(0, data_element_special);


          if (!string.IsNullOrEmpty(idFormulaPeso) && !string.Equals(idFormulaPeso, "0"))
          {
            formulaPeso = sql.GetFormula(idFormulaPeso);

            if (formulaPeso.Formula.Contains("ENTERO") || formulaPeso.Formula.Contains("REDONDEAR.MAS") || formulaPeso.Formula.Contains("CONDICIONALM") ||
            formulaPeso.Formula.Contains("CONDICIONALC") || formulaPeso.Formula.Contains("REDONDEAR") || formulaPeso.Formula.Contains("ID") ||
            formulaPeso.Formula.Contains("RESULT") || formulaPeso.Formula.Contains("REDOND.MULT"))
            {
              formulaPeso.Formula = condicionalesController.MasterEvaluator(formulaPeso.Formula, data_list_elements, results);
            }

            resultPesoKg = evaluadorController.ExecuteFormula(formulaPeso.Formula, data_list_elements, out error);
          }
        }

        #endregion

        results.Add(result);

        #region ENSAMBLADO DE MODELO

        data_model.Numero_Parte = itemno;
        data_model.nombre = nameComponent;
        data_model.Class = pClass;
        //data_model.cantidad = System.Convert.ToDouble(Math.Truncate(resultQty));
        data_model.cantidad = System.Convert.ToDouble(Math.Round(resultQty));
        data_model.medida = System.Convert.ToDouble(resultMd);
        data_model.total_perfil = System.Convert.ToDouble(resultTotal);
        data_model.Peso_Kg = System.Convert.ToDouble(resultPesoKg);

        #endregion
      }
      catch (Exception ex)
      {
        error = ex.Message;
        data_model = null;
      }

      errorMethod = error;
      return data_model;
    }


  }
}
