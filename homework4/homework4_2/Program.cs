using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4_2
{
    public class AlarmEventArgs
    {
        public static string Time { get; set; }
    }

    public delegate void AlarmEventHandler(object sender, AlarmEventArgs e);

    public class AlarmClock
    {
        public event AlarmEventHandler onAlarm;
        public void alarm(String time)
        {
            AlarmEventArgs args = new AlarmEventArgs();
            AlarmEventArgs.Time = time;
            while (true) onAlarm(this, args);
        }
    }
    public class Form
    {
        public AlarmClock clock = new AlarmClock();
        public Form()
        {
            clock.onAlarm += Tick;
            clock.onAlarm += Alarm;
        }

        public void Tick(object sender, AlarmEventArgs args)
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("滴答");
        }
        public void Alarm(object sender, AlarmEventArgs args)
        {
            if (AlarmEventArgs.Time == DateTime.Now.ToLongTimeString().ToString())
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine($"{AlarmEventArgs.Time}!时间到了!");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string time = "10:43:00";
            Form form = new Form();
            form.clock.alarm(time);
        }
    }
}
