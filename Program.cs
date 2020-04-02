using System;
using System.Globalization;

namespace EasterCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1)
            {
                if (Int32.TryParse(args[0], out int year))
                {
                    WriteDates(year);
                }
                else
                {
                    WriteDates(DateTime.Today.Year);
                }
            }
            else
            {
                WriteDates(DateTime.Today.Year);
            }
        }

        static DateTime CalculateEasterDate(int year)
        {
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int month = (h + l - 7 * m + 114) / 31;
            int day = ((h + l - 7 * m + 114) % 31) + 1;
            return new DateTime(year, month, day, new GregorianCalendar());
        }

        static DateTime CalculateOrthodoxEasterDate(int year)
        {
            int a = year % 4;
            int b = year % 7;
            int c = year % 19;
            int d = (19 * c + 15) % 30;
            int e = (2 * a + 4*b - d + 34) % 7;
            int month = (d + e + 114) / 31;
            int day = ((d + e + 114) % 31) + 1;
            return new DateTime(year, month, day, new JulianCalendar()); 
        }

        static void WriteDates(int year)
        {
            Console.WriteLine($"Easter {year} is on {CalculateEasterDate(year).ToString("m")}.");
            Console.WriteLine($"Orthodox Easter {year} is on {CalculateOrthodoxEasterDate(year).ToString("m")}.");
        }
    }
}
