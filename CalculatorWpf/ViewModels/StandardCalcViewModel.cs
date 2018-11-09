using CalculatorLib;
using CalculatorLib.CalcOperation;
using CalculatorLib.CalculatorState;
using CalculatorWpf.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWpf.ViewModels
{
    class StandardCalcViewModel: ViewModelBase
    {
        #region Fields and Properties

        private double number;
        public string Number {
            get => number.ToString();
            set 
            {
                Set(ref number, GetNumberFromString(value));
            }
        }

        private string expression;
        public string Expression { get => expression; set => Set(ref expression, value); }

        private string operationSymbol;
        public string OperationSymbol { get => operationSymbol; set => Set(ref operationSymbol, value); }
        #endregion

        #region Dependencies

        ICalculator calculator;

        INavigator navigator;

        #endregion

        #region Constructor

        public StandardCalcViewModel(INavigator navigator)
        {
            this.calculator = new SimpleCalculator();
            calculator.CalculatorState = new InitialState(calculator);
            this.navigator = navigator;
        }

        #endregion

        #region Commands

        private RelayCommand<string> calculatorArithmeticOperationButtonCommand;
        public RelayCommand<string> CalculatorArithmeticOperationButtonCommand
        {
            get
            {
                return calculatorArithmeticOperationButtonCommand ??
                    (calculatorArithmeticOperationButtonCommand = new RelayCommand<String>(obj =>
                    {
                        string opText = obj as string;
                        CalculatorOperation operation;
                        operation = new CalculatorOperation
                        {
                            SecondArgument = number,
                            OperationSymbol = opText
                        };

                        if (opText == "=")
                        {
                            if (calculator.CalculatorState is CalculationState)
                            {
                                //calculator.CalculatorState.PerformOperation(operation).ToString() ?? Number;
                                //if (calculator.CalculatorState.ChangeState())
                                //{
                                //    Expression += $"{calculator.CalculatorState.CalculationOperation.FirstArgument?.ToString()} {calculator.CalculatorState.CalculationOperation.OperationSymbol} {calculator.CalculatorState.CalculationOperation.SecondArgument?.ToString()} {opText} {Number} ";
                                //}
                                //calculator.CalculatorState.FinishExpression();
                            }
                        }
                        else {
                            if (opText == "+")
                            {
                                operation.ExecuteOperation = (argument1, argument2) =>  argument1 + argument2;
                                
                            }
                            else if (opText == "−")
                            {
                                operation.ExecuteOperation = (argument1, argument2) => argument1 - argument2;
                            }
                            else if (opText == "×")
                            {
                                operation.ExecuteOperation = (argument1, argument2) => argument1 * argument2;
                            }
                            else if (opText == "÷")
                            {
                                operation.ExecuteOperation = (argument1, argument2) => argument1 / argument2;
                            }
                            else
                            {
                                operation = null;
                            }
                            calculator.CalculatorState.PerformOperation(operation);
                            if (calculator.CalculatorState.Reset)
                            {
                                Expression += $" {OperationSymbol} {operation.SecondArgument}";
                                Number = calculator.CalculatorState.CalculationOperation.FirstArgument.ToString();
                            }
                            calculator.CalculatorState.ContinueExpression(operation);
                            OperationSymbol = operation.OperationSymbol;
                        }
                    }));
            }
        }


        private RelayCommand<string> calculatorNumberButtonClickCommand;
        public RelayCommand<string> CalculatorNumberButtonClickCommand
        {
            get
            {
                return calculatorNumberButtonClickCommand ??
                    (calculatorNumberButtonClickCommand = new RelayCommand<string>((obj =>
                    {
                        calculator.CalculatorState.TakingInputActions();
                        if (calculator.CalculatorState.Reset)
                        {
                            Number = (string)obj;
                            calculator.CalculatorState.Reset = false;
                        }
                        else
                        {
                            Number += (string)obj;
                        }
                    }),
                    obj =>
                    {
                        string text = obj as string;
                        if (text == "." && (string.IsNullOrEmpty(Number) || Number.Contains(".")))
                        {
                            return false;
                        }
                        return true;
                    }));
            }
        }

        #endregion


        #region Functions

        double GetNumberFromString(string numberText)
        {
            double.TryParse(numberText, out double number);
            return number;
        }

        #endregion
    }
}
