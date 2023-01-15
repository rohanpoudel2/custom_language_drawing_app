using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    /// <summary>
    /// Interface for all the shapes that can be drawn from the <see cref="ArtWork"/> class.
    /// </summary>
    public interface Shape
    {
        /// <summary>
        /// Draws the shape without fill.
        /// </summary>
        void Draw();

        /// <summary>
        /// Draws the shape with fill using the provided brush.
        /// </summary>
        /// <param name="Brush">The brush to use for fill.</param>
        void Draw(SolidBrush Brush);
    }
}
