using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics graphics;

        Dictionary<int, Pen> pairs = new Dictionary<int, Pen>()
        {
            {0,Pens.Pink },{ 1,Pens.Blue } ,{ 2,Pens.Black },{ 3,Pens.Green },{4,Pens.Red }
        };

        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {

            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);

        }

        private void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(pairs[listBox1.SelectedIndex], (int)x0, (int)y0, (int)x1, (int)y1);
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            per1 = (double)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            per2 = (double)numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            th1 = ((int)numericUpDown3.Value) * Math.PI / 180;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            th2 = ((int)numericUpDown4.Value) * Math.PI / 180;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = panel2.CreateGraphics();
            graphics.Clear(BackColor);
            drawCayleyTree((int)numericUpDown5.Value, 200, 310, (double)numericUpDown6.Value, -Math.PI / 2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
