using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using auxLibrary;

namespace ProjectEulerSolutions.problems
{
    public partial class problem9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            uint a=0, b=0, c=0;
            for (uint i = 1; i < 999; i++)
            {
                for (uint j = i; j < 999; j++)
                {
                    for (uint k = Math.Max(i,j); k < 999; k++)
                    {
                        if (i + j + k > 1000 || i * i + j * j < k * k)
                            break;

                        if (i * i + j * j == k * k && i + j + k == 1000)
                        {
                            a = i;
                            b = j;
                            c = k;
                        }
                    }

                        if (i + j > 999)
                            break;
                }
            }
            ltrlResult.Text = "The Pythagorean triplet for which a+b+c=1000 is: a = "+ a + ", b = " + b + ", c = " + c + ".<br />The Product a*b*c is: " + a*b*c;
        }
    }
}