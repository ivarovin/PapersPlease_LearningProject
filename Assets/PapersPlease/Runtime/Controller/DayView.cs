using System;
using System.Threading.Tasks;

namespace PapersPlease.Runtime.Controller
{
    public interface DayView
    {
        Task Print(DateTime dateTime);
    }
}