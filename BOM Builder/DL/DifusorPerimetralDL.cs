using BOM_Builder.Logs;
using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace BOM_Builder.DL
{
    public class DifusorPerimetralDL : DataAccessSQL
    {
        #region VARIABLES GLOBALES

        Log logs = new Log();
        private readonly string _BaseDatos = null;
        private const string querySQL = "SQL";
        SqlDataReader dataReader = null;

        #endregion

        public List<NM_CodigoModel> Get_List_Codigos()
        {
            List<NM_CodigoModel> lData = new List<NM_CodigoModel>();
            NM_CodigoModel mData = new NM_CodigoModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_CODIGO WHERE Valor_Codigo = 'DP'";
                logs.Log_Query(strCadenaSQL, this.GetType().Name, MethodBase.GetCurrentMethod().Name, querySQL);
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new NM_CodigoModel
                        {
                            Id = Convert.ToInt16(dataReader["Id"]),
                            Valor_Codigo = Convert.ToString(dataReader["Valor_Codigo"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"])
                        };

                        lData.Add(mData);
                    }

                    dataReader = null;
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return lData;
        }

        public List<NM_AccesorioModel> Get_List_Accesorios()
        {
            List<NM_AccesorioModel> lData = new List<NM_AccesorioModel>();
            NM_AccesorioModel mData = new NM_AccesorioModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_Accesorio";
                logs.Log_Query(strCadenaSQL, this.GetType().Name, MethodBase.GetCurrentMethod().Name, querySQL);
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    mData = new NM_AccesorioModel
                    {
                        Id = 0,
                        Valor_Accesorio = "Seleccione una opción..."
                    };

                    lData.Add(mData);

                    while (dataReader.Read())
                    {
                        mData = new NM_AccesorioModel
                        {
                            Id = Convert.ToInt16(dataReader["Id"]),
                            Valor_Accesorio = Convert.ToString(dataReader["Valor_Accesorio"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"])
                        };

                        lData.Add(mData);
                    }

                    dataReader = null;
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return lData;
        }

        public List<NM_DeflexorModel> Get_List_Deflexores()
        {
            List<NM_DeflexorModel> lData = new List<NM_DeflexorModel>();
            NM_DeflexorModel mData = new NM_DeflexorModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_DEFLEXOR";
                logs.Log_Query(strCadenaSQL, this.GetType().Name, MethodBase.GetCurrentMethod().Name, querySQL);
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new NM_DeflexorModel
                        {
                            Id = Convert.ToInt16(dataReader["Id"]),
                            Valor_Deflexor = Convert.ToString(dataReader["Valor_Deflexor"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"])
                        };

                        lData.Add(mData);
                    }

                    dataReader = null;
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return lData;
        }

        public List<NM_EspesorModel> Get_List_Espesores()
        {
            List<NM_EspesorModel> lData = new List<NM_EspesorModel>();
            NM_EspesorModel mData = new NM_EspesorModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_ESPESOR";
                logs.Log_Query(strCadenaSQL, this.GetType().Name, MethodBase.GetCurrentMethod().Name, querySQL);
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new NM_EspesorModel
                        {
                            Id = Convert.ToInt16(dataReader["Id"]),
                            Valor_Espesor = Convert.ToInt16(dataReader["Valor_Espesor"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"])
                        };

                        lData.Add(mData);
                    }

                    dataReader = null;
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return lData;
        }

        public List<NM_MarcoModel> Get_List_Marcos()
        {
            List<NM_MarcoModel> lData = new List<NM_MarcoModel>();
            NM_MarcoModel mData = new NM_MarcoModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_MARCO";
                logs.Log_Query(strCadenaSQL, this.GetType().Name, MethodBase.GetCurrentMethod().Name, querySQL);
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    mData = new NM_MarcoModel
                    {
                        Id = 0,
                        Valor_Marco = "Seleccione una opción..."
                    };

                    lData.Add(mData);

                    while (dataReader.Read())
                    {
                        mData = new NM_MarcoModel
                        {
                            Id = Convert.ToInt16(dataReader["Id"]),
                            Valor_Marco = Convert.ToString(dataReader["Valor_Marco"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"])
                        };

                        lData.Add(mData);
                    }

                    dataReader = null;
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return lData;
        }

        public List<NM_SeparadorModel> Get_List_Separadores()
        {
            List<NM_SeparadorModel> lData = new List<NM_SeparadorModel>();
            NM_SeparadorModel mData = new NM_SeparadorModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_SEPARADOR";
                logs.Log_Query(strCadenaSQL, this.GetType().Name, MethodBase.GetCurrentMethod().Name, querySQL);
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new NM_SeparadorModel
                        {
                            Id = Convert.ToInt16(dataReader["Id"]),
                            Valor_Separacion = Convert.ToInt16(dataReader["Valor_Separacion"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"])
                        };

                        lData.Add(mData);
                    }

                    dataReader = null;
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return lData;
        }

        public int Get_Combinacion_Existente(string combinacion)
        {
            string error = string.Empty;
            int Id = 0;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT Id FROM NM_Combinaciones WHERE Combinacion_Bom = '" + combinacion + "'";
                logs.Log_Query(strCadenaSQL, this.GetType().Name, MethodBase.GetCurrentMethod().Name, querySQL);
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        Id = Convert.ToInt16(dataReader["Id"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                Id = 0;
            }

            return Id;
        }

        public string Get_Descrip_Marco(string pMarco)
        {
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT Descripcion FROM NM_Marco WHERE Valor_Marco = '" + pMarco + "'";
                logs.Log_Query(strCadenaSQL, this.GetType().Name, MethodBase.GetCurrentMethod().Name, querySQL);
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        error = Convert.ToString(dataReader["Descripcion"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }

        public string Get_Descrip_Separador(string pSeparador)
        {
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT Descripcion FROM NM_SEPARADOR WHERE Valor_Separacion = '" + pSeparador + "'";
                logs.Log_Query(strCadenaSQL, this.GetType().Name, MethodBase.GetCurrentMethod().Name, querySQL);
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        error = Convert.ToString(dataReader["Descripcion"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }

        public string Get_Descrip_Grados(string pGrados)
        {
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT Descripcion FROM NM_Deflexor WHERE Valor_Deflexor = '" + pGrados + "'";
                logs.Log_Query(strCadenaSQL, this.GetType().Name, MethodBase.GetCurrentMethod().Name, querySQL);
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        error = Convert.ToString(dataReader["Descripcion"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }

        public string Get_Descrip_Espesor(string pEspesor)
        {
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT Descripcion FROM NM_Espesor WHERE Valor_Espesor = '" + pEspesor + "'";
                logs.Log_Query(strCadenaSQL, this.GetType().Name, MethodBase.GetCurrentMethod().Name, querySQL);
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        error = Convert.ToString(dataReader["Descripcion"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }

        public List<NM_ComponentesModel> Get_List_Components_AL()
        {
            List<NM_ComponentesModel> lData = new List<NM_ComponentesModel>();
            NM_ComponentesModel mData = new NM_ComponentesModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "SELECT * FROM NM_Componentes WHERE Codigo LIKE '%PEXAL%'";

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new NM_ComponentesModel
                        {
                            Id = Convert.ToInt32(dataReader["ID"]),
                            Id_Arinvt = Convert.ToString(dataReader["Id_Arinvt"]),
                            Codigo = Convert.ToString(dataReader["Codigo"]),
                            Nombre_Componente = Convert.ToString(dataReader["Nombre_Componente"]),
                            Class = Convert.ToString(dataReader["Class"])
                        };

                        lData.Add(mData);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return lData;
        }

        public List<NM_ComponentesModel> Get_List_Components_AN()
        {
            List<NM_ComponentesModel> lData = new List<NM_ComponentesModel>();
            NM_ComponentesModel mData = new NM_ComponentesModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "SELECT * FROM NM_Componentes WHERE Codigo LIKE '%PEXAN%'";

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new NM_ComponentesModel
                        {
                            Id = Convert.ToInt32(dataReader["ID"]),
                            Id_Arinvt = Convert.ToString(dataReader["Id_Arinvt"]),
                            Codigo = Convert.ToString(dataReader["Codigo"]),
                            Nombre_Componente = Convert.ToString(dataReader["Nombre_Componente"]),
                            Class = Convert.ToString(dataReader["Class"])
                        };

                        lData.Add(mData);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return lData;
        }

        public List<NM_ComponentesModel> Get_List_Components_AC()
        {
            List<NM_ComponentesModel> lData = new List<NM_ComponentesModel>();
            NM_ComponentesModel mData = new NM_ComponentesModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "SELECT * FROM NM_Componentes WHERE Codigo LIKE '%PEXAC%'";

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new NM_ComponentesModel
                        {
                            Id = Convert.ToInt32(dataReader["ID"]),
                            Id_Arinvt = Convert.ToString(dataReader["Id_Arinvt"]),
                            Codigo = Convert.ToString(dataReader["Codigo"]),
                            Nombre_Componente = Convert.ToString(dataReader["Nombre_Componente"]),
                            Class = Convert.ToString(dataReader["Class"])
                        };

                        lData.Add(mData);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return lData;
        }

        public List<NM_ComponentesModel> Get_List_Components_Class_ST()
        {
            List<NM_ComponentesModel> lData = new List<NM_ComponentesModel>();
            NM_ComponentesModel mData = new NM_ComponentesModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "SELECT * FROM NM_Componentes WHERE [Class] LIKE '%ST%'";

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new NM_ComponentesModel
                        {
                            Id = Convert.ToInt32(dataReader["ID"]),
                            Id_Arinvt = Convert.ToString(dataReader["Id_Arinvt"]),
                            Codigo = Convert.ToString(dataReader["Codigo"]),
                            Nombre_Componente = Convert.ToString(dataReader["Nombre_Componente"]),
                            Class = Convert.ToString(dataReader["Class"])
                        };

                        lData.Add(mData);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return lData;
        }

        public List<NM_ComponentesModel> Get_List_Components_Class_PC()
        {
            List<NM_ComponentesModel> lData = new List<NM_ComponentesModel>();
            NM_ComponentesModel mData = new NM_ComponentesModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "  SELECT * FROM NM_Componentes WHERE [Class] LIKE '%PC%'";

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new NM_ComponentesModel
                        {
                            Id = Convert.ToInt32(dataReader["ID"]),
                            Id_Arinvt = Convert.ToString(dataReader["Id_Arinvt"]),
                            Codigo = Convert.ToString(dataReader["Codigo"]),
                            Nombre_Componente = Convert.ToString(dataReader["Nombre_Componente"]),
                            Class = Convert.ToString(dataReader["Class"])
                        };

                        lData.Add(mData);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return lData;
        }

        public bool Add_Components(List<ArinvtModel> pModel, string pAcabado)
        {
            string error = string.Empty;
            decimal affected = 0;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();

                for (int i = 0; i < pModel.Count; i++)
                {
                    strCadenaSQL = strCadenaSQL + @"
                        INSERT INTO NM_Componentes ([Id_Arinvt], [Codigo], [Acabado], [Class], [Nombre_Componente], [Fecha_Creacion]) VALUES ('" + pModel[i].Id + "','" + pModel[i].Itemno + "', '" +
                        pAcabado + "', '" + pModel[i].Class + "','" + pModel[i].Descrip1 + "', GETDATE())" + Environment.NewLine;
                }

                affected = funGuardarSQL(false);
                commitTransaction();

                return affected <= 0 ? true : false;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
