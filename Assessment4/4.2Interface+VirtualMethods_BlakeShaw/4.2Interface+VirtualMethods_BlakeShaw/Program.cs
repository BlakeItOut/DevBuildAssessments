using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2Interface_VirtualMethods_BlakeShaw
{
    /*S-Single responsibility principle
     * Each class only has members that would change for the same reason.
     * 0-Open/closed principle
     * The nature of virtual and override used in Shape and square inherently mean the subclass extends and does not modify.
     * L-Liskov
     * The square could replace an instance of shape without affecting the correctness
     * I-Interface segregation principle
     * The interface is about as simple as can be. We could probably write another inteface for ISides that just has a sides property
     * D-Dependency inversion principle
     * The higher level Shape does not depend on the lower level Square and as an abstract class they really both depend on abstraction
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
