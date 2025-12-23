using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
    public class LegacyNewBoms
    {
        public int Id { get; set; }
        public string Itemno { get; set; }
        public string Rev { get; set; }
        public string Descrip { get; set; }
        public bool Approved { get; set; }
    }
}
