using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment
{
    public class ArtWork
    {
        //Declaring variables
        Pen pen = new Pen(Color.Black, 1);
        Graphics illustrate;
        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        public Boolean fill = false;
        ShapeFactory shape;

        public int xPosition, yPosition;

        public List<KeyValuePair<Shape,Tuple<bool,Pen>>> shapes = new List<KeyValuePair<Shape,Tuple<bool, Pen>>>();

        public void AddShape(Shape shape)
        {
            shapes.Add(new KeyValuePair<Shape,Tuple<bool,Pen>>(shape,new Tuple<bool,Pen>(fill,pen)));
        }

        public Iterator CreateIterator()
        {
            return new ArtWorkIterator(this);
        }

        public ArtWork() { }

        // Constructor of ArtWork class which takes a Graphics object as the parameter
        public ArtWork(Graphics g)
        {
            this.illustrate = g;
            xPosition = yPosition = 0;
            shape = new ShapeFactory(illustrate);
        }

        //Function responsible to draw a Line
        public void drawLine(int xPos, int yPos)
        {
            /* Calling the drawLine function in the ShapeFactory class when return a Line object
            * with which we then call the Draw function inside the Line class
            */
            //(shape.drawLine(pen, xPosition, yPosition, xPos, yPos)).Draw();
            AddShape(shape.drawLine(pen, xPosition, yPosition, xPos, yPos));
            // Setting the current position to the end of the line that is generated
            xPosition = xPos;
            yPosition = yPos;
        }

        //Function responsible to draw a square
        public void drawSquare(int size)
        {
            Console.WriteLine("tHIS Square COLOR: " + pen.Color);
            AddShape(shape.drawSquare(pen, xPosition, yPosition, size));

        }

        // Function responsible to draw Circle
        public void drawCircle(int radius)
        {
            Console.WriteLine("tHIS CIRCLE COLOR: "+ pen.Color);
                AddShape(shape.drawCircle(pen, xPosition, yPosition, radius));


        }

        //Function responsible to draw rectangle
        public void drawRectangle(int width, int height)
        {
       
                AddShape(shape.drawRectangle(pen, xPosition, yPosition, width, height));


        }

        //Function responsible to draw Triangle
        public void drawTriangle(Point[] Points)
        {
           AddShape(shape.drawTriangle(pen, Points));
        }

        public void DrawNow()
        {
            Iterator iterator = CreateIterator();
            while (iterator.HasNext()){
                KeyValuePair<Shape, Tuple<bool, Pen>> kvp = (KeyValuePair<Shape, Tuple<bool, Pen>>)iterator.Next();
                Shape shape = kvp.Key;
                Tuple<bool,Pen> variables = kvp.Value;
                bool fill = variables.Item1;
                Pen pen = variables.Item2;
                this.drawBrush = new SolidBrush(pen.Color);
                Console.WriteLine("This COLOR: "+ pen.Color);
                if (fill)
                {
                    shape.Draw(drawBrush);
                }
                else
                {
                    shape.Draw();
                }

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
