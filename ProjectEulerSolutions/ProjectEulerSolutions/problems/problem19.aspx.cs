using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using auxLibrary;
using System.Text;

namespace ProjectEulerSolutions.problems
{
    public partial class problem19 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int result = 0;
            int dayCount = 0;
            int monthDays;

            for (int year = 1900; year < 2001; year++)
            {
                foreach (string strMonth in arrMonths)
                {
                    monthDays = getMonthLength(strMonth, year);
                    if (dayCount % 7 == (int)Day.Sun)
                        result++;
                    
                    dayCount += monthDays;
                }
            }


            ltrlResult.Text += "<br />The number of Sundays that fell on the first of the month in the 20th Century is: " + result;
        }

        public string[] arrMonths
        {
            get { return new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }; }
        }

        public enum Day
        {
            Mon = 0,
            Tue = 1,
            Wed = 2,
            Thu = 3,
            Fri = 4,
            Sat = 5,
            Sun = 6
        }

        public int getMonthLength(string month, int year)
        {
            switch (month)
            {
                case "Jan":
                case "Mar":
                case "May":
                case "Jul":
                case "Aug":
                case "Oct":
                case "Dec":
                    return 31;

                case "Apr":
                case "Jun":
                case "Sep":
                case "Nov":
                    return 30;

                case "Feb":
                    if (isLeapYear(year))
                        return 29;
                    else
                        return 28;

                default:
                    return -1;
            }
        }

        public Boolean isLeapYear(int year)
        {
            //It's leap year if it's divisible by 4, but not divisible by 100 unless it's divisible by 400.
            return (year % 4 == 0) && (year % 100 != 0 || year % 400 == 0);
        }


    }
}