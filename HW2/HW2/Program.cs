using System;
using System.IO;
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
            string number_str = input(Console.In);
            // break string into numbers which were separated by space and put them in the indexes of this array
            string[] splitted = number_str.Split();
            // create an ineger array to save numbers as integers
            int[] numbers = new int[splitted.Length];
            // pass the splitted array(which have string numbers) and numbers array(empty)
            // to the method to convert numbers from string to integer
            str_to_int(splitted, numbers);
            // number entered by user to be checked
            int input_num;
            // get numbers for check from user until -1 is entered
            do
            {
                // get number from user and convert them to int
                input_num = int.Parse(input(Console.In));
                output(Console.Out, numbers, input_num);
                // this condition prevents program from calculating probability of -1
                if (input_num == -1)
                    break;
            } while (input_num != -1);
        }
        /// <summary>
        /// gets a string from user
        /// </summary>
        /// <param name="reader">stream of text which we want to read from it</param>
        /// <returns>returns the string entered by user</returns>
        public static string input(TextReader reader) => reader.ReadLine();
        /// <summary>
        /// write the number calculated by random_prob method
        /// </summary>
        /// <param name="writer">stream of text which we want to write something on it</param>
        /// <param name="arr">the array that is going to be passed to random_prob method</param>
        /// <param name="num">the number that is going to be passed to random_prob method</param>
        public static void output(TextWriter writer, int[] arr, int num)
        {
            writer.WriteLine(random_prob(arr, num));
        }
        /// <summary>
        /// gets two arrays.one string and one int
        /// converts string numbers in string array to integers and put them in the int array 
        /// </summary>
        /// <param name="str_arr">string array</param>
        /// <param name="int_arr">integer array which is going to fill with str_arr indexes converted to integer</param>
        public static void str_to_int(string[] str_arr, int[] int_arr)
        {
            for (int i = 0; i < int_arr.Length; i++)
            {
                int_arr[i] = int.Parse(str_arr[i]);
            }
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
