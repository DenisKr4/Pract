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
            bool convertTo = false;
            string currency = string.Empty;
            double count = 0;

            Console.WriteLine("Введите курс валют:");
            Console.Write("usd = ");
            double usd = double.Parse(Console.ReadLine());
            Console.Write("eur = ");
            double eur = double.Parse(Console.ReadLine());
            Console.Write("rub = ");
            double rub = double.Parse(Console.ReadLine());

            Convertor c = new Convertor(usd, eur, rub);

            Console.WriteLine("\nВыберите действие:\n1. Из гривень в валюту\n2. Из валюты в гривны");

            if (Console.ReadLine() == "1")
                convertTo = true;

            Console.WriteLine("\nВыберите валюту:\n1. usd\n2. eur\n3. rub");
            switch (Console.ReadLine())
            {
                case "1":
                    currency = "usd";
                    break;
                case "2":
                    currency = "eur";
                    break;
                case "3":
                    currency = "rub";
                    break;
            }

            Console.Write("\nНапишите количество: ");
            count = double.Parse(Console.ReadLine());

            if (convertTo)
                c.ConvertTo(currency, count);
            else
                c.ConvertInto(currency, count);

            Console.ReadKey();
        }

        private class Convertor
        {
            private double _usd;
            private double _eur;
            private double _rub;
            public Convertor(double usd, double eur, double rub)
            {
                _usd = usd;
                _eur = eur;
                _rub = rub;
            }

            public void ConvertTo(string currency, double count)
            {
                switch(currency)
                {
                    case "usd":
                        Console.WriteLine("Количество по курсу: {0}", count * _usd);
                        break;
                    case "eur":
                        Console.WriteLine("Количество по курсу: {0}", count * _eur);
                        break;
                    case "rub":
                        Console.WriteLine("Количество по курсу: {0}", count * _rub);
                        break;
                }
            }

            public void ConvertInto(string currency, double count)
            {
                switch (currency)
                {
                    case "usd":
                        Console.WriteLine("Количество по курсу: {0}", count /_usd);
                        break;
                    case "eur":
                        Console.WriteLine("Количество по курсу: {0}", count / _eur);
                        break;
                    case "rub":
                        Console.WriteLine("Количество по курсу: {0}", count / _rub);
                        break;
                }
            }
        }
    }
}
