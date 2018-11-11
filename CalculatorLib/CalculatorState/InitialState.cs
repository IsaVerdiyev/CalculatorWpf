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
            calculator.CalculatorState = new OperationChoosingState(calculator);
            calculator.CalculatorState.CalculationOperation = new CalculatorOperation
            {
                FirstArgument = operation.SecondArgument,
                ExecuteOperation = operation.ExecuteOperation,
                OperationSymbol = operation.OperationSymbol,
                Result = operation.SecondArgument
            };

            calculator.CalculatorState.Expression = $"{calculator.CalculatorState.CalculationOperation.FirstArgument} {calculator.CalculatorState.CalculationOperation.OperationSymbol} ";
        }

        public InitialState(ICalculator calculator) : base(calculator) {  }


        

        //public override void ContinueExpression(CalculatorOperation operation)
        //{
        //    return;
        //}

        public override void FinishExpression(CalculatorOperation operation)
        {
            CalculationOperation = operation;
            CalculationOperation.Result = CalculationOperation.SecondArgument;
            Expression = $"{calculator.CalculatorState.CalculationOperation.Result} = {calculator.CalculatorState.CalculationOperation.Result}";
            Reset = true;
        }

        public override void TakingInputActions()
        {
            return;
        }
    }
}
