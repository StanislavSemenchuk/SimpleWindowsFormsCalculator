using SimpleCalculator.Handlers;
using SimpleCalculator.Handlers.Interfaces;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Calculator : Form
    {
        private readonly InputPerformer _inputHandler;
        public Calculator()
        {
            InitializeComponent();
            _inputHandler = new InputPerformer(digitBox);
        }

        private void digitBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            _inputHandler.Perform(e.KeyChar.ToString());
        }

        private void button_Click(object sender, EventArgs e)
        {
            _inputHandler.Perform((sender as Button).Text);
        }

        private void digitBox_TextChanged(object sender, EventArgs e)
        {
            digitBox.SelectionStart = digitBox.Text.Length;
            digitBox.SelectionLength = 0;
            digitBox.Focus();
        }

        [DllImport("user32")] private static extern bool HideCaret(IntPtr hWnd);
        private void digitBox_GotFocus(object sender, EventArgs e)
        {
            HideCaret(digitBox.Handle);
        }
    }
}
