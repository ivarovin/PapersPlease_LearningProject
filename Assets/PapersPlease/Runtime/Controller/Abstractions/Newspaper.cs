using System;
using System.Threading.Tasks;

namespace PapersPlease.Runtime.Controller
{
    public interface Newspaper
    {
        Task Open(DateTime day);
        Task Close();
    }
}