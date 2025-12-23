using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
    public class ModeladoBomModel
    {
        public string Combination { get; set; }
        public string Itemno { get; set; }
        public string Class { get; set; }
        public string Nombre_Componente { get; set; }
        public string FormulaQty { get; set; }
        public string FormulaMd { get; set; }
        public string FormulaTotal { get; set; }
        public string FormulaPeso { get; set; }
        public int IdCondicionalQty { get; set; }
        public int IdCondicionalMd { get; set; }
        public int IdCondicionalTotal { get; set; }
        public string Type_ConditionalQty { get; set; }
        public string Type_ConditionalMd { get; set; }
        public string IdCompuestoQty { get; set; }
        public string IdCompuestoMd { get; set; }
        public string NombreMasterQty { get; set; }
        public string NombreMasterMd { get; set; }
        public string Seccion { get; set; }
        public int Linea { get; set; }
        public string Descripcion { get; set; }
    }
}
