using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIDemo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo.Utilities.Tests
{
    [TestClass()]
    public class ConverterTests
    {
        [TestMethod()]
        public void NumberToWordsTest_CheckIfMinusValues()
        {
          
            decimal d = -12.9M;
            string a = Utilities.Converter.NumberToWords(d);
            Assert.IsTrue(a.Contains(("minus")));
        }

        [TestMethod()]
        public void NumberToWordsTest_CheckIfTheRightStringIsOutputted_AsTheExample()
        {
            decimal d = 123.45M;
            string a = Utilities.Converter.NumberToWords(d);
            Assert.IsTrue(a.Equals("ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS"));
           
        }
        [TestMethod()]
        public void NumberToWordsTest_CheckIfSingleDigitIsCorrect()
        {
            decimal d = 1.45M;
            string a = Utilities.Converter.NumberToWords(d);
            Assert.IsTrue(a.Equals("ONE DOLLAR AND FORTY-FIVE CENTS"));

        }
        [TestMethod()]
        public void NumberToWordsTest_CheckIfDoubleDigitIsCorrect()
        {
            decimal d = 13.45M;
            string a = Utilities.Converter.NumberToWords(d);
            Assert.IsTrue(a.Equals("THIRTEEN DOLLARS AND FORTY-FIVE CENTS"));

        }

        [TestMethod()]
        public void NumberToWordsTest_CheckIfThreeDigitIsCorrect()
        {
            decimal d = 123.45M;
            string a = Utilities.Converter.NumberToWords(d);
            Assert.IsTrue(a.Equals("ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS"));

        }
        [TestMethod()]
        public void NumberToWordsTest_CheckIfTFourIsCorrect()
        {
            decimal d = 123.45M;
            string a = Utilities.Converter.NumberToWords(d);
            Assert.IsTrue(a.Equals("ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS"));

        }

        [TestMethod()]
        public void NumberToWordsTest_CheckIfNineDigitsCorrect()
        {
            decimal d = 666999789.70M;
            string a = Utilities.Converter.NumberToWords(d);
            Assert.IsTrue(a.Equals("SIX HUNDRED AND SIXTY-SIX MILLION NINE HUNDRED AND NINETY-NINE THOUSAND SEVEN HUNDRED AND EIGHTY-NINE DOLLARS AND SEVENTY CENTS"));

        }
    }
}
