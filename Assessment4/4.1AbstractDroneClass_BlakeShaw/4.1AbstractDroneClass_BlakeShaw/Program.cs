using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1AbstractDroneClass_BlakeShaw
{
    /*S-Single responsibility principle
     * The drone and quadrotor both have only a single responsibility they would only change if there was a change to how the flight speed was calcuated
     * 0-Open/closed principle
     * The private variables in drone ensure that quadrotor extends rather than modifies the drone class
     * L-Liskov
     * The quadrotor could replace an instance of drone without affecting the correctness
     * I-Interface segregation principle
     * Didn't really have interfaces here but if we did then we would probably have one associated with each property or method almost
     * D-Dependency inversion principle
     * The higher level drone does not depend on the lower level quadrotor and as an abstract class they really both depend on abstraction
     */
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
