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
    public class SquareOperatorTests
    {
        [TestMethod()]
        public void SquareOperatorTest()
        {
            string filePath = "square.txt";
            File.WriteAllText(filePath, "4");
            SquareOperator so = new SquareOperator(File.OpenText(filePath));
            Assert.AreEqual(so.ToString(), "Square(4)");
            Assert.AreEqual(so.Evaluate(), 16);
        }
    }
}