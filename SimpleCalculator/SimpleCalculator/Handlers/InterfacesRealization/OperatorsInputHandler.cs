using SimpleCalculator.Handlers.Helpers;
using SimpleCalculator.Handlers.Interfaces;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers.InterfacesRealization
{
    class OperatorsInputHandler : IInputHandler
    {
        private TextBox _digitBox;
        private string _expression;
        private CalculationPerformer _calculationPerformer;
        public OperatorsInputHandler(TextBox digitBox, ref string expression)
        {
            _digitBox = digitBox;
            _expression = expression;
            _calculationPerformer = new CalculationPerformer();
        }
        public void InputChecker(string inputed)
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
    }
}
