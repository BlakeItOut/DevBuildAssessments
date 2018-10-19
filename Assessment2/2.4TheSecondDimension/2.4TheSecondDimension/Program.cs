using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4TheSecondDimension
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] Matrix = new int[,] { 
                {  5, -4,  3,  0 },
                {  5,  1, -2, -1},
                {  8,  6, -7,  4},
                { -2,  1, -5,  2}
            };
            Print(Matrix);
            ArticulateStats(Matrix);

            Console.WriteLine();
            Console.WriteLine("Here is another random one, just for fun.");
            int[,] newMatrix = MakeMatrix();
            Print(newMatrix);
            ArticulateStats(newMatrix);
        }

        static void ArticulateStats (int[,] Matrix)
        {
            Console.WriteLine($"The sum of the diagonal is {SumDiagonal(Matrix)} and the sum of all the numbers is {SumAll(Matrix)}.");
        }

        public static int SumDiagonal(int[,] Matrix)
        {
            int diagonalSum = 0;
            foreach (int[] coordinate in getCoordinates(Matrix))
            {
                diagonalSum += Matrix[coordinate[0], coordinate[1]];
            }
            return diagonalSum;
        }

        static List<int[]> getCoordinates(int[,] Matrix)
        {
            List<int[]> coordinates = new List<int[]>();
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        coordinates.Add(new int []{i, j});
                    }
                }
            }
            return coordinates;
        }
        
        static int SumAll(int[,] Matrix)
        {
            int allSum = 0;
            foreach (var num in Matrix)
            {
                allSum += num;
            }
            return allSum;
        }

        static void Print(int[,] Matrix)
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write($"{Matrix[i, j],3}");
                }
                Console.WriteLine("");
            }
        }

        static int[,] MakeMatrix ()
        {
            Random rand = new Random();
            int sides = rand.Next(1,25);;
            int[,] Matrix = new int[sides, sides];
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Matrix[i, j] = (rand.Next(0,1)*2-1)*rand.Next(10);
                }
            }
            return Matrix;
        } 
    }
}
