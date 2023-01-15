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
    public class ParameterCheckingTest
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
        public void TestParameterCheckingTrue() 
        {
            //Passing valid arguments to the checkParameter function
            actualValue = parser.checkParameter("200,50", "int");
            //Testing if the returned value is a type of array
            Assert.IsInstanceOfType(actualValue, typeof(Array));

            actualValue = parser.checkParameter("red", "string");
            Assert.IsInstanceOfType(actualValue, typeof(Array));
        }

        [TestMethod]
        public void TestParameterCheckingFalse()
        {
            actualValue = parser.checkParameter("-200", "int");
            Assert.IsNotInstanceOfType(actualValue, typeof(Array));

            //Passing invalid arguments to the checkParameter function
            actualValue = parser.checkParameter("re4", "string");
            //Testing if the returned value is not a type of array because of the above parameters it show return a exception rather than an array
            Assert.IsNotInstanceOfType(actualValue, typeof(Array));
        }
    }
}
