using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"C:\Users\user\Desktop\file.txt";
            File.Create(path).Close();
            File.WriteAllText(path, "Ghjbpdjmyst lfyyst\n\nПроизваольные данные!!1!");
            Console.WriteLine(File.ReadAllText(path));
            Console.ReadKey();
        }
    }
}
