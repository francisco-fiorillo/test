using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using auxLibrary;

namespace ProjectEulerSolutions.problems
{
    public partial class problem7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const int PRIME_POSITION_TO_FIND = 10001;
            int primeCounter = 0;
            ulong currentNumber = 1;

            while (primeCounter < PRIME_POSITION_TO_FIND)
            {
                currentNumber++;
                if(auxMethods.isPrime(currentNumber))
                    primeCounter++;
            }

            ltrlResult.Text = "The prime number in position " + PRIME_POSITION_TO_FIND + " is: " + currentNumber;
        }
    }
}