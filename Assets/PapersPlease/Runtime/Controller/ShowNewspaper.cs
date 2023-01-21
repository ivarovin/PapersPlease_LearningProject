using System.Threading;
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

        public async Task Run(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await newspaper.Open(day, token);
            await walkToWork.Listen();
            await newspaper.Close();
        }
    }
}