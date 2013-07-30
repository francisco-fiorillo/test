using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Numerics;
using auxLibrary;

namespace ProjectEulerSolutions.problems
{
    public partial class problem16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            uint POW_OF_2 = 15;
            long sumOfDigits = 0;
            String strDigits = auxMethods.power((BigInteger)2, POW_OF_2).ToString();
            sumOfDigits = strDigits.Sum(x => uint.Parse(x.ToString()));
            ltrlResult.Text = "The sum of the digits of 2^" + POW_OF_2 + " is: " + sumOfDigits;
        }
    }
}