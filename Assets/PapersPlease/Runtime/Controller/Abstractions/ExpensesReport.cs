using System.Threading.Tasks;

namespace PapersPlease.Runtime.Controller
{
    public interface ExpensesReport
    {
        Task OfDay(int day);
    }
}