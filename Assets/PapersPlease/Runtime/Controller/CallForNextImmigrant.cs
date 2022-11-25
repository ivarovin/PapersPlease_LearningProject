using System;
using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class CallForNextImmigrant
    {
        readonly Workday workday;
        
        const bool IsFirstImmigrantToday = true;

        public CallForNextImmigrant(Workday workday)
        {
            this.workday = workday;
        }
        
        public async Task Execute()
        {
            if(!IsFirstImmigrantToday)
                return;

            workday.Start();
        }
    }
}