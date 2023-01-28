namespace PapersPlease.Runtime.Model
{
    public readonly struct Magnitude
    {
        readonly string value;

        public Magnitude(string value)
        {
            this.value = value;
        }
        
        public static Magnitude Salary => new Magnitude("Salary");
        public static Magnitude Savings => new Magnitude("Savings");
        public static Magnitude Rent => new Magnitude("Rent");
        public static Magnitude Penalties => new Magnitude("Penalties");
        public static Magnitude Food => new Magnitude("Food");
        public static Magnitude Heat => new Magnitude("Heat");

        public override string ToString()
        {
            return value;
        }
        
        public static implicit operator Magnitude(string value)
        {
            return new Magnitude(value);
        }
        
        public static implicit operator string(Magnitude value)
        {
            return value.value;
        }
    }
}