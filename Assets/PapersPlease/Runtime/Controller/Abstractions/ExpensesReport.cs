using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public interface ExpensesReport
    {
        Task<Bills> OfDay(int day, EconomicBalance balance);
        Task Close();
    }
}