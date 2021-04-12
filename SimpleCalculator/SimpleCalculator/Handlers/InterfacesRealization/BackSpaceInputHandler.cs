using SimpleCalculator.Handlers.Interfaces;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers.InterfacesRealization
{
    class BackSpaceInputHandler : IInputHandler
    {
        private TextBox _digitBox;
        public BackSpaceInputHandler(TextBox digitBox)
        {
            _digitBox = digitBox;
        }
        public void InputChecker(string inputed)
        {
            if (inputed == "⌫" || inputed == ((char)Keys.Back).ToString())
            {
                _digitBox.Text = !string.IsNullOrWhiteSpace(_digitBox.Text)
                    ? _digitBox.Text.Substring(0, _digitBox.Text.Length - 1)
                    : _digitBox.Text;
            }
        }
    }
}
