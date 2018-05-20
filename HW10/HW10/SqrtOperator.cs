using System;
using System.IO;

namespace OOCalculator
{
    public class SqrtOperator : UnaryOperator
    {
        /// <summary>
        /// calls the base constructor
        /// </summary>
        /// <param name="reader"></param>
        public SqrtOperator(TextReader reader)
            : base(reader)
        {
            
        }

        //overrides operator symbol of unary operator class
        public override string OperatorSymbol => "SquareRoot";

        /// <summary>
        /// override the evaluate method of expressions class
        /// </summary>
        /// <returns></returns>
        public override double Evaluate() => Math.Sqrt(Operand.Evaluate());
    }
}