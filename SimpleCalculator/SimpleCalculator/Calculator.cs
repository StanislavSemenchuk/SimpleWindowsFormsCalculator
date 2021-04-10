using SimpleCalculator.Handlers;
using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        bool isPerformed = false;

        private void digitBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = new KeywordInputHandler(ref digitBox).InputChecker(e.KeyChar.ToString());
        }

        private void button_Click(object sender, EventArgs e)
        {
            isPerformed = new UIButtonInputHandler(ref digitBox).InputChecker((sender as Button).Text);
        }

        private void digitBox_TextChanged(object sender, EventArgs e)
        {
            digitBox.SelectionStart = digitBox.Text.Length;
            digitBox.SelectionLength = 0;
            digitBox.Focus();
        }
    }
}
