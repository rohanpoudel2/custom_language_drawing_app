using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class ArtWork
    {
        Pen pen;
        Graphics illustrate;
        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Boolean fill = false;
        ShapeFactory shape;

        private int xPosition, yPosition;
        public int Xposition
        {
            get; set;
        }
        public int Yposition
        {
            get; set;
        }

        public ArtWork(Graphics g)
        {
            this.illustrate = g;
            xPosition = yPosition = 0;
            pen = new Pen(Color.Black, 1);
            shape = new ShapeFactory(illustrate);
        }

        public void drawLine(int xPos, int yPos)
        {
            //illustrate.DrawLine(pen, xPosition, yPosition, xPos, yPos);
            (shape.drawLine(pen, xPosition, yPosition, xPos, yPos)).Draw();
            xPosition = xPos;
            yPosition = yPos;
        }

        public void drawSquare(int size)
        {
            //illustrate.DrawRectangle(pen, xPosition, yPosition, xPosition + size, yPosition + size);

            if (fill)
            {
                (shape.drawSquare(pen, xPosition, yPosition, size)).Draw(drawBrush);
            }
            else
            {
                (shape.drawSquare(pen, xPosition, yPosition, size)).Draw();
            }
        }

        public void drawCircle(int radius)
        {
            //illustrate.DrawEllipse(pen, xPosition, yPosition, xPosition + (radius * 2), yPosition + (radius * 2));
            if (fill)
            {
                (shape.drawCircle(pen, xPosition, yPosition, radius)).Draw(drawBrush);
            }
            else
            {
                (shape.drawCircle(pen, xPosition, yPosition, radius)).Draw();
            }

        }

        public void drawRectangle(int width, int height)
        {
            //illustrate.DrawRectangle(pen, xPosition, yPosition, width, height );
            if (fill)
            {
                (shape.drawRectangle(pen, xPosition, yPosition, width, height)).Draw(drawBrush);
            }
            else
            {
                (shape.drawRectangle(pen, xPosition, yPosition, width, height)).Draw();
            }

        }

        public void drawTriangle(Point[] Points)
        {
            //illustrate.DrawPolygon(pen, Points);
            if (fill)
            {
                (shape.drawTriangle(pen, Points)).Draw(drawBrush);
            }
            else
            {
                (shape.drawTriangle(pen, Points)).Draw();
            }

        }

        public void showError(string error, int positionX, int positionY)
        {
            illustrate.DrawString(error, drawFont, drawBrush, positionX, positionY);
        }

        public void moveTo(int positionX, int positionY)
        {
            this.xPosition = positionX;
            this.yPosition = positionY;
            drawPosition(positionX, positionY );
        }

        public void drawPosition(int x, int y)
        {
            const int radius = 4;
            Pen Positionpen = new Pen(Color.Red, 2);

            illustrate.DrawEllipse(Positionpen, x, y, radius, radius);
        }

        public void changeColor(string colour)
        {
            Color newColor = Color.FromName(colour);
            drawBrush = new SolidBrush(newColor);
            pen = new Pen(newColor, 2);
        }

        public void changeFill(string fill)
        {
            if (fill.Equals("on"))
            {
                this.fill = true;
            }
            else if (fill.Equals("off"))
            {
                this.fill = false;
            }
        }



    }
}
