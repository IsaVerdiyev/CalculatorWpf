using CalculatorLib.CalculatorOperation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib.CalculatorHistory
{
    public interface ICalculatorHistory
    {
        List<ICalculatorOperation> History { get; set; }

        void AddToHistory(ICalculatorOperation calculatorOperation);
        void ClearHistory();
    }
}
