using System.Drawing;

namespace Assignment
{
    public class Triangle
    {
        private Graphics illustrate;
        private Pen pen;
        private Point[] points;
        public Triangle(Graphics illustrate, Pen pen, Point[] points)
        {
            this.illustrate = illustrate;
            this.pen = pen;
            this.points = points;
        }

        public void Draw()
        {
            illustrate.DrawPolygon(pen, points);
        }

        public void Draw(SolidBrush brush)
        {
            illustrate.FillPolygon(brush, points);
        }
    }
}