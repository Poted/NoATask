using System;
using System.Globalization;

namespace NoATask
{
    class Dates
    {
        #region Variables
        private static string? userInput;
        private static string[] dates;
        private static DateTime date1;
        private static DateTime date2;
        private static string output;
        #endregion

        static void Main(string[] args)
        {
            GettingInput();
            FormattingDates();
            GettingOutput();

            Console.ReadKey();
        }

        #region Methods
        static void InputException()
        {
            Console.WriteLine("Your input is invalid.");
            GettingInput();
        }

        static void GettingInput()
        {
            Console.WriteLine("Please, enter the dates.");
            userInput = Console.ReadLine();

            if (userInput != null && userInput.Length == 21)
            {
                dates = userInput.Split(" ");
                
                try
                {
                    date1 = Convert.ToDateTime(dates[0]);
                
                    date2 = Convert.ToDateTime(dates[1]);
                }

                catch (Exception)
                {
                    InputException();
                }
            }

            else
            {
                InputException();
            }
        }

        static void FormattingDates()
        {   
            DateTime dt;
            char separator;


            if (userInput.Contains('-'))
            {
                separator = '-';
            }

            else if (userInput.Contains('.'))
            {
                separator = '.';
            }

            else
            {
                separator = '\u2215';
            }

            string format = $"yyyy{ separator }MM{ separator }dd";

            if (DateTime.TryParseExact(dates[0], format, CultureInfo.CurrentCulture,
                                      DateTimeStyles.None, out dt)
                && DateTime.TryParseExact(dates[1], format, CultureInfo.CurrentCulture,
                                      DateTimeStyles.None, out dt))
            {
                if (date1.Year == date2.Year && date1.Month == date2.Month)
                {
                    output = String.Format(date1.ToString($"yyyy{separator}MM{separator}dd") + " - " + date2.ToString("dd"));
                }

                else if (date1.Year == date2.Year)
                {
                    output = String.Format(date1.ToString($"yyyy{separator}MM{separator}dd") + " - " + date2.ToString($"MM{separator}dd"));
                }

                else output = String.Format(date1.ToString($"yyyy{separator}MM{separator}dd" + " - " + date2.ToString($"yyyy{separator}MM{separator}dd")));
            }

            else
            {
                if (date1.Year == date2.Year && date1.Month == date2.Month)
                {
                    output = String.Format(date1.ToString("dd") + " - " + date2.ToString($"dd{separator}MM{separator}yyyy"));
                }

                else if (date1.Year == date2.Year)
                {
                    output = String.Format(date1.ToString($"dd{separator}MM") + " - " + date2.ToString($"dd{separator}MM{separator}yyyy"));
                }

                else output = String.Format(date1.ToString($"dd{separator}MM{separator}yyyy" + " - " + date2.ToString($"dd{separator}MM{separator}yyyy")));
            }

        }

        static void GettingOutput()
        {
            Console.WriteLine(output);
        }

        #endregion
    }
}
