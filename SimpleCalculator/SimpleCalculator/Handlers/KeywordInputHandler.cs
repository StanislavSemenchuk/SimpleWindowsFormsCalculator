using SimpleCalculator.Handlers.Bases;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers
{
    class KeywordInputHandler : InputHandler
    {
        private TextBox _digitBox;
        public KeywordInputHandler(ref TextBox outBox)
        {
            _digitBox = outBox;
        }

        /// <summary>
        /// chek if character is digit, dot, backspase or operation sign, and perform operation
        /// </summary>
        /// <param name="inputedChar"></param>
        /// <returns>return true if character is digit, dot, backspase or operation sign</returns>
        public override bool InputChecker(string inputed)
        {
            string allowedCharsRegexPattern = @"^(\d*(\.)?[\+\*\/-]?)$";
            //Check if character is digit, dot, backspase or operation sign
            if (!Regex.IsMatch(inputed.ToString(), allowedCharsRegexPattern))
            {
                if (inputed == ((char)Keys.Enter).ToString() || inputed == "=")
                {
                    _digitBox.Text = PerformCalculations(_digitBox.Text);
                    return true;
                }
                if (inputed == ((char)Keys.Back).ToString())
                {
                    _digitBox.Text = !string.IsNullOrWhiteSpace(_digitBox.Text)
                        ? _digitBox.Text.Substring(0, _digitBox.Text.Length - 1)
                        : _digitBox.Text;
                    return true;
                }
                return true;
            }
            return false;
        }
    }
}
