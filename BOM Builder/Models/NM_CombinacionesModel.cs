using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
    public class NM_CombinacionesModel
    {
        public int Id { get; set; }
        public string Combinacion { get; set; }
        public bool Approved { get; set; }
        public bool Phantom { get; set; }
    }
}
