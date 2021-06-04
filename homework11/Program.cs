using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace homework11
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService service = new OrderService();
            //购物1
            Dictionary<Commodity, int> customer_1 = new Dictionary<Commodity, int>()
            { { OrderService.banana, 2 }, { OrderService.apple, 8 } };
            service.AddOrder("Dave", customer_1);
            //购物2
            Dictionary<Commodity, int> customer_2 = new Dictionary<Commodity, int>()
            { { OrderService.apple, 4 }, { OrderService.bird, 1 }, { OrderService.bottle, 8 } };
            service.AddOrder("Aaron", customer_2);
            

            //根据订单号查询
            Console.WriteLine("根据订单号0查询：");
            service.Display(service.FindByID(1));

            //根据客户名查询
            Console.WriteLine("根据客户名Dave查询：");
            service.Display(service.FindByCustomer("Dave"));

            //根据订单金额查询
            Console.WriteLine("根据订单金额180查询：");
            service.Display(service.FindByCost(180));

            //修改订单客户名
            service.ModifyOrder(1, "Aaron");

            //删除订单
            service.DeleteOrder(1);
        }
    }
}
