using Aura.AddOns;
using System;
using System.Windows.Data;

namespace Aura.Common.ValueConverters
{
    public class ClockPeriodReadableTimeSpanValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is IClockPeriod clockPeriod)
            {
                return $"{(clockPeriod.EndTime ?? DateTime.Now).ToString("h:mm tt")}  - {clockPeriod.StartTime.ToString("h:mm tt")}";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
