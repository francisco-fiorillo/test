using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectEulerSolutions.problems
{
    public partial class problem2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int result = 0;
            for (int i = 1; i < 4000000; i++)
            {
                if (fib(i) > 4000000)
                    break;

                if (fib(i) % 2 == 0)
                    result += fib(i);
            }
            ltrlResult.Text = "The sum of even Fibonacci series under 4.000.000 is: " + result;
                
        }

        private int fib(int x)
        {
            if (x == 1 || x == 2)
                return x;
            else
                return fib(x - 1) + fib(x - 2);
        }
    }
}