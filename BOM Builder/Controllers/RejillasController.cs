using BOM_Builder.DL;
using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Controllers
{
    public class RejillasController
    {
        RejillasDL rejillasDL = new RejillasDL();

        public List<NM_AleacionModel> GetListAleaciones()
        {
            List<NM_AleacionModel> dataList = new List<NM_AleacionModel>();
            string error = string.Empty;

            try
            {
                dataList = rejillasDL.GetListAleacion();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                dataList = null;
            }

            return dataList;
        }

        public List<NM_CodigoModel> GetListCodigos()
        {
            List<NM_CodigoModel> dataList = new List<NM_CodigoModel>();
            string error = string.Empty;

            try
            {
                dataList = rejillasDL.GetListCodigos();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                dataList = null;
            }

            return dataList;
        }

        public List<NM_AccesorioModel> GetListAccesorios()
        {
            List<NM_AccesorioModel> dataList = new List<NM_AccesorioModel>();
            string error = string.Empty;

            try
            {
                dataList = rejillasDL.GetListAccesorios();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                dataList = null;
            }

            return dataList;
        }

        public List<NM_SubModelosModel> GetListSubModelos(string codeFather)
        {
            List<NM_SubModelosModel> dataList = new List<NM_SubModelosModel>();
            string error = string.Empty;

            try
            {
                dataList = rejillasDL.GetListSubModelos(codeFather);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                dataList = null;
            }

            return dataList;
        }
    }
}
