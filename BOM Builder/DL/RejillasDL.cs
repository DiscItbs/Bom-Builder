using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.DL
{
    public class RejillasDL : DataAccessSQL
    {
        private readonly string _BaseDatos = null;

        public List<NM_AleacionModel> GetListAleacion()
        {
            SqlDataReader dataReader = null;
            List<NM_AleacionModel> dataList = new List<NM_AleacionModel>();
            NM_AleacionModel dataModel = new NM_AleacionModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_Aleacion";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        dataModel = new NM_AleacionModel
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            Codigo_Aleacion = Convert.ToString(dataReader["Codigo_Aleacion"])
                        };
                        dataList.Add(dataModel);
                    }

                    dataReader.Close();
                }
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
            SqlDataReader dataReader = null;
            List<NM_CodigoModel> dataList = new List<NM_CodigoModel>();
            NM_CodigoModel dataModel = new NM_CodigoModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_CODIGO WHERE Valor_Codigo <> 'DP'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        dataModel = new NM_CodigoModel
                        {
                            Id = Convert.ToInt16(dataReader["Id"]),
                            Valor_Codigo = Convert.ToString(dataReader["Valor_Codigo"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"])
                        };

                        dataList.Add(dataModel);
                    }

                    dataReader.Close();
                }
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
            SqlDataReader dataReader = null;
            List<NM_AccesorioModel> dataList = new List<NM_AccesorioModel>();
            NM_AccesorioModel dataModel = new NM_AccesorioModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_Accesorio WHERE Valor_Accesorio = '' OR Valor_Accesorio = 'CO' OR Valor_Accesorio = '5CO' OR Valor_Accesorio = '8CO'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        dataModel = new NM_AccesorioModel
                        {
                            Id = Convert.ToInt16(dataReader["Id"]),
                            Valor_Accesorio = Convert.ToString(dataReader["Valor_Accesorio"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"])
                        };

                        dataList.Add(dataModel);
                    }

                    dataReader.Close();
                }
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
            SqlDataReader dataReader = null;
            List<NM_SubModelosModel> dataList = new List<NM_SubModelosModel>();
            NM_SubModelosModel dataModel = new NM_SubModelosModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_SubModelo WHERE CodigoId ='" + codeFather + "'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        dataModel = new NM_SubModelosModel
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            CodigoId = Convert.ToInt32(dataReader["CodigoId"]),
                            SubCodigo = Convert.ToString(dataReader["SubCodigo"])
                        };

                        dataList.Add(dataModel);
                    }

                    dataReader.Close();
                }
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
