using System;
using NUnit.Framework;
using Test;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        //class under tests
        private DateCalculator _cut;

        [TestCase("12/30/1985", "11/26/2021", 35, 10, 27)]
        [TestCase("11/26/2021", "12/30/1985", 35, 10, 27)]
        [TestCase("11/27/2019", "11/26/2021", 01, 11, 29)]
        [TestCase("11/26/2021", "11/27/2019", 01, 11, 29)]
        [TestCase("11/30/1985", "01/01/2021", 35, 01, 01)]
        [TestCase("01/01/2021", "11/30/1985", 35, 01, 01)]
        [TestCase("02/15/2019", "02/15/2019", 0, 0, 0)]
        [TestCase("02/15/2019", "02/16/2019", 0, 0, 01)]
        [TestCase("02/16/2019", "02/15/2019", 0, 0, 01)]
        [TestCase("03/31/2019", "03/01/2019", 0, 0, 30)]
        [TestCase("03/01/2019", "03/31/2019", 0, 0, 30)]
        [TestCase("02/20/1985", "10/26/2021", 36, 08, 03)]
        [TestCase("10/26/2021", "02/20/1985", 36, 08, 03)]
        [TestCase("12/31/1999", "02/01/2020", 20, 01, 01)]
        public void GetDateDifference_PassVariousDates_Success(DateTime firstDate, DateTime secondDate, int yearsExpected, int monthsExpected, int daysExpected)
        {
            //arrange
            _cut = new DateCalculator(firstDate, secondDate);

            //act
            var result = _cut.GetDateDifference();

            //assert
            Assert.AreEqual(yearsExpected, result.Years, $"Incorrect difference of years for {firstDate} and {secondDate}");
            Assert.AreEqual(monthsExpected, result.Months, $"Incorrect difference of months for {firstDate} and {secondDate}");
            Assert.AreEqual(daysExpected, result.Days, $"Incorrect difference of days for {firstDate} and {secondDate}");
        }
    }
}