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
            MyClass myClass = new MyClass();
            MyStruct myStruct = new MyStruct();

            myClass.change = "не изменено";
            myStruct.change = "не изменено";

            Console.WriteLine("\nClass: " + myClass.change + "\nStruct: " + myStruct.change);

            ClassTaker(myClass);
            StructTaker(myStruct);

            Console.WriteLine("\nClass: " + myClass.change + "\nStruct: " + myStruct.change);

            Console.ReadKey();
        }

        struct MyStruct
        {
            public string change;
        }

        class MyClass
        {
            public string change;
        }

        static void StructTaker(MyStruct myStruct)
        {
            myStruct.change = "изменено";
        }

        static void ClassTaker(MyClass myClass)
        {
            myClass.change = "изменено";
        }
    }
}
