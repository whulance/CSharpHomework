using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3_homework
{
    public interface Shape
    {
        void area();
    }

    public class Circle : Shape
    {
        double radius;
        public Circle(double r)
        {
            Console.WriteLine("工厂已生成圆形");
            this.radius = r;
        }
        public void area()
        {
            double s = Math.PI * radius * radius;
            Console.WriteLine("该圆形面积是： "+s);
        }
    }

    public class Rectangle : Shape
    {
        double length;
        double width;
        public Rectangle(double length,double width)
        {
            Console.WriteLine("工厂已生成长方形");
            this.length = length;
            this.width = width;
        }
        public void area()
        {
            double s = length * width;
            Console.WriteLine("该长方形面积是：  " + s);
        }
    }

    public class Triangle : Shape
    {
        double line1;
        double line2;
        double angle;
        public Triangle(double line1,double line2,double angle)
        {
            Console.WriteLine("工厂已生成三角形");
            this.line1 = line1;
            this.line2 = line2;
            this.angle = angle;
        }
        public void area()
        {
            double s = line1 * line2 * (Math.Sin(angle));
            Console.WriteLine("该三角形面积是：  " + s);
        }
    }


    public class ShapeFactory
    {
        public static Shape produceShape(int i)
        {
            Shape shape = null;
            if (i == 1)
            {
                Console.WriteLine("请输入要生成圆形的半径");
                double radius = Convert.ToDouble(Console.ReadLine());
                shape = new Circle(radius);
            }
            else if (i == 2)
            {
                Console.WriteLine("请输入要生成长方形的长");
                double length = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入要生成长方形的宽");
                double width = Convert.ToDouble(Console.ReadLine());
                shape = new Rectangle(length, width);
            }
            else if (i==3)
            {
                Console.WriteLine("请输入要生成三角形的一边长度");
                double l1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入要生成三角形另外任意一边长度");
                double l2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入两边夹角值(不用输入弧度值，输入角度值就可以)");
                double angle = Math.PI * (Convert.ToDouble(Console.ReadLine())) / 180;
                shape = new Triangle(l1,l2,angle);
            }
            else
            {
                Console.WriteLine("工厂里没有这样的图形");
                shape = null;
            }
            return shape;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape;
            Console.WriteLine("现工厂中有三种图形可生成，它们分别是：");
            Console.WriteLine("1.圆形 2.长方形 3.三角形");
            Console.WriteLine("如果你想生成其中任何一种图形，请输入它对应的数字");
            Console.WriteLine("例如: 1 是圆形; 2 是长方形; 3 是三角形");
            Console.WriteLine("请输入数字");
            int i = Convert.ToInt32(Console.ReadLine());
            shape = ShapeFactory.produceShape(i);
            shape.area();
        }
    }
}
