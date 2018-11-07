using CalculatorLib.CalculatorHistory;
using CalculatorLib.CalculatorState;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib
{
    public interface ICalculator
    {
        AbstractCalculatorState CalculatorState { get; set; }

        ICalculatorHistory CalculatorHistory { get; set; }
    }
}
