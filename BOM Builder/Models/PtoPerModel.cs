using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
   public class PtoPerModel
   {
      public long Id { get; set; }
      public long SndOp_Id {get; set;}
      public long PartNo_Id { get; set; }
      public string OpSeq { get; set; }
      public string UoM { get; set; }
   }
}
