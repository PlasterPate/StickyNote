using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOCalculator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCalculator.Tests
{
    [TestClass()]
    public class SqrtOperatorTests
    {
        [TestMethod()]
        public void SqrtOperatorTest()
        {
            string filePath = "sqrt.txt";
            File.WriteAllText(filePath, "25");
            SqrtOperator so = new SqrtOperator(File.OpenText(filePath));
            Assert.AreEqual(so.ToString(), "Sqrt(25)");
            Assert.AreEqual(so.Evaluate(), 5);
        }
    }
}