using BOM_Builder.Controllers;
using BOM_Builder.DL;
using BOM_Builder.Models;
using System;
using System.Collections.Generic;

namespace BOM_Builder.BL
{
   public class ConstructionComponentDP
   {
      #region VARIABLES GLOBALES

      BomDL dL = new BomDL();
      ComponentesDL componentDL = new ComponentesDL();
      ModeladoBomController modelado_bom_controller = new ModeladoBomController();
      EvaluacionFormulasController evaluador_controller = new EvaluacionFormulasController();

      #endregion

      #region MODELADO DE COMPONENTES

      List<string> componentes = new List<string>();
      List<string> componentesSN = new List<string>() { "ALETA", "TRAVESANO" };
      List<string> componentesBase = new List<string>() { "MARCO LARGO", "MARCO ANCHO", "ALETA", "TRAVESANO", "ESCUADRA" };
      List<string> componentesND = new List<string>() { "MARCO LARGO EXTERNO", "MARCO ANCHO EXTERNO", "MARCO INTERIOR TOTAL", "ALETA", "TRAVESANO", "ESCUADRA", "REMACHE", "ANGULO" };
      List<string> componentesAccesorioFF = new List<string>() { "MARCO LARGO EXTERNO", "MARCO ANCHO EXTERNO", "MARCO LADO DE VISAGRA", "MARCO INTERIOR LARGO", "MARCO INTERIOR ANCHO", "ALETA.", "TRAVESANO", "TUERCA INCERTO 3/16", "ANGULO", "TORNILLO FILLIPS", "ESCUADRA", "ESCUADRA2" };
      List<string> componentesAccesorioDH = new List<string>() { "MARCO LARGO", "MARCO ANCHO", "ALETA EXTERNA", "ALETA INTERIOR", "TRAVESANO", "ESCUADRA", "OP. PLASTICO DH", "CANAL" };
      List<string> componentesAccesorioCO = new List<string>() { "MARCO LARGO", "MARCO ANCHO", "ALETA", "TRAVESANO", "ESCUADRA", "LARGUERO", "TAPA", "ALETA..", "CORREDERA", "ALAMBRE", "REMACHE", "PORTA ACTUADOR", "ACTUADOR" };
      List<string> componentesAccesorio5CO = new List<string>() { "MARCO LARGO", "MARCO ANCHO", "ALETA", "TRAVESANO", "ESCUADRA", "LARGUERO", "TAPA", "ALETA...", "CORREDERA", "ALAMBRE", "REMACHE", "PORTA ACTUADOR", "ACTUADOR" };
      List<string> componentesAccesorio8CO = new List<string>() { "MARCO LARGO", "MARCO ANCHO", "ALETA", "TRAVESANO", "ESCUADRA", "LARGUERO", "TAPA", "ALETA...", "CORREDERA", "ALAMBRE", "REMACHE", "PORTA ACTUADOR", "ACTUADOR" };
      List<string> componentesAccesorioPDR = new List<string>() { "MARCO LARGO", "MARCO ANCHO", "ALETA", "TRAVESANO", "ESCUADRA", "REMACHE.", "CUADROS GALVANI" };
      List<string> componentesAccesorioFFP = new List<string>() { "MARCO LADO VISAGRA", "MARCO LARGO EXTERNO", "MARCO ANCHO EXTERNO", "MARCO INTERIOR LARGO", "MARCO INTERIOR ANCHO", "ALETA", "TRAVESANO", "ESCUADRA", "BROCHE RECTO" };

      #endregion

      /// <summary>
      /// Metodo para obtener el listado de componentes por BOM´s
      /// </summary>
      /// <param name="codigoModelo"></param>
      /// <param name="marco"></param>
      /// <param name="accesorio"></param>
      /// <param name="cantidad"></param>
      /// <param name="largo"></param>
      /// <param name="ancho"></param>
      /// <param name="modeloCompuesto"></param>
      /// <param name="grados"></param>
      /// <returns></returns>
      public List<ComponenteModel> Get_List_Components(string codigoModelo, string marco, string accesorio, int cantidad, int largo, int ancho, string modeloCompuesto, int grados, string material)
      {
         List<ComponenteModel> lComponentes = new List<ComponenteModel>();

         switch (codigoModelo)
         {
            case "DP":
               if (marco == "ND")
               {
                  componentes = componentesND;
               }
               else if (marco == "SN")
               {
                  componentes = componentesSN;
               }
               else
               {
                  if (accesorio != "")
                  {
                     switch (accesorio)
                     {
                        case "FF":
                           componentes = componentesAccesorioFF;
                           break;
                        case "FFP":
                           componentes = componentesAccesorioFFP;
                           break;
                        case "DH":
                           componentes = componentesAccesorioDH;
                           break;
                        case "5CO":
                           componentes = componentesAccesorio5CO;
                           break;
                        case "8CO":
                           componentes = componentesAccesorio8CO;
                           break;
                        case "PDR":
                           componentes = componentesAccesorioPDR;
                           break;
                        case "CO":
                           componentes = componentesAccesorioCO;
                           break;
                        default:
                           componentes = componentesBase;
                           break;
                     }
                  }
                  else
                  {
                     componentes = componentesBase;
                  }
               }

               break;
            default:
               break;
         }

         foreach (var item in componentes)
         {
            lComponentes.Add(Get_List_Components_Bom(item, largo, ancho, cantidad, modeloCompuesto, grados, marco, accesorio, material));
            //break;
         }

         return lComponentes;
      }

