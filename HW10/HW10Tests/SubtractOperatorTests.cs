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
    public class SubtractOperatorTests
    {
        [TestMethod()]
        public void SubtractOperatorTest()
        {
            string filePath = "subtract.txt";
            File.WriteAllText(filePath, "8\n6");
            SubtractOperator so = new SubtractOperator(File.OpenText(filePath));
            Assert.AreEqual(so.ToString(), "(8-6)");
            Assert.AreEqual(so.Evaluate(), 2);
        }
    }
}