using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWpf.ViewModels
{
    class StandardCalcViewModel: ViewModelBase
    {
        //#region Fields and Properties

        //private string textBoxNumber;

        //public string TextBoxNumber
        //{
        //    get { return textBoxNumber; }
        //    set { textBoxNumber = value; }
        //}


        //#endregion

        //#region Dependencies

        //ICalculator calculator;

        //INavigationService navigationService;

        //#endregion

        //#region Constructor

        //public StandardCalcViewModel(INavigationService navigationService)
        //{
        //    this.calculator = new Calculator.SimpleCalculator();
        //    calculator.CalculatorState = new InitialState(calculator);
        //    this.navigationService = navigationService;
        //}

        //#endregion

        //#region Commands

        //private RelayCommand<string> calculatorArithmeticOperationButtonCommand;

        //public RelayCommand<string> CalculatorArithmeticOperationButtonCommand
        //{
        //    get
        //    {
        //        return calculatorArithmeticOperationButtonCommand ??
        //            (calculatorArithmeticOperationButtonCommand = new RelayCommand<String>(obj =>
        //            {
        //                string opText = obj as string;
        //                ICalculatorOperation operation;
        //                Double.TryParse(TextBoxNumber, out double second);
        //                if (opText == "+")
        //                {
        //                    operation = new SumOperation { SecondArgument = second };
        //                }
        //                else if (opText == "-")
        //                {
        //                    operation = new SubstractOperation { SecondArgument = second };
        //                }
        //                else if (opText == "*")
        //                {
        //                    operation = new MultiplyOperation { SecondArgument = second };
        //                }
        //                else if (opText == "÷")
        //                {
        //                    operation = new DevideOperation { SecondArgument = second };
        //                }
        //                else if (opText == "=")
        //                {
        //                    operation = new EqualsOperation { SecondArgument = second };
        //                }
        //                else
        //                {
        //                    operation = null;
        //                }
        //                TextBoxNumber = calculator.CalculatorState.PerformOperation(operation)?.ToString() ?? TextBoxNumber;
        //            }));
        //    }
        //}

        //#endregion
    }
}
