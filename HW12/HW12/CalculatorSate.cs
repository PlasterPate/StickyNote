using System;
namespace SimpleCalculator
{
    /// <summary>
    ///  این کلاس وضعیت مادر است 
    ///  برای هر وضعیتی اگر یکی از 
    ///  Event ها
    ///  مثلا
    ///  EnterEqual/...
    ///  را 
    ///  override
    ///  نکنیم به طور پیش فرض کاری انجام نمیدهد و در وضعیت فعلی باقی میماند.
    ///  این کلاس اینترفیس 
    ///  IState
    ///  را پیاده سازی میکند و به ازای دکمه های مختلفی که کاربر میزند عملکرد های متفاوتی دارد
    ///  این کلاس به تنهایی نشان دهنده ی هیج وضعیتی نیست
    ///  و تنها شامل خصوصیات مشترک حالت های مختلف یک ماشین حساب است 
    ///  که هر کدام ار این حالت ها باید به طور جداگانه تعریف شوند
    /// </summary>
    public abstract class CalculatorState : IState
    {
        public Calculator Calc { get; }
        /// <summary>
        /// this constructor will be called in derived classes
        /// it assigns an input calculator to 
        /// </summary>
        /// <param name="calc"></param>
        public CalculatorState(Calculator calc) => this.Calc = calc;
        public virtual IState EnterEqual() =>this;
        public virtual IState EnterZeroDigit() => this;
        public virtual IState EnterNonZeroDigit(char c) => this;        
        public virtual IState EnterOperator(char c) => this;
        public virtual IState EnterPoint() => this;

        /// <summary>
        /// does the calculations and updates every thing 
        /// it will show a message if it faced an exeption
        /// </summary>
        /// <param name="nextState">the state that it is going to have after this process</param>
        /// <param name="op">the operator character</param>
        /// <returns>calculator state after this process</returns>
        protected IState ProcessOperator(IState nextState, char? op = null)
        {
            try
            {
                this.Calc.Evalute();
                this.Calc.UpdateDisplay();
                this.Calc.PendingOperator = op;
                return nextState;
            }
            catch (Exception e)
            {
                this.Calc.DisplayError(e.Message);
                return new ErrorState(this.Calc);
            }
        }
    }
}