      /// <summary>
      /// Metodo que obtiene la informacion global del BOM, segun sus combinacion
      /// </summary>
      /// <param name="nombre"></param>
      /// <param name="largo"></param>
      /// <param name="ancho"></param>
      /// <param name="cantidad"></param>
      /// <param name="modeloCompuesto"></param>
      /// <param name="grados"></param>
      /// <param name="marco"></param>
      /// <param name="accesorio"></param>
      /// <returns></returns>
      public ComponenteModel Get_List_Components_Bom(string nombreComponente, int largo, int ancho, int cantidad, string modeloCompuesto, int grados, string marco, string accesorio, string material)
      {
         ComponenteModel mData = new ComponenteModel();
         string itemno = string.Empty;
         string nombre = string.Empty;

         if (marco == "SN")
         {
            if (nombreComponente == "TRAVESANO")
            {
               nombre = "TRAVESAÑO";
            }
            else
            {
               nombre = nombreComponente;
            }

            itemno = dL.Get_Itemno_Article(nombre);

            if (itemno.Contains("\r\n"))
            {
               itemno = itemno.Replace("\r\n", string.Empty);
            }

            mData = Get_Info_Bom_SN(nombre, largo, ancho, cantidad, grados, material, modeloCompuesto);
         }
         else if (marco == "ND")
         {
            if (nombreComponente == "TRAVESANO")
            {
               nombre = "TRAVESAÑO";
            }
            else
            {
               nombre = nombreComponente;
            }

            itemno = dL.Get_Itemno_Article(nombre);

            if (itemno.Contains("\r\n"))
            {
               itemno = itemno.Replace("\r\n", string.Empty);
            }

            mData = Get_Info_Bom_ND(nombre, largo, ancho, cantidad, grados, material, modeloCompuesto);
         }
         else
         {
            if (marco == "" && accesorio != "")
            {
               if (nombreComponente == "TRAVESANO")
               {
                  nombre = "TRAVESAÑO";
               }
               else
               {
                  nombre = nombreComponente;
               }

               itemno = dL.Get_Itemno_Article(nombre);

               if (itemno.Contains("\r\n"))
               {
                  itemno = itemno.Replace("\r\n", string.Empty);
               }

               mData = Get_Info_Bom_OA(nombre, largo, ancho, cantidad, accesorio, grados, material, modeloCompuesto);
            }
            else if (marco != "" && accesorio != "")
            {
               if (nombreComponente == "TRAVESANO")
               {
                  nombre = "TRAVESAÑO";
               }
               else
               {
                  nombre = nombreComponente;
               }

               itemno = dL.Get_Itemno_Article(nombre);

               if (itemno.Contains("\r\n"))
               {
                  itemno = itemno.Replace("\r\n", string.Empty);
               }

               mData = Get_Info_Bom_WA(nombre, largo, ancho, cantidad, marco, accesorio, grados, material, modeloCompuesto);
            }
            else
            {
               if (nombreComponente == "TRAVESANO")
               {
                  nombre = "TRAVESAÑO";
               }
               else
               {
                  nombre = nombreComponente;
               }

               itemno = dL.Get_Itemno_Article(nombre);

               if (itemno.Contains("\r\n"))
               {
                  itemno = itemno.Replace("\r\n", string.Empty);
               }

               mData = Get_Info_Bom_WOA(nombre, largo, ancho, cantidad, marco, grados, material, modeloCompuesto);
            }
         }

         return mData;
      }

      /// <summary>
      /// Funcion para obtener las formulas especificas de los BOM´s SN
      /// </summary>
      /// <param name="nombre"></param>
      /// <param name="largo"></param>
      /// <param name="ancho"></param>
      /// <param name="cantidad"></param>
      /// <returns></returns>
      public ComponenteModel Get_Info_Bom_SN(string nombre, int largo, int ancho, int cantidad, int grados, string material, string modeloCompuesto)
      {
         ComponenteModel mData = new ComponenteModel();
         string error = string.Empty;
         double formulaMedia = 0;
         double formulaCantidad = 0;
         string codigo = string.Empty;
         string clase = string.Empty;

         try
         {
            clase = componentDL.Get_Class(nombre, material);
            codigo = componentDL.Get_Codigo(nombre, material);
            material = codigo;

            if (material.Contains("\r\n"))
            {
               material = material.Replace("\r\n", string.Empty);
            }

            switch (nombre)
            {
               case "ALETA":
                  mData.nombre = nombre;
                  formulaCantidad = (ancho * 2) - 2;
                  mData.cantidad = Get_Quantity_Bom(modeloCompuesto, cantidad, largo, ancho, grados);
                  formulaMedia = largo - 0.25;
                  mData.medida = formulaMedia;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "TRAVESAÑO":
                  mData.nombre = nombre;

                  if (largo <= 20)
                  {
                     formulaCantidad = (cantidad * 3);
                  }

                  mData.cantidad = formulaCantidad;

                  if (largo >= 9.5)
                  {
                     formulaMedia = ancho - 0.25 + (0.50);
                  }

                  mData.medida = formulaMedia;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
            }
         }
         catch (System.Exception ex)
         {
            error = ex.Message;
         }

         return mData;
      }

