using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class commandParser
    {

        artWork myArtWork, errorArtWork;
        List<string> errors = new List<string>();
        int errorPosition = 0;
        public commandParser(artWork myArtWork,artWork errorArtWork)
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
                            throw new ArgumentException();
                        }
                        stringParams.Add(parms);
                    }
                    return stringParams.ToArray();
                }
                
            }
            catch(Exception e) 
            {
                errors.Add(e.Message);
            }
            return "";
        }

       public void runCommand(string instruction)
        {
            string[] commandSplit = instruction.Split(' ');
            string command = "";
            dynamic parameter;
            try
            {
                if (commandSplit.Length == 2)
                {
                    command = commandSplit[0];

                    if (command.Equals("drawto") == true)
                    {
                        parameter = checkParameter(commandSplit[1], "int");
                        if (parameter.Length != 2)
                        {
                            throw new ArgumentException();
                        }
                        myArtWork.drawLine(parameter[0], parameter[1]);

                    }

                    if (command.Equals("circle") == true)
                    {
                        parameter = checkParameter(commandSplit[1], "int");
                        if (parameter.Length != 1)
                        {
                            throw new ArgumentException();
                        }
                        myArtWork.drawCircle(parameter[0]);
                    }

                    if(command.Equals("rectangle") == true)
                    {
                        parameter = checkParameter(commandSplit[1], "int");
                        if (parameter.Length != 2)
                        {
                            throw new ArgumentException();
                        }
                        myArtWork.drawRectangle(parameter[0], parameter[1]);
                    }

                    if(command.Equals("triangle") == true)
                    {
                        parameter = checkParameter(commandSplit[1], "int");
                        if (parameter.Length != 5)
                        {
                            throw new ArgumentException();
                        }
                        Point point1 = new Point(myArtWork.Xposition, myArtWork.Yposition);
                        Point point2 = new Point(parameter[0], parameter[1]);
                        Point point3 = new Point(parameter[1], parameter[2]);
                        Point point4 = new Point(parameter[2], parameter[3]);
                        Point point5 = new Point(parameter[3], parameter[4]);
                        Point point6 = new Point(parameter[4], myArtWork.Xposition);

                        Point[] points =
                        {
                            point1, point2, point3, point4, point5, point6
                        };

                        myArtWork.drawTriangle(points);
                    }

                    if (command.Equals("moveto") == true)
                    {
                        parameter = checkParameter(commandSplit[1], "int");
                        if (parameter.Length != 2)
                        {
                            throw new ArgumentException();
                        }
                        myArtWork.moveTo(parameter[0], parameter[1]);
                    }

                    if(command.Equals("pen") == true)
                    {
                        parameter = checkParameter(commandSplit[1], "string");
                        if(parameter.Length != 1)
                        {
                            throw new ArgumentException();
                        }
                        myArtWork.changeColor(parameter[0]);
                    }

                    if(command.Equals("fill") == true)
                    {
                        parameter = checkParameter(commandSplit[1], "string");
                        if (parameter.Length != 1)
                        {
                            throw new ArgumentException();
                        }
                        myArtWork.changeFill(parameter[0]);
                    }
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
