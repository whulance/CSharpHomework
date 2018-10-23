using Microsoft.VisualStudio.TestTools.UnitTesting;
using week7_homework_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week7_homework_1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void addOrderTest()
        {
            Order o = new Order();
            o.OrderID = "001"; o.Customer = "laa";
            OrderService orderService = new OrderService();
            orderService.addOrder(o);
            Assert.IsTrue(orderService.orderList.Contains(o));
            Order oo = new Order();
            oo.OrderID = "001"; o.Customer = "laa";
            try
            {
                orderService.addOrder(oo);
            }
            catch (Exception e)
            {
                Assert.Equals(e.Message, "错误！订单号已存在,不可添加，若需要可以进行修改或者换一个订单号");
            }
        }

        [TestMethod()]
        public void deleteOrderTest()
        {
            Order o = new Order();
            o.OrderID = "001"; o.Customer = "laa";
            OrderService orderService = new OrderService();
            orderService.addOrder(o);
            orderService.deleteOrder(o.OrderID);
            Assert.IsFalse(orderService.orderList.Contains(o));
            try
            {
                orderService.deleteOrder(o.OrderID);
            }
            catch (Exception e)
            {
                Assert.Equals(e.Message, "错误！订单号不存在,不可删除，请更换订单号");
            }
        }

        [TestMethod()]
        public void SearchByOrderIDTest()
        {
            OrderService orderService = new OrderService();
            Order o = new Order();
            o.OrderID = "001";
            orderService.orderList.Add(o);
            orderService.SearchByOrderID("001");
            try
            {
                orderService.SearchByOrderID("002");
            }
            catch (Exception e)
            {
                StringAssert.Equals(e.Message, "错误！没有该订单号订单！");
            }
        }

        [TestMethod()]
        public void SearchByCustomerTest()
        {
            OrderService orderService = new OrderService();
            Order o = new Order();
            o.Customer = "lll";
            orderService.orderList.Add(o);
            orderService.SearchByCustomer("lll");
            try
            {
                orderService.SearchByCustomer("2");
            }
            catch (Exception e)
            {
                StringAssert.Equals(e.Message, "错误！找不到该客户的订单");
            }
        }

        [TestMethod()]
        public void SearchByProductTest()
        {
           
            OrderService orderService = new OrderService();
            Order o = new Order();
            o.Customer = "111";
            o.OrderID = "001";
            Orderdetails a = new Orderdetails();
            a.ProductName = "可乐";
            o.orderdetailsList.Add(a);
            orderService.orderList.Add(o);
            orderService.SearchByProduct("可乐");
            try
            {
                orderService.SearchByProduct("雪碧");
            }
            catch (Exception e)
            {
                StringAssert.Equals(e.Message, "错误！找不到存在该商品的订单");
            }
        }

        

        
    }
}