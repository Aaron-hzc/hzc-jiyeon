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
using System.Xml.Serialization;

namespace OrderWinform
{
    public partial class Form1 : Form
    {
        private OrderService service;
        public OrderService Service { set => service = value; get => service; }
        public Form1()
        {
            InitializeComponent();
            OrderbindingSource.DataSource = Service.Orders;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (OrderbindingSource.Current == null)
            {
                MessageBox.Show("请先选择要删除的订单！");
                return;
            }
            if (MessageBox.Show("确定要删除该订单吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                service.DeleteOrder(((Order)OrderbindingSource.Current).ID);
            }
            OrderbindingSource.ResetBindings(false);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
                using (System.IO.FileStream fs = (System.IO.FileStream)openFileDialog1.OpenFile())
                {
                    Order[] orders = (Order[])xmlSerializer.Deserialize(fs);
                    Array.ForEach(orders, p => service.Orders.Add(p));
                }
                MessageBox.Show("ImportSuccess");
            }
            OrderbindingSource.ResetBindings(false);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
                using (System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile())
                {
                    xmlSerializer.Serialize(fs, service.Orders.ToArray());
                }
                MessageBox.Show("ExportSuccess");
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (OrderbindingSource.Current == null)
            {
                MessageBox.Show("请先选择要修改的订单！");
                return;
            }
            Dictionary<Commodity, int> myCommodity = ((Order)OrderbindingSource.Current).Orderdetails.commodityNum;
            Form2 modifyForm = new Form2(ref service, true,
                ((Order)OrderbindingSource.Current).ID,
                ((Order)OrderbindingSource.Current).customerName,
                myCommodity[OrderService.apple], myCommodity[OrderService.banana]);
            modifyForm.ShowDialog();
            OrderbindingSource.ResetBindings(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 addForm = new Form2(ref service, false);
            addForm.ShowDialog();
            OrderbindingSource.ResetBindings(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //点击进行查询
        private void button1_Click(object sender, EventArgs e)
        {
            OrderbindingSource.DataSource = Service.Orders.Where(s => s.customerName.Contains(textBox1.Text));
        }
    }
}
