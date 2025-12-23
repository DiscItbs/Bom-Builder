namespace BOM_Builder.Models.Dtos
{
  public class NMSecuenciasDto
  {
    public decimal ID { get; set; } = int.MaxValue;
    public string Descripcion { get; set; } = string.Empty;
    public string PKHide { get; set; } =  string.Empty;
  }
}
