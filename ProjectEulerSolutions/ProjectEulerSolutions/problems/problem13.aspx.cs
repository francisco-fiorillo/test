using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectEulerSolutions.problems
{
    public partial class problem13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ulong result = 0;
            const int MAX_DIGITS = 10;
            const int NUMBER_OF_DIGITS_TO_CAPTURE = 10;
            String[] allLines = System.IO.File.ReadAllLines(Server.MapPath("/files") + "\\p13_numbers.txt");

            while (allLines[0].Length > 0)
            {
                for (int i = 0; i < allLines.Length; i++)
                {
                    result += UInt64.Parse(allLines[i].Substring(allLines[i].Length - MAX_DIGITS));
                    allLines[i] = allLines[i].Substring(0, allLines[i].Length - MAX_DIGITS);
                }

                if (allLines[0].Length > 0)
                    result = UInt64.Parse(result.ToString().Substring(0, result.ToString().Length - MAX_DIGITS));
            }
            result = UInt64.Parse(result.ToString().Substring(0, NUMBER_OF_DIGITS_TO_CAPTURE));
            ltrlResult.Text = "The first ten digits of the sum of all the given numbers is: " + result;            
        }
    }
}