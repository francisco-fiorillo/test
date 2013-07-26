using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectEulerSolutions.problems
{
    public partial class problem14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const uint MAX_NUMBER = 999999;
            //const uint MAX_NUMBER = 13;
            uint seqCounter = 0;
            uint maxSeqLength = 0;
            uint result = 0;

            for (uint i = MAX_NUMBER; i > 1; i--)
            {
                uint currentNumber = i;
                seqCounter = 1;

                while (currentNumber != 1)
                {
                    //Collatz
                    if (currentNumber % 2 == 0)
                        currentNumber /= 2;
                    else
                        currentNumber = 3 * currentNumber + 1;
                    
                    seqCounter++;
                }                

                if (seqCounter > maxSeqLength)
                {
                    maxSeqLength = seqCounter;
                    result = i;
                }
            }

            ltrlResult.Text = "The starting number under " + MAX_NUMBER + " which produces the longest Collatz sequence is: " + result;
            ltrlResult.Text += "<br />The number of steps for this sequence is: " + maxSeqLength;
        }
    }
}