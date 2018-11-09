using CalculatorLib.CalcOperation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib.CalculatorHistory
{
    public interface ICalculatorHistory
    {
        List<CalcOperation.CalculatorOperation> History { get; set; }

        void AddToHistory(CalcOperation.CalculatorOperation calculatorOperation);
        void ClearHistory();
    }
}
