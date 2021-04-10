using SimpleCalculator.Services;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers.Helpers
{
    class CalculationPerformer
    {
        public string PerformCalculations(string equitationString)
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
    }
}
