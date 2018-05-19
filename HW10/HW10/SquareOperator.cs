using System;
using System.IO;

namespace OOCalculator
{
    public class SquareOperator : UnaryOperator
    {
        public SquareOperator(TextReader reader)
            : base(reader)
        {
            
        }

        public override string OperatorSymbol => "Square";
        
        public override double Evaluate() => Math.Pow(Operand.Evaluate(), 2) ;

    }
}