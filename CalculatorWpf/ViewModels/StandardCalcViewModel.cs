using CalculatorLib;
using CalculatorLib.CalcOperation;
using CalculatorLib.CalculatorState;
using CalculatorWpf.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalculatorWpf.ViewModels
{
    class StandardCalcViewModel: ViewModelBase
    {
        #region Fields and Properties

        private string number;
        public string Number {
            get => number;
            set
            {
                Set(ref number, value);
                CalculatorNumberButtonClickCommand.RaiseCanExecuteChanged();
            }
        }

        private string expression;
        public string Expression { get => expression; set => Set(ref expression, value); }

        private ObservableCollection<string> history = new ObservableCollection<string>();
        public ObservableCollection<string> History { get => history; set => Set(ref history, value); }

        private string decimalSeparator;
        public string DecimalSeparator { get => decimalSeparator; set => Set(ref decimalSeparator, value); }


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

            string CultureName = Thread.CurrentThread.CurrentCulture.Name;
            CultureInfo ci = new CultureInfo(CultureName);
            DecimalSeparator = ci.NumberFormat.NumberDecimalSeparator;
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
                            SecondArgument = GetNumberFromString(Number),
                            OperationSymbol = opText
                        };

                        if (opText == "=")
                        {
                            calculator.CalculatorState.FinishExpression(operation);
                            History.Add(calculator.CalculatorState.Expression);
                            Expression = null;
                            Number = calculator.CalculatorState.CalculationOperation?.Result.ToString();
                            return;

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

                            Expression = calculator.CalculatorState.Expression;
                            Number = calculator.CalculatorState.CalculationOperation.Result.ToString();

                            
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
                        if (text == DecimalSeparator && (string.IsNullOrEmpty(Number) || Number.Contains(DecimalSeparator)))
                        {
                            return false;
                        }
                        return true;
                    }));
            }
        }

        private RelayCommand eraseNumberCommand;
        public RelayCommand EraseNumberCommand
        {
            get => eraseNumberCommand ?? (eraseNumberCommand = new RelayCommand(() => Number =  Number?.Remove(Number.Count() - 1, 1)));
        }

        private RelayCommand makeZeroCurrentNumberCommand;
        public RelayCommand MakeZeroCurrentNumberCommand { get => makeZeroCurrentNumberCommand ?? (makeZeroCurrentNumberCommand = new RelayCommand(() => Number = "0")); }

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
