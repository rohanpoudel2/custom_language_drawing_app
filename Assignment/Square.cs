using System.Drawing;

namespace Assignment
{
    /// <summary>
    /// The Square class inherits the BasicShape class and implements the Draw() and Draw(SolidBrush brush) methods
    /// to draw a square on the Graphics object.
    /// </summary>
    public class Square : BasicShape
    {
        /// <summary>
        /// Declaring variable for the size of the square.
        /// </summary>
        private int size;

        /// <summary>
        /// Constructor of the Square class that takes Graphics object, Pen object, x and y position and size of the square as parameters.
        /// </summary>
        /// <param name="illustrate">The Graphics object on which the shape will be drawn.</param>
        /// <param name="pen">The Pen object that will be used to draw the shape.</param>
        /// <param name="xPosition">The x-coordinate of the drawing point of the square.</param>
        /// <param name="yPosition">The y-coordinate of the drawing point of the square.</param>
        /// <param name="size">The size of the square.</param>
        public Square(Graphics illustrate,Pen pen, int xPosition, int yPosition, int size) : base(pen, illustrate, xPosition, yPosition)
        {
            //Assigning the received parameters to the global variables
            this.size = size;
        }

        /// <summary>
        /// Draws the square on the Graphics object using the Pen object and the x, y position and size of the square.
        /// </summary>
        public override void Draw()
        {
            illustrate.DrawRectangle(pen, xPosition, yPosition, size,  size);
        }

        /// <summary>
        /// Draws the square on the Graphics object using the Brush object and the x, y position and size of the square.
        /// </summary>
        public override void Draw(SolidBrush brush)
        {
            illustrate.FillRectangle(brush, xPosition, yPosition, size, size);
        }
    }
}