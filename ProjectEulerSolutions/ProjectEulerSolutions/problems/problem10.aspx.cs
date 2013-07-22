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
            ulong maxVaule = 2000000;

            for (ulong i = 2; i <= maxVaule; i++)
            {
                if (auxMethods.isPrime(i))
                {
                    result += i;
                }

            }
            ltrlResult.Text = "The sum of the prime numbers under " + maxVaule + "is: " + result;
        }
    }
}