using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._3RefactoringDebugging_BlakeShaw
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 1, 2, 3, 4, 5, 6 };
            //Removed unnecessary action
            //int i = 0;
            //Removed unnecessary semicolon but also commented out so doesn't really matter.
            //for (i = 0; i < array1.Length; i++)
            //{
            //    array1[i]++;
            //}
            int result = GetSum(array1);
            Console.WriteLine(result);
        }
        //set as static so it could be called and set the return type to int to match the destination
        private static int GetSum(int[] array1)
        {
            //changed starting value of the sum to zero so we did not start with an extra 1 added.
            int sum = 0;
            foreach (int item in array1)
            {
                sum = sum + item;
            }
            //add space where there summed number was actually returned back to be used
            return sum;
        }
    }
}
