using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace Aura.Common.ValueConverters
{
    public class TempBucketNameValueConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return "[Please Enter Name]";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Empty;
        }
    }
}
