using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class Gameplay
    {
        readonly ShowNewspaper showNewspaper;
        readonly StartDay startDay;
        readonly CallForNextImmigrant callNext;
        readonly EndDay endDay;

        readonly Workday workdayModel;

        public Gameplay(ShowNewspaper showNewspaper, StartDay startDay, CallForNextImmigrant callNext, TimePassage timePassage, EndDay endDay, Workday workdayModel)
        {
            this.showNewspaper = showNewspaper;
            this.startDay = startDay;
            this.callNext = callNext;
            this.endDay = endDay;
            this.workdayModel = workdayModel;
        }

        public async Task Run()
        {
            while(true)
            {
                await showNewspaper.Run();
                await startDay.Run();

                do { await callNext.Run(); }
                while(!workdayModel.IsOver);

                await endDay.Run();
            }
        }
    }
}