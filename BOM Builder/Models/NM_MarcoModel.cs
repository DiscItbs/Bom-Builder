using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
    public class NM_MarcoModel
    {
        public int Id { get; set; }

        public string Valor_Marco { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha_Creacion { get; set; }
    }
}
