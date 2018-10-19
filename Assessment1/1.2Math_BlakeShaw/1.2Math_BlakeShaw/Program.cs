using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2Math_BlakeShaw
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter an integer: ");
                int number = int.Parse(Console.ReadLine());
                for (int i = 0; i <= 12; i++)
                {
                    Console.WriteLine($"{number} x {i} = {number * i}");
                }
            }    
        }
    }
}
