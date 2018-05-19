using System;
using System.IO;

namespace OOCalculator
{
    public class DivideOperator : BinaryOperator
    {
        public DivideOperator(TextReader reader)
            : base(reader)
        {
            
        }

        public override string OperatorSymbol => "/";

        public override double Evaluate() => LHS.Evaluate() / RHS.Evaluate();
    }
}