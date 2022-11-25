using System;

namespace PapersPlease.Runtime.Model
{
    public class Workday
    {
        DateTime when;
        public TimeSpan TimeOfDay => when.TimeOfDay;
        public bool IsOver => when.TimeOfDay > TimeSpan.FromHours(18);

        bool isPassing;

        public static Workday FirstOne()
        {
            return new Workday()
            {
                when = new DateTime(1982, 11, 23).AddHours(6)
            };
        }
        
        public void SpendDay()
        {
            when = when.Date.AddDays(1).AddHours(6);
            isPassing = false;
        }

        public void Forward(TimeSpan howMuch)
        {
            if(!isPassing)
                return;
            
            when = when.Add(howMuch);
        }
        
        public void Start() => isPassing = true;
        
        public static implicit operator DateTime(Workday workday)
        {
            return workday.when;
        }
    }
}