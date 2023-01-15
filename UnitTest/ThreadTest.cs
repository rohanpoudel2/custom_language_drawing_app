using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class ThreadTest
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
        public void TestThreadStart()
        {
            //Checking if thread start is working as expected
            parser.runCommand("circle 50");
            parser.runCommand("flash red,green");
            expectedValue = true;
            actualValue = parser.flashShapes.IsAlive;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestThreadStop()
        {
            //Checking if thread stop is working as expected
            TestThreadStart();
            parser.stopFlashing();
            while(parser.stopFlash != true) { }
            expectedValue = false;
            actualValue= parser.flashShapes.IsAlive;
            Assert.AreEqual(expectedValue, actualValue);

        }
    }
}
