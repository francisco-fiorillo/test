using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectEulerSolutions.problems
{
    public partial class problem1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int result = 0;
            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    result += i;
            }
            ltrlResult.Text = "The sum of all multiples of 3 and 5 below 1000 is: " + result;
        }
    }
}