using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1._3IdLikeToByAVowel_BlakeShaw
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int vowelCount = 0;
                Console.Write("Enter a string: ");
                string toBeChecked = Console.ReadLine();
                foreach (char letter in toBeChecked) {
                    if(Regex.IsMatch(letter.ToString(), @"[AEIOUaeiou]"))
                    {
                        vowelCount++;
                    }
                }
                Console.WriteLine($"There were {vowelCount} vowels.");
            }
        }
    }
}
