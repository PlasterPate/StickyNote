using System;
using System.IO;

namespace OOCalculator
{
    public class NumberExpression : Expression
    {
        //number 
        protected double Number;

        /// <summary>
        /// constructor of number expression which assigns the number value
        /// </summary>
        /// <param name="line"></param>
        public NumberExpression(string line)
        {
            Number = double.Parse(line);
        }

        /// <summary>
        /// override the evaluate method of expressions class
        /// </summary>
        /// <returns></returns>
        public override double Evaluate() => Number;

        /// <summary>
        /// convert number to string
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Number.ToString();
    }
}