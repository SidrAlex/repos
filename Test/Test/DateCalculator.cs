using System;

namespace Test
{
    public class DateCalculator
    {

        private readonly DateTime _shorterDate;
        private readonly DateTime _largerDate;

        private int GetMonthsDifference()
        {
            return 11 - _shorterDate.Month + _largerDate.Month;
        }

        private int GetYearsDifference(int monthsBalanceFromBothYears)
        {
            return monthsBalanceFromBothYears >= 12 ? _largerDate.Year - _shorterDate.Year : _largerDate.Year - _shorterDate.Year - 1;
        }

        private Tuple<int, int> GetDaysDifference()
        {
            var shorterDateDaysBalance = (new DateTime(_shorterDate.Year, _shorterDate.Month, 01).AddMonths(1).AddDays(-1) - _shorterDate).Days;
            var largerDateDaysBalance = (_largerDate - new DateTime(_largerDate.Year, _largerDate.Month, 01).AddDays(-1)).Days;
            var largerDateWithShorterDateBalance = _largerDate.AddDays(shorterDateDaysBalance);
            var result = largerDateWithShorterDateBalance.Month > _largerDate.Month ?
                new Tuple<int, int>(largerDateWithShorterDateBalance.Day, 1) :
                new Tuple<int, int>(largerDateDaysBalance + shorterDateDaysBalance, 0);

            return result;
        }

        public DateCalculator(DateTime firstDate, DateTime secondDate)
        {
            if (firstDate > secondDate)
            {
                _largerDate = firstDate;
                _shorterDate = secondDate;
            } else
            {
                _shorterDate = firstDate;
                _largerDate = secondDate;
            }
        }

        public DateDifferenceResult GetDateDifference()
        {
            if (_shorterDate == _largerDate)
            {
                return new DateDifferenceResult();
            }
            if (_shorterDate.Year == _largerDate.Year && _shorterDate.Month == _largerDate.Month)
            {
                return new DateDifferenceResult(0, 0, _largerDate.Day - _shorterDate.Day);
            }
            var (days, additionalMonths) = GetDaysDifference();
            var monthsFromBothYears = GetMonthsDifference();
            var years = GetYearsDifference(monthsFromBothYears);
            var months = monthsFromBothYears >= 12 ? monthsFromBothYears - 12 : monthsFromBothYears;
            months += additionalMonths;

            return new DateDifferenceResult(years, months, days);
        }
    }

}
