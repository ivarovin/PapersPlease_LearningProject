using System;

namespace PapersPlease.Runtime.Model
{
    public class Workday
    {
        readonly Worktime schedule = Worktime.Default;
        DateTime now;
        
        public TimeSpan TimeOfDay => now.TimeOfDay;
        public bool IsOver => TimeToOver < TimeSpan.Zero;
        public TimeSpan TimeToOver => schedule.End - now.TimeOfDay;
        public int DaysSinceBeginning => (int)now.Subtract(FirstOne().now).TotalDays; 

        bool isPassing;

        public Workday(DateTime day)
        {
            now = day + schedule.Start;
        }

        public static Workday FirstOne()
        {
            return new Workday(new DateTime(1982, 11, 23));
        }
        
        public void SpendDay()
        {
            now = now.Date.AddDays(1) + schedule.Start;
            isPassing = false;
        }

        public void Forward(TimeSpan howMuch)
        {
            if(!isPassing)
                return;
            
            now = now.Add(howMuch);
        }
        
        public void Start() => isPassing = true;
        
        public static implicit operator DateTime(Workday workday)
        {
            return workday.now;
        }
    }
}