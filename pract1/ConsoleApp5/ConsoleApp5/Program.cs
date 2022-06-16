using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя аккаунта: ");
            string account = Console.ReadLine();
            Console.Write("Введите имя покупателя: ");
            string customer = Console.ReadLine();
            Console.Write("Введите имя поставщика: ");
            string provider = Console.ReadLine();

            Invoice invoice = new Invoice(account, customer, provider);
            Console.Write("Введите количество товара: ");
            Console.WriteLine(invoice.GetInvoice(int.Parse(Console.ReadLine())));

            Console.ReadKey();
        }

        class Invoice
        {
            private string _account;
            private string _customer;
            private string _provider;

            private string _article;
            private int _quantity;

            public Invoice(string account, string customer, string provider)
            {
                _account = account;
                _customer = customer;
                _provider = provider;
            }

            private double CalcOrderPrice()
            {
                return _quantity * 1000;
            }

            private double CalcOrderPriceNDS()
            {
                return _quantity * 1000 - (_quantity * 0.10);
            }

            public string GetInvoice(int quantity)
            {
                _quantity = quantity;
                Random r = new Random();

                return "\nАккаунт: " + _account + "\nПокупатель: " + _customer + "\nПоставщик: " + _provider + "\nАртикл: " + r.Next(1000, 10000).ToString() 
                    + "\nЦена заказа: " + CalcOrderPrice().ToString() + "\nЦена с учетом НДС: " + CalcOrderPriceNDS().ToString();
            }
        }
    }
}
