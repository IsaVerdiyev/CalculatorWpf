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
        public override void ContinueExpression(CalculatorOperation operation)
        {
            return;
        }

        public OperationChoosingState(ICalculator calculator): base(calculator)
        {
            Reset = false; 
        }

        public override bool FinishExpression(CalculatorOperation operation)
        {
            //CalculationOperation.Result = CalculationOperation.ExecuteOperation(CalculationOperation.FirstArgument, operation.SecondArgument);
            calculator.CalculatorState = new InitialState(calculator) { Reset = true };
            calculator.CalculatorState.CalculationOperation = this.CalculationOperation;
            return true;
        }

        public override void PerformOperation(CalculatorOperation operation)
        {
            CalculationOperation.ExecuteOperation = operation.ExecuteOperation;
            CalculationOperation.OperationSymbol = operation.OperationSymbol;
        }

        public override void TakingInputActions()
        {
            calculator.CalculatorState = new CalculationState(calculator);
            calculator.CalculatorState.CalculationOperation = this.CalculationOperation;
        }
    }
}
