using CalculatorLib.CalcOperation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib.CalculatorState
{
    public class CalculationState: AbstractCalculatorState
    {
        public CalculationState(ICalculator calculator) : base(calculator) { Reset = true; }

        //public override void ContinueExpression(CalculatorOperation operation)
        //{

        //    calculator.CalculatorState = new OperationChoosingState(calculator) { Reset = true };
        //    CalculationOperation.FirstArgument = CalculationOperation.Result;
        //    CalculationOperation.ExecuteOperation = operation.ExecuteOperation;
        //    calculator.CalculatorState.CalculationOperation = CalculationOperation;
        //}

        public override void FinishExpression(CalculatorOperation operation)
        {
            CalculationOperation.SecondArgument = operation.SecondArgument;
            CalculationOperation.Result = CalculationOperation.ExecuteOperation(CalculationOperation.FirstArgument, CalculationOperation.SecondArgument);
            calculator.CalculatorHistory?.AddToHistory(CalculationOperation);
            Expression += $"{CalculationOperation.SecondArgument} = {CalculationOperation.Result}";
            calculator.CalculatorState = new InitialState(calculator)
            {
                Reset = true,
                CalculationOperation = CalculationOperation,
                Expression = Expression
            };
        }

        public override void PerformOperation(CalculatorOperation operation)
        {
            CalculationOperation.SecondArgument = operation.SecondArgument;
            CalculationOperation.Result = CalculationOperation.ExecuteOperation(CalculationOperation.FirstArgument, CalculationOperation.SecondArgument);
            calculator.CalculatorHistory?.AddToHistory(CalculationOperation);
            Expression += $"{CalculationOperation.SecondArgument} {operation.OperationSymbol} ";
            CalculationOperation.FirstArgument = CalculationOperation.Result;
            calculator.CalculatorState = new OperationChoosingState(calculator);
            calculator.CalculatorState.CalculationOperation = CalculationOperation;
            CalculationOperation.OperationSymbol = operation.OperationSymbol;
            CalculationOperation.ExecuteOperation = operation.ExecuteOperation;
            calculator.CalculatorState.Expression = Expression;
            
        }

        public override void TakingInputActions()
        {
            return;
        }
    }
}
