using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
    public class NM_Condicional
    {
        public int Id { get; set; }
        public string NombreCondicional { get; set; }
        public string Condicional { get; set; }
        public string Tipo { get; set; }
        public string Verdadero { get; set; }
        public string Falso { get; set; }
        public string Path { get; set; }
        public string NodoPadre { get; set; }
    }
}
