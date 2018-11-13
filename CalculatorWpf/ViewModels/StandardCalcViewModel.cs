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
using System.Windows;
using System.Windows.Input;

namespace CalculatorWpf.ViewModels
{
    class StandardCalcViewModel : ViewModelBase
    {
        #region Fields and Properties

        private string number;
        public string Number
        {
            get => number;
            set
            {
                Set(ref number, value);
                CalculatorNumberButtonClickCommand.RaiseCanExecuteChanged();
                InverseSignOfNumberCommand.RaiseCanExecuteChanged();
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

        private RelayCommand<Key> calculatorArithmeticOperationButtonCommand;
        public RelayCommand<Key> CalculatorArithmeticOperationButtonCommand
        {
            get
            {
                return calculatorArithmeticOperationButtonCommand ??
                    (calculatorArithmeticOperationButtonCommand = new RelayCommand<Key>(passedKey =>
                    {
                        if(passedKey == Key.Back)
                        {
                            EraseNumberCommand.Execute(null);
                            return;
                        }
                        CalculatorOperation operation;
                        operation = new CalculatorOperation
                        {
                            SecondArgument = GetNumberFromString(Number),
                        };

                        if (passedKey == Key.Enter)
                        {
                            operation.OperationSymbol = "=";
                            calculator.CalculatorState.FinishExpression(operation);
                            History.Add(calculator.CalculatorState.Expression);
                            Expression = null;
                            Number = calculator.CalculatorState.CalculationOperation?.Result.ToString();
                            return;

                        }
                        else
                        {
                            if (passedKey == Key.Add)
                            {
                                operation.OperationSymbol = "+";
                                operation.ExecuteOperation = (argument1, argument2) => argument1 + argument2;

                            }
                            else if (passedKey == Key.Subtract)
                            {
                                operation.OperationSymbol = "−";
                                operation.ExecuteOperation = (argument1, argument2) => argument1 - argument2;
                            }
                            else if (passedKey == Key.Multiply)
                            {
                                operation.OperationSymbol = "×";
                                operation.ExecuteOperation = (argument1, argument2) => argument1 * argument2;
                            }
                            else if (passedKey == Key.Divide)
                            {
                                operation.OperationSymbol = "÷";
                                operation.ExecuteOperation = (argument1, argument2) => argument1 / argument2;
                            }
                            else
                            {
                                return;
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
                    (calculatorNumberButtonClickCommand = new RelayCommand<string>((input =>
                    {
                        if (!double.TryParse(input, out double result) && input != DecimalSeparator)
                        {
                            return;
                        }
                        calculator.CalculatorState.TakingInputActions();
                        if (calculator.CalculatorState.Reset)
                        {
                            Number = input;
                            calculator.CalculatorState.Reset = false;
                        }
                        else
                        {
                            Number += input;
                        }
                        GetRidOfFirstAdditionalZerosInNumber();
                    }),
                    input =>
                    {
                        
                        if (input == DecimalSeparator && (string.IsNullOrEmpty(Number) || Number.Contains(DecimalSeparator)))
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
            get => eraseNumberCommand ?? (eraseNumberCommand = new RelayCommand(() => Number = Number?.Remove(Number.Count() - 1, 1), () => Number.Count() > 0));
        }

        private RelayCommand makeZeroCurrentNumberCommand;
        public RelayCommand MakeZeroCurrentNumberCommand { get => makeZeroCurrentNumberCommand ?? (makeZeroCurrentNumberCommand = new RelayCommand(() => Number = "0")); }


        private RelayCommand inverseSignOfNumberCommand;
        public RelayCommand InverseSignOfNumberCommand
        {
            get => inverseSignOfNumberCommand ?? (inverseSignOfNumberCommand = new RelayCommand(() =>
            {
                if (Number.First() != '-')
                {
                    Number = Number.Insert(0, "-");
                }
                else
                {
                    Number = Number.Remove(0, 1);
                }
            },() => Number != null && Number.Count() > 0));
        }


        private RelayCommand cleanCurrentExpressionCommand;
        public RelayCommand CleanCurrentExpressionCommand {
            get => cleanCurrentExpressionCommand ?? (cleanCurrentExpressionCommand = 
                new RelayCommand(() => {
                    Expression = "";
                    Number = "0";
                    calculator.CalculatorState = new InitialState(calculator) { Reset = true };
                }));
        } 

        #endregion


        #region Functions

        double GetNumberFromString(string numberText)
        {
            double.TryParse(numberText, out double number);
            return number;
        }

        void GetRidOfFirstAdditionalZerosInNumber()
        {
            if (Number == null || Number.Count() <= 1)
            {
                return;
            }


            if (Number[0] == '0')
            {

                if (Number[1] != ',')
                {
                    Number = Number.Remove(0, 1);
                }
            }
        }

        #endregion
    }
}