      /// <summary>
      /// Funcion para obtener las formulas especificas de los BOM´s ND
      /// </summary>
      /// <param name="nombre"></param>
      /// <param name="largo"></param>
      /// <param name="ancho"></param>
      /// <param name="cantidad"></param>
      /// <returns></returns>
      public ComponenteModel Get_Info_Bom_ND(string nombre, int largo, int ancho, int cantidad, int grados, string material, string modeloCompuesto)
      {
         ComponenteModel mData = new ComponenteModel();
         string error = string.Empty;
         double formulaMedia = 0;
         double formulaCantidad = 0;
         string codigo = string.Empty;
         string clase = string.Empty;

         try
         {
            clase = componentDL.Get_Class(nombre, material);
            codigo = componentDL.Get_Codigo(nombre, material);
            material = codigo;

            if (material.Contains("\r\n"))
            {
               material = material.Replace("\r\n", string.Empty);
            }

            switch (nombre)
            {
               case "MARCO LARGO EXTERNO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = largo + (1 + (0.75));
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "MARCO ANCHO EXTERNO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = ancho + (1 + (0.75));
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "MARCO INTERIOR TOTAL":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 1;
                  mData.medida = ((largo - 0.50) + (ancho - (0.50))) * 2;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "ALETA":
                  mData.nombre = nombre;
                  mData.cantidad = Get_Quantity_Bom(modeloCompuesto, cantidad, largo, ancho, grados);
                  mData.medida = largo - 0.75;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "TRAVESAÑO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;

                  if (largo >= 9.5)
                  {
                     formulaMedia = ancho;
                  }
                  else
                  {
                     formulaMedia = ancho + 0.25;
                  }
                  mData.Numero_Parte = material;
                  mData.medida = formulaMedia;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "REMACHE":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = 0;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "ANGULO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 1;
                  mData.medida = 2;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "ESCUADRA":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 4;
                  mData.medida = 0.75;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
            }
         }
         catch (System.Exception ex)
         {
            error = ex.Message;
         }

         return mData;
      }

      /// <summary>
      /// Funcion para obtener las formulas espeficicas de los BOM´s
      /// </summary>
      /// <param name="nombre"></param>
      /// <param name="largo"></param>
      /// <param name="ancho"></param>
      /// <param name="cantidad"></param>
      /// /// <param name="marco"></param>
      /// <returns></returns>
      public ComponenteModel Get_Info_Bom_WOA(string nombre, int largo, int ancho, int cantidad, string marco, int grados, string material, string modeloCompuesto)
      {
         ComponenteModel mData = new ComponenteModel();
         string error = string.Empty;
         double formulaMarcoLargo = 0;
         double formulaMarcoAncho = 0;
         double formulaAleta = 0;
         double formulaTravesano = 0;
         double formulaEscuadra = 0;
         string codigo = string.Empty;
         string clase = string.Empty;
         double formularCantidades = 0;

         try
         {
            clase = componentDL.Get_Class(nombre, material);
            codigo = componentDL.Get_Codigo(nombre, material);
            material = codigo;

            if (material.Contains("\r\n"))
            {
               material = material.Replace("\r\n", string.Empty);
            }

            if (marco == "10")
            {
               formulaMarcoLargo = largo + (1 + (0.50) - (0.25));
               formulaMarcoAncho = ancho + (1 + (0.50) - (0.25));
               formulaAleta = largo - 0.375;

               if (largo >= 9.5)
               {
                  formulaTravesano = ancho - (0.25) + (0.50);
               }

               formulaEscuadra = 0.75;
            }
            else if (marco == "12")
            {
               formulaMarcoLargo = largo - (0.50) + 1;
               formulaMarcoAncho = ancho - (0.6875) + 1;
               formulaAleta = largo - (0.50);

               if (largo >= 9.5)
               {
                  formulaTravesano = ancho - (0.6875) + (0.50);
               }

               formulaEscuadra = 0.375;
            }
            else if (marco == "15")
            {
               formulaMarcoLargo = largo + 2 * (1.5) - (0.75);
               formulaMarcoAncho = ancho + (2 + (0.50) - (0.25));
               formulaAleta = largo - (0.375);

               if (largo >= 9.5)
               {
                  formulaTravesano = ancho - (0.25) + (0.50);
               }

               formulaEscuadra = 0.75;
            }
            else if (marco == "L")
            {
               formulaMarcoLargo = largo + (2 + (0.25) - (0.25));
               formulaMarcoAncho = ancho + (2 + (0.25) - (0.25));
               formulaAleta = largo - (0.375);

               if (largo >= 9.5)
               {
                  formulaTravesano = ancho - (0.25) + (0.50);
               }

               formulaEscuadra = 0.75;
            }

            switch (nombre)
            {
               case "MARCO LARGO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = formulaMarcoLargo;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "MARCO ANCHO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = formulaMarcoAncho;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "ALETA":
                  mData.nombre = nombre;
                  mData.cantidad = Get_Quantity_Bom(modeloCompuesto, cantidad, largo, ancho, grados);
                  mData.medida = formulaAleta;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "TRAVESAÑO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 3;
                  mData.medida = formulaTravesano;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "ESCUADRA":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 4;
                  mData.medida = formulaEscuadra;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
            }
         }
         catch (System.Exception ex)
         {
            error = ex.Message;
         }

         return mData;
      }

