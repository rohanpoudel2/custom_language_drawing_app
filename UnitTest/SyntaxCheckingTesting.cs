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
    public class SyntaxCheckingTesting
    {
        ArtWork myArtWork;
        CommandParser parser;
        dynamic expectedValue, actualValue;
        List<string> commands = new List<string>();
        [TestInitialize]

        public void Initialize()
        {
            myArtWork = new ArtWork();
            parser = new CommandParser(myArtWork);
        }

        [TestMethod]
        public void TestSyntaxFalse()
        {
            //Checking if testsyntax is working as expected
            parser.errors.Clear();
            commands.Add("cice 50");
            parser.checkSyntax(commands);
            expectedValue = 0;
            actualValue = myArtWork.shapes.Count;
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
