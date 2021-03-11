using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2_1
{
    class PrimeFactor
    {
        public void showPrimeFactor(int x)
        {

            for (int a = 2; a < x; ++a)
            {
                if (x % a == 0 && a != x)
                {
                    if (a <= 7)
                    {
                        if (a == 2 || a == 3 || a == 5 || a == 7)
                        {

                            Console.WriteLine(a);
                        }
                    }
                    else
                    {
                        if (a % 2 != 0 && a % 3 != 0 && a % 5 != 0 && a % 7 != 0)
                        {
                            Console.WriteLine(a);
                        }

                    }
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("输入数字x为");
            int x = Int32.Parse(Console.ReadLine());
            PrimeFactor per = new PrimeFactor();
            Console.WriteLine("正整数x的质因数有");
            Console.WriteLine("1");
            per.showPrimeFactor(x);
            Console.ReadLine();
        }
    }
}
