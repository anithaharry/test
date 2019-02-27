using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDemo.Utilities
{
    public class Converter
    {
        private static string[] oneValues = {
            "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
            "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen",
        };

        private static string[] tenValues = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        private static string[] unitValues = { "hundred", "thousand", "million", "billion", "trillion", "quadrillion","quintillion",  "sextillion",      "septillion",    "octillion",      "nonillion",
            "decillion",    "undecillion",     "duodecillion",  "tredecillion",   "quattuordecillion",
            "sexdecillion", "septendecillion", "octodecillion", "novemdecillion", "vigintillion"  };

        public static string NumberToWords(decimal number)
        {
         
                string dollar = "dollars";
                string cents = "cents";
                if (number < 0)
                    return "minus " + NumberToWords(Math.Abs(number));

                long integerValue = (long) number;
                long decimalValue = (long) ((number - integerValue) * 100);
                if (decimalValue == 0)
                    cents = "";
                if (decimalValue == 1)
                    cents = "cent";
                if (integerValue == 1)
                    dollar = "dollar";


                return string.Format("{0} " + dollar + " {1} " + cents, NumberToWords(integerValue),
                    NumberToWords(decimalValue)).ToUpper();
           
        }

        private static string NumberToWords(long number, string appendScale = "")
        {
            
            string finalString = "";
           
            if (number < 100)
            {
                if (number < 20)
                    finalString = oneValues[number];
                else
                {
                    //divide by ten to get the value of the first part of the double digit greater than 20 to determine the double digit unit
                    long valueOfTens = number / 10;
                    finalString = " and " + tenValues[valueOfTens] ;

                    //get the second part of the double digit to determine the value 
                    long valueOfOnes = number % 10;
                    if ((valueOfOnes) > 0)
                        finalString += "-" + oneValues[valueOfOnes];
                }
            }
            else
            {
            
                long unitValue = 0;
                string unitValueString = "";

                if (number < 1000) // number is between 100 and 1000
                {
                    unitValue = 100;
                    unitValueString = unitValues[0];
                    
                }
                else // find the scale of the number
                {
                    var a = Math.Log(number, 1000);
                    long log = (long)Math.Log(number, 1000);
                    unitValue = (long)Math.Pow(1000, log);
                    unitValueString = unitValues[log];
                   
                }
              
                finalString = string.Format("{0} {1}", NumberToWords(number / unitValue, unitValueString), NumberToWords(number % unitValue)).Trim();
            }
            
           
            return string.Format("{0} {1}", finalString, appendScale).Trim();
        }
    }


}
