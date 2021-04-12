using SimpleCalculator.Handlers.Helpers;
using SimpleCalculator.Handlers.Interfaces;
using System;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers.InterfacesRealization
{
    class EqualInputHandler : IInputHandler
    {
        private TextBox _digitBox;
        private String _expression;
        private CalculationPerformer _calculationPerformer;
        public EqualInputHandler(TextBox digitBox, string expression)
        {
            _digitBox = digitBox;
            _expression = expression;
            _calculationPerformer = new CalculationPerformer();
        }
        public void InputChecker(string inputed)
        {
            if (inputed == "=" || inputed == ((char)Keys.Enter).ToString())
            {
                _expression += _digitBox.Text;
                _digitBox.Text = _calculationPerformer.PerformCalculations(_expression);
                _digitBox.Text = _digitBox.Text.Replace(',', '.');
                _expression = string.Empty;
            }
        }
    }
}
