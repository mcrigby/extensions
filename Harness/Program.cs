using System;

namespace Harness
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = DateTime.Now;
            Console.WriteLine($"Now: {date}");
            Console.WriteLine();
            Console.WriteLine($"Tuesday Before: {date.DayOfWeekBefore(DayOfWeek.Tuesday)}");
            Console.WriteLine($"Wednesday Before: {date.DayOfWeekBefore(DayOfWeek.Wednesday)}");
            Console.WriteLine($"Thursday Before: {date.DayOfWeekBefore(DayOfWeek.Thursday)}");
            Console.WriteLine($"Tuesday On or Before: {date.DayOfWeekOnOrBefore(DayOfWeek.Tuesday)}");
            Console.WriteLine($"Wednesday On or Before: {date.DayOfWeekOnOrBefore(DayOfWeek.Wednesday)}");
            Console.WriteLine($"Thursday On or Before: {date.DayOfWeekOnOrBefore(DayOfWeek.Thursday)}");
            Console.WriteLine();
            Console.WriteLine($"Tuesday After: {date.DayOfWeekAfter(DayOfWeek.Tuesday)}");
            Console.WriteLine($"Wednesday After: {date.DayOfWeekAfter(DayOfWeek.Wednesday)}");
            Console.WriteLine($"Thursday After: {date.DayOfWeekAfter(DayOfWeek.Thursday)}");
            Console.WriteLine($"Tuesday On or After: {date.DayOfWeekOnOrAfter(DayOfWeek.Tuesday)}");
            Console.WriteLine($"Wednesday On or After: {date.DayOfWeekOnOrAfter(DayOfWeek.Wednesday)}");
            Console.WriteLine($"Thursday On or After: {date.DayOfWeekOnOrAfter(DayOfWeek.Thursday)}");
            Console.WriteLine();
            Console.WriteLine($"First Of the Month: {date.FirstDayOfTheMonth()}");
            Console.WriteLine($"Last of the Month: {date.LastDayOfTheMonth()}");
            Console.WriteLine();
            Console.WriteLine($"Yesterday: {date.Yesterday()}");
            Console.WriteLine($"Tomorrow: {date.Tomorrow()}");
            Console.WriteLine($"Start of Day: {date.StartOfDay()}");
            Console.WriteLine($"End of Day: {date.EndOfDay()}");
            Console.WriteLine();
            Console.WriteLine($"Working Day On Or Before: {date.WorkingDayOnOrBefore(DayOfWeek.Monday, DayOfWeek.Tuesday)}");
            Console.WriteLine($"Working Day Before: {date.WorkingDayBefore(DayOfWeek.Monday, DayOfWeek.Tuesday)}");
            Console.WriteLine();
            Console.WriteLine($"Working Day On Or After: {date.WorkingDayOnOrAfter(DayOfWeek.Thursday, DayOfWeek.Friday)}");
            Console.WriteLine($"Working Day After: {date.WorkingDayAfter(DayOfWeek.Thursday, DayOfWeek.Friday)}");
            Console.WriteLine();
            Console.WriteLine($"2nd Tuesday: {date.NthDayOfWeekInMonth(DayOfWeek.Tuesday, 2)}");
            Console.WriteLine($"5th Tuesday: {date.NthDayOfWeekInMonth(DayOfWeek.Tuesday, 5)}");
            Console.WriteLine($"Last Wednesday: {date.LastDayOfWeekInMonth(DayOfWeek.Wednesday)}");
            Console.WriteLine();

            var birthday = new DateTime(1982, 8, 31);
            for (var i = 0; i < 365; i++)
                Console.WriteLine($"Age of {birthday} on {date.AddDays(i)}: {birthday.AgeOn(date.AddDays(i))}");
            Console.WriteLine();
            for (var i = 0; i < 365; i++)
                Console.WriteLine($"Age of {date.AddDays(i)} on {birthday}: {date.AddDays(i).AgeOn(birthday)}");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
