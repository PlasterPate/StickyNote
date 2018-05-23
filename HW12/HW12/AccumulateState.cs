using static System.Console;

namespace SimpleCalculator
{
    /// <summary>
    /// هنگامی که یک رقم غیر صفر وارد کنیم ماشین حساب وارد این حالت می شود
    /// در این حالت میتوانیم تا زمان وارد کردن عملگر به تعداد دلخواه رقم (از جمله صفر) وارد کنیم
    /// </summary>
    public class AccumulateState : CalculatorState
    {
        public AccumulateState(Calculator calc) : base(calc) { }

        // #7 لطفا
        public override IState EnterEqual() => 
            ProcessOperator(new ComputeState(this.Calc));
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');
        public override IState EnterNonZeroDigit(char c)
        {
            // #8 لطفا!
            this.Calc.Display += c;
            return this;
        }

        // #9 لطفا!
        public override IState EnterOperator(char c) => 
            ProcessOperator(new ComputeState(this.Calc), c);

        public override IState EnterPoint()
        {
            // #10 لطفا!
            this.Calc.Display += ".";
            return new PointState(this.Calc);
        }
    }
}