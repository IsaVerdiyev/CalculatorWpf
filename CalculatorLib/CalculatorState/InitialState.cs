using CalculatorLib.CalcOperation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib.CalculatorState
{
    public class InitialState: AbstractCalculatorState
    {
        public override void PerformOperation(CalculatorOperation operation)
        {
            if (Reset)
            {
                return;
            }
            calculator.CalculatorState = new OperationChoosingState(calculator);
            calculator.CalculatorState.CalculationOperation = new CalculatorOperation
            {
                FirstArgument = operation.SecondArgument,
                ExecuteOperation = operation.ExecuteOperation,
                OperationSymbol = operation.OperationSymbol
            };
        }

        public InitialState(ICalculator calculator) : base(calculator) { Reset = true; }


        

        public override void ContinueExpression(CalculatorOperation operation)
        {
            return;
        }

        public override bool FinishExpression(CalculatorOperation operation)
        {
            return false;
        }

        public override void TakingInputActions()
        {
            return;
        }
    }
}
