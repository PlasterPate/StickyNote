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
    public class ExpressionTests
    {
        [TestMethod()]
        public void BuildExpressionTreeTest()
        {
            string filePath = "expressionTree.txt";
            string fileContent = 
                "Negate\n" +
                "Square\n" +
                "Multiply\n" +
                "Add\n" +
                "2\n" +
                "1\n" +
                "Divide\n" +
                "Subtract\n" +
                "7\n" +
                "Sqrt\n" +
                "4\n" +
                "2";
            string toStringResult = "-(Square((2+1)*((7-Sqrt(4))/2)))";
            File.WriteAllText(filePath, fileContent);
            Expression test = Expression.BuildExpressionTree(File.OpenText(filePath));
            Assert.AreEqual(test.ToString(), toStringResult);
            Assert.AreEqual(test.Evaluate(), -36);
        }
    }
}