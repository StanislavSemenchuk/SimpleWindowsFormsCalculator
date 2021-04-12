using SimpleCalculator.Handlers.Interfaces;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers.InterfacesRealization
{
    class NumberInputHandler : IInputHandler
    {
        private TextBox _digitBox;
        public NumberInputHandler(TextBox digitBox)
        {
            _digitBox = digitBox;
        }
        public void InputChecker(string inputed)
        {
            if (char.IsDigit(inputed[0]) || inputed == "."
                && !_digitBox.Text.Contains(".")
                && _digitBox.Text.IndexOf(".") == -1)
            {
                _ = string.IsNullOrEmpty(_digitBox.Text) && inputed == "." ?
                    _digitBox.Text = $"0{inputed}" :
                    _digitBox.Text += inputed;
            }
        }
    }
}
