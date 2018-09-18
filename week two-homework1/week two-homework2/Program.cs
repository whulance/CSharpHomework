using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_two_homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list;
            Console.WriteLine("Please enter the length of the list:");
            int length = Convert.ToInt32(Console.ReadLine());
            list = new int[length];
            for (int n = 0; n < length; n++)
            {
                list[n] = Convert.ToInt32(Console.ReadLine());
            }
            int max = list[0];
            int min = list[0];
            for (int i = 0; i < length; i++)
            {
                if (max < list[i])
                    max = list[i];
            }
            Console.WriteLine("the max is : " + max);
            for (int i = 0; i < length; i++)
            {
                if (min > list[i])
                    min = list[i];
            }
            Console.WriteLine("the min is : " + min);
            float sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += list[i];
            }
            Console.WriteLine("the average is : " + sum / length);
            Console.WriteLine("the sum is : " + sum);
        }
    }
}
