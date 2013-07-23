using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using auxLibrary;

namespace ProjectEulerSolutions.problems
{
    public partial class problem6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ulong summationOfSquares, squareOfSummation, result;

            summationOfSquares = auxMethods.summation ((ulong)1, (ulong)100, x => x * x);
            squareOfSummation = auxMethods.summation((ulong)1, (ulong)100, x => x) * auxMethods.summation((ulong)1, (ulong)100, x => x);

            result = squareOfSummation - summationOfSquares;

            ltrlResult.Text = "The difference between the sum of the squares of the first one hundred natural numbers and the square of the sum is: " + result;
        }
    }
}