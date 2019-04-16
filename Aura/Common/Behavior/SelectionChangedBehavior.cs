﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Aura.Common.Behavior
{
    public class SelectionChangedBehavior
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(SelectionChangedBehavior), new PropertyMetadata(PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            Selector selector = (Selector)depObj;
            if (selector != null)
            {
                selector.SelectionChanged += new SelectionChangedEventHandler(SelectionChanged);
            }
        }

        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }

        private static void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selector selector = (Selector)sender;
            if (selector != null)
            {
                ICommand command = selector.GetValue(CommandProperty) as ICommand;
                if (command != null)
                {
                    command.Execute(new
                    {
                        sender,
                        e
                    });
                }
            }
        }
    }
}
