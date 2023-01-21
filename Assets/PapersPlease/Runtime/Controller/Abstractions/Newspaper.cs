using System;
using System.Threading;
using System.Threading.Tasks;

namespace PapersPlease.Runtime.Controller
{
    public interface Newspaper
    {
        Task Open(DateTime day, CancellationToken cancellationToken);
        Task Close();
    }
}