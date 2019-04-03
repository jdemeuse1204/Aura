using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Aura.Common.ValueConverters
{
    public class InvertVisibilityValueConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var enumValue = (Visibility)Enum.Parse(typeof(Visibility), value.ToString());

            switch (enumValue)
            {
                case Visibility.Hidden:
                    return Visibility.Visible;
                default:
                case Visibility.Visible:
                    return Visibility.Hidden;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var enumValue = (Visibility)Enum.Parse(typeof(Visibility), value.ToString());

            switch (enumValue)
            {
                case Visibility.Hidden:
                    return Visibility.Hidden;
                default:
                case Visibility.Visible:
                    return Visibility.Visible;
            }
        }
    }
}