      /// <summary>
      /// Funcion para obtener las formulas especificas de los BOM´s, pero solo para los que contienen Accesorio
      /// </summary>
      /// <param name="nombre"></param>
      /// <param name="largo"></param>
      /// <param name="ancho"></param>
      /// <param name="cantidad"></param>
      /// <param name="marco"></param>
      /// <param name="accesorio"></param>
      /// <returns></returns>
      public ComponenteModel Get_Info_Bom_WA(string nombre, int largo, int ancho, int cantidad, string marco, string accesorio, int grados, string material, string modeloCompuesto)
      {
         ComponenteModel mData = new ComponenteModel();
         string error = string.Empty;
         double formulaMarcoLargo = 0;
         double formulaMarcoAncho = 0;
         double formulaAleta = 0;
         double formulaTravesano = 0;
         double formulaEscuadra = 0;
         double formulaLarguero = 0;
         double formulaTapa = 0;
         double formulaAleta440 = 0;
         double formulaAlambre = 0;
         double formulaCorredera = 0;
         double formulaRemache = 0;
         double formulaPA = 0;
         double formulaA = 0;
         double formulaAlambrePeso = 0;
         double cantidades = 0;
         double cantidades1 = 0;
         double perfil58CO = 0;
         double perfil = 0;
         double totales = 0;
         string codigo = string.Empty;
         string clase = string.Empty;

         const double WIRE16 = 0.0042875;
         const double WIRE18 = 0.00024232;
         const double WIRE20 = 0.00012471;
         const double WIRE24 = 0.00004953;


         try
         {
            clase = componentDL.Get_Class(nombre, material);
            codigo = componentDL.Get_Codigo(nombre, material);
            material = codigo;

            if (material.Contains("\r\n"))
            {
               material = material.Replace("\r\n", string.Empty);
            }

            switch (material)
            {
               case "WIRE16":
                  formulaAlambrePeso = (WIRE16) * ((cantidad * 2) * (largo) / 2);
                  break;
               case "WIRE18":
                  formulaAlambrePeso = (WIRE18) * ((cantidad * 2) * (largo) / 2);
                  break;
               case "WIRE20":
                  formulaAlambrePeso = (WIRE20) * ((cantidad * 2) * (largo) / 2);
                  break;
               case "WIRE24":
                  formulaAlambrePeso = (WIRE24) * ((cantidad * 2) * (largo) / 2);
                  break;
            }

            if (marco == "10")
            {
               switch (accesorio)
               {
                  case "CO":
                     formulaMarcoLargo = largo + (1 + (0.50) - (0.25));
                     formulaMarcoAncho = ancho + (1 + (0.50) - (0.25));
                     formulaAleta = largo - 0.375;

                     if (largo >= 9.5)
                     {
                        formulaTravesano = ancho - (0.25) + (0.50);
                     }

                     formulaEscuadra = 0.75;
                     formulaLarguero = largo - 0.25;
                     formulaTapa = formulaMarcoAncho - (2 * (0.75)) - (2 * (0.1875)) + (0.50);
                     formulaAleta440 = ancho - 1 + 0.75;
                     formulaCorredera = 8.75;
                     formulaAlambre = largo;
                     formulaRemache = 0;
                     formulaPA = 0.6;
                     formulaA = 0;
                     cantidades1 = 0; perfil = 240;
                     break;
                  case "5CO":
                     formulaMarcoLargo = largo + (1 + (0.50) - (0.25));
                     formulaMarcoAncho = ancho + (1 + (0.50) - (0.25));
                     formulaAleta = largo - 0.375;

                     if (largo >= 9.5)
                     {
                        formulaTravesano = ancho - (0.25) + (0.50);
                     }

                     formulaEscuadra = 0.75;
                     formulaLarguero = largo - 0.25;
                     formulaTapa = formulaMarcoAncho - (2 * (0.75)) - (2 * (0.1875)) + (0.50);
                     formulaAleta440 = ancho - 1 + 0.75;
                     formulaCorredera = 8.75;
                     formulaAlambre = largo;
                     formulaRemache = 0;
                     formulaPA = 0.6;
                     formulaA = 0;
                     cantidades1 = 0; perfil = 236;
                     break;
                  case "8CO":
                     formulaMarcoLargo = largo + (1 + (0.5) - (0.25));
                     formulaMarcoAncho = ancho + (1 + (0.5) - (0.25));
                     formulaAleta = largo - 0.375;

                     if (largo >= 9.5)
                     {
                        formulaTravesano = ancho - (0.25) + (0.50);
                     }

                     formulaEscuadra = 0.75;
                     formulaLarguero = (largo - 0.25) / 2;
                     formulaTapa = (ancho - (0.5625) + (0.2 + 0.2)) / 2;
                     formulaAleta440 = (ancho - 1 + 0.75) / 2;
                     formulaCorredera = (largo - 1.25) / 2;
                     formulaAlambre = largo / 2;
                     formulaRemache = 0;
                     formulaPA = 0.6;
                     formulaA = 0;
                     cantidades = 8;
                     cantidades1 = 4; perfil = 236;
                     break;
                  case "PDR":
                     formulaMarcoLargo = largo + (1 + (0.50) - (0.25));
                     formulaMarcoAncho = ancho + 1.5;
                     formulaAleta = largo - 0.375;

                     if (largo >= 9.5)
                     {
                        formulaTravesano = ancho - (0.25) + (0.50);
                     }

                     formulaEscuadra = 0.75;
                     formulaAlambre = 0;
                     formulaRemache = 0;
                     break;
               }
            }
            else if (marco == "12")
            {
               switch (accesorio)
               {
                  case "CO":
                     formulaMarcoLargo = largo - (0.50) + 1;
                     formulaMarcoAncho = ancho - (0.6875) + 1;
                     formulaAleta = largo - 0.50;

                     if (largo >= 9.5)
                     {
                        formulaTravesano = ancho - (0.6875) + (0.50);
                     }

                     formulaEscuadra = 0.375;
                     formulaLarguero = largo - 0.25;
                     formulaTapa = formulaMarcoAncho - (2 * (0.75)) - (2 * (0.1875)) + (0.50);
                     formulaAleta440 = ancho - 1 + 0.75;
                     formulaCorredera = 8.75;
                     formulaAlambre = largo;
                     formulaRemache = 0;
                     formulaPA = 0.6;
                     formulaA = 0;
                     break;
                  case "5CO":
                     formulaMarcoLargo = largo - (0.25) + 1;
                     formulaMarcoAncho = ancho - (0.6875) + 1;
                     formulaAleta = largo - 0.50;

                     if (largo >= 9.5)
                     {
                        formulaTravesano = ancho - (0.6875) + (0.50);
                     }

                     formulaEscuadra = 0.375;
                     formulaLarguero = largo - 0.25;
                     formulaTapa = formulaMarcoAncho - (2 * (0.75)) - (2 * (0.1875)) + (0.50);
                     formulaAleta440 = ancho - 1 + 0.75;
                     formulaCorredera = 8.75;
                     formulaAlambre = largo;
                     formulaRemache = 0;
                     formulaPA = 0.6;
                     formulaA = 0; perfil = 236;
                     break;
                  case "8CO":
                     formulaMarcoLargo = largo - (0.5) + 1;
                     formulaMarcoAncho = ancho - 0.6875 + 1;
                     formulaAleta = largo - 0.375;

                     if (largo >= 9.5)
                     {
                        formulaTravesano = ancho - (0.25) + (0.50);
                     }

                     formulaEscuadra = 0.75;
                     formulaLarguero = (largo - 0.25) / 2;
                     formulaTapa = (ancho - (0.5625) + (0.2 + 0.2)) / 2;
                     formulaAleta440 = (ancho - 1 + 0.75) / 2;
                     formulaCorredera = (largo - 1.25) / 2;
                     formulaAlambre = largo / 2;
                     formulaRemache = 0;
                     formulaPA = 0.6;
                     formulaA = 0;
                     cantidades = 8;
                     cantidades1 = 4; perfil = 236;
                     break;
               }
            }
            else if (marco == "15")
            {
               switch (accesorio)
               {
                  case "CO":
                     formulaMarcoLargo = largo + 2 * (1.5) - (0.75);
                     formulaMarcoAncho = ancho + (2 + (0.50) - (0.25));
                     formulaAleta = largo - 0.375;

                     if (largo >= 9.5)
                     {
                        formulaTravesano = ancho - (0.25) + (0.50);
                     }

                     formulaEscuadra = 0.75;
                     formulaLarguero = largo - 0.25;
                     formulaTapa = formulaMarcoAncho - (2 * (0.75)) - (2 * (0.1875)) + (0.50);
                     formulaAleta440 = ancho - 1 + 0.75;
                     formulaCorredera = 8.75;
                     formulaAlambre = largo;
                     formulaRemache = 0;
                     formulaPA = 0.6;
                     formulaA = 0;
                     break;
                  case "5CO":
                     formulaMarcoLargo = largo + 2 * (1.5) - (0.75);
                     formulaMarcoAncho = ancho + (2 + (0.50) - (.25));
                     formulaAleta = largo - 0.375;

                     if (largo >= 9.5)
                     {
                        formulaTravesano = ancho - (0.25) + (0.50);
                     }

                     formulaEscuadra = 0.375;
                     formulaLarguero = largo - 0.25;
                     formulaTapa = formulaMarcoAncho - (2 * (0.75)) - (2 * (0.1875)) + (0.50);
                     formulaAleta440 = ancho - 1 + 0.75;
                     formulaCorredera = 8.75;
                     formulaAlambre = largo;
                     formulaRemache = 0;
                     formulaPA = 0.6;
                     formulaA = 0;
                     perfil = 236;
                     break;
                  case "8CO":
                     formulaMarcoLargo = largo + 2 * (1.5) - (0.75);
                     formulaMarcoAncho = ancho + (2 + (0.50) - (0.25));
                     formulaAleta = largo - 0.375;

                     if (largo >= 9.5)
                     {
                        formulaTravesano = ancho - (0.25) + (0.50);
                     }

                     formulaEscuadra = 0.75;
                     formulaLarguero = (largo - 0.25) / 2;
                     formulaTapa = (ancho - (0.5625) + (0.2 + 0.2)) / 2;
                     formulaAleta440 = (ancho - 1 + 0.75) / 2;
                     formulaCorredera = (largo - 1.25) / 2;
                     formulaAlambre = largo / 2;
                     formulaRemache = 0;
                     formulaPA = 0.6;
                     formulaA = 0;
                     cantidades = 8;
                     cantidades1 = 4; perfil = 236;
                     break;
               }
            }
            else if (marco == "L")
            {
               switch (accesorio)
               {
                  case "CO":
                     formulaMarcoLargo = largo + (2 + (0.25) - (0.25));
                     formulaMarcoAncho = ancho + (2 + (0.25) - (0.25));
                     formulaAleta = largo - 0.375;

                     if (largo >= 9.5)
                     {
                        formulaTravesano = ancho - (0.25) + (0.50);
                     }

                     formulaEscuadra = 0.75;
                     formulaLarguero = largo - 0.25;
                     formulaTapa = formulaMarcoAncho - (2 * (0.75)) - (2 * (0.1875) + (0.50));
                     formulaAleta440 = ancho - 1 + 0.75;
                     formulaCorredera = 8.75;
                     formulaAlambre = largo;
                     formulaRemache = 0;
                     formulaPA = 0.6;
                     formulaA = 0;
                     break;
               }
            }

            switch (nombre)
            {
               case "MARCO LARGO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = formulaMarcoLargo;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "MARCO ANCHO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = formulaMarcoAncho;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "ALETA":
                  mData.nombre = nombre;
                  mData.cantidad = Get_Quantity_Bom(modeloCompuesto, cantidad, largo, ancho, grados);
                  mData.medida = formulaAleta;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "TRAVESAÑO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * cantidades1;
                  mData.medida = formulaTravesano;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "ESCUADRA":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2 * 2;
                  mData.medida = formulaEscuadra;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "LARGUERO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * cantidades;
                  mData.medida = formulaLarguero;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / perfil;
                  mData.Class = clase;
                  break;
               case "TAPA":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * cantidades;
                  mData.medida = formulaTapa;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / perfil;
                  mData.Class = clase;
                  break;
               case "ALETA..":
                  mData.nombre = nombre;
                  mData.cantidad = largo - 1;
                  mData.medida = formulaAleta440;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / perfil;
                  mData.Class = clase;
                  break;
               case "ALETA...":
                  mData.nombre = nombre;
                  mData.cantidad = largo - 1;
                  mData.medida = formulaAleta440;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / perfil;
                  mData.Class = clase;
                  break;
               case "CORREDERA":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 4;
                  mData.medida = formulaCorredera;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / perfil;
                  mData.Class = clase;
                  break;
               case "ALAMBRE":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = formulaAlambre;
                  mData.Numero_Parte = material;
                  mData.total_perfil = 0;
                  mData.Peso_Kg = formulaAlambrePeso;
                  mData.Class = clase;
                  break;
               case "REMACHE":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2 * 2;
                  mData.medida = formulaRemache;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "PORTA ACTUADOR":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 1;
                  mData.medida = formulaPA;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "ACTUADOR":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 1;
                  mData.medida = formulaA;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "CUADROS GALVANI":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = formulaAlambre;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "REMACHE.":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 6;
                  mData.medida = formulaRemache;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
            }
         }
         catch (System.Exception ex)
         {
            error = ex.Message;
         }

         return mData;
      }

