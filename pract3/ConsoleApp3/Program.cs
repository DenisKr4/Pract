using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите цвет: ");
            for(int i = 1; i < 5; i++)
            {
                Console.WriteLine(i + ". " + Enum.GetName(typeof(Colors), i));
            }

            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();

            Print(str, num);

            Console.ReadKey();
        }

        enum Colors
        {
            Red = 1,
            Green,
            Yellow,
            Blue
        }

        static void Print(string str, int colorNum)
        {
            string color = ((Colors)colorNum).ToString();

            switch (color)
            {
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "Blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }

            Console.WriteLine("\n" + str);
        }
    }
}
