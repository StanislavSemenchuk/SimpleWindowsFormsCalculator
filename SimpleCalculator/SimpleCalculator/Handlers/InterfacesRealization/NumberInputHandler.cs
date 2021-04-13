using SimpleCalculator.Handlers.Helpers;
using SimpleCalculator.Handlers.Interfaces;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers.InterfacesRealization
{
    class NumberInputHandler : IInputHandler
    {
        private TextBox _digitBox;
        private WrapperHelper<bool> _operationPerformed;
        public NumberInputHandler(TextBox digitBox, WrapperHelper<bool> operationPerformed)
        {
            _digitBox = digitBox;
            _operationPerformed = operationPerformed;
        }
        public void InputChecker(string inputed)
        {
            PerformedChecker(_operationPerformed);
            if (char.IsDigit(inputed[0]) || inputed == "."
                && !_digitBox.Text.Contains(".")
                && _digitBox.Text.IndexOf(".") == -1)
            {
                _ = string.IsNullOrEmpty(_digitBox.Text) && inputed == "." ?
                    _digitBox.Text = $"0{inputed}" :
                    _digitBox.Text += inputed;
            }
        }
        /// <summary>
        /// Change operation performed state to false and cleanup textBox
        /// </summary>
        /// <param name="operationPerformed"></param
        private void PerformedChecker(WrapperHelper<bool> operationPerformed) 
        {
            if (operationPerformed.Value)
            {
                _digitBox.Text = string.Empty;
                operationPerformed.Value = false;
            }
        }
    }
}
