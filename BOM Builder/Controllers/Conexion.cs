using BOM_Builder.Models;
using IQMS.Entities.Lib.Manufacturing;
//using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace BOM_Builder
{
    class Conexion
    {
        private static string conn = ConfigurationSettings.AppSettings.Get("connectionORACLE");

        #region GET

        public Partno getPartnoRow(string id)
        {
            Partno partno = new Partno();

            using (var conn = new OracleConnection(Conexion.conn))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT * FROM partno WHERE id=" + id + "";

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                partno.id = reader["ID"].ToString();
                                partno.standard_id = reader["STANDARD_ID"].ToString();
                                partno.arinvt = reader["ARINVT_ID"].ToString();
                                partno.stdcav = reader["STDCAV"].ToString();
                                partno.actcav = reader["ACTCAV"].ToString();
                                partno.ptwt = reader["PTWT"].ToString();
                                partno.ptwt_disp = reader["PTWT_DISP"].ToString();
                                partno.boxno = reader["BOXNO"].ToString();
                                partno.ptwt_thermo_disp = reader["PTWT_THERMO_DISP"].ToString();
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        string exe = e.ToString();
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }

            return partno;
        }

        public string getStandardIdFromMFG(string mfg)
        {
            string URL_GET_STANDARDID = string.Format("SELECT id FROM standard where mfgno = '{0}'", mfg);

            string standardId = select(URL_GET_STANDARDID, "id");

            return standardId;
        }

        public string GetCntrDescr(string mfgCell)
        {
            string GET_DESC = string.Format("SELECT CNTR_DESC FROM WORK_CENTER WHERE MFGCELL = '{0}'", mfgCell);

            return select(GET_DESC, "CNTR_DESC");
        }

        public string getMasterBOMFromMFG(string mfgno)
        {
            string URL_GET_STANDARDID = string.Format("SELECT id FROM standard where mfgno = 'MSTR-{0}'", mfgno);

            string standardId = select(URL_GET_STANDARDID, "id");

            return standardId;
        }

        public string getArtInvtFromStandard(string standardId)
        {
            string URL_GET_ARTINVT = string.Format("SELECT arinvt_id FROM partno WHERE standard_id = '{0}'", standardId);

            string arinvtId = select(URL_GET_ARTINVT, "arinvt_id");

            return arinvtId;
        }

        public double GetPesoTeorico(string itemno)
        {
            string conv_value = string.Empty;
            string QUERY = string.Format("SELECT conv_value FROM arinvt_uom_conv " +
                                         "INNER JOIN arinvt " +
                                         "ON arinvt_uom_conv.arinvt_id = arinvt.id " +
                                         "WHERE arinvt.itemno = '{0}' " +
                                         "AND arinvt_uom_conv.UOM = 'KG'", itemno);
            conv_value = select(QUERY, "conv_value");

            if (string.IsNullOrEmpty(conv_value))
                return 0;
            return Convert.ToDouble(conv_value);
        }

        public List<string> generalSelect(string query, string value)
        {
            List<string> data = new List<string>();

            using (var conn = new OracleConnection(Conexion.conn))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = query;

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                data.Add(reader[value].ToString());
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        string exe = e.ToString();
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }

            return data;
        }

        public string select(string query, string value)
        {
            string data = "";

            using (var conn = new OracleConnection(Conexion.conn))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = query;

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                data = reader[value].ToString();
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        string exe = e.ToString();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return data;
        }

        public NM_ComponentesModel GetComponente(string itemno)
        {
            string query = string.Format("SELECT * FROM ARINVT WHERE ITEMNO = '{0}'", itemno);
            NM_ComponentesModel componente = new NM_ComponentesModel();

            using (var conn = new OracleConnection(Conexion.conn))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                componente.Id_Arinvt = reader["ID"].ToString();
                                componente.Codigo = reader["ITEMNO"].ToString();
                                componente.Acabado = reader["CLASS"].ToString();
                                componente.Class = reader["CLASS"].ToString();
                                componente.Nombre_Componente = reader["DESCRIP"].ToString();
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        string exe = e.ToString();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return componente;
        }

        public string getArinvtIdFromMFG(string itemno)
        {
            string URL_GET_ARINVTID = string.Format("SELECT id FROM arinvt WHERE itemno = '{0}'", itemno);

            string id = select(URL_GET_ARINVTID, "id");

            return id;
        }

        public string GetArinvtFromCuser(string itemno,string serialize,string clase)
        {
            string GET = string.Format("SELECT ID FROM ARINVT WHERE ITEMNO = '{0}' AND CUSER1 = '{1}' " +
                                       "AND CLASS = '{2}'",itemno, serialize,clase);

            return select(GET, "ID");
        }

        public Standard GetStandardFather(string standard_id)
        {
            Standard standard = new Standard();
            using (var conn = new OracleConnection(Conexion.conn))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = string.Format("SELECT * FROM STANDARD WHERE ID = {0}", standard_id);

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["SETS"] != DBNull.Value)
                                    standard.SETS = Convert.ToInt32(reader["SETS"]);
                                else
                                    standard.SETS = 0;
                                if (reader["SETS_DISP"] != DBNull.Value)
                                    standard.SETS_DISP = Convert.ToInt32(reader["SETS_DISP"]);
                                else
                                    standard.SETS_DISP = 0;
                                if (reader["CYCLETM"] != DBNull.Value)
                                    standard.CYCLETM = Convert.ToInt32(reader["CYCLETM"]);
                                else
                                    standard.CYCLETM = 0;
                                if (reader["CYCLETM_DISP"] != DBNull.Value)
                                    standard.CYCLETM_DISP = Convert.ToInt32(reader["CYCLETM_DISP"]);
                                else
                                    standard.CYCLETM_DISP = 0;
                                if (reader["CYCLE"] != DBNull.Value)
                                    standard.CYCLE = Convert.ToInt32(reader["CYCLE"]);
                                else
                                    standard.CYCLE = 0;
                                if (reader["EPLANT_ID"] != DBNull.Value)
                                    standard.EPLANT_ID = Convert.ToInt32(reader["EPLANT_ID"]);
                                else
                                    standard.EPLANT_ID = 0;
                                if (reader["CNTR_TYPE"] != DBNull.Value)
                                    standard.CNTR_TYPE = reader["CNTR_TYPE"].ToString();
                                else
                                    standard.CNTR_TYPE = string.Empty;
                                if (reader["MFGCELL_ID"] != DBNull.Value)
                                    standard.MFGCELL_ID = Convert.ToInt32(reader["MFGCELL_ID"]);
                                else
                                    standard.MFGCELL_ID = 0;
                                if (reader["MFGCELL"] != DBNull.Value)
                                    standard.MFGCELL = reader["MFGCELL"].ToString();
                                else
                                    standard.MFGCELL = string.Empty;
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        string exe = e.ToString();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return standard;
        }

        public string GetStandardFromPartNo(string id)
        {
            string GET_STANDARD = string.Format("SELECT standard_id FROM partno WHERE Id = '{0}'", id);

            return select(GET_STANDARD, "standard_id");
        }

        public string GetSecuenceOpmat(string sndop_id)
        {
            string GET = string.Format("SELECT SEQ FROM OPMAT WHERE SNDOP_ID = {0}", sndop_id);

            return select(GET, "SEQ");
        }
        public BillOfMaterialsEx GetBOMEx(string standardId)
        {
            BillOfMaterialsEx bom = new BillOfMaterialsEx();
            long standardID = 0;
            standardID = Convert.ToInt64(standardId);
            string query = string.Format("SELECT * FROM standard WHERE id='{0}'", standardId);
            bom.StandardId = Convert.ToInt32(standardId);

            using (var conn = new OracleConnection(Conexion.conn))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = query;

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bom.Description = reader["DESCRIP"].ToString();
                                bom.CycleTime = Convert.ToDecimal(reader["CYCLETM"]);
                                bom.MfgType = reader["MFG_TYPE"].ToString();
                                bom.MfgCell = reader["MFGCELL"].ToString();
                                bom.CenterType = reader["CNTR_TYPE"].ToString();
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        string exe = e.ToString();
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return bom;
        }

        public NM_ComponentesModel GetComponenteIQMS(string itemno)
        {
            string query = string.Format("SELECT * FROM arinvt WHERE Codigo = '{0}'", itemno);
            NM_ComponentesModel componente = new NM_ComponentesModel();

            using (var connection = new OracleConnection(conn))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = query;
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                componente.Id_Arinvt = reader["ID"].ToString();
                                //componente.Id_Arinvt = reader["Id_Arinvt"].ToString();
                                componente.Codigo = reader["ITEMNO"].ToString();
                                //componente.Acabado = reader["Acabado"].ToString();
                                componente.Class = reader["Class"].ToString();
                                componente.Nombre_Componente = reader["DESCRIP"].ToString();
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        string exe = e.ToString();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return componente;
        }
        public bool ExecuteQuery(string query)
        {
            using (var conn = new OracleConnection(Conexion.conn))
            {
                using (var cmd = new OracleCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        string exe = e.ToString();
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return true;
        }

        public string GetRevArinvt(string arinvt_id)
        {
            string GET = string.Format("SELECT REV FROM ARINVT WHERE ID = {0}", arinvt_id);

            return select(GET, "REV");
        }

        public ArinvtModel GetArinvtById(string arinvt_id)
        {
            ArinvtModel arinvt = new ArinvtModel();

            using (var conn = new OracleConnection(Conexion.conn))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = string.Format("SELECT * FROM arinvt WHERE Id = {0}", arinvt_id);

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                arinvt.Id = Convert.ToInt32(reader["ID"]);
                                if (reader["CLASS"] != DBNull.Value)
                                    arinvt.Class = reader["CLASS"].ToString();
                                else
                                    arinvt.Class = string.Empty;
                                if (reader["ITEMNO"] != DBNull.Value)
                                    arinvt.Itemno = reader["ITEMNO"].ToString();
                                else
                                    arinvt.Itemno = string.Empty;
                                if (reader["DESCRIP"] != DBNull.Value)
                                    arinvt.Descrip1 = reader["DESCRIP"].ToString();
                                else
                                    arinvt.Descrip1 = string.Empty;
                                if (reader["DESCRIP2"] != DBNull.Value)
                                    arinvt.Descrip2 = reader["DESCRIP2"].ToString();
                                else
                                    arinvt.Descrip2 = string.Empty;
                                if (reader["UNIT"] != DBNull.Value)
                                    arinvt.Unit = reader["UNIT"].ToString();
                                else
                                    arinvt.Unit = string.Empty;
                                if (reader["STANDARD_ID"] != DBNull.Value)
                                    arinvt.Standard_Id = Convert.ToInt32(reader["STANDARD_ID"].ToString());
                                else
                                    arinvt.Standard_Id = 0;
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        string exe = e.ToString();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return arinvt;
        }

        public string GetPartno(string arinvt_id, string standard_id)
        {
            string GET_PARTNO = string.Format("SELECT ID FROM PARTNO WHERE STANDARD_ID = {0} AND ARINVT_ID = {1}", standard_id, arinvt_id);

            return select(GET_PARTNO, "ID");
        }
        public List<LegacyNewBoms> GetLegacy()
        {
            List<LegacyNewBoms> legacyList = new List<LegacyNewBoms>();
            LegacyNewBoms legacy;

            using (var conn = new OracleConnection(Conexion.conn))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = string.Format("SELECT * FROM LEGACY_NEW_BOMS");

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                legacy = new LegacyNewBoms();
                                legacy.Id = Convert.ToInt32(reader["Id"]);
                                legacy.Itemno = reader["Itemno"].ToString();
                                legacy.Rev = reader["Rev"].ToString();
                                legacy.Descrip = reader["Descrip"].ToString();
                                if(reader["APPROVED"]!=DBNull.Value)
                                {
                                    if(Convert.ToInt32(reader["APPROVED"])==1)
                                    {
                                        legacy.Approved = true;
                                    }
                                    else
                                    {
                                        legacy.Approved = false;
                                    }
                                }
                                else
                                {
                                    legacy.Approved = false;
                                }
                                legacyList.Add(legacy);
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        string exe = e.ToString();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return legacyList;
        }
        
        public string GetEqno(string mfg_cell)
        {
            string GET = string.Format("SELECT EQNO FROM WORK_CENTER WHERE MFGCELL = '{0}'", mfg_cell);

            return select(GET, "EQNO");
        }

        #endregion

        #region INSERT

        public bool insertBomRev(string rev, string standard_id)
        {
            string queryUpdateRev = string.Format("UPDATE standard SET route_seq = '{0}' WHERE id='{1}'", rev, standard_id);

            return insert(queryUpdateRev);
        }

        public bool insert(string queryInsert)
        {
            using (var conn = new OracleConnection(Conexion.conn))
            {
                string insert = queryInsert;

                using (var cmd = new OracleCommand(insert, conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        string exe = e.ToString();
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return true;
        }

        public bool InsertLooseWeight(string value, string arinvt_id)
        {
            string QUERY = string.Format("UPDATE arinvt SET LOOSE_WEIGHT = '{0}' WHERE id = '{1}'", value, arinvt_id);

            return ExecuteQuery(QUERY);
        }

        public string InsertBom(BillOfMaterials bom)
        {
            string INSERT = string.Format("INSERT INTO STANDARD(MFGNO,MFG_TYPE,TIMESTAMP) " +
                                          "VALUES('{0}','{1}',SYSDATE) RETURNING id INTO :id", bom.MfgNo, bom.MfgType);

            return InsertReturnId(INSERT);
        }

        public string InsertArinvt(InventoryItem art)
        {
            string INSERT = string.Format("INSERT INTO ARINVT(CLASS,ITEMNO,REV,DESCRIP,UNIT,STANDARD_ID) " +
                                          "VALUES('{0}','{1}','{2}','{3}','{4}','{5}') RETURNING id INTO :id", 
                                          art.InventoryClass,art.ItemNumber,art.Rev,art.Description,art.Unit,art.StandardId);

            return InsertReturnId(INSERT);
        }

        public string InsertPartno(BomPart partno)
        {
            string INSERT = string.Format("INSERT INTO PARTNO(STANDARD_ID,ARINVT_ID,STDCAV,ACTCAV)" +
                                          " VALUES('{0}','{1}','{2}','{3}') RETURNING id INTO :id", partno.StandardId,partno.ArInvtId,"1","1");

            return InsertReturnId(INSERT);
        }
        public string InsertSndop()
        {
            string INSERT = "INSERT INTO SNDOP(OP_CLASS,OPDESC,EDATE_TIME,UOM) VALUES('IN','Attached Components',SYSDATE,'SEC') RETURNING id INTO :id";

            return InsertReturnId(INSERT);
        }
        public string InsertReturnId(string query)
        {
            string value = string.Empty;
            using (var conexion = new OracleConnection(conn))
            {
                using (var cmd = new OracleCommand(query, conexion))
                {
                    try
                    {
                        conexion.Open();
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = ":id",
                            //OracleDbType = OracleDbType.Int32,
                            OracleType = OracleType.Int32,
                            Direction = ParameterDirection.Output
                        });
                        cmd.ExecuteNonQuery();
                        value = cmd.Parameters[":id"].Value.ToString();
                    }
                    catch (SqlException ex)
                    {

                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }

            return value;
        }

        public void InsertComponentToPart(string sndop_id,string arinvt_id, string standard_id,int partsper)
        {
            string seq = GetSecuenceOpmat(sndop_id);

            string INSERT = string.Format("INSERT INTO OPMAT(SNDOP_ID,ARINVT_ID,STANDARD_ID,PTSPER,EDATE_TIME,SEQ,UNIT,UNIT_NATIVE) " +
                                          "VALUES({0},{1},{2},{3},{4},SYSDATE,'PZA','PZA')",sndop_id,arinvt_id,standard_id,partsper,seq);

            ExecuteQuery(INSERT);
        }

        public string InsertComponentToPart(string sndop_id, string arinvt_id, string unit, string standard_id, double partsper)
        {
            string seq = GetSecuenceOpmat(sndop_id);

            if (string.Equals(seq, ""))
            {
                seq = "1";
            }
            else
            {
                seq = (Convert.ToInt32(seq) + 1).ToString();
            }

            string INSERT = string.Format("INSERT INTO OPMAT(SNDOP_ID,ARINVT_ID,PTSPER,SEQ,EDATE_TIME,UNIT,UNIT_NATIVE,PTSPER_DISP) " +
                                          "VALUES({0},{1},{2},{3},SYSDATE,'{4}','{4}',{3}) RETURNING id INTO :id", sndop_id, arinvt_id, partsper, seq, unit, partsper);

            return InsertReturnId(INSERT);
        }
        #endregion

        #region UPDATE

        public bool updateMfCell(string mfgcell, string standard_id)
        {
            string queryUpdateMFCell = string.Empty;
            string idMfgCell = string.Empty;

            idMfgCell = select("SELECT ID FROM mfgcell WHERE mfgcell = '" + mfgcell + "'", "Id");
            queryUpdateMFCell = string.Format("UPDATE STANDARD SET MFGCELL = '{0}', MFGCELL_ID = {1}, SETS = 1, SETS_DISP = 1 WHERE id = '{2}'", mfgcell, idMfgCell, standard_id);

            return insert(queryUpdateMFCell);
        }

        public bool updateCntrType(string cntr_type, string standard_id)
        {
            string queryUpdateMFCell = string.Format("UPDATE standard SET cntr_type = '{0}' WHERE id='{1}'", cntr_type, standard_id);

            return insert(queryUpdateMFCell);
        }

        public bool UpdateIdBomArticle(string idStandardId, string idItemMaster)
        {
            string query = string.Empty;
            query = "UPDATE ARINVT SET standard_id = '" + idStandardId + "' WHERE id = '" + idItemMaster + "'";
            return insert(query);
        }

        public bool UpdateNoSalable(string idArinvt)
        {
            string UPDATE_NOSALABLE = string.Format("UPDATE arinvt SET NON_SALABLE = 'Y', USE_THIS_UOM_FOR_MRP = 'Y' " +
                                                    "WHERE id = '{0}'", idArinvt);

            return ExecuteQuery(UPDATE_NOSALABLE);
        }

        public bool UpdateRunBest(string bom_id, string workcenter_id)
        {
            string UPDATE_RUNBEST = string.Format("UPDATE RUNS_BEST SET WORK_CENTER_ID_ACT = '{0}' WHERE standard_id = '{1}'", workcenter_id, bom_id);

            return ExecuteQuery(UPDATE_RUNBEST);
        }

        public bool UpdateBom(BillOfMaterials bom)
        {
            string UPDATE = string.Format("UPDATE STANDARD SET DESCRIP = '{0}', CYCLETM = '{1}', EPLANT_ID = '{2}', MFGNO = '{3}', CYCLETM_DISP = '{1}'," +
                                          "SETS = 1, SETS_DISP = 1 " +
                                          "WHERE ID = '{4}'",bom.Description,bom.CycleTime,bom.EPlantId,bom.MfgNo,bom.StandardId);

            return ExecuteQuery(UPDATE);
        }

        public bool UpdateSndop(string sndop_id)
        {
            string UPDATE = string.Format("UPDATE SNDOP SET OPNO = {0}, EPLANT_ID = 13 WHERE ID = {0}", sndop_id);

            return ExecuteQuery(UPDATE);
        }

        public void InsertPtoper(string partno_id, string sndop_id)
        {
            string INSERT = string.Format("INSERT INTO PTOPER (partno_id,sndop_id,opseq,uom) " +
                                          "VALUES({0},{1},1,'SEC')", partno_id, sndop_id);

            ExecuteQuery(INSERT);
        }

        public bool UpdateOpmatPartsper(string opmat_id, string partsper)
        {
            string UPDATE = string.Format("UPDATE OPMAT SET PTSPER = {0}, PTSPER_DISP = {0} WHERE ID = {1}", partsper, opmat_id);

            return ExecuteQuery(UPDATE);
        }

        public bool UpdateStandardChild(string standard_id, Standard standard)
        {
            string UPDATE = string.Format("UPDATE STANDARD SET SETS = 1, SETS_DISP = 1, CYCLETM = 5, CYCLETM_DISP = 5," +
                                                    "CYCLE = 720, EPLANT_ID = 13, CNTR_TYPE='{0}', MFGCELL_ID = {1}, MFGCELL = '{2}' " +
                                                    "WHERE ID = {3}",
                                                    standard.CNTR_TYPE, standard.MFGCELL_ID, standard.MFGCELL, standard_id);
            return ExecuteQuery(UPDATE);
        }

        public void UpdateEplantArinvt(string id)
        {
            string UPDATE = string.Format("UPDATE arinvt SET EPLANT_ID = 13 WHERE Id = {0}", id);
            ExecuteQuery(UPDATE);
        }

        public void UpdateLegacy(List<LegacyNewBoms> legacyList)
        {
            string UPDATE = string.Empty;
            int app = 0;

            foreach(var leg in legacyList)
            {
                if(leg.Approved==true)
                {
                    app = 1;
                }

                UPDATE = string.Format("UPDATE LEGACY_NEW_BOMS SET APPROVED = '{0}' WHERE ID={1}", app,leg.Id);
                ExecuteQuery(UPDATE);
            }
        }
        public void UpdateLegacy(List<NM_CombinacionesModel> boms)
        {
            string UPDATE = string.Empty;
            int app = 0;

            foreach (var bom in boms)
            {
                if (bom.Approved == true)
                {
                    app = 1;
                }
                UPDATE = string.Format("UPDATE LEGACY_NEW_BOMS SET APPROVED = '{0}' WHERE ITEMNO='{1}'", app, bom.Combinacion);
                ExecuteQuery(UPDATE);
            }
        }

        public void UpdateLegacy(List<string> boms)
        {
            string UPDATE = string.Empty;

            foreach (var bom in boms)
            {
                UPDATE = string.Format("UPDATE LEGACY_NEW_BOMS SET APPROVED = '1' WHERE ITEMNO='{1}'", bom);
                ExecuteQuery(UPDATE);
            }
        }

        public void UpdatePhantom(List<NM_CombinacionesModel> boms)
        {
            string UPDATE = string.Empty;
            string app = string.Empty;

            foreach (var bom in boms)
            {
                if (bom.Phantom == true)
                {
                    app = "1";
                }
                UPDATE = string.Format("UPDATE LEGACY_NEW_BOMS SET PHANTOM = '{0}' WHERE ITEMNO='{1}'", app, bom.Combinacion);
                ExecuteQuery(UPDATE);
            }
        }

        public void UpdatePhantom(string data, string arinvt_id)
        {
            string UPDATE = string.Format("UPDATE ARINVT SET PHANTOM = '{0}' " +
                "WHERE ID = '{1}'", data,arinvt_id);

            ExecuteQuery(UPDATE);
        }

        public void UpdatePhantom(List<string> boms)
        {
            string UPDATE = string.Empty;

            foreach(var bom in boms)
            {
                UPDATE = string.Format("UPDATE ARINVT SET PHANTOM = '1' " +
                "WHERE ID = '{1}'", bom);
                ExecuteQuery(UPDATE);
            }
            
        }

        #endregion

        #region CHECK

        public bool checkBom(string arinvt_id)
        {
            string GET = string.Format("SELECT standard_id FROM PARTNO WHERE arinvt_id = '{0}'", arinvt_id);
            string GET_PK_HIDE = string.Empty;
            List<string> boms = generalSelect(GET, "standard_id");
            string pk_hide = string.Empty;

            if(boms.Count==0)
            {
                return false;
            }

            foreach(var bom in boms)
            {
                GET_PK_HIDE = string.Format("SELECT PK_HIDE FROM STANDARD WHERE ID = {0}", bom);
                pk_hide = select(GET_PK_HIDE, "PK_HIDE");
                if(pk_hide!="Y")
                {
                    return true;
                }
            }
            return false;
        }

        public bool validItemNo(string itemno, string revision, string classes)
        {
            string URL_GET_ITEMNO = string.Format("SELECT itemno FROM arinvt WHERE itemno = '{0}' AND rev = '{1}' AND class = '{2}'", itemno, revision, classes);

            string item = select(URL_GET_ITEMNO, "itemno");

            if (!string.IsNullOrEmpty(item) && item != "")
            {
                return true;
            }

            return false;
        }

        public bool Valid_Bom_Exist(string pItemNo, out int pSeq)
        {
            string URL_GET_ITEMNO = string.Format("SELECT mfgno, route_seq FROM standard WHERE mfgno = '{0}'", pItemNo);

            string item = select(URL_GET_ITEMNO, "route_seq");

            if (!string.IsNullOrEmpty(item) && item != "")
            {
                pSeq = Convert.ToInt16(item);
                return true;
            }
            else
            {
                pSeq = 0;
                return false;
            }
        }

        #endregion

        #region METODOS SIN UTILIZAR

        public Arinvt GetArinvt(string itemno)
        {
            Arinvt arinvt = new Arinvt();
            string query = string.Format("SELECT * FROM arinvt WHERE itemno='{0}'", itemno);

            using (var conn = new OracleConnection(Conexion.conn))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = query;

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                arinvt.id = reader["id"].ToString();
                                arinvt.clase = reader["class"].ToString();
                                arinvt.itemno = reader["itemno"].ToString();
                                arinvt.descripcion = reader["descrip"].ToString();
                                arinvt.unit = reader["unit"].ToString();
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        string exe = e.ToString();
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return arinvt;
        }

        public void connect()
        {
            OracleConnection conexion = new OracleConnection(conn);
            conexion.Open();
            MessageBox.Show("Conexion establecida");
        }

        public string getIdStandar()
        {
            string test = "";

            using (var conn = new OracleConnection(Conexion.conn))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT * " + "FROM (SELECT * FROM standard order by ID DESC)" + "WHERE rownum = 1";

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                test = reader["ID"].ToString();
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        string exe = e.ToString();
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }

            return test;
        }

        //ARVINVT debe ser unico
        public void copyPartnoRow(string idPartno, string newIdParno)
        {
            Partno partno = getPartnoRow(idPartno);
            string queryInsert = "INSERT INTO partno (id,standard_id,arinvt_id,stdcav,actcav,ptwt,ptwt_disp,boxno,ptwt_thermo_disp) " + "VALUES(" + newIdParno + "," + partno.standard_id + "," + partno.arinvt + ",'" + partno.stdcav + "','" + partno.actcav +
               "'," + "'" + partno.ptwt + "','" + partno.ptwt_disp + "','" + partno.boxno + "','" + partno.ptwt_thermo_disp + "')";
            insert(queryInsert);
        }

        public List<string> getMasterBOM()
        {
            List<string> masterList = new List<string>();

            string query_get_master = "SELECT mfgno FROM standard WHERE mfgno like 'MSTR%'";

            using (var conn = new OracleConnection(Conexion.conn))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = query_get_master;

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                masterList.Add(reader["mfgno"].ToString());
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        string exe = e.ToString();
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }

            return masterList;
        }

        public List<string> getBOMS(string model)
        {
            List<string> boms = new List<string>();

            string queryGetBoms = "SELECT mfgno FROM standard where mfgno like '" + model + "%'";

            boms = generalSelect(queryGetBoms, "mfgno");

            return boms;
        }

        public string getMasterBOM(string model)
        {
            string bom = "";

            string queryGetBoms = string.Format("SELECT mfgno FROM standard where mfgno = MSTR-{0}6X6", model);

            bom = select(queryGetBoms, "mfgno");

            return bom;
        }

        public string getPartnoFromStandadID(string standard_id)
        {
            string partno = "";

            string queryGetPartno = string.Format("SELECT id FROM partno WHERE standard_id = {0}", standard_id);

            partno = select(queryGetPartno, "id");

            return partno;
        }

        public string getPerfilID(string perfil)
        {
            string id = "";

            string queryGetPerfilID = string.Format("SELECT id FROM arinvt WHERE itemno='{0}'", perfil);

            id = select(queryGetPerfilID, "id");

            return id;
        }

        #endregion
    }
}
