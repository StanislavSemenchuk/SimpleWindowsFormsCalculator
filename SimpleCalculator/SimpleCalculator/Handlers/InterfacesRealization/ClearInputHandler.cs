using SimpleCalculator.Handlers.Interfaces;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers.InterfacesRealization
{
    class ClearInputHandler : IInputHandler
    {
        private string _expression;
        private TextBox _digitBox;
        public ClearInputHandler(TextBox digitBox, ref string expression)
        {
            _expression = expression;
            _digitBox = digitBox;
        }
        public void InputChecker(string inputedChar)
        {
            _expression = string.Empty;
            _digitBox.Text = string.Empty;
        }
    }
}
