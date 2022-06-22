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
            Random r = new Random();
            LinkedList<int> list = new LinkedList<int>();
            int count = r.Next(3, 11);
            int sum = 0;

            for (int i = 0; i < count; i++)
                list.AddLast(r.Next(50, 3000));

            count = 1;

            for(int i = 0; list.Count > i ; list.RemoveFirst())
            {
                Console.WriteLine("Клиент №{0}\nСумма поупки: {1}", count, list.First.Value);
                count++;
                Console.WriteLine("Нажмите клавишу чтобы обслужить");
                Console.ReadLine();
                sum += list.First.Value;
                Console.WriteLine("Ваш доход: {0}\n", sum);
            }

            Console.ReadKey();
        }
    }
}
