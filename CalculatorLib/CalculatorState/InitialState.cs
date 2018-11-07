using CalculatorLib.CalculatorOperation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib.CalculatorState
{
    public class InitialState: AbstractCalculatorState
    {
        public override double? PerformOperation(ICalculatorOperation operation)
        {
            return null;
        }

        public InitialState(ICalculator calculator) : base(calculator) { }


        public override void ResetVisibleInput<T>(ref T field, T value)
        {
            calculator.CalculatorState = new FirstArgumentEnteringState(calculator);
            field = value;
        }
    }
}
