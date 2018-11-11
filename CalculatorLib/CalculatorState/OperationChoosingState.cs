using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorLib.CalcOperation;

namespace CalculatorLib.CalculatorState
{
    class OperationChoosingState : AbstractCalculatorState
    {
        //public override void ContinueExpression(CalculatorOperation operation)
        //{
        //    return;
        //}

        public OperationChoosingState(ICalculator calculator): base(calculator)
        {
             
        }

        public override void FinishExpression(CalculatorOperation operation)
        {
            CalculationOperation.SecondArgument = operation.SecondArgument;
            CalculationOperation.Result = CalculationOperation.ExecuteOperation(CalculationOperation.FirstArgument, CalculationOperation.SecondArgument);
            Expression += $" {operation.SecondArgument} = {CalculationOperation.Result}";
            calculator.CalculatorState = new InitialState(calculator);
            calculator.CalculatorState.CalculationOperation = CalculationOperation;
            calculator.CalculatorState.Expression = Expression;
        }

        public override void PerformOperation(CalculatorOperation operation)
        {
           
            CalculationOperation.ExecuteOperation = operation.ExecuteOperation;
            CalculationOperation.OperationSymbol = operation.OperationSymbol;
            Expression = Expression.Remove(Expression.Count() - 2, 2);
            Expression += $"{CalculationOperation.OperationSymbol} ";
        }

        public override void TakingInputActions()
        {
            calculator.CalculatorState = new CalculationState(calculator);
            calculator.CalculatorState.CalculationOperation = CalculationOperation;
            calculator.CalculatorState.Expression = Expression;
        }
    }
}
