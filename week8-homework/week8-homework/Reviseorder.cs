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
using week8_homework;



namespace week8_homework
{
    public partial class Reviseorder : Form
    {
        public Order order1 = new Order();
        
        

        public Reviseorder(Order order)
        {
            
            InitializeComponent();
            order1 = order;
            dataGridView1.DataSource = new BindingList<Orderdetails>(order1.orderdetailsList);
            //textBox1.DataBindings.Add("Text", order.OrderID, "value", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            order1.OrderID = textBox1.Text;
            order1.Customer = textBox2.Text;
            Close();
        }
    }
}
