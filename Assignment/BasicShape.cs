using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    /// <summary>
    /// The BasicShape class serves as a base class for different shape classes. It contains the basic variables and constructor needed to create a shape.
    /// </summary>
    public abstract class BasicShape : Shape
    {
        /// <summary>
        /// The Pen object used to draw the shape
        /// </summary>
        protected Pen pen;
        /// <summary>
        /// The Graphics object used to draw the shape
        /// </summary>
        protected Graphics illustrate;
        /// <summary>
        /// The x-coordinate and y-coordinate position of the shape
        /// </summary>
        protected int xPosition, yPosition;

        /// <summary>
        /// Constructor of BasicShape class which assigns the passed arguments to the class level variables
        /// </summary>
        /// <param name="pen">The Pen object used to draw the shape</param>
        /// <param name="illustrate">The Graphics object used to draw the shape</param>
        /// <param name="xPosition">The x-coordinate position of the shape</param>
        /// <param name="yPosition">The y-coordinate position of the shape</param>
        protected BasicShape(Pen pen, Graphics illustrate, int xPosition, int yPosition)
        {
            this.pen = pen;
            this.illustrate= illustrate;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        /// <summary>
        /// Draws the shape
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Draws the shape with a given brush
        /// </summary>
        /// <param name="brush">The brush used to fill the shape</param>
        public abstract void Draw(SolidBrush brush);
    }
}
