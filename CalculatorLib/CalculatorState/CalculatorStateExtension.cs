using CalculatorLib.CalcOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace CalculatorLib.CalculatorState
//{
//    public static class CalculatorStateExtension
//    {
//        public static string GenerateMathExpression(this AbstractCalculatorState calculatorState, string expression, CalculatorOperation operation)
//        {
//            if(calculatorState is OperationChoosingState)
//            {
//                if (!calculatorState.Reset)
//                {
//                    expression += $"{operation.SecondArgument} {operation.OperationSymbol} ";
//                    calculatorState.Reset = true;
//                    return expression;
//                }
//                expression = expression.Remove(expression.Count() - 2, 2);
//                expression += $"{calculatorState.CalculationOperation.OperationSymbol} ";
//                return expression;
//            }
//            else if(calculatorState is InitialState)
//            {
//                return $"{operation.SecondArgument} = {operation.SecondArgument}";
//            }
//            else
//            {
//                expression += $"{operation.SecondArgument} {operation.OperationSymbol} ";
//                return expression;
//            }
//        }

//        public static string GetFinishedExpression(this AbstractCalculatorState calculatorState, string expression, CalculatorOperation operation)
//        {
//            if (calculatorState is OperationChoosingState)
//            {
//                expression = expression?.Remove(expression.Count() - 2, 2);
//                expression += $"= {calculatorState.CalculationOperation.FirstArgument}";
//                return expression;
//            }
//            else if (calculatorState is InitialState)
//            {
//                calculatorState.CalculationOperation = operation;
//                calculatorState.CalculationOperation.Result = operation.SecondArgument;
//                return $"{operation.SecondArgument} = {operation.SecondArgument}";
//            }
//            else if(calculatorState is CalculationState)
//            {
//                expression += $"{operation?.SecondArgument} = {calculatorState.CalculationOperation.Result}";
//                return expression;
//            }
//            return "";
//        }
//    }
//}
