using BOM_Builder.Models;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.OracleClient;
using IQMS.Entities.Lib.Manufacturing;

namespace BOM_Builder.DL
{
    public class BomDL : DataAccessOracle
    {
        private readonly string _BaseDatos = null;
        OracleDataReader dataReader = null;
        DataAccessSQL AccessSQL = new DataAccessSQL();

        public List<ArinvtModel> GetListClassValid(out string errorMethod)
        {
            List<ArinvtModel> data_list = new List<ArinvtModel>();
            ArinvtModel data_model = new ArinvtModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT CLASS FROM ARINVT_CLASS WHERE PRIMARY_MATERIAL = 'Y'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        data_model = new ArinvtModel { Class = Convert.ToString(dataReader["class"]) };
                        data_list.Add(data_model);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return data_list;
        }

        public string Get_Itemno_Article(string pQuery)
        {
            string error = string.Empty;
            string itemno = string.Empty;
            SqlDataReader dataReader = null;

            try
            {
                AccessSQL.switchConexion(_BaseDatos);

                AccessSQL.strCadenaSQL = "SELECT TOP 1 Codigo FROM NM_Componentes WHERE Nombre_Componente = '" + pQuery + "'";

                dataReader = AccessSQL.funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        if (dataReader["Codigo"] == DBNull.Value)
                        {
                            itemno = "";
                        }
                        else
                        {
                            itemno = Convert.ToString(dataReader["Codigo"]);
                        }
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return itemno;
        }

        public bool Exist_Article(string pItemno)
        {
            string error = string.Empty;
            bool exist = false;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "SELECT ITEMNO FROM ARINVT WHERE ITEMNO = '" + pItemno + "'";

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        if (dataReader["ITEMNO"] == DBNull.Value)
                        {
                            exist = false;
                        }
                        else
                        {
                            exist = true;
                        }
                    }

                    dataReader.Close();

                }
                return exist;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                exist = false;
            }

