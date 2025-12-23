using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
    public class Standard
    {
        public int SETS { get; set; }
        public int SETS_DISP { get; set; }
        public int CYCLETM { get; set; }
        public int CYCLETM_DISP { get; set; }
        public int CYCLE { get; set; }
        public int EPLANT_ID { get; set; }
        public string CNTR_TYPE { get; set; }
        public int MFGCELL_ID { get; set; }
        public string MFGCELL { get; set; }
    }
}