      /// <summary>
      /// Funcion para obtener la informacion especifica de los BOM´s pero sin marco
      /// </summary>
      /// <param name="nombre"></param>
      /// <param name="largo"></param>
      /// <param name="ancho"></param>
      /// <param name="cantidad"></param>
      /// <param name="accesorio"></param>
      /// <returns></returns>
      public ComponenteModel Get_Info_Bom_OA(string nombre, int largo, int ancho, int cantidad, string accesorio, int grados, string material, string modeloCompuesto)
      {
         ComponenteModel mData = new ComponenteModel();
         string error = string.Empty;
         double formulaMarcoExternoLargo = 0;
         double formulaMarcoExternoAncho = 0;
         double formulaMarcoInteriorLargo = 0;
         double formulaMarcoInteriorAncho = 0;
         double formulaMarcoInteriorVisagra = 0;
         double formulaAleta = 0;
         double formulaTravesano = 0;
         double formulaEscuadra = 0;
         double formulaEscuadra2 = 0;
         double formulaTuerca = 0;
         double formulaAngulo = 0;
         double formulaTornillo = 0;
         double formulaBroche = 0;
         double formulaCantidad = 0;
         int cantidadArticulo = 0;
         int cantidadArticuloFF = 0;
         string codigo = string.Empty;
         string clase = string.Empty;

         try
         {
            clase = componentDL.Get_Class(nombre, material);
            codigo = componentDL.Get_Codigo(nombre, material);
            material = codigo;

            if (material.Contains("\r\n"))
            {
               material = material.Replace("\r\n", string.Empty);
            }

            switch (accesorio)
            {
               case "FF":
                  formulaMarcoExternoLargo = largo - (0.375) + 2 * ((0.75) + (0.03125));
                  formulaMarcoExternoAncho = ancho - (0.375) + 2 * ((0.75) + (0.03125));
                  formulaMarcoInteriorVisagra = largo - (1) + 2 * ((0.75) + (0.03125));
                  formulaMarcoInteriorLargo = largo - (1) + 2 * ((0.75) + (0.03125));
                  formulaMarcoInteriorAncho = ancho - (1) + 2 * ((0.75) + (0.03125));
                  formulaAleta = largo - 1;

                  if (largo >= 9.5)
                  {
                     formulaTravesano = ancho - 0.25 - 0.25;
                  }

                  formulaEscuadra = 1.55;
                  formulaTuerca = 0;
                  formulaAngulo = largo - 3;
                  formulaTornillo = 0;
                  formulaEscuadra2 = 0.75;
                  cantidadArticuloFF = cantidad * 1;
                  cantidadArticulo = cantidad * 8;
                  break;
               case "FFP":
                  formulaMarcoInteriorVisagra = largo - (0.96875) + (0.3125);
                  formulaMarcoExternoLargo = ancho - (0.96875) + (0.3125);
                  formulaMarcoExternoAncho = ancho - 1 - (0.375);
                  formulaMarcoInteriorAncho = ancho - 1 - (0.375);
                  formulaMarcoInteriorLargo = largo - 1 - (0.375);

                  if (grados != 0)
                  {
                     formulaAleta = largo - (0.9375);

                     if (largo >= 9.5)
                     {
                        formulaTravesano = ancho - 0.25 - 0.25;
                     }
                  }
                  else
                  {
                     formulaAleta = largo - 4 + (0.9375) + (0.03125);

                     if (largo >= 9.5)
                     {
                        formulaTravesano = ancho - 3;
                     }
                  }

                  formulaEscuadra = 0.75;
                  formulaBroche = 0;
                  cantidadArticuloFF = cantidad * 2;
                  cantidadArticulo = cantidad * 12;
                  break;
               case "DH":
                  // Marco largo
                  formulaMarcoExternoLargo = largo - (0.375) + 2;
                  // Marco ancho
                  formulaMarcoExternoAncho = ancho - (0.50) + 2;
                  // Aleta exterior
                  formulaMarcoInteriorAncho = largo - (0.375);
                  // Aleta interior
                  formulaMarcoInteriorLargo = ancho - (0.50) + (0.25) + (0.125);

                  if (largo >= 9.5)
                  {
                     formulaTravesano = ancho - (0.50) + (0.50);
                  }

                  formulaEscuadra = 0.75;
                  // Plastico DH
                  formulaEscuadra2 = 0;

                  // Canal
                  if (cantidad >= 2)
                  {
                     formulaBroche = 8.5 / 2;
                  }
                  else
                  {
                     formulaBroche = 8.5;
                  }

                  cantidadArticulo = cantidad * 4;

                  break;
            }

            switch (nombre)
            {
               case "MARCO LARGO EXTERNO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = formulaMarcoExternoLargo;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "MARCO ANCHO EXTERNO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = formulaMarcoExternoAncho;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "MARCO INTERIOR VISAGRA":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 1;
                  mData.medida = formulaMarcoInteriorVisagra;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "MARCO INTERIOR LARGO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidadArticuloFF;
                  mData.medida = formulaMarcoInteriorLargo;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "MARCO INTERIOR ANCHO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = formulaMarcoInteriorAncho;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "ALETA":
                  mData.nombre = nombre;
                  mData.cantidad = Get_Quantity_Bom(modeloCompuesto, cantidad, largo, ancho, grados);
                  mData.medida = formulaAleta;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "TRAVESAÑO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = formulaTravesano;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "TUERCA INCERTO 3/16":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 4;
                  mData.medida = formulaTuerca;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "ANGULO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = formulaAngulo;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "TORNILLO FILLIPS":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 4;
                  mData.medida = formulaTornillo;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "ESCUADRA":
                  mData.nombre = nombre;
                  mData.cantidad = cantidadArticulo;
                  mData.medida = formulaEscuadra;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "ESCUADRA2":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 4;
                  mData.medida = formulaEscuadra2;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "MARCO LADO DE VISAGRA":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 1;
                  mData.medida = formulaMarcoInteriorVisagra;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "BROCHE RECTO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 1;
                  mData.medida = formulaBroche;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "MARCO LARGO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = formulaMarcoExternoLargo;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "MARCO ANCHO":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 2;
                  mData.medida = formulaMarcoExternoAncho;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "ALETA EXTERNA":
                  mData.nombre = nombre;
                  mData.cantidad = ((ancho * 2) - 2) * cantidad;
                  mData.medida = formulaMarcoInteriorAncho;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "ALETA INTERIOR":
                  mData.nombre = nombre;
                  mData.cantidad = Math.Truncate((formulaMarcoExternoLargo - 2) / (0.75));
                  mData.Class = clase;
                  mData.medida = formulaMarcoInteriorLargo;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "OP. PLASTICO DH":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 1;
                  mData.medida = formulaEscuadra2;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
               case "CANAL":
                  mData.nombre = nombre;
                  mData.cantidad = cantidad * 1;
                  mData.medida = formulaBroche;
                  mData.Numero_Parte = material;
                  mData.total_perfil = (mData.cantidad * mData.medida) / 240;
                  mData.Class = clase;
                  break;
            }
         }
         catch (System.Exception ex)
         {
            error = ex.Message;
         }

         return mData;
      }

