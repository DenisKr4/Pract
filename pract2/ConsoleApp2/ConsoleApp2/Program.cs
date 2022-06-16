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
            List<Store> stores = new List<Store>();
            Store store = new Store();
            store.FillStoreDefault();
            stores.Add(store);

            bool exit = false;

            while(!exit)
            {
                Console.WriteLine();
                for (int i = 0; i < stores.Count; i++)
                {
                    Console.WriteLine("{0}. Найти товары в магазине \"" + stores[i].FindOutStoreName() + "\" (всего товаров: {1})", i + 1, stores[i].FindOutProductCount());

                    if(i + 1 == stores.Count)
                    {
                        Console.WriteLine("{0}. Добавить новый магазин", i + 2);
                        Console.WriteLine("\n0. Выйти");
                    }
                }

                Console.Write("\nВыберите дейстивие: ");
                int input = int.Parse(Console.ReadLine());

                if (input == 0)
                    exit = true;
                else if(input == stores.Count + 1)
                {
                    Store newStore = new Store();

                    Console.Write("Введите количество товара: ");
                    newStore.FillStore(int.Parse(Console.ReadLine()));

                    stores.Add(newStore);
                }
                else
                {
                    bool back = false;

                    while(!back)
                    {
                        Console.WriteLine("\nВыберите дейстивие:\n1. Найти товар по номеру\n2. Найти товар по имени\n0. Выход");

                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Write("Введите номер: ");
                                Console.WriteLine(stores[input - 1].FindProductFromIndex(int.Parse(Console.ReadLine()) - 1));
                                break;
                            case "2":
                                Console.Write("Введите название: ");
                                Console.WriteLine(stores[input - 1].FindProductFromName(Console.ReadLine()));
                                break;
                            case "0":
                                back = true;
                                break;
                            default:
                                Console.WriteLine("Неверное значение");
                                break;
                        }
                    }
                }
            }
        }

        private class Article
        {
            private string _productName;
            private string _storeName;
            private double _price;

            public string productName { get { return _productName; } }
            public string storeName { get { return _storeName; } }
            public double price { get { return _price; } }

            public Article(string prod, string store, double price)
            {
                _productName = prod;
                _storeName = store;
                _price = price;
            }
        }

        private class Store
        {
            private Article[] _articles;

            public void FillStoreDefault()
            {
                _articles = new Article[5];

                _articles[0] = new Article("Пылесос", "Техника", 1999.99);
                _articles[1] = new Article("Телевизор", "Техника", 10000);
                _articles[2] = new Article("Холодильник", "Техника", 7499);
                _articles[3] = new Article("Кофемашина", "Техника", 2399.99);
                _articles[4] = new Article("Стиральная машина", "Техника", 4700);
            }

            public void FillStore(int count)
            {
                _articles = new Article[count];

                Console.Write("Введите название магазина: ");
                string storeName = Console.ReadLine();

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("Товар №{0}", i + 1);
                    Console.Write("Введите название товара: ");
                    string prodName = Console.ReadLine();
                    Console.Write("Введите цену товара: ");
                    double price = double.Parse(Console.ReadLine());

                    _articles[i] = new Article(prodName, storeName, price);
                }
            }

            public string FindProductFromIndex(int index)
            {
                if (index >= 0 && index < _articles.Length)
                {
                    return "Название: " + _articles[index].productName + "\nМагазин: " + _articles[index].storeName + "\nЦена: " + _articles[index].price + " грн.";
                }
                else
                    return "Такого товара нет!";
            }

            public string FindProductFromName(string name)
            {
                foreach(Article art in _articles)
                    if(art.productName.ToLower() == name.ToLower())
                        return "Название: " + art.productName + "\nМагазин: " + art.storeName + "\nЦена: " + art.price + " грн.";

                return "Такого товара нет!";
            }

            public string FindOutStoreName()
            {
                return _articles[0].storeName;
            }

            public int FindOutProductCount()
            {
                return _articles.Length;
            }
        }
    }
}
