using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3_2
{
    class Program
    {
        public interface Shape
        {
            int Area();
            int Area(int length, int width);
            int Area(int a);
            int Area(int x, int y, int z);
            bool isLegal();
        }
        class Rectangle : Shape
        {
            int length, width;
            public int Length
            {
                get
                {
                    return length;
                }
                set
                {
                    length = value;
                }
            }
            public int Width
            {
                get
                {
                    return width;
                }
                set
                {
                    width = value;
                }
            }

            public bool isLegal()
            {
                if (length > 0 && width > 0)
                    return true;
                else
                    return false;
            }
            public int Area()
            {
                return 0;
            }
            public int Area(int a)
            {
                return 0;
            }
            public int Area(int x,int y,int z)
            {
                return 0;
            }
            public int Area(int length,int width)
            {
                this.length = length;
                this.width = width;
                if (isLegal())
                {
                    var area = length * width;
                    return area;
                }
                else return 0;
            }
            
        }

        class Square : Shape
        {
            int a;
            public int A
            {
                get => a;
                set => a = value;
            }
            public bool isLegal()
            {
                if (a > 0)
                    return true;
                else
                    return false;
            }
            public int Area()
            {
                return 0;
            }
            
            public int Area(int length,int width)
            {
                return 0;
            }
            public int Area(int x, int y, int z)
            {
                return 0;
            }
            public int Area(int a)
            {
                this.a = a;
                if (isLegal())
                {
                    var area = a * a;
                    return area;
                }
                else return 0;
            }
        }

        class Triangle : Shape
        {
            int x, y, z, p;
            public int X
            {
                get => x; set => x = value;
            }
            public int Y
            {
                get => y; set => y = value;
            }
            public int Z
            {
                get => z; set => z = value;
            }
            public int P
            {
                get => p; set => p = (x + y + z) / 2;
            }
            public bool isLegal()
            {
                if (x + y > z && x + z > y && y + z > x && x > 0 && y > 0 && z > 0)
                    return true;
                else return false;
            }
            public int Area()
            {
                return 0;
            }
            public int Area(int a)
            {
                return 0;
            }
            public int Area(int length,int width)
            {
                return 0;
            }
            public int Area(int x,int y,int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
                if (isLegal())
                    return p * (p - x) * (p - y) * (p - z);
                else return 0;
            }
        }

        public class ShapeFactory
        {

            public static int creatShape(string shape)
            {
                int s = 0;
                Shape sh = null;
                switch (shape)
                {
                    case "Rectangle":
                        sh = new Rectangle();
                        int length = int.Parse(Console.ReadLine());
                        int width = int.Parse(Console.ReadLine());
                        s = sh.Area(length, width);
                        break;
                    case "Square":
                        sh = new Square();
                        int a = int.Parse(Console.ReadLine());
                        s = sh.Area(a);
                        break;
                    case "Triangle":
                        sh = new Triangle();
                        int x = int.Parse(Console.ReadLine());
                        int y = int.Parse(Console.ReadLine());
                        int z = int.Parse(Console.ReadLine());
                        s = sh.Area(x,y,z);
                        break;
                }
                return s;
            }
        }
        static void Main(string[] args)
        {
            int[] a = new int[10];
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("第{0}个图形为",i);
                String shape = Console.ReadLine();
                a[i - 1] = ShapeFactory.creatShape(shape);
            }
            int sum = 0;
            for (int j = 0; j < 10; j++)
            {
                sum += a[j];
            }
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
