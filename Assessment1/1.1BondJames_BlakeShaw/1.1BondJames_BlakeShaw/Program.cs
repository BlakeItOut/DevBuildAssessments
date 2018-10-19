using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1BondJames_BlakeShaw
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a first and last name: ");
                string name = Console.ReadLine();
                Console.WriteLine($"{name.Split(' ')[1]} {name.Split(' ')[0]}");
            }
        }
    }
}
