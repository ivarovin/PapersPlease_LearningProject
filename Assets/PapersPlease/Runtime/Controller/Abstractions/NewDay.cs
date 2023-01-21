using System;
using System.Threading;
using System.Threading.Tasks;

namespace PapersPlease.Runtime.Controller
{
    public interface NewDay
    {
        Task StartAt(DateTime day, CancellationToken cancellationToken);
    }
}