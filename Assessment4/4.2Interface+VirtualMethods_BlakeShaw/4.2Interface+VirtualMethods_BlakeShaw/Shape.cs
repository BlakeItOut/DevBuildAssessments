using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2Interface_VirtualMethods_BlakeShaw
{
    abstract class Shape : IShape
    {
        public virtual void Draw() => Console.WriteLine("Hi, I am a shape.");
    }
}
