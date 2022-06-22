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
            bool exit = false;
            List<int> nums = new List<int>();

            while(!exit)
            {
                Console.Write("Введите команду: ");
                string command = Console.ReadLine();
                try
                {
                    nums.Add(Convert.ToInt32(command));
                }
                catch
                {
                    if (command == "exit")
                        exit = true;
                    else if (command == "sum")
                    {
                        SumValues(nums);
                        nums = new List<int>();
                    }
                    else
                        Console.WriteLine("Неопознанная команда");

                }
            }
        }

        static void SumValues(List<int> nums)
        {
            int sum = 0;

            for(int i = 0; i < nums.Count; i++)
                sum += nums[i];

            Console.WriteLine("Сумма введенных значений: {0}", sum);
        }
    }
}
