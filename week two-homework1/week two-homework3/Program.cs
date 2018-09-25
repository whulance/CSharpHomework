using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace week_two_homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            for (int i = 2; i <= 100; i++)
                list.Add(i);
            Console.WriteLine("the prime numbers between two and one hundred are: ");
            for (int i = 2; i <= 100; i++)
            {
                for (int m = 100; m > i; m--)
                {
                    if (m % i == 0)
                        list.Remove(m);
                }
            }
            int number = list.Count;
            for (int i = 0; i < number; i++)
                Console.WriteLine(list[i]);

        }
    }
}
          
