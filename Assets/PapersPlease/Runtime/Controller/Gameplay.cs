using System;
using System.Threading;
using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class Gameplay
    {
        readonly ShowNewspaper showNewspaper;
        readonly StartDay startDay;
        readonly CallForNextEntrant callNext;
        readonly EndDay endDay;

        readonly Workday workdayModel;

        public Gameplay(ShowNewspaper showNewspaper, StartDay startDay, CallForNextEntrant callNext, TimePassage timePassage, EndDay endDay, Workday workdayModel)
        {
            this.showNewspaper = showNewspaper;
            this.startDay = startDay;
            this.callNext = callNext;
            this.endDay = endDay;
            this.workdayModel = workdayModel;
        }

        public async Task Run(TimeSpan realtimeWorkday, CancellationToken token)
        {
            while(true)
            {
                token.ThrowIfCancellationRequested();
                await showNewspaper.Run(token);
                await startDay.Run(token);

                do { await callNext.Run(realtimeWorkday); }
                while(!workdayModel.IsOver);

                await endDay.Run();
            }
        }
    }
}