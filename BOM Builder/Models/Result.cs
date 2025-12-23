using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
    public class Result
    {
        public string Itemno { get; set; }
        public string Description { get; set; }
        public string resultQty { get; set; }
        public string resultMd { get; set; }
        public string resultTotal { get; set; }
        public bool IsUsed { get; set; }
    }
}
