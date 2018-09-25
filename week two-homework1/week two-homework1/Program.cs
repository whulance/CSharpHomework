using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace week_two_homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int k=1;
            Console.WriteLine("the number is: ");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("the prime numbers of this number are: ");
            for (int m=2;m<=i;m++,k=1)
            {
                if(i%m==0)
                {
                    int n;
                    for ( n = 2; n < m; n++)
                    {
                        if (m % n == 0)
                            k = 0;
                    }
                    if (1 == k)
                        Console.WriteLine(m + "");
                        

                }
            }*/
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
            Console.WriteLine("23");
        }
    }
}
