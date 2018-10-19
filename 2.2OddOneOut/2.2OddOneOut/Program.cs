using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2OddOneOut
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = int.Parse(promptUser("What number would you like to go up to? ", (x => int.TryParse(x, out n) && n > 0)));
                int[] odds = Enumerable.Range(1, n).Where(i => (i%2 == 1)).ToArray();
                Console.WriteLine($"For all the odds from 1 to {n}, [{string.Join(", ",odds)}], the sum is {getSum(odds)} and the average is {getAverage(odds)}.");
            }
        }

        static int getSum (int[] odds)
        {
            int sum = 0;
            foreach (int odd in odds)
            {
                sum += odd;
            }
            return sum;
        }

        static int getAverage (int[] odds)
        {
            return getSum(odds) / odds.Length;
        }

        static string promptUser(string message, Func<string, bool> condition)
        {
            Console.Write(message);
            string textValue = Console.ReadLine();
            if (condition(textValue))
            {
                return textValue;
            }
            else
            {
                Console.WriteLine("This is not valid input.");
                return promptUser(message, condition);
            }
        }
    }
}
