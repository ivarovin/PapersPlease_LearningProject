using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class ShowNewspaper
    {
        readonly WalkToWork walkToWork;
        readonly Newspaper newspaper;
        readonly Workday day;

        public ShowNewspaper(WalkToWork walkToWork, Newspaper newspaper, Workday day)
        {
            this.walkToWork = walkToWork;
            this.newspaper = newspaper;
            this.day = day;
        }

        public async Task Run()
        {
            await newspaper.Open(day);
            await walkToWork.Listen();
            await newspaper.Close();
        }
    }
}