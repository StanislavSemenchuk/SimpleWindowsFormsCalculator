using SimpleCalculator.Handlers;
using SimpleCalculator.Handlers.Interfaces;
using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Calculator : Form
    {
        private readonly IInputHandler _inputHandler;
        public Calculator()
        {
            InitializeComponent();
            _inputHandler = new InputHandler(digitBox);
        }

        private void digitBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = _inputHandler.InputChecker(e.KeyChar.ToString());
        }

        private void button_Click(object sender, EventArgs e)
        {
            _inputHandler.InputChecker((sender as Button).Text);
        }

        private void digitBox_TextChanged(object sender, EventArgs e)
        {
            digitBox.SelectionStart = digitBox.Text.Length;
            digitBox.SelectionLength = 0;
            digitBox.Focus();
        }
    }
}
