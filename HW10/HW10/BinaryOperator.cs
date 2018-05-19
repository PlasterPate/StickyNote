using System;
using System.IO;

namespace OOCalculator
{
    public abstract class BinaryOperator: Expression, IOperator
    {
        protected Expression LHS;
        protected Expression RHS;

        public BinaryOperator()
        {
            throw new NotImplementedException();
        }

        public BinaryOperator(TextReader reader)
        {
            throw new NotImplementedException();
        }

        public abstract string OperatorSymbol { get; }

        public sealed override string ToString() => throw new NotImplementedException();

    }
}