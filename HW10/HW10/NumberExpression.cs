using System;
using System.IO;

namespace OOCalculator
{
    public class NumberExpression : Expression
    {
        protected double Number;

        public NumberExpression(string line)
        {
            Number = double.Parse(line);
        }

        public override double Evaluate() => Number;

        public override string ToString() => Number.ToString();
    }
}