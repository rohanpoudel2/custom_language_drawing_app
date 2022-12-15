﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class CommandParser
    {
        enum shapeCommands
        {
            circle,
            drawto,
            square,
            rectangle,
            triangle
        }

        enum otherCommands
        {
            reset,
            clear,
            moveto,
            pen,
            fill
        }

        ArtWork myArtWork;

        List<string> errors = new List<string>();
        int errorIndex = 0;
        public CommandParser(ArtWork myArtWork)
        {
            this.myArtWork = myArtWork;
        }

        public dynamic checkParameter(string parameter, string type)
        {

            List<string> parameters = new List<string>(parameter.Split(','));

            try
            {
                if (type == "int")
                {

                    List<int> intParams = new List<int>();

                    foreach (string parms in parameters)
                    {
                        intParams.Add(Int32.Parse(parms));

                        if (Int32.Parse(parms) < 0)
                        {
                            throw new ArgumentOutOfRangeException();
                        }

                    }

                    return intParams.ToArray();
                }
                else
                {

                    List<string> stringParams = new List<string>();

                    foreach (string parms in parameters)
                    {
                        if (parms.Any(char.IsDigit))
                        {
                            throw new ArgumentException("Parameter must be of String Type");
                        }
                        stringParams.Add(parms);
                    }

                    return stringParams.ToArray();
                }

            }
            catch (Exception e)
            {
                errors.Add(e.Message);
            }

            return "";
        }

        public void runCommand(string instruction)
        {

            errorIndex++;

            string[] commandSplit = instruction.Split(' ');
            string[] availableShapeCommands = Enum.GetNames(typeof(shapeCommands));
            string[] availableOtherCommands = Enum.GetNames(typeof(otherCommands));

            try
            {
                if (availableShapeCommands.Contains(commandSplit[0], StringComparer.OrdinalIgnoreCase))
                {
                    if (commandSplit.Length != 2)
                    {
                        throw new ArgumentException("Invalid Number of parameters");
                    }

                    if (commandSplit.Length == 2)
                    {
                        dynamic parameter;
                        string command = commandSplit[0];

                        if (command.Equals("drawto") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "int");

                            if (checkCommandLength(parameter.Length, 2))
                            {
                                myArtWork.drawLine(parameter[0], parameter[1]);
                            }
                            else
                            {
                                throw new ArgumentException("Invalid Parameter is Given for drawto");
                            }

                        }

                        if (command.Equals("square") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "int");

                            if (checkCommandLength(parameter.Length, 1))
                            {
                                myArtWork.drawSquare(parameter[0]);
                            }
                            else
                            {
                                throw new ArgumentException("Invalid Parameter is Given for square");
                            }

                        }

                        if (command.Equals("circle") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "int");

                            if (checkCommandLength(parameter.Length, 1))
                            {
                                myArtWork.drawCircle(parameter[0]);
                            }
                            else
                            {
                                throw new ArgumentException("Invalid Parameter is Given for circle");
                            }

                        }

                        if (command.Equals("rectangle") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "int");

                            if (checkCommandLength(parameter.Length, 2))
                            {
                                myArtWork.drawRectangle(parameter[0], parameter[1]);
                            }
                            else
                            {
                                throw new ArgumentException("Invalid Parameter is Given for rectangle");
                            }

                        }

                        if (command.Equals("triangle") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "int");

                            if (checkCommandLength(parameter.Length, 4))
                            {
                                Point point1 = new Point(myArtWork.Xposition, myArtWork.Yposition);
                                Point point2 = new Point(parameter[0], parameter[1]);
                                Point point3 = new Point(parameter[2], parameter[3]);

                                Point[] points =
                                {
                                point1, point2, point3
                            };

                                myArtWork.drawTriangle(points);
                            }
                            else
                            {
                                throw new ArgumentException("Invalid Parameter is Given triangle");
                            }

                        }

                    }
                }

                else if (availableOtherCommands.Contains(commandSplit[0], StringComparer.OrdinalIgnoreCase))
                {
                    dynamic parameter;
                    string command = commandSplit[0];

                    if (command.Equals("clear") == true)
                    {

                        if (checkCommandLength(commandSplit.Length, 1))
                        {
                            myArtWork.clear();
                            errors.Clear();
                        }
                        else
                        {
                            throw new ArgumentException("clear does not require parameters");
                        }

                    }

                    if (command.Equals("reset") == true)
                    {

                        if (checkCommandLength(commandSplit.Length, 1))
                        {
                            myArtWork.reset();
                        }
                        else
                        {
                            throw new ArgumentException("reset does not require parameters");
                        }

                    }

                    if (commandSplit.Length == 2)
                    {
                        if (command.Equals("moveto") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "int");

                            if (checkCommandLength(parameter.Length, 2))
                            {
                                myArtWork.moveTo(parameter[0], parameter[1]);
                            }
                            else
                            {
                                throw new ArgumentException("Invalid  Parameter is Given for moveto");
                            }

                        }

                        if (command.Equals("pen") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "string");
                            if (parameter.Length != 1)
                            {
                                throw new ArgumentException("Invalid Parameter is Given for pen");
                            }
                            myArtWork.changeColor(parameter[0]);
                            if (myArtWork.changeColor(parameter[0]) == false)
                            {
                                throw new ArgumentException("Invalid Color, Please try with new Color");
                            }
                        }

                        if (command.Equals("fill") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "string");
                            if (parameter.Length != 1)
                            {
                                throw new ArgumentException("Invalid Parameter is Given for fill");
                            }
                            if (parameter[0].Equals("on") == true || parameter[0].Equals("off") == true)
                            {
                                myArtWork.changeFill(parameter[0]);
                            }
                            else
                            {
                                throw new ArgumentException("Fill parameter must be 'on' or 'off'");
                            }

                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Command Not Available");
                }

            }
            catch (Exception e)
            {
                errors.Add("Index " + (errorIndex - 1) + ": " + e.Message);
                errors.Add("--------------------------------------");
            }
        }

        public Boolean checkCommandLength(int length, int tobeLength)
        {

            if (length != tobeLength)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void resetFill()
        {
            myArtWork.changeFill("off");
        }

        public void resetColor()
        {
            myArtWork.changeColor("black");
        }

        public List<string> showError()
        {
            errorIndex = 0;
            return errors;
        }
    }
}
