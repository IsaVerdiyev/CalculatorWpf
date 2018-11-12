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
    class TextCompositionEventArgsToStringConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            return ((TextCompositionEventArgs)value).Text;
        }
    }
}
