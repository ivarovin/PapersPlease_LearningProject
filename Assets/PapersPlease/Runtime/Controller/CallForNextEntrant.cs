using System;
using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class CallForNextEntrant
    {
        readonly Workday workday;
        readonly Speaker speaker;

        const bool IsFirstEntrantToday = true;

        public CallForNextEntrant(Workday workday, Speaker speaker)
        {
            this.workday = workday;
            this.speaker = speaker;
        }

        public async Task Run(TimeSpan realtimeWorkday)
        {
            await speaker.Listen();
            await speaker.ShowCall();
            
            if(!IsFirstEntrantToday)
                return;

            workday.Start(realtimeWorkday);
        }
    }
}