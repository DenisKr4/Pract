using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec;

            Console.Write("Введите сторону a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите сторону b: ");
            int b = int.Parse(Console.ReadLine());

            rec = new Rectangle(a, b);

            Console.WriteLine("\nПериметер прамоугольника: {0}", rec.Perimeter);
            Console.WriteLine("Площадь прямоугольника: {0}", rec.Area);

            Console.ReadKey();
        }
        private class Rectangle
        {
            private double side1;
            private double side2;

            public double Area { get { return AreaCalculator(); } }
            public double Perimeter { get { return PerimeterCalculator(); } }
            public Rectangle(double s1, double s2)
            {
                side1 = s1;
                side2 = s2;
            }

            private double AreaCalculator()
            {
                return side1 * side2;
            }

            private double PerimeterCalculator()
            {
                return 2 * (side1 + side2);
            }
        }
    }
}

