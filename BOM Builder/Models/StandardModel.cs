using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
   public class StandardModel
   {
        public long Id { get; set; }
        public string Mfgno { get; set; }
        public string MfgType { get; set; }
        public string MfgCell { get; set; }
        public string Cntr_type { get; set; }
        public string Descrip { get; set; }
        public int Cycletm { get; set; }
        public int Cycle { get; set; }
    }
}
