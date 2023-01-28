namespace PapersPlease.Runtime.Model
{
    //TODO: meter dentro de Workday.
    public class WorkdayPerformance
    {
        public int Hits { get; set; }
        public int Faults { get; set; }

        public static WorkdayPerformance Zero { get; } = new() { Hits = 0, Faults = 0 };
        
        public static WorkdayPerformance WithHits(int hits) => new() { Hits = hits, Faults = 0 };
        public static WorkdayPerformance WithFaults(int faults) => new() { Hits = 0, Faults = faults };
    }
}