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
    public class DivideOperatorTests
    {
        [TestMethod()]
        public void DivideOperatorTest()
        {
            string filePath = "divide.txt";
            File.WriteAllText(filePath, "15\n3");
            DivideOperator dio = new DivideOperator(File.OpenText(filePath));
            Assert.AreEqual(dio.ToString(), "(15/3)");
            Assert.AreEqual(dio.Evaluate(), 5);
        }
    }
}