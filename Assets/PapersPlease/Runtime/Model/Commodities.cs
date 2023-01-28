namespace PapersPlease.Runtime.Model
{
    internal record Commodities
    {
        public int Heat { get; set; }
        public int Food { get; set; }
        public static Commodities Default => new Commodities
        {
            Heat = 10,
            Food = 20
        };
    }
}