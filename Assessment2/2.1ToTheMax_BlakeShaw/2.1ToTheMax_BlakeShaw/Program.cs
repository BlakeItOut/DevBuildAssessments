using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1ToTheMax_BlakeShaw
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = int.Parse(promptUser("How many numbers would you like in this array? ", (x => int.TryParse(x, out n) && n > 0)));
                double[] numberArray = new double[n];

                for (int i = 0; i < n; i++)
                {
                    numberArray[i] = double.Parse(promptUser($"What would you like for the number at index {i}? ", (x => double.TryParse(x, out numberArray[i]))));
                }
                double max = numberArray[0];
                foreach (double number in numberArray)
                {
                    max = (number > max) ? number : max;
                }
                Console.WriteLine($"The max is {max}.");
            }  
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
