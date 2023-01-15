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
    public class IteratorDesignTest
    {
        ArtWork artwork;
        ShapeFactory shapeFactory;

        [TestInitialize]
        public void Initialize()
        {
            artwork = new ArtWork();
            shapeFactory = new ShapeFactory(artwork.illustrate);
        }

        [TestMethod]
        public void TestIteratorDesignPattern()
        {
            // Adding some shapes to the artwork
            artwork.AddShape(shapeFactory.drawCircle(new Pen(Color.Red), 0, 0, 50));
            artwork.AddShape(shapeFactory.drawSquare(new Pen(Color.Blue), 50, 50, 100));
            artwork.AddShape(shapeFactory.drawLine(new Pen(Color.Green), 0, 0, 100, 100));
            // Creating an iterator for the artwork
            Iterator iterator = artwork.CreateIterator();
            // Testing that the iterator correctly iterates through the shapes in the artwork
            Assert.IsTrue(iterator.HasNext());
            KeyValuePair<Shape, Tuple<bool, Pen>> shape1 = (KeyValuePair<Shape, Tuple<bool, Pen>>)iterator.Next();
            Assert.AreEqual(shape1.Key.GetType(), typeof(Circle));
            Assert.IsTrue(iterator.HasNext());
            KeyValuePair<Shape, Tuple<bool, Pen>> shape2 = (KeyValuePair<Shape, Tuple<bool, Pen>>)iterator.Next();
            Assert.AreEqual(shape2.Key.GetType(), typeof(Square));
            Assert.IsTrue(iterator.HasNext());
            KeyValuePair<Shape, Tuple<bool, Pen>> shape3 = (KeyValuePair<Shape, Tuple<bool, Pen>>)iterator.Next();
            Assert.AreEqual(shape3.Key.GetType(), typeof(Line));
            Assert.IsFalse(iterator.HasNext());
        }
    }
}
