using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class CommandParser
    {
        // Declaring enumeration for available shape commands
        enum ShapeCommands
        {
            circle,
            drawto,
            square,
            rectangle,
            triangle
        }

        //Declaring enumeration for available commands apart for shape commands
        enum OtherCommands
        {
            reset,
            clear,
            moveto,
            pen,
            fill
        }

        ArtWork myArtWork;

        //Creating a new List to store the errors that might occure in scope of this class
        List<string> errors = new List<string>();

        IDictionary<string, dynamic> variable = new Dictionary<string, dynamic>(); 

        //Declaring a int variable to count the nth number of code being processed
        int errorIndex = 0;

        public CommandParser() { }

        //Constructor for CommandParser class when takes an object of ArtWork for argument
        public CommandParser(ArtWork myArtWork)
        {
            this.myArtWork = myArtWork;
        }

        /*Function with dynamic return type because the return type can be either an array of int or a string
          *This function is responsible to check if the parameters are valid or not 
        */
        public dynamic checkParameter(string parameter, string type)
        {

            List<string> parameters = new List<string>(parameter.Split(','));

            try
            {
                if (type == "int")
                {

                    List<int> intParams = new List<int>();

                    // Checking if the given parameter is a valid integer parameter
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

                    //Checking if the given parameter is a valid string parameter
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
                // If checking the parameters had thrown an error then the error is added to the global List of errors
                errors.Add(e.Message);
            }

            return "";
        }

        // Function responsible to check the command and call the appopriate function related to that command in the ArtWork class
        public void runCommand(string instruction)
        {
            // Incrementing the errorIndex as this command is called only when the user enters a code
            errorIndex++;
            string[] commandSplit;

            if (instruction.Contains('='))
            {
                commandSplit = instruction.Split('=');
                if (commandSplit[1].Length < 0)
                {
                    throw new ArgumentException("Invalid value given to the variable");
                }
                else
                {
                    if (Int32.TryParse(commandSplit[1], out int result))
                    {
                        variable.Add(commandSplit[0].Trim(), commandSplit[1]);
                    }
                    else
                    {
                        if (commandSplit[1].Contains('+'))
                        {
                            string[] newCommand = commandSplit[1].Split('+');

                            if (newCommand[0].All(char.IsDigit) && newCommand[1].All(char.IsDigit))
                            {
                                variable.Add(commandSplit[0].Trim(), Int32.Parse(newCommand[0]) + Int32.Parse(newCommand[1]));
                            }
                            else if (newCommand[0].All(char.IsDigit) && !newCommand[1].All(char.IsDigit))
                            {
                                if (variable.TryGetValue(newCommand[1], out dynamic output))
                                {
                                    variable.Add(commandSplit[0].Trim(), Int32.Parse(newCommand[0]) + Int32.Parse(output));
                                }
                                else
                                {
                                    //Throw Exception
                                }
                            }
                            else if (!newCommand[0].All(char.IsDigit) && newCommand[1].All(char.IsDigit))
                            {
                                if (variable.TryGetValue(newCommand[0], out dynamic output))
                                {
                                    variable.Add(commandSplit[0].Trim(), Int32.Parse(output) + Int32.Parse(newCommand[1]));
                                }
                                else
                                {
                                    //Throw Exception
                                }
                            }
                            else if (!newCommand[0].All(char.IsDigit) && !newCommand[1].All(char.IsDigit))
                            {
                                if (variable.TryGetValue(newCommand[0], out dynamic output))
                                {
                                    if (variable.TryGetValue(newCommand[1], out dynamic output1))
                                    {
                                        variable.Add(commandSplit[0].Trim(), Int32.Parse(output) + Int32.Parse(output1));
                                    }
                                    else
                                    {
                                        //Throw Exception
                                    }
                                }
                                else
                                {
                                    //Throw Exception
                                }
                            }
                        }
                        if (variable.TryGetValue(commandSplit[1], out dynamic value))
                        {
                            variable.Add(commandSplit[0].Trim(), value);
                        }

                    }
                    
                }
            }
            else
            {
                // Splitting the given code with the split function at a whitespace to seperate the command and the parameter
                commandSplit = instruction.Split(' ');
            }
   
            // Creating two different arrays from the enums to check if the given command is valid and available to be processed
            string[] availableShapeCommands = Enum.GetNames(typeof(ShapeCommands));
            string[] availableOtherCommands = Enum.GetNames(typeof(OtherCommands));

            try
            {
                // Runs if any shape related commands have been given
                if (availableShapeCommands.Contains(commandSplit[0], StringComparer.OrdinalIgnoreCase))
                {
                    if (commandSplit.Length != 2)
                    {
                        throw new ArgumentException("Invalid Number of parameters");
                    }

                    if (commandSplit.Length == 2)
                    {
                        dynamic parameter = "";

                        if (variable.Count == 0)
                        {
                            parameter = checkParameter(commandSplit[1], "int");
                        }
                        else
                        {
                            if (variable.TryGetValue(commandSplit[1], out dynamic value))
                            {
                                parameter = checkParameter(value.ToString(), "int");
                            }
                        }

                        // Getting the first index of the array commandSplit which is the command
                        string command = commandSplit[0];

                        if (command.Equals("drawto") == true)
                        {
                   
                            // Checking if valid number of parameters have been provided and calling appropriate methods in the ArtWork class 
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
                           
                            // Checking if valid number of parameters have been provided and calling appropriate methods in the ArtWork class 
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
                           
                            // Checking if valid number of parameters have been provided and calling appropriate methods in the ArtWork class 
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
                         
                            // Checking if valid number of parameters have been provided and calling appropriate methods in the ArtWork class 
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
                           
                            // Checking if valid number of parameters have been provided and calling appropriate methods in the ArtWork class 
                            if (checkCommandLength(parameter.Length, 4))
                            {
                                Point point1 = new Point(myArtWork.xPosition, myArtWork.yPosition);
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
                // Runs if any non shape related commands has been given
                else if (availableOtherCommands.Contains(commandSplit[0], StringComparer.OrdinalIgnoreCase))
                {
                    dynamic parameter;
                    string command = commandSplit[0];

                    if (command.Equals("clear") == true)
                    {
                        // Checking if valid number of parameters have been provided and calling appropriate methods in the ArtWork class 
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
                        // Checking if valid number of parameters have been provided and calling appropriate methods in the ArtWork class 
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

                            // Checking if valid number of parameters have been provided and calling appropriate methods in the ArtWork class 
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
                            // Calling the checkParameter to check if the parametes is a valid string
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
                            // Calling the checkParameter to check if the parametes is a valid string
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

        public void clearVariables()
        {
            variable.Clear();
        }

        //Function responsible to check the Length of the parameter
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

        //Function responsible to reset the Fill to off
        public void resetFill()
        {
            myArtWork.changeFill("off");
        }

        //Function responsible to reset the color to black
        public void resetColor()
        {
            myArtWork.changeColor("black");
        }

        //Function responsible to return errors List
        public List<string> showError()
        {
            errorIndex = 0;
            return errors;
        }
    }
}
