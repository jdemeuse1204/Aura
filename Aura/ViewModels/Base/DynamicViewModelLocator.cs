using Ninject;
using System;
using System.Linq;
using System.Windows;

namespace Aura.ViewModels.Base
{
    public class DynamicViewModelLocator
    {
        public static readonly DependencyProperty ViewModelClassNameProperty = DependencyProperty.RegisterAttached("ViewModelClassName", typeof(string), typeof(DynamicViewModelLocator), new PropertyMetadata(null));
        public static readonly DependencyProperty IsAutomaticLocatorProperty = DependencyProperty.RegisterAttached("IsAutomaticLocator", typeof(bool), typeof(DynamicViewModelLocator), new PropertyMetadata(false, IsAutomaticLocatorChanged));

        public static bool GetIsAutomaticLocator(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsAutomaticLocatorProperty);
        }

        public static void SetIsAutomaticLocator(DependencyObject obj, bool value)
        {
            obj.SetValue(IsAutomaticLocatorProperty, value);
        }

        private static void IsAutomaticLocatorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var callOwner = d as FrameworkElement;
            var className = $"{d.DependencyObjectType.Name}ViewModel";
            var userControl = GetInstanceOf(callOwner.GetType(), className);

            callOwner.DataContext = userControl;
        }

        public static string GetViewModelClassName(DependencyObject obj)
        {
            return (string)obj.GetValue(ViewModelClassNameProperty);
        }

        public static void SetViewModelClassName(DependencyObject obj, string value)
        {
            obj.SetValue(ViewModelClassNameProperty, value);
        }

        private static object GetInstanceOf(Type dependencyPropertyType, string className)
        {
            var assembly = dependencyPropertyType.Assembly;
            var assemblyTypes = assembly.GetTypes();
            var userControlType = assemblyTypes.FirstOrDefault(a => a.Name.Contains(className));

            if (userControlType == null)
            {
                throw new ArgumentException($"Not exist a type {className} in the assembly { assembly.FullName} ");
            }

            return App.Container.Get(userControlType);
        }
    }
}
