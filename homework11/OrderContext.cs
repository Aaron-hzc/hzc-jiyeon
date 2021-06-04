using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace homework11
{
    public class OrderContext:Dbcontext
    {
        public OrderContext() : base("OrderDataBase")
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<OrderContext>());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderService> OrderDetails { get; set; }
        public DbSet<Commodity> Commodity { get; set; }
    }
}
