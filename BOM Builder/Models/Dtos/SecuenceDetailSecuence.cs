using System;


namespace BOM_Builder.Models.Dtos
{
  public class SecuenceDetailSecuence
  {
    public Int32 ID { get; set; } = int.MaxValue;
    public string Secuencia { get; set; } = string.Empty;
    public string Familia {  get; set; } = string.Empty;
    public string Proceso { get; set; } = string.Empty;
    public string PosBom { get; set; } = string.Empty;
  }
}
