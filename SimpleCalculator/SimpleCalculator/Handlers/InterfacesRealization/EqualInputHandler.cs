using SimpleCalculator.Handlers.Helpers;
using SimpleCalculator.Handlers.Interfaces;
using System.Text;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers.InterfacesRealization
{
    class EqualInputHandler : IInputHandler
    {
        private TextBox _digitBox;
        private StringBuilder _expression;
        private CalculationPerformer _calculationPerformer;
        public EqualInputHandler(TextBox digitBox, StringBuilder expression)
        {
            _digitBox = digitBox;
            _expression = expression;
            _calculationPerformer = new CalculationPerformer();
        }
        public void InputChecker(string inputed)
        {
            if (inputed == "=" || inputed == ((char)Keys.Enter).ToString())
            {
                _expression.Append(_digitBox.Text);
                _digitBox.Text = _calculationPerformer.PerformCalculations(_expression.ToString());
                _digitBox.Text = _digitBox.Text.Replace(',', '.');
                _expression.Remove(0, _expression.Length);
            }
        }
    }
}
