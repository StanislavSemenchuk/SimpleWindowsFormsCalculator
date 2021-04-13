using SimpleCalculator.Handlers.Interfaces;
using System.Text;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers.InterfacesRealization
{
    class ClearInputHandler : IInputHandler
    {
        private StringBuilder _expression;
        private TextBox _digitBox;
        public ClearInputHandler(TextBox digitBox, StringBuilder expression)
        {
            _expression = expression;
            _digitBox = digitBox;
        }
        public void InputChecker(string inputedChar)
        {
            _expression.Remove(0, _expression.Length);
            _digitBox.Text = string.Empty;
        }
    }
}
