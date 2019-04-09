using Aura.Models.Types;
using System;
using System.Windows;
using System.Windows.Data;

namespace Aura.Common.ValueConverters
{
    public class WhenRuleItemTypeVisibilityValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is RuleItemType type)
            {
                return type == RuleItemType.When ? Visibility.Visible : Visibility.Hidden;
            }

            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Visibility type)
            {
                return type == Visibility.Visible ? RuleItemType.When : RuleItemType.Then;
            }

            return RuleItemType.When;
        }
    }
}
