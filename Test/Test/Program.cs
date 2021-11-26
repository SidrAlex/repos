using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var date1 = new DateTime(2017, 2, 05);
            var date2 = new DateTime(2019, 11, 25);
            var dateCalculator = new DateCalculator(date1, date2);
            var dateDifferenceResult = dateCalculator.GetDateDifference();

            Console.WriteLine($"Difference of years between dates {date1} and {date2}: {dateDifferenceResult.Years}");
            Console.WriteLine($"Difference of months between dates {date1} and {date2}: {dateDifferenceResult.Months}");
            Console.WriteLine($"Difference of days between dates {date1} and {date2}: {dateDifferenceResult.Days}");

            Console.ReadKey();
        }
    }
}
