using BOM_Builder.DL;
using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Controllers
{
    public class GeneratorController
    {
        GeneratorDL generatorDL = new GeneratorDL();
        BomDL bomDL = new BomDL();

        public List<NM_ModelosLModel> GetListModel(out string errorMethod)
        {
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            string error = string.Empty;

            try
            {
                data_list = generatorDL.GetListModelL0(out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }
            errorMethod = error;
            return data_list;
        }

        public List<ArinvtModel> GetListClasses(out string errorMethod)
        {
            List<ArinvtModel> data_list = new List<ArinvtModel>();
            string error = string.Empty;

            try
            {
                data_list = bomDL.GetListClass(out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            errorMethod = error;
            return data_list;
        }

        public List<NM_CombinacionesModel> GetListModelAssembly(int id, string finishes, out string errorMetohd)
        {
            List<NM_CombinacionesModel> data_list = new List<NM_CombinacionesModel>();
            string error = string.Empty;

            try
            {
                data_list = generatorDL.GetListModelAssembly(id, finishes, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            errorMetohd = error;
            return data_list;
        }

        public List<NM_CombinacionesModel> GetListModelAssembly(int id, out string errorMetohd)
        {
            List<NM_CombinacionesModel> data_list = new List<NM_CombinacionesModel>();
            string error = string.Empty;

            try
            {
                data_list = generatorDL.GetListModelAssembly(id, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            errorMetohd = error;
            return data_list;
        }

        public List<NM_SubModelosModel> GetListSubModel(string idCodigoModel, out string errorMetohd)
        {
            List<NM_SubModelosModel> data_list = new List<NM_SubModelosModel>();
            string error = string.Empty;

            try
            {
                data_list = generatorDL.GetListSubModel(idCodigoModel, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            errorMetohd = error;
            return data_list;
        }

        public string GetMfgCell(string model, out string errorMethod)
        {
            string mfg_cell = string.Empty;
            string error = string.Empty;

            try
            {
                mfg_cell = generatorDL.GetMfgCell(model, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return mfg_cell;
        }
    }
}
