﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    interface Shapes
    {
        Circle drawCircle(Pen pen, int xPosition, int yPosition, int radius);
        Rectanglee drawRectangle(Pen pen, int xPosition, int yPosition, int width, int height);
        Triangle drawTriangle(Pen pen, Point[] points);
        Square drawSquare(Pen pen, int xPosition, int yPosition, int size);
        Line drawLine(Pen pen, int xPosition, int yPosition, int toXPosition, int toYPosition);
    }
}
