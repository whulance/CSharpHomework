using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text.RegularExpressions;



namespace week7_homework_1
{
    [Serializable]
    public class Orderdetails
    {
        public string ProductName { set; get; }
        public int ProductNum { set; get; }
        public double ProductPrice { set; get; }

        public Orderdetails()
        {
            this.ProductName = "";
            this.ProductNum = 0;
            this.ProductPrice = 0;
        }

        public Orderdetails(string ProductName, int ProductNum, double ProductPrice)
        {
            this.ProductName = ProductName;
            this.ProductNum = ProductNum;
            this.ProductPrice = ProductPrice;
        }

        public double productSum()
        {
            double sum = this.ProductPrice * this.ProductNum;
            return sum;
        }
        public void PrintOrderdetails()
        {
            Console.WriteLine("商品名：" + ProductName);
            Console.WriteLine("商品数量" + ProductNum);
            Console.WriteLine("商品价格" + ProductPrice);
            Console.WriteLine(ProductName + "商品总价" + Convert.ToDouble(this.productSum()));
        }
    }

    public class Order
    {
        public List<Orderdetails> orderdetailsList = new List<Orderdetails>();
        public string OrderID { get; set; }
        public string Customer{ get; set; }
        public string Customerphone { get; set; }
        public Order()
        {
            this.OrderID = "";
            this.Customer = "";
            this.Customerphone = "";
        }
        public double orderSum()
        {
            double sum = 0;
            foreach (Orderdetails o in orderdetailsList)
                sum += o.productSum();
            return sum;
        }
        public void PrintOrder()
        {
            Console.WriteLine("订单号:" + OrderID);
            Console.WriteLine("客户:" + Customer);
            Console.WriteLine("客户电话" + Customerphone);
            foreach (Orderdetails i in orderdetailsList)
                i.PrintOrderdetails();
            Console.WriteLine("订单总价：" + orderSum());
        }

    }

    public class OrderException : Exception
    {
        public OrderException(string message) : base(message) { }
    }
    public class OrderService
    {
        public List<Order> orderList = new List<Order>();
        public void PrintOrderList(List<Order> ol)
        {
            foreach (Order i in orderList)
                i.PrintOrder();
        }
        Order checkOrderIDUnique(string neworderID)
        {
            foreach (Order order in orderList)
            {
                if (order.OrderID == neworderID)
                    return order;
                //throw new OrderException("错误！订单号已存在,不可添加，若需要可以进行修改或者换一个订单号");
            }
            return null;
        }

        public bool checkOrderNum(Order order)
        {
            if (order.OrderID.Length == 11)
            {
                Regex rx = new Regex("[1-2][0-9]{3}(((0[13578]|1[02])(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)(0[1-9]|[12][0-9]|30))|(02(0[1-9]|[1][0-9]|2[0-8])))[0-9]{3}");
                bool ok = rx.IsMatch(order.OrderID);
                return ok;
            }
            else
                return false;
        }

        public bool checkOrderPhone(Order order)
        {
            if (order.Customerphone.Length == 11)
            {
                Regex regex = new Regex("1[0-9]{10}");
                bool ok1 = regex.IsMatch(order.Customerphone);
                return ok1;
            }
            else
                return false;
        }

