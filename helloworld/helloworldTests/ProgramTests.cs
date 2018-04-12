using Microsoft.VisualStudio.TestTools.UnitTesting;
using helloworld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloworld.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void checkTest()
        {
            int[] numbers_asc = new int[] { 2, 4, 7, 11, 20 };
            int[] numbers_des = new int[] { 33, 19, 12, 7, 0 };
            int[] numbers_wrong = new int[] { 16, 4, 7, 5, 19 };

            Assert.IsTrue(Program.check(numbers_asc, true));
            Assert.IsTrue(Program.check(numbers_des, false));
            Assert.IsFalse(Program.check(numbers_wrong, false));
        }
    }
}