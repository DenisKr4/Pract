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
            Console.WriteLine("Было");

            int[] arr = new int[5] { 3, 5, 9, 0, -1 };

            foreach (int x in arr)
                Console.Write("{0} ", x);

            arr.SortArr();

            Console.WriteLine("\nСтало");

            foreach (int x in arr)
                Console.Write("{0} ", x);

            Console.ReadKey();
        }

    }

    public static class ArraySort
    {
        public static void SortArr(this int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }                   
                }            
            }
        }
    }
}
