using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("此数组中的所有元素值为：");
            String str = Console.ReadLine();
            String[] strs = str.Split(' ');
            int l = strs.Length;
            int[] a = new int[l];
            int max = int.Parse(strs[0]);
            int min = int.Parse(strs[0]);
            int sum = 0;
            for(int i = 0; i < l; i++)
            {
                a[i] = int.Parse(strs[i]);
                if (max > a[i])
                    max = max;
                else
                    max = a[i];
                if (min < a[i])
                    min = min;
                else
                    min = a[i];
                sum += a[i];
            }
            Console.WriteLine("最大值为{0}，最小值为{1}，平均值为{2}，所有元素的和为{3}。",max, min, sum / l, sum);
            Console.ReadLine();
        }
    }
}
