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
    public class MultiplyOperatorTests
    {
        [TestMethod()]
        public void MultiplyOperatorTest()
        {
            string filePath = "multiply.txt";
            File.WriteAllText(filePath, "2\n5");
            MultiplyOperator mo = new MultiplyOperator(File.OpenText(filePath));
            Assert.AreEqual(mo.ToString(), "(2*5)");
            Assert.AreEqual(mo.Evaluate(), 10);
        }
    }
}