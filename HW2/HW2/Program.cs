using System;
using System.Collections.Generic;
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
            // a variable for taking numbers as a string in one line
            string number_str = Console.ReadLine();
            // break string into numbers which were separated by space and put them in the indexes of this array
            string[] splitted = number_str.Split();
            // create an ineger array to save numbers as integers
            int[] numbers = new int[splitted.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                // convert string numbers in splitted array to integers and put them in the numbers array
                numbers[i] = int.Parse(splitted[i]);
            }

            // number entered by user to be checked
            int input_num;
            // get numbers for check from user until -1 is entered
            do
            {
                input_num = int.Parse(Console.ReadLine());
                Console.WriteLine(random_prob(numbers, input_num));
                // this condition prevents program from calculating probability of -1
                if (input_num == -1)
                    break;
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
            double input_prob = input_counter / numbers.Length;
            return input_prob;
        }
    }
}
