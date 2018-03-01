using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void random_probTest()
        {
            // 2 test arrays having 8 integers
            int[] test_array1 = new int[8] { 5, 21, 5, 6, 0, 12, 12, 5 };
            int[] test_array2 = new int[8] { 19, 5, 4, 4, 4, 63, 4, 4 };

            // compare return value of method with the answer we expect to see if it works correctly
            Assert.AreEqual(0.375, Program.random_prob(test_array1, 5));
            Assert.AreEqual(.25, Program.random_prob(test_array1, 12));
            Assert.AreEqual(0.625, Program.random_prob(test_array2, 4));
            Assert.AreEqual(0, Program.random_prob(test_array2, 64));
        }
    }
}