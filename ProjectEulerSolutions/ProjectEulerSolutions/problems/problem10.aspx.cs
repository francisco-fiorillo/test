using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using auxLibrary;
namespace ProjectEulerSolutions.problems
{
    public partial class problem10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ulong result = 0;
            int maxVaule = 2000000;
            //int maxVaule = 10;

            int[] basePrimes = {2};

            List<int> lstPrimes = new List<int>(basePrimes);

            for (int i = 3; i <= maxVaule; i++)
            {
                bool isPrime = false;
                foreach (int prime in lstPrimes)
                {
                    if (i % prime == 0)
                        break;

                    if (prime == lstPrimes.Last())
                        isPrime = true;
                }

                if (isPrime)
                {
                    lstPrimes.Add(i);
                    //Reset the flag
                    isPrime = false;
                }
            }

            foreach(int prime in lstPrimes)
            {
                result += (ulong)prime;
            }
            ltrlResult.Text = "The sum of the prime numbers under " + maxVaule + " is: " + result;
        }
    }
}