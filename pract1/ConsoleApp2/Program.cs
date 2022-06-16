using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Выберите количество точек(от 3 до 5): ");
            int count = int.Parse(Console.ReadLine());
            List<Point> points = new List<Point>();

            if (count >= 3 && count <= 5)
                for (int i = 0; i < count; i++)
                {
                    Console.Write("\nВведите x точки номер {0}:", i + 1);
                    int x = int.Parse(Console.ReadLine());
                    Console.Write("Введите y точки номер {0}:", i + 1);
                    int y = int.Parse(Console.ReadLine());

                    points.Add(new Point(x, y, ""));
                }
            else
            {
                Console.WriteLine("Неверно введено значение");
                Console.ReadKey();
                return;
            }

            if (count == 3)
            {
                Figure fig = new Figure(points[0], points[1], points[2]);
                fig.PerimeterCalculator();
            }
            else if (count == 4)
            {
                Figure fig = new Figure(points[0], points[1], points[2], points[3]);
                fig.PerimeterCalculator();
            }
            else
            {
                Figure fig = new Figure(points[0], points[1], points[2], points[3], points[4]);
                fig.PerimeterCalculator();
            }

            Console.ReadKey();
        }
        
        private class Point
        {
            private int _x;
            private int _y;
            private string _str;

            public int x { get { return _x; } }
            public int y { get { return _y; } }
            public string str { get { return _str; } }

            public Point(int x, int y, string str)
            {
                _x = x;
                _y = y;
                _str = str;
            }
        }

        private class Figure
        {
            private Point _p1;
            private Point _p2;
            private Point _p3;
            private Point _p4;
            private Point _p5;

            public Figure(Point p1, Point p2, Point p3)
            {
                _p1 = p1;
                _p2 = p2;
                _p3 = p3;
            }

            public Figure(Point p1, Point p2, Point p3, Point p4)
            {
                _p1 = p1;
                _p2 = p2;
                _p3 = p3;
                _p4 = p4;
            }
            
            public Figure(Point p1, Point p2, Point p3, Point p4, Point p5)
            {
                _p1 = p1;
                _p2 = p2;
                _p3 = p3;
                _p4 = p4;
                _p5 = p5;
            }

            private double LenghtSide(Point a, Point b)
            {
                return Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
            }

            public void PerimeterCalculator()
            {
                if(_p5 == null && _p4 == null)
                {
                    Console.WriteLine("Название фигуры: Треугольник");
                    Console.WriteLine("Площадь фигуры: {0}", LenghtSide(_p1, _p2) + LenghtSide(_p2, _p3) + LenghtSide(_p3, _p1));
                }
                else if(_p5 == null)
                {
                    Console.WriteLine("Название фигуры: Четырехугольник");
                    Console.WriteLine("Площадь фигуры: {0}", LenghtSide(_p1, _p2) + LenghtSide(_p2, _p3) + LenghtSide(_p3, _p4) + LenghtSide(_p4, _p1));
                }
                else
                {
                    Console.WriteLine("Название фигуры: Многоугольник");
                    Console.WriteLine("Площадь фигуры: {0}", LenghtSide(_p1, _p2) + LenghtSide(_p2, _p3) + LenghtSide(_p3, _p4) + LenghtSide(_p4, _p5) + LenghtSide(_p5, _p1));
                }
            }
        }
    }
}
