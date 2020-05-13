using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class DateTimeExtensions
    {
        public static int Age(this DateTime source)
        {
            return source.AgeOn(DateTime.Today);
        }
        public static int AgeOn(this DateTime source, DateTime compare)
        {
            var result = compare.Year - source.Year;
            if (compare.Month < source.Month || (compare.Month == source.Month && compare.Day < source.Day))
                result -= 1;

            return result;
        }

        public static DateTime AddWeeks(this DateTime source, double value)
        {
            return source.AddDays(value * 7);
        }

        public static DateTime StartOfDay(this DateTime source)
        {
            return source.Date;
        }
        public static DateTime EndOfDay(this DateTime source)
        {
            return source.Date
                .AddDays(1)
                .AddMilliseconds(-1);
        }

        public static DateTime Yesterday(this DateTime source)
        {
            return source.Date.AddDays(-1);
        }
        public static DateTime Tomorrow(this DateTime source)
        {
            return source.Date.AddDays(1);
        }

        public static DateTime FirstDayOfTheMonth(this DateTime source)
        {
            return new DateTime(source.Year, source.Month, 1);
        }
        public static DateTime LastDayOfTheMonth(this DateTime source)
        {
            return source
                .FirstDayOfTheMonth()
                .AddMonths(1)
                .AddDays(-1);
        }

        public static DateTime WorkingDayOnOrBefore(this DateTime source, DayOfWeek publicHoliday1 = DayOfWeek.Sunday, DayOfWeek publicHoliday2 = DayOfWeek.Saturday)
        {
            return source
                .WorkingDayOnOrBefore(new[] { source.DayOfWeekOnOrBefore(publicHoliday1), source.DayOfWeekOnOrBefore(publicHoliday2) });
        }
        public static DateTime WorkingDayBefore(this DateTime source, DayOfWeek publicHoliday1 = DayOfWeek.Sunday, DayOfWeek publicHoliday2 = DayOfWeek.Saturday)
        {
            return source
                .WorkingDayBefore(new[] { source.DayOfWeekOnOrBefore(publicHoliday1), source.DayOfWeekOnOrBefore(publicHoliday2) });
        }
        public static DateTime WorkingDayOnOrAfter(this DateTime source, DayOfWeek publicHoliday1 = DayOfWeek.Sunday, DayOfWeek publicHoliday2 = DayOfWeek.Saturday)
        {
            return source
                .WorkingDayOnOrAfter(new[] { source.DayOfWeekOnOrAfter(publicHoliday1), source.DayOfWeekOnOrAfter(publicHoliday2) });
        }
        public static DateTime WorkingDayAfter(this DateTime source, DayOfWeek publicHoliday1 = DayOfWeek.Sunday, DayOfWeek publicHoliday2 = DayOfWeek.Saturday)
        {
            return source
                .WorkingDayAfter(new[] { source.DayOfWeekOnOrAfter(publicHoliday1), source.DayOfWeekOnOrAfter(publicHoliday2) });
        }

        public static DateTime WorkingDayOnOrBefore(this DateTime source, IEnumerable<DateTime> publicHolidays)
        {
            IEnumerable<DateTime> nonWorkingDays = publicHolidays.Union(new[] { source.DayOfWeekOnOrBefore(DayOfWeek.Saturday), source.DayOfWeekOnOrBefore(DayOfWeek.Sunday) });
            var value = source.Date;

            while (nonWorkingDays.Any(x => x.Date == value))
                value = value.AddDays(-1);

            return value.Date;
        }
        public static DateTime WorkingDayBefore(this DateTime source, IEnumerable<DateTime> publicHolidays)
        {
            return source
                .AddDays(-1)
                .WorkingDayOnOrBefore(publicHolidays);
        }
        public static DateTime WorkingDayOnOrAfter(this DateTime source, IEnumerable<DateTime> publicHolidays)
        {
            IEnumerable<DateTime> nonWorkingDays = publicHolidays.Union(new[] { source.DayOfWeekOnOrAfter(DayOfWeek.Saturday), source.DayOfWeekOnOrAfter(DayOfWeek.Sunday) });
            var value = source.Date;

            while (nonWorkingDays.Any(x => x.Date == value))
                value = value.AddDays(1);

            return value.Date;
        }
        public static DateTime WorkingDayAfter(this DateTime source, IEnumerable<DateTime> publicHolidays)
        {
            return source
                .AddDays(1)
                .WorkingDayOnOrAfter(publicHolidays);
        }

        public static DateTime DayOfWeekOnOrBefore(this DateTime source, DayOfWeek DayOfWeek)
        {
            int _valueDayOfWeek = (int)source.DayOfWeek;
            int _targetDayOfWeek = (int)DayOfWeek;
            int _difference = _valueDayOfWeek - _targetDayOfWeek;
            if (_difference < 0) _difference += 7;

            return source.Date.AddDays(-_difference);
        }
        public static DateTime DayOfWeekBefore(this DateTime source, DayOfWeek DayOfWeek)
        {
            int _valueDayOfWeek = (int)source.DayOfWeek;
            int _targetDayOfWeek = (int)DayOfWeek;
            int _difference = _valueDayOfWeek - _targetDayOfWeek;
            if (_difference <= 0) _difference += 7;

            return source.Date.AddDays(-_difference);
        }
        public static DateTime DayOfWeekOnOrAfter(this DateTime source, DayOfWeek DayOfWeek)
        {
            int _valueDayOfWeek = (int)source.DayOfWeek;
            int _targetDayOfWeek = (int)DayOfWeek;
            int _difference = _targetDayOfWeek - _valueDayOfWeek;
            if (_difference < 0) _difference += 7;

            return source.Date.AddDays(_difference);
        }
        public static DateTime DayOfWeekAfter(this DateTime source, DayOfWeek DayOfWeek)
        {
            int _valueDayOfWeek = (int)source.DayOfWeek;
            int _targetDayOfWeek = (int)DayOfWeek;
            int _difference = _targetDayOfWeek - _valueDayOfWeek;
            if (_difference <= 0) _difference += 7;

            return source.Date.AddDays(_difference);
        }

        public static DateTime NthDayOfWeekInMonth(this DateTime source, DayOfWeek dayOfWeek, int n)
        {
            if (n < 1 || 5 < n)
                throw new ArgumentOutOfRangeException(nameof(n), n, "n should be between 1 and 5 inclusive.");

            var result = source
                .FirstDayOfTheMonth()
                .DayOfWeekOnOrAfter(dayOfWeek)
                .AddWeeks(n - 1);

            if (result.Month != source.Month)
                result = result.AddWeeks(-1);

            return result;
        }
        public static DateTime LastDayOfWeekInMonth(this DateTime source, DayOfWeek dayOfWeek)
        {
            return source
                .LastDayOfTheMonth()
                .DayOfWeekOnOrBefore(dayOfWeek);
        }

        public static DateTime Midpoint(this DateTime date, DateTime otherDate)
        {
            TimeSpan _diff = date - otherDate;
            TimeSpan _mid = new TimeSpan(0, 0, 0, 0, (int)_diff.TotalMilliseconds / 2);
            return date - _mid;
        }

        public static TimeSpan EquationOfTimeEccentricEffect(this DateTime date)
        {
            double h = AverageAngle * (date.DayOfYear - 2);
            double v = h + (E360OverPi * Math.Sin(h.AsDegreesToRadians()));
            double m = ((h - v) * MinutesPerDegree);
            double s = (m - (int)m) * 60;
            double l = (s - (int)s) * 1000;

            return new TimeSpan(0, 0, (int)m, (int)s, (int)l);
        }
        public static TimeSpan EquationOfTimeTiltEffect(this DateTime date)
        {
            double e = AverageAngle * (date.DayOfYear - 80);
            e = (e >= 270 ? e - 360 : (e >= 90 ? e - 180 : e));
            double b = Math.Atan(Math.Cos(MaxEarthTilt.AsDegreesToRadians()) * Math.Tan(e.AsDegreesToRadians())).AsRadiansToDegrees();
            double m = ((e - b) * MinutesPerDegree);
            double s = (m - (int)m) * 60;
            double l = (s - (int)s) * 1000;

            return new TimeSpan(0, 0, (int)m, (int)s, (int)l);
        }
        public static TimeSpan EquationOfTimeTotal(this DateTime date)
        {
            return date.EquationOfTimeEccentricEffect() + date.EquationOfTimeTiltEffect();
        }

        public static DateTime SolarNoon(this DateTime date, double Longitude)
        {
            TimeSpan _eqTime = date.EquationOfTimeTotal();
            double m = 720 + (-Longitude * 4) - _eqTime.TotalMinutes;
            TimeSpan val = m.AsMinutesToTimeSpan();

            return new DateTime(date.Year, date.Month, date.Day, val.Hours, val.Minutes, val.Seconds, val.Milliseconds, DateTimeKind.Utc);
        }
        public static DateTime Sunrise(this DateTime date, double Latitude, double Longitude)
        {
            TimeSpan eqTime = date.EquationOfTimeTotal();
            double m = 720 + (4 * (-Longitude - date.HourAngleSunrise(Latitude))) - eqTime.TotalMinutes; // in minutes
            TimeSpan val = m.AsMinutesToTimeSpan();

            return new DateTime(date.Year, date.Month, date.Day, val.Hours, val.Minutes, val.Seconds, val.Milliseconds, DateTimeKind.Utc);
        }
        public static DateTime Sunset(this DateTime date, double Latitude, double Longitude)
        {
            TimeSpan eqTime = date.EquationOfTimeTotal();
            double m = 720 + (4 * (-Longitude - date.HourAngleSunset(Latitude))) - eqTime.TotalMinutes; // in minutes
            TimeSpan val = m.AsMinutesToTimeSpan();

            return new DateTime(date.Year, date.Month, date.Day, val.Hours, val.Minutes, val.Seconds, val.Milliseconds, DateTimeKind.Utc);
        }
        public static DateTime Dawn(this DateTime date, double Latitude, double Longitude, TwilightKind Kind)
        {
            TimeSpan eqTime = date.EquationOfTimeTotal();
            double m = 720 + (4 * (-Longitude - date.HourAngleDawn(Latitude, Kind))) - eqTime.TotalMinutes; // in minutes
            TimeSpan val = m.AsMinutesToTimeSpan();

            return new DateTime(date.Year, date.Month, date.Day, val.Hours, val.Minutes, val.Seconds, val.Milliseconds, DateTimeKind.Utc);
        }
        public static DateTime Dusk(this DateTime date, double Latitude, double Longitude, TwilightKind Kind)
        {
            TimeSpan eqTime = date.EquationOfTimeTotal();
            double m = 720 + (4 * (-Longitude - date.HourAngleDusk(Latitude, Kind))) - eqTime.TotalMinutes; // in minutes
            TimeSpan val = m.AsMinutesToTimeSpan();

            return new DateTime(date.Year, date.Month, date.Day, val.Hours, val.Minutes, val.Seconds, val.Milliseconds, DateTimeKind.Utc);
        }

        public static double HourAngleSunrise(this DateTime date, double Latitude)
        {
            return date.HourAngle(Latitude, 90.833);
        }
        public static double HourAngleSunset(this DateTime date, double Latitude)
        {
            return -date.HourAngleSunrise(Latitude);
        }
        public static double HourAngleDawn(this DateTime date, double Latitude, TwilightKind Kind)
        {
            double _geometricZenith;

            switch (Kind)
            {
                case TwilightKind.Nautical:
                    _geometricZenith = 102;
                    break;
                case TwilightKind.Astronomical:
                    _geometricZenith = 108;
                    break;
                case TwilightKind.Civil:
                default:
                    _geometricZenith = 96;
                    break;
            }

            return date.HourAngle(Latitude, _geometricZenith);
        }
        public static double HourAngleDusk(this DateTime date, double Latitude, TwilightKind Kind)
        {
            return -date.HourAngleDawn(Latitude, Kind);
        }
        public static double SolarDeclination(this DateTime date)
        {
            double h = AverageAngle * (date.DayOfYear - 2);
            double v = h + (E360OverPi * Math.Sin(h.AsDegreesToRadians()));
            return Math.Asin((MinutesPerDegree / 10) * Math.Sin((v - VAtVernalEquinox).AsDegreesToRadians())).AsRadiansToDegrees();
        }
        public static double HourAngle(this DateTime date, double Latitude, double GeometricZenith)
        {
            double latRad = Latitude.AsDegreesToRadians();
            double sdRad = date.SolarDeclination().AsDegreesToRadians();
            double someVal = GeometricZenith.AsDegreesToRadians();

            double HA = Math.Acos(Math.Cos(someVal) / (Math.Cos(latRad) * Math.Cos(sdRad)) - Math.Tan(latRad) * Math.Tan(sdRad));

            return HA.AsRadiansToDegrees();
        }

        public static double AsDegreesToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }
        public static double AsRadiansToDegrees(this double val)
        {
            return (180 / Math.PI) * val;
        }
        public static TimeSpan AsMinutesToTimeSpan(this double val)
        {
            double h = Math.Floor(val / 60);
            val -= h * 60;
            double s = (val - (int)val) * 60;
            double l = (s - (int)s) * 1000;

            return new TimeSpan(0, (int)h, (int)val, (int)s, (int)l);
        }

        private const double AverageAngle = 0.985653;
        private const double E360OverPi = 1.915169;
        private const double MinutesPerDegree = 3.98892;
        private const double MaxEarthTilt = 23.45;
        private const double VAtVernalEquinox = 78.74611803;

        public enum TwilightKind
        {
            Civil,
            Nautical,
            Astronomical
        }
    }
}
