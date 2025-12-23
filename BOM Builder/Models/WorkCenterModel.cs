using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
    public class WorkCenterModel
    {
        public long Id { get; set; }
        public string Mfg_Cell { get; set; }
        public string Cntr_Desc { get; set; }
    }
}
