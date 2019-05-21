using System;
using System.Globalization;

namespace PersonalAccounting
{
    class Class_Persian_Date
    {
        #region Property
        private static PersianCalendar pc = new PersianCalendar();
        private static DateTime dt_now = DateTime.Parse(DateTime.Now.ToString());
        private static readonly int Day = pc.GetDayOfMonth(dt_now);
        private static int Month = pc.GetMonth(dt_now);
        private static readonly int Year = pc.GetYear(dt_now);
        private static readonly int GetDayMonth = pc.GetDaysInMonth(Year, Month);
        private static readonly DayOfWeek GetDayWeek = pc.GetDayOfWeek(dt_now);
        private static string DayName = dt_now.DayOfWeek.ToString();
        private static string Week_Name;
        private static bool Leap;//Kabise
        #endregion

        #region Public Methods
        public static string ShowShamsiToday(DateTime dt)
        {
            string year = pc.GetYear(dt).ToString("0000");
            string mounth = pc.GetMonth(dt).ToString("00");
            string day = pc.GetDayOfMonth(dt).ToString("00");
            return year + "/" + mounth + "/" + day;
        }
        public static string ShowTime()
        {
            string Hour = pc.GetHour(DateTime.Now).ToString("0#");
            string Minute = pc.GetMinute(DateTime.Now).ToString("0#");
            return Hour + ":" + Minute;
        }
        private static int NumberDayOfWeek(string name)
        {
            int n = 0;
            switch (name)
            {
                case "Saturday": n = 0; break;
                case "Sunday": n = 1; break;
                case "Monday": n = 2; break;
                case "Tuesday": n = 3; break;
                case "Wednesday": n = 4; break;
                case "Thursday": n = 5; break;
                case "Friday": n = 6; break;
            }
            return n;
        }
        private static bool YearKabise(int year)
        {
            if (pc.IsLeapYear(year) == true)
            {
                Leap = true;
            }
            else
            {
                Leap = false;
            }
            return Leap;
        }
        public static string Day_Name()
        {
            switch (DayName.ToString().ToLower())
            {
                case "saturday": Week_Name = "شنبه"; break;
                case "sunday": Week_Name = "یکشنبه"; break;
                case "monday": Week_Name = "دوشنبه"; break;
                case "tuesday": Week_Name = "سه شنبه"; break;
                case "wednesday": Week_Name = "چهارشنبه"; break;
                case "thursday": Week_Name = "پنج شنبه"; break;
                case "friday": Week_Name = "جمعه"; break;
            }
            return Week_Name;
        }
        #endregion

        #region FilterDate Method
        public static string[] FilterWeek()
        {
            string[] arrWeek = new string[2];
            DateTime Start = dt_now.AddDays((-1 * NumberDayOfWeek(DayName)));
            DateTime End = Start.AddDays(6);

            arrWeek[0] = ShowShamsiToday(Start);
            arrWeek[1] = ShowShamsiToday(End);
            return arrWeek;
        }
        public static string[] FilterMonth()
        {
            string[] arrMonth = new string[2];
            arrMonth[0] = Year + "/" + Month.ToString("0#") + "/" + "01";
            arrMonth[1] = Year + "/" + Month.ToString("0#") + "/" + GetDayMonth;
            return arrMonth;
        }
        public static string[] FilterYear()
        {
            YearKabise(Year);
            string[] arrYear = new string[2];
            if (Leap == true)
            {
                arrYear[0] = Year + "/" + "01" + "/" + "01";
                arrYear[1] = Year + "/" + "12" + "/" + "30";
            }
            else
            {
                arrYear[0] = Year + "/" + "01" + "/" + "01";
                arrYear[1] = Year + "/" + "12" + "/" + "29";
            }
            return arrYear;
        }
        #endregion
    }
}