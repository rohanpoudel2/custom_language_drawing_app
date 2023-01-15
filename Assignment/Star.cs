using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    /// <summary>
    /// The Star class inherits the BasicShape class and implements the Draw() and Draw(SolidBrush brush) methods
    /// to draw a star on the Graphics object.
    /// </summary>
    public class Star:BasicShape
    {
        /// <summary>
        /// Declaring variable for the points of the star.
        /// </summary>
        private Point[] points;

        /// <summary>
        /// Constructor of the Star class that takes Graphics object, Pen object and points of the star as parameters.
        /// </summary>
        /// <param name="illustrate">The Graphics object on which the shape will be drawn.</param>
        /// <param name="pen">The Pen object that will be used to draw the shape.</param>
        /// <param name="points">The points of the star.</param>
        public Star(Graphics illustrate, Pen pen, Point[] points) : base(pen, illustrate, 0, 0)
        {
            this.points = points;
        }

        /// <summary>
        /// Draws the star on the Graphics object using the Pen object and points of the star.
        /// </summary>
        public override void Draw()
        {
            illustrate.DrawPolygon(pen, points);
        }

        /// <summary>
        /// Draws the star on the Graphics object using the Brush object and points of the star.
        /// </summary>
        public override void Draw(SolidBrush brush)
        {
            illustrate.FillPolygon(brush,points);
        }
    }
}
