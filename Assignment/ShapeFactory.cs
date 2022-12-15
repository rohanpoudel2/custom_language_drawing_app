using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{

    //Implementing the interface Shapes in this ShapeFactory function
    class ShapeFactory: Shapes
    {
        private Graphics illustrate;

        //Constructor for ShapeFactory class
        public ShapeFactory(Graphics illustrate)
        {
            this.illustrate = illustrate;
        }

        // Function responsible to return the Circle object
        public Circle drawCircle(Pen pen, int x, int y, int radius)
        {
            return new Circle(illustrate, pen, x, y, radius);
        }

        //Function responsible to return the Rectanglee object
        public Rectanglee drawRectangle(Pen pen, int x, int y, int width, int height)
        {
            return new Rectanglee(illustrate, pen, x, y, width, height);
        }

        //Function responsible to return the Triangle Object
        public Triangle drawTriangle(Pen pen, Point[] points)
        {
            return new Triangle(illustrate, pen, points);
        }

        //Function responsible to return the Square Object
        public Square drawSquare(Pen pen, int xPosition, int yPosition, int size)
        {
            return new Square(illustrate, pen, xPosition, yPosition, size);
        }

        //Function responsible to return the Line Object
        public Line drawLine(Pen pen, int xPosition, int yPosition, int xPos, int yPos)
        {
            return new Line(illustrate, pen, xPosition, yPosition, xPos, yPos);
        }
    }
}
