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
 
            (shape.drawLine(pen, xPosition, yPosition, xPos, yPos)).Draw();
            xPosition = xPos;
            yPosition = yPos;
        }

        public void drawSquare(int size)
        {

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
           
            if (fill)
            {
                (shape.drawTriangle(pen, Points)).Draw(drawBrush);
            }
            else
            {
                (shape.drawTriangle(pen, Points)).Draw();
            }

        }

        public void moveTo(int positionX, int positionY)
        {
            this.xPosition = positionX;
            this.yPosition = positionY;
        }

        public void clear()
        {
            illustrate.Clear(Color.White);
        }

        public void reset()
        {
            this.xPosition = 0;
            this.yPosition = 0;
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
