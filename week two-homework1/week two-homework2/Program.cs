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
            double sum = 0;
            foreach (int n in list)
            {
                max = (n > max) ? n : max;
                min = (n < min) ? n : min;
                sum += n;
            }
            double average = sum / list.Length;
            Console.WriteLine("the max is : " + max);
            Console.WriteLine("the min is : " + min);
            Console.WriteLine("the average is : " + average);
            Console.WriteLine("the sum is : " + sum);
        }
    }
}
