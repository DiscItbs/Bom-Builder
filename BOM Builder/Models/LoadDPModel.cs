using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
    public class LoadDPModel
    {
        public int Id { get; set; }

        public string Itemno { get; set; }

        public string Class { get; set; }

        public int Largo { get; set; }

        public int Ancho { get; set; }

        public string Acabado { get; set; }

        public string Rev { get; set; }

        public string Descrip1 { get; set; }

        public string Descrip2 { get; set; }
    }
}
