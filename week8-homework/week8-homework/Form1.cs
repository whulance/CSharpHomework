using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week7_homework_1;


namespace week8_homework
{
    public partial class Form1 : Form
    {
        public OrderService orderService = new OrderService();
        public Form1()
        {
            InitializeComponent();
            orderService.addOrder(new Order());
            orderService.orderList[0].OrderID = "001";
            orderService.orderList[0].Customer = "Mr.Q";
            orderService.orderList[0].orderdetailsList.Add(new Orderdetails("chips", 10, 5));
           
            dataGridView1.DataSource = new BindingList<Order>(orderService.orderList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addorder addOrderForm = new Addorder();
            addOrderForm.ShowDialog();
            try
            {
                Order o=new Order();
                o.Customer = addOrderForm.Customer;
                o.OrderID = addOrderForm.ID;
                o.orderdetailsList = addOrderForm.orderdetailsList;
                orderService.addOrder(o);
            }
            catch (System.ArgumentNullException) { }
            finally
            {
                dataGridView1.DataSource = new BindingList<Order>(orderService.orderList);
            }
            
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Order order=orderService.SearchByOrderID(label1.Text);
            dataGridView2.DataSource = new BindingList<Orderdetails>(order.orderdetailsList);
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string i = textBox3.Text;
            orderService.deleteOrder(i);
            dataGridView1.DataSource = new BindingList<Order>(orderService.orderList);
        }

       
        private void Search_Click(object sender, EventArgs e)
        {
            List<Order> orderlistt = new List<Order>();
            for (int n = 0; n < this.orderService.orderList.Count; n++)
            {
                if (orderService.orderList[n].OrderID == textBox2.Text)
                {
                    orderlistt.Add(orderService.orderList[n]);
                }
            }
            dataGridView1.DataSource = new BindingList<Order>(orderlistt);
           
        }
        private void button4_Click_2(object sender, EventArgs e)
        {
            List<Order> orderlistt = new List<Order>();
            for (int n = 0; n < this.orderService.orderList.Count; n++)
            {
                if (orderService.orderList[n].Customer == textBox4.Text)
                {
                    orderlistt.Add(orderService.orderList[n]);
                }
            }
            dataGridView1.DataSource = new BindingList<Order>(orderlistt);
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            Order order = orderService.SearchByOrderID(s);
            Reviseorder reviseorder = new Reviseorder(order);
            reviseorder.ShowDialog();
            orderService.deleteOrder(s);
            orderService.addOrder(reviseorder.order1);
        }

       

        
    }
}
