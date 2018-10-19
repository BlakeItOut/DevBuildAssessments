using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2._3ListOnListOnList
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ascending = true;
            List<string> listOfString = new List<string> { "alpha", "beta", "gamma" };
            while (true)
            {
                switch (promptUser("Would you like to add(a), search(s), order alphabetically(o), or print(p)? ", (response => Regex.IsMatch(response.ToLower(), @"^[asop]"))))
                {
                    case "a":
                        add(ref listOfString);
                        break;
                    case "s":
                        search(listOfString);
                        break;
                    case "o":
                        ascending = order(ref listOfString, ascending);
                        break;
                    case "p":
                        print(listOfString);
                        break;
                    default:
                        break;
                }
            } 
        }

        static void add(ref List<string> listOfString)
        {
            string stringToAdd = promptUser("What string would you like to add? ", (str => !string.IsNullOrWhiteSpace(str)));
            listOfString.Insert(~(listOfString.BinarySearch(stringToAdd)), stringToAdd);
        }

        static void search( List<string> listOfString)
        {
            string stringToSearchFor = promptUser("What string would you like to search for? ", (str => !string.IsNullOrWhiteSpace(str)));
            if(listOfString.Exists(item => item.Contains(stringToSearchFor)))
            {
                Console.WriteLine($"{stringToSearchFor} can be found in the following:");
                foreach (string word in listOfString.FindAll(item => item.Contains(stringToSearchFor))) {
                    Console.WriteLine($"{word} from index {listOfString.IndexOf(word)}");
                }
                     
            }
            else
            {
                Console.WriteLine($"{stringToSearchFor} cannot be found in the list");
            }
        }

        static bool order(ref List<string> listOfString, bool ascending)
        {
            listOfString.Sort((a,b)=>(ascending?1:-1)* a.CompareTo(b));
            return !ascending;
        }

        static void print(List<string> listOfString)
        {
            listOfString.ForEach(Console.WriteLine);
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
