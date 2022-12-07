using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{

    class ShapeFactory: Shapes
    {
        private Graphics illustrate;

        public ShapeFactory(Graphics illustrate)
        {
            this.illustrate = illustrate;
        }

        public Circle drawCircle(Pen pen, int x, int y, int radius)
        {
            return new Circle(illustrate, pen, x, y, radius);
        }

        public Rectanglee drawRectangle(Pen pen, int x, int y, int width, int height)
        {
            return new Rectanglee(illustrate, pen, x, y, width, height);
        }

        public Triangle drawTriangle(Pen pen, Point[] points)
        {
            return new Triangle(illustrate, pen, points);
        }
    }
}
