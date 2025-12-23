using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;
using BOM_Builder.Logs;

namespace BOM_Builder.DL
{
    public class ComponentesDL : DataAccessSQL
    {
        #region VARIABLES GLOBALES

        Log logs = new Log();
        private readonly string _BaseDatos = null;
        private const string querySQL = "SQL";
        SqlDataReader dataReader = null;

        #endregion

        public List<NM_ComponentesModel> Get_List_Components()
        {
            List<NM_ComponentesModel> lData = new List<NM_ComponentesModel>();
            NM_ComponentesModel mData = new NM_ComponentesModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM NM_Componentes";
                logs.Log_Query(strCadenaSQL, this.GetType().Name, MethodBase.GetCurrentMethod().Name, querySQL);
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new NM_ComponentesModel
                        {
                            Id = Convert.ToInt16(dataReader["Id"]),
                            Codigo = Convert.ToString(dataReader["Codigo"]),
                            Nombre_Componente = Convert.ToString(dataReader["Nombre_Componente"])
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

        public bool Create_Component(string modeloCompuesto)
        {
            decimal affected = 0;
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "INSERT INTO NM_Combinaciones (Combinacion_Bom, Fecha_Creacion) VALUES ('" + modeloCompuesto + "', GETDATE())";
                logs.Log_Query(strCadenaSQL, this.GetType().Name, MethodBase.GetCurrentMethod().Name, querySQL);
                affected = funGuardarSQL(false);
                commitTransaction();

                return affected > 0 ? true : false;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool Create_Component_Detail(int idCombinacion, int idComponente, int cantidad)
        {
            decimal affected = 0;
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "INSERT INTO NM_Detalle_Combinaciones_Componentes (Id_Combinacion, Id_Componente, Cantidad, Fecha_Creacion) VALUES ('" + idCombinacion + "', '" + idComponente + "', GETDATE())";
                logs.Log_Query(strCadenaSQL, this.GetType().Name, MethodBase.GetCurrentMethod().Name, querySQL);
                affected = funGuardarSQL(false);
                commitTransaction();

                return affected > 0 ? true : false;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public string Get_Codigo(string pNombre, string pMaterial)
        {
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                if (pMaterial == "AL" || pMaterial == "AN" || pMaterial == "AC")
                {
                    strCadenaSQL = "SELECT Codigo FROM NM_Componentes WHERE Nombre_Componente = '" + pNombre + "' AND Acabado = '" + pMaterial + "'";
                }

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        error = Convert.ToString(dataReader["Codigo"]);
                    }

                    dataReader.Close();
                }

                if (error == "")
                {
                    switchConexion(_BaseDatos);
                    strCadenaSQL = "SELECT Codigo FROM NM_Componentes WHERE Nombre_Componente = '" + pNombre + "'";
                    dataReader = funConsultaSQL();

                    if (dataReader != null)
                    {
                        while (dataReader.Read())
                        {
                            error = Convert.ToString(dataReader["Codigo"]);
                        }

                        dataReader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }

        public string Get_Class(string pNombre, string pMaterial)
        {
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                if (pMaterial == "AL" || pMaterial == "AN" || pMaterial == "AC")
                {
                    strCadenaSQL = "SELECT class FROM NM_Componentes WHERE Nombre_Componente = '" + pNombre + "' AND Acabado = '" + pMaterial + "'";
                }

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        error = Convert.ToString(dataReader["class"]);
                    }

                    dataReader.Close();
                }

                if (error == "")
                {
                    switchConexion(_BaseDatos);
                    strCadenaSQL = "SELECT Codigo FROM NM_Componentes WHERE Nombre_Componente = '" + pNombre + "'";
                    dataReader = funConsultaSQL();

                    if (dataReader != null)
                    {
                        while (dataReader.Read())
                        {
                            error = Convert.ToString(dataReader["Codigo"]);
                        }

                        dataReader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }
    }
}
