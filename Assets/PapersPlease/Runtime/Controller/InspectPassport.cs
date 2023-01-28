using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class InspectPassport
    {
        WorkdayPerformance performance;

        public Task Run()
        {
            //TODO: accept or deny passport.
            return Task.CompletedTask;
        }
    }
}