using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using auxLibrary;
using System.Diagnostics;

namespace ProjectEulerSolutions.problems
{
    public partial class problem5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Method 1*/
            Stopwatch sw1 = Stopwatch.StartNew();
            bool resultFound = false;
            long currentNumber = 0;            
            
            while(!resultFound)
            {
                currentNumber++;

                for(int i=20; i >= 11; i--)
                {
                    if (currentNumber % i != 0)
                        break;
                    else if (i == 11)
                    {
                        resultFound = true;
                        break;
                    }
                }
            }
            sw1.Stop();
            ltrlResult.Text = "The smallest number evenly divisible by 1 to 20 is: " + currentNumber + ". Time elapsed: " + sw1.Elapsed;

            /* Method 2 - Finding the LCM*/
            Stopwatch sw2 = Stopwatch.StartNew();
            List<ulong> lstNumbersToCalulateLCM = new List<ulong>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            ulong LCMResult = auxMethods.calculateLCM(lstNumbersToCalulateLCM);
            sw2.Stop();
            ltrlResult.Text += "<br/> The number calculating the Least Common Multiplier (should be the same) is: " + LCMResult + ". Time elapsed: " + sw2.Elapsed;
        }               
    }
}