using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOM_Builder.DL;
using BOM_Builder.Models;
using IQMS.Entities.Lib.Manufacturing;

namespace BOM_Builder.Controllers
{
    public class AssemblyBomController
    {
        #region VARIABLES GLOBALES

        Conexion conexion = new Conexion();
        WebAPI webApi = new WebAPI();
        BomDL bomDl = new BomDL();
        GeneratorDL generatorDL = new GeneratorDL();
        const string TABLE_BOM = "STANDARD";
        string sndop_id = string.Empty;
        double fatherLooseWeight;
        string idItemFather = string.Empty;

        #endregion

        //public void .GetInformationBom(string baseName, ref List<ComponenteModel> dataListModel, string nameModel, int large, int width, int qty, int cycle, string mfg_cell, string finishes, string classes, out string errorMethod)
        public void GetInformationBom(string baseName, ref List<ComponenteModel> dataListModel, string nameModel, BomForm form, int cycle, string mfg_cell, string finishes, string classes, out string errorMethod)
        {
            string error = string.Empty;

            try
            {
                
                ReceiveInformationBom(baseName, ref dataListModel, nameModel, form, cycle, mfg_cell, finishes, classes, out error);

                conexion.InsertLooseWeight(fatherLooseWeight.ToString(), idItemFather);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
        }

        public void ReceiveInformationBom(string baseName, ref List<ComponenteModel> dataListModel, string nameModel, BomForm form,
                                          int cycle, string mfg_cell, string finishes, string classes, out string errorMethod)
        {
            string error = string.Empty;
            string revision = string.Empty;
            bool success = false;
            string id_item_father = string.Empty;
            string id_bom_fater = string.Empty;
            string serialize = string.Empty;
            string measure = string.Empty;
            bool exist = false;

            try
            {

                serialize = MakeSerialize(form);
                measure = GetMeasure(form);
                idItemFather = conexion.GetArinvtFromCuser(nameModel,serialize, classes);
                exist = conexion.checkBom(idItemFather);

                if(!exist)
                {
                    if (idItemFather == "")
                    {
                        idItemFather = "0";
                    }

                    if (Convert.ToInt32(idItemFather) > 0 && error == "")
                    {
                        CreateBomFather(baseName, ref dataListModel, nameModel, measure, cycle, mfg_cell, finishes, idItemFather, revision, classes, out error);
                    }
                    else
                    {
                        MessageBox.Show("El Item padre con esas medidas no ha sido encontrado en IQMS");
                    }
                }
                else
                {
                    MessageBox.Show("El BOM ya ha sido creado");
                }
                //}
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
        }

        //public void CreateItemFather(string baseName, ref List<ComponenteModel> dataListModel, string nameModel, string revision, int large, int width, int cycle, string mfg_cell, string finishes, string classes, out string errorMethod)
        //{
        //    InventoryItem master_item_father = new InventoryItem();
        //    //InventoryItemBase master_item_result = new InventoryItemBase();
        //    //ArinvtModel master_item_father = new ArinvtModel();
        //    string error = string.Empty;
        //    string description_base = string.Empty;
        //    string description_extend = string.Empty;
        //    string id_item_father = string.Empty;
        //    bool existArinvt = false;

        //    try
        //    {
        //        if (finishes != "AN")
        //        {
        //            description_base = nameModel + " " + large + width;
        //        }
        //        else
        //        {
        //            description_base = nameModel + " " + large + width + " " + finishes;
        //        }

        //        description_extend = " " + baseName + " " + revision;

        //        master_item_father.EplantId = 13;
        //        master_item_father.ItemNumber = nameModel;
        //        master_item_father.Description = description_extend;
        //        master_item_father.ExtDescription = description_base;
        //        master_item_father.Unit = "PZA";
        //        master_item_father.InactiveFlag = "N";
        //        master_item_father.InventoryClass = classes;
        //        master_item_father.Rev = revision;
        //        //master_item_result = webApi.createNewItemInv(master_item_father);
        //        //master_item_father.Class = classes;
        //        //master_item_father.Itemno = nameModel;
        //        //master_item_father.Descrip1 = description_extend;
        //        //master_item_father.Descrip2 = description_base;
        //        //master_item_father.Unit = "PZA";
        //        //master_item_father.Rev = revision;

        //        //if (master_item_result == null)
        //        if (conexion.validItemNo(master_item_father.ItemNumber, master_item_father.Rev, master_item_father.InventoryClass))
        //        {
        //            id_item_father = conexion.InsertArinvt(master_item_father);

        //            //id_item_father = bomDl.GetIdItemFather(nameModel, revision, classes, out error);

        //            if (Convert.ToInt32(id_item_father) > 0 && error == "")
        //            {
        //                //CreateBomFather(baseName, ref dataListModel, nameModel, large, width, cycle, mfg_cell, finishes, id_item_father, revision, classes, out error);
        //                idItemFather = id_item_father;
        //            }
        //            else
        //            {
        //                error = "Error al crear el articulo maestro, esto puede deberse a que la informacion sea incorrecta o el articulo ya ha sido creado.." + Environment.NewLine;
        //            }
        //        }
        //        else
        //        {
        //            idItemFather = bomDl.GetIdItemFather(nameModel, revision, classes, out error);
        //            //CreateBomFather(baseName, ref dataListModel, nameModel, large, width, cycle, mfg_cell, finishes, idItemFather, revision, classes, out error);
        //            //CreateBomFather(baseName, ref dataListModel, nameModel, large, width, cycle, mfg_cell, finishes, master_item_result.Id.ToString(), revision, classes, out error);
        //            //idItemFather = master_item_result.Id.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        error = ex.Message;
        //    }

        //    errorMethod = error;
        //}

        public void CreateBomFather(string baseName, ref List<ComponenteModel> dataListModel, string nameModel, string measure, 
                                    int cycle, string mfg_cell, string finishes, string idItemFather, string revisionGeneric,
                                    string classes, out string errorMethod)
        {
            BillOfMaterials master_bom = new BillOfMaterials();
            List<UdColsModel> id_ud_cols = new List<UdColsModel>();
            string error = string.Empty;
            string description = string.Empty;
            string user_description = string.Empty;
            string description_english = string.Empty;
            string id_table_ud = string.Empty;
            bool success = false;
            bool success_user_form = false;
            int sequences = 0;
            string revision = string.Empty;
            string eqno = string.Empty;
            string id_work_center = string.Empty;
            bool is_inserted_run_best = false;
            string id_bom_father = string.Empty;
            string id_item_father = string.Empty;
            string name_model_bom = string.Empty;

            try
            {
                name_model_bom = nameModel + " " + classes;
                success = conexion.Valid_Bom_Exist(name_model_bom, out sequences);

                if (!success)
                {
                    if (sequences != 0)
                    {
                        revision = "1";
                    }
                    else
                    {
                        sequences += 1;
                        revision = Convert.ToString(sequences);
                    }
                }
                else
                {
                    sequences += 1;
                    revision = Convert.ToString(sequences);
                }

                master_bom.MfgNo = name_model_bom;
                master_bom.MfgType = "GENERIC";
                master_bom.StandardId = Convert.ToInt32(conexion.InsertBom(master_bom));

                //master_bom = webApi.createNewBom("GENERIC", name_model_bom);

                //if (master_bom == null)
                if (master_bom.StandardId == 0)
                {
                    id_bom_father = bomDl.GetIdBomFather(nameModel, revision, out error);
                    error = "No se pudo generar el Bom:  " + nameModel + " " + Environment.NewLine;
                }
                else
                {
                    success = conexion.insertBomRev(revision, master_bom.StandardId.ToString());

                    if (success)
                    {
                        if (mfg_cell == "DP")
                        {
                            eqno = "DP-ENS";
                        }

                        if (mfg_cell == "RE")
                        {
                            eqno = "RE-ENS";
                        }

                        if (mfg_cell == "DC")
                        {
                            eqno = "DC-ENS";
                        }

                        if (mfg_cell == "FV")
                        {
                            eqno = "";
                        }

                        if (mfg_cell == "RL")
                        {
                            eqno = "";
                        }

                        if (mfg_cell == "CP")
                        {
                            eqno = "";
                        }

                        if (mfg_cell == "PZ")
                        {
                            eqno = "";
                        }

                        if (mfg_cell == "LI")
                        {
                            eqno = "";
                        }

                        if (mfg_cell == "LA")
                        {
                            eqno = "";
                        }

                        if (mfg_cell == "DL")
                        {
                            eqno = "";
                        }

                        if (mfg_cell == "PM")
                        {
                            eqno = "";
                        }

                        if (mfg_cell == "EB")
                        {
                            eqno = "";
                        }

                        if (mfg_cell == "SM")
                        {
                            eqno = "";
                        }

                        if (mfg_cell == "PI")
                        {
                            eqno = "";
                        }

                        if (mfg_cell == "PK")
                        {
                            eqno = "";
                        }

                        if (finishes != "AN")
                        {
                            description = baseName + " " + nameModel + " " + revisionGeneric + " " + classes;
                            master_bom.MfgNo = nameModel + " " + classes;
                        }
                        else
                        {
                            description = baseName + " " + nameModel + " " + revisionGeneric;
                            master_bom.MfgNo = nameModel + " " + finishes;
                        }


                        if (user_description == "")
                        {
                            user_description = "DESCRIPCION LARGA EN PROCESO DE GENERACIÓN";
                        }
                        else
                        {
                            user_description = user_description.Replace("MODULO", "DIFUSOR");
                        }

                        if (description_english == "")
                        {
                            description_english = "ENGLISH DESCRIPTION";
                        }
                        else
                        {
                            description_english = "ENGLISH DESCRIPTION";
                        }

                        master_bom.Description = description;
                        master_bom.CycleTime = cycle;
                        master_bom.EPlantId = 13;

                        //webApi.UpdateBOM(master_bom);
                        conexion.UpdateBom(master_bom);

                        /// Actualiza el center type
                        if (conexion.updateCntrType(mfg_cell, master_bom.StandardId.ToString()))
                        {
                            /// Actualiza el manfactura cell del BOM y agrega la eplant
                            if (conexion.updateMfCell(mfg_cell, master_bom.StandardId.ToString()))
                            {
                                /// Actualiza el Id del standard_id del articulo creado
                                if (conexion.UpdateIdBomArticle(master_bom.StandardId.ToString(), idItemFather))
                                {
                                    /// FALTA DEFINIR LOS CAMPOS EXTENDIDOS DE USUARIO
                                    id_table_ud = bomDl.Get_Id_Form_User(TABLE_BOM);

                                    if (id_table_ud != "0")
                                    {
                                        id_ud_cols = bomDl.Get_List_Id_Form_User(id_table_ud);

                                        if (id_ud_cols.Count != 0)
                                        {
                                            success_user_form = bomDl.Add_Descriptions(id_ud_cols, master_bom.StandardId.ToString(), user_description, description_english);
                                        }
                                    }

                                    success = true;
                                    error = string.Empty;
                                }
                                else
                                {
                                    error += "No se pudo asociar la Eplant al BOM creado.." + Environment.NewLine;
                                    success = false;
                                }
                            }
                            else
                            {
                                error += "No se pudo agregar el manufactura cell ni agregar la Eplant correspondiente.." + Environment.NewLine;
                                success = false;
                            }
                        }
                        else
                        {
                            error += "No se pudo actualizar el center type del BOM, creado.." + Environment.NewLine;
                            success = false;
                        }
                    }
                    else
                    {
                        error += "No se pudo crear el BOM padre." + Environment.NewLine;
                        success = false;
                    }

                    if (success && error == "")
                    {
                        /// Obtiene id del work center para funcionalidad del Run Best = DP-ENS
                        id_work_center = bomDl.GetIdWorkCenter(eqno, out error);

                        if (error == "")
                        {
                            is_inserted_run_best = bomDl.CreateRunBest(master_bom.StandardId.ToString(), id_work_center, out error);
                        }

                        CreateItemAssembly(ref dataListModel, master_bom.StandardId.ToString(), idItemFather, mfg_cell, finishes,
                                           classes, mfg_cell, measure, out error, id_work_center);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
        }

        public void CreateItemAssembly(ref List<ComponenteModel> dataListModel, string idBomFather, string idItemFather, string typeModel,
                                        string finishes, string classes, string mfg_cell, string measure, out string errorMethod, string workcenterId)
        {
            InventoryItem item_assembly = new InventoryItem();
            ArinvtModel arinvtRawMat = new ArinvtModel();
            InventoryItem item_assembly_childNew = new InventoryItem();
            InventoryItemBase child_item = new InventoryItemBase();
            BomPart master_bom_part = new BomPart();
            BomPart child_bom_part;
            ArinvtModel arinvt = new ArinvtModel();
            BillOfMaterials child_bom = new BillOfMaterials();
            Standard standardInfoFather = new Standard();
            string error = string.Empty;
            string id_arinvt = string.Empty;
            string id_bom = string.Empty;
            string clas = string.Empty;
            string childSndop_id = string.Empty;
            string auxStdChild = string.Empty;
            string auxPartnoChild = string.Empty;
            string opmatId_child = string.Empty;
            string rev = string.Empty;
            double totalPerfil = 0;
            string rawMat_id = string.Empty;

            double looseWeight;
            double pesoTeorico;

            try
            {
                master_bom_part.ArInvtId = Convert.ToInt64(idItemFather);
                master_bom_part.StandardId = Convert.ToInt64(idBomFather);
                master_bom_part.PartNoId = Convert.ToInt32(conexion.InsertPartno(master_bom_part));
                standardInfoFather = conexion.GetStandardFather(idBomFather);
                this.sndop_id = conexion.InsertSndop();
                conexion.UpdateSndop(this.sndop_id);
                conexion.InsertPtoper(master_bom_part.PartNoId.ToString(), this.sndop_id);

                //master_bom_part = webApi.AddPartToBOM(idItemFather, Convert.ToInt64(idBomFather));

                if (master_bom_part != null)
                {
                    foreach (var component in dataListModel)
                    {
                        if (component != null)
                        {
                            clas = component.Class;
                            id_arinvt = bomDl.GetIdItemArinvt(component.Numero_Parte, component.Class, out error);
                            if (string.IsNullOrEmpty(id_arinvt))
                                rev = string.Empty;
                            else
                                rev = conexion.GetRevArinvt(id_arinvt);

                            if (component.cantidad > 0 && !string.IsNullOrEmpty(id_arinvt))
                            {
                                //Agregar solo componente
                                //if (clas == "PC" || clas == "ST" || clas == "PL" || clas == "MP" || clas == "AL" || clas == "PP" || clas == "CS")
                                //&& (string.IsNullOrEmpty(rev) || string.IsNullOrWhiteSpace(rev))) 
                                // || clas == "CS" && rev.Contains("FRA")
                                //if(!((clas == "SE" || clas == "AN") || (clas == "ST" || clas == "PC" || clas == "AL")
                                //    &&(rev.Contains("PF") || rev.Contains("SE"))))
                                if(!rev.Contains("SE"))
                                {
                                    arinvt = conexion.GetArinvtById(id_arinvt);
                                    //webApi.AddComponentToPart(master_bom_part.PartNoId, Convert.ToInt32(id_arinvt), Convert.ToDecimal(component.cantidad));
                                    if (rev.Contains("FRA")) // || component.Numero_Parte.Contains("WIRE"))
                                    {
                                        component.cantidad = component.Peso_Kg;
                                    }
                                    opmatId_child = conexion.InsertComponentToPart(this.sndop_id, id_arinvt, arinvt.Unit, idBomFather, Convert.ToInt32(component.cantidad));
                                    conexion.UpdateOpmatPartsper(opmatId_child, component.cantidad.ToString());

                                }
                                //Hace Subensamble
                                //else if ((clas == "SE" || clas == "AN") ||
                                //         ((clas == "ST" || clas == "PC" || clas == "AL") && (rev.Contains("PF") || rev.Contains("SE")) && component.cantidad > 0))
                                else
                                {
                                    child_bom_part = new BomPart();
                                    child_bom.MfgNo = component.Numero_Parte + "-" + component.medida.ToString();//component.medida.ToString("N4");
                                    child_bom.MfgType = "GENERIC";


                                    auxStdChild = conexion.getStandardIdFromMFG(child_bom.MfgNo);

                                    if (string.IsNullOrEmpty(auxStdChild))
                                    {
                                        child_bom_part.StandardId = Convert.ToInt32(conexion.InsertBom(child_bom));
                                        conexion.UpdateStandardChild(child_bom_part.StandardId.ToString(), standardInfoFather);
                                    }
                                    else
                                    {
                                        child_bom_part.StandardId = Convert.ToInt32(auxStdChild);
                                    }

                                    item_assembly = new InventoryItem();
                                    item_assembly.StandardId = Convert.ToInt32(child_bom_part.StandardId);
                                    item_assembly.InventoryClass = "SE";
                                    item_assembly.ItemNumber = component.Numero_Parte + "-" + component.medida.ToString("N4");
                                    item_assembly.Description = "TRAMO " + component.Numero_Parte + "-" + component.medida.ToString("N4") + " PULG";
                                    item_assembly.InactiveFlag = "N";
                                    item_assembly.Unit = "PZA";
                                    item_assembly.EplantId = 13;
                                    item_assembly.Rev = measure;
                                    //child_item = webApi.createNewItemInv(item_assembly);
                                    id_arinvt = conexion.getArinvtIdFromMFG(item_assembly.ItemNumber);
                                    if (id_arinvt == "")
                                    {

                                        child_item.Id = Convert.ToInt32(conexion.InsertArinvt(item_assembly));
                                    }
                                    else
                                        child_item.Id = Convert.ToInt64(id_arinvt);

                                    if (child_item.Id > 0)
                                    {
                                        conexion.UpdateEplantArinvt(child_item.Id.ToString());
                                        //id_arinvt = conexion.getArinvtIdFromMFG(component.Numero_Parte + "-" + component.Medida.ToString("N4"));
                                        arinvt = conexion.GetArinvtById(child_item.Id.ToString());

                                        child_bom_part.ArInvtId = Convert.ToInt64(child_item.Id);
                                        auxPartnoChild = conexion.GetPartno(child_bom_part.ArInvtId.ToString(), child_bom_part.StandardId.ToString());
                                        if (string.IsNullOrEmpty(auxPartnoChild))
                                        {
                                            child_bom_part.PartNoId = Convert.ToInt32(conexion.InsertPartno(child_bom_part));
                                            childSndop_id = conexion.InsertSndop();
                                            conexion.UpdateSndop(childSndop_id);
                                            conexion.InsertPtoper(child_bom_part.PartNoId.ToString(), childSndop_id);
                                        }

                                        if (Convert.ToInt64(child_item.Id) > 0)
                                        {
                                            //webApi.AddComponentToPart(master_bom_part.PartNoId, Convert.ToInt32(id_arinvt), Convert.ToDecimal(component.cantidad));
                                            opmatId_child = conexion.InsertComponentToPart(this.sndop_id, arinvt.Id.ToString(), arinvt.Unit, idBomFather, Convert.ToInt32(component.cantidad));
                                            conexion.UpdateOpmatPartsper(opmatId_child, component.cantidad.ToString());
                                            conexion.UpdateStandardChild(child_bom_part.StandardId.ToString(), standardInfoFather);

                                            if (string.IsNullOrEmpty(childSndop_id))
                                            {
                                                childSndop_id = conexion.InsertSndop();
                                                conexion.UpdateSndop(childSndop_id);
                                            }
                                            totalPerfil = Convert.ToDouble(component.total_perfil) / Convert.ToInt32(component.cantidad);
                                            component.Arinvt = conexion.getArinvtIdFromMFG(component.Numero_Parte);

                                            if (string.IsNullOrEmpty(component.Arinvt))
                                            {

                                                item_assembly_childNew = new InventoryItem();
                                                item_assembly_childNew.InventoryClass = "SE";
                                                item_assembly_childNew.ItemNumber = component.Numero_Parte;
                                                item_assembly_childNew.Description = "TRAMO " + component.Numero_Parte + "-" + component.medida.ToString("N4") + " PULG";
                                                item_assembly_childNew.InactiveFlag = "N";
                                                item_assembly_childNew.Unit = "PZA";//arinvt.Unit;
                                                item_assembly_childNew.EplantId = 13;
                                                component.Arinvt = conexion.InsertArinvt(item_assembly_childNew);
                                            }
                                            rawMat_id = conexion.getArinvtIdFromMFG(component.Numero_Parte);
                                            arinvtRawMat = conexion.GetArinvtById(rawMat_id);
                                            try
                                            {
                                                opmatId_child = conexion.InsertComponentToPart(childSndop_id, component.Arinvt, arinvt.Unit, child_bom_part.StandardId.ToString(), totalPerfil);
                                            }
                                            catch (Exception ex)
                                            {
                                                opmatId_child = conexion.InsertComponentToPart(childSndop_id, component.Arinvt, "KG", child_bom_part.StandardId.ToString(), totalPerfil);
                                            }

                                            conexion.UpdateOpmatPartsper(opmatId_child, totalPerfil.ToString());

                                            conexion.UpdateNoSalable(arinvt.Id.ToString());
                                            pesoTeorico = conexion.GetPesoTeorico(component.Numero_Parte);
                                            if (!string.IsNullOrEmpty(pesoTeorico.ToString())
                                                || !string.IsNullOrWhiteSpace(pesoTeorico.ToString()))
                                            {
                                                looseWeight = (component.total_perfil * pesoTeorico) * component.cantidad;
                                                conexion.InsertLooseWeight(looseWeight.ToString(), arinvt.Id.ToString());
                                                fatherLooseWeight += looseWeight;
                                            }
                                            if (!string.IsNullOrEmpty(workcenterId))
                                                bomDl.CreateRunBest(child_bom_part.StandardId.ToString(), workcenterId, out error);
                                            if(!string.IsNullOrEmpty(child_item.Id.ToString()))
                                                conexion.UpdatePhantom("Y", child_item.Id.ToString());
                                        }
                                        childSndop_id = string.Empty;

                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                error = "Se produjo un error al intentar crear el articulo del ensamble. Especificamente en: ." + Environment.NewLine;
                error += ex.Message;
            }

            errorMethod = error;
        }

        //public void CreateBomFather(string baseName, ref List<ComponenteModel> dataListModel, string nameModel, BomForm form, int cycle, string mfg_cell, string finishes, string idItemFather, string revisionGeneric, string classes, out string errorMethod)
        //{
        //    BillOfMaterials master_bom = new BillOfMaterials();
        //    List<UdColsModel> id_ud_cols = new List<UdColsModel>();
        //    string error = string.Empty;
        //    string description = string.Empty;
        //    string user_description = string.Empty;
        //    string description_english = string.Empty;
        //    string id_table_ud = string.Empty;
        //    bool success = false;
        //    bool success_user_form = false;
        //    int sequences = 0;
        //    string revision = string.Empty;
        //    string eqno = string.Empty;
        //    string id_work_center = string.Empty;
        //    bool is_inserted_run_best = false;
        //    string id_bom_father = string.Empty;
        //    string id_item_father = string.Empty;
        //    string name_model_bom = string.Empty;

        //    try
        //    {
        //        name_model_bom = nameModel + " " + classes;
        //        success = conexion.Valid_Bom_Exist(name_model_bom, out sequences);

        //        if (!success)
        //        {
        //            if (sequences != 0)
        //            {
        //                revision = "1";
        //            }
        //            else
        //            {
        //                sequences += 1;
        //                revision = Convert.ToString(sequences);
        //            }
        //        }
        //        else
        //        {
        //            sequences += 1;
        //            revision = Convert.ToString(sequences);
        //        }

        //        master_bom.MfgNo = name_model_bom;
        //        master_bom.MfgType = "GENERIC";
        //        master_bom.StandardId = Convert.ToInt32(conexion.InsertBom(master_bom));

        //        //master_bom = webApi.createNewBom("GENERIC", name_model_bom);

        //        //if (master_bom == null)
        //        if(master_bom.StandardId>0)
        //        {
        //            id_bom_father = bomDl.GetIdBomFather(nameModel, revision, out error);
        //            error = "No se pudo generar el Bom:  " + nameModel + " " + Environment.NewLine;
        //        }
        //        else
        //        {
        //            success = conexion.insertBomRev(revision, master_bom.StandardId.ToString());

        //            if (success)
        //            {
        //                if (mfg_cell == "DP")
        //                {
        //                    eqno = "DP-ENS";
        //                }

        //                if (mfg_cell == "RE")
        //                {
        //                    eqno = "RE-ENS";
        //                }

        //                if (mfg_cell == "DC")
        //                {
        //                    eqno = "DC-ENS";
        //                }

        //                if (mfg_cell == "FV")
        //                {
        //                    eqno = "";
        //                }

        //                if (mfg_cell == "RL")
        //                {
        //                    eqno = "";
        //                }

        //                if (mfg_cell == "CP")
        //                {
        //                    eqno = "";
        //                }

        //                if (mfg_cell == "PZ")
        //                {
        //                    eqno = "";
        //                }

        //                if (mfg_cell == "LI")
        //                {
        //                    eqno = "";
        //                }

        //                if (mfg_cell == "LA")
        //                {
        //                    eqno = "";
        //                }

        //                if (mfg_cell == "DL")
        //                {
        //                    eqno = "";
        //                }

        //                if (mfg_cell == "PM")
        //                {
        //                    eqno = "";
        //                }

        //                if (mfg_cell == "EB")
        //                {
        //                    eqno = "";
        //                }

        //                if (mfg_cell == "SM")
        //                {
        //                    eqno = "";
        //                }

        //                if (mfg_cell == "PI")
        //                {
        //                    eqno = "";
        //                }

        //                if (mfg_cell == "PK")
        //                {
        //                    eqno = "";
        //                }

        //                if (finishes != "AN")
        //                {
        //                    description = baseName + " " + nameModel + " " + revisionGeneric + " " + classes;
        //                    master_bom.MfgNo = nameModel + " " + classes;
        //                }
        //                else
        //                {
        //                    description = baseName + " " + nameModel + " " + revisionGeneric;
        //                    master_bom.MfgNo = nameModel + " " + finishes;
        //                }

        //                user_description = bomDl.GetInfoLargeDescription(idItemFather, classes, out error);
        //                description_english = bomDl.GetInfoEnglishDescription(idItemFather, classes, out error);

        //                if (user_description == "")
        //                {
        //                    user_description = "DESCRIPCION LARGA EN PROCESO DE GENERACIÓN";
        //                }
        //                else
        //                {
        //                    user_description = user_description.Replace("MODULO", "DIFUSOR");
        //                }

        //                if (description_english == "")
        //                {
        //                    description_english = "ENGLISH DESCRIPTION";
        //                }
        //                else
        //                {
        //                    description_english = "ENGLISH DESCRIPTION";
        //                }

        //                master_bom.Description = description;
        //                master_bom.CycleTime = cycle;
        //                master_bom.EPlantId = 13;

        //                //webApi.UpdateBOM(master_bom);
        //                conexion.UpdateBom(master_bom);

        //                /// Actualiza el center type
        //                if (conexion.updateCntrType(mfg_cell, master_bom.StandardId.ToString()))
        //                {
        //                    /// Actualiza el manfactura cell del BOM y agrega la eplant
        //                    if (conexion.updateMfCell(mfg_cell, master_bom.StandardId.ToString()))
        //                    {
        //                        /// Actualiza el Id del standard_id del articulo creado
        //                        if (conexion.UpdateIdBomArticle(master_bom.StandardId.ToString(), idItemFather))
        //                        {
        //                            /// FALTA DEFINIR LOS CAMPOS EXTENDIDOS DE USUARIO
        //                            id_table_ud = bomDl.Get_Id_Form_User(TABLE_BOM);

        //                            if (id_table_ud != "0")
        //                            {
        //                                id_ud_cols = bomDl.Get_List_Id_Form_User(id_table_ud);

        //                                if (id_ud_cols.Count != 0)
        //                                {
        //                                    success_user_form = bomDl.Add_Descriptions(id_ud_cols, master_bom.StandardId.ToString(), user_description, description_english);
        //                                }
        //                            }

        //                            success = true;
        //                            error = string.Empty;
        //                        }
        //                        else
        //                        {
        //                            error += "No se pudo asociar la Eplant al BOM creado.." + Environment.NewLine;
        //                            success = false;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        error += "No se pudo agregar el manufactura cell ni agregar la Eplant correspondiente.." + Environment.NewLine;
        //                        success = false;
        //                    }
        //                }
        //                else
        //                {
        //                    error += "No se pudo actualizar el center type del BOM, creado.." + Environment.NewLine;
        //                    success = false;
        //                }
        //            }
        //            else
        //            {
        //                error += "No se pudo crear el BOM padre." + Environment.NewLine;
        //                success = false;
        //            }

        //            if (success && error == "")
        //            {
        //                /// Obtiene id del work center para funcionalidad del Run Best = DP-ENS
        //                id_work_center = bomDl.GetIdWorkCenter(eqno, out error);

        //                if (error == "")
        //                {
        //                    is_inserted_run_best = bomDl.CreateRunBest(master_bom.StandardId.ToString(), id_work_center, out error);
        //                }

        //                CreateItemAssembly(ref dataListModel, master_bom.StandardId.ToString(), idItemFather, mfg_cell, finishes, classes, mfg_cell, out error);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        error = ex.Message;
        //    }

        //    errorMethod = error;
        //}

        //public void CreateItemAssembly(ref List<ComponenteModel> dataListModel, string idBomFather, string idItemFather, string typeModel, string finishes, string classes, string mfg_cell, out string errorMethod)
        //{
        //    InventoryItem item_assembly = new InventoryItem();
        //    InventoryItemBase child_item = new InventoryItemBase();
        //    BomPart master_bom_part = new BomPart();
        //    string error = string.Empty;
        //    string id_arinvt = string.Empty;
        //    string id_bom = string.Empty;
        //    string clas = string.Empty;

        //    double looseWeight;
        //    double pesoTeorico;

        //    try
        //    {
        //        master_bom_part.ArInvtId = Convert.ToInt64(idBomFather);
        //        master_bom_part.StandardId = Convert.ToInt64(idItemFather);
        //        master_bom_part.PartNoId = Convert.ToInt32(conexion.InsertPartno(master_bom_part));
        //        this.sndop_id = conexion.InsertSndop();
        //        //master_bom_part = webApi.AddPartToBOM(idItemFather, Convert.ToInt64(idBomFather));

        //        if (master_bom_part != null)
        //        {
        //            foreach (var component in dataListModel)
        //            {
        //                clas = component.Class;

        //                if (clas == "PC" || clas == "ST" || clas == "PL")
        //                {
        //                    id_arinvt = bomDl.GetIdItemArinvt(component.Numero_Parte, component.Class, out error);
        //                    //webApi.AddComponentToPart(master_bom_part.PartNoId, Convert.ToInt32(id_arinvt), Convert.ToDecimal(component.cantidad));
        //                    conexion.InsertComponentToPart(this.sndop_id, id_arinvt, idBomFather, Convert.ToInt32(component.cantidad));
        //                }
        //                else if (clas == "SE" || clas == "AL")
        //                {
        //                    item_assembly = new InventoryItem();
        //                    item_assembly.InventoryClass = "SE";
        //                    item_assembly.ItemNumber = component.Numero_Parte + "-" + component.medida.ToString("N4");
        //                    item_assembly.Description = "TRAMO " + component.Numero_Parte + "-" + component.medida.ToString("N4") + " PULG";
        //                    item_assembly.InactiveFlag = "N";
        //                    item_assembly.Unit = "PZA";
        //                    item_assembly.EplantId = 13;

        //                    //child_item = webApi.createNewItemInv(item_assembly);
        //                    child_item.Id = Convert.ToInt32(conexion.InsertArinvt(item_assembly));

        //                    //if (child_item == null)
        //                    if(child_item.Id>0)
        //                    {
        //                        id_arinvt = conexion.getArinvtIdFromMFG(component.Numero_Parte + "-" + component.medida.ToString("N4"));


        //                        if (Convert.ToInt64(id_arinvt) > 0)
        //                        {
        //                            //webApi.AddComponentToPart(master_bom_part.PartNoId, Convert.ToInt32(id_arinvt), Convert.ToDecimal(component.cantidad));
        //                            conexion.InsertComponentToPart(this.sndop_id, id_arinvt, idBomFather, Convert.ToInt32(component.cantidad));
        //                            CreateBomAssembly(component, typeModel, finishes, id_arinvt, master_bom_part.PartNoId, classes, mfg_cell, out error);
        //                            conexion.UpdateNoSalable(id_arinvt);
        //                            pesoTeorico = conexion.GetPesoTeorico(component.Numero_Parte);
        //                            looseWeight = (component.total_perfil * pesoTeorico) * component.cantidad;
        //                            conexion.InsertLooseWeight(looseWeight.ToString(), id_arinvt);
        //                            fatherLooseWeight += looseWeight;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        //webApi.AddComponentToPart(master_bom_part.PartNoId, child_item.Id, Convert.ToDecimal(component.cantidad));
        //                        conexion.InsertComponentToPart(this.sndop_id, id_arinvt, idBomFather, Convert.ToInt32(component.cantidad));
        //                        CreateBomAssembly(component, typeModel, finishes, child_item.Id.ToString(), master_bom_part.PartNoId, classes, mfg_cell, out error);
        //                        conexion.UpdateNoSalable(child_item.Id.ToString());
        //                        pesoTeorico = conexion.GetPesoTeorico(component.Numero_Parte);
        //                        looseWeight = (component.total_perfil * pesoTeorico) * component.cantidad;
        //                        conexion.InsertLooseWeight(looseWeight.ToString(), child_item.Id.ToString());
        //                        fatherLooseWeight += looseWeight;
        //                    }


        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        error = "Se produjo un error al intentar crear el articulo del ensamble. Especificamente en: ." + Environment.NewLine;
        //        error += ex.Message;
        //    }

        //    errorMethod = error;
        //}

        public void CreateBomAssembly(ComponenteModel dataComponentModel, string typeModel, string finishes, string idItemChild, long idBomPart, string classes, string mfg_cell, out string errorMethod)
        {
            BillOfMaterials master_bom_Assembly = new BillOfMaterials();
            string error = string.Empty;
            string eqno = string.Empty;
            string id_work_center = string.Empty;
            bool is_inserted_run_best = false;
            string id_Bom_assembly = string.Empty;
            string standard_id_child = string.Empty;

            try
            {
                //master_bom_Assembly = webApi.createNewBom("GENERIC", dataComponentModel.Numero_Parte + "-" + dataComponentModel.medida.ToString("N4"));
                master_bom_Assembly.MfgNo = dataComponentModel.Numero_Parte + "-" + dataComponentModel.medida.ToString("N4");
                master_bom_Assembly.MfgType = "GENERIC";
                master_bom_Assembly.StandardId = Convert.ToInt32(conexion.InsertBom(master_bom_Assembly));

                if (mfg_cell == "DP")
                {
                    eqno = "DP-CTE";
                }

                if (mfg_cell == "RE")
                {
                    eqno = "RE-CTE";
                }

                if (mfg_cell == "DC")
                {
                    eqno = "DC-CTE";
                }

                if (mfg_cell == "FV")
                {
                    eqno = "";
                }

                if (mfg_cell == "RL")
                {
                    eqno = "";
                }

                if (mfg_cell == "CP")
                {
                    eqno = "CP";
                }

                if (mfg_cell == "PZ")
                {
                    eqno = "";
                }

                if (mfg_cell == "LI")
                {
                    eqno = "";
                }

                if (mfg_cell == "LA")
                {
                    eqno = "";
                }

                if (mfg_cell == "DL")
                {
                    eqno = "";
                }

                if (mfg_cell == "PM")
                {
                    eqno = "";
                }

                if (mfg_cell == "EB")
                {
                    eqno = "";
                }

                if (mfg_cell == "SM")
                {
                    eqno = "";
                }

                if (mfg_cell == "PI")
                {
                    eqno = "";
                }

                if (mfg_cell == "PK")
                {
                    eqno = "";
                }

                //if (master_bom_Assembly != null)
                if(master_bom_Assembly.StandardId>0)
                {
                    master_bom_Assembly.MfgNo = dataComponentModel.Numero_Parte + "-" + dataComponentModel.medida.ToString("N4");
                    master_bom_Assembly.Description = "TRAMO " + dataComponentModel.Numero_Parte + "-" + dataComponentModel.medida.ToString("N4") + " PULG";
                    master_bom_Assembly.EPlantId = 13;
                    master_bom_Assembly.CycleTime = 5;

                    //webApi.UpdateBOM(master_bom_Assembly);
                    conexion.UpdateBom(master_bom_Assembly);

                    if (dataComponentModel.Numero_Parte.Contains("CINT") || dataComponentModel.Numero_Parte.Contains("PEXAL - 12102") || dataComponentModel.Numero_Parte.Contains("PEXAN - 12102") ||
                             dataComponentModel.Numero_Parte.Contains("PEXAL - 1440") || dataComponentModel.Numero_Parte.Contains("PEXAN - 12102") ||
                             dataComponentModel.Numero_Parte.Contains("PEXAL - 11967") || dataComponentModel.Numero_Parte.Contains("PEXAN - 11967") ||
                             dataComponentModel.Numero_Parte.Contains("WIRE24") || dataComponentModel.Numero_Parte.Contains("WIRE24") ||
                             dataComponentModel.Numero_Parte.Contains("REMACHEPOP43") || dataComponentModel.Numero_Parte.Contains("ACTUADORCO") ||
                             dataComponentModel.Numero_Parte.Contains("PEXAL - 21487") || dataComponentModel.Numero_Parte.Contains("PEXAN - 21487"))
                    {
                        conexion.updateCntrType("REJILLAS", master_bom_Assembly.StandardId.ToString());
                        conexion.updateMfCell("RE", master_bom_Assembly.StandardId.ToString());
                        eqno = "RE-CTE";
                    }
                    if (dataComponentModel.Numero_Parte == "PEXAL - 10185" || dataComponentModel.Numero_Parte == "PEXAN - 10185")
                    {
                        conexion.updateCntrType("CP", master_bom_Assembly.StandardId.ToString());
                        conexion.updateMfCell("CP", master_bom_Assembly.StandardId.ToString());
                        eqno = "CP";
                    }
                    else
                    {
                        conexion.updateCntrType(typeModel, master_bom_Assembly.StandardId.ToString());
                        conexion.updateMfCell(typeModel, master_bom_Assembly.StandardId.ToString());
                    }

                    /// Obtiene id del work center para funcionalidad del Run Best 
                    id_work_center = bomDl.GetIdWorkCenter(eqno, out error);

                    if (error == "")
                    {
                        is_inserted_run_best = bomDl.CreateRunBest(master_bom_Assembly.StandardId.ToString(), id_work_center, out error);
                    }

                    AddItemToBom(master_bom_Assembly, dataComponentModel, finishes, idItemChild, idBomPart, classes, out error);
                }
                else
                {
                    id_Bom_assembly = conexion.getArinvtIdFromMFG(dataComponentModel.Numero_Parte + "-" + dataComponentModel.medida.ToString("N4"));
                    id_work_center = bomDl.GetIdWorkCenter(eqno, out error);

                    if (Convert.ToInt64(id_Bom_assembly) > 0)
                    {
                        master_bom_Assembly = new BillOfMaterials();
                        master_bom_Assembly.StandardId = Convert.ToInt64(id_Bom_assembly);
                        AddItemToBom(master_bom_Assembly, dataComponentModel, finishes, idItemChild, idBomPart, classes, out error);

                        if (dataComponentModel.Numero_Parte.Contains("CINT") || dataComponentModel.Numero_Parte.Contains("PEXAL - 12102") || dataComponentModel.Numero_Parte.Contains("PEXAN - 12102") ||
                             dataComponentModel.Numero_Parte.Contains("PEXAL - 1440") || dataComponentModel.Numero_Parte.Contains("PEXAN - 12102") ||
                             dataComponentModel.Numero_Parte.Contains("PEXAL - 11967") || dataComponentModel.Numero_Parte.Contains("PEXAN - 11967") ||
                             dataComponentModel.Numero_Parte.Contains("WIRE24") || dataComponentModel.Numero_Parte.Contains("WIRE24") ||
                             dataComponentModel.Numero_Parte.Contains("REMACHEPOP43") || dataComponentModel.Numero_Parte.Contains("ACTUADORCO") ||
                             dataComponentModel.Numero_Parte.Contains("PEXAL - 21487") || dataComponentModel.Numero_Parte.Contains("PEXAN - 21487"))
                        {
                            standard_id_child = conexion.getStandardIdFromMFG(dataComponentModel.Numero_Parte + "-" + dataComponentModel.medida.ToString("N4"));
                            conexion.updateCntrType("REJILLAS", standard_id_child);
                            conexion.updateMfCell("RE", standard_id_child);
                            conexion.UpdateRunBest(standard_id_child, id_work_center);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = "Se produjo un error al intentar crear el bom del ensamble. Especificamente en: ." + Environment.NewLine;
                error += ex.Message;
            }

            errorMethod = error;
        }

        //public void CreateBomAssembly(ComponenteModel dataComponentModel, string typeModel, string finishes, string idItemChild, long idBomPart, string classes, string mfg_cell, out string errorMethod)
        //{
        //    BillOfMaterials master_bom_Assembly = new BillOfMaterials();
        //    string error = string.Empty;
        //    string eqno = string.Empty;
        //    string id_work_center = string.Empty;
        //    bool is_inserted_run_best = false;
        //    string id_Bom_assembly = string.Empty;
        //    string standad_id = string.Empty;
        //    string standard_id_child = string.Empty;

        //    try
        //    {
        //        master_bom_Assembly = webApi.createNewBom("GENERIC", dataComponentModel.Numero_Parte + "-" + dataComponentModel.medida.ToString("N4"));

        //        if (master_bom_Assembly != null)
        //        {
        //            master_bom_Assembly.MfgNo = dataComponentModel.Numero_Parte + "-" + dataComponentModel.medida.ToString("N4");
        //            master_bom_Assembly.Description = "TRAMO " + dataComponentModel.Numero_Parte + "-" + dataComponentModel.medida.ToString("N4") + " PULG";
        //            master_bom_Assembly.EPlantId = 13;
        //            master_bom_Assembly.CycleTime = 5;

        //            webApi.UpdateBOM(master_bom_Assembly);

        //            if (mfg_cell == "DP")
        //            {
        //                eqno = "DP-CTE";
        //            }

        //            if (mfg_cell == "RE")
        //            {
        //                eqno = "RE-CTE";
        //            }

        //            if (mfg_cell == "DC")
        //            {
        //                eqno = "DC-CTE";
        //            }

        //            if (mfg_cell == "FV")
        //            {
        //                eqno = "";
        //            }

        //            if (mfg_cell == "RL")
        //            {
        //                eqno = "";
        //            }

        //            if (mfg_cell == "CP")
        //            {
        //                eqno = "CP";
        //            }

        //            if (mfg_cell == "PZ")
        //            {
        //                eqno = "";
        //            }

        //            if (mfg_cell == "LI")
        //            {
        //                eqno = "";
        //            }

        //            if (mfg_cell == "LA")
        //            {
        //                eqno = "";
        //            }

        //            if (mfg_cell == "DL")
        //            {
        //                eqno = "";
        //            }

        //            if (mfg_cell == "PM")
        //            {
        //                eqno = "";
        //            }

        //            if (mfg_cell == "EB")
        //            {
        //                eqno = "";
        //            }

        //            if (mfg_cell == "SM")
        //            {
        //                eqno = "";
        //            }

        //            if (mfg_cell == "PI")
        //            {
        //                eqno = "";
        //            }

        //            if (mfg_cell == "PK")
        //            {
        //                eqno = "";
        //            }

        //            if (dataComponentModel.Numero_Parte.Contains("CINT") || dataComponentModel.Numero_Parte.Contains("PEXAL - 12102") || dataComponentModel.Numero_Parte.Contains("PEXAN - 12102") ||
        //                     dataComponentModel.Numero_Parte.Contains("PEXAL - 1440") || dataComponentModel.Numero_Parte.Contains("PEXAN - 12102") ||
        //                     dataComponentModel.Numero_Parte.Contains("PEXAL - 11967") || dataComponentModel.Numero_Parte.Contains("PEXAN - 11967") ||
        //                     dataComponentModel.Numero_Parte.Contains("WIRE24") || dataComponentModel.Numero_Parte.Contains("WIRE24") ||
        //                     dataComponentModel.Numero_Parte.Contains("REMACHEPOP43") || dataComponentModel.Numero_Parte.Contains("ACTUADORCO") ||
        //                     dataComponentModel.Numero_Parte.Contains("PEXAL - 21487") || dataComponentModel.Numero_Parte.Contains("PEXAN - 21487"))
        //            {
        //                conexion.updateCntrType("REJILLAS", master_bom_Assembly.StandardId.ToString());
        //                conexion.updateMfCell("RE", master_bom_Assembly.StandardId.ToString());
        //                eqno = "RE-CTE";
        //            }
        //            else
        //            {
        //                conexion.updateCntrType(typeModel, master_bom_Assembly.StandardId.ToString());
        //                conexion.updateMfCell(typeModel, master_bom_Assembly.StandardId.ToString());
        //            }
        //            if (dataComponentModel.Numero_Parte == "PEXAL - 10185" || dataComponentModel.Numero_Parte == "PEXAN - 10185")
        //            {
        //                conexion.updateCntrType("CP", master_bom_Assembly.StandardId.ToString());
        //                conexion.updateMfCell("CP", master_bom_Assembly.StandardId.ToString());
        //                eqno = "CP";
        //            }


        //            /// Obtiene id del work center para funcionalidad del Run Best 
        //            id_work_center = bomDl.GetIdWorkCenter(eqno, out error);

        //            if (error == "")
        //            {
        //                is_inserted_run_best = bomDl.CreateRunBest(master_bom_Assembly.StandardId.ToString(), id_work_center, out error);
        //            }

        //            AddItemToBom(master_bom_Assembly, dataComponentModel, finishes, idItemChild, idBomPart, classes, out error);
        //        }
        //        else
        //        {
        //            id_Bom_assembly = conexion.getArinvtIdFromMFG(dataComponentModel.Numero_Parte + "-" + dataComponentModel.medida.ToString("N4"));

        //            if (Convert.ToInt64(id_Bom_assembly) > 0)
        //            {
        //                master_bom_Assembly = new BillOfMaterials();
        //                master_bom_Assembly.StandardId = Convert.ToInt64(id_Bom_assembly);

        //                AddItemToBom(master_bom_Assembly, dataComponentModel, finishes, idItemChild, idBomPart, classes, out error);

        //                if (dataComponentModel.Numero_Parte.Contains("CINT") || dataComponentModel.Numero_Parte.Contains("PEXAL - 12102") || dataComponentModel.Numero_Parte.Contains("PEXAN - 12102") ||
        //                     dataComponentModel.Numero_Parte.Contains("PEXAL - 1440") || dataComponentModel.Numero_Parte.Contains("PEXAN - 12102") ||
        //                     dataComponentModel.Numero_Parte.Contains("PEXAL - 11967") || dataComponentModel.Numero_Parte.Contains("PEXAN - 11967") ||
        //                     dataComponentModel.Numero_Parte.Contains("WIRE24") || dataComponentModel.Numero_Parte.Contains("WIRE24") ||
        //                     dataComponentModel.Numero_Parte.Contains("REMACHEPOP43") || dataComponentModel.Numero_Parte.Contains("ACTUADORCO") ||
        //                     dataComponentModel.Numero_Parte.Contains("PEXAL - 21487") || dataComponentModel.Numero_Parte.Contains("PEXAN - 21487"))
        //                {
        //                    id_work_center = bomDl.GetIdWorkCenter(eqno, out error);
        //                    standard_id_child = conexion.getStandardIdFromMFG(dataComponentModel.Numero_Parte + "-" + dataComponentModel.medida.ToString("N4"));
        //                    conexion.updateCntrType("REJILLAS", standard_id_child);
        //                    conexion.updateMfCell("RE", standard_id_child);
        //                    conexion.UpdateRunBest(standad_id, id_work_center);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        error = "Se produjo un error al intentar crear el bom del ensamble. Especificamente en: ." + Environment.NewLine;
        //        error += ex.Message;
        //    }

        //    errorMethod = error;
        //}

        public void AddItemToBom(BillOfMaterials dataBomAssembly, ComponenteModel componenteModel, string finishes, string idItemChild, long idBomPart, string classess, out string errorMethod)
        {
            SQLServer sql = new SQLServer();
            ArinvtModel arinvt = new ArinvtModel();
            BomPart bom_part = new BomPart();
            InventoryItem item_sub_assembly = new InventoryItem();
            InventoryItemBase chlid_sub_assembly = new InventoryItemBase();
            string error = string.Empty;
            string id_arinvt = string.Empty;
            double weight_total = 0;
            string id_bom = string.Empty;
            string clas = string.Empty;
            string id_bom_part = string.Empty;
            double looseWeight;
            double pesoTeorico;

            try
            {
                if (componenteModel.Numero_Parte.Contains("PEXAL - 10185"))
                {
                    arinvt = bomDl.Get_Purchased_Item(componenteModel.Numero_Parte, "AL");
                }
                else if (componenteModel.Numero_Parte.Contains("PEXAN - 10185"))
                {
                    arinvt = bomDl.Get_Purchased_Item(componenteModel.Numero_Parte, "AL");
                }
                else
                {
                    arinvt = bomDl.Get_Purchased_Item(componenteModel.Numero_Parte, classess);
                }

                if (arinvt == null)
                {
                    error += "Se produjo un error al intentar verificar la existencia del articulo comprado que se añadira al BOM.." + Environment.NewLine;
                }
                else
                {
                    id_bom_part = idBomPart.ToString();
                    //bom_part = webApi.AddPartToBOM(idItemChild, dataBomAssembly.StandardId);
                    bom_part.ArInvtId = Convert.ToInt64(idItemChild);
                    bom_part.StandardId = Convert.ToInt64(dataBomAssembly.StandardId);
                    bom_part.PartNoId = Convert.ToInt64(conexion.InsertPartno(bom_part));

                    //if (bom_part == null)
                    if(bom_part.PartNoId>0)
                    {
                        error += "Se produjo un error al intentar crear el bom del sub-ensamble.." + Environment.NewLine;
                    }
                    else
                    {
                        item_sub_assembly = new InventoryItem();
                        item_sub_assembly.EplantId = 13;
                        item_sub_assembly.ItemNumber = arinvt.Itemno.ToString();
                        item_sub_assembly.Unit = "PZA";
                        item_sub_assembly.InactiveFlag = "N";
                        item_sub_assembly.Description = arinvt.Itemno + "-" + finishes;
                        item_sub_assembly.InventoryClass = finishes;

                        if (componenteModel.total_perfil > 0)
                        {
                            weight_total = componenteModel.total_perfil / componenteModel.cantidad;
                        }
                        else
                        {
                            weight_total = componenteModel.Peso_Kg;
                        }

                        //chlid_sub_assembly = webApi.createNewItemInv(item_sub_assembly);
                        chlid_sub_assembly.Id = Convert.ToInt64(conexion.InsertArinvt(item_sub_assembly));

                        //if (chlid_sub_assembly == null)
                        if(chlid_sub_assembly.Id>0)
                        {
                            id_arinvt = conexion.getArinvtIdFromMFG(item_sub_assembly.ItemNumber);

                            if (Convert.ToInt64(id_arinvt) > 0)
                            {
                                //webApi.AddComponentToPart(bom_part.PartNoId, Convert.ToInt32(id_arinvt), Convert.ToDecimal(weight_total.ToString("N6")));
                                conexion.InsertComponentToPart(bom_part.PartNoId.ToString(), id_arinvt, "", Convert.ToInt32(weight_total.ToString("N6")));
                            }
                        }
                        else
                        {
                            //webApi.AddComponentToPart(bom_part.PartNoId, chlid_sub_assembly.Id, Convert.ToDecimal(weight_total.ToString("N6")));
                            conexion.InsertComponentToPart(bom_part.PartNoId.ToString(), chlid_sub_assembly.Id.ToString(), "", Convert.ToInt32(weight_total.ToString("N6")));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
        }

        public string MakeSerialize(BomForm form)
        {
            string serialize = string.Empty;

            if (!string.IsNullOrEmpty(form.Largo.ToString()))
                serialize += form.Largo + "|";
            else
                serialize += "0|";
            if (!string.IsNullOrEmpty(form.Ancho.ToString()))
                serialize += form.Ancho + "|";
            else
                serialize += "0|";
            if (!string.IsNullOrEmpty(form.Diametro.ToString()))
                serialize += form.Diametro + "|";
            else
                serialize += "0|";
            if (!string.IsNullOrEmpty(form.Grados.ToString()))
                serialize += form.Grados + "|";
            else
                serialize += "0|";
            if (!string.IsNullOrEmpty(form.Ranuras.ToString()))
                serialize += form.Ranuras + "|";
            else
                serialize += "0|";
            if (!string.IsNullOrEmpty(form.Espesor.ToString()))
                serialize += form.Espesor + "|";
            else
                serialize += "0|";
            if (!string.IsNullOrEmpty(form.Pies.ToString()))
                serialize += form.Pies + "|";
            else
                serialize += "0|";
            if (!string.IsNullOrEmpty(form.Ancho1.ToString()))
                serialize += form.Ancho1 + "|";
            else
                serialize += "0|";
            if (!string.IsNullOrEmpty(form.Ancho2.ToString()))
                serialize += form.Ancho2 + "|";
            else
                serialize += "0|";
            if (!string.IsNullOrEmpty(form.Ancho3.ToString()))
                serialize += form.Ancho3 + "|";
            else
                serialize += "0|";
            if (!string.IsNullOrEmpty(form.Ancho4.ToString()))
                serialize += form.Ancho4 + "|";
            else
                serialize += "0|";
            if (!string.IsNullOrEmpty(form.Altura.ToString()))
                serialize += form.Altura + "|";
            else
                serialize += "0|";
            if (!string.IsNullOrEmpty(form.Cuello1.ToString()))
                serialize += form.Cuello1 + "|";
            else
                serialize += "0|";
            if (!string.IsNullOrEmpty(form.Cuello2.ToString()))
                serialize += form.Cuello2 + "|";
            else
                serialize += "0|";
            if (!string.IsNullOrEmpty(form.Elemen.ToString()))
                serialize += form.Elemen + "|";
            else
                serialize += "0|";

            return serialize;
        }

        public string GetMeasure(BomForm form)
        {
            string measure = string.Empty;

            if (!string.IsNullOrEmpty(form.Largo.ToString()) && !string.Equals(form.Largo.ToString(), "0"))
                measure += "X" + form.Largo;
            if (!string.IsNullOrEmpty(form.Ancho.ToString()) && !string.Equals(form.Ancho.ToString(), "0"))
                measure += "X" + form.Ancho;
            if (!string.IsNullOrEmpty(form.Horizontal.ToString()) && !string.Equals(form.Horizontal.ToString(), "0"))
                measure += "X" + form.Horizontal;
            if (!string.IsNullOrEmpty(form.Vertical.ToString()) && !string.Equals(form.Vertical.ToString(), "0"))
                measure += "X" + form.Vertical;
            if (!string.IsNullOrEmpty(form.Diametro.ToString()) && !string.Equals(form.Diametro.ToString(), "0"))
                measure += "X" + form.Diametro;
            if (!string.IsNullOrEmpty(form.Grados.ToString()) && !string.Equals(form.Grados.ToString(), "0"))
                measure += "X" + form.Grados;
            if (!string.IsNullOrEmpty(form.Ranuras.ToString()) && !string.Equals(form.Ranuras.ToString(), "0"))
                measure += "X" + form.Ranuras;
            if (!string.IsNullOrEmpty(form.Espesor.ToString()) && !string.Equals(form.Espesor.ToString(), "0"))
                measure += "X" + form.Espesor;
            if (!string.IsNullOrEmpty(form.Pies.ToString()) && !string.Equals(form.Pies.ToString(), "0"))
                measure += "X" + form.Pies;
            if (!string.IsNullOrEmpty(form.Ancho1.ToString()) && !string.Equals(form.Ancho1.ToString(), "0"))
                measure += "X" + form.Ancho1;
            if (!string.IsNullOrEmpty(form.Ancho2.ToString()) && !string.Equals(form.Ancho2.ToString(), "0"))
                measure += "X" + form.Ancho2;
            if (!string.IsNullOrEmpty(form.Ancho3.ToString()) && !string.Equals(form.Ancho3.ToString(), "0"))
                measure += "X" + form.Ancho3;
            if (!string.IsNullOrEmpty(form.Ancho4.ToString()) && !string.Equals(form.Ancho4.ToString(), "0"))
                measure += "X" + form.Ancho4;
            return measure.Substring(1);
        }
    }

}
