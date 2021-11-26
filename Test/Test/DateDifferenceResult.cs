namespace Test
{
    public class DateDifferenceResult
    {
        public DateDifferenceResult(int years = 0, int months = 0, int days = 0)
        {
            Years = years;
            Months = months;
            Days = days;
        }

        public int Years { get; set; }

        public int Months { get; set; }

        public int Days { get; set; }
    }
}
