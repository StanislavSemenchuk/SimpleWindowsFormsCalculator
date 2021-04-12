using SimpleCalculator.Handlers.Helpers;
using SimpleCalculator.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers
{
    class InputHandler : IInputHandler
    {
        private TextBox _digitBox;
        private CalculationPerformer _calculationPerformer = new CalculationPerformer();
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
                && _digitBox.Text.IndexOf(".") != -1)
            {
                _digitBox.Text = _digitBox.Text + inputed;
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
                    _expression = _calculationPerformer.PerformCalculations(_expression) + inputed;
                    _expression = _expression.Replace(',', '.');
                }
                _digitBox.Text = string.Empty;
            }
            if (inputed == "=" || inputed == ((char)Keys.Enter).ToString())
            {
                _expression += _digitBox.Text;
                _digitBox.Text = _calculationPerformer.PerformCalculations(_expression);
                _digitBox.Text = _digitBox.Text.Replace(',', '.');
                _expression = string.Empty;
            }
            if (inputed == "⌫" || inputed == ((char)Keys.Back).ToString())
            {
                _digitBox.Text = !string.IsNullOrWhiteSpace(_digitBox.Text)
                    ? _digitBox.Text.Substring(0, _digitBox.Text.Length - 1)
                    : _digitBox.Text;
            }
            if (inputed == "C")
            {
                _expression = string.Empty;
                _digitBox.Text = string.Empty;
            }
        }
    }
}
