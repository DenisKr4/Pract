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
            Train[] trains;

            Console.Write("Ввеите количество поездов: ");
            int count = int.Parse(Console.ReadLine());

            trains = new Train[count];

            for (int i = 0; i < count; i++)
            {
                Console.Write("Введите номер поезда: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Введите время отпраления (прим. 12:00:00): ");
                string time = Console.ReadLine();

                Console.Write("Введите пункт назначения: ");
                string destination = Console.ReadLine();

                trains[i] = new Train(number, time, destination);
            }

            BubbleSort(trains);

            bool exit = false;

            while(!exit)
            {
                Console.WriteLine("\n1. Найти поезд по номеру\n0. Выйти");
                Console.Write("Выберите действие: ");
                switch(Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("\nВведите номер: ");
                        int num = int.Parse(Console.ReadLine());
                        bool exist = false;
                        foreach (Train tr in trains)
                            if (tr.number == num)
                            {
                                Console.WriteLine(tr.OutputInfo());
                                exist = true;
                            }
                        if (!exist)
                            Console.WriteLine("Такого поезда нет!");
                        break;
                    case "0":
                        exit = true;
                        break;
                }
            }
        }

        protected class Train
        {
            private int _number;
            private string _time;
            private string _destination;

            public int number { get { return _number; } }
            public string time { get { return _time; } }
            public string destination { get { return _destination; } }

            public Train(int number, string time, string destination)
            {
                _number = number;
                _time = time;
                _destination = destination;
            }

            public string OutputInfo()
            {
                return "\nНомер поезда: " + _number.ToString() + "\nВремя отправления: " + _time + "\nПункт назначения: " + _destination;
            }
        }

        protected static void BubbleSort(Train[] trains)
        {
            for (int i = 0; i < trains.Length - 1; i++)
                for (int j = 0; j < trains.Length - i - 1; j++)
                    if (trains[j].number > trains[j + 1].number)
                    {
                        var tempVar = trains[j];
                        trains[j] = trains[j + 1];
                        trains[j + 1] = tempVar;
                    }
        }
    }
}
