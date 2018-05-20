﻿using System;
using System.IO;

namespace OOCalculator
{
    public class AddOperator : BinaryOperator
    {
        /// <summary>
        /// calls the base constructor
        /// </summary>
        /// <param name="reader"></param>
        public AddOperator(TextReader reader)
            : base(reader)
        {
            
        }

        //overrides operator symbol of binary operator class
        public override string OperatorSymbol => "+";

        /// <summary>
        /// override the evaluate method of expressions class
        /// </summary>
        /// <returns></returns>
        public override double Evaluate() => LHS.Evaluate() + RHS.Evaluate();
    }
}