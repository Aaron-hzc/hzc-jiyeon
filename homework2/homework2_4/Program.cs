using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2_4
{
    class Program
    {
        static bool isTrue(int row,int col, int[,] matarix)
        {
            for(int i = 0; i < row-1; i++)
            {
                for(int j = 0; j < col-1; j++)
                {
                    if (matarix[i, j] != matarix[i + 1, j + 1])
                        return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入此矩阵的行数和列数：");
            String str = Console.ReadLine();
            String[] strs = str.Split(' ');

            int row = int.Parse(strs[0]);
            int col = int.Parse(strs[1]);
            int[,] ma = new int[row, col];

            Console.WriteLine("请输入矩阵各行元素值：");
            for(int i = 0; i < row; i++)
            {
                String number = Console.ReadLine();
                String[] numbers = number.Split(' ');
                for(int j = 0; j < col; j++)
                {
                    ma[i, j] = int.Parse(numbers[j]);
                }
            }

            if (isTrue(row, col, ma))
                Console.WriteLine("Ture");
            else
                Console.WriteLine("False");
            Console.ReadLine();
        }
    }
}
