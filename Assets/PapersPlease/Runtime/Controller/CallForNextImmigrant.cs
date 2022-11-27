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

        public async Task Run()
        {
            await speaker.Listen();
            
            if(!IsFirstImmigrantToday)
                return;

            workday.Start();
        }
    }
}