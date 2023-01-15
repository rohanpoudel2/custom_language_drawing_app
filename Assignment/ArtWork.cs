using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment
{
    /// <summary>
    /// The ArtWork class is responsible for creating and drawing various shapes on the output screen, such as lines, squares, circles, rectangles, and triangles.
    /// It also contains various properties and methods for managing the state of the drawn shapes, such as fill, pen, and position.
    /// <remarks>
    /// <para>
    /// The class contains a ReaderWriterLockSlim object called '_rwLock' which is used to provide thread-safety while accessing the list of shapes.
    /// </para>
    /// </remarks>
    /// </summary>
    public class ArtWork
    {
        /// <summary>
        /// The pen used to draw the shapes
        /// </summary>
        Pen pen = new Pen(Color.Black, 1);

        /// <summary>
        /// The graphics object used to draw the shapes
        /// </summary>
        Graphics illustrate;

        /// <summary>
        /// The font used for text
        /// </summary>
        Font drawFont = new Font("Arial", 16);

        /// <summary>
        /// The brush used to fill in shapes
        /// </summary>
        SolidBrush drawBrush = new SolidBrush(Color.Black);

        /// <summary>
        /// Indicates if the shape should be filled or not
        /// </summary>
        public Boolean fill = false;

        /// <summary>
        /// The shape factory object used to create shapes
        /// </summary>
        ShapeFactory shape;

        /// <summary>
        /// A lock used to ensure thread safety
        /// </summary>
        private readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();

        /// <summary>
        /// The current x and y positions
        /// </summary>
        public int xPosition, yPosition;

        /// <summary>
        /// A list of all the shapes drawn, along with their fill and pen properties
        /// </summary>
        public List<KeyValuePair<Shape, Tuple<bool, Pen>>> shapes = new List<KeyValuePair<Shape, Tuple<bool, Pen>>>();

        /// <summary>
        /// Add a shape object to the list of shapes
        /// </summary>
        /// <param name="shape">The shape object to be added to the list</param>
        public void AddShape(Shape shape)
        {
            shapes.Add(new KeyValuePair<Shape, Tuple<bool, Pen>>(shape, new Tuple<bool, Pen>(fill, pen)));
        }
        /// <summary>
        /// Create and return an iterator for the list of shapes
        /// </summary>
        /// <returns>An iterator for the list of shapes</returns>
        public Iterator CreateIterator()
        {
            return new ArtWorkIterator(this);
        }

        /// <summary>
        /// Default constructor for the ArtWork class
        /// </summary>
        public ArtWork() { }

        /// <summary>
        /// Constructor of ArtWork class which takes a Graphics object as the parameter
        /// </summary>
        /// <param name="g">A Graphics object used to draw shapes</param>
        public ArtWork(Graphics g)
        {
            this.illustrate = g;
            xPosition = yPosition = 0;
            shape = new ShapeFactory(illustrate);
        }


        /// <summary>
        /// Method responsible for creating a line and adding it to the list of shapes.
        /// </summary>
        /// <param name="xPos">The x-coordinate of the end point of the line.</param>
        /// <param name="yPos">The y-coordinate of the end point of the line.</param>
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

        /// <summary>
        /// This method is responsible for creating a square and adding it to the list of shapes.
        /// </summary>
        /// <param name="size">The size of the square</param>
        public void drawSquare(int size)
        {
            Console.WriteLine("tHIS Square COLOR: " + pen.Color);
            AddShape(shape.drawSquare(pen, xPosition, yPosition, size));
        }


        /// <summary>
        /// This method is responsible for creating a circle and adding it to the list of shapes.
        /// </summary>
        /// <param name="radius">The radius of the circle</param>
        public void drawCircle(int radius)
        {
            Console.WriteLine("tHIS CIRCLE COLOR: "+ pen.Color);
                AddShape(shape.drawCircle(pen, xPosition, yPosition, radius));


        }

        /// <summary>
        /// This method is responsible for creating a rectangle and adding it to the list of shapes.
        /// </summary>
        /// <param name="width">The width of the rectangle</param>
        /// <param name="height">The height of the rectangle</param>
        public void drawRectangle(int width, int height)
        {
       
                AddShape(shape.drawRectangle(pen, xPosition, yPosition, width, height));


        }

        /// <summary>
        /// This method is responsible for creating a triangle and adding it to the list of shapes.
        /// </summary>
        /// <param name="Points">The points for the triangle</param>
        public void drawTriangle(Point[] Points)
        {
           AddShape(shape.drawTriangle(pen, Points));
        }

        /// <summary>
        /// This method is responsible for creating a Star and adding it to the list of shapes.
        /// </summary>
        /// <param name="Points">The points for the Star</param>
        public void drawStar(Point[] Points)
        {
            AddShape(shape.drawStar(pen, Points));
        }

        /// <summary>
        /// Draws all the shapes in the shapes list.
        /// </summary>
        /// <remarks>
        /// This method uses a <see cref="ReaderWriterLockSlim"/> to ensure thread safety while iterating through the shapes list and drawing them.
        /// It also checks the fill status of each shape and calls the appropriate Draw method on the shape.
        /// </remarks>
        public void DrawNow()
        {
            _rwLock.EnterReadLock();
            try
            {
                Iterator iterator = CreateIterator();
                while (iterator.HasNext())
                {
                    KeyValuePair<Shape, Tuple<bool, Pen>> kvp = (KeyValuePair<Shape, Tuple<bool, Pen>>)iterator.Next();
                    Shape shape = kvp.Key;
                    Tuple<bool, Pen> variables = kvp.Value;
                    bool fill = variables.Item1;
                    Pen pen = variables.Item2;
                    this.drawBrush = new SolidBrush(pen.Color);
                    Console.WriteLine("This COLOR: " + pen.Color);
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
            finally
            {
                _rwLock.ExitReadLock();
            }
        }


        /// <summary>
        /// This method is responsible for moving the position at which the shapes are to be drawn.
        /// </summary>
        /// <param name="positionX">The x-coordinate position</param>
        /// <param name="positionY">The y-coordinate position</param>
        public void moveTo(int positionX, int positionY)
        {
            // Assigning the new positions passed on to the function to the current positions
            this.xPosition = positionX;
            this.yPosition = positionY;
        }

        /// <summary>
        /// This method is responsible clear the current output screen with white color.
        /// </summary>
        public void clear()
        {
            illustrate.Clear(Color.White);
        }

        /// <summary>
        /// This method is responsible to reset the `xPosition` and `yPosition` back to 0,0.
        /// </summary>
        public void reset()
        {
            this.xPosition = 0;
            this.yPosition = 0;
        }

        /// <summary>
        /// Function to change the color of the pen and brush.
        /// </summary>
        /// <param name="colour">The name of the color to be used.</param>
        /// <returns>Returns true if the color is valid, false otherwise.</returns>
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

        /// <summary>
        /// Changes the fill property of the shape being drawn.
        /// </summary>
        /// <param name="fill">A string value representing the fill property, "on" for filled shape, "off" for non-filled shape</param>
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
