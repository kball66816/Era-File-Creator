﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Common.Common
{
    public class ZipCodeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (ParseZipCodeLength(value.ToString()) == true)
            {
                return new ValidationResult(true, null);
            }

            else
            {
                return new ValidationResult(false, null);
            }
        }


        private bool ParseZipCodeLength(string zipCode)
        {
            bool validLength = false;
            if (zipCode.Length == 5 || zipCode.Length == 9)
            {
                validLength = true;
                return validLength;
            }

            else
            {
                return validLength;
            }
        }
    }
}
