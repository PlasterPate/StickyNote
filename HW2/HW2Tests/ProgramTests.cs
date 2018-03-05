using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
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
            // 4 test numbers
            int test_num1 = 5;
            int test_num2 = 12;
            int test_num3 = 4;
            int test_num4 = 64;
            // compare return value of method with the answer we expect to see if it works correctly
            Assert.AreEqual(0.375, Program.random_prob(test_array1, test_num1));
            Assert.AreEqual(.25, Program.random_prob(test_array1, test_num2));
            Assert.AreEqual(0.625, Program.random_prob(test_array2, test_num3));
            Assert.AreEqual(0, Program.random_prob(test_array2, test_num4));
        }

        [TestMethod()]
        public void inputTest()
        {
            // a test string
            string test = "1 2 2 3 3 3 4 5";
            // make a string reader and give it a string .
            // so we can read that string from it later and compare the result with what we gave it before
            using (StringReader reader = new StringReader(test))
            {
                // compare test string and what our method reads from string reader
                Assert.AreEqual(test, Program.input(reader));
            }
        }

        [TestMethod()]
        public void outputTest()
        {
            // a test array
            int[] test_array = { 1, 2, 2, 3, 3, 3, 4, 5 };
            // a test number
            int test_num = 3;
            // probability of selecting the test number in the test array
            double result = 0.375;
            // make a string writer. so we can write a string on it later
            using (StringWriter writer = new StringWriter())
            {
                // write on string writer using output method
                Program.output(writer, test_array, test_num);
                // make a string variable, convert the value on string writer to string and put it in this variable
                string output = writer.GetStringBuilder().ToString();
                // remove two additional characters (/r and /n) from end of the string
                output = output.Remove(output.Length - 2);
                // compare the value wrote on string writer and the result we expect
                Assert.AreEqual(result.ToString(), output);
            }
        }
    }
}