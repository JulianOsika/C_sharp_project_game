using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Julian Osika przedstawia");
            Thread.Sleep(3000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" 88    888     8888   8     8    88 ");
            Console.WriteLine("8  8   8  8    8      8 8   8   8  8");
            Console.WriteLine("8888   888     888    8  8  8   8888");
            Console.WriteLine("8  8   8  8    8      8   8 8   8  8");
            Console.WriteLine("8  8   8   8   8888   8     8   8  8");
            Thread.Sleep(5000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Interface i1 = new Interface();

            int i = 1;
            do { i1.CheckButton(); } while (i == 1);

        }
    }
}
