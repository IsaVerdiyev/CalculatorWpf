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
            Reset = true; 
        }

        public override bool FinishExpression(CalculatorOperation operation)
        {
            return false;
        }

        public override void PerformOperation(CalculatorOperation operation)
        {
            Reset = false;
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
