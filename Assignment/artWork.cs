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
        int xPosition, yPosition;

        public artWork(Graphics g)
        {
            this.illustrate = g;
            xPosition = yPosition = 0;
            pen = new Pen(Color.Black, 1);
        }

        public void DrawLine(int xPos, int yPos)
        {
            illustrate.DrawLine(pen, xPosition, yPosition, xPos, yPos);
            xPosition = xPos;
            yPosition = yPos;
        }

        public void DrawSquare(int size)
        {
            illustrate.DrawRectangle(pen, xPosition, yPosition, xPosition + size, yPosition + size);
        }

    }
}