      public double Get_Quantity_Bom(string pCombination, int pQty, int pLargo, int pAncho, int pGrados)
      {
         double resultQty = 0;
         string[] modelComplete;
         string[] modelBase = null;
         modelComplete = pCombination.Split('-');

         if (modelComplete[0].Contains("0"))
         {
            modelBase = modelComplete[0].Split('0');
         }
         else if (modelComplete[0].Contains("5"))
         {
            modelBase = modelComplete[0].Split('5');
         }

         switch (modelBase[0])
         {
            case "DP1412":
               if (pGrados == 0)
               {
                  resultQty = ((pAncho * 2) - 2) * pQty;
               }
               else if (pGrados == 5)
               {
                  resultQty = ((pAncho * 2) - 2) * pQty;
               }

               break;
            case "DP1812":
               if (pGrados == 0)
               {

               }
               else if (pGrados == 5)
               {

               }

               break;
            case "DP1838":
               if (pGrados == 0)
               {
                  resultQty = ((pAncho * 3) - 2) * pQty;
               }
               else if (pGrados == 5)
               {
                  resultQty = ((pAncho * 3) - 3) * pQty;
               }

               break;
            case "DP1423":
               if (pGrados == 0)
               {
                  resultQty = ((pAncho * 1.5) - 2) * pQty;
               }
               else if (pGrados == 5)
               {
                  resultQty = ((pAncho * 1.5) - 2) * pQty;
               }

               break;
            case "DP1823":
               if (pGrados == 0)
               {
                  resultQty = ((pAncho * 1.5) - 2) * pQty;
               }
               else if (pGrados == 5)
               {
                  resultQty = ((pAncho * 1.5) - 2) * pQty;
               }

               break;
            default:
               break;
         }

         return resultQty;
      }

