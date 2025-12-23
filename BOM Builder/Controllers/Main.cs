using System.Collections.Generic;
using BOM_Builder.Models;

namespace BOM_Builder
{
    public class Main
    {
        List<string> componentesHR = new List<string> { "Marco Largo", "Marco Ancho", "Aleta", "Travesaño", "Escuadra", "Alambre" };
        List<string> componentesSG = new List<string> { "Marco Largo", "Marco Ancho", "Aleta Vertical", "Aleta Horizontal", "Travesaño Vertical", "Travesaño Horizontal", "Escuadra" };

        public ComponenteModel GetComponentHR(string nombre, long cantidad, long largo, long ancho)
        {
            ComponenteModel componente = new ComponenteModel();

            switch (nombre)
            {
                case "Marco Largo":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.HR_perfil_marcos;//"10331";
                    componente.cantidad = cantidad * 2;
                    componente.medida = largo - 0.75;
                    componente.total_perfil = ((componente.cantidad * (largo + 1.75))) / 240;
                    break;

                case "Marco Ancho":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.HR_perfil_marcos;//"10331"
                    componente.cantidad = cantidad * 2;
                    componente.medida = ancho - 0.75;
                    componente.total_perfil = ((componente.cantidad * (ancho + 1.75))) / 240;
                    break;

                case "Aleta":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.HR_perfil_aleta;//"69052";
                    componente.cantidad = (ancho - 1) * cantidad;
                    componente.medida = largo - 0.25;
                    componente.total_perfil = (componente.cantidad * componente.medida) / 240;
                    break;

                case "Travesaño":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.HRP_perfil_travesaño;//"17978";
                    componente.cantidad = (int)(largo / 16.25) * cantidad;

                    if (largo > 16.25)
                    {
                        componente.medida = ancho - 0.25;
                    }
                    else
                    {
                        componente.medida = 0;
                    }

                    componente.total_perfil = (componente.cantidad * componente.medida) / 240;
                    break;

                case "Escuadra":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.HR_perfil_escuadra;//"10185";
                    componente.cantidad = 4;
                    componente.medida = 1;
                    componente.total_perfil = (componente.cantidad * componente.medida) / 240;
                    break;

                case "Alambre":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.HR_alambre;//"CAL20";
                    componente.cantidad = 2;
                    componente.medida = ancho;
                    componente.total_perfil = (componente.cantidad * componente.medida) * 0.0254 * 0.005;
                    break;
            }

            return componente;
        }

        public ComponenteModel GetComponentHRP(string nombre, long cantidad, long largo, long ancho)
        {
            ComponenteModel componente = new ComponenteModel();

            switch (nombre)
            {
                case "Marco Largo":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.HRP_perfil_marcos;//"10331";
                    componente.cantidad = cantidad * 2;
                    componente.medida = largo - 1.25;
                    componente.total_perfil = ((componente.cantidad * (largo + 1.75))) / 240;
                    break;

                case "Marco Ancho":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.HRP_perfil_marcos;//"10331";
                    componente.cantidad = cantidad * 2;
                    componente.medida = ancho - 0.75;
                    componente.total_perfil = ((componente.cantidad * (ancho + 1.75))) / 240;
                    break;

                case "Aleta":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.HRP_perfil_aleta;//"69052";
                    componente.cantidad = (ancho - 1) * cantidad;
                    componente.medida = largo - 0.25;
                    componente.total_perfil = (componente.cantidad * componente.medida) / 240;
                    break;

                case "Travesaño":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.HRP_perfil_travesaño;//"17978";
                    componente.cantidad = (int)(largo / 16.25) * cantidad;

                    if (largo > 16.25)
                    {
                        componente.medida = ancho - 0.25;
                    }
                    else
                    {
                        componente.medida = 0;
                    }

                    componente.total_perfil = (componente.cantidad * componente.medida) / 240;
                    break;

                case "Escuadra":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.HRP_perfil_escuadra;//"10185";
                    componente.cantidad = 4;
                    componente.medida = 1;
                    componente.total_perfil = (componente.cantidad * componente.medida) / 240;
                    break;

                case "Alambre":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.HRP_alambre;//"CAL20";
                    componente.cantidad = 2;
                    componente.medida = ancho;
                    componente.total_perfil = (componente.cantidad * componente.medida) * 0.0254 * 0.005;
                    break;
            }

            return componente;
        }

