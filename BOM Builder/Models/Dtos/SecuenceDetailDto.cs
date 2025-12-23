using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models.Dtos
{
  public class SecuenceDetailDto
  {
    public Int32 ID { get; set; } = int.MaxValue;
    public string Detalle {  get; set; }
    public string PK { get; set; }
  }
}
