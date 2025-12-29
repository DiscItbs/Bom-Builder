using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.Models
{
  public class NM_ModelosLModel
  {
    public int Id_L0 { get; set; }
    public int Id_L1 { get; set; }
    public int Id_L2 { get; set; }
    public int Id_L3 { get; set; }
    public string Name_Model { get; set; }
    public string Description_Model { get; set; }
    public string Description_Large { get; set; }
    public string Description_English { get; set; }
    public bool Aplica_SubNivel { get; set; }
    public string Mfg_Cell { get; set; }
    public string CentroTrabajo { get; set; }
    public string Secuence { get; set; }
  }
}
