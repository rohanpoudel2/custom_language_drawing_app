using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    /// <summary>
    /// Declares the interface methods for creating different shapes
    /// </summary>
    interface Shapes
    {
        /// <summary>
        /// Method for creating a Circle shape
        /// </summary>
        /// <param name="pen">The Pen object to be used for drawing the Circle</param>
        /// <param name="xPosition">The x-coordinate of the center of the Circle</param>
        /// <param name="yPosition">The y-coordinate of the center of the Circle</param>
        /// <param name="radius">The radius of the Circle</param>
        /// <returns>Returns a Circle object</returns>
        Circle drawCircle(Pen pen, int xPosition, int yPosition, int radius);

        /// <summary>
        /// Method for creating a Rectangle shape
        /// </summary>
        /// <param name="pen">The Pen object to be used for drawing the Rectangle</param>
        /// <param name="xPosition">The x-coordinate of the top-left corner of the Rectangle</param>
        /// <param name="yPosition">The y-coordinate of the top-left corner of the Rectangle</param>
        /// <param name="width">The width of the Rectangle</param>
        /// <param name="height">The height of the Rectangle</param>
        /// <returns>Returns a Rectanglee object</returns>
        Rectanglee drawRectangle(Pen pen, int xPosition, int yPosition, int width, int height);

        /// <summary>
        /// Method for creating a Triangle shape
        /// </summary>
        /// <param name="pen">The Pen object to be used for drawing the Triangle</param>
        /// <param name="points">An array of Point objects representing the vertices of the Triangle</param>
        /// <returns>Returns a Triangle object</returns>
        Triangle drawTriangle(Pen pen, Point[] points);

        /// <summary>
        /// Method for creating a Square shape
        /// </summary>
        /// <param name="pen">The Pen object to be used for drawing the Square</param>
        /// <param name="xPosition">The x-coordinate of the top-left corner of the Square</param>
        /// <param name="yPosition">The y-coordinate of the top-left corner of the Square</param>
        /// <param name="size">The size of the Square</param>
        /// <returns>Returns a Square object</returns>
        Square drawSquare(Pen pen, int xPosition, int yPosition, int size);

        /// <summary>
        /// Method for creating a Line shape
        /// </summary>
        /// <param name="pen">The Pen object to be used for drawing the Line</param>
        /// <param name="xPosition">The x-coordinate of the starting point of the Line</param>
        /// <param name="yPosition">The y-coordinate of the starting point of the Line</param>
        /// <param name="toXPosition">The x-coordinate of the ending point of the Line</param>
        /// <param name="toYPosition">The y-coordinate of the ending point of the Line</param>
        /// <returns>Returns a Line object</returns>
        Line drawLine(Pen pen, int xPosition, int yPosition, int toXPosition, int toYPosition);

        /// <summary>
        /// Method for creating a Star shape
        /// </summary>
        /// <param name="pen">The Pen object to be used for drawing the Star</param>
        /// <param name="points">An array of Point objects representing the vertices of the Star</param>
        /// <returns>Returns a Star object</returns>
        Star drawStar(Pen pen, Point[] points);
    }
}
