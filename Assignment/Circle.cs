using System;
using System.Data;
using System.Drawing;

namespace Assignment
{
    /// <summary>
    /// The Circle class inherits the BasicShape class and implements the Draw() and Draw(SolidBrush brush) methods
    /// to draw a circle on the Graphics object.
    /// </summary>
    public class Circle : BasicShape
    {
        /// <summary>
        /// Declaring variable for the radius of the circle.
        /// </summary>
        private int radius;

        /// <summary>
        /// Constructor of the Circle class that takes Graphics object, Pen object, x and y position and radius of the circle as parameters.
        /// </summary>
        /// <param name="illustrate">The Graphics object on which the shape will be drawn.</param>
        /// <param name="pen">The Pen object that will be used to draw the shape.</param>
        /// <param name="xPosition">The x-coordinate of the center of the circle.</param>
        /// <param name="yPosition">The y-coordinate of the center of the circle.</param>
        /// <param name="radius">The radius of the circle.</param>
        public Circle(Graphics illustrate, Pen pen, int xPosition, int yPosition, int radius) : base(pen, illustrate, xPosition, yPosition)
        {
            //Assigning the received parameters to the global variables
            this.radius = radius;
        }

        /// <summary>
        /// Draws the circle on the Graphics object using the Pen object and the x, y position and radius of the circle.
        /// </summary>
        public override void Draw()
        {
           illustrate.DrawEllipse(pen, xPosition - radius, yPosition - radius, (radius * 2), (radius * 2));
        }

        /// <summary>
        /// Draws the circle on the Graphics object using the Brush object and the x, y position and radius of the circle.
        /// </summary>
        public override void Draw(SolidBrush brush)
        {
            illustrate.FillEllipse(brush, xPosition - radius, yPosition - radius, (radius * 2), (radius * 2));
        }

    }
}