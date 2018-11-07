using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib.CalculatorOperation
{
    public class SubstractOperation: ICalculatorOperation
    {
        public double? FirstArgument { get; set; }
        public double? SecondArgument { get; set; }
        public double? Result { get; set; }

        public Action Operation { get => (() => Result = FirstArgument - SecondArgument); }

        public Func<bool> ValidateChecker { get => null; }
    }
}
