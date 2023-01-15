using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class ShapeFactoryTesting
    {
        ShapeFactory shape;
        Graphics g;
        Pen pen;
        dynamic actualValue;

        [TestInitialize]
        public void Initialize()
        {
            pen = new Pen(Color.Black,2);
            g = Graphics.FromImage(new Bitmap(500, 500));
            shape = new ShapeFactory(g);
        }

        [TestMethod]
        public void TestCircleObject()
        {
            actualValue = shape.drawCircle(pen, 0, 0, 20);
            // Testing if the actual value is indeed a type of Circle
            Assert.IsInstanceOfType(actualValue, typeof(Circle));
        }

        [TestMethod]
        public void TestSquareObject()
        {
            //Calling the drawSquare functino to get the returned object
            actualValue = shape.drawSquare(pen, 0, 0, 20);
            //Testing if the actual value is indeed of a type of Square
            Assert.IsInstanceOfType(actualValue, typeof(Square));
        }

        [TestMethod]
        public void TestRectangleObject()
        {
            //Calling the drawRectangle functino to get the returned object
            actualValue = shape.drawRectangle(pen, 0, 0, 20, 40);
            //Testing if the actual value is indeed of a type of Rectanglee
            Assert.IsInstanceOfType(actualValue, typeof(Rectanglee));
        }

        [TestMethod]
        public void TestLineObject()
        {
            //Calling the drawLine functino to get the returned object
            actualValue = shape.drawLine(pen, 0, 0, 20, 20);
            //Testing if the actual value is indeed of a type of Line
            Assert.IsInstanceOfType(actualValue, typeof(Line));
        }

        [TestMethod]
        public void TestTriangleObject()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(20, 20);
            Point point3 = new Point(50, 50);

            Point[] points =
            { point1, point2, point3 };

            //Calling the drawTriangle functino to get the returned object
            actualValue = shape.drawTriangle(pen, points);
            //Testing if the actual value is indeed of a type of Triangle
            Assert.IsInstanceOfType(actualValue, typeof(Triangle));
        }

        [TestMethod]
        public void TestStarObject()
        {
            int outerRadius = 50;
            int innerRadius = outerRadius / 2;
            Point center = new Point(110, 110);

            List<Point> points = new List<Point>();
            for (int i = 0; i < 5; i++)
            {
                double angle = 4.0 * Math.PI * i / 5.0;
                int x = (int)(center.X + outerRadius * Math.Cos(angle));
                int y = (int)(center.Y + outerRadius * Math.Sin(angle));
                points.Add(new Point(x, y));

                angle += Math.PI / 5;
                x = (int)(center.X + innerRadius * Math.Cos(angle));
                y = (int)(center.Y + innerRadius * Math.Sin(angle));
                points.Add(new Point(x, y));
            }

            Point[] points1 = points.ToArray();

            actualValue = shape.drawStar(pen,points1);

            Assert.IsInstanceOfType(actualValue, typeof(Star));
        }
    }
}
