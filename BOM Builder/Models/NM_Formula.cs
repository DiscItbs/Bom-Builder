using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
    public class NM_Formula
    {
        public int Id { get; set; }
        public string NombreFormula { get; set; }
        public string Tipo { get; set; }
        public string Formula { get; set; }
        public string FechaCreacion { get; set; }

    }
}
