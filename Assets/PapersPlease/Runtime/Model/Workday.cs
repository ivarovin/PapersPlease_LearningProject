using System;

namespace PapersPlease.Runtime.Model
{
    public class Workday
    {
        readonly Worktime schedule = Worktime.Default;
        DateTime date;
        bool isPassing;

        public TimeSpan TimeOfDay => date.TimeOfDay;
        
        public bool IsOver => TimeToOver <= TimeSpan.FromSeconds(1);
        public TimeSpan TimeToOver => schedule.End - date.TimeOfDay;
        
        public int DaysSinceBeginning => (int)date.Subtract(FirstOne.date).TotalDays + 1; 
        
        public Workday(DateTime day)
        {
            date = day + schedule.Start;
        }

        public static Workday FirstOne { get; } = new(new DateTime(1982, 11, 23));

        public void Start() => isPassing = true;

        
        public void SpendDay()
        {
            date = date.Date.AddDays(1) + schedule.Start;
            isPassing = false;
        }

        public void Forward(TimeSpan howMuch)
        {
            if(!isPassing)
                return;
            
            date = date.Add(howMuch);
        }
        
        public static implicit operator DateTime(Workday workday)
        {
            return workday.date;
        }
    }
}