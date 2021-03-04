using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_1
{
    class Test
    {
        public void calculate(double n1, double n2, string symbol)//三个形参
        {
            double result = 0;
            switch (symbol)
            {
                case "+":
                    result = n1 + n2;
                    Console.WriteLine($"这两数之和为:{result}");
                    break;
                case "-":
                    result = n1 - n2;
                    Console.WriteLine($"这两数之差为:{result}");
                    break;
                case "*":
                    result = n1 * n2;
                    Console.WriteLine($"这两数之积为:{result}");
                    break;
                case "/":
                    switch (n2)
                    {
                        case 0:
                            Console.WriteLine("请重新输入不等于0的n2");
                            double rn2 = double.Parse(Console.ReadLine());
                            result = n1 / rn2;
                            Console.WriteLine($"这两数之商为:{result}");
                            break;
                        default:
                            result = n1 / n2;
                            Console.WriteLine($"这两数之商为:{result}");
                            break;
                    }
                    break;
                case "%":
                    switch (n2)
                    {
                        case 0:
                            Console.WriteLine("请重新输入不为零的n2");
                            double rn2 = double.Parse(Console.ReadLine());
                            result = n1 % rn2;
                            Console.WriteLine($"这两数取余为:{result}");
                            break;
                        default:
                            result = n1 % n2;
                            Console.WriteLine($"这两数取余为:{result}");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("请输入正确的运算符号:");
                    string rFuhao = Console.ReadLine();
                    switch (rFuhao)
                    {
                        case "+":
                            result = n1 + n2;
                            Console.WriteLine($"这两数之和为:{result}");
                            break;
                        case "-":
                            result = n1 - n2;
                            Console.WriteLine($"这两数之差为:{result}");
                            break;
                        case "*":
                            result = n1 * n2;
                            Console.WriteLine($"这两数之积为:{result}");
                            break;
                        case "/":
                            switch (n2)
                            {
                                case 0:
                                    Console.WriteLine("请重新输入不为0的n2");
                                    double rn2 = double.Parse(Console.ReadLine());
                                    result = n1 / rn2;
                                    Console.WriteLine($"这两数的商为:{result}");
                                    break;
                                default:
                                    result = n1 / n2;
                                    Console.WriteLine($"这两数的商为:{result}");
                                    break;
                            }
                            break;
                        case "%":
                            switch (n2)
                            {
                                case 0:
                                    Console.WriteLine("请重新输入不为零的n2");
                                    double rn2 = double.Parse(Console.ReadLine());
                                    result = n1 % rn2;
                                    Console.WriteLine($"这两数取余为:{result}");
                                    break;
                                default:
                                    result = n1 % n2;
                                    Console.WriteLine($"这两数取余为:{result}");
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }
    }
    class Calculator_1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入n1:");
            double n1 = double.Parse(Console.ReadLine());
            Console.WriteLine("请输入n2:");
            double n2 = double.Parse(Console.ReadLine());
            Console.WriteLine("请输入运算符号:+、-、*、/、%中的一个");
            string symbol = Console.ReadLine();
            Test per = new Test();
            per.calculate(n1, n2, symbol);
            Console.ReadLine();
        }
    }
}
