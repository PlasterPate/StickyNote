using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOCalculator.Tests
{
    [TestClass()]
    public class NegateOperatorTests
    {
        [TestMethod()]
        public void NegateOperatorTest()
        {
            string filePath = "negate.txt";
            File.WriteAllText(filePath, "5");
            NegateOperator no = new NegateOperator(File.OpenText(filePath));
            Assert.AreEqual(no.ToString(), "-(5)");
            Assert.AreEqual(no.Evaluate(), -5);
        }
    }
}