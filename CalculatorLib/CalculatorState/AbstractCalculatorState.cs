using CalculatorLib.CalcOperation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib.CalculatorState
{
    public abstract class AbstractCalculatorState
    {
        protected ICalculator calculator;

        public AbstractCalculatorState(ICalculator calculator)
        {
            this.calculator = calculator;
            reset = false;
        }

        public abstract void PerformOperation(CalculatorOperation operation);

        

        CalculatorOperation calculationOperation;

        public CalculatorOperation CalculationOperation { get => calculationOperation; set => calculationOperation = value; }

        protected bool reset;

        public bool Reset { get => reset; set => reset = value; }

        public abstract void ContinueExpression(CalculatorOperation operation);

        public abstract bool FinishExpression(CalculatorOperation operation);

        public abstract void TakingInputActions();

        //public bool Reset { get => reset; }
    }
}
