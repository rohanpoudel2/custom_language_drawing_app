using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public abstract class BasicShape
    {
        //Declaring basic variables needed to create a shape
        protected Pen pen;
        protected Graphics illustrate;
        protected int xPosition, yPosition;

        //Constructor of BasicShape class which takes some arguments to assign it to the class level variables declared above
        protected BasicShape(Pen pen, Graphics illustrate, int xPosition, int yPosition)
        {
            this.pen = pen;
            this.illustrate= illustrate;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }
    }
}