        public ComponenteModel GetComponentSG(string nombre, long cantidad, long largo, long ancho)
        {
            ComponenteModel componente = new ComponenteModel();

            switch (nombre)
            {
                case "Marco Largo":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.SG_perfil_marcos;
                    componente.cantidad = cantidad * 2;
                    componente.medida = largo - 0.75;
                    componente.total_perfil = ((componente.cantidad * (largo + 1.75))) / 240;
                    break;

                case "Marco Ancho":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.SG_perfil_marcos;
                    componente.cantidad = cantidad * 2;
                    componente.medida = largo - 0.75;
                    componente.total_perfil = ((componente.cantidad * (largo + 1.75))) / 240;
                    break;

                case "Aleta Vertical":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.SG_perfil_aletas;
                    componente.cantidad = ((((largo - 1.25) / 0.75) - (largo / 16.25)) * ((ancho / 16.25) + 1)) * cantidad;
                    componente.medida = (ancho - 0.25) / ((ancho / 16.25) + 1);
                    componente.total_perfil = (componente.cantidad * componente.medida) / 240;
                    break;

                case "Aleta Horizontal":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.SG_perfil_aletas;
                    componente.cantidad = ((((ancho - 1.25) / 0.75) - (ancho / 16.25)) * ((largo / 16.25) + 1)) * cantidad;
                    componente.medida = (largo - 0.25) / ((largo / 16.25) + 1);
                    componente.total_perfil = (componente.cantidad * componente.medida) / 240;
                    break;

                case "Travesaño Vertical":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.SG_perfil_travesaños;
                    componente.cantidad = (largo / 16.25) * cantidad;

                    if (largo > 16.25)
                    {
                        componente.medida = ancho - 0.25;
                    }
                    else
                    {
                        componente.medida = 0;
                    }

                    componente.total_perfil = (componente.cantidad * componente.medida) / 240;
                    break;

                case "Travesaño Horizontal":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.SG_perfil_travesaños;
                    componente.cantidad = (ancho / 16.25) * cantidad;

                    if (largo > 16.25)
                    {
                        componente.medida = largo - 0.25;
                    }
                    else
                    {
                        componente.medida = 0;
                    }

                    componente.total_perfil = (componente.cantidad * componente.medida) / 240;
                    break;

                case "Escuadra":
                    componente.nombre = nombre;
                    componente.perfil = Properties.Resources.SG_perfil_escuadra;
                    componente.cantidad = 4;
                    componente.medida = 1;
                    componente.total_perfil = (componente.cantidad * componente.medida) / 240;
                    break;
            }

            return componente;
        }

        public List<ComponenteModel> getComponentList(string modelo, long cantidad, long largo, long ancho)
        {
            List<string> componentes = new List<string>();
            List<ComponenteModel> componentList = new List<ComponenteModel>();

            switch (modelo)
            {
                case "HR":
                    componentes = componentesHR;
                    break;

                case "VR":
                    componentes = componentesHR;
                    break;

                case "HRP":
                    componentes = componentesHR;
                    break;

                case "SG":
                    componentes = componentesSG;
                    break;
            }

            foreach (var componente in componentes)
            {
                if (modelo == "HR" || modelo == "VR")
                {
                    if (componente != "Travesaño")
                    {
                        componentList.Add(GetComponentHR(componente, cantidad, largo, ancho));
                    }
                    else if (componente == "Travesaño" && largo > 16.25)
                    {
                        componentList.Add(GetComponentHR(componente, cantidad, largo, ancho));
                    }
                }
                else if (modelo == "HRP")
                {
                    if (componente != "Travesaño")
                    {
                        componentList.Add(GetComponentHR(componente, cantidad, largo, ancho));
                    }
                    else if (componente != "Travesaño" && largo > 16.25)
                    {
                        componentList.Add(GetComponentHRP(componente, cantidad, largo, ancho));
                    }
                }

                else if (modelo == "SG")
                {
                    if (componente != "Travesaño")
                    {
                        componentList.Add(GetComponentSG(componente, cantidad, largo, ancho));
                    }
                    else if (componente != "Travesaño" && largo > 16.25)
                    {
                        componentList.Add(GetComponentSG(componente, cantidad, largo, ancho));
                    }
                }

            }

            return componentList;
        }
    }
}
