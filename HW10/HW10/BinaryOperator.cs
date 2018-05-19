using System;
using System.IO;

namespace OOCalculator
{
    public abstract class BinaryOperator: Expression, IOperator
    {
        protected Expression LHS;
        protected Expression RHS;

        public BinaryOperator(TextReader reader)
        {
            LHS = GetNextExpression(reader);
            RHS = GetNextExpression(reader);
        }

        public abstract string OperatorSymbol { get; }

        public sealed override string ToString() => $"({LHS}{OperatorSymbol}{RHS})";

    }
}