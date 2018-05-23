namespace SimpleCalculator
{
    /// <summary>
    /// این وضعیت نشان دهنده حالتی است که نقطه زده شده
    /// این وضعیت شبیه وضعیت
    /// Accumulate
    /// است
    /// تنها فرقش این است که نقطه جدیدی نمی شود زد.
    /// تغییرات لازم را برای این کار بدهید.
    /// </summary>
    public class PointState : AccumulateState
    {
        public PointState(Calculator calc) : base(calc) { }

        /// <summary>
        ///does nothing 
        ///because we cant have more than one point at the same time 
        /// </summary>
        /// <returns>point state</returns>
        public override IState EnterPoint() => this;
    }
}