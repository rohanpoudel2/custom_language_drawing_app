using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class OtherCommandsTest
    {
        ArtWork myArtWork;
        CommandParser parser;
        dynamic expectedValue, actualValue;

        [TestInitialize]
        public void Initialize()
        {
            myArtWork = new ArtWork();
            parser = new CommandParser(myArtWork);
        }

        [TestMethod]
        public void TestFillChange()
        {
            //Testing if fill state is being changed as expected
            expectedValue = true;
            parser.runCommand("fill on");
            actualValue = myArtWork.fill;

            Assert.AreEqual(expectedValue, actualValue);

            expectedValue = false;
            parser.runCommand("fill off");
            actualValue = myArtWork.fill;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestColorChange()
        {
            //Testing if color is changing as expected
            expectedValue = true;
            actualValue = myArtWork.changeColor("red");
            Assert.AreEqual(expectedValue, actualValue);

            expectedValue = false;
            actualValue = myArtWork.changeColor("pinkkk");
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestPositionReset()
        {
            //Testing if position is being reset as expected
            myArtWork.moveTo(199, 100);
            parser.runCommand("reset");

            expectedValue = new ArrayList();
            expectedValue.Add(0);
            expectedValue.Add(0);

            actualValue = new ArrayList();
            actualValue.Add(myArtWork.xPosition);
            actualValue.Add(myArtWork.yPosition);

            CollectionAssert.AreEqual(expectedValue, actualValue);

            actualValue.Clear();

            myArtWork.moveTo(200, 200);

            actualValue.Add(myArtWork.xPosition);
            actualValue.Add(myArtWork.yPosition);

            CollectionAssert.AreNotEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestPositionMove()
        {
            //Testing is position is being moved as expected
            parser.runCommand("moveto 200,200");

            expectedValue = new ArrayList();
            actualValue = new ArrayList();

            expectedValue.Add(200);
            expectedValue.Add(200);

            actualValue.Add(myArtWork.xPosition);
            actualValue.Add(myArtWork.yPosition);

            CollectionAssert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void checkCommandLengthTestTrue()
        {
            //Checking is checkCommandLength function is working as expected
            expectedValue = true;
            actualValue = parser.checkCommandLength(1, 1);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void checkCommandLengthTestFalse()
        {
            expectedValue = false;
            actualValue = parser.checkCommandLength(1, 2);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void checkColorTestTrue()
        {
            //checking if checkColot function is working as expected
            expectedValue = true;
            actualValue = parser.checkColor("red");
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void checkColorTestFalse()
        {
            expectedValue= false;
            actualValue = parser.checkColor("pinkk");
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void checkFillResetTest() 
        {
            //Checking if fill reset is working as expected
            parser.runCommand("fill on");
            parser.resetFill();
            actualValue = myArtWork.fill;
            expectedValue = false;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void getErrorListCheck() 
        {
            //Checking if getting the error list is working as expected
            expectedValue = parser.errors;
            actualValue = parser.showError();
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void checkColorResetTest()
        {
            //Checking if color reset is working as expected
            parser.runCommand("pen red");
            expectedValue = Color.Black;
            parser.resetColor();
            actualValue = myArtWork.pen.Color;
            Assert.AreEqual(expectedValue,actualValue);
        }

    }
}
