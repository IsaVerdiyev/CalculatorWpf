﻿using CalculatorLib.CalcOperation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib.CalculatorState
{
    public class CalculationState: AbstractCalculatorState
    {
        public CalculationState(ICalculator calculator) : base(calculator) { Reset = true; }

        public override void ContinueExpression(CalculatorOperation operation)
        {

            calculator.CalculatorState = new OperationChoosingState(calculator) { Reset = true };
            CalculationOperation.FirstArgument = CalculationOperation.Result;
            CalculationOperation.ExecuteOperation = operation.ExecuteOperation;
            calculator.CalculatorState.CalculationOperation = CalculationOperation;
        }

        public override bool FinishExpression(CalculatorOperation operation)
        {
            //if(Reset)
            //{
            //    CalculationOperation.Result = CalculationOperation.FirstArgument;
            //}
            //else
            //{
            //    CalculationOperation.Result = CalculationOperation.ExecuteOperation(CalculationOperation.FirstArgument, operation.SecondArgument);
            //}
            calculator.CalculatorState = new InitialState(calculator) {
                Reset = true,
                CalculationOperation = this.CalculationOperation
            };
            return true;
        }

        public override void PerformOperation(CalculatorOperation operation)
        {
            CalculationOperation.SecondArgument = operation.SecondArgument;
            CalculationOperation.Result = CalculationOperation.ExecuteOperation(CalculationOperation.FirstArgument, CalculationOperation.SecondArgument);
            calculator.CalculatorHistory?.AddToHistory(CalculationOperation);
            //ContinueExpression(operation);
        }

        public override void TakingInputActions()
        {
            return;
        }
    }
}