using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloworld
{
    public class Program
    {
        public static bool check(int[] numbers, bool asc)
        {
            int first_num = numbers[0];
            foreach (int num in numbers)
            {
                if (asc)
                    if (num < first_num)
                        return false;
                    else
                        first_num = num;
                else
                    if (num > first_num)
                    return false;
                else
                    first_num = num;
            }
            return true;
        }

        static void Main(string[] args)
        {
<<<<<<< HEAD
            

            //Console.ReadKey();
=======
>>>>>>> 72c067e5c81458212549ce070d5b05effdb6d6d3
        }
    }
}
