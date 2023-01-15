using System.Drawing;
using System.Runtime.InteropServices;

namespace Assignment
{
    /// <summary>
    /// The Rectanglee class inherits the BasicShape class and implements the Draw() and Draw(SolidBrush brush) methods
    /// to draw a Rectangle on the Graphics object.
    /// </summary>
    public class Rectanglee : BasicShape
    {
        /// <summary>
        /// Declaring variable for the width and height of the rectangle.
        /// </summary>
        private int width, height;

        /// <summary>
        /// Constructor of the Rectanglee class that takes Graphics object, Pen object, x and y position, width and height of the rectangle as parameters.
        /// </summary>
        /// <param name="illustrate">The Graphics object on which the shape will be drawn.</param>
        /// <param name="pen">The Pen object that will be used to draw the shape.</param>
        /// <param name="xPosition">The x-coordinate of the drawing point of the rectangle.</param>
        /// <param name="yPosition">The y-coordinate of the drawing point of the rectagle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rectanglee(Graphics illustrate, Pen pen, int xPosition, int yPosition, int width, int height) : base(pen, illustrate, xPosition, yPosition)
        {
            //Assigning the received parameters to the global variables
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Draws the rectangle on the Graphics object using the Pen object and the x, y position, width and height of the rectangle.
        /// </summary>
        public override void Draw()
        {
            illustrate.DrawRectangle(pen, xPosition, yPosition, width, height);
        }


        /// <summary>
        /// Draws the rectangle on the Graphics object using the Brush object and the x, y position, width and height of the rectangle.
        /// </summary>
        public override void Draw(SolidBrush brush)
        {
            illustrate.FillRectangle(brush, xPosition, yPosition, width, height);
        }
    }
}