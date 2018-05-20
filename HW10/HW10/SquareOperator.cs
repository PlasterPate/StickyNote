using System;
using System.IO;

namespace OOCalculator
{
    public class SquareOperator : UnaryOperator
    {
        /// <summary>
        /// calls the base constructor
        /// </summary>
        /// <param name="reader"></param>
        public SquareOperator(TextReader reader)
            : base(reader)
        {
            
        }

        //overrides operator symbol of unary operator class
        public override string OperatorSymbol => "Square";

        /// <summary>
        /// override the evaluate method of expressions class
        /// </summary>
        /// <returns></returns>
        public override double Evaluate() => Math.Pow(Operand.Evaluate(), 2) ;

    }
}