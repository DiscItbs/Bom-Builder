using BOM_Builder.DL;
using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BOM_Builder.Controllers
{
    public class ConfiguracionController
    {
        ConfiguracionDL configuracionDL = new ConfiguracionDL();
        BomDL bomDL = new BomDL();

        #region GET
        
        /// <summary>
        /// Metodo para verificar si existe la combinación a crear
        /// </summary>
        /// <param name="modeloCompuesto"></param>
        /// <param name="acabado"></param>
        /// <param name="errorMetodo"></param>
        /// <returns></returns>
        public bool VerifyExistence(string modeloCompuesto, string acabado, out string errorMetodo)
        {
            string error = string.Empty;
            bool success = false;

            try
            {
                success = configuracionDL.VerifyExistence(modeloCompuesto, acabado, out errorMetodo);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            if (error == "")
            {
                errorMetodo = error;
                success = false;
            }
            else
            {
                errorMetodo = error;
                success = true;
            }

            return success;
        }

        /// <summary>
        /// Metodo para obtener la lista de clases de iqms validadas como materia prima
        /// </summary>
        /// <param name="dataListClass"></param>
        /// <param name="itemno"></param>
        /// <param name="description"></param>
        /// <param name="errorMethod"></param>
        /// <returns></returns>
        public List<ArinvtModel> GetInfoComponents(List<string> dataListClass, string itemno, string description, out string errorMethod)
        {
            List<ArinvtModel> data_list = new List<ArinvtModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListComponents(dataListClass, itemno, description, out error);
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
        /// Metodo para obtener la lista de componentes por acabado
        /// </summary>
        /// <param name="finishes"></param>
        /// <param name="errorMethod"></param>
        /// <returns></returns>
        public List<ArinvtModel> GetInfoComponents(string finishes, out string errorMethod)
        {
            List<ArinvtModel> data_list = new List<ArinvtModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListComponents(finishes, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }
            //MessageBox.Show("pase por GetInfoComponents");
            errorMethod = error;
            return data_list;
        }

        public List<ArinvtModel> GetInfoComponents(out string errorMethod)
        {
            List<ArinvtModel> data_list = new List<ArinvtModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListComponents(out error);
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
        /// Metodo para obtener el listado de combinaciones
        /// </summary>
        /// <returns></returns>
        public List<NM_CombinacionesModel> GetListCombinacions(string finish, int id)
        {
            List<NM_CombinacionesModel> data_list = new List<NM_CombinacionesModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListCombinacions(finish, id);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            return data_list;
        }

        /// <summary>
        /// Metodo para obtener el listado de componentes por combinacion
        /// </summary>
        /// <param name="combination"></param>
        /// <returns></returns>
        public List<NM_Detalle_Combinaciones_ComponentesModel> GetListCombinacionComponente(string combination, string finish)
        {
            List<NM_Detalle_Combinaciones_ComponentesModel> data_list = new List<NM_Detalle_Combinaciones_ComponentesModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListCombinacionComponente(combination, finish);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            return data_list;
        }

        /// <summary>
        /// Metodo para obtener el listado de modelos de bom superior l0
        /// </summary>
        /// <param name="errorMethod"></param>
        /// <returns></returns>
        public List<NM_ModelosLModel> GetListModelL0(out string errorMethod)
        {
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListModelL0(out error);
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
        /// Metodo para obtener el listado de modelos de bom superior l1, en relacion al id del modelo l0
        /// </summary>
        /// <param name="id"></param>
        /// <param name="errorMethod"></param>
        /// <returns></returns>
        public List<NM_ModelosLModel> GetListModelL1(int id, out string errorMethod)
        {
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListModelL1(id, out error);
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
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListModelL2(out error);
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
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListModelL2(id, out error);
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
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListModelL0WithSubNivel(out error);
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
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListModelL1WithSubNivel(out error);
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
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListModelL1WithSubNivel(id, out error);
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
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListModelL2WithSubNivel(out error);
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
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListModelL2WithSubNivel(id, out error);
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
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListModelL3WithSubNivel(id, out error);
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
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListModelL3(out error);
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
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListModelL3(id, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            errorMethod = error;
            return data_list;
        }

        public List<ArinvtModel> GetListClassValid(out string errorMethod)
        {
            List<ArinvtModel> data_list = new List<ArinvtModel>();
            string error = string.Empty;

            try
            {
                data_list = bomDL.GetListClassValid(out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            errorMethod = error;
            return data_list;
        }

        public List<NM_MaterialesModel> GetListMaterials()
        {
            string error = string.Empty;
            List<NM_MaterialesModel> data_list = new List<NM_MaterialesModel>();

            try
            {
                data_list = configuracionDL.GetListMaterials();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            return data_list;
        }

        public List<NM_MaterialesModel> GetListMaterialsCombo()
        {
            string error = string.Empty;
            List<NM_MaterialesModel> data_list = new List<NM_MaterialesModel>();

            try
            {
                data_list = configuracionDL.GetListMaterialsCombo();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            return data_list;
        }

        public List<NM_SubMaterialesModel> GetLisSubtMaterials(int id)
        {
            string error = string.Empty;
            List<NM_SubMaterialesModel> data_list = new List<NM_SubMaterialesModel>();

            try
            {
                data_list = configuracionDL.GetLisSubtMaterials(id);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            return data_list;
        }

        public List<NM_SubMaterialesModel> GetLisSubtMaterials()
        {
            string error = string.Empty;
            List<NM_SubMaterialesModel> data_list = new List<NM_SubMaterialesModel>();

            try
            {
                data_list = configuracionDL.GetLisSubtMaterials();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            return data_list;
        }

        public List<WorkCenterModel> GetWorkCenters()
        {
            List<WorkCenterModel> data_list = new List<WorkCenterModel>();
            string error = string.Empty;

            try
            {
                data_list = configuracionDL.GetListMfgCell();
            }
            catch ( Exception ex) 
            {
                error = ex.Message;
                data_list = null;
            }

            return data_list;
        }

        public List<NM_CondicionalMaster> GetListConditionals(out string errorMethod)
        {
            string error = string.Empty;
            List<NM_CondicionalMaster> data_list = new List<NM_CondicionalMaster>();

            try
            {
                data_list = configuracionDL.GetListConditionals(out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return data_list;
        }

        public ConditionalsModel GetConditionals(int id, out string errorMethod)
        {
            ConditionalsModel data_model = new ConditionalsModel();
            string error = string.Empty;

            try
            {
                data_model = configuracionDL.GetConditionals(id, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return data_model;
        }

        public List<ConditionalsModel> GetListConditionals(int id, out string errorMethod)
        {
            string error = string.Empty;
            List<ConditionalsModel> data_list = new List<ConditionalsModel>();

            try
            {
                data_list = configuracionDL.GetListConditionals(id, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return data_list;
        }

        public string GetIdCompuesto(string id)
        {
            string id_compuesto = string.Empty;
            string error = string.Empty;

            try
            {
                id_compuesto = configuracionDL.GetIdCompuesto(id);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return id_compuesto;
        }

        public string GetFormula(int id, out string errorMethod)
        {
            string error = string.Empty;
            string formula = string.Empty;

            try
            {
                formula = configuracionDL.GetFormula(id, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return formula;
        }

        #region EDICION

        public long GetIdCombinationBOM(string combination, string type, out string errorMethod)
        {
            long id = 0;
            string error = string.Empty;

            try
            {
                id = configuracionDL.GetIdCombinationBOM(combination, type, out error);
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
            string error = string.Empty;

            try
            {
                dataList = configuracionDL.GetListComponents(id, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return dataList;
        }

        public List<NM_Detalle_Combinacion_Componentes_FormulasModel> GetListComponentsFormulas(string combinacion, string typeMaterial, out string errorMethod)
        {
            List<NM_Detalle_Combinacion_Componentes_FormulasModel> dataList = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
            string error = string.Empty;

            try
            {
                dataList = configuracionDL.GetListComponentsFormulas(combinacion, typeMaterial, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return dataList;
        }

        public bool UpdateFormulasComponent(List<NM_Detalle_Combinacion_Componentes_FormulasModel> dataList, out string errorMethod)
        {
            bool state = false;
            string error = string.Empty;

            try
            {
                state = configuracionDL.UpdateFormulasComponent(dataList, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return state;
        }

        #endregion

        #endregion

        #region POST

        /// <summary>
        /// Metodo para crear el pre-ensamblado de bom x componentes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modeloCompuesto"></param>
        /// <param name="acabado"></param>
        /// <param name="dataList"></param>
        /// <param name="errorMetodo"></param>
        /// <returns></returns>
        public bool CreateModelComponents(int id, string modeloCompuesto, string acabado, List<NM_Detalle_Combinaciones_ComponentesModel> dataList, out string errorMetodo)
        {
            string error = string.Empty;
            bool affected = false;

            try
            {
                affected = configuracionDL.CreateModelComponents(id, modeloCompuesto, acabado, dataList, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMetodo = error;
            return affected;
        }

        /// <summary>
        /// Metodo para obtener el listado de formulas y componentes
        /// </summary>
        /// <param name="dataListModel"></param>
        /// <param name="errorMethod"></param>
        public bool CreateModelComplete(List<NM_Detalle_Combinacion_Componentes_FormulasModel> dataListModel, out string errorMethod)
        {
            string error = string.Empty;

            try
            {
                configuracionDL.CreateModelComplete(dataListModel, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                errorMethod = error;
                return false;
            }

            errorMethod = error;

            return true;
        }

        public bool CreateModelL0(string nameModel, string descriptionModel, string description_large, string description_english, out string errorMethod)
        {
            string error = string.Empty;
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.CreateModelL0(nameModel, descriptionModel, description_large, description_english, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool CreateModelL1(int idModelL0, string nameModel, string descriptionModel, string apply, string mfg,string centroTrabajo, out string errorMethod)
        {
            string error = string.Empty;
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.CreateModelL1(idModelL0, nameModel, descriptionModel, apply, mfg,centroTrabajo, out error);
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
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.CreateModelL2(idModelL1, nameModel, descriptionModel, apply, out error);
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
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.CreateModelL3(idModelL2, nameModel, descriptionModel, out error);
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
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.CreateMaterial(name, description, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool CreateSubMaterial(int id, string name, string description, out string errorMethod)
        {
            string error = string.Empty;
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.CreateSubMaterial(id, name, description, out error);
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
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.UpdateModelL0(idModelL0, nameModel, descriptionModel, description_large, description_english, out error);
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
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.UpdateModelL1(idModelL1, nameModel, descriptionModel, apply, mfg,centroTrabajo, out error);
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
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.UpdateModelL2(idModelL2, idModelL1, nameModel, descriptionModel, apply, out error);
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
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.UpdateModelL3(idModelL3, idModelL2, nameModel, descriptionModel, out error);
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
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.UpdateMaterial(id, name, description, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        public bool UpdateSubMaterial(int id, string name, string description, out string errorMethod)
        {
            string error = string.Empty;
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.UpdateSubMaterial(id, name, description, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return is_inserted;
        }

        #region EDICION

        public bool UpdateComponentsBOM(long idCombination, string combination, List<NM_Detalle_Combinaciones_ComponentesModel> dataList, List<NM_Detalle_Combinaciones_ComponentesModel> dataListNews, out string errorMethod)
        {
            bool state = false;
            string error = string.Empty;

            try
            {
                state = configuracionDL.UpdateComponentsBOM(idCombination, combination, dataList, dataListNews, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                state = false;
            }

            errorMethod = error;
            return state;
        }

        public bool DeleteComponentsBOM( List<NM_Detalle_Combinaciones_ComponentesModel> dataList,  out string errorMethod)
        {
            bool state = false;
            string error = string.Empty;

            try
            {
                state = configuracionDL.DeleteComponentsBOM(dataList, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                state = false;
            }

            errorMethod = error;
            return state;
        }

        public bool AddComponentsBOM( List<NM_Detalle_Combinaciones_ComponentesModel> dataList, long idCombinacion,  out string errorMethod)
        {
            bool state = false;
            string error = string.Empty;

            try
            {
                state = configuracionDL.AddComponentsBOM( dataList, idCombinacion, out error);
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
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.DeleteModelL0(idModelL0, out error);
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
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.DeleteModelL1(idModelL1, out error);
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
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.DeleteModelL2(idModelL2, idModelL1, out error);
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
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.DeleteModelL3(idModelL3, idModelL2, out error);
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
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.DeleteMaterial(id, out error);
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
            bool is_inserted = false;

            try
            {
                is_inserted = configuracionDL.DeleteSubMaterial(id, out error);
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
