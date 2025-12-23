using System;

namespace BOM_Builder.Models.Dtos
{
  internal class NMSecuencesDto
  {
    public Int32 ID {  get; set; } = int.MaxValue;
    public string SecuenceDetail { get; set; } = string.Empty;
    public char PkHideSecuences { get; set; } = char.MinValue;
  }
}
