using SimpleCalculator.Services;
using System.Windows.Forms;

namespace SimpleCalculator.Handlers.Helpers
{
    class CalculationPerformer
    {
        public string PerformCalculations(string equitationString)
        {
            return new CalculationService().CalculateEquitationFromString(equitationString);
        }
    }
}
