using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib.CalculatorOperation
{
    public class DevideOperation: ICalculatorOperation
    {
        public double? FirstArgument { get; set; }
        public double? SecondArgument { get; set; }
        public double? Result { get; set; }

        public Action Operation { get => (() => Result = FirstArgument / SecondArgument); }

        public Func<bool> ValidateChecker { get => (() => SecondArgument != 0); }
    }
}
