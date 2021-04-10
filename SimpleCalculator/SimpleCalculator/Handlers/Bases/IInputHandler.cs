using SimpleCalculator.Services;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers.Bases
{
    abstract class InputHandler
    {
        /// <summary>
        /// Perform Calculation of expression
        /// </summary>
        /// <param name="equitationString"></param>
        /// <returns>string with result of math expression</returns>
        protected string PerformCalculations(string equitationString) 
        {
            try
            {
                return new CalculationService().CalculateEquitationFromString(equitationString);
            }
            catch 
            {
                MessageBox.Show("Something wrong with your expression. \n" +
                    "Rules:\n" +
                    "- One number might have only one dot\n" +
                    "- Calculator not supported expressions like : '+-', '-+' etc");
                return equitationString;
            }
        }

        public abstract bool InputChecker(string inputedChar);
    }
}