      /// <summary>
      /// Metodo para obtener la lista de componentes del bom de sql
      /// </summary>
      /// <param name="modelCompleteBom">Nombre del bom (combinacion)</param>
      /// <param name="finishes">Acabados</param>
      /// <param name="large">Medida de largo</param>
      /// <param name="width">Medida de ancho</param>
      /// <param name="qty">Cantidad de bom</param>
      /// <param name="errorMetohd">Mensaje de error en caso de alguna excepcion</param>
      /// <returns>Arrelgo de lista componentes</returns>
      public List<ComponenteModel> GetListComponent(string modelCompleteBom, string finishes, int large, int width, int qty, out string errorMetohd)
      {
         List<ComponenteModel> data_list_componets = new List<ComponenteModel>();
         List<ModeladoBomModel> data_list_modeling = new List<ModeladoBomModel>();
         string error = string.Empty;

         try
         {
            data_list_modeling = modelado_bom_controller.GetBomModels(modelCompleteBom, finishes, out error);

            if (data_list_modeling.Count != 0)
            {
               foreach (var item in data_list_modeling)
               {
                  data_list_componets.Add(GetDataComponents(item.Itemno, item.Class, item.Nombre_Componente, item.FormulaQty, item.FormulaMd, item.FormulaTotal, large, width, qty, out error));
               }
            }
         }
         catch (Exception ex)
         {
            error = ex.Message;
            data_list_componets = null;
         }

         errorMetohd = error;
         return data_list_componets;
      }

