using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class artWork
    {
        Pen pen;
        Graphics illustrate;
        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        private int xPosition, yPosition;
        public int Xposition
        {
            get; set;
        }
        public int Yposition
        {
            get; set;
        }

        public artWork(Graphics g)
        {
            this.illustrate = g;
            xPosition = yPosition = 0;
            pen = new Pen(Color.Black, 1);
            drawPosition(xPosition, yPosition);
        }

        public void drawLine(int xPos, int yPos)
        {
            illustrate.DrawLine(pen, xPosition, yPosition, xPos, yPos);
            xPosition = xPos;
            yPosition = yPos;
        }

        public void drawSquare(int size)
        {
            illustrate.DrawRectangle(pen, xPosition, yPosition, xPosition + size, yPosition + size);
        }

        public void drawCircle(int radius)
        {
            illustrate.DrawEllipse(pen, xPosition, yPosition, xPosition + (radius * 2), yPosition + (radius * 2));
        }

        public void drawRectangle(int width, int height)
        {
            illustrate.DrawRectangle(pen, xPosition, yPosition, width, height );
        }

        public void drawTriangle(Point[] Points)
        {
            illustrate.DrawPolygon(pen, Points);
        }

        public void showError(string error, int positionX, int positionY)
        {
            illustrate.DrawString(error, drawFont, drawBrush, positionX, positionY);
        }

        public void moveTo(int positionX, int positionY)
        {
            this.xPosition = positionX;
            this.yPosition = positionY;
            drawPosition(positionX, positionY);
        }

        public void drawPosition(int x, int y)
        {
            const int radius = 4;
            pen = new Pen(Color.Red, 2);
            illustrate.DrawEllipse(pen, x, y, radius, radius);
        }



    }
}
