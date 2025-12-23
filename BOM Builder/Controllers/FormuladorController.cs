using BOM_Builder.DL;
using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Controllers
{
   public class FormuladorController
   {
      FormuladorDL formuladorDL = new FormuladorDL();

      public bool CreateFormulaQty(string nameFormula, string formula, out string errorMethod)
      {
         string error = string.Empty;
         bool affected = false;

         try
         {
            affected = formuladorDL.CreateFormulaQty(nameFormula, formula, out error);
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         errorMethod = error;
         return affected;
      }

      public bool CreateFormulaMd(string nameFormula, string formula, out string errorMethod)
      {
         string error = string.Empty;
         bool affected = false;

         try
         {
            affected = formuladorDL.CreateFormulaMd(nameFormula, formula, out error);
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         errorMethod = error;
         return affected;
      }

      public bool CreateFormulaTotal(string nameFormula, string formula, out string errorMethod)
      {
         string error = string.Empty;
         bool affected = false;

         try
         {
            affected = formuladorDL.CreateFormulaTotal(nameFormula, formula, out error);
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         errorMethod = error;
         return affected;
      }

      public List<NM_Formula> GetListFormulas(out string errorMethod)
      {
            List<NM_Formula> data_list = new List<NM_Formula>();
            string error = string.Empty;

            try
            {
               data_list = formuladorDL.GetListFormulas(out error);
            }
            catch (Exception ex)
            {
               error = ex.Message;
               data_list = null;
            }

            errorMethod = error;
            return data_list;
      }
   }
}