      /// <summary>
      /// Metodo de obtencion de informacion del componente
      /// </summary>
      /// <param name="itemno">Numero de parte</param>
      /// <param name="classes">Clase del componente</param>
      /// <param name="nameComponent">Nombre del componente</param>
      /// <param name="formulaQty">Formula de cantidad para el componente</param>
      /// <param name="formulaMd">Formula de medidas para el componente</param>
      /// <param name="formulaTotal">Formula del total del componente</param>
      /// <param name="large">Medida del largo</param>
      /// <param name="width">Medida del ancho</param>
      /// <param name="qty">Cantidad de boms</param>
      /// <param name="errorMetohd">Mensaje de error en caso de alguna excepcion</param>
      /// <returns>Modelo completo con su informacion pertinente</returns>
      public ComponenteModel GetDataComponents(string itemno, string pClass, string nameComponent, string formulaQty, string formulaMd, string formulaTotal, int large, int width, int qty, out string errorMetohd)
      {
         List<string> data_list_values_qty_md = new List<string>();
         List<string> data_list_values_total = new List<string>();
         ComponenteModel data_model = new ComponenteModel();
         double resultQty = 0;
         double resultMd = 0;
         double resultTotal = 0;
         string error = string.Empty;

         try
         {
            data_list_values_qty_md = new List<string> { large.ToString(), width.ToString(), qty.ToString() };

            //resultQty = evaluador_controller.ExecuteFormula(formulaQty, data_list_values_qty_md, out error);
            //resultMd = evaluador_controller.ExecuteFormula(formulaMd, data_list_values_qty_md, out error);

            data_list_values_total = new List<string> { resultQty.ToString(), resultMd.ToString() };
            //resultTotal = evaluador_controller.ExecuteFormula(formulaTotal, data_list_values_total, out error);

            data_model.Numero_Parte = itemno;
            data_model.nombre = nameComponent;
            data_model.Class = pClass;
            data_model.cantidad = System.Convert.ToDouble(resultQty);
            data_model.medida = System.Convert.ToDouble(resultMd);
            data_model.total_perfil = System.Convert.ToDouble(resultTotal);
         }
         catch (Exception ex)
         {
            error = ex.Message;
            data_model = null;
         }

         errorMetohd = error;
         return data_model;
      }
   }
}

