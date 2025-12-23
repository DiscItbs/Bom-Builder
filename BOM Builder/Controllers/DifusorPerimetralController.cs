using BOM_Builder.DL;
using BOM_Builder.Models;
using System;
using System.Collections.Generic;

namespace BOM_Builder.Controllers
{
   public class DifusorPerimetralController
   {
      #region VARIABLES GLOBALES

      DifusorPerimetralDL difusorDL = new DifusorPerimetralDL();

      #endregion

      /// <summary>
      /// Metodo para obtener la lista de codigos (abreviaturas de modelos)
      /// </summary>
      /// <returns></returns>
      public List<NM_CodigoModel> Get_Codigos()
      {
         List<NM_CodigoModel> lData = new List<NM_CodigoModel>();
         string error = string.Empty;

         try
         {
            lData = difusorDL.Get_List_Codigos();
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         return lData;
      }

      /// <summary>
      /// Metodo para obtener la lista de accesorios de bom´s
      /// </summary>
      /// <returns></returns>
      public List<NM_AccesorioModel> Get_Accesorios()
      {
         List<NM_AccesorioModel> lData = new List<NM_AccesorioModel>();
         string error = string.Empty;

         try
         {
            lData = difusorDL.Get_List_Accesorios();
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         return lData;
      }

      /// <summary>
      /// Metodo para obtener la lista de grados de deflexores
      /// </summary>
      /// <returns></returns>
      public List<NM_DeflexorModel> Get_Deflexores()
      {
         List<NM_DeflexorModel> lData = new List<NM_DeflexorModel>();
         string error = string.Empty;

         try
         {
            lData = difusorDL.Get_List_Deflexores();
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         return lData;
      }

      /// <summary>
      /// Metodo para obtener la lista de las medidas de los espesores
      /// </summary>
      /// <returns></returns>
      public List<NM_EspesorModel> Get_Espesores()
      {
         List<NM_EspesorModel> lData = new List<NM_EspesorModel>();
         string error = string.Empty;

         try
         {
            lData = difusorDL.Get_List_Espesores();
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         return lData;
      }

      /// <summary>
      /// Metodo para obtener la lista de medidas de los marcos
      /// </summary>
      /// <returns></returns>
      public List<NM_MarcoModel> Get_Marcos()
      {
         List<NM_MarcoModel> lData = new List<NM_MarcoModel>();
         string error = string.Empty;

         try
         {
            lData = difusorDL.Get_List_Marcos();
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         return lData;
      }

      /// <summary>
      /// Metodos para obtener la lista de las medidas de los separadores
      /// </summary>
      /// <returns></returns>
      public List<NM_SeparadorModel> Get_Separadores()
      {
         List<NM_SeparadorModel> lData = new List<NM_SeparadorModel>();
         string error = string.Empty;

         try
         {
            lData = difusorDL.Get_List_Separadores();
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         return lData;
      }

      /// <summary>
      /// Metodo para comprar la existencia del bom en base a la combinacion de datos
      /// retornara el id
      /// </summary>
      /// <param name="combinacion"></param>
      /// <returns></returns>
      public int Get_Combinacion_Existente(string combinacion)
      {
         string error = string.Empty;
         int Id = 0;

         try
         {
            Id = difusorDL.Get_Combinacion_Existente(combinacion);
         }
         catch (Exception ex)
         {
            error = ex.Message;
            Id = 0;
         }

         return Id;
      }

      /// <summary>
      /// Metodo para obtener la lista de los pexales
      /// </summary>
      /// <returns></returns>
      public List<NM_ComponentesModel> Get_List_Components_AL()
      {
         List<NM_ComponentesModel> lData = new List<NM_ComponentesModel>();
         string error = string.Empty;

         try
         {
            lData = difusorDL.Get_List_Components_AL();
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         return lData;
      }

      /// <summary>
      /// Metodo para obtener la lista de los pexanes
      /// </summary>
      /// <returns></returns>
      public List<NM_ComponentesModel> Get_List_Components_AN()
      {
         List<NM_ComponentesModel> lData = new List<NM_ComponentesModel>();
         string error = string.Empty;

         try
         {
            lData = difusorDL.Get_List_Components_AN();
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         return lData;
      }

      /// <summary>
      /// Metodo para obtener la lista de los pexales
      /// </summary>
      /// <returns></returns>
      public List<NM_ComponentesModel> Get_List_Components_Class_ST()
      {
         List<NM_ComponentesModel> lData = new List<NM_ComponentesModel>();
         string error = string.Empty;

         try
         {
            lData = difusorDL.Get_List_Components_Class_ST();
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         return lData;
      }

      /// <summary>
      /// Metodo para obtener la lista de los pexanes
      /// </summary>
      /// <returns></returns>
      public List<NM_ComponentesModel> Get_List_Components_Class_PC()
      {
         List<NM_ComponentesModel> lData = new List<NM_ComponentesModel>();
         string error = string.Empty;

         try
         {
            lData = difusorDL.Get_List_Components_Class_PC();
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         return lData;
      }

      /// <summary>
      /// Metodo para obtener la lista de los pexac´s
      /// </summary>
      /// <returns></returns>
      public List<NM_ComponentesModel> Get_List_Components_AC()
      {
         List<NM_ComponentesModel> lData = new List<NM_ComponentesModel>();
         string error = string.Empty;

         try
         {
            lData = difusorDL.Get_List_Components_AC();
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         return lData;
      }

      public bool Create_Component(List<ArinvtModel> pModel, string pAcabado)
      {
         bool affected = false;
         string error = string.Empty;

         try
         {
            affected = difusorDL.Add_Components(pModel, pAcabado);
            return affected;
         }
         catch (Exception ex)
         {
            error = ex.Message;
            return false;
         }
      }

      public string Get_Description_Marco(string pMarco)
      {
         string error = string.Empty;

         try
         {
            error = difusorDL.Get_Descrip_Marco(pMarco);
         }
         catch (Exception ex)
         {
            error = ex.Message;
         }

         return error;
      }
   }
}