            return exist;
        }

        public ArinvtModel Get_Purchased_Item(string pItemno, string pKind)
        {
            ArinvtModel arinvt = new ArinvtModel();
            string error = string.Empty;
            string itemno = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "SELECT ITEMNO, ID FROM ARINVT WHERE ITEMNO = '" + pItemno + "' --AND CLASS = '" + pKind + "'";

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        arinvt.Itemno = Convert.ToString(dataReader["itemno"]);
                        arinvt.Id = Convert.ToInt64(dataReader["Id"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return arinvt;
        }

        public List<ArinvtModel> Get_List_Components_AL()
        {
            List<ArinvtModel> lData = new List<ArinvtModel>();
            ArinvtModel mData = new ArinvtModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "SELECT * FROM ARINVT WHERE ITEMNO LIKE '%PEXAL%' AND DESCRIP NOT LIKE 'TRAMO%'";

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new ArinvtModel
                        {
                            Id = Convert.ToInt64(dataReader["ID"]),
                            Itemno = Convert.ToString(dataReader["Itemno"]),
                            Descrip1 = Convert.ToString(dataReader["Descrip"]),
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

        public List<ArinvtModel> Get_List_Components_AN()
        {
            List<ArinvtModel> lData = new List<ArinvtModel>();
            ArinvtModel mData = new ArinvtModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "SELECT * FROM ARINVT WHERE ITEMNO LIKE '%PEXAN%' AND DESCRIP NOT LIKE 'TRAMO%'";

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new ArinvtModel
                        {
                            Id = Convert.ToInt64(dataReader["ID"]),
                            Itemno = Convert.ToString(dataReader["Itemno"]),
                            Descrip1 = Convert.ToString(dataReader["Descrip"]),
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

        public List<ArinvtModel> Get_List_Components_AC()
        {
            List<ArinvtModel> lData = new List<ArinvtModel>();
            ArinvtModel mData = new ArinvtModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "SELECT * FROM ARINVT WHERE ITEMNO LIKE '%PEXAC%' AND DESCRIP NOT LIKE 'TRAMO%'";

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new ArinvtModel
                        {
                            Id = Convert.ToInt64(dataReader["ID"]),
                            Itemno = Convert.ToString(dataReader["Itemno"]),
                            Descrip1 = Convert.ToString(dataReader["Descrip"]),
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

        public List<ArinvtModel> Get_List_Components_Class_ST()
        {
            List<ArinvtModel> lData = new List<ArinvtModel>();
            ArinvtModel mData = new ArinvtModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "SELECT * FROM ARINVT WHERE ITEMNO NOT LIKE '%PEXAL%' AND ITEMNO NOT LIKE '%PEXAN%' AND ITEMNO NOT LIKE '%PEXAC%' AND DESCRIP NOT LIKE '%TRAMO%' AND CLASS LIKE 'ST'";

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new ArinvtModel
                        {
                            Id = Convert.ToInt64(dataReader["ID"]),
                            Itemno = Convert.ToString(dataReader["Itemno"]),
                            Descrip1 = Convert.ToString(dataReader["Descrip"]),
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

        public List<ArinvtModel> Get_List_Components_Class_PC()
        {
            List<ArinvtModel> lData = new List<ArinvtModel>();
            ArinvtModel mData = new ArinvtModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "SELECT * FROM ARINVT WHERE ITEMNO NOT LIKE '%PEXAL%' AND ITEMNO NOT LIKE '%PEXAN%' AND ITEMNO NOT LIKE '%PEXAC%' AND DESCRIP NOT LIKE '%TRAMO%' AND CLASS LIKE 'PC'";

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new ArinvtModel
                        {
                            Id = Convert.ToInt64(dataReader["ID"]),
                            Itemno = Convert.ToString(dataReader["Itemno"]),
                            Descrip1 = Convert.ToString(dataReader["Descrip"]),
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

        public string Get_Id_Form_User(string pTable)
        {
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT ID FROM UD_TABLES WHERE TABLE_NAME = '" + pTable + "'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        error = Convert.ToString(dataReader["ID"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                error = "0";
            }

            return error;
        }

        public List<UdColsModel> Get_List_Id_Form_User(string pId)
        {
            OracleDataReader dataReader = null;
            List<UdColsModel> lData = new List<UdColsModel>();
            UdColsModel mData = new UdColsModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM UD_COLS WHERE UD_TABLES_ID = '" + pId + "'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        mData = new UdColsModel
                        {
                            Id = Convert.ToString(dataReader["ID"]),
                            Col_Name = Convert.ToString(dataReader["Col_Name"]),
                            Col_Label = Convert.ToString(dataReader["Col_Label"])
                        };
                        lData.Add(mData);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                lData = null;
            }

            return lData;
        }

        public string GetDescriptionLarge(string id, out string errorMethod)
        {
            OracleDataReader dataReader = null;
            string description = string.Empty;
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT CUSER FROM UD_DATA WHERE PARENT_ID = '" + id + "'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        description = Convert.ToString(dataReader["CUSER"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return description;
        }

        public string GetDescriptionEnglish(string id, out string errorMethod)
        {
            OracleDataReader dataReader = null;
            string description = string.Empty;
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT CUSER FROM UD_DATA WHERE PARENT_ID = '" + id + "'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        description = Convert.ToString(dataReader["CUSER"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return description;
        }

        public bool Add_Descriptions(List<UdColsModel> pModel, string pIdBom, string pDescription, string pDescriptionEnglish)
        {
            string error = string.Empty;
            decimal affected = 0;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();

                for (int i = 0; i < pModel.Count; i++)
                {
                    if (pModel[i].Col_Name == "DESCRIPTION_LARGE")
                    {
                        strCadenaSQL = "INSERT INTO UD_DATA (UD_COLS_ID, PARENT_ID, CUSER) VALUES('" + pModel[i].Id + "', '" + pIdBom + "', '" + pDescription + "')";
                        affected = funGuardarSQL(false);
                    }
                    else
                    {
                        strCadenaSQL = "INSERT INTO UD_DATA (UD_COLS_ID, PARENT_ID, CUSER) VALUES('" + pModel[i].Id + "', '" + pIdBom + "', '" + pDescriptionEnglish + "')";
                        affected = funGuardarSQL(false);
                    }
                }

                commitTransaction();
                return affected <= 0 ? true : false;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public string GetIdWorkCenter(string eqno, out string errorMethod)
        {
            OracleDataReader dataReader = null;
            string id = string.Empty;
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT ID FROM WORK_CENTER WHERE EQNO = '" + eqno + "'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        id = Convert.ToString(dataReader["ID"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return id;
        }

        public bool CreateRunBest(string idBom, string idWorkCenter, out string errorMethod)
        {
            string error = string.Empty;
            decimal affected = 0;
            bool is_Inserted = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();
                strCadenaSQL = "INSERT INTO RUNS_BEST(STANDARD_ID, WORK_CENTER_ID_ACT, SEQ) VALUES('" + idBom + "', '" + idWorkCenter + "', '1')";
                affected = funGuardarSQL(false);
                commitTransaction();

                if (affected <= 0)
                {
                    is_Inserted = true;
                }
                else
                {
                    is_Inserted = false;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_Inserted;
        }

        public string GetIdItemFather(string nameModel, string rev, string classes, out string errorMethod)
        {
            string error = string.Empty;
            string id_item_father = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM ARINVT WHERE ITEMNO = '" + nameModel + "' AND REV = '" + rev + "' AND CLASS = '" + classes + "'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        id_item_father = Convert.ToString(dataReader["ID"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                error = "0";
            }

            errorMethod = error;
            return id_item_father;
        }

        public string GetIdItemBomFather(string idArinvt, string classs, out string errorMethod)
        {
            string error = string.Empty;
            string id_item_father = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT STANDARD_ID FROM ARINVT WHERE ID = '" + idArinvt + "' --AND CLASS = '" + classs + "'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        id_item_father = Convert.ToString(dataReader["STANDARD_ID"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                error = "0";
            }

            errorMethod = error;
            return id_item_father;
        }

        public string GetIdItemBomFather(string idArinvt, out string errorMethod)
        {
            string error = string.Empty;
            string id_item_father = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM ARINVT WHERE ID = '" + idArinvt + "'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        id_item_father = Convert.ToString(dataReader["STANDARD_ID"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                error = "0";
            }

            errorMethod = error;
            return id_item_father;
        }

        public string GetIdBomFather(string nameModel, string rev, out string errorMethod)
        {
            string error = string.Empty;
            string id_item_father = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM STANDARD WHERE MFGNO = '" + nameModel + "' AND route_seq = '" + rev + "'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        id_item_father = Convert.ToString(dataReader["ID"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                error = "0";
            }

            errorMethod = error;
            return id_item_father;
        }

        public string GetIdItemArinvt(string itemno, string classes, out string errorMethod)
        {
            string error = string.Empty;
            string id_item_father = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT * FROM ARINVT WHERE ITEMNO = '" + itemno + "' AND CLASS = '" + classes + "'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        id_item_father = Convert.ToString(dataReader["ID"]);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                error = "0";
            }

            errorMethod = error;
            return id_item_father;
        }

        public List<ArinvtModel> GetListClass(out string errorMethod)
        {
            List<ArinvtModel> lData = new List<ArinvtModel>();
            ArinvtModel mData = new ArinvtModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "SELECT * FROM ARINVT_CLASS";

                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    mData = new ArinvtModel
                    {
                        //Id = 0,
                        //Class = "Seleccione una opción..."
                    };

                    lData.Add(mData);

                    while (dataReader.Read())
                    {
                        mData = new ArinvtModel
                        {
                            Id = Convert.ToInt64(dataReader["ID"]),
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

            errorMethod = error;
            return lData;
        }

        public string GetInfoLargeDescription(string idParent, string clase, out string errorMethod)
        {
            string error = string.Empty;
            string description = string.Empty;
            string col_name = string.Empty;

            try
            {
                if (clase.Contains("SA"))
                {
                    col_name = "DESCRIP_LARGA_SA";
                }

                if (clase.Contains("NG"))
                {
                    col_name = "DESCRIP_LARGA_NG";
                }

                if (clase.Contains("PE"))
                {
                    col_name = "DESCRIP_LARGA_PE";
                }

                if (clase.Contains("BR"))
                {
                    col_name = "DESCRIP_LARGA_BR";
                }

                if (clase.Contains("BD"))
                {
                    col_name = "DESCRIP_LARGA_BD";
                }

                if (clase.Contains("AN"))
                {
                    col_name = "DESCRIP_LARGA_AN";
                }

                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT T0.CUSER DESCRIPTION FROM UD_DATA T0 INNER JOIN UD_COLS T1 ON T1.ID = T0.UD_COLS_ID WHERE T0.PARENT_ID = " + idParent + " AND T1.COL_NAME = '" + col_name + "'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        description = dataReader["DESCRIPTION"].ToString();
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return description;
        }

        public string GetInfoEnglishDescription(string idParent, string clase, out string errorMethod)
        {
            string error = string.Empty;
            string description = string.Empty;
            string col_name = string.Empty;

            try
            {
                if (clase.Contains("SA"))
                {
                    col_name = "DESCRIP_INGLES_SA";
                }

                if (clase.Contains("NG"))
                {
                    col_name = "DESCRIP_INGLES_NG";
                }

                if (clase.Contains("PE"))
                {
                    col_name = "DESCRIP_INGLES_PE";
                }

                if (clase.Contains("BR"))
                {
                    col_name = "DESCRIP_INGLES_BR";
                }

                if (clase.Contains("BD"))
                {
                    col_name = "DESCRIP_INGLES_BD";
                }

                if (clase.Contains("AN"))
                {
                    col_name = "DESCRIP_INGLES_AN";
                }

                switchConexion(_BaseDatos);
                strCadenaSQL = "SELECT T0.CUSER DESCRIPTION FROM UD_DATA T0 INNER JOIN UD_COLS T1 ON T1.ID = T0.UD_COLS_ID WHERE T0.PARENT_ID = " + idParent + " AND T1.COL_NAME = '" + col_name + "'";
                dataReader = funConsultaSQL();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        description = dataReader["DESCRIPTION"].ToString();
                    }

                    dataReader.Close();
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
