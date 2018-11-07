using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib.CalculatorOperation
{
    public interface ICalculatorOperation
    {
        double? FirstArgument { get; set; }

        double? SecondArgument { get; set; }

        double? Result { get; set; }

        Action Operation { get; }

        Func<bool> ValidateChecker { get; }
    }
}
