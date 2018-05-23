using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Calculator
    {
        /// <summary>
        /// constructor of calculator which puts it in the start state(ready to work)
        /// </summary>
        public Calculator()
        {
            this.State = new StartState(this);
        }

        /// <summary>
        /// a dictionory that its keys are operator characters 
        /// and values are functions that get two doubles and return the result using that operator(key)
        /// </summary>
        public static readonly Dictionary<char, Func<double, double, double>> Operators =
            new Dictionary<char, Func<double, double, double>>()
            {
                ['+'] = (x, y) => x + y,
                ['-'] = (x, y) => x - y,
                ['/'] = (x, y) => x / y,
                ['*'] = (x, y) => x * y,
                ['^'] = (x, y) => Math.Pow(x, y)
            };

        /// <summary>
        /// shows the current number on screen
        /// the action is going to be console.clear in the program
        /// but it can be anything
        /// </summary>
        /// <param name="a">a function that runs before main work</param>
        public void PrintDisplay(Action a)
        {
            a();
            Console.Write(this.Display);
        }

        //the string of number that is shown
        public string Display { get; set; } = "0";

        //the actual number that we do the calculations on it and saves the values
        public double Accumulation { get; set; }
        
        //a nullable char that saves the operator char that user have entered.
        //it will be null if no operators have entered 
        public char? PendingOperator { get; set; } = null;
        
        //the state that calculator is in it.for example at the start 
        //or when a dot is entered or after entering operators ,etc.
        public IState State { get; protected set; }

        /// <summary>
        /// does the calculation on numbers with pending operator
        /// or just parse the number on screen if there is no operators
        /// </summary>
        public void Evalute()
        {
            Accumulation = PendingOperator.HasValue ? 
                    Operators[PendingOperator.Value](Accumulation, double.Parse(Display)) :
                    double.Parse(Display);
        }

        /// <summary>
        /// shows the error message in red for half a second
        /// </summary>
        /// <param name="message"></param>
        public void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ResetColor();
            Thread.Sleep(500);
        }

        /// <summary>
        /// parse the double number to string to be shown in display
        /// </summary>
        public void UpdateDisplay() => Display = Accumulation.ToString();

        public void EnterPoint() => State = State.EnterPoint();
        public void EnterZeroDigit() => State = State.EnterZeroDigit();
        public void EnterNonZeroDigit(char c) => State = State.EnterNonZeroDigit(c);

        public void EnterOperator(char op)
        {
            State = State.EnterOperator(op);
            PendingOperator = op;
        }

        public void EnterEqual() => State = State.EnterEqual();

        /// <summary>
        /// clears everything and goes to start state
        /// </summary>
        public void Clear()
        {
            Accumulation = 0;
            State = new StartState(this);
            PendingOperator = null;
            Display = "0";
        }
    }
}
