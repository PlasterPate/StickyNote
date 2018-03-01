using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Program
    {
        /// <summary>
        /// gets a list of integer numbers from user. then runs a method on each number that user enters and
        /// prints the return value until user enters -1
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // create an array of integers with 8 indexes
            int[] numbers = new int[8];
            for (int i = 0; i < 8; i++)
            {
                // gets each number of array from user as a string and converts it to integer
                numbers[i] = int.Parse(Console.ReadLine());
            }
            // number entered by user to be checked
            int input_num;
            // get numbers for check from user until -1 is entered
            do
            {
                input_num = int.Parse(Console.ReadLine());
                // this condition prevents program from calculating probability of -1
                if (input_num != -1)
                    Console.WriteLine(random_prob(numbers, input_num));
            } while (input_num != -1);
        }
        /// <summary>
        /// calculates the probability of selecting a number in a list of numbers in a random selection
        /// </summary>
        /// <param name="numbers">an array of integer numbers that we want to select a random number from it</param>
        /// <param name="input_num">integer number entered by user for checking its probability of being selected</param>
        /// <returns>double number between 0 and 1 that shows the probability of selecting input number in numbers list</returns>
        public static double random_prob(int[] numbers, int input_num)
        {
            // number of times that input number is repeated in numbers list
            double input_counter = 0;
            // compare input number with numbers in list 
            foreach (int number in numbers)
            {
                // increase counter by 1 if input number was founded in list
                if (input_num == number)
                    input_counter++;
            }
            double input_prob = input_counter / 8;
            return input_prob;
        }
    }
}
