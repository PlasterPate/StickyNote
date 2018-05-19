using System;
using System.IO;

namespace OOCalculator
{
    public abstract class Expression
    {
        public abstract double Evaluate();

        public static Expression BuildExpressionTree(StreamReader reader)
        {
            return Expression.GetNextExpression(reader);
        }

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