using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment;
using System.Collections.Generic;

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

            myArt.moveto(200, 200);

            expectedValue = new int[0, 0];
            actualValue = new int[myArt.Xposition, myArt.Yposition];
            CollectionAssert.AreEqual(expectedValue, actualValue);

        }
      
    }
}
