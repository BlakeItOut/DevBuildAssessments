using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2Interface_VirtualMethods_BlakeShaw
{
    class Square : Shape
    {
        public double Side { get; set; }
        public Square() => Side = 0;
        public Square(int side) => Side = side;
        public override void Draw() => Console.WriteLine("Hi, I am a square!");
        public double GetArea() => Math.Pow(Side, 2);
    }
}
