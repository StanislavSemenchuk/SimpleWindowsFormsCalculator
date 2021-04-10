using System.Data;
using System.Windows.Forms;

namespace SimpleCalculator.Services
{
    class CalculationService
    {
        public string CalculateEquitationFromString(string equitation)
        {
            return new DataTable().Compute(equitation, "").ToString();
        }
    }
}
