using System;
using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class Gameplay
    {
        readonly ShowNewspaper showNewspaper;
        readonly StartDay startDay;
        readonly CallForNextEntrant callNext;
        readonly InspectPassport inspectPassport;
        readonly EndDay endDay;

        readonly Workday workdayModel;

        public Gameplay(ShowNewspaper showNewspaper, StartDay startDay, CallForNextEntrant callNext, EndDay endDay,
                        Workday workdayModel, InspectPassport inspectPassport)
        {
            this.showNewspaper = showNewspaper;
            this.startDay = startDay;
            this.callNext = callNext;
            this.endDay = endDay;
            this.workdayModel = workdayModel;
            this.inspectPassport = inspectPassport;
        }

        public async Task Run(TimeSpan realtimeWorkday)
        {
            while(true)
            {
                await showNewspaper.Run();
                await startDay.Run();

                do
                {
                    await callNext.Run(realtimeWorkday);
                    await inspectPassport.Run();
                } while(!workdayModel.IsOver);

                await endDay.Run();
            }
        }
    }
}