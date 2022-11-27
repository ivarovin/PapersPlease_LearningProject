using System.Threading.Tasks;

namespace PapersPlease.Runtime.Controller
{
    public class Gameplay
    {
        readonly ShowNewspaper showNewspaper;

        public Gameplay(ShowNewspaper showNewspaper)
        {
            this.showNewspaper = showNewspaper;
        }
        
        public async Task Run()
        {
            await showNewspaper.Run();
        }
    }
}