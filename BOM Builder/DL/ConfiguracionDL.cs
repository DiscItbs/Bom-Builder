using BOM_Builder.Controllers;
using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BOM_Builder.DL
{
    public class ConfiguracionDL : DataAccessSQL
    {
        private readonly string _BaseDatos = null;
        DataAccessOracle accessOracle = new DataAccessOracle();
        private string connectionSQL = ConfigurationSettings.AppSettings.Get("connectionSQL");
        SQLServer sql = new SQLServer();

        #region GET

        /// <summary>
        /// Metodo para recupear los items de iqms
        /// </summary>
        /// <param name="dataListClass">Lista de clases activas en iqms</param>
        /// <param name="itemno">Nombre de itemno</param>
        /// <param name="description">Descripcion itemno</param>
        /// <param name="errorMethod">Mensaje de error</param>
        /// <returns></returns>
        public List<ArinvtModel> GetListComponents(List<string> dataListClass, string itemno, string description, out string errorMethod)
        {
            OracleDataReader data_reader = null;
            List<ArinvtModel> data_list = new List<ArinvtModel>();
            ArinvtModel data_model = new ArinvtModel();
            string error = string.Empty;

            try
            {
                accessOracle.switchConexion(_BaseDatos);

                if (dataListClass.Count != 0)
                {
                    for (int i = 0; i < dataListClass.Count; i++)
                    {
                        if (itemno == "" && description == "")
                        {
                            accessOracle.strCadenaSQL = "SELECT * FROM ARINVT WHERE CLASS = '" + dataListClass[i] + "'" + Environment.NewLine;
                        }
                        else if (itemno != "" && description == "")
                        {
                            accessOracle.strCadenaSQL = "SELECT * FROM ARINVT WHERE CLASS = '" + dataListClass[i] + "' AND ITEMNO LIKE '%" + itemno + "%'" + Environment.NewLine;
                        }
                        else if (itemno == "" && description != "")
                        {
                            accessOracle.strCadenaSQL = "SELECT * FROM ARINVT WHERE CLASS = '" + dataListClass[i] + "' AND DESCRIP LIKE '%" + description + "%'" + Environment.NewLine;
                        }
                        else if (itemno != "" && description != "")
                        {
                            accessOracle.strCadenaSQL = "SELECT * FROM ARINVT WHERE CLASS = '" + dataListClass[i] + "' AND ITEMNO LIKE '%" + itemno + "%' AND DESCRIP LIKE '%" + description + "%'" + Environment.NewLine;
                        }

                        data_reader = accessOracle.funConsultaSQL();

                        if (data_reader != null)
                        {
                            while (data_reader.Read())
                            {
                                data_model = new ArinvtModel();
                                data_model.Id = Convert.ToInt32(data_reader["Id"]);
                                data_model.Itemno = Convert.ToString(data_reader["ITEMNO"]);
                                data_model.Descrip1 = Convert.ToString(data_reader["DESCRIP"]);

                                if (data_model.Itemno.Contains("XAL"))
                                {
                                    data_model.Acabado = "AL";
                                    data_model.Class = "SE";
                                }
                                else if (data_model.Itemno.Contains("XAN"))
                                {
                                    data_model.Acabado = "AN";
                                    data_model.Class = "SE";
                                }
                                else if (data_model.Itemno.Contains("XAC"))
                                {
                                    data_model.Acabado = "AC";
                                    data_model.Class = "ST";
                                }
                                else
                                {
                                    data_model.Acabado = "";
                                    data_model.Class = Convert.ToString(data_reader["Class"]);
                                }

                                data_list.Add(data_model);
                            }

                            data_reader.Close();
                        }
                    }
                }
                else
                {
                    if (itemno == "" && description == "")
                    {
                        accessOracle.strCadenaSQL = "SELECT * FROM ARINVT " + Environment.NewLine;
                    }
                    else if (itemno != "" && description == "")
                    {
                        accessOracle.strCadenaSQL = "SELECT * FROM ARINVT WHERE ITEMNO LIKE '%" + itemno + "%'" + Environment.NewLine;
                    }
                    else if (itemno == "" && description != "")
                    {
                        accessOracle.strCadenaSQL = "SELECT * FROM ARINVT WHERE DESCRIP LIKE '%" + description + "%'" + Environment.NewLine;
                    }
                    else if (itemno != "" && description != "")
                    {
                        accessOracle.strCadenaSQL = "SELECT * FROM ARINVT WHERE ITEMNO LIKE '%" + itemno + "%' AND DESCRIP LIKE '%" + description + "%'" + Environment.NewLine;
                    }

                    data_reader = accessOracle.funConsultaSQL();

                    if (data_reader != null)
                    {
                        while (data_reader.Read())
                        {
                            data_model = new ArinvtModel
                            {
                                Id = Convert.ToInt32(data_reader["Id"]),
                                Class = Convert.ToString(data_reader["Class"]),
                                Itemno = Convert.ToString(data_reader["ITEMNO"]),
                                Descrip1 = Convert.ToString(data_reader["DESCRIP"])
                            };

                            data_list.Add(data_model);
                        }

                        data_reader.Close();
                    }
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

        /// <summary>
        /// Metodo para obtener la lista de componentes activados como materia prima
        /// </summary>
        /// <param name="finishes"></param>
        /// <param name="errorMethod"></param>
        /// <returns></returns>
        public List<ArinvtModel> GetListComponents(string finishes, out string errorMethod)
        {
            OracleDataReader data_reader = null;
            List<ArinvtModel> data_list = new List<ArinvtModel>();
            ArinvtModel data_model = new ArinvtModel();
            string error = string.Empty;

            try
            {
                accessOracle.switchConexion(_BaseDatos);
                //MessageBox.Show("Pase primer punto switch conn");

                accessOracle.strCadenaSQL = "SELECT * FROM ARINVT T0 INNER JOIN ARINVT_CLASS T1 ON T1.CLASS = T0.CLASS WHERE T1.PRIMARY_MATERIAL = 'Y' " +
                                            "OR (T0.CLASS = 'SE' AND REV = 'SE') FETCH FIRST 100000 ROWS ONLY";

                data_reader = accessOracle.funConsultaSQL();
                //MessageBox.Show("Pase segundo punto ejecutar consulta");

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new ArinvtModel();
                        data_model.Id = Convert.ToInt32(data_reader["Id"]);
                        data_model.Itemno = Convert.ToString(data_reader["ITEMNO"]);
                        data_model.Descrip1 = Convert.ToString(data_reader["DESCRIP"]);
                        data_model.Class = Convert.ToString(data_reader["CLASS"]);
                        data_list.Add(data_model);
                    }

                    data_reader.Close();
                }
            }
            catch (ArgumentNullException ex)
            {
                error = ex.Message;
                data_list = null;
                MessageBox.Show(error);
            }

            errorMethod = error;
            return data_list;
        }

        public List<ArinvtModel> GetListComponents(out string errorMethod)
        {
            OracleDataReader data_reader = null;
            List<ArinvtModel> data_list = new List<ArinvtModel>();
            ArinvtModel data_model = new ArinvtModel();
            string error = string.Empty;

            try
            {
                #region ARTICULOS CON AL, AN Y AC

                accessOracle.switchConexion(_BaseDatos);

                accessOracle.strCadenaSQL = "SELECT * FROM ARINVT T0 INNER JOIN ARINVT_CLASS T1 ON T1.CLASS = T0.CLASS WHERE ITEMNO LIKE 'PEXAC%' OR ITEMNO LIKE 'PEXAN%' OR ITEMNO LIKE 'PEXAL%' AND T1.PRIMARY_MATERIAL = 'Y' ORDER BY T0.ITEMNO";

                data_reader = accessOracle.funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new ArinvtModel();
                        data_model.Id = Convert.ToInt32(data_reader["Id"]);
                        data_model.Itemno = Convert.ToString(data_reader["ITEMNO"]);
                        data_model.Descrip1 = Convert.ToString(data_reader["DESCRIP"]);

                        if (data_model.Itemno.Contains("XAL"))
                        {
                            data_model.Acabado = "AL";
                            data_model.Class = "SE";
                        }
                        else if (data_model.Itemno.Contains("XAN"))
                        {
                            data_model.Acabado = "AN";
                            data_model.Class = "SE";
                        }
                        else if (data_model.Itemno.Contains("XAC"))
                        {
                            data_model.Acabado = "AC";
                            data_model.Class = "ST";
                        }
                        else
                        {
                            data_model.Acabado = "";
                            data_model.Class = Convert.ToString(data_reader["Class"]);
                        }

                        data_list.Add(data_model);
                    }

                    data_reader.Close();
                }

                #endregion

                #region ARTICULOS SIN AL, AN Y AC

                accessOracle.switchConexion(_BaseDatos);

                accessOracle.strCadenaSQL = "SELECT * FROM ARINVT T0 INNER JOIN ARINVT_CLASS T1 ON T1.CLASS = T0.CLASS WHERE ITEMNO NOT LIKE 'PEXAC%' AND ITEMNO NOT LIKE 'PEXAN%' AND ITEMNO NOT LIKE 'PEXAL%' AND T1.PRIMARY_MATERIAL = 'Y' ORDER BY T0.ITEMNO";

                data_reader = accessOracle.funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new ArinvtModel();
                        data_model.Id = Convert.ToInt32(data_reader["Id"]);
                        data_model.Itemno = Convert.ToString(data_reader["ITEMNO"]);
                        data_model.Descrip1 = Convert.ToString(data_reader["DESCRIP"]);

                        if (data_model.Itemno.Contains("XAL"))
                        {
                            data_model.Acabado = "AL";
                            data_model.Class = "SE";
                        }
                        else if (data_model.Itemno.Contains("XAN"))
                        {
                            data_model.Acabado = "AN";
                            data_model.Class = "SE";
                        }
                        else if (data_model.Itemno.Contains("XAC"))
                        {
                            data_model.Acabado = "AC";
                            data_model.Class = "ST";
                        }
                        else
                        {
                            data_model.Acabado = "";
                            data_model.Class = Convert.ToString(data_reader["Class"]);
                        }

                        data_list.Add(data_model);
                    }

                    data_reader.Close();
                }

                #endregion
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            errorMethod = error;
            return data_list;
        }

        /// <summary>
        /// Metodo para obtener la lista de combinaciones ya registradas
        /// </summary>
        /// <returns></returns>
        public List<NM_CombinacionesModel> GetListCombinacions(string finish, int id)
        {
            List<NM_CombinacionesModel> data_list = new List<NM_CombinacionesModel>();
            NM_CombinacionesModel data_model = new NM_CombinacionesModel();
            SqlDataReader data_reader = null;
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_Combinaciones WHERE Acabado = '" + finish + "' AND ID_MODELO_BASE = " + id + " AND completado = '0' ORDER BY Combinacion_Bom ASC";
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

            return data_list;
        }

        /// <summary>
        /// Metodo para obtener la lista de componentes por combinacion
        /// </summary>
        /// <param name="combination"></param>
        /// <returns></returns>
        public List<NM_Detalle_Combinaciones_ComponentesModel> GetListCombinacionComponente(string combination, string finish)
        {
            List<NM_Detalle_Combinaciones_ComponentesModel> data_list = new List<NM_Detalle_Combinaciones_ComponentesModel>();
            NM_Detalle_Combinaciones_ComponentesModel data_model = new NM_Detalle_Combinaciones_ComponentesModel();
            SqlDataReader data_reader = null;
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = @"
                    SELECT 
	                    T0.Combinacion_Bom AS Combinacion, T0.Acabado AS Acabado, T1.Itemno AS Itemno, T1.Class_IQMS AS Class, T1.Nombre_Componente AS Nombre_Componente, T1.Id_Combinacion, T1.Id_Arinvt, T1.Id
                    FROM 
	                    NM_Combinaciones AS T0 
	                    INNER JOIN NM_Detalle_Combinaciones_Componentes AS T1 ON T1.Id_Combinacion = T0.Id
                    WHERE
	                   T0.Combinacion_Bom = '" + combination + "' AND T0.Acabado = '" + finish + "'";

                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new NM_Detalle_Combinaciones_ComponentesModel
                        {
                            Id = Convert.ToInt32(data_reader["Id"]),
                            Acabado = Convert.ToString(data_reader["Acabado"]),
                            Itemno = Convert.ToString(data_reader["Itemno"]),
                            Class = Convert.ToString(data_reader["Class"]),
                            Nombre_Componente = Convert.ToString(data_reader["Nombre_Componente"]),
                            IdCombinacion = Convert.ToInt32(data_reader["Id_Combinacion"]),
                            IdComponentes = Convert.ToInt32(data_reader["Id_Arinvt"])
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

            return data_list;
        }

        /// <summary>
        /// Metodo para obtener la lista de modelo nivel 0
        /// </summary>
        /// <param name="errorMethod"></param>
        /// <returns></returns>
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
                    while (data_reader.Read())
                    {
                        data_model = new NM_ModelosLModel
                        {
                            Id_L0 = Convert.ToInt32(data_reader["Id"]),
                            Name_Model = Convert.ToString(data_reader["Nombre_Modelo"]),
                            Description_Model = Convert.ToString(data_reader["Descripcion_Modelo"]),
                            Description_Large = Convert.ToString(data_reader["Descripcion_Larga"]),
                            Description_English = Convert.ToString(data_reader["Descripcion_Ingles"])
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

        public List<NM_ModelosLModel> GetListModelL0WithSubNivel(out string errorMethod)
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
                            Id_L0 = Convert.ToInt32(data_reader["Id"]),
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

        public List<NM_ModelosLModel> GetListModelL1(int id, out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            NM_ModelosLModel data_model = new NM_ModelosLModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_ModeloL1 WHERE Id_ModeloL0 = " + id;
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new NM_ModelosLModel
                        {
                            Id_L1 = Convert.ToInt32(data_reader["Id"]),
                            Name_Model = Convert.ToString(data_reader["Nombre_Modelo"]),
                            Description_Model = Convert.ToString(data_reader["Descripcion_Modelo"]),
                            Aplica_SubNivel = Convert.ToBoolean(data_reader["Aplica_SubNivel"]),
                            Mfg_Cell = Convert.ToString(data_reader["Mfg_Cell"]),
                            CentroTrabajo = Convert.ToString(data_reader["Cntr_Desc"])
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

        public List<NM_ModelosLModel> GetListModelL1WithSubNivel(out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            NM_ModelosLModel data_model = new NM_ModelosLModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_ModeloL1 WHERE Aplica_SubNivel = 1";
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

        public List<NM_ModelosLModel> GetListModelL1WithSubNivel(int id, out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            NM_ModelosLModel data_model = new NM_ModelosLModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_ModeloL1 WHERE Id_ModeloL0 = " + id;
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

        public List<NM_ModelosLModel> GetListModelL2(out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            NM_ModelosLModel data_model = new NM_ModelosLModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_ModeloL2";
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new NM_ModelosLModel
                        {
                            Id_L2 = Convert.ToInt32(data_reader["Id"]),
                            Id_L1 = Convert.ToInt32(data_reader["Id_ModeloL1"]),
                            Name_Model = Convert.ToString(data_reader["Nombre_Modelo"]),
                            Description_Model = Convert.ToString(data_reader["Descripcion_Modelo"]),
                            Aplica_SubNivel = Convert.ToBoolean(data_reader["Aplica_SubNivel"])
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

        public List<NM_ModelosLModel> GetListModelL2(int id, out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            NM_ModelosLModel data_model = new NM_ModelosLModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_ModeloL2 WHERE Id_ModeloL1 = " + id;
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new NM_ModelosLModel
                        {
                            Id_L2 = Convert.ToInt32(data_reader["Id"]),
                            Name_Model = Convert.ToString(data_reader["Nombre_Modelo"]),
                            Description_Model = Convert.ToString(data_reader["Descripcion_Modelo"])
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

        public List<NM_ModelosLModel> GetListModelL2WithSubNivel(out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            NM_ModelosLModel data_model = new NM_ModelosLModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_ModeloL2 WHERE Aplica_SubNivel = 1";
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
                            Id_L2 = Convert.ToInt32(data_reader["Id"]),
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

        public List<NM_ModelosLModel> GetListModelL2WithSubNivel(int id, out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            NM_ModelosLModel data_model = new NM_ModelosLModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_ModeloL2 WHERE Id_ModeloL1 = " + id;
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
                            Id_L2 = Convert.ToInt32(data_reader["Id"]),
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

        public List<NM_ModelosLModel> GetListModelL3WithSubNivel(int id, out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            NM_ModelosLModel data_model = new NM_ModelosLModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_ModeloL3 WHERE Id_ModeloL2 = " + id;
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
                            Id_L3 = Convert.ToInt32(data_reader["Id"]),
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

        public List<NM_ModelosLModel> GetListModelL3(out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            NM_ModelosLModel data_model = new NM_ModelosLModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_ModeloL3";
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new NM_ModelosLModel
                        {
                            Id_L3 = Convert.ToInt32(data_reader["Id"]),
                            Id_L2 = Convert.ToInt32(data_reader["Id_ModeloL2"]),
                            Name_Model = Convert.ToString(data_reader["Nombre_Modelo"]),
                            Description_Model = Convert.ToString(data_reader["Descripcion_Modelo"])
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

        public List<NM_ModelosLModel> GetListModelL3(int id, out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            NM_ModelosLModel data_model = new NM_ModelosLModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_ModeloL3 WHERE Id_ModeloL2 = " + id;
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new NM_ModelosLModel
                        {
                            Id_L3 = Convert.ToInt32(data_reader["Id"]),
                            Name_Model = Convert.ToString(data_reader["Nombre_Modelo"]),
                            Description_Model = Convert.ToString(data_reader["Descripcion_Modelo"])
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

        /// <summary>
        /// Metodo para verificar que el bom a crear no exista
        /// </summary>
        /// <param name="modeloCompuesto">Nombre bom</param>
        /// <param name="acabado">AC, AN, AL</param>
        /// <param name="errorMethod">Mensaje de error</param>
        /// <returns></returns>
        public bool VerifyExistence(string modeloCompuesto, string acabado, out string errorMethod)
        {
            SqlDataReader data_reader = null;
            string error = string.Empty;
            bool success = false;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "SELECT Id FROM NM_Combinaciones WHERE Combinacion_Bom = '" + modeloCompuesto + "' AND Acabado = '" + acabado + "'";

                data_reader = funConsultaSQL();

                if (!data_reader.HasRows)
                {
                    success = false;
                }
                else
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            if (error == "")
            {
                errorMethod = error;
                success = false;
            }
            else
            {
                errorMethod = error;
                success = true;
            }

            return success;
        }

        public List<NM_MaterialesModel> GetListMaterials()
        {
            SqlDataReader data_reader = null;
            List<NM_MaterialesModel> data_list = new List<NM_MaterialesModel>();
            NM_MaterialesModel data_model = new NM_MaterialesModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_Materiales";
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new NM_MaterialesModel { Id = Convert.ToInt32(data_reader["Id"]), Nombre_Material = Convert.ToString(data_reader["Nombre_Material"]), Descripcion_Material = Convert.ToString(data_reader["Descripcion_Material"]) };
                        data_list.Add(data_model);
                    }

                    data_reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return data_list;
        }

        public List<NM_MaterialesModel> GetListMaterialsCombo()
        {
            SqlDataReader data_reader = null;
            List<NM_MaterialesModel> data_list = new List<NM_MaterialesModel>();
            NM_MaterialesModel data_model = new NM_MaterialesModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_Materiales";
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    data_model = new NM_MaterialesModel { Id = 0, Nombre_Material = "Seleccione una opción..." };
                    data_list.Add(data_model);

                    while (data_reader.Read())
                    {
                        data_model = new NM_MaterialesModel { Id = Convert.ToInt32(data_reader["Id"]), Nombre_Material = Convert.ToString(data_reader["Nombre_Material"]), Descripcion_Material = Convert.ToString(data_reader["Descripcion_Material"]) };
                        data_list.Add(data_model);
                    }

                    data_reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return data_list;
        }

        public List<NM_SubMaterialesModel> GetLisSubtMaterials(int id)
        {
            SqlDataReader data_reader = null;
            List<NM_SubMaterialesModel> data_list = new List<NM_SubMaterialesModel>();
            NM_SubMaterialesModel data_model = new NM_SubMaterialesModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT T0.Id, t1.Id AS IdMaterial_Base, T1.Nombre_Material AS Material_Base, T0.Nombre_Material, T0.Descripcion_Material FROM NM_SubMateriales AS T0 INNER JOIN NM_Materiales AS T1 ON T1.Id = T0.Id_Material_Base WHERE Id_Material_Base = " + id;
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new NM_SubMaterialesModel { Id = Convert.ToInt32(data_reader["Id"]), Id_Material_Base = Convert.ToInt32(data_reader["IdMaterial_Base"]), Material_Base = Convert.ToString(data_reader["Material_Base"]), Nombre_Material = Convert.ToString(data_reader["Nombre_Material"]), Descripcion_Material = Convert.ToString(data_reader["Descripcion_Material"]) };
                        data_list.Add(data_model);
                    }

                    data_reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return data_list;
        }

        public List<NM_SubMaterialesModel> GetLisSubtMaterials()
        {
            SqlDataReader data_reader = null;
            List<NM_SubMaterialesModel> data_list = new List<NM_SubMaterialesModel>();
            NM_SubMaterialesModel data_model = new NM_SubMaterialesModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT T0.Id, t1.Id AS IdMaterial_Base, T1.Nombre_Material AS Material_Base, T0.Nombre_Material, T0.Descripcion_Material FROM NM_SubMateriales AS T0 INNER JOIN NM_Materiales AS T1 ON T1.Id = T0.Id_Material_Base";
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new NM_SubMaterialesModel { Id = Convert.ToInt32(data_reader["Id"]), Id_Material_Base = Convert.ToInt32(data_reader["IdMaterial_Base"]), Material_Base = Convert.ToString(data_reader["Material_Base"]), Nombre_Material = Convert.ToString(data_reader["Nombre_Material"]), Descripcion_Material = Convert.ToString(data_reader["Descripcion_Material"]) };
                        data_list.Add(data_model);
                    }

                    data_reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return data_list;

        }

        public List<WorkCenterModel> GetListMfgCell()
        {
            OracleDataReader data_reader = null;
            List<WorkCenterModel> data_list = new List<WorkCenterModel>();
            WorkCenterModel data_model = new WorkCenterModel();
            string error = string.Empty;

            try
            {
                accessOracle.switchConexion(_BaseDatos);
                accessOracle.strCadenaSQL = "SELECT * FROM WORK_CENTER WHERE MFGCELL IS NOT NULL";
                data_reader = accessOracle.funConsultaSQL();

                if (data_reader != null)
                {
                    data_model = new WorkCenterModel { Cntr_Desc = "Seleccione una opción...", Mfg_Cell = "0" };
                    data_list.Add(data_model);

                    while (data_reader.Read())
                    {
                        data_model = new WorkCenterModel { Cntr_Desc = Convert.ToString(data_reader["CNTR_DESC"]), Mfg_Cell = Convert.ToString(data_reader["MFGCELL"]) };
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

            return data_list;
        }

        public List<NM_CondicionalMaster> GetListConditionals(out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<NM_CondicionalMaster> data_list = new List<NM_CondicionalMaster>();
            List<NM_CondicionalMaster> data_list_master = new List<NM_CondicionalMaster>();
            NM_CondicionalMaster data_model = new NM_CondicionalMaster();
            string error = string.Empty;

            try
            {
                #region CONDIONAL

                switchConexion(_BaseDatos);

                strCadenaSQL = @"
                    SELECT DISTINCT T0.Id, T1.IdCondicionalMaster, T0.NombreCondicional, T0.Tipo FROM NM_Condicionales AS T0 LEFT JOIN NM_CondicionalMaster AS T1 ON T1.IdCondicionalMaster = T0.Id
                    WHERE T0.TIPO IS NOT NULL AND T0.Tipo <> ''";
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    data_model = new NM_CondicionalMaster { IdCondicionalMaster = 0, Nombre = "Seleccione una opción...", Tipo = "Base" };
                    data_list.Add(data_model);

                    while (data_reader.Read())
                    {
                        data_model = new NM_CondicionalMaster();
                        data_model.Id = Convert.ToInt32(data_reader["Id"]);

                        if (data_reader["IdCondicionalMaster"] == DBNull.Value)
                        {
                            data_model.Nombre = Convert.ToString(data_reader["NombreCondicional"]) + " *** Condicion simple ***";
                        }
                        else
                        {
                            data_model.Nombre = Convert.ToString(data_reader["NombreCondicional"]) + " *** Condicion master ***";
                        }

                        data_model.Tipo = Convert.ToString(data_reader["Tipo"]);
                        data_list.Add(data_model);
                    }

                    data_reader.Close();
                }

                #endregion

            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            errorMethod = error;
            return data_list;
        }

        public string GetIdCompuesto(string id)
        {
            SqlDataReader data_reader = null;
            string id_compuesto = string.Empty;
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT TOP 1 * FROM NM_CondicionalMaster WHERE IdCondicionalMaster = '" + id + "'";
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        id_compuesto = data_reader["IdCompuesto"].ToString();
                    }

                    data_reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return id_compuesto;
        }

        public string GetFormula(int id, out string errorMethod)
        {
            SqlDataReader data_reader = null;
            string formula = string.Empty;
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_Formulas WHERE Id = '" + id + "'";
                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        formula = data_reader["Formula"].ToString();
                    }

                    data_reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return formula;
        }

        public List<ConditionalsModel> GetListConditionals(int id, out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<ConditionalsModel> data_list = new List<ConditionalsModel>();
            ConditionalsModel data_model = new ConditionalsModel();
            string error = string.Empty;

            try
            {
                #region CONDIONAL

                switchConexion(_BaseDatos);

                strCadenaSQL = @"
                    SELECT 
                        T0.Id, T1.IdCondicionalMaster, T0.NombreCondicional, T0.Tipo, T0.Condicional, T1.IdElemento, T1.Posicion  
                    FROM 
                        NM_Condicionales AS T0 LEFT JOIN NM_CondicionalMaster AS T1 ON T1.IdCondicionalMaster = T0.Id
                    WHERE  
                        T0.Id = " + id + " AND T0.TIPO IS NOT NULL AND T0.Tipo <> ''";

                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new ConditionalsModel();
                        data_model.Id = Convert.ToInt32(data_reader["Id"]);

                        if (data_reader["IdElemento"] == DBNull.Value)
                        {
                            data_model.IdElemento = 0;
                        }
                        else
                        {
                            data_model.IdElemento = Convert.ToInt32(data_reader["IdElemento"]);
                        }

                        data_model.Posicion = Convert.ToString(data_reader["Posicion"]);
                        data_model.Condicional = Convert.ToString(data_reader["Condicional"]);

                        if (data_reader["IdCondicionalMaster"] == DBNull.Value)
                        {
                            data_model.Nombre = Convert.ToString(data_reader["NombreCondicional"]) + " CS";
                        }
                        else
                        {
                            data_model.Nombre = Convert.ToString(data_reader["NombreCondicional"]) + " CM";
                        }

                        data_model.Tipo = Convert.ToString(data_reader["Tipo"]);
                        data_list.Add(data_model);
                    }

                    data_reader.Close();
                }

                #endregion

            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            errorMethod = error;
            return data_list;
        }

        public ConditionalsModel GetConditionals(int id, out string errorMethod)
        {
            SqlDataReader data_reader = null;
            ConditionalsModel data_model = new ConditionalsModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = @"
                   SELECT * FROM NM_Condicionales WHERE Id = " + id;

                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new ConditionalsModel();
                        data_model.Id = Convert.ToInt32(data_reader["Id"]);
                        data_model.Verdadero = Convert.ToString(data_reader["Verdadero"]);
                        data_model.Falso = Convert.ToString(data_reader["Falso"]);
                        data_model.Condicional = Convert.ToString(data_reader["Condicional"]);
                        data_model.Nombre = Convert.ToString(data_reader["NombreCondicional"]);
                    }

                    data_reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return data_model;
        }

        #region EDICION

        public long GetIdCombinationBOM(string combination, string type, out string errorMethod)
        {
            SqlDataReader reader = null;
            long id = 0;
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT Id FROM NM_Combinaciones WHERE Combinacion_Bom = '" + combination + "' AND Acabado = '" + type + "'";
                reader = funConsultaSQL();

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt64(reader["Id"]);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                id = 0;
            }

            errorMethod = error;
            return id;
        }

        public List<NM_Detalle_Combinaciones_ComponentesModel> GetListComponents(long id, out string errorMethod)
        {
            List<NM_Detalle_Combinaciones_ComponentesModel> dataList = new List<NM_Detalle_Combinaciones_ComponentesModel>();
            NM_Detalle_Combinaciones_ComponentesModel dataModel = new NM_Detalle_Combinaciones_ComponentesModel();
            SqlDataReader reader = null;
            string error = string.Empty;
            string QUERY = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_Detalle_Combinaciones_Componentes WHERE Id_Combinacion = " + id;
                //strCadenaSQL = "SELECT comp.Id,comp.Class,comp.IdComponentes,comp.Itemno,comp.Nombre_Componente" +
                //                      "form.L FROM NM_Detalle_Combinaciones_Componentes WHERE Id_Combinacion = " + id;
                reader = funConsultaSQL();

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        dataModel = new NM_Detalle_Combinaciones_ComponentesModel
                        {
                            
                            Id = Convert.ToInt32(reader["Id"]),
                            Class = Convert.ToString(reader["Class_IQMS"]),
                            IdComponentes = Convert.ToInt32(reader["Id_Arinvt"]),
                            Itemno = Convert.ToString(reader["Itemno"]),
                            Nombre_Componente = Convert.ToString(reader["Nombre_Componente"])
                        };
                        QUERY = string.Format("Select Linea From NM_Detalle_Combinacion_Componentes_Formulas WHERE " +
                                                  "IdDetalleComp = {0} AND IdCombinacion = {1}", dataModel.Id,id);
                        dataModel.Linea = Convert.ToInt32(sql.Select(QUERY, "Linea"));
                        if(!dataList.Contains(dataModel))
                            dataList.Add(dataModel);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                dataList = null;
            }

            errorMethod = error;
            return dataList;
        }

        public List<NM_Detalle_Combinacion_Componentes_FormulasModel> GetListComponentsFormulas(string combinacion, string typeMaterial, out string errorMethod)
        {
            List<NM_Detalle_Combinacion_Componentes_FormulasModel> dataList = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
            NM_Detalle_Combinacion_Componentes_FormulasModel dataModel = new NM_Detalle_Combinacion_Componentes_FormulasModel();
            SqlDataReader reader = null;
            string error = string.Empty;
            string condicionalQty = string.Empty;
            string condicionalMd = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = @"
                SELECT DISTINCT 
                    T0.Id, T0.IdDetalleComp, T1.Id AS IdCombinacion, T1.Combinacion_Bom AS Combinacion, T0.Id AS IdDetalleForComp, T2.Itemno AS Itemno, T2.Class_IQMS AS Class, T2.Nombre_Componente AS NombreComponente, 
                    T3.Id AS IdFormulaMD, T3.NombreFormula AS NombreFormulaMD, T4.Id AS IdFormulaQty, T4.NombreFormula AS NombreFormulaQty, T5.Id AS IdFormulaTotal, T5.NombreFormula AS NombreFormulaTotal, 
                    T0.IdCondicionalQty, T0.IdCondicionalMd, T10.Id AS IdCondicionalTotal, T0.TypeConditionalQty, T0.TypeConditionalMd, T0.IdCompuestoQty, T0.IdCompuestoMd, 
                    T6.Nombre AS NombreMasterQty, T7.Nombre AS NombreMasterMd, T0.Seccion AS Seccion ,T0.Linea AS Linea, T0.Descripcion AS Descripcion,
                    T_Formulas.Id AS IdFormulaPeso,T_Formulas.NombreFormula As NombreFormulaPeso,
                    T8.NombreCondicional AS CondicionalQty, T9.NombreCondicional AS CondicionalMd
                FROM 
	                NM_Detalle_Combinacion_Componentes_Formulas AS T0 (NOLOCK)
	                INNER JOIN NM_Combinaciones AS T1 (NOLOCK) ON T1.Id = T0.IdCombinacion
	                INNER JOIN NM_Detalle_Combinaciones_Componentes AS T2 (NOLOCK) ON T2.Id_Arinvt = T0.IdComponente AND T2.Id_Combinacion = T1.Id AND T2.Id_Combinacion = T0.IdCombinacion
	                LEFT JOIN NM_Formulas AS T3 (NOLOCK) ON T3.Id = T0.IdFormulaMd
	                LEFT JOIN NM_Formulas AS T4 (NOLOCK) ON T4.Id = T0.IdFormulaQty
	                LEFT JOIN NM_Formulas AS T5 (NOLOCK) ON T5.Id = T0.IdFormulaTotal
                    LEFT JOIN NM_Formulas AS T_Formulas (NOLOCK) ON T_Formulas.Id = T0.IdFormulaPeso
	                LEFT JOIN NM_CondicionalMaster AS T6 (NOLOCK) ON T6.IdCondicionalMaster = T0.IdCondicionalQty
	                LEFT JOIN NM_CondicionalMaster AS T7 (NOLOCK) ON T7.IdCondicionalMaster = T0.IdCondicionalMd
	                LEFT JOIN NM_Condicionales AS T8 (NOLOCK) ON T8.Id = T0.IdCondicionalQty
	                LEFT JOIN NM_Condicionales AS T9 (NOLOCK) ON T9.Id = T0.IdCondicionalMd
                    LEFT JOIN NM_Condicionales AS T10 (NOLOCK) ON T10.Id = T0.IdFormulaTotal
                WHERE 
                    T1.Combinacion_Bom = '" + combinacion + @"'
                        AND T1.Acabado = '" + typeMaterial + @"'
                ORDER BY 
	                T2.Itemno DESC";

                reader = funConsultaSQL();

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        dataModel = new NM_Detalle_Combinacion_Componentes_FormulasModel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdCombinacion = Convert.ToInt32(reader["IdCombinacion"]),
                            Itemno = Convert.ToString(reader["Itemno"]),
                            NombreComponente = Convert.ToString(reader["NombreComponente"]),
                            NombreFormulaMd = Convert.ToString(reader["NombreFormulaMd"]),
                            NombreFormulaQty = Convert.ToString(reader["NombreFormulaQty"]),
                            NombreFormulaTotal = Convert.ToString(reader["NombreFormulaTotal"]),
                            NombreFormulaPeso = Convert.ToString(reader["NombreFormulaPeso"]),
                            IdDetalleForComp = Convert.ToInt32(reader["IdDetalleComp"]),
                            
                        };

                        if (reader["NombreMasterQty"]==DBNull.Value)
                        {
                            dataModel.NombreCondicionalQty = Convert.ToString(reader["CondicionalQty"]);
                        }
                        else
                        {
                            dataModel.NombreCondicionalQty = Convert.ToString(reader["NombreMasterQty"]);
                        }
                        if (reader["NombreMasterMd"] == DBNull.Value)
                        {
                            dataModel.NombreCondicionalMd = Convert.ToString(reader["CondicionalMd"]);
                        }
                        else
                        {
                            dataModel.NombreCondicionalMd = Convert.ToString(reader["NombreMasterMd"]);
                        }

                        if (reader["Seccion"]==DBNull.Value)
                        {
                            dataModel.Seccion = "";
                        }
                        else
                        {
                            dataModel.Seccion = Convert.ToString(reader["Seccion"]);
                        }
                        if (reader["Linea"] == DBNull.Value)
                        {
                            dataModel.Linea = 0;
                        }
                        else
                        {
                            dataModel.Linea = Convert.ToInt32(reader["Linea"]);
                        }
                        if (reader["Descripcion"] == DBNull.Value)
                        {
                            dataModel.Descripcion = "";
                        }
                        else
                        {
                            dataModel.Descripcion = Convert.ToString(reader["Descripcion"]);
                        }

                        dataList.Add(dataModel);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                dataList = null;
            }

            errorMethod = error;
            return dataList;
        }

        public List<NM_Detalle_Combinacion_Componentes_FormulasModel> GetListComponentsWithFormulas(long id, out string errorMethod)
        {
            List<NM_Detalle_Combinacion_Componentes_FormulasModel> dataList = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
            NM_Detalle_Combinacion_Componentes_FormulasModel dataModel = new NM_Detalle_Combinacion_Componentes_FormulasModel();
            SqlDataReader reader = null;
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_Detalle_Combinacion_Componentes_Formulas WHERE IdCombinacion = " + id;
                reader = funConsultaSQL();

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        dataModel = new NM_Detalle_Combinacion_Componentes_FormulasModel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdComponente = Convert.ToInt32(reader["IdComponente"])
                        };

                        dataList.Add(dataModel);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                dataList = null;
            }

            errorMethod = error;
            return dataList;
        }

        #endregion

        #endregion

        #region POST

        /// <summary>
        /// Metodo para crear el ensamblado completo de componentes con formulas
        /// </summary>
        /// <param name="dataListModel"></param>
        /// <param name="errorMethod"></param>
        public void CreateModelComplete(List<NM_Detalle_Combinacion_Componentes_FormulasModel> dataListModel, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;

            try
            {
                strCadenaSQL = "";
                switchConexion(_BaseDatos);
                iniciarTransaccion();

                for (int i = 0; i < dataListModel.Count; i++)
                {
                    strCadenaSQL += @"
                    INSERT INTO NM_Detalle_Combinacion_Componentes_Formulas ([IdCombinacion], [IdDetalleComp], [Itemno], [IdComponente], [IdFormulaQty], [IdFormulaMd],
                    [IdFormulaTotal],[IdFormulaPeso], [IdCondicionalQty], [IdCondicionalMd], [TypeConditionalMd], [TypeConditionalQty],[IdCompuestoQty], [IdCompuestoMd],[Seccion], [Linea], [Descripcion], [Fecha_Creacion]) " +
                    " VALUES(" + dataListModel[i].IdCombinacion + ", " + dataListModel[i].IdDetalleComponente + ", '" + dataListModel[i].Itemno + "', " + 
                    dataListModel[i].IdComponente + ", " + dataListModel[i].IdFormulaQty + ", " + dataListModel[i].IdFormulaMd + ", " + dataListModel[i].IdFormulaTotal + ", " +
                    dataListModel[i].IdFormulaPeso + ", " + dataListModel[i].IdCondicionalQty + ", " + dataListModel[i].IdCondicionalMd + ", '" + dataListModel[i].TypeConditionalMd + "', '" + 
                    dataListModel[i].TypeConditionalQty + "', '" + dataListModel[i].IdCompuestoQty + "', '" +
                    dataListModel[i].IdCompuestoMd + "','" + dataListModel[i].Seccion + "','" + dataListModel[i].Linea + "','" + dataListModel[i].Descripcion + "', GETDATE())" + Environment.NewLine;

                    //strCadenaSQL += "UPDATE NM_Combinaciones SET Completado = '1' WHERE Id = " + dataListModel[i].IdCombinacion + Environment.NewLine;
                }

                affected = funGuardarSQL(false);
                commitTransaction();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
        }

        /// <summary>
        /// Metodo para crear el modelo pre-ensamblado de nombre combinacion, y componentes
        /// </summary>
        /// <param name="modeloCompuesto">Nombre bom</param>
        /// <param name="acabado">AC, AN, AL</param>
        /// <param name="dataListModel">Lista de componentes</param>
        /// <param name="errorMetodo">Mensaje de error</param>
        /// <returns></returns>
        public bool CreateModelComponents(int id, string modeloCompuesto, string acabado, List<NM_Detalle_Combinaciones_ComponentesModel> dataListModel, out string errorMetodo)
        {
            string error = string.Empty;
            decimal affect = 0;
            bool affected = false;
            int idCombinacion = 0;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();

                strCadenaSQL = "INSERT INTO NM_Combinaciones ([Id_Modelo_Base], [Combinacion_Bom], [Acabado], [Completado], [Fecha_Creacion]) OUTPUT INSERTED.Id VALUES(" + id + ", '" + modeloCompuesto + "', '" + acabado + "', '0', GETDATE())";

                idCombinacion = (int)ExecuteEscalar();

                if (idCombinacion != 0)
                {
                    strCadenaSQL = "";

                    for (int i = 0; i < dataListModel.Count; i++)
                    {
                        strCadenaSQL += "INSERT INTO NM_Detalle_Combinaciones_Componentes ([Id_Combinacion], [Id_Arinvt], [Itemno], [Nombre_Componente], [Class_IQMS], [Fecha_Creacion]) VALUES ('" + idCombinacion + "', '" + dataListModel[i].IdComponentes +
                            "', '" + dataListModel[i].Itemno + "', '" + dataListModel[i].Nombre_Componente + "', '" + dataListModel[i].Class + "', GETDATE())" + Environment.NewLine;
                    }

                    affect = funGuardarSQL(false);
                    commitTransaction();

                    if (affect != 0)
                    {
                        affected = false;
                    }
                    else
                    {
                        affected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMetodo = error;
            return affected;
        }

        public bool CreateModelL0(string nameModel, string descriptionModel, string description_large, string description_english, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "INSERT INTO NM_ModeloL0(Nombre_Modelo, Descripcion_Modelo, Descripcion_Larga, Descripcion_Ingles, Fecha_Creacion) VALUES('" + nameModel + "', '" + descriptionModel + "', '" + description_large + "', '" + description_english + "', GETDATE())";
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool CreateModelL1(int idL0, string nameModel, string descriptionModel, string apply, string mfg,string centroTrabajo, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "INSERT INTO NM_ModeloL1(Id_ModeloL0, Nombre_Modelo, Descripcion_Modelo, Aplica_SubNivel, Mfg_Cell,Cntr_Desc, Fecha_Creacion)" +
                    " VALUES(" + idL0 + ", '" + nameModel + "', '" + descriptionModel + "', '" + apply + "', '" + mfg + "','"+centroTrabajo+"', GETDATE())";
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool CreateModelL2(int idModelL1, string nameModel, string descriptionModel, string apply, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "INSERT INTO NM_ModeloL2(Id_ModeloL1, Nombre_Modelo, Descripcion_Modelo, Aplica_SubNivel, Fecha_Creacion) VALUES('" + idModelL1 + "', '" + nameModel + "', '" + descriptionModel + "', '" + apply + "', GETDATE())";
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool CreateModelL3(int idModelL2, string nameModel, string descriptionModel, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "INSERT INTO NM_ModeloL3(Id_ModeloL2, Nombre_Modelo, Descripcion_Modelo, Fecha_Creacion) VALUES('" + idModelL2 + "', '" + nameModel + "', '" + descriptionModel + "', GETDATE())";
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool CreateMaterial(string name, string description, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "INSERT INTO NM_Materiales (Nombre_Material, Descripcion_Material, Fecha_Creacion) VALUES('" + name + "', '" + description + "', GETDATE())";
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool CreateSubMaterial(int idMaterial, string name, string description, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "INSERT INTO NM_SubMateriales (Id_Material_Base, Nombre_Material, Descripcion_Material, Fecha_Creacion) VALUES (" + idMaterial + ", '" + name + "', '" + description + "', GETDATE())";
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        #endregion

        #region UPDATE

        public bool UpdateModelL0(int idModelL0, string nameModel, string descriptionModel, string description_large, string description_english, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "UPDATE NM_ModeloL0 SET Nombre_Modelo = '" + nameModel + "', Descripcion_Modelo = '" + descriptionModel + "', Descripcion_Larga = '" + description_large + "', Descripcion_Ingles = '" + description_english + "', WHERE Id = " + idModelL0;
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool UpdateModelL1(int idModelL1, string nameModel, string descriptionModel, string apply, string mfg,string centroTrabajo, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "UPDATE NM_ModeloL1 SET Nombre_Modelo = '" + nameModel + "', Descripcion_Modelo = '" + descriptionModel + "', Aplica_SubNivel = '" + apply + "', Mfg_Cell = '" + mfg + "', Cntr_Desc = '"+centroTrabajo+"' WHERE Id = " + idModelL1;
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool UpdateModelL2(int idModelL2, int idModelL1, string nameModel, string descriptionModel, string apply, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "UPDATE NM_ModeloL2 SET Nombre_Modelo = '" + nameModel + "', Descripcion_Modelo = '" + descriptionModel + "', Aplica_SubNivel = '" + apply + "' WHERE Id = " + idModelL2 + " AND Id_ModeloL1 = " + idModelL1;
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool UpdateModelL3(int idModelL3, int idModelL2, string nameModel, string descriptionModel, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "UPDATE NM_ModeloL3 SET Nombre_Modelo = '" + nameModel + "', Descripcion_Modelo = '" + descriptionModel + "' WHERE Id = " + idModelL3 + " AND Id_ModeloL1 = " + idModelL2;
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool UpdateMaterial(int id, string name, string description, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "UPDATE NM_Materiales SET Nombre_Material = '" + name + "', Descripcion_Material = '" + description + "' WHERE ID = " + id;
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool UpdateSubMaterial(int idSubMaterial, string name, string description, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "UPDATE NM_SubMateriales SET Nombre_Material = '" + name + "', Descripcion_Material = '" + description + "' WHERE ID = " + idSubMaterial;
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool UpdateComplete(int id)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "UPDATE NM_Combinaciones SET Completado = '1' WHERE Id = " + id;
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return is_inserted;
        }

        #region EDICION

        public bool UpdateComponentsBOM(long idCombination, string combination, List<NM_Detalle_Combinaciones_ComponentesModel> dataList, List<NM_Detalle_Combinaciones_ComponentesModel> dataListNews, out string errorMethod)
        {
            bool state = false;
            string error = string.Empty;
            decimal affected = 0;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();

                strCadenaSQL = "";

                for (int i = 0; i < dataList.Count; i++)
                {
                    //strCadenaSQL += @"
                    //UPDATE 
                    //    NM_Detalle_Combinacion_Componentes_Formulas 
                    //SET 
                    //    IdComponente = " + dataListNews[i].IdComponentes + @"
                    //WHERE 
                    //    IdComponente = " + dataList[i].IdComponentes + Environment.NewLine;

                    strCadenaSQL += string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas " +
                                    "SET " +
                                  "IdComponente = {0}, Itemno = '{1}' " +
                                    "WHERE " +
                                  "IdComponente = {2}", dataListNews[i].IdComponentes, dataListNews[i].Itemno, dataList[i].IdComponentes);

                    strCadenaSQL += @"
                    UPDATE 
                        NM_Detalle_Combinaciones_Componentes 
                    SET 
                        [Id_Arinvt] = " + dataListNews[i].IdComponentes + ", [Itemno] = '" + dataListNews[i].Itemno + "', [Nombre_Componente] = '" + dataListNews[i].Nombre_Componente + @"', [Class_IQMS] = '" + dataListNews[i].Class + @"'
                    WHERE 
                        Id = " + dataList[i].Id + Environment.NewLine;
                }

                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    state = false;
                }
                else
                {
                    state = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                state = false;
            }

            errorMethod = error;
            return state;
        }

        public bool DeleteComponentsBOM(List<NM_Detalle_Combinaciones_ComponentesModel> dataList, out string errorMethod)
        {
            bool state = false;
            string error = string.Empty;
            decimal affected = 0;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();

                strCadenaSQL = "";

                for (int i = 0; i < dataList.Count; i++)
                {
                    strCadenaSQL += @"DELETE FROM NM_Detalle_Combinacion_Componentes_Formulas WHERE IdDetalleComp = " + dataList[i].Id + Environment.NewLine;
                    strCadenaSQL += @"DELETE FROM NM_Detalle_Combinaciones_Componentes WHERE Id = " + dataList[i].Id + Environment.NewLine;
                }

                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    state = false;
                }
                else
                {
                    state = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                state = false;
            }

            errorMethod = error;
            return state;
        }

        public bool AddComponentsBOM(List<NM_Detalle_Combinaciones_ComponentesModel> dataList, long idCombinacion, out string errorMethod)
        {
            bool state = false;
            string error = string.Empty;
            decimal affected = 0;

            try
            {
                for (int i = 0; i < dataList.Count; i++)
                {
                    int idDetalle = 0;
                    string queryDetalle = @"INSERT INTO [NM_Detalle_Combinaciones_Componentes] ( [Id_Combinacion], [Id_Arinvt], [Itemno], [Nombre_Componente], [Class_IQMS], [Fecha_Creacion]) output INSERTED.ID VALUES ('" + idCombinacion + "', '" + dataList[i].IdComponentes + "', '" + dataList[i].Itemno + "', '" + dataList[i].Nombre_Componente + "', '" + dataList[i].Class + "', GETDATE())" + Environment.NewLine;

                    using (SqlConnection connection = new SqlConnection(connectionSQL))
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            command.CommandType = System.Data.CommandType.Text;
                            command.CommandText = queryDetalle;

                            try
                            {
                                connection.Open();
                                idDetalle = (int)command.ExecuteScalar();
                            }
                            catch (SqlException ex)
                            {
                                error = ex.Message;
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                    }

                    switchConexion(_BaseDatos);
                    iniciarTransaccion();
                    strCadenaSQL = "";

                    strCadenaSQL += @"INSERT INTO [NM_Detalle_Combinacion_Componentes_Formulas] ( [IdCombinacion], [Itemno], [IdComponente], [IdFormulaQty], [IdFormulaMd], [IdFormulaTotal], [IdCondicionalQty], 
                    [IdCondicionalMd], [TypeConditionalMd], [TypeConditionalQty], [IdCompuestoQty], [IdCompuestoMd], [Fecha_Creacion], [IdDetalleComp]) VALUES('" + idCombinacion + "', '" + dataList[i].Itemno + "','" + dataList[i].IdComponentes + "', 0, 0, 0, 0, 0, '', '', 0, 0, GETDATE(), " + idDetalle + ")" +
                    Environment.NewLine;

                    affected = funGuardarSQL(false);
                    commitTransaction();
                }

                if (affected != 0)
                {
                    state = false;
                }
                else
                {
                    switchConexion(_BaseDatos);
                    iniciarTransaccion();

                    strCadenaSQL = "UPDATE [NM_Combinaciones]SET [Completado] = 0 WHERE Id = " + idCombinacion;

                    affected = funGuardarSQL(false);
                    commitTransaction();

                    if (affected != 0)
                    {
                        state = false;
                    }
                    else
                    {
                        state = true;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                state = false;
            }

            errorMethod = error;
            return state;
        }

        public bool UpdateFormulasComponent(List<NM_Detalle_Combinacion_Componentes_FormulasModel> dataList, out string errorMethod)
        {
            string error = string.Empty;
            bool state = false;
            decimal affected = 0;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();

                for (int i = 0; i < dataList.Count; i++)
                {
                    strCadenaSQL += @"
                    UPDATE 
                        [NM_Detalle_Combinacion_Componentes_Formulas]
                    SET
                        [IdFormulaQty] = " + dataList[i].IdFormulaQty + ", [IdFormulaMd] = " + dataList[i].IdFormulaMd + ", [IdFormulaTotal] = " + dataList[i].IdFormulaTotal + ", [IdCondicionalQty] = " + dataList[i].IdCondicionalQty + @",
                        [IdCondicionalMd] = " + dataList[i].IdCondicionalMd + ", [TypeConditionalMd] = '" + dataList[i].TypeConditionalMd + "', [TypeConditionalQty] = '" + dataList[i].TypeConditionalQty + @"', 
                        [IdCompuestoQty] = '" + dataList[i].IdCompuestoQty + "', [IdCompuestoMd] = '" + dataList[i].IdCompuestoMd + @"'
                    WHERE
                        Id = " + dataList[i].Id + Environment.NewLine;
                }

                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    state = false;
                }
                else
                {
                    switchConexion(_BaseDatos);
                    iniciarTransaccion();

                    for (int i = 0; i < dataList.Count; i++)
                    {
                        strCadenaSQL += "UPDATE [NM_Combinaciones]SET [Completado] = 1 WHERE Id = " + dataList[i].IdCombinacion + Environment.NewLine;
                    }

                    affected = funGuardarSQL(false);
                    commitTransaction();

                    if (affected != 0)
                    {
                        state = false;
                    }
                    else
                    {
                        state = true;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                state = false;
            }

            errorMethod = error;
            return state;
        }

        #endregion

        #endregion

        #region DELETE

        public bool DeleteModelL0(int idModelL0, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "DELETE FROM NM_ModeloL0 WHERE Id = " + idModelL0;
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool DeleteModelL1(int idModelL1, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "DELETE FROM NM_ModeloL1 WHERE Id = " + idModelL1;
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool DeleteModelL2(int idModelL2, int idModelL1, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "DELETE FROM NM_ModeloL2 WHERE Id = " + idModelL2 + " AND Id_ModeloL1 = " + idModelL1;
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool DeleteModelL3(int idModelL3, int idModelL2, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "DELETE FROM NM_ModeloL3 WHERE Id = " + idModelL3 + " AND Id_ModeloL1 = " + idModelL2;
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool DeleteMaterial(int id, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "DELETE FROM NM_Materiales WHERE ID = " + id;
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool DeleteSubMaterial(int id, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "DELETE FROM NM_SubMateriales WHERE ID = " + id;
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        #endregion
    }
}
