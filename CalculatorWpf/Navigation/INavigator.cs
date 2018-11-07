using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWpf.Navigation
{
    interface INavigator
    {
        ViewModelBase Current { get; set; }

        void NavigateTo(VM name);

        void GoBack();

        void AddPage(ViewModelBase page, VM name);

        void RemovePage(VM name);
    }
}
