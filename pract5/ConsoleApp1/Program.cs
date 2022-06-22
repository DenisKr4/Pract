using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 100; i++)
                Directory.CreateDirectory(@"C:\Folder\Folder_" + i.ToString());

            Process.Start(@"C:\Folder");
            Thread.Sleep(5000);

            for (int i = 0; i < 100; i++)
                Directory.Delete(@"C:\Folder\Folder_" + i.ToString());
        }
    }
}
