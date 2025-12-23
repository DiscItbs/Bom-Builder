using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
    public class ArinvtModel
    {
        public long Id { get; set; }
        public string Class { get; set; }
        public string Itemno { get; set; }
        public string Descrip1 { get; set; }
        public string Descrip2 { get; set; }
        public string Unit { get; set; }
        public long Standard_Id { get; set; }
        public long PartNo_Id { get; set; }
        public string Acabado { get; set; }
        public string Rev { get; set; }
    }
}
