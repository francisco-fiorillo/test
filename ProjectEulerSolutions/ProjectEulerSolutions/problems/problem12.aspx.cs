using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using auxLibrary;
namespace ProjectEulerSolutions.problems
{
    public partial class problem12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const int AMOUNT_OF_DIVISIORS = 501;
            //const int AMOUNT_OF_DIVISIORS = 6;
            int divisorCounter = 1;
            int currentExpCounter = 0;
            int currentPrimeFactor = 2;
            
            int currentTriangleIndex = 0;
            int currentTriangleNumber = 0;
            int lastTriangleNumber = 0;
            List<int> lstExponents = new List<int>();

            //Cycle until I find the desired amount of divisors
            while(divisorCounter < AMOUNT_OF_DIVISIORS)
            {
                //Reset the exponents list, the prime factors and the divisors counter to test a new number
                divisorCounter = 1;
                currentPrimeFactor = 2;
                lstExponents.Clear();
                                                
                currentTriangleIndex++;
                currentTriangleNumber = auxMethods.summation(currentTriangleIndex);
                lastTriangleNumber = currentTriangleNumber;
                
                

                //Keep finding prime factors and exponents until I reach the final factorization
                while (currentTriangleNumber > 1)
                {
                    //reset the exponent counter
                    currentExpCounter = 0;

                    while (currentTriangleNumber % currentPrimeFactor == 0)
                    {
                        currentExpCounter++;
                        currentTriangleNumber /= currentPrimeFactor;
                    }

                    //If i found a positive exponent, I add it to the list.
                    if (currentExpCounter > 0)
                    {
                        lstExponents.Add(currentExpCounter);
                    }

                    currentPrimeFactor = auxMethods.findNextPrime(currentPrimeFactor);
                }

                //Now I have a list of all the exponents of the prime factorization. any combination with less or equal values for each exponent is a divisor of the triangle number
                //Thus, I just need to multiply the exponents + 1 (to include the 0 value) in order to get the total amount of divisors for the number.
                foreach (int exp in lstExponents)
                {
                    divisorCounter *= exp + 1;
                }                
            }

            ltrlResult.Text = "The first triangle number with more than " + (AMOUNT_OF_DIVISIORS - 1) + " divisors is: " + lastTriangleNumber;
        }
    }
}