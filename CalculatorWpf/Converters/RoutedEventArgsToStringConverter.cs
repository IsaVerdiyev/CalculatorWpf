using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace CalculatorWpf.Converters
{
    class RoutedEventArgsToStringConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            var passedEventArgs = (KeyEventArgs)value;
            return passedEventArgs.Key.ToString();
        }
    }
}
