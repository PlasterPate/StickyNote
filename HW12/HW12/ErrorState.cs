namespace SimpleCalculator
{
    /// <summary>
    /// ماشین حساب وقتی به این حالت وارد میشود که خطایی رخ داده باشد
    /// از این حالت هر کلیدی که فشار داده شود به وضعیت اولیه باید برگردیم
    /// #2 لطفا!
    /// </summary>
    public class ErrorState : CalculatorState
    {
        public ErrorState(Calculator calc) : base(calc) { }
        public override IState EnterEqual() => GoToStartState(Calc);
        public override IState EnterNonZeroDigit(char c) => GoToStartState(Calc);
        public override IState EnterZeroDigit() => GoToStartState(Calc);
        public override IState EnterOperator(char c) => GoToStartState(Calc);
        public override IState EnterPoint() => GoToStartState(Calc);

        /// <summary>
        /// clears eveything and goes back to start state
        /// </summary>
        /// <param name="calc">state after clearing which is start state</param>
        /// <returns></returns>
        public IState GoToStartState(Calculator calc)
        {
            calc.Clear();
            return calc.State;
        }
    }
}