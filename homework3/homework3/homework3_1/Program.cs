using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3_1
{
    //第一题中的代码无Main函数，并且可直接用于第二题
    interface Shape
    {
        int Area();
        bool isLegal();
    }
    class Rectangle:Shape
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
            if (isLegal())
            {
                var area = length * width;
                return area;
            }
            else return 0;
        }
    }

    class Square:Shape
    {
        int  a;
        public int A
        {
            get => a;
            set => a = value;
        }
        public bool isLegal()
        {
            if ( a > 0)
                return true;
            else
                return false;
        }

        public int Area()
        {
            if (isLegal())
            {
                var area = a * a;
                return area;
            }
            else return 0;
        }
    }

    class Triangle:Shape
    {
        int x, y, z, p;
        public int X
        {
            get => x;set => x = value;
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
            get => p;set => p = (x + y + z) / 2;
        }
        public bool isLegal()
        {
            if (x + y > z && x + z > y && y + z > x && x > 0 && y > 0 && z > 0)
                return true;
            else return false;
        }
        public int Area()
        {
            if (isLegal())
                return p * (p - x) * (p - y) * (p - z);
            else return 0;
        }
    }
}
