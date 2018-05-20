using System;
using System.IO;

namespace OOCalculator
{
    public abstract class BinaryOperator: Expression, IOperator
    {
        //left side operand
        //it's protected so derived classed have access to it
        protected Expression LHS;
        //right side operand
        protected Expression RHS;

        /// <summary>
        /// constructor of binary operator which assign value of LHS and RHS
        /// </summary>
        /// <param name="reader"></param>
        public BinaryOperator(TextReader reader)
        {
            LHS = GetNextExpression(reader);
            RHS = GetNextExpression(reader);
        }

        /// <summary>
        /// symbol of operator
        /// every operator has a symbol 
        /// so this property is abstract and all of unary and binary operators have to override it
        /// </summary>
        public abstract string OperatorSymbol { get; }

        /// <summary>
        /// writes the expression in the correct form
        /// it's same for all operators so it's sealed and operators can't override it by itself
        /// </summary>
        /// <returns></returns>
        public sealed override string ToString() => $"({LHS}{OperatorSymbol}{RHS})";

    }
}