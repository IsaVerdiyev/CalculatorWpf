using CalculatorLib.CalculatorState;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib.CalcOperation
{
    public class CalculatorOperation
    {
        public double? FirstArgument { get; set; }

        public double? SecondArgument { get; set; }

        public double? Result { get; set; }

        public string OperationSymbol { get; set; }

        public Func<double?, double?, double?> ExecuteOperation { get; set; }
    }
}
