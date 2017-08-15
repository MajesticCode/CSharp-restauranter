using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace restauranter
{
  [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
  sealed public class PastDate : ValidationAttribute
  {
    public override bool IsValid(object value)
    {
      bool result = false;
      // Add validation logic here
      if (value is DateTime)
      {
        if ((DateTime)value <= DateTime.UtcNow)
        {
          result = true;
        }
      }
      return result;
    }
  }
}