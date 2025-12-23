using BOM_Builder.Controllers;
using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JScript.Vsa;
using Microsoft.JScript;

namespace BOM_Builder.BL
{
   public class ConstructionComponentRejillas
   {
      #region VARIABLES GLOBALES

      ModeladoBomController modelado_bom_controller = new ModeladoBomController();
      EvaluacionFormulasController evaluador_controller = new EvaluacionFormulasController();

      #endregion

      public List<ComponenteModel> GetComponents(string modelCompleteBom, int large, int width, int qty, string finishes, out string errorMethod)
      {
         List<ComponenteModel> list_components = new List<ComponenteModel>();
         string error = string.Empty;

         try
         {
            List<ModeladoBomModel> data_list = new List<ModeladoBomModel>();
            data_list = modelado_bom_controller.GetBomModels(modelCompleteBom, finishes, out error);

            if (data_list.Count != 0)
            {
               foreach (var item in data_list)
               {
                  list_components.Add(GetDataComponents(item.Itemno, item.Class, item.Nombre_Componente, item.FormulaQty, item.FormulaMd, item.FormulaTotal, large, width, qty, out error));
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

      public ComponenteModel GetDataComponents(string itemno, string pClass, string nameComponent, string formulaQty, string formulaMd, string formulaTotal, int large, int width, int qty, out string errorMethod)
      {
         List<string> data_list_values_qty_md = new List<string>();
         List<string> data_list_values_total = new List<string>();
         ComponenteModel data_model = new ComponenteModel();
         double resultQty = 0;
         double resultMd = 0;
         double resultTotal = 0;
         string error = string.Empty;

         try
         {
            data_list_values_qty_md = new List<string> { large.ToString(), width.ToString(), qty.ToString() };

            //resultQty = evaluador_controller.ExecuteFormula(formulaQty, data_list_values_qty_md, out error);
            //resultMd = evaluador_controller.ExecuteFormula(formulaMd, data_list_values_qty_md, out error);

            data_list_values_total = new List<string> { resultQty.ToString(), resultMd.ToString() };
            //resultTotal = evaluador_controller.ExecuteFormula(formulaTotal, data_list_values_total, out error);

            data_model.Numero_Parte = itemno;
            data_model.nombre = nameComponent;
            data_model.Class = pClass;
            data_model.cantidad = System.Convert.ToDouble(resultQty);
            data_model.medida = System.Convert.ToDouble(resultMd);
            data_model.total_perfil = System.Convert.ToDouble(resultTotal);
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
