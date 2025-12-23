using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
    public class NM_ModeloL1
    {
        public int Id { get; set; }
        public int IdModeloL0 { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string MfgCell { get; set; }
        public bool Approved { get; set; }
    }
}
