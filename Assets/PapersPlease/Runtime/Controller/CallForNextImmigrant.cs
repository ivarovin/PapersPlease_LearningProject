using System;
using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class CallForNextImmigrant
    {
        readonly Workday workday;
        readonly Speaker speaker;

        const bool IsFirstImmigrantToday = true;

        public CallForNextImmigrant(Workday workday, Speaker speaker)
        {
            this.workday = workday;
            this.speaker = speaker;
        }

        public async Task Run(TimeSpan realtimeWorkday)
        {
            await speaker.Listen();
            await speaker.ShowCall();
            
            if(!IsFirstImmigrantToday)
                return;

            workday.Start(realtimeWorkday);
        }
    }
}