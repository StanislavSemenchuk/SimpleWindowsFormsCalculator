using SimpleCalculator.Handlers.Interfaces;
using SimpleCalculator.Handlers.InterfacesRealization;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers
{
    class InputPerformer
    {
        private readonly TextBox _digitBox;
        private readonly StringBuilder _expressionBuilder;
        private readonly Dictionary<string, IInputHandler> _strategyPairs;
        #region handlers disclosure
        private IInputHandler _numberHandler;
        private IInputHandler _operatorsHandler;
        private IInputHandler _backSpaseHandler;
        private IInputHandler _equalHandler;
        private IInputHandler _clearHandler;
        #endregion
        public InputPerformer(TextBox outBox)
        {
            _digitBox = outBox;
            _expressionBuilder = new StringBuilder(string.Empty);
            _strategyPairs = new Dictionary<string, IInputHandler>();
            InitializeDictionary();
        }
        public void Perform(string inputed)
        {
            if (_strategyPairs.ContainsKey(inputed)) 
            {
                _strategyPairs[inputed].InputChecker(inputed);
            }
        }

        /// <summary>
        /// Method whitch initialize dictionary with allowed strings/theirs handler pairs
        /// </summary>
        private void InitializeDictionary() 
        {
            #region initializing handlers
            _numberHandler = new NumberInputHandler(_digitBox);
            _operatorsHandler = new OperatorsInputHandler(_digitBox, _expressionBuilder);
            _backSpaseHandler = new BackSpaceInputHandler(_digitBox);
            _equalHandler = new EqualInputHandler(_digitBox, _expressionBuilder);
            _clearHandler = new ClearInputHandler(_digitBox, _expressionBuilder);
            #endregion
            #region initializating dictionary values
            //digits and points
            _strategyPairs.Add("0", _numberHandler);
            _strategyPairs.Add("1", _numberHandler);
            _strategyPairs.Add("2", _numberHandler);
            _strategyPairs.Add("3", _numberHandler);
            _strategyPairs.Add("4", _numberHandler);
            _strategyPairs.Add("5", _numberHandler);
            _strategyPairs.Add("6", _numberHandler);
            _strategyPairs.Add("7", _numberHandler);
            _strategyPairs.Add("8", _numberHandler);
            _strategyPairs.Add("9", _numberHandler);
            _strategyPairs.Add(".", _numberHandler);
            //operators
            _strategyPairs.Add("+", _operatorsHandler);
            _strategyPairs.Add("-", _operatorsHandler);
            _strategyPairs.Add("*", _operatorsHandler);
            _strategyPairs.Add("/", _operatorsHandler);
            //equal operations
            _strategyPairs.Add("=", _equalHandler);
            _strategyPairs.Add(((char)Keys.Enter).ToString(), _equalHandler);
            //backspace handler
            _strategyPairs.Add("⌫", _backSpaseHandler);
            _strategyPairs.Add(((char)Keys.Back).ToString(), _backSpaseHandler);
            //clear handler
            _strategyPairs.Add("C", _clearHandler);
            #endregion
        }
    }
}
