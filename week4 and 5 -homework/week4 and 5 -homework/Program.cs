using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4_and_5__homework
{
    
    //声明所需参数类型
    public class ClockEventArgs : EventArgs
    {
        public int SetHour;//所设定时间的小时
        public int SetMinute;//所设定时间的分钟
        public int CurrentHour; //当今时间的小时
        public int CurrentMinute;//当今时间的分钟
        public bool TimeCheck;//比较时间是否符合
    }

    //声明委托类型
    public delegate void ClockCheck(object sender, ClockEventArgs e);

    //定义事件源
    public class Clock
    {
        //声明事件
        public event ClockCheck WhetherClockRing;

        public void Check(int Sethour, int Setminute)
        {
            ClockEventArgs args = new ClockEventArgs();
            args.TimeCheck = false;
            args.SetHour = Sethour;
            args.SetMinute = Setminute;
            while (1 != 0)
            {
                args.CurrentHour = Convert.ToInt32(DateTime.Now.Hour.ToString());
                args.CurrentMinute = Convert.ToInt32(DateTime.Now.Minute.ToString());
                WhetherClockRing(this, args);
                if (args.TimeCheck == true)
                    break;
                System.Threading.Thread.Sleep(1000);
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var clock = new Clock();
            //注册事件源
            clock.WhetherClockRing += CheckClock;
            int sethour, setminute;
            Console.WriteLine("请输入闹钟的小时：");
            sethour = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入闹钟的分钟：");
            setminute = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("已成功设定闹钟" + sethour + "时" + setminute + "分");
            clock.Check(sethour, setminute);
        }

        static void CheckClock(object sender,  ClockEventArgs e)//比较时间
        {
            if (e.SetHour == e.CurrentHour && e.SetMinute == e.CurrentMinute)
            {
                e.TimeCheck = true;
                Console.WriteLine("闹钟响了！！！");
            }
        }
    }
}
