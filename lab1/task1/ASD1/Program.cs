using System;
using static System.Math;
namespace ASD1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input x"); double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input y"); double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input z"); double z = Convert.ToDouble(Console.ReadLine());
            double a, b;
            if (Sin(PI + x) != 0 && z != 0 && y != 0)
            {
                a = (1 / (2 * Sin(PI + x))) + Pow(Sin((x + y) / z), 2);
                b = (Cos(Pow(a, 2) * x)) / 2 * y * z;
                Console.WriteLine($"a = {a}\nb = {b}");
            }
            else
            {
                Console.WriteLine("Error, input another x, y, z");
            }
        }
    }
}
