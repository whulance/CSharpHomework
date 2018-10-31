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
    public partial class Addorder : Form
    {
        public string ID;
        public string Customer;
        public List<Orderdetails> orderdetailsList = new List<Orderdetails>();
        

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ID = textBox2.Text;
            Customer = textBox1.Text;
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                
                orderdetailsList.Add(new Orderdetails());
                orderdetailsList[i].ProductName=dataGridView1.Rows[i].Cells[0].Value.ToString();
                orderdetailsList[i].ProductNum = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());
                orderdetailsList[i].ProductPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString());
            }

            Close();
        }


        public Addorder()
        {
            

            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
