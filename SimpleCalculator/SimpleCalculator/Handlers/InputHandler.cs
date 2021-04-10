using SimpleCalculator.Handlers.Helpers;
using SimpleCalculator.Handlers.Interfaces;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers
{
    class InputHandler : IInputHandler
    {
        private TextBox _digitBox;
        private CalculationPerformer _calculationPerformer = new CalculationPerformer();
        public InputHandler(ref TextBox outBox)
        {
            _digitBox = outBox;
        }

        /// <summary>
        /// </summary>
        /// <param name="inputedChar"></param>
        /// <returns>return true if character is digit, dot, backspase or operation sign, and perform operation</returns>
        public bool InputChecker(string inputed)
        {
            string allowedCharsRegexPattern = @"^[\+\*\/\-\.\d+]$";
            //Check if character is digit, dot, backspase or operation sign
            if (Regex.IsMatch(inputed, allowedCharsRegexPattern)) 
            {
                _digitBox.Text += inputed;
                return true;
            }
            if (inputed == "=" || inputed == ((char)Keys.Enter).ToString())
            {
                _digitBox.Text = _digitBox.Text.Replace(',', '.');
                _digitBox.Text = _calculationPerformer.PerformCalculations(_digitBox.Text);
                return true;
            }
            if (inputed == "⌫" || inputed == ((char)Keys.Back).ToString())
            {
                _digitBox.Text = !string.IsNullOrWhiteSpace(_digitBox.Text)
                    ? _digitBox.Text.Substring(0, _digitBox.Text.Length - 1)
                    : _digitBox.Text;
                return true;
            }
            if (inputed == "CE")
            {
                _digitBox.Text = string.Empty;
                return true;
            }
            return false;
        }
    }
}
