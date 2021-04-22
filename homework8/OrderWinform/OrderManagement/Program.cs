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
        public int ID { get; set; }
        public string customerName { get; set; }
        public int Money { get; set; }

        public OrderDetails[] Orderdetails;
        public override string ToString()
        {
            return "ID:" + ID + "\n" + "Customer's name:" + customerName + "\n" + "Money:" + Money + "\n" + "OrderDetails:" + Orderdetails;
        }
        public Order() { }
        public Order(int id, string customername, int money, params OrderDetails[] orderdetails)
        {
            ID = id;
            customerName = customername;
            Money = money;
            Orderdetails = orderdetails;
        }
        public Order(int id, string commodityname, int commodityNum, string customername, int money)
        {
            ID = id;
            Money = money;
            customerName = customername;
            Orderdetails = new[] { new OrderDetails(commodityname, commodityNum) };
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
            return this.ID == a.ID &&
                   this.customerName == a.customerName &&
                   this.Money == a.Money &&
                   this.Orderdetails == a.Orderdetails;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(ID) + Convert.ToInt32(customerName) + Convert.ToInt32(Money) + Convert.ToInt32(Orderdetails);
        }
    }
    public class OrderDetails
    {
        public string CommodityName { get; set; }
        public int CommodityNum { get; set; }
        public OrderDetails() { }
        public OrderDetails(string commodityName, int commodityNum)
        {
            CommodityName = commodityName;
            CommodityNum = commodityNum;
        }
        public override string ToString()
        {
            return "CommodityName:" + CommodityName + "\n" + "CommodityNum:" + CommodityNum;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is OrderDetails)) throw new SystemException();
            OrderDetails orderdetails = obj as OrderDetails;
            return this.CommodityName == orderdetails.CommodityName && this.CommodityNum == orderdetails.CommodityNum;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(CommodityName) + Convert.ToInt32(CommodityNum);
        }
    }
    public class OrderService
    {
        //订单List
        public List<Order> Orders = new List<Order>();
        //商品列表
        public static Commodity banana = new Commodity("banana", 10);
        public static Commodity apple = new Commodity("apple", 20);

        //添加订单
        public bool AddOrder(Order order)
        {
            if (order == null || order.Orderdetails == null)
            {
                throw new OrderException("添加参数不能为空");
            }
            if (Orders.Where(o => o.ID == order.ID).Any())
            {
                return false;
            }
            Orders.Add(order);
            return true;
        }
        //修改订单
        public void ChangeOrder(Order order)
        {
            if (order == null)
                throw new OrderException("修改参数不能为空！");
            var changedOrder = Orders.Where(o => o.ID == order.ID).FirstOrDefault();
            if (changedOrder == null)
                throw new OrderException("被修改订单不存在");
            else
            {
                if (order.customerName != null && order.Orderdetails != null && order.Money > 0)
                {
                    changedOrder.customerName = order.customerName;
                    changedOrder.Orderdetails = order.Orderdetails;
                    changedOrder.Money = order.Money;
                }
            }
        }
        //删除订单
        public void DeleteOrder(int ID)
        {
            var deletedOrder = Orders.Where(o => o.ID == ID).FirstOrDefault();
            if (deletedOrder == null)
                throw new OrderException("该订单不存在");
            Orders.Remove(deletedOrder);
        }

        //通过ID查询Order
        public List<Order> IDFind(int ID)
        {
            var query = Orders
                .Where(s => s.ID == ID)
                .OrderBy(s => s.Money);
            return query.ToList<Order>();
        }
        //通过customerName查询Order
        public List<Order> NameFind(string name)
        {
            var query = Orders
                .Where(s => s.customerName == name)
                .OrderBy(s => s.Money);
            return query.ToList<Order>();
        }
        //排序
        public void OrderSort(int ID)
        {

            Orders.Where(o => o.ID == ID).FirstOrDefault();
        }
        public void SortOrder(Comparison<Order> t)
        {
            Orders.Sort(t);
        }
        public void Export(string fileName)
        {
            
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
                Order[] temp = Orders.ToArray();
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, temp);
                }
           
        }
        public void Import(string fileName)
        {
                if (!File.Exists(fileName))
                    throw new InvalidOperationException("文件不存在");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
                Order[] temp = Orders.ToArray();
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    temp = (Order[])xmlSerializer.Deserialize(fs);
                }
                this.Orders = temp.ToList();
           
        }
    }
    public class OrderException : Exception
    {
        public OrderException(string message) : base(message) { }
    }
    public class Customer
    {
        public string CustomerName { get; set; }

        public string[] CommodityBuy;
        public override string ToString()
        {
            string str = "";
            foreach (String commodity in CommodityBuy)
            {
                str += commodity + " ";
            }
            return "CustomerName:" + CustomerName + "\n" + "Buy commodity:" + str;
        }
    }
    public class Commodity
    {
        public string CommodityName { get; set; }
        public int UnitPrice { get; set; }

        public Commodity(string commodityName, int unitPrice)
        {
            CommodityName = commodityName;
            UnitPrice = unitPrice;
        }
        public override string ToString()
        {
            return "CommodityName:" + CommodityName + "\n" + "UnitPrice:" + UnitPrice;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();

            orderService.AddOrder(new Order(0, "apple", 1, "Aaron", 5));
            orderService.AddOrder(new Order(1, "banana", 5, "Aaron", 10));
            orderService.AddOrder(new Order(2, "Aaron", 50, new OrderDetails("apple", 6),
                                                           new OrderDetails("banana", 5)
            ));
            orderService.ChangeOrder(new Order(0, "apple", 2, "Aaron", 10));
            orderService.DeleteOrder(1);
            orderService.IDFind(2);
            orderService.NameFind("Aaron");
        }
    }
}
