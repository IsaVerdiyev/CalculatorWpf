using CalculatorLib.CalculatorOperation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib.CalculatorState
{
    class SecondArgumentEnteringState: AbstractCalculatorState
    {
        public SecondArgumentEnteringState(ICalculator calculator) : base(calculator) { }


        public override double? PerformOperation(ICalculatorOperation operation)
        {

            CalculationOperation.SecondArgument = operation.SecondArgument;
            CalculationOperation.Operation();
            double result = CalculationOperation.Result.Value;
            calculator.CalculatorHistory?.AddToHistory(CalculationOperation);
            if (!(operation is EqualsOperation))
            {
                operation.FirstArgument = CalculationOperation.Result;
                CalculationOperation = operation;
                reset = true;
            }
            else
            {
                calculator.CalculatorState = new InitialState(calculator);
            }
            return result;
        }

        public override void ResetVisibleInput<T>(ref T field, T value)
        {
            if (reset)
            {
                field = value;
            }
        }
    }
}
