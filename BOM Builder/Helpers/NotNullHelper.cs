using System;

namespace BOM_Builder.Helpers
{
  public static class NotNullHelper
  {
    public static string NotNullString(object value)
    {
      if (value == null || value == DBNull.Value)
      {
        return string.Empty;
      }

      var str = value.ToString();
      return string.IsNullOrWhiteSpace(str) ? string.Empty : str;
    }
  }
}
