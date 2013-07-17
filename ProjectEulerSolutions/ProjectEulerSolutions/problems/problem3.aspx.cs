using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectEulerSolutions.problems
{
    public partial class problem3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const ulong NUMBER_TO_FACTORIZE = 600851475143;

            ulong currentNumberValue = NUMBER_TO_FACTORIZE;
            ulong currentDivisor = 2;

            while (currentNumberValue > 1)
            {
                if (!isPrime(currentDivisor))
                {
                    currentDivisor++;
                    continue;
                }

                while (currentNumberValue % currentDivisor == 0)
                {
                    currentNumberValue = currentNumberValue / currentDivisor;
                }
                
                //only increment if i didn't complete the factorization (to keep the bigger prime factor in the variable).
                if(currentNumberValue > 1)
                    currentDivisor++;
            }            

            ltrlResult.Text = "The largest prime factor of: " + NUMBER_TO_FACTORIZE + " is: " + currentDivisor;
        }

        private bool isPrime(ulong x)
        {
            for (ulong i = 2; i < x; i++)
            {
                if (x % i == 0)
                    return false;
            }
            return true;
        }
    }
}