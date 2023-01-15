using System.Drawing;

namespace Assignment
{
    /// <summary>
    /// The Triangle class inherits the BasicShape class and implements the Draw() and Draw(SolidBrush brush) methods
    /// to draw a triangle on the Graphics object.
    /// </summary>
    public class Triangle : BasicShape
    {
        /// <summary>
        /// Declaring variable for the points of the triangle.
        /// </summary>
        private Point[] points;

        /// <summary>
        /// Constructor of the Triangle class that takes Graphics object, Pen object and points of the triangle as parameters.
        /// </summary>
        /// <param name="illustrate">The Graphics object on which the shape will be drawn.</param>
        /// <param name="pen">The Pen object that will be used to draw the shape.</param>
        /// <param name="points">The points of the triangle.</param>
        public Triangle(Graphics illustrate, Pen pen, Point[] points) : base(pen, illustrate, 0, 0)
        {
            //Assigning the received parameters to the global variables
            this.points = points;
        }

        /// <summary>
        /// Draws the triangle on the Graphics object using the Pen object and points of the triangle.
        /// </summary>
        public override void Draw()
        {
            illustrate.DrawPolygon(pen, points);
        }

        /// <summary>
        /// Draws the triangle on the Graphics object using the Brush object and points of the triangle.
        /// </summary>
        public override void Draw(SolidBrush brush)
        {
            illustrate.FillPolygon(brush, points);
        }
    }
}