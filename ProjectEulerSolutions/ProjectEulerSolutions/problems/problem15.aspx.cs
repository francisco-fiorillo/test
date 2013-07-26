using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using auxLibrary;

namespace ProjectEulerSolutions.problems
{
    public partial class problem15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //NOTE: THIS DOESN'T WORK FOR BIG SIZES OF SQUARES. THE FACTORIALS GROW QUICKLY AND OVERFLOWS.

            const ulong SQUARE_SIDE_LENGTH = 5;

            ulong routeSize = SQUARE_SIDE_LENGTH * 2;

            /********************************************************************************************************/
            /* Solved this using combinatory -> The ways to find all the routes is equivalent                       */
            /* to take "m" elements (right movements) from "m + n" elements, where  "n" are the                     */
            /* down movements. This way, the solution is the binomial coeficient (m+n n) or, likewise, (m+n  m).    */
           /*********************************************************************************************************/

            //To simplify the factorial calculation, I cancel the divisors
            List<ulong> lstFacNumbers = new List<ulong>();
            for (ulong i = SQUARE_SIDE_LENGTH + 1; i <= routeSize; i++)
            {
                lstFacNumbers.Add(i);
            }

            ulong facNumbersProduct = 1;

            foreach (ulong num in lstFacNumbers)
            {
                facNumbersProduct *= num;
            }


            //ulong result = auxMethods.factorial(routeSize) / (auxMethods.factorial(SQUARE_SIDE_LENGTH) * auxMethods.factorial(routeSize - SQUARE_SIDE_LENGTH));
            ulong result = facNumbersProduct / auxMethods.factorial(routeSize - SQUARE_SIDE_LENGTH);

            ltrlResult.Text = String.Format("The number of routes from top left to bottom right for a {0} by {0} square when only movements to the right and bottom are allowed is: {1}", SQUARE_SIDE_LENGTH, result);
        }
    }
}