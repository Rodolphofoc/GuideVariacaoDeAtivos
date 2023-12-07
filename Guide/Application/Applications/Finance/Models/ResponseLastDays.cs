namespace Applications.Finance.Models
{
    public class ResponseLastDays
    {
        public DateTime Data { get; set; }

        public int Day { get; set; } = 0;

        public float Value { get; set; }

        public double Percent { get; set; }

        public double PercentComparedFistDate { get; set; }


    }
}
