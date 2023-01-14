using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public interface ExpensesReport
    {
        Task OfDay(int day, EconomicBalance balance);
    }
}