using CalculatorLib.CalculatorHistory;
using CalculatorLib.CalculatorState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    public class SimpleCalculator: ICalculator
    {

        AbstractCalculatorState calculatorState;
        public AbstractCalculatorState CalculatorState { get => calculatorState; set => calculatorState = value; }

        ICalculatorHistory calculatorHistory;
        public ICalculatorHistory CalculatorHistory { get => calculatorHistory; set => calculatorHistory = value; }
    }
}
