﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Common.Common
{
    class SuccessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool param = bool.Parse(parameter.ToString());
            if (value == null)
            {
                return false;
            }
            else
            {
                return !((bool)value ^ param);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool param = bool.Parse(parameter.ToString());
            return !((bool)value ^ param);
        }
    }
}
