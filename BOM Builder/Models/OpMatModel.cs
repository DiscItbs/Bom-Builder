using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
   public class OpMatModel
   {
      public long Id { get; set; }
      public string Seq { get; set; }
      public string PtsPer { get; set; }
      public string Unit { get; set; }
      public string Itemno_Arinvt { get; set; }
      public string Descrip_Arinvt { get; set; }
   }
}
