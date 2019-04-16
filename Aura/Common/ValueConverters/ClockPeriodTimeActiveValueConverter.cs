using Aura.AddOns;
using Aura.Common.Extensions;
using System;
using System.Windows.Data;

namespace Aura.Common.ValueConverters
{
    public class ClockPeriodTimeActiveValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is IClockPeriod clockPeriod)
            {
                return ((clockPeriod.EndTime ?? DateTime.Now) - clockPeriod.StartTime).ToReadableTime();
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
