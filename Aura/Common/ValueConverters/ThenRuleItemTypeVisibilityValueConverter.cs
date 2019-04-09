using Aura.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Aura.Common.ValueConverters
{
    public class ThenRuleItemTypeVisibilityValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is RuleItemType type)
            {
                return type == RuleItemType.Then ? Visibility.Visible : Visibility.Hidden;
            }

            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Visibility type)
            {
                return type == Visibility.Visible ? RuleItemType.Then : RuleItemType.When;
            }

            return RuleItemType.Then;
        }
    }
}
