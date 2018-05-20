using System;
using System.IO;

namespace OOCalculator
{
    public abstract class Expression
    {
        /// <summary>
        /// calculate the result of expression
        /// each operator has a different way of calculation
        /// so it's abstract and every operators have to override it
        /// </summary>
        /// <returns></returns>
        public abstract double Evaluate();

        /// <summary>
        /// reads multiple lines and returns an expression in correct format
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Expression BuildExpressionTree(StreamReader reader)
        {
            return Expression.GetNextExpression(reader);
        }

        /// <summary>
        /// reads a line and calls the appropriate operator depend on the operators name
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected static Expression GetNextExpression(TextReader reader)
        {
            string line = reader.ReadLine();
            switch (line)
            {
                case "Add":
                    return new AddOperator(reader);

                case "Subtract":
                    return new SubtractOperator(reader);

                case "Multiply":
                    return new MultiplyOperator(reader);

                case "Negate":
                    return new NegateOperator(reader);

                case "Square":
                    return new SquareOperator(reader);

                case "Divide":
                    return new DivideOperator(reader);

                case "SquareRoot":
                    return new SqrtOperator(reader);

                default:
                    return new NumberExpression(line);

            }
        }
    }
}