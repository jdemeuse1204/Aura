using Aura.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace Aura.Common.ValueConverters
{
    public class TimeSpanValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is TimeSpan timeSpan)
            {
                return timeSpan.ToReadableTime();
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Empty;
        }
    }
}
