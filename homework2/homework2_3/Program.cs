using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a;
            a = new int[99];
            for(int i = 2; i <= 100; i++)
            {
                a[i - 2] = i;
            }
            Console.WriteLine("2到100以内的素数有：");
            for(int n = 0; n <= 98; n++)
            {
                if(a[n] % 2 != 0 && a[n] % 3 != 0 && a[n] % 5 != 0 && a[n] % 7 != 0)
                {
                    Console.WriteLine(a[n]);
                }
            }
            Console.ReadLine();
        }
    }
}
