using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.DL
{
    public class GeneratorDL : DataAccessSQL
    {
        private readonly string _BaseDatos = null;

        public List<NM_ModelosLModel> GetListModelL0(out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            NM_ModelosLModel data_model = new NM_ModelosLModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_ModeloL0";
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    data_model = new NM_ModelosLModel
                    {
                        Id_L1 = 0,
                        Name_Model = "Seleccione una opción..."
                    };

                    data_list.Add(data_model);

                    while (data_reader.Read())
                    {
                        data_model = new NM_ModelosLModel
                        {
                            Id_L1 = Convert.ToInt32(data_reader["Id"]),
                            Name_Model = Convert.ToString(data_reader["Nombre_Modelo"])
                        };
                        data_list.Add(data_model);
                    }

                    data_reader.Close();
                }
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
            NM_CombinacionesModel data_model = new NM_CombinacionesModel();
            SqlDataReader data_reader = null;
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = @"
                SELECT DISTINCT
                    T1.Id, T1.Combinacion_Bom AS Combinacion, T1.Acabado As Acabado
                FROM
                    NM_Detalle_Combinacion_Componentes_Formulas AS T0(NOLOCK)
                    INNER JOIN NM_Combinaciones AS T1(NOLOCK) ON T1.Id = T0.IdCombinacion 
                WHERE 
                    T1.Acabado = '" + finishes + "' AND T1.Id_Modelo_Base = " + id + @"
                ORDER BY 
                    T1.Combinacion_Bom ASC";

                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    data_model = new NM_CombinacionesModel
                    {
                        Id = 0,
                        Combinacion = "Seleccione una opción..."
                    };
                    data_list.Add(data_model);

                    while (data_reader.Read())
                    {
                        data_model = new NM_CombinacionesModel
                        {
                            Id = Convert.ToInt32(data_reader["Id"]),
                            Combinacion = Convert.ToString(data_reader["Combinacion"])
                        };
                        data_list.Add(data_model);
                    }

                    data_reader.Close();
                }
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
            NM_CombinacionesModel data_model = new NM_CombinacionesModel();
            SqlDataReader data_reader = null;
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_Combinaciones WHERE Id_Modelo_Base = '" + id + "'";
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    data_model = new NM_CombinacionesModel
                    {
                        Id = 0,
                        Combinacion = "Seleccione una opción..."
                    };
                    data_list.Add(data_model);

                    while (data_reader.Read())
                    {
                        data_model = new NM_CombinacionesModel
                        {
                            Id = Convert.ToInt32(data_reader["Id"]),
                            Combinacion = Convert.ToString(data_reader["Combinacion_Bom"])
                        };
                        data_list.Add(data_model);
                    }

                    data_reader.Close();
                }
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
            NM_SubModelosModel data_model = new NM_SubModelosModel();
            SqlDataReader data_reader = null;
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_SubModelo WHERE CodigoId = '" + idCodigoModel + "'";
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new NM_SubModelosModel
                        {
                            Id = Convert.ToInt32(data_reader["Id"]),
                            CodigoId = Convert.ToInt32(data_reader["CodigoId"]),
                            SubCodigo = Convert.ToString(data_reader["SubCodigo"])
                        };
                        data_list.Add(data_model);
                    }

                    data_reader.Close();
                }
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
            SqlDataReader data_reader = null;
            string error = string.Empty;
            string mfg_cell = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = string.Format("SELECT Mfg_Cell FROM NM_ModeloL1 WHERE Nombre_Modelo = '{0}'",model);
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        if (data_reader["Mfg_Cell"] != DBNull.Value)
                        {
                            mfg_cell = Convert.ToString(data_reader["Mfg_Cell"]);
                        }
                        else
                        {
                            mfg_cell = "";
                        }
                    }

                    data_reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return mfg_cell;
        }

        public string GetLargeDescription(string baseName, out string errorMethod)
        {
            SqlDataReader data_reader = null;
            string error = string.Empty;
            string description = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT Descripcion_Larga FROM NM_ModeloL0 WHERE Nombre_Modelo = '" + baseName + "'";
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        description = Convert.ToString(data_reader["Descripcion_Larga"]);
                    }

                    data_reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return description;
        }

        public string GetEnglishDescription(string baseName, out string errorMethod)
        {
            SqlDataReader data_reader = null;
            string error = string.Empty;
            string description = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT Descripcion_Ingles FROM NM_ModeloL0 WHERE Nombre_Modelo = '" + baseName + "'";
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        description = Convert.ToString(data_reader["Descripcion_Ingles"]);
                    }

                    data_reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return description;
        }
    }
}
