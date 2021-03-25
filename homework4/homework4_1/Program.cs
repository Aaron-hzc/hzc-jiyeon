using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4_1
{
    class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
        public static void Each(GenericList<T> nodes, Action<T> f)
        {
            Node<T> node = nodes.Head;
            while (node != null)
            {
                f(node.Data);
                node = node.Next;
            }
        }
    }

    class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
                head = tail = n;
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> nodes = new GenericList<int>();
            Random r = new Random();
            for(int i = 0; i < 10; i++)
            {
                nodes.Add(r.Next(0, 100));
            }

            int sum = 0, max = -1, min = 101;
            Console.WriteLine("链表元素为：");
                Node<int>.Each(nodes, m => Console.Write(m + " "));
            Console.WriteLine();
            Node<int>.Each(nodes, m => sum += m);
            Console.WriteLine($"和为：{sum}");
            Node<int>.Each(nodes, m => min = Math.Min(min, m));
            Console.WriteLine($"最小值为：{min}");
            Node<int>.Each(nodes, m => max = Math.Max(max, m));
            Console.WriteLine($"最大值为：{max}");
            Console.ReadLine();
        }
    }
}
