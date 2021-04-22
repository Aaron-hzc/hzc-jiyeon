using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework6_1;

namespace OrderWinform
{
    public partial class Form2 : Form
    {
        private XmlDictionary<Commodity, int> newCommodity;
        private OrderService service;
        private int modifyID;
        public bool Condition { get; set; }
        public Form2(ref OrderService service, bool condition, int id = 0, string customer = "", int num1 = 0, int num2 = 0, int num3 = 0, int num4 = 0)
        {
            InitializeComponent();
            this.service = service;
            this.Condition = condition;
            this.modifyID = id;
            this.customer.Text = customer;
            this.appleNum.Value = num1;
            this.bananaNum.Value = num2;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定提交吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (this.customer.Text == "")
                {
                    MessageBox.Show("请输入customerName");
                    return;
                }
                if ((int)appleNum.Value + (int)bananaNum.Value == 0)
                {
                    MessageBox.Show("请输入有效的商品数量！");
                    return;
                }
                newCommodity = new XmlDictionary<Commodity, int>() { { OrderService.banana, (int)bananaNum.Value }, { OrderService.apple, (int)appleNum.Value }, { OrderService.bird, (int)birdNum.Value }, { OrderService.bottle, (int)bottleNum.Value } };
                if (this.Condition == false)
                {
                    service.AddOrder(customer.Text, newCommodity);
                    this.Close();
                }
                else if (this.Condition == true)
                {
                    service.ChangeOrder();
                    for (int i = 0; i < service.Orders.Count; i++)
                    {
                        if (service.Orders[i].ID == this.modifyID)
                        {
                            service.Orders[i].Orderdetails.CommodityNum = newCommodity;
                            int cost = 0;
                            foreach (var item in newCommodity)
                            {
                                cost += (item.Key.Price * item.Value);
                            }
                            service.Orders[i].Money = cost;
                        }
                    }
                    this.Close();
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (this.Condition == true)
            {
                this.Text = "修改订单";
            }
            else
            {
                this.Text = "添加订单";
            }
        }

    }
}
