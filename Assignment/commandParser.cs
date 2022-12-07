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

        int errorPosition = 0;
        public commandParser(artWork myArtWork,artWork errorArtWork)
        {
           this.myArtWork = myArtWork;
           this.errorArtWork = errorArtWork;
        }

       public void runCommand(string instruction)
        {
            string[] commandSplit = instruction.Split(' ');
            string command = "";
            string[] parameter = Array.Empty<string>();
            List<string> errors = new List<string>();

            try
            {
                if (commandSplit.Length == 2)
                {
                    command = commandSplit[0];
                    parameter = commandSplit[1].Split(',');
                    List<int> checkedParameters = new List<int>();
                    int[] checkedParametersArrays = Array.Empty<int>();

                    for (int i = 0; i < parameter.Length; i++)
                    {
                        checkedParameters.Add(Int32.Parse(parameter[i]));
                    }

                    checkedParametersArrays = checkedParameters.ToArray();

                    if (command.Equals("drawto") == true)
                    {
                        if (checkedParametersArrays.Length != 2)
                        {
                            throw new ArgumentException();
                        }
                        myArtWork.drawLine(checkedParametersArrays[0], checkedParametersArrays[1]);

                    }

                    if (command.Equals("circle") == true)
                    {
                        if (checkedParametersArrays.Length != 1)
                        {
                            throw new ArgumentException();
                        }
                        myArtWork.drawCircle(checkedParametersArrays[0]);
                    }

                    if(command.Equals("rectangle") == true)
                    {
                        if(checkedParametersArrays.Length != 2)
                        {
                            throw new ArgumentException();
                        }
                        myArtWork.drawRectangle(checkedParametersArrays[0], checkedParametersArrays[1]);
                    }

                    if(command.Equals("triangle") == true)
                    {
                        if(checkedParametersArrays.Length != 5)
                        {
                            throw new ArgumentException();
                        }
                        Point point1 = new Point(myArtWork.Xposition, myArtWork.Yposition);
                        Point point2 = new Point(checkedParametersArrays[0], checkedParametersArrays[1]);
                        Point point3 = new Point(checkedParametersArrays[1], checkedParametersArrays[2]);
                        Point point4 = new Point(checkedParametersArrays[2], checkedParametersArrays[3]);
                        Point point5 = new Point(checkedParametersArrays[3], checkedParametersArrays[4]);
                        Point point6 = new Point(checkedParametersArrays[4], myArtWork.Xposition);

                        Point[] points =
                        {
                            point1, point2, point3, point4, point5, point6
                        };

                        myArtWork.drawTriangle(points);
                    }

                    if (command.Equals("moveto") == true)
                    {
                        if (checkedParametersArrays.Length != 2)
                        {
                            throw new ArgumentException();
                        }
                        myArtWork.moveTo(checkedParametersArrays[0], checkedParametersArrays[1]);
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
                    errorPosition = errorPosition + 50;
                }
            }
        }
    }
}
