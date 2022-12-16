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
        //Declaring variables required to perform tests
        ArtWork myArt = new ArtWork();
        CommandParser parser;
        ShapeFactory shape;
        Graphics g = Graphics.FromImage(new Bitmap(500, 500));
        Pen pen = new Pen(Color.Black, 2);
        dynamic expectedValue, actualValue;

        //This test method is testing if the fill change command is working as expected
        [TestMethod]
        public void TestFillChange()
        {
            parser = new CommandParser(myArt);

            //Value is expected to be true if "fill on" command is passed
            expectedValue = true;
            parser.runCommand("fill on");
            //Getting the actual value which is to be changed after running the above command
            actualValue = myArt.fill;
            //Testing if the expectedValue and the actualValue are same
            Assert.AreEqual(expectedValue, actualValue);

            expectedValue = false;
            parser.runCommand("fill off");
            actualValue = myArt.fill;
            Assert.AreEqual(expectedValue, actualValue);
        }

        //This test method is testing if the color change command is working as expected
        [TestMethod]
        public void TestColorChange()
        {
            //Value is expected to be true if all the color changing tests passes
            expectedValue = true;
            //Sending a valid color to the changeColor method in ArtWork class
            actualValue = myArt.changeColor("red");
            //Testing if the expectedValie and the actualValue are same which is true
            Assert.AreEqual(expectedValue, actualValue);

            expectedValue = false;
            actualValue = myArt.changeColor("reddddd");
            Assert.AreEqual(expectedValue, actualValue);
        }

        //This test method is testing if the Position reset command is reseting the position back to 0,0
        [TestMethod]
        public void TestPositionReset()
        {
            parser= new CommandParser(myArt);
            
            //Moving the current position to 200,200
            myArt.moveTo(200,200);
            //Using the reset command to bring back the cursor position to 0,0
            parser.runCommand("reset");

            //The expected value is to be 0,0
            expectedValue = new ArrayList();
            expectedValue.Add(0);
            expectedValue.Add(0);

            //Getting the actual current position from the ArtWork class
            actualValue = new ArrayList();
            actualValue.Add(myArt.xPosition);
            actualValue.Add(myArt.yPosition);

            //Using collection assert's areequal method to check if both the collection have same value at index 0 and index 1
            CollectionAssert.AreEqual(expectedValue, actualValue);

            actualValue.Clear();
            
            myArt.moveTo(200,200);
            
            actualValue.Add(myArt.xPosition);
            actualValue.Add(myArt.yPosition);

            CollectionAssert.AreNotEqual(expectedValue, actualValue);

        }

        //This test method is testing if the position moving command is working as expected
        [TestMethod]
        public void TestPositionMove()
        {
            parser = new CommandParser(myArt);

            //Moving the current position to 200,200
            parser.runCommand("moveto 200,200");

            expectedValue = new ArrayList();
            actualValue = new ArrayList();

            expectedValue.Add(200);
            expectedValue.Add(200);

            actualValue.Add(myArt.xPosition);
            actualValue.Add(myArt.yPosition);

            //Using collection assert's areequal method to check if both the collection have same valie at index 0 and index 1
            CollectionAssert.AreEqual(expectedValue, actualValue);
        }

        //This test method is testing if the parameter check helper function is working as expected
        [TestMethod]
        public void TestParameterCheck()
        {
            parser = new CommandParser(myArt);

            //Passing valid arguments to the checkParameter function
            actualValue = parser.checkParameter("200,50", "int");
            //Testing if the returned value is a type of array
            Assert.IsInstanceOfType(actualValue, typeof(Array));

            actualValue = parser.checkParameter("red", "string");
            Assert.IsInstanceOfType(actualValue, typeof(Array));

            actualValue = parser.checkParameter("-200", "int");
            Assert.IsNotInstanceOfType(actualValue, typeof(Array));
            
            //Passing invalid arguments to the checkParameter function
            actualValue = parser.checkParameter("re4", "string");
            //Testing if the returned value is not a type of array because of the above parameters it show return a exception rather than an array
            Assert.IsNotInstanceOfType(actualValue, typeof(Array));
        }

        //This test method is testing if the shapefactory method is returning the appropriate Object of Circle class
        [TestMethod]
        public void TestCircleObject()
        {
            shape = new ShapeFactory(g);
            //Calling the drawCircle funciton to get the returned object
            actualValue = shape.drawCircle(pen, 0,0,20);
            // Testing if the actual value is indeed a type of Circle
            Assert.IsInstanceOfType(actualValue, typeof(Circle));
        }

        //This test method is testing if the shapefactory method is returning the appropriate Object of Square class
        [TestMethod]
        public void TestSquareObject()
        {
            shape = new ShapeFactory(g);
            //Calling the drawSquare functino to get the returned object
            actualValue = shape.drawSquare(pen, 0, 0,20);
            //Testing if the actual value is indeed of a type of Square
            Assert.IsInstanceOfType(actualValue, typeof(Square));
        }

        //This test method is testing if the shapefactory method is returning the appropriate Object of Rectanglee class
        [TestMethod]
        public void TestRectangleObject()
        {
            shape = new ShapeFactory(g);
            //Calling the drawRectangle functino to get the returned object
            actualValue = shape.drawRectangle(pen, 0,0,20,40);
            //Testing if the actual value is indeed of a type of Rectanglee
            Assert.IsInstanceOfType(actualValue, typeof(Rectanglee));
        }

        //This test method is testing if the shapefactory method is returning the appropriate Object of Line class
        [TestMethod]
        public void TestLineObject()
        {
            shape = new ShapeFactory(g);
            //Calling the drawLine functino to get the returned object
            actualValue = shape.drawLine(pen, 0,0, 20,20);
            //Testing if the actual value is indeed of a type of Line
            Assert.IsInstanceOfType(actualValue, typeof(Line));
        }

        //This test method is testing if the shapefactory method is returning the appropriate Object of Triangle class
        [TestMethod]
        public void TestTriangleObject()
        {
            shape = new ShapeFactory(g);

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

        
    }
}
