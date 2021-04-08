using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace homework6_1
{
    public class Order : IComparable
    {
        public String ID { get; set; }
        public Customer customer { get; set; }
        public String Time { get; set; }
        public double Money { get; set; }

        public List<OrderDetails> orderdetails = new List<OrderDetails>();
        public Order() { }
        public Order(string cus, List<OrderDetails> orderDetails)
        {
            this.customer.Name = cus;
            this.orderdetails = orderDetails;

        }
        public override string ToString()
        {
            return "ID:" + ID + "\n" + "Time:" + Time + "\n" + "Customer:" + customer + "\n" + "Money:" + Money;
        }
        public int CompareTo(Object obj)
        {
            if (!(obj is Order)) throw new SystemException();
            Order a = obj as Order;
            return this.ID.CompareTo(a.ID);
        }
        public override bool Equals(object obj)
        {
            Order a = obj as Order;
            return this.ID == a.ID;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(ID);
        }
    }
    public class OrderDetails
    {
        public Dictionary<Commodity, int> CommodityNum { get; set; }
        public OrderDetails(Dictionary<Commodity, int> n)
        {
            CommodityNum = n;
        }

        private string name;
        private int amount;
        private double price;
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }


        public OrderDetails(String name, int amount, double price)
        {
            Name = name;
            Amount = amount;
            Price = price;
        }
        public override string ToString()
        {
            return "Name:" + Name + "\n" + "Amount:" + Amount + "\n" + "Commodity:" + CommodityNum + "\n" + "Price:" + Price;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is OrderDetails)) throw new SystemException();
            OrderDetails orderdetails = obj as OrderDetails;
            return this.name == orderdetails.name && this.price == orderdetails.price && this.amount == orderdetails.amount && this.CommodityNum == orderdetails.CommodityNum;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(Name) + Convert.ToInt32(Amount) + Convert.ToInt32(CommodityNum) + Convert.ToInt32(Price);
        }

    }
    public class OrderService
    {
        private static int orderNum = 0;
        //商品列表
        public static Commodity banana = new Commodity("banana", 10);
        public static Commodity apple = new Commodity("apple", 15);

        //订单List
        public List<Order> Orders = new List<Order>();

        //添加订单
        public bool AddOrder(string customer, Dictionary<Commodity, int> commodityBuy)
        {
            int paymoney = 0;
            foreach (var item in commodityBuy)
            {
                paymoney += (item.Key.Price * item.Value);
            }
            Order newOrder = new Order();
            //判断订单内是否有相同项
            foreach (var item in Orders)
            {
                if (newOrder.Equals(item)) return false;
            }
            Orders.Add(new Order());
            orderNum++;
            Console.WriteLine("添加订单成功");
            return true;
        }
        //修改订单
        public void ChangeOrder(string ID, string newname)
        {
            if (ID == null || ID.Length >= Orders.Count)
                throw new OrderException("该订单不存在");
            Orders[int.Parse(ID)].customer.Name = newname;
        }
        //删除订单
        public void DeleteOrder(string ID)
        {
            if (ID == null || ID.Length >= Orders.Count)
                throw new OrderException("该订单不存在");
            Orders.RemoveAt(int.Parse(ID));
        }

        //通过ID查询Order
        public List<Order> IDFind(string ID)
        {
            var query = Orders
                .Where(s => s.ID == ID)
                .OrderBy(s => s.Money);
            return query.ToList<Order>();
        }
        //通过name查询Order
        public List<Order> NameFind(string name)
        {
            var query = Orders
                .Where(s => s.customer.Name == name)
                .OrderBy(s => s.Money);
            return query.ToList<Order>();
        }
        //排序
        public void OrderSort()
        {
            Orders.Sort();
        }
        public void SortOrder(Comparison<Order> t)
        {
            Orders.Sort(t);
        }
        public void Export()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
                Order[] temp = Orders.ToArray();
                using (FileStream fs = new FileStream("s.xml", FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, temp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Import()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
                Order[] temp = Orders.ToArray();
                using (FileStream fs = new FileStream("Orders.xml", FileMode.Open))
                {
                    temp = (Order[])xmlSerializer.Deserialize(fs);
                }
                this.Orders = temp.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("该文件不存在！");
                Console.WriteLine(e.Message);
            }
        }
    }
    public class OrderException : Exception
    {
        public OrderException(string message) : base(message) { }
    }
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<String> commodityBuy = new List<string>();
        public override string ToString()
        {
            string str = "";
            foreach (String commodity in commodityBuy)
            {
                str += commodity + " ";
            }
            return "Name:" + Name + "\n" + "Buy commodity:" + str;
        }
    }
    public class Commodity
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Commodity(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return "Commodity:" + Name + "\n" + "Price:" + Price;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderservice = new OrderService();
            //购物一次
            Dictionary<Commodity, int> customer1 = new Dictionary<Commodity, int>()
            {
                {OrderService.banana,7 },
                {OrderService.apple,14 }
            };
            orderservice.AddOrder("Aaron", customer1);
            //通过订单号查询订单
            Console.WriteLine("根据订单号查询到：");
            orderservice.IDFind("0");
            //通过姓名查询
            Console.WriteLine("根据姓名查询结果：");
            orderservice.NameFind("Aaron");
            //修改姓名
            try
            {
                Console.WriteLine("修改姓名为：");
                orderservice.ChangeOrder("0", "Bob");
            }
            catch (OrderException e)
            {
                Console.WriteLine("修改订单失败" + e.Message);
            }
            //删除订单
            try
            {
                Console.WriteLine("删除订单");
                orderservice.DeleteOrder("0");
            }
            catch (OrderException e)
            {
                Console.WriteLine("删除订单失败" + e.Message);
            }
            //排序订单
            //再购一次物
            Dictionary<Commodity, int> customer2 = new Dictionary<Commodity, int>()
            {
                {OrderService.banana,2 },
                {OrderService.apple,2 }
            };
            Console.WriteLine("排序结果如下：");
            orderservice.OrderSort();

        }
    }
}
