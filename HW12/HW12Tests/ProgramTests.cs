using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculator.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AccumulateStateTest() => RunTest<AccumulateState>(keys: "123430q", expectedDisplay: "123430");
        [TestMethod()]
        public void PointStateTest() => RunTest<PointState>(keys: ".......q", expectedDisplay: "0.");
        [TestMethod()]
        public void StartStateTest() => RunTest<ComputeState>(keys: "12+q", expectedDisplay: "12");
        [TestMethod()]
        public void ErrorStateTest() => RunTest<ErrorState>(keys: "12+5==q", expectedDisplay: "17");

        [TestMethod()]
        public void SumTest() => RunTest<ComputeState>(keys: "10+10=q", expectedDisplay: "20");

        [TestMethod()]
        public void SubtractTest() => RunTest<ComputeState>(keys: "20-10=q", expectedDisplay: "10");

        [TestMethod()]
        public void ZeroTest() => RunTest<StartState>(keys: "000000q", expectedDisplay: "0");

        [TestMethod()]
        public void ExtraPointTest() => RunTest<PointState>(keys: "55.234.2q", expectedDisplay: "55.2342");

        [TestMethod()]
        public void MultiplyTest() => RunTest<ComputeState>(keys: "10*10=q", expectedDisplay: "100");

        [TestMethod()]
        public void MultipleSumTest() => RunTest<ComputeState>(keys: "10+10+10.3=q", expectedDisplay: "30.3");

        [TestMethod()]
        public void DivideTest() => RunTest<ComputeState>(keys: "10/2=q", expectedDisplay: "5");

        [TestMethod()]
        public void PowerTest() => RunTest<ComputeState>(keys: "2^5=q", expectedDisplay: "32");

        [TestMethod()]
        public void AccumulationTest() => RunTest<AccumulateState>(keys: "10000000q", expectedDisplay: "10000000");

        [TestMethod()]
        public void StartingPointTest() => RunTest<ComputeState>(keys: ".5*2=q", expectedDisplay: "1");

        [TestMethod()]
        public void SumZeroTest() => RunTest<ComputeState>(keys: "5+0=q", expectedDisplay: "5");

        [TestMethod()]
        public void MulitiOperatorTest() => RunTest<ErrorState>(keys: "5+-q", expectedDisplay: "5");

        [TestMethod()]
        public void OperatorPointTest() => RunTest<ComputeState>(keys: "7+.8=q", expectedDisplay: "7.8");

        [TestMethod()]
        public void StartingEqualTest() => RunTest<ComputeState>(keys: "=q", expectedDisplay: "0");

        [TestMethod()]
        public void StartingOperatorTest() => RunTest<ComputeState>(keys: "+3=q", expectedDisplay: "3");

        [TestMethod()]
        public void EscapeTest() => RunTest<StartState>(keys: $"1+2={(char)ConsoleKey.Escape}q", expectedDisplay: "0");

        [TestMethod()]
        public void AfterErrorTest()
        {
            // "==" is for going to error state
            RunTest<StartState>(keys: "===q", expectedDisplay: "0");
            RunTest<StartState>(keys: "==0q", expectedDisplay: "0");
            RunTest<StartState>(keys: "==2q", expectedDisplay: "0");
            RunTest<StartState>(keys: "==+q", expectedDisplay: "0");
            RunTest<StartState>(keys: "==.q", expectedDisplay: "0");
        }

        private void RunTest<ExpectedState>(string keys, string expectedDisplay)
        {
            int i = 0;
            Calculator c = Program.RunCalculator(() => keys[i++], () => {});
            Assert.AreEqual(c.Display, expectedDisplay);
            Assert.IsTrue(c.State is ExpectedState);
        }

    }
}