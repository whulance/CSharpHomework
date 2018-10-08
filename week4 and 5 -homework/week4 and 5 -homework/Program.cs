using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4_and_5__homework
{
    public class Orderdetails
    {
        public string ProductName;
        public int ProductNum;
        public double ProductPrice;
        public Orderdetails(string ProductName, int ProductNum, double ProductPrice)
        {
            this.ProductName = ProductName;
            this.ProductNum = ProductNum;
            this.ProductPrice = ProductPrice;
        }
        public void PrintOrderdetails()
        {
            Console.WriteLine("商品名：" + ProductName);
            Console.WriteLine("商品数量:" + ProductNum);
            Console.WriteLine("商品价格:" + ProductPrice);
        }
    }

    public class Order
    {
        public List<Orderdetails> orderdetailsList = new List<Orderdetails>();
        public string OrderID;
        public string Customer;
        public void PrintOrder()
        {
            Console.WriteLine("订单号:" + OrderID);
            Console.WriteLine("客户:" + Customer);
            foreach (Orderdetails i in orderdetailsList)
                i.PrintOrderdetails();
        }
    }

    public class OrderException : Exception
    {
        public OrderException(string message) : base(message) { }
    }
    class OrderService
    {
        List<Order> orderList = new List<Order>();
        public void PrintOrderList()
        {
            foreach (Order i in orderList)
                i.PrintOrder();
        }
        public Order checkOrderIDUnique(string neworderID)
        {
            foreach (Order order in orderList)
            {
                if (order.OrderID == neworderID)
                    return order;
                //throw new OrderException("错误！订单号已存在,不可添加，若需要可以进行修改或者换一个订单号");
            }
            return null;
        }

        public void addOrder()
        {
            try
            {
                Order neworder = new Order();
                List<Orderdetails> orderdetailsList = new List<Orderdetails>();
                Console.WriteLine("请输入订单号:");
                string neworderID = Console.ReadLine();
                neworder.OrderID = neworderID;
                Order n = checkOrderIDUnique(neworderID);
                if (n != null)
                    throw new OrderException("错误！订单号已存在,不可添加，若需要可以进行修改或者换一个订单号");
                Console.WriteLine("请输入客户名称:");
                neworder.Customer = Console.ReadLine();
                Console.WriteLine("请输入该订单商品种类数目：");
                int m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("请依次输入每一种商品名称，数量，价格。");
                for (int i = 1; i <= m; i++)
                {
                    Console.WriteLine("请输入第" + i + "种商品名称。");
                    string productname = Console.ReadLine();
                    Console.WriteLine("请输入第" + i + "种商品数量。");
                    int productnum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("请输入第" + i + "种商品价格。");
                    int productprice = Convert.ToInt32(Console.ReadLine());
                    Orderdetails productorderdetails = new Orderdetails(productname, productnum, productprice);
                    orderdetailsList.Add(productorderdetails);
                }
                neworder.orderdetailsList = orderdetailsList;
                orderList.Add(neworder);
                Console.WriteLine("增加订单后订单打印如下：");
                PrintOrderList();
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void deleteOrder()
        {
            try
            {
                Console.WriteLine("请输入订单号：");
                string deleteorderID = Console.ReadLine();
                Order n = checkOrderIDUnique(deleteorderID);
                if (n == null)
                    throw new OrderException("错误！订单号不存在,不可删除，请更换订单号");
                orderList.Remove(n);

                Console.WriteLine("删除后订单打印如下：");
                PrintOrderList();
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void search()
        {
            Console.WriteLine("请输入想查询订单的依据(输入所相应代表的数字)：");
            Console.WriteLine("1代表根据订单号查询");
            Console.WriteLine("2代表根据客户查询");
            Console.WriteLine("3代表根据商品查询");
            int choice = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (choice)
                {
                    case 1:
                        SearchByOrderID();
                        break;
                    case 2:
                        SearchByCustomer();
                        break;
                    case 3:
                        SearchByProduct();
                        break;
                    default:
                        throw new Exception("输入数字有误,不符合范围");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SearchByOrderID()
        {
            Console.WriteLine("请输入订单号：");
            string s = Console.ReadLine();
            Console.WriteLine("查询结果如下：");
            try
            {
                Order o = checkOrderIDUnique(s);
                if (o == null)
                    throw new Exception("没有该订单号订单！");
                o.PrintOrder();
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SearchByCustomer()
        {
            bool n = false;
            Console.WriteLine("请输入客户名称：");
            string customer = Console.ReadLine();
            Console.WriteLine("查询结果如下：");
            try
            {
                foreach (Order i in orderList)
                {
                    if (i.Customer == customer)
                    {
                        i.PrintOrder();
                        n = true;
                    }
                }
                if (!n)
                    throw new OrderException("错误！找不到该客户的订单");
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SearchByProduct()
        {
            bool n = false;
            Console.WriteLine("请输入商品名称：");
            string product = Console.ReadLine();
            Console.WriteLine("查询结果如下：");
            try
            {
                for (int m = 0; m < orderList.Count; m++)
                {
                    foreach (Orderdetails i in orderList[m].orderdetailsList)
                        if (i.ProductName == product)
                        {
                            orderList[m].PrintOrder();
                            n = true;
                        }
                }
                if (!n)
                    throw new OrderException("错误！找不到存在该商品的订单");
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void reviseOrder()
        {
            Console.WriteLine("请输入要修改的订单的订单号：");
            string orderID = Console.ReadLine();
            try
            {
                Order m = checkOrderIDUnique(orderID);
                if (m == null)
                    throw new OrderException("错误！不存在该订单号的订单");
                Console.WriteLine("请输入新的订单号：");
                string s = Console.ReadLine();
                Order i = checkOrderIDUnique(s);
                if (i != null)
                    throw new OrderException("错误！已存在该订单号的订单");
                m.OrderID = s;
                Console.WriteLine("请输入新的客户名：");
                m.Customer = Console.ReadLine();
                List<Orderdetails> orderdetailsList = new List<Orderdetails>();
                Console.WriteLine("请输入新的订单商品种类数目：");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("请依次输入每一种商品名称，数量，价格。");
                for (int b = 1; b <= a; b++)
                {
                    Console.WriteLine("请输入第" + b + "种商品名称。");
                    string productname = Console.ReadLine();
                    Console.WriteLine("请输入第" + b + "种商品数量。");
                    int productnum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("请输入第" + b + "种商品价格。");
                    int productprice = Convert.ToInt32(Console.ReadLine());
                    Orderdetails productorderdetails = new Orderdetails(productname, productnum, productprice);
                    orderdetailsList.Add(productorderdetails);
                }
                m.orderdetailsList = orderdetailsList;
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            Console.WriteLine("请选择希望订单进行的操作（只需输入相应操作前面数字即可）：");
            Console.WriteLine("1.添加新订单");
            Console.WriteLine("2.删除订单");
            Console.WriteLine("3.查询订单");
            Console.WriteLine("4.修改订单");
            Console.WriteLine("5.打印订单列表");
            Console.WriteLine("6.退出");
            try
            {
                bool exit = false;
                while (exit == false)
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            orderService.addOrder();
                            break;
                        case 2:
                            orderService.deleteOrder();
                            break;
                        case 3:
                            orderService.search();
                            break;
                        case 4:
                            orderService.search();
                            break;
                        case 5:
                            orderService.PrintOrderList();
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            throw new Exception("错误！没有这个选项");
                    }
                }
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
    
    /**
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
}*/
