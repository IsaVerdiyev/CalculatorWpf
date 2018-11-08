using CalculatorLib;
using CalculatorLib.CalculatorOperation;
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

        private string resultNumber;
        public string ResultNumber { get => resultNumber; set => Set(ref resultNumber, value); }

        private string expression;
        public string Expression { get => expression; set => Set(ref expression, value); }


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
                        ICalculatorOperation operation;
                        Double.TryParse(ResultNumber, out double second);
                        if (opText == "+")
                        {
                            operation = new SumOperation { SecondArgument = second };
                        }
                        else if (opText == "−")
                        {
                            operation = new SubstractOperation { SecondArgument = second };
                        }
                        else if (opText == "×")
                        {
                            operation = new MultiplyOperation { SecondArgument = second };
                        }
                        else if (opText == "÷")
                        {
                            operation = new DevideOperation { SecondArgument = second };
                        }
                        else if (opText == "=")
                        {
                            operation = new EqualsOperation { SecondArgument = second };
                        }
                        else
                        {
                            operation = null;
                        }
                        ResultNumber = calculator.CalculatorState.PerformOperation(operation)?.ToString() ?? ResultNumber;
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
                        calculator.CalculatorState.ResetVisibleInput(ref resultNumber, "");
                        ResultNumber += (string)obj;
                    }),
                    obj =>
                    {
                        string text = obj as string;
                        if (text == "." && (string.IsNullOrEmpty(ResultNumber) || ResultNumber.Contains(".")))
                        {
                            return false;
                        }
                        return true;
                    }));
            }
        }

        #endregion
    }
}
