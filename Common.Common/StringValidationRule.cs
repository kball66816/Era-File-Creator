using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Common.Common
{
    public class StringValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, null);
            }

            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
