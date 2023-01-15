using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{


    /// <summary>
    /// The ShapeFactory class is responsible for creating various shapes by taking a Graphics object and returning the corresponding shape object.
    /// </summary>
    public class ShapeFactory: Shapes
    {
        /// <summary>
        /// The 'illustrate' variable is used to hold a reference to the Graphics object that is used to draw shapes on the screen.
        /// </summary>
        private Graphics illustrate;

        /// <summary>
        /// Constructor for ShapeFactory class
        /// </summary>
        /// <param name="illustrate">A Graphics object that is used to create the shapes</param>
        public ShapeFactory(Graphics illustrate)
        {
            this.illustrate = illustrate;
        }

        /// <summary>
        /// Function responsible to return the Circle object.
        /// </summary>
        /// <param name="pen">Pen object used to draw the shape</param>
        /// <param name="x">x-coordinate of the center of the circle</param>
        /// <param name="y">y-coordinate of the center of the circle</param>
        /// <param name="radius">radius of the circle</param>
        /// <returns>A Circle object</returns>
        public Circle drawCircle(Pen pen, int x, int y, int radius)
        {
            return new Circle(illustrate, pen, x, y, radius);
        }

        /// <summary>
        /// Function responsible to return the Rectanglee object
        /// </summary>
        /// <param name="pen">Pen object used to draw the shape</param>
        /// <param name="x">x-coordinate of the top-left corner of the rectangle</param>
        /// <param name="y">y-coordinate of the top-left corner of the rectangle</param>
        /// <param name="width">width of the rectangle</param>
        /// <param name="height">height of the rectangle</param>
        /// <returns>A Rectanglee object</returns>
        public Rectanglee drawRectangle(Pen pen, int x, int y, int width, int height)
        {
            return new Rectanglee(illustrate, pen, x, y, width, height);
        }

        /// <summary>
        /// Function responsible to return the Triangle Object
        /// </summary>
        /// <param name="pen">Pen object used to draw the shape</param>
        /// <param name="points">An array of 3 Point objects that define the vertices of the triangle</param>
        /// <returns>A Triangle object</returns>
        public Triangle drawTriangle(Pen pen, Point[] points)
        {
            return new Triangle(illustrate, pen, points);
        }

        /// <summary>
        /// Function responsible to return the Square Object
        /// </summary>
        /// <param name="pen">Pen object used to draw the shape</param>
        /// <param name="xPosition">x-coordinate of the top-left corner of the square</param>
        /// <param name="yPosition">y-coordinate of the top-left corner of the square</param>
        /// <param name="size">length of the sides of the square</param>
        /// <returns>A Square object</returns>
        public Square drawSquare(Pen pen, int xPosition, int yPosition, int size)
        {
            return new Square(illustrate, pen, xPosition, yPosition, size);
        }

        /// <summary>
        /// Function responsible to return the Line Object
        /// </summary>
        /// <param name="pen">Pen object used to draw the line</param>
        /// <param name="xPosition">x-coordinate position of the line</param>
        /// <param name="yPosition">y-coordinate position of the line</param>
        /// <returns>A Line object</returns>
        public Line drawLine(Pen pen, int xPosition, int yPosition, int xPos, int yPos)
        {
            return new Line(illustrate, pen, xPosition, yPosition, xPos, yPos);
        }

        /// <summary>
        /// Method for creating a Star shape
        /// </summary>
        /// <param name="pen">The Pen object to be used for drawing the Star</param>
        /// <param name="points">An array of Point objects representing the vertices of the Star</param>
        /// <returns>Returns a Star object</returns>
        public Star drawStar(Pen pen, Point[] points) 
        {
            return new Star(illustrate,pen,points);
        }
    }
}
