using BOM_Builder.DL;
using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Controllers
{
   public class ModeladoBomController
   {
      ModeladoDL modeladoDL = new ModeladoDL();

      public List<ModeladoBomModel> GetBomModels(string modelComplete, string finish, out string errorMethod)
      {
         List<ModeladoBomModel> data_list = new List<ModeladoBomModel>();
         string error = string.Empty;

         try
         {
            data_list = modeladoDL.GetBomModels(modelComplete, finish, out error);
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         errorMethod = error;
         return data_list;
      }
   }
}
