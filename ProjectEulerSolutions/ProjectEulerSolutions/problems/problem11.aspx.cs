using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectEulerSolutions.problems
{
    public partial class problem11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] allLines;
            int result = 0;
            int testNum = 0;
            int[,] grid;

            /*** SETTING UP THE NUMBER MATRIX ***/
            allLines = System.IO.File.ReadAllLines(Server.MapPath("/files") + "\\p11_grid.txt");

            //set the size of the number grid
            grid = new int[allLines[0].Count(chr => Char.IsWhiteSpace(chr)) + 1, allLines.Length];

            for (int i = 0; i < allLines.Length; i++)
            {
                int columnCounter = 0;
                foreach (string num in allLines[i].Split(new Char[] { ' ' }))
                {
                    grid[i, columnCounter] = Int32.Parse(num);
                    columnCounter++;
                }

            }
            /***********************************/

            /*** Start checking fo the biggest product ***/
            int rowCount = grid.GetLength(0);
            int columnCount = grid.GetLength(1);

            for (int x = 0; x < rowCount; x++)
            {
                for (int y = 0; y < rowCount; y++)
                {
                    /*Check if the current position has 3 more values to the bottom and calculate it*/
                    if (x + 3 < rowCount)
                    {
                        testNum = grid[x, y] * grid[x + 1, y] * grid[x + 2, y] * grid[x + 3, y];
                        result = Math.Max(result, testNum);
                    }

                    /*Check if the current position has 3 more values to the right and calculate it*/
                    if (y + 3 < columnCount)
                    {
                        testNum = grid[x, y] * grid[x, y + 1] * grid[x, y + 2] * grid[x, y + 3];
                        result = Math.Max(result, testNum);
                    }

                    /*Check if the current position has 3 more values to the bottom-right diagonal and calculate it*/
                    if (x + 3 < rowCount && y + 3 < columnCount)
                    {
                        testNum = grid[x, y] * grid[x + 1, y + 1] * grid[x + 2, y + 2] * grid[x + 3, y + 3];
                        result = Math.Max(result, testNum);
                    }

                    /*Check if the current position has 3 more values to the bottom-left diagonal and calculate it*/
                    if (x + 3 < rowCount && y - 3 >= 0)
                    {
                        testNum = grid[x, y] * grid[x + 1, y - 1] * grid[x + 2, y - 2] * grid[x + 3, y - 3];
                        result = Math.Max(result, testNum);
                    }
                }
            }
            /*********************************************/

            ltrlResult.Text = "The greatest product of 4 elements in the same direction is: " + result;
        }
    }
}