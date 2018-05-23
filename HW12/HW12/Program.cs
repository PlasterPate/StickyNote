using System;

namespace SimpleCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunCalculator(() => Console.ReadKey().KeyChar, () => Console.Clear());
        }

        /// <summary>
        /// runs the proper method depending on the character that user types
        /// </summary>
        /// <param name="GetKey"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Calculator RunCalculator(Func<char> GetKey, Action a)
        {
            Calculator calc = new Calculator();
            while (true)
            {
                calc.PrintDisplay(a);
                char key = GetKey();
                switch (key)
                {
                    case '.':
                        calc.EnterPoint();
                        break;
                    case '0':
                        calc.EnterZeroDigit();
                        break;
                    case '=':
                    case (char)ConsoleKey.Enter:
                        calc.EnterEqual();
                        break;
                    case (char)ConsoleKey.Escape:
                        calc.Clear();
                        break;
                    case var c when c != '0' && char.IsDigit(c):
                        calc.EnterNonZeroDigit(c);
                        break;
                    case var c when Calculator.Operators.ContainsKey(c):
                        calc.EnterOperator(c);
                        break;
                    case 'q':
                        return calc;
                }
            }
        }
    }
}
