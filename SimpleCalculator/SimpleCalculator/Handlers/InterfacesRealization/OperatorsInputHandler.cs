using SimpleCalculator.Handlers.Helpers;
using SimpleCalculator.Handlers.Interfaces;
using System.Text;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers.InterfacesRealization
{
    class OperatorsInputHandler : IInputHandler
    {
        private TextBox _digitBox;
        private StringBuilder _expression;
        private CalculationPerformer _calculationPerformer;
        private WrapperHelper<bool> _operationPerformed;
        public OperatorsInputHandler(TextBox digitBox, StringBuilder expression, WrapperHelper<bool> operationPerformed)
        {
            _digitBox = digitBox;
            _expression = expression;
            _operationPerformed = operationPerformed;
            _calculationPerformer = new CalculationPerformer();
        }
        public void InputChecker(string inputed)
        {
            if (_expression.ToString().IndexOfAny(new char[] { '+', '-', '*', '/' }) == -1)
            {
                _expression.Append(_digitBox.Text + inputed);
            }
            else
            {
                _expression.Append(_digitBox.Text);
                _expression.Replace(_expression.ToString(), _calculationPerformer.PerformCalculations(_expression.ToString()) + inputed);
                _expression.Replace(',', '.');
            }
            _digitBox.Text = _expression.ToString();
            ChangeOperationState(_operationPerformed);
        }
        private void ChangeOperationState(WrapperHelper<bool> operationPerformed)
        {
            operationPerformed.Value = true;
        }
    }
}
