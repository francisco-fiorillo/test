using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using auxLibrary;
using System.Text;

namespace ProjectEulerSolutions.problems
{
    public partial class problem18 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int result;

            int?[,] pyramidArray = TextPyramidToArray("p18_pyramid.txt");
            result = MaxSumFromPyramidArray(pyramidArray).Value;

            ltrlResult.Text += "<br />The maximum total of the sum of the adyacent number from top to bottom is: " + result;
        }

        private int?[,] TextPyramidToArray(String filename)
        {
            String[] allLines = System.IO.File.ReadAllLines(Server.MapPath("/files") + "\\" + filename);

            string[] pyramidLineNumbers;
            int arrayWidth = allLines.Last().Count(x => x.Equals(' ')) + 1; //Count spaces for the last line plus one, which is the total width of the pyramid.
            int arrayHeight = allLines.Count();
            int currentWidth;
            int currentHeight = 0;



            int?[,] pyramidArray = new int?[arrayWidth, arrayHeight];

            foreach (string line in allLines)
            {

                currentWidth = 0;
                pyramidLineNumbers = line.Split(' ');

                foreach (string num in pyramidLineNumbers)
                {
                    pyramidArray[currentWidth, currentHeight] = Int32.Parse(num);
                    currentWidth++;
                }

                //SET REMAINING ARRAY VALUES TO NULL
                /*
                for (int i = currentWidth; i > arrayWidth; i++) 
                {
                    //pyramidArray[i, currentHeight] = null;
                }
                */
                currentHeight++;
            }
            return pyramidArray;
        }

        private int? MaxSumFromPyramidArray(int?[,] pyramidArray)
        {

            for (int h = pyramidArray.GetLength(1) - 1; h > 0; h--) //I will take columns up to "1" because I will use the previous index in the row on top to sum it)
            {
                for (int w = pyramidArray.GetLength(0) - 1; w > 0; w--)
                {
                    if (pyramidArray[w, h] == null)
                        continue;

                    pyramidArray[w - 1, h - 1] = pyramidArray[w - 1, h - 1] + Math.Max(pyramidArray[w - 1, h].Value, pyramidArray[w, h].Value);
                    pyramidArray[w, h] = null;
                }
            }            

            return pyramidArray[0,0];
        }
    }
}