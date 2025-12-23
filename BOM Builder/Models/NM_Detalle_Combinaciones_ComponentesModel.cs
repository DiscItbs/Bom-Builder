using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
   public class NM_Detalle_Combinaciones_ComponentesModel
   {
      public int Id { get; set; }
      public string Id_Arinvt { get; set; }
      public int IdCombinacion { get; set; }
      public long IdComponentes { get; set; }
      public string Nombre_Componente { get; set; }
      public string Acabado { get; set; }
      public string Class { get; set; }
      public string Itemno { get; set; }
      public bool isUsed { get; set; }
      public int Linea { get; set; }
    }
}
