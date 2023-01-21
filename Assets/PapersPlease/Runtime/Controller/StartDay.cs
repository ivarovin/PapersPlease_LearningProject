using System.Threading;
using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class StartDay
    {
        readonly Workday model;
        readonly NewDay view;
        
        public StartDay(Workday model, NewDay view)
        {
            this.model = model;
            this.view = view;
        }

        public Task Run(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return view.StartAt(model, token);
        }
    }
}