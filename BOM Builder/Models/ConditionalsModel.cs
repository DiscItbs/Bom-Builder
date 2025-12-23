using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
    public class ConditionalsModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdCondicionalMaster { get; set; }
        public string IdCompuesto { get; set; }
        public int IdElemento { get; set; }
        public string Posicion { get; set; }
        public int Nivel { get; set; }
        public string Condicional { get; set; }
        public string Tipo { get; set; }
        public string Verdadero { get; set; }
        public string Falso { get; set; }
    }
}
