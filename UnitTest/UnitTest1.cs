using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment;
using System.Collections;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        ArtWork myArt;
        dynamic expectedValue, actualValue;

        [TestMethod]
        public void TestFillChange()
        {
            myArt = new ArtWork();

            expectedValue = true;
            myArt.changeFill("on");
            actualValue = myArt.fill;
            Assert.AreEqual(expectedValue, actualValue);

            expectedValue = false;
            myArt.changeFill("off");
            actualValue = myArt.fill;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestColorChange()
        {
            myArt = new ArtWork();

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
            myArt = new ArtWork();

            myArt.moveTo(200,200);
            myArt.reset();

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
            myArt = new ArtWork();

            myArt.moveTo(200,200);

            expectedValue = new ArrayList();
            actualValue = new ArrayList();

            expectedValue.Add(200);
            expectedValue.Add(200);

            actualValue.Add(myArt.xPosition);
            actualValue.Add(myArt.yPosition);

            CollectionAssert.AreEqual(expectedValue, actualValue);
        }



      
    }
}
