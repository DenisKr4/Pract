using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Accauntant accauntant = new Accauntant();
            Post worker;
            int hours;

            Array arr = Enum.GetValues(typeof(Post));

            Console.WriteLine("Выберите должность: ");

            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + arr.GetValue(i).ToString());
            }

            switch(Console.ReadLine())
            {
                case "1":
                    worker = Post.Техник;
                    break;
                case "2":
                    worker = Post.Программист;
                    break;
                case "3":
                    worker = Post.Тестировщик;
                    break;
                case "4":
                    worker = Post.Менеджер;
                    break;
                default:
                    Console.WriteLine("Неверное введенное значние!");
                    Console.ReadKey();
                    return;
            }

            Console.Write("Введите количество часов: ");
            hours = int.Parse(Console.ReadLine());

            if (accauntant.AskForBonus(worker, hours))
                Console.WriteLine("\nЭтот работник заслужил повышение!");
            else
                Console.WriteLine("\nЭтот работник не заслужил повышение.");

            Console.ReadKey();
        }

        protected enum Post
        {
            Техник = 20,
            Программист = 30, 
            Тестировщик = 40,
            Менеджер = 25
        }

        protected class Accauntant
        {
            public bool AskForBonus(Post worker, int hours)
            {
                if ((int)worker > hours)
                    return true;
                else
                    return false;
            }
        }
    }
}
