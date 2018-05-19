using System;
using System.IO;

namespace OOCalculator
{
    public abstract class UnaryOperator: Expression, IOperator
    {
        protected Expression Operand;

        public UnaryOperator(TextReader reader)
        {
            Operand = GetNextExpression(reader);
        }

        public sealed override string ToString() => $"{OperatorSymbol}({Operand})";

        public abstract string OperatorSymbol { get; }
    }
}