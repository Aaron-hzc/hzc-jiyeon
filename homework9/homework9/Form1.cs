using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework9
{
    public partial class Form1 : Form
    {
        public newCrawler myCrawler;
        public Thread thread;
        bool crawl;
        public Form1()
        {
            InitializeComponent();
            myCrawler = new newCrawler();
            crawl = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            crawl = true;
            thread = new Thread(myCrawler.Crawl);
            thread.Start(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "暂停爬取")
            {
                crawl = false;
                thread.Suspend();
                button2.Text = "继续爬取";
            }
            else if(button2.Text=="继续爬取")
            {
                crawl = true;
                thread.Resume();
                button2.Text = "暂停爬取";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            thread.Abort();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            richTextBox1.Text = myCrawler.Infor;
        }
    }
}
