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
    public class VariableAssignmentTesting
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
        public void VariableAssignmentTestTrue()
        {
            //Assigning a variable to test if the output is as expected
            string command = "a=20";
            actualValue= parser.assignVariables(command);
            expectedValue = "";

            Assert.AreEqual(expectedValue,actualValue);
        }

        [TestMethod]
        public void VariableAssignmentTestFalse()
        {
            //Trying to do a illegal assignment to test if the exception is being thrown as expected
            try
            {
                string command = "b=";
            }catch(Exception e)
            {
                expectedValue = new CustomValueException("Null value cannot be assigned to the variable. Please try to assign a valid value.");
                Assert.AreEqual(expectedValue,e);
            }
        }

        [TestMethod]
        public void VariableAddition()
        {
            //Testing Addition of variable 
            parser.assignVariables("a=50");
            parser.assignVariables("b=a+20");
            expectedValue = "70";
            foreach (string a in parser.variable.Keys)
            {
                if (a.Equals("b"))
                {
                    actualValue = parser.variable[a];
                    break;
                }
            }
            Assert.AreEqual(expectedValue,actualValue);

        }

        [TestMethod]
        public void VariabelSubstraction()
        {
            //Testing Substraction of variable
            parser.assignVariables("a=50");
            parser.assignVariables("b=a-20");
            expectedValue = "30";
            foreach (string a in parser.variable.Keys)
            {
                if (a.Equals("b"))
                {
                    actualValue = parser.variable[a];
                    break;
                }
            }
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void VariabelMultiplicity()
        {
            //Testing multiplication of variable
            parser.assignVariables("a=2");
            parser.assignVariables("b=a*10");
            expectedValue = "20";
            foreach (string a in parser.variable.Keys)
            {
                if (a.Equals("b"))
                {
                    actualValue = parser.variable[a];
                    break;
                }
            }
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void VariabelDivision() 
        {
            //Testing division of variable
            parser.assignVariables("a=2");
            parser.assignVariables("b=20/a");
            expectedValue = "10";
            foreach (string a in parser.variable.Keys)
            {
                if (a.Equals("b"))
                {
                    actualValue = parser.variable[a];
                    break;
                }
            }
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void VariableClearTest()
        {
            //Testing clearing of variable
            parser.variable.Clear();
            parser.assignVariables("a=2");
            expectedValue = 1;
            actualValue = parser.variable.Count();
            Assert.AreEqual(expectedValue, actualValue);

            parser.clearVariables();

            expectedValue = 0;
            actualValue = parser.variable.Count();
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
