using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("*");
            comboBox1.Items.Add("/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = textBoxn1.Text;
            string str2 = textBoxn2.Text;

            double n1 = Convert.ToInt32(str1);
            double n2 = Convert.ToInt32(str2);
            double n3 = 0;

            switch (comboBox1.Text)
            {
                case "+":
                    n3 = n1 + n2;
                    break;
                case "-":
                    n3 = n1 - n2;
                    break;
                case "*":
                    n3 = n1 * n2;
                    break;
                case "/":
                    n3 = n1 / n2;
                    break;
                default:
                    break;
            }
            string str3 = Convert.ToString(n3);
            textBoxresult.Text = str3;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("*");
            comboBox1.Items.Add("/");
        }

 
    }
}
