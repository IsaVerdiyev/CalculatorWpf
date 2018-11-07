using CalculatorLib.CalculatorOperation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib.CalculatorState
{
    class FirstArgumentEnteringState: AbstractCalculatorState
    {
        public FirstArgumentEnteringState(ICalculator calculatorUser) : base(calculatorUser) { }


        public override double? PerformOperation(ICalculatorOperation operation)
        {
            operation.FirstArgument = operation.SecondArgument;
            operation.SecondArgument = null;
            this.CalculationOperation = operation;
            reset = true;
            return null;
        }

        public override void ResetVisibleInput<T>(ref T field, T value)
        {
            if (reset)
            {
                calculator.CalculatorState = new SecondArgumentEnteringState(calculator);
                calculator.CalculatorState.CalculationOperation = this.CalculationOperation;
                field = value;
            }

        }
    }
}
