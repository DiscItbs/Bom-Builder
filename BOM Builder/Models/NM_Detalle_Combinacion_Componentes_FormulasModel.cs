using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
    public class NM_Detalle_Combinacion_Componentes_FormulasModel : ICloneable
    {
        public int Id { get; set; }
        public int IdCombinacion { get; set; }
        public int IdDetalleComponente { get; set; }
        public string NombreComponente { get; set; }
        public int IdComponente { get; set; }
        public int IdFormulaQty { get; set; }
        public int IdFormulaMd { get; set; }
        public int IdFormulaTotal { get; set; }
        public int IdFormulaPeso { get; set; }
        public int IdCondicionalQty { get; set; }
        public int IdCondicionalMd { get; set; }
        public string TypeConditionalQty { get; set; }
        public string TypeConditionalMd { get; set; }
        public string IdCompuestoQty { get; set; }
        public string IdCompuestoMd { get; set; }
        public string NombreMasterQty { get; set; }
        public string NombreMasterMd { get; set; }
        public int IdDetalleForComp { get; set; }
        public string NombreFormulaMd { get; set; }
        public string NombreFormulaQty { get; set; }
        public string NombreFormulaTotal { get; set; }
        public string NombreFormulaPeso { get; set; }
        public string Itemno { get; set; }
        public string Descripcion { get; set; }
        public string NombreCondicionalQty { get; set; }
        public string NombreCondicionalMd { get; set; }
        public string NombreCondicionalTotal { get; set; }
        public bool IsUsed { get; set; }
        public string Seccion { get; set; }
        public int Linea { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
