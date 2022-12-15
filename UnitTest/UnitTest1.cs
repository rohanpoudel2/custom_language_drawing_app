using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Collections.Generic;
using System.Reflection;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        ArtWork myArt = new ArtWork();
        CommandParser parser;
        ShapeFactory shape;
        Graphics g = Graphics.FromImage(new Bitmap(500, 500));
        Pen pen = new Pen(Color.Black, 2);
        dynamic expectedValue, actualValue;

        [TestMethod]
        public void TestFillChange()
        {
            parser = new CommandParser(myArt);

            expectedValue = true;
            parser.runCommand("fill on");
            actualValue = myArt.fill;
            Assert.AreEqual(expectedValue, actualValue);

            expectedValue = false;
            parser.runCommand("fill off");
            actualValue = myArt.fill;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestColorChange()
        {
            expectedValue = true;
            actualValue = myArt.changeColor("red");
            Assert.AreEqual(expectedValue, actualValue);

            expectedValue = false;
            actualValue = myArt.changeColor("reddddd");
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestPositionReset()
        {
            parser= new CommandParser(myArt);

            myArt.moveTo(200,200);
            parser.runCommand("reset");

            expectedValue = new ArrayList();
            expectedValue.Add(0);
            expectedValue.Add(0);

            actualValue = new ArrayList();
            actualValue.Add(myArt.xPosition);
            actualValue.Add(myArt.yPosition);

            CollectionAssert.AreEqual(expectedValue, actualValue);

            actualValue.Clear();
            
            myArt.moveTo(200,200);
            
            actualValue.Add(myArt.xPosition);
            actualValue.Add(myArt.yPosition);

            CollectionAssert.AreNotEqual(expectedValue, actualValue);

        }

        [TestMethod]
        public void TestPositionMove()
        {
            parser = new CommandParser(myArt);

            parser.runCommand("moveto 200,200");

            expectedValue = new ArrayList();
            actualValue = new ArrayList();

            expectedValue.Add(200);
            expectedValue.Add(200);

            actualValue.Add(myArt.xPosition);
            actualValue.Add(myArt.yPosition);

            CollectionAssert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestParameterCheck()
        {
            parser = new CommandParser(myArt);

            actualValue = parser.checkParameter("200,50", "int");
            Assert.IsInstanceOfType(actualValue, typeof(Array));

            actualValue = parser.checkParameter("red", "string");
            Assert.IsInstanceOfType(actualValue, typeof(Array));

            actualValue = parser.checkParameter("-200", "int");
            Assert.IsNotInstanceOfType(actualValue, typeof(Array));

            actualValue = parser.checkParameter("re4", "string");
            Assert.IsNotInstanceOfType(actualValue, typeof(Array));
        }

        [TestMethod]
        public void TestCircleObject()
        {
            shape = new ShapeFactory(g);
            actualValue = shape.drawCircle(pen, 0,0,20);
            Assert.IsInstanceOfType(actualValue, typeof(Circle));
        }

        [TestMethod]
        public void TestSquareObject()
        {
            shape = new ShapeFactory(g);
            actualValue = shape.drawSquare(pen, 0, 0,20);
            Assert.IsInstanceOfType(actualValue, typeof(Square));
        }

        [TestMethod]
        public void TestRectangleObject()
        {
            shape = new ShapeFactory(g);
            actualValue = shape.drawRectangle(pen, 0,0,20,40);
            Assert.IsInstanceOfType(actualValue, typeof(Rectanglee));
        }

        [TestMethod]
        public void TestLineObject()
        {
            shape = new ShapeFactory(g);
            actualValue = shape.drawLine(pen, 0,0, 20,20);
            Assert.IsInstanceOfType(actualValue, typeof(Line));
        }

        [TestMethod]
        public void TestTriangleObject()
        {
            shape = new ShapeFactory(g);

            Point point1 = new Point(0, 0);
            Point point2 = new Point(20, 20);
            Point point3 = new Point(50, 50);

            Point[] points =
            { point1, point2, point3 };

            actualValue = shape.drawTriangle(pen, points);
            Assert.IsInstanceOfType(actualValue, typeof(Triangle));
        }

        [TestMethod]
        public void TestCommands() 
        {
            parser = new CommandParser(myArt);
            parser.runCommand("no 40");
            actualValue = parser.showError();
        }
    }
}
