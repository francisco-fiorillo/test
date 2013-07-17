using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectEulerSolutions.problems
{
    public partial class problem4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int largestPalindrome = 1;

            for (int i = 999; i > 1; i--)
            {
                for (int j = i; j > 1; j--)
                {
                    if (i * j > largestPalindrome)
                    {
                        if (isPalindrome(i * j))
                        {
                            largestPalindrome = i * j;

                            //If I found a larger palindrome, it's useless to check with smaller values of "j", so I just continue with the next value of "i".
                            break;
                        }
                    }
                    else
                        //If the largest palindrome is bigger than the current multiplication, it's useless to keep checking with smaller values.
                        break;
                }
            }
            
            ltrlResult.Text = "The largest palindrome obtained by multiplying 3-digit numbers is: " + largestPalindrome;
        }

        private bool isPalindrome(int x)
        {
            string strNumber = x.ToString();
            int numLength = strNumber.Length;
            
            for (int i = 0; i < numLength / 2; i++)
            {
                if (!strNumber.ElementAt(i).Equals(strNumber.ElementAt(numLength - i - 1)))
                    return false;
            }
            //if all opposite chars are equal, we have a palindrome.
            return true;
        }
    }
}