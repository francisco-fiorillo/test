using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using auxLibrary;

namespace ProjectEulerSolutions.problems
{
    public partial class problem16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (uint i = 1; i < 50; i++)
            {
                ltrlResult.Text += auxMethods.power(2, i) + "<br/>";
            }
        }
    }
}