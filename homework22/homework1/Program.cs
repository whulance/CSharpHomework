using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            string i1 = Console.ReadLine();
            string i2 = Console.ReadLine();
            int data1 = Convert.ToInt32(i1);
            int data2 = Convert.ToInt32(i2);
            int i3 = data1 * data2;
            Console.WriteLine(i3);
        }
    }
}
