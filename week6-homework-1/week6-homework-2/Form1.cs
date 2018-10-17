using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week6_homework_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }

        private Graphics graphics;
        double th1 = 1 * Math.PI / 180;
        double th2 = 1 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        double angle1;
        double angle2;
        string select="Blue";
        string size = "";
        int i;
        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * Math.Cos(th);
            double y2 = y0 + leng * Math.Sin(th);
            int k = 1;
           

            if (i != 0)
                drawLine(x0, y0, x1, y1);
            i = 1;

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + angle1 * th1);
            drawCayleyTree(n - 1, x2, y2, per2 * k * leng, th - angle2 * th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            
            switch (select)
            {
                case "Blue":
                    Pen pen = new Pen(Color.Blue, Convert.ToInt32(size));
                    graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Black":
                    Pen pen1 = new Pen(Color.Black, Convert.ToInt32(size));
                    graphics.DrawLine(pen1, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Yellow":
                    Pen pen2 = new Pen(Color.Yellow, Convert.ToInt32(size));
                    graphics.DrawLine(pen2, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Green":
                    Pen pen3 = new Pen(Color.Green, Convert.ToInt32(size));
                    graphics.DrawLine(pen3, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Brown":
                    Pen pen4 = new Pen(Color.Blue, Convert.ToInt32(size));
                    graphics.DrawLine(pen4, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
            }
            
            
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            angle1 = double.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            angle2 = double.Parse(textBox1.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            per1 = double.Parse(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            per2 = double.Parse(textBox4.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            size = textBox6.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            select = comboBox1.Text;
        }

        
    }
}
