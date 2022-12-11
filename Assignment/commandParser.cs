using System;
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

        ArtWork myArtWork, errorArtWork;
        List<string> errors = new List<string>();
        int errorPosition = 0;
        public CommandParser(ArtWork myArtWork,ArtWork errorArtWork)
        {
           this.myArtWork = myArtWork;
           this.errorArtWork = errorArtWork;
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
            catch(Exception e) 
            {
                errors.Add(e.Message);
                throw new ArgumentException("Parameter must be a Number");
            }
            return new ArgumentException("Please try again !");
        }

       public void runCommand(string instruction)
        {
            string[] commandSplit = instruction.Split(' ');

            string[] availableShapeCommands = Enum.GetNames(typeof(shapeCommands));
            string[] availableOtherCommands = Enum.GetNames(typeof(otherCommands));
            Console.WriteLine(commandSplit[0]);
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
                            if (parameter.Length != 2)
                            {
                                throw new ArgumentException("Invalid Number of Parameter is Given");
                            }
                            myArtWork.drawLine(parameter[0], parameter[1]);

                        }

                        if(command.Equals("square") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "int");
                            if(parameter.Length != 1)
                            {
                                throw new ArgumentException("Invalid Number of Parameter is Given");
                            }
                            myArtWork.drawSquare(parameter[0]);
                        }

                        if (command.Equals("circle") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "int");
                            if (parameter.Length != 1)
                            {
                                throw new ArgumentException("Invalid Number of Parameter is Given");
                            }
                            myArtWork.drawCircle(parameter[0]);
                        }

                        if(command.Equals("rectangle") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "int");
                            if (parameter.Length != 2)
                            {
                                throw new ArgumentException("Invalid Number of Parameter is Given");
                            }
                            myArtWork.drawRectangle(parameter[0], parameter[1]);
                        }

                        if(command.Equals("triangle") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "int");
                            if (parameter.Length != 4)
                            {
                                throw new ArgumentException("Invalid Number of Parameter is Given");
                            }

                            Point point1 = new Point(myArtWork.Xposition, myArtWork.Yposition);
                            Point point2 = new Point(parameter[0], parameter[1]);
                            Point point3 = new Point(parameter[2], parameter[3]);

                            Point[] points =
                            {
                                point1, point2, point3
                            };

                            myArtWork.drawTriangle(points);
                        }

                    }
                }
                else if (availableOtherCommands.Contains(commandSplit[0], StringComparer.OrdinalIgnoreCase))
                {
                    dynamic parameter;
                    string command = commandSplit[0];
                    if (commandSplit.Length != 2)
                    {
                        throw new ArgumentException("Invalid Number of parameters");
                    }
                    if (commandSplit.Length == 2)
                    {
                        if (command.Equals("moveto") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "int");
                            if (parameter.Length != 2)
                            {
                                throw new ArgumentException("Invalid Number of Parameter is Given");
                            }
                            myArtWork.moveTo(parameter[0], parameter[1]);
                        }

                        if (command.Equals("pen") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "string");
                            if (parameter.Length != 1)
                            {
                                throw new ArgumentException("Invalid Number of Parameter is Given");
                            }
                            myArtWork.changeColor(parameter[0]);
                        }

                        if (command.Equals("fill") == true)
                        {
                            parameter = checkParameter(commandSplit[1], "string");
                            if (parameter.Length != 1)
                            {
                                throw new ArgumentException("Not Enough Parameter is Given");
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
                errors.Add(e.Message);
            }
            finally
            {
                int x = 0;
                foreach (string error in errors)
                {
                    Console.WriteLine(error);
                    errorArtWork.showError(error, x, errorPosition);
                    errorPosition = errorPosition + 30;
                }
                errorPosition = 0;
                errors.Clear();
            }
        }
    }
}
