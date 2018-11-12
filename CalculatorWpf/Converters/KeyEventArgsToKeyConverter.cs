using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorWpf.Converters
{
    class KeyEventArgsToKeyConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            var passedEventArgs = ((KeyEventArgs)value);
            passedEventArgs.Handled = true;

            if(passedEventArgs.Key == Key.OemPlus && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
            {
                return Key.Add;
            }
            if(passedEventArgs.Key == Key.OemMinus && !(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
            {
                return Key.Subtract;
            }
            if (passedEventArgs.Key == Key.D8 && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
            {
                return Key.Multiply;
            }
            if(passedEventArgs.Key == Key.OemQuestion && !(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
            {
                return Key.Divide;
            }
            if ((passedEventArgs.Key == Key.OemPlus && !(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))) || passedEventArgs.Key == Key.Enter)
            {
                return Key.Enter;
            }
            if(passedEventArgs.Key == Key.Back)
            {
                return Key.Back;
            }
            passedEventArgs.Handled = false;
            return null;
        }
    }
}
