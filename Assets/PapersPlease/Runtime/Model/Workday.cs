using System;

namespace PapersPlease.Runtime.Model
{
    public class Workday
    {
        readonly Worktime schedule = Worktime.Default;
        TimeSpan realtimeDuration;
        DateTime date;
        bool isPassing;

        public TimeSpan TimeOfDay => date.TimeOfDay;
        
        public bool IsOver => TimeToOver <= TimeSpan.FromSeconds(1);
        public TimeSpan TimeToOver => schedule.End - date.TimeOfDay;
        
        public int DaysSinceBeginning => 1 + (int)date.Date.Subtract(FirstOne.date.Date).TotalDays; 
        
        public Workday(DateTime day)
        {
            date = day + schedule.Start;
        }
        
        public Workday(DateTime day, Worktime schedule)
        {
            this.schedule = schedule;
            date = day + schedule.Start;
        }

        public static Workday FirstOne => new(new DateTime(1982, 11, 23));

        [Obsolete("To be deleted.")]
        public void Start() => Start(schedule.Duration);
        public void Start(TimeSpan thisRealtimeDuration)
        {
            realtimeDuration = thisRealtimeDuration;
            isPassing = true;
        }


        public void SpendDay()
        {
            date = date.Date.AddDays(1) + schedule.Start;
            isPassing = false;
        }

        public void Forward(TimeSpan realTime)
        {
            if(!isPassing)
                return;
            
            var virtualTime = realTime * (schedule.Duration / realtimeDuration);
            date = date.Add(virtualTime < TimeToOver ? virtualTime : TimeToOver);
        }
        
        public static implicit operator DateTime(Workday workday)
        {
            return workday.date;
        }
    }
}