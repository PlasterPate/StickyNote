using System;
using System.IO;

namespace OOCalculator
{
    public abstract class UnaryOperator: Expression, IOperator
    {
        protected Expression Operand;

        /// <summary>
        /// constructor of unary operator which assigns the operand
        /// </summary>
        /// <param name="reader"></param>
        public UnaryOperator(TextReader reader)
        {
            Operand = GetNextExpression(reader);
        }

        /// <summary>
        /// writes the expression in the correct form
        /// it's same for all operators so it's sealed and operators can't override it by itself
        /// </summary>
        /// <returns></returns>
        public sealed override string ToString() => $"{OperatorSymbol}({Operand})";

        /// <summary>
        /// symbol of operator
        /// every operator has a symbol 
        /// so this property is abstract and all of unary and binary operators have to override it
        /// </summary>
        public abstract string OperatorSymbol { get; }
    }
}