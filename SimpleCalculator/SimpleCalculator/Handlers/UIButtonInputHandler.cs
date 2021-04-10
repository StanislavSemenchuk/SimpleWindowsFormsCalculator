using SimpleCalculator.Handlers.Bases;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers
{
    class UIButtonInputHandler : InputHandler
    {
        private TextBox _digitBox;
        public UIButtonInputHandler(ref TextBox outBox)
        {
            _digitBox = outBox;
        }

        /// <summary>
        /// </summary>
        /// <param name="inputedChar"></param>
        /// <returns>return true if character is digit, dot, backspase or operation sign, and perform operation</returns>
        public override bool InputChecker(string inputed)
        {
            string allowedCharsRegexPattern = @"^(\d*(\.)?[\+\*\/-]?)$";
            //Check if character is digit, dot, backspase or operation sign
            if (Regex.IsMatch(inputed.ToString(), allowedCharsRegexPattern)) 
            {
                _digitBox.Text += inputed;
                return true;
            }
            else if (inputed == "=")
            {
                _digitBox.Text = PerformCalculations(_digitBox.Text);
                return true;
            }
            else if (inputed == "⌫")
            {
                _digitBox.Text = !string.IsNullOrWhiteSpace(_digitBox.Text)
                    ? _digitBox.Text.Substring(0, _digitBox.Text.Length - 1)
                    : _digitBox.Text;
                return true;
            }
            else if (inputed == "CE")
            {
                _digitBox.Text = string.Empty;
                return true;
            }
            return false;
        }
    }
}
