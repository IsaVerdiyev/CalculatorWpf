using CalculatorLib.CalculatorOperation;
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

        public abstract double? PerformOperation(ICalculatorOperation operation);

        public abstract void ResetVisibleInput<T>(ref T field, T value);

        ICalculatorOperation calculationOperation;

        public ICalculatorOperation CalculationOperation { get => calculationOperation; set => calculationOperation = value; }

        protected bool reset;

        public bool Reset { get => reset; }
    }
}
