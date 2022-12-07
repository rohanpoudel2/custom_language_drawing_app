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
        int xPosition, yPosition;

        public artWork(Graphics g)
        {
            this.illustrate = g;
            xPosition = yPosition = 0;
            pen = new Pen(Color.Black, 1);
            drawPosition();
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

        public void showError(string error, int positionX, int positionY)
        {
            illustrate.DrawString(error, drawFont, drawBrush, positionX, positionY);
        }

        public void moveTo(int positionX, int positionY)
        {
            this.xPosition = positionX;
            this.yPosition = positionY;
            drawPosition();
        }

        public void drawPosition()
        {
            const int radius = 4;
            pen = new Pen(Color.Red, 2);
            illustrate.DrawEllipse(pen, xPosition, yPosition, radius, radius);
        }

    }
}
