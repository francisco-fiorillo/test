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
    public partial class problem17 : System.Web.UI.Page
    {
        private List<NumberWithName> lstDigitPositionNames = new List<NumberWithName>()
            {
                new NumberWithName(1, "One"),
                new NumberWithName(10, "Ten"),
                new NumberWithName(100, "Hundred"),
                new NumberWithName(1000, "Thousand")
            };

        private List<NumberWithName> lstNumberNames = new List<NumberWithName>()
            {
                new NumberWithName(1, "One"),
                new NumberWithName(2, "Two"),
                new NumberWithName(3, "Three"),
                new NumberWithName(4, "Four"),
                new NumberWithName(5, "Five"),
                new NumberWithName(6, "Six"),
                new NumberWithName(7, "Seven"),
                new NumberWithName(8, "Eight"),
                new NumberWithName(9, "Nine"),
                new NumberWithName(10, "Ten"),
                new NumberWithName(11, "Eleven"),
                new NumberWithName(12, "Twelve"),
                new NumberWithName(13, "Thirteen"),
                new NumberWithName(14, "Fourteen"),
                new NumberWithName(15, "Fifteen"),
                new NumberWithName(16, "Sixteen"),
                new NumberWithName(17, "Seventeen"),
                new NumberWithName(18, "Eighteen"),
                new NumberWithName(19, "Nineteen"),
                new NumberWithName(20, "Twenty"),
                new NumberWithName(30, "Thirty"),
                new NumberWithName(40, "Forty"),
                new NumberWithName(50, "Fifty"),
                new NumberWithName(60, "Sixty"),
                new NumberWithName(70, "Seventy"),
                new NumberWithName(80, "Eighty"),
                new NumberWithName(90, "Ninety"),
            };

        private int countNumberNameChars(int number, bool blnPrintNumberName = false)
        {
            //Decompose the number
            int units, tens, hundreds, thousands;
            bool blnNumberNameFinished = false;

            StringBuilder sblNumberName = new StringBuilder();

            units = number % 10;

            tens = (number % 100 - units);
            tens = tens > 0 ? tens / 10 : 0;

            hundreds = number % 1000 - tens - units;
            hundreds = hundreds > 0 ? hundreds / 100 : 0;

            thousands = number % 10000 - hundreds - tens - units;
            thousands = thousands > 0 ? thousands / 1000 : 0;

            //Generate the string for each decimal value
            if (thousands > 0)
            {
                //the "number of thousands" (one, two, etc.)
                sblNumberName.Append(specialNumberToString(thousands));

                //the "thousand" word"
                sblNumberName.Append(numberUnitToString(1000));
            }

            if (hundreds > 0)
            {
                sblNumberName.Append(specialNumberToString(hundreds));

                sblNumberName.Append(numberUnitToString(100));
            }

            //If i have a bigger decimal position then "tens" and "tens" or "units" are not zero, i have to add the "and" word to the tens.
            if ((thousands > 0 || hundreds > 0) && (tens > 0 || units > 0))
                sblNumberName.Append("And");


            if (tens > 0)
            {                
                //The are specific names for some the last two digits, and must be treated separately in these cases (eleven, twelve, etc).
                if (lstNumberNames.Exists(x => x.number == int.Parse(tens.ToString() + units.ToString())))
                {
                    sblNumberName.Append(lstNumberNames.Find(x => x.number == int.Parse(tens.ToString() + units.ToString())).name);
                    blnNumberNameFinished = true;
                }
                else
                {
                    //Case for Twenty-one, Thirty-eight, etc. Here I add the "tens" part.
                    sblNumberName.Append(lstNumberNames.Find(x => x.number == int.Parse(tens.ToString() + "0")).name);
                }
            }

            if (units > 0 && !blnNumberNameFinished)
            {
                sblNumberName.Append(lstNumberNames.Find(x => x.number == units).name);
                blnNumberNameFinished = true;
            }

            if (blnPrintNumberName)
                ltrlResult.Text += "<br />" + sblNumberName.ToString();
            return sblNumberName.Length;
        }

        private string specialNumberToString(int number)
        {
            return lstNumberNames.Find(x => x.number == number).name;
        }

        private string numberUnitToString(int number)
        {
            return lstDigitPositionNames.Find(x => x.number == number).name;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            const int numberCountLimit = 1000;

            int result = 0;

            for (int i = 1; i <= numberCountLimit; i++)
            {
                result += countNumberNameChars(i, true);
            }


            ltrlResult.Text += "<br />The number of characters in all the numbers from 1 to " + numberCountLimit + " is: " + result;
        }
    }
}