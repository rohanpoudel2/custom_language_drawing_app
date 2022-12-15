using System.Drawing;

namespace Assignment
{
    public class Triangle
    {
        //Declaring variables
        private Graphics illustrate;
        private Pen pen;
        private Point[] points;

        //Constructor of this class
        public Triangle(Graphics illustrate, Pen pen, Point[] points)
        {
            //Assigning the received parameters to the global variables
            this.illustrate = illustrate;
            this.pen = pen;
            this.points = points;
        }

        // Function responsible to draw the Desired shape
        public void Draw()
        {
            illustrate.DrawPolygon(pen, points);
        }

        //Overloading the Draw function with a parameter. Function to be used to draw filled shapes
        public void Draw(SolidBrush brush)
        {
            illustrate.FillPolygon(brush, points);
        }
    }
}