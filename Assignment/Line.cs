using System.Drawing;

namespace Assignment
{
    /// <summary>
    /// The Line class inherits the BasicShape class and implements the Draw() and Draw(SolidBrush brush) methods
    /// to draw a line on the Graphics object.
    /// </summary>
    public class Line : BasicShape
    {
        /// <summary>
        /// Declaring variable for the drawing position of the line.
        /// </summary>
        private int toXPos, toYPos;

        /// <summary>
        /// Constructor of this class
        /// </summary>
        /// <param name="illustrate">The graphics object</param>
        /// <param name="pen">The pen to be used for drawing</param>
        /// <param name="xPosition">Starting x position of the line</param>
        /// <param name="yPosition">Starting y position of the line</param>
        /// <param name="toXPos">Ending x position of the line</param>
        /// <param name="toYPos">Ending y position of the line</param>
        public Line(Graphics illustrate, Pen pen, int xPosition, int yPosition, int toXPos, int toYPos) : base(pen, illustrate, xPosition, yPosition)
        {
            //Assigning the received parameters to the global variables
            this.toXPos = toXPos;
            this.toYPos = toYPos;
        }

        /// <summary>
        /// Draws the Line shape on the graphics object
        /// </summary>
        public override void Draw()
        {
            illustrate.DrawLine(pen, xPosition, yPosition, toXPos, toYPos);
        }

        /// <summary>
        /// Draws the Line shape on the graphics object with the given SolidBrush
        /// </summary>
        public override void Draw(SolidBrush brush)
        {
            illustrate.DrawLine(pen, xPosition, yPosition, toXPos, toYPos);
        }
    }
}