        public void addOrder(Order norder)
        {
            try
            {
                Order n = checkOrderIDUnique(norder.OrderID);
                if (n != null)
                    throw new OrderException("错误！订单号已存在,不可添加，若需要可以进行修改或者换一个订单");
                if (checkOrderNum(norder) == false)
                    throw new OrderException("错误！输入的订单号不符合规则！");
                if (checkOrderPhone(norder) == false)
                    throw new OrderException("错误！输入的顾客电话不符合规则！");
                orderList.Add(norder);
                Console.WriteLine("增加订单后订单打印如下：");
                PrintOrderList(orderList);
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void deleteOrder(string deleteorderID)
        {
            try
            {
                Order n = checkOrderIDUnique(deleteorderID);
                if (n == null)
                    throw new OrderException("错误！订单号不存在,不可删除，请更换订单号");
                orderList.Remove(n);

                Console.WriteLine("删除后订单打印如下：");
                PrintOrderList(orderList);
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
                        Console.WriteLine("请输入订单号：");
                        string s = Console.ReadLine();
                        SearchByOrderID(s);
                        break;
                    case 2:
                        Console.WriteLine("请输入客户名称：");
                        string customer = Console.ReadLine();
                        SearchByCustomer(customer);
                        break;
                    case 3:
                        Console.WriteLine("请输入商品名称：");
                        string product = Console.ReadLine();
                        SearchByProduct(product);
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

        public Order SearchByOrderID(string s)
        {
            
            Console.WriteLine("查询结果如下：");
            try
            {
                Order o = checkOrderIDUnique(s);
                if (o == null)
                    throw new Exception("错误！没有该订单号订单！");
                o.PrintOrder();
                return o;
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void SearchByCustomer(string customer)
        {
            bool n = false;
            Console.WriteLine("查询结果如下：");
            try
            {
                var searchorders = from orders in orderList where orders.Customer == customer select orders;
                foreach (var i in searchorders)
                {
                    i.PrintOrder();
                }
                if (!n)
                    throw new OrderException("错误！找不到该客户的订单");
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SearchByProduct(string product)
        {
            bool n = false;
            Console.WriteLine("查询结果如下：");
            try
            {
                for (int m = 0; m < orderList.Count; m++)
                {
                    var orders = from i in orderList[m].orderdetailsList where i.ProductName == product select orderList[m];
                    orderList[m].PrintOrder();
                    n = (orders != null);
                }
                if (!n)
                    throw new OrderException("错误！找不到存在该商品的订单");
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void searchPrice()
        {
            Console.WriteLine("请输出订单总金额超过一万的订单：");

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
                Console.WriteLine("请输入新的客户电话：");
                m.Customerphone = Console.ReadLine();
                if (checkOrderNum(m) == false)
                    throw new OrderException("错误！输入的订单号不符合规则！");
                if(checkOrderPhone(m)==false)
                    throw new OrderException("错误！输入的订单号不符合规则！");
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

        public void searchover(List<Order> orderList)
        {
            var search = from i in orderList where i.orderSum() >= 10000 select i;
            foreach (Order n in search)
                n.PrintOrder();
        }

        public void export()
        {
            XmlSerializer showxml = new XmlSerializer(typeof(List<Order>));
            String xmlFileName = "show.xml";
            XmlSerialize(showxml, xmlFileName, orderList);
        }

        public void import()
        {
            FileStream fs = new FileStream("show.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            List<Order> orderl = (List<Order>)xs.Deserialize(fs);
            PrintOrderList(orderl);
        }

        public static void XmlSerialize(XmlSerializer ser, string fileName, object obj)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            ser.Serialize(fs, obj);
            fs.Close();
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
            Console.WriteLine("6.打印出订单总金额高于或等于1万元的订单");
            Console.WriteLine("7.退出");
            Console.WriteLine("8.序列化");
            try
            {
                bool exit = false;
                while (exit == false)
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Order neworder = new Order();
                            List<Orderdetails> orderdetailsList = new List<Orderdetails>();
                            Console.WriteLine("请输入订单号:");
                            neworder.OrderID = Console.ReadLine();
                            Console.WriteLine("请输入客户名称:");
                            neworder.Customer = Console.ReadLine();
                            Console.WriteLine("请输入客户电话:");
                            neworder.Customerphone = Console.ReadLine();
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
                                Double productprice = Convert.ToDouble(Console.ReadLine());
                                Orderdetails productorderdetails = new Orderdetails(productname, productnum, productprice);
                                orderdetailsList.Add(productorderdetails);
                            }
                            neworder.orderdetailsList = orderdetailsList;
                            orderService.addOrder(neworder);
                            break;
                        case 2:
                            Console.WriteLine("请输入订单号：");
                            string deleteorderID = Console.ReadLine();
                            orderService.deleteOrder(deleteorderID);
                            break;
                        case 3:
                            orderService.search();
                            break;
                        case 4:
                            orderService.search();
                            break;
                        case 5:
                            orderService.PrintOrderList(orderService.orderList);
                            break;
                        case 6:
                            orderService.searchover(orderService.orderList);
                            break;
                        case 7:
                            exit = true;
                            break;
                        case 8:
                            orderService.export();
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



