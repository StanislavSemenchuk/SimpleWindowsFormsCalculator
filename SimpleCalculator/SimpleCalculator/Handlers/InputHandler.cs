using SimpleCalculator.Handlers.Helpers;
using SimpleCalculator.Handlers.Interfaces;
using SimpleCalculator.Handlers.InterfacesRealization;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers
{
    class InputHandler : IInputHandler
    {
        private readonly TextBox _digitBox;
        private readonly CalculationPerformer _calculationPerformer = new CalculationPerformer();
        public InputHandler(TextBox outBox)
        {
            _digitBox = outBox;
        }

        private string _expression = string.Empty;

        /// <summary>
        /// </summary>
        /// <param name="inputedChar"></param>
        /// <returns>return true if character is digit, dot, backspase or operation sign, and perform operation</returns>
        public void InputChecker(string inputed)
        {
            //Check if character is digit, dot, backspase or operation sign
            if (char.IsDigit(inputed[0]) || inputed == "."
                && !_digitBox.Text.Contains(".")
                && _digitBox.Text.IndexOf(".") == -1)
            {
                new NumberInputHandler(_digitBox).InputChecker(inputed);
            }
            if (inputed == "+" || inputed == "-" || inputed == "/" || inputed == "*")
            {
                if (_expression.IndexOfAny(new char[] { '+', '-', '*', '/' }) == -1)
                {
                    _expression = _digitBox.Text + inputed;
                }
                else
                {
                    _expression += _digitBox.Text;
                    _expression = _calculationPerformer.PerformCalculations(_expression[0]) + inputed;
                    _expression = _expression.Replace(',', '.');
                }
                _digitBox.Text = string.Empty;
            }
            if (inputed == "=" || inputed == ((char)Keys.Enter).ToString())
            {
                new EqualInputHandler(_digitBox, _expression).InputChecker(inputed);
            }
            if (inputed == "⌫" || inputed == ((char)Keys.Back).ToString())
            {
                new BackSpaceInputHandler(_digitBox).InputChecker(inputed);
            }
            if (inputed == "C")
            {
                new ClearInputHandler(_digitBox, ref _expression).InputChecker(inputed);
            }
        }
    }
}
