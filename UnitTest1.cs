using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConvertNumber.Models;
namespace ConvertNumber.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void tstConvertToWords()
        {
            NumberToText _obj = new NumberToText();
            _obj.noToConvert = 563.9;
            string s = _obj.getConvertedValue();
            s = s.Replace(" ", "");
            Assert.AreEqual("FIVEHUNDREDSIXTY-THREEDOLLARSANDNINETYCENTS", s);
        }
    }
}
