using System;
using System.IO;

namespace OOCalculator
{
    public abstract class UnaryOperator: Expression, IOperator
    {
        protected Expression Operand;

        public UnaryOperator()
        {
            throw new NotImplementedException();
        }

        public UnaryOperator(TextReader reader)
        {
            throw new NotImplementedException();
        }

        public sealed override string ToString() => throw new NotImplementedException();

        public abstract string OperatorSymbol { get; }
    }
}