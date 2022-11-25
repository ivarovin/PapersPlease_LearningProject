using System;
using System.Threading.Tasks;

namespace PapersPlease.Runtime.Controller
{
    public interface DayView
    {
        Task PrintAtStart(DateTime dateTime);
        Task PrintAtEnd(DateTime dateTime);
    }
}