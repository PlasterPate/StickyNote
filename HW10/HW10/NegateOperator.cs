using System;
using System.IO;

namespace OOCalculator
{
    public class NegateOperator : UnaryOperator
    {
        /// <summary>
        /// calls the base constructor
        /// </summary>
        /// <param name="reader"></param>
        public NegateOperator(TextReader reader)
            : base(reader)
        {
            
        }

        //overrides operator symbol of unary operator class
        public override string OperatorSymbol => "-";

        /// <summary>
        /// override the evaluate method of expressions class
        /// </summary>
        /// <returns></returns>
        public override double Evaluate() => -1 * Operand.Evaluate(); 
    }
}