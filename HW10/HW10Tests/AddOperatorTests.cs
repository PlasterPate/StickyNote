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
    public class AddOperatorTests
    {
        [TestMethod()]
        public void AddOperatorTest()
        {
            string filePath = "add.txt";
            File.WriteAllText(filePath, "3\n5");
            AddOperator ao = new AddOperator(File.OpenText(filePath));
            Assert.AreEqual(ao.ToString(), "(3+5)");
            Assert.AreEqual(ao.Evaluate(), 8);
        }
    }
}