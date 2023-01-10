using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class ArtWork
    {
        //Declaring variables
        Pen pen;
        Graphics illustrate;
        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        public Boolean fill = false;
        ShapeFactory shape;

        public int xPosition, yPosition;

        public ArtWork() { }

        // Constructor of ArtWork class which takes a Graphics object as the parameter
        public ArtWork(Graphics g)
        {
            this.illustrate = g;
            xPosition = yPosition = 0;
            pen = new Pen(Color.Black, 1);
            shape = new ShapeFactory(illustrate);
        }

        //Function responsible to draw a Line
        public void drawLine(int xPos, int yPos)
        {
            /* Calling the drawLine function in the ShapeFactory class when return a Line object
            * with which we then call the Draw function inside the Line class
            */
            (shape.drawLine(pen, xPosition, yPosition, xPos, yPos)).Draw();
            
            // Setting the current position to the end of the line that is generated
            xPosition = xPos;
            yPosition = yPos;
        }

        //Function responsible to draw a square
        public void drawSquare(int size)
        {
            //Checking the state of fill
            if (fill)
            {
                //If fill is on then the brush required by the Fill(Shape) function is passed on to the Draw function 
                (shape.drawSquare(pen, xPosition, yPosition, size)).Draw(drawBrush);
            }
            else
            {
                //If fill is off then the Draw function is called without any parameters being passed
                (shape.drawSquare(pen, xPosition, yPosition, size)).Draw();
            }
        }

        // Function responsible to draw Circle
        public void drawCircle(int radius)
        {
            //Checking the state of fill
            if (fill)
            {
                //If fill is on then the brush required by the Fill(Shape) function is passed on to the Draw function 
                (shape.drawCircle(pen, xPosition, yPosition, radius)).Draw(drawBrush);
            }
            else
            {
                //If fill is off then the Draw function is called without any parameters being passed
                (shape.drawCircle(pen, xPosition, yPosition, radius)).Draw();
            }

        }

        //Function responsible to draw rectangle
        public void drawRectangle(int width, int height)
        {
            //Checking the state of fill
            if (fill)
            {
                //If fill is on then the brush required by the Fill(Shape) function is passed on to the Draw function 
                (shape.drawRectangle(pen, xPosition, yPosition, width, height)).Draw(drawBrush);
            }
            else
            {
                //If fill is off then the Draw function is called without any parameters being passed
                (shape.drawRectangle(pen, xPosition, yPosition, width, height)).Draw();
            }

        }

        //Function responsible to draw Triangle
        public void drawTriangle(Point[] Points)
        {
            //Checking the state of fill
            if (fill)
            {
                //If fill is on then the brush required by the Fill(Shape) function is passed on to the Draw function 
                (shape.drawTriangle(pen, Points)).Draw(drawBrush);
            }
            else
            {
                //If fill is off then the Draw function is called without any parameters being passed
                (shape.drawTriangle(pen, Points)).Draw();
            }

        }

        //Function responsible to move the current position
        public void moveTo(int positionX, int positionY)
        {
            // Assigning the new positions passed on to the function to the current positions
            this.xPosition = positionX;
            this.yPosition = positionY;
        }

        // Function responsible to clear the current PictureOutput
        public void clear()
        {
            illustrate.Clear(Color.White);
        }

        //Function responsible to reset the current positions to 0,0
        public void reset()
        {
            this.xPosition = 0;
            this.yPosition = 0;
        }

        //Function responsible to change the color of the Pen
        public Boolean changeColor(string colour)
        {
            Color newColor = Color.FromName(colour);
            
            //Checking if the given color is a valid color or not
            if(newColor.IsKnownColor == false) {
                return false;
            }
            else
            {
                //If the color is valid then the pen and brush are assigned the same color
                drawBrush = new SolidBrush(newColor);
                pen = new Pen(newColor, 2);
                return true;
            }
            
        }

        // Function responsible to change the fill state to on or off
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
