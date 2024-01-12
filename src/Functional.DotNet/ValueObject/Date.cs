using System;
using System.Security.Policy;

namespace Functional.DotNet.ValueObject
{
    using static F;

    /// <summary>
    /// Value Object
    /// </summary>
    /// <param name="year"></param>
    public record DayOfWeekInfo(DateTime date)
    {
        public const int JAN = 1;
        public const int DEC = 12;
        public const int LASTDAYOFDEC = 31;
        public const int FIRSTDAYOFJAN = 1;
        public const int THURSDAY = 4;

        private readonly Option<DateTime> dateStartYear;
        private readonly Option<DateTime> dateEndYear;

        public int DaysInFirstWeek => 8 - StartWeekDayOfYear;
        public int DaysInLastWeek => 8 - EndWeekDayOfYear;

        public int StartWeekDayOfYear => dateStartYear.GetDayOfWeek();
        public int EndWeekDayOfYear => dateEndYear.GetDayOfWeek();

        private readonly int DayOfYear;

        private bool ThursdayFlag =>
            StartWeekDayOfYear == THURSDAY || EndWeekDayOfYear == THURSDAY;

        private int WeekNumberInTheYear =>
            DaysInFirstWeek >= THURSDAY
                ? FullWeeks + 1
                : FullWeeks > 52 && !ThursdayFlag
                    ? 1
                    : FullWeeks;

        public Option<int> GetWeekNumber() =>
            WeekNumberInTheYear > 0
                ? WeekNumberInTheYear
                : None;

        // If the year either starts or ends on a thursday it will have a 53rd week
        public bool Is53WeeksYear =>
            StartWeekDayOfYear == THURSDAY || EndWeekDayOfYear == THURSDAY
                ? true
                : false;

        // We begin by calculating the number of FULL weeks between the start of the year and
        // our date. The number is rounded up, so the smallest possible value is 0.
        public int FullWeeks => (int)Math.Ceiling((DayOfYear - DaysInFirstWeek) / 7.0);


        protected DayOfWeekInfo(DayOfWeekInfo original)
        {
            dateStartYear = Date.Create(original.date.Year, JAN, FIRSTDAYOFJAN);
            dateEndYear = Date.Create(original.date.Year, DEC, LASTDAYOFDEC);
            DayOfYear = original.DayOfYear;
        }
    };

    public static class Date
    {

        public static Option<DateTime> Parse(string s) =>
            DateTime.TryParse(s, out DateTime d) ? Some(d) : None;

        public static Option<DateTime> Create(int year, int month, int day) =>
            Some(new DateTime(year, month, day));

        public static int ToInt(this Enum value) => Convert.ToInt32(value);

        public static int GetDayOfWeek(this Option<DateTime> date) =>
            date
                .Match
                (
                    Some: result => result.DayOfWeek.ToInt().AddMondayCompensation(),
                    None: () => 0
                );

        public static int GetDayOfYear(this Option<DateTime> date) =>
            date
                .Match
                (
                    Some: result => result.DayOfYear,
                    None: () => 0
                );


        public static int AddMondayCompensation(this int value) =>
            value == 0
                ? 7
                : value;
    }
}
