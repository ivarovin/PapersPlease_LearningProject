using System;
using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class TimePassage
    {
        readonly Workday day;
        readonly Clock view;
        TaskCompletionSource<bool> promise;

        public TimePassage(Workday day, Clock view)
        {
            this.day = day;
            this.view = view;
        }

        /// Ahora como mucho te pasa el mismo día de una vez, nunca más de uno.
        public void Inject(TimeSpan time)
        {
            day.Forward(time < day.TimeToOver ? time : day.TimeToOver);

            view.Print(day.TimeOfDay);

            if(day.IsOver)
                promise?.SetResult(true);
        }

        public async Task WaitForEndOfWorkday()
        {
            promise = new TaskCompletionSource<bool>();
            await promise.Task;
        }
    }
}