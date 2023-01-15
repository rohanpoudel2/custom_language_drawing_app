using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment
{
    /// <summary>
    /// The CommandParser class is responsible for parsing and executing the commands provided by the user.
    /// It contains methods to assign variables, check syntax, execute shape commands, handle loops and conditions, and more.
    /// </summary>
    public class CommandParser
    {
        /// <summary>
        /// The `ShapeCommands` enumeration defines a list of possible shape commands that can be used in the application.
        /// The enumeration contains the following values: circle, drawto, square, rectangle, and triangle.
        /// </summary>
        enum ShapeCommands
        {
            circle,
            drawto,
            square,
            rectangle,
            triangle,
            star
        }

        /// <summary>
        /// The `OtherCommands` enumeration defines a list of possible other commands that can be used in the application.
        /// The enumeration contains the following values: reset, clear, moveto, pen, fill, and flash.
        /// </summary>
        enum OtherCommands
        {
            reset,
            clear,
            moveto,
            pen,
            fill,
            flash
        }

        /// <summary>
        /// The `myArtWork` variable is an instance of the `ArtWork` class that holds the information and methods related to the artwork being drawn.
        /// </summary>
        ArtWork myArtWork;

        /// <summary>
        /// The `commandSplit` variable is a string array that is used to store the results of splitting a command string into individual elements.
        /// </summary>
        string[] commandSplit;

        /// <summary>
        /// The `parameter` variable holds the parameter of a command.
        /// </summary>
        dynamic parameter = "";

        /// <summary>
        /// The `errors` list holds the errors that occur during the parsing of the commands.
        /// </summary>
        List<string> errors = new List<string>();

        /// <summary>
        /// The `variable` dictionary holds the user-defined variables and their values.
        /// </summary>
        IDictionary<string, dynamic> variable = new Dictionary<string, dynamic>();

        /// <summary>
        /// The `validLoop` variable indicates if the current loop statement is valid.
        /// </summary>
        bool validLoop;

        /// <summary>
        /// The `inLoop` variable indicates if the parser is currently inside a loop block.
        /// </summary>
        bool inLoop;

        /// <summary>
        /// The `loopInterval` variable holds the interval at which the loop block should be executed.
        /// </summary>
        int loopInterval = 0;

        /// <summary>
        /// The `loopStatement` variable holds the loop statement.
        /// </summary>
        string loopStatement;

        /// <summary>
        /// The `loopCommands` list holds the commands that should be executed in the loop block.
        /// </summary>
        List<string> loopCommands = new List<string>();

        /// <summary>
        /// The `loopCount` variable holds the number of times the loop block has been executed.
        /// </summary>
        int loopCount = 0;

        /// <summary>
        /// The `ifCount` variable holds the number of if blocks encountered.
        /// </summary>
        int ifCount = 0;

        /// <summary>
        /// The `inCondition` variable indicates if the parser is currently inside an if block.
        /// </summary>
        bool inCondition;

        /// <summary>
        /// The `validIf` variable indicates if the current if statement is valid.
        /// </summary>
        bool validIf;

        /// <summary>
        /// The `conditionCommands` list holds the commands that should be executed in the if block.
        ///</summary>
        List<string> conditionCommands = new List<string>();

        /// <summary>
        /// The `methodCount` variable holds the number of method blocks encountered.
        /// </summary>
        int methodCount = 0;

        /// <summary>
        /// The `inMethod` variable indicates if the parser is currently inside a method block.
        /// </summary>
        bool inMethod;

        /// <summary>
        /// The `calledMethod` variable holds the name of the method that is currently being called.
        /// </summary>
        string calledMethod = "";

        /// <summary>
        /// The `methods` dictionary holds the user-defined methods and their corresponding commands.
        /// </summary>
        IDictionary<string, dynamic> methods = new Dictionary<string, dynamic>();

        /// <summary>
        /// The `methodCommands` dictionary holds the commands of the user-defined methods, keyed by method name.
        /// </summary>
        Dictionary<string, List<string>> methodCommands = new Dictionary<string, List<string>>();

        /// <summary>
        /// The `currentMethodname` variable holds the name of the current method being parsed.
        /// </summary>
        string currentMethodname = "";

        /// <summary>
        /// The `shapeCommands` list holds the shape commands that are encountered.
        /// </summary>
        List<string> shapeCommands = new List<string>();

        /// <summary>
        /// The `shapeCommandsCopy` list holds a copy of the shape commands that are encountered.
        /// </summary>
        List<string> shapeCommandsCopy = new List<string>();

        /// <summary>
        /// The `colorIndex` variable holds the index of the current color in the flashing colors array.
        /// </summary>
        int colorIndex = 0;

        /// <summary>
        /// The `flashingColors` array holds the colors that the shapes should flash between.
        /// </summary>
        string[] flashingColors;

        /// <summary>
        /// The `flashingInterval` variable holds the interval, in milliseconds, at which the shapes should flash between colors.
        /// </summary>
        int flashingInterval = 1000;

        /// <summary>
        /// The `flashStatus` variable indicates the current flash status of the shapes.
        /// </summary>
        bool flashStatus = false;

        /// <summary>
        /// The `stopFlash` variable indicates if the flash thread should stop running.
        /// </summary>
        bool stopFlash = false;

        /// <summary>
        /// The `flashShapes` variable is a thread that is responsible for flashing the shapes.
        /// </summary>
        Thread flashShapes;

        /// <summary>
        /// The `refreshMethod` variable holds a reference to a method that is responsible for refreshing the artwork.
        /// </summary>
        dynamic refreshMethod;

        /// <summary>
        /// The `errorIndex` variable holds the index of the current error encountered.
        /// </summary>
        int errorIndex = 0;

        /// <summary>
        /// The constructor of the CommandParser class which initializes an instance of ArtWork.
        /// </summary>
        /// <param name="myArtWork">An instance of the ArtWork class.</param>
        public CommandParser(ArtWork myArtWork)
        {
            this.myArtWork = myArtWork;
        }

        /// <summary>
        /// The `checkParameter` method is used to check the validity of a given parameter and convert it to the specified type.
        /// </summary>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <param name="type">The type of the parameter. Can be either "int" or "string".</param>
        /// <returns>An array of the converted parameter or an exception if the parameter is invalid.</returns>
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
                            throw new CustomParameterException("Parameter is out of range. Please give a value that is 0 or more");
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
                            throw new CustomParameterException("Parameter must be of String Type. Please give a parameter of type string");
                        }
                        stringParams.Add(parms);
                    }

                    return stringParams.ToArray();
                }

            }
            catch (Exception e)
            {
                // If checking the parameters had thrown an error then the error is added to the global List of errors
                return e;
            }
        }

        /// <summary>
        /// Runs the command passed in the instruction parameter.
        /// It splits the instruction by space and checks for the first word of the command.
        /// It checks if the command is a valid shape command or other command and processes it accordingly.
        /// It also checks if the command is being run inside a loop, condition or a method and processes it accordingly.
        /// It also starts a new thread to flash the shapes that have been drawn.
        /// </summary>
        /// <param name="instruction">The instruction to be run as a command.</param>
        public void runCommand(string instruction)
        {
            Console.WriteLine("This: " + instruction);
            try
            {
                errorIndex++;
                commandSplit = instruction.Split(' ');

                //FOR LOOP

                if (commandSplit[0].Contains("while"))
                {
                    string[] loopCondition;
                    loopStatement = "while " + commandSplit[1];
                    string operatorr = "";

                    if (loopCount == 0)
                    {
                        inLoop = true;
                    }
                    loopCount++;

                    List<string> loopOperands = new List<string>();
                    if (commandSplit[1].Contains('<') && !commandSplit[1].Contains("<="))
                    {
                        loopCondition = commandSplit[1].Split('<');
                        operatorr = "<";
                    }
                    else if (commandSplit[1].Contains('>') && !commandSplit[1].Contains(">="))
                    {
                        loopCondition = commandSplit[1].Split('>');
                        operatorr = ">";
                    }
                    else if (commandSplit[1].Contains("<="))
                    {
                        loopCondition = commandSplit[1].Split(new string[] { "<=" }, StringSplitOptions.None);
                        operatorr = "<=";
                    }
                    else if (commandSplit[1].Contains(">="))
                    {
                        loopCondition = commandSplit[1].Split(new string[] { ">=" }, StringSplitOptions.None);
                        operatorr = ">=";
                    }
                    else
                    {
                        throw new ArgumentException("expression not supported");
                    }

                    foreach (string operand in loopCondition)
                    {
                        if (operand.All(char.IsDigit))
                        {
                            loopOperands.Add(operand);
                        }
                        else
                        {
                            if (variable.TryGetValue(operand, out dynamic value))
                            {
                                loopOperands.Add(value);
                            }
                            else
                            {
                                throw new ArgumentException("variable not available");
                            }
                        }
                    }

                    if (operatorr.Equals("<"))
                    {
                        if (int.Parse(loopOperands[0]) < int.Parse(loopOperands[1]))
                        {
                            if (loopInterval == 0)
                            {
                                loopInterval = int.Parse(loopOperands[1]) - int.Parse(loopOperands[0]);
                            }

                            validLoop = true;
                        }
                        else
                        {
                            validLoop = false;
                        }
                    }
                    else if (operatorr.Equals(">"))
                    {
                        if (int.Parse(loopOperands[0]) > int.Parse(loopOperands[1]))
                        {
                            if (loopInterval == 0)
                            {
                                loopInterval = int.Parse(loopOperands[0]) - int.Parse(loopOperands[1]);
                            }
                            validLoop = true;
                        }
                        else
                        {
                            validLoop = false;
                        }
                    }
                    else if (operatorr.Equals("<="))
                    {
                        if (int.Parse(loopOperands[0]) <= int.Parse(loopOperands[1]))
                        {
                            if (loopInterval == 0)
                            {
                                loopInterval = (int.Parse(loopOperands[1]) - int.Parse(loopOperands[0])) + 1;
                            }
                            validLoop = true;
                        }
                        else
                        {
                            validLoop = false;
                        }
                    }
                    else if (operatorr.Equals(">="))
                    {
                        if (int.Parse(loopOperands[0]) >= int.Parse(loopOperands[1]))
                        {
                            if (loopInterval == 0)
                            {
                                loopInterval = (int.Parse(loopOperands[0]) - int.Parse(loopOperands[1])) + 1;
                            }
                            validLoop = true;
                        }
                        else
                        {
                            validLoop = false;
                        }
                    }
                }

                if (commandSplit[0].Contains("endloop"))
                {
                    for (int i = 0; i <= loopInterval; i++)
                    {
                        inLoop = false;
                        errorIndex--;
                        foreach (string command in loopCommands)
                        {
                            if (command.Contains("="))
                            {
                                assignVariables(command);
                            }
                            if (validLoop)
                            {
                                runCommand(command);
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (!validLoop)
                        {
                            break;
                        }
                    }
                }

                //For IF

                if (commandSplit[0].Contains("if") && commandSplit[0].IndexOf("endif") == -1)
                {
                    string[] ifCondition;
                    string operatorr = "";
                    if (ifCount == 0)
                    {
                        inCondition = true;
                    }
                    ifCount++;

                    List<string> ifOperands = new List<string>();
                    if (commandSplit[1].Contains('<') && !commandSplit[1].Contains("<="))
                    {
                        ifCondition = commandSplit[1].Split('<');
                        operatorr = "<";
                    }
                    else if (commandSplit[1].Contains('>') && !commandSplit[1].Contains(">="))
                    {
                        ifCondition = commandSplit[1].Split('>');
                        operatorr = ">";
                    }
                    else if (commandSplit[1].Contains("=="))
                    {
                        ifCondition = commandSplit[1].Split(new string[] { "==" }, StringSplitOptions.None);
                        operatorr = "==";
                    }
                    else if (commandSplit[1].Contains("<="))
                    {
                        ifCondition = commandSplit[1].Split(new string[] { "<=" }, StringSplitOptions.None);
                        operatorr = "<=";
                    }
                    else if (commandSplit[1].Contains(">="))
                    {
                        ifCondition = commandSplit[1].Split(new string[] { ">=" }, StringSplitOptions.None);
                        operatorr = ">=";
                    }
                    else
                    {
                        throw new ArgumentException("expression not supported");
                    }

                    foreach (string operand in ifCondition)
                    {

                        if (operand.All(char.IsDigit))
                        {
                            ifOperands.Add(operand);
                        }
                        else
                        {
                            if (variable.TryGetValue(operand, out dynamic value))
                            {
                                ifOperands.Add(value);
                            }
                            else
                            {
                                throw new ArgumentException("variable not available");
                            }
                        }
                    }

                    if (operatorr.Equals("<"))
                    {
                        if (int.Parse(ifOperands[0]) < int.Parse(ifOperands[1]))
                        {
                            validIf = true;
                        }
                        else
                        {
                            validIf = false;
                        }
                    }
                    else if (operatorr.Equals(">"))
                    {
                        if (int.Parse(ifOperands[1]) < int.Parse(ifOperands[0]))
                        {
                            validIf = true;
                        }
                        else
                        {
                            validIf = false;
                        }
                    }
                    else if (operatorr.Equals("=="))
                    {
                        if (int.Parse(ifOperands[0]) == int.Parse(ifOperands[1]))
                        {
                            validIf = true;
                        }
                        else
                        {
                            validIf = false;
                        }
                    }
                    else if (operatorr.Equals("<="))
                    {
                        if (int.Parse(ifOperands[0]) <= int.Parse(ifOperands[1]))
                        {
                            validIf = true;
                        }
                        else
                        {
                            validIf = false;
                        }
                    }
                    else if (operatorr.Equals(">="))
                    {
                        if (int.Parse(ifOperands[0]) >= int.Parse(ifOperands[1]))
                        {
                            validIf = true;
                        }
                        else
                        {
                            validIf = false;
                        }
                    }
                }

                if (commandSplit[0].Contains("endif"))
                {
                    inCondition = false;

                    foreach (string command in conditionCommands)
                    {
                        if (validIf)
                        {
                            runCommand(command);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                //For Method

                if (commandSplit[0].Equals("method"))
                {
                    string methodParameter;
                    string[] methodParameters;
                    string methodName;

                    if (methodCount == 0)
                    {
                        inMethod = true;
                    }
                    methodCount++;

                    int startIndex = commandSplit[1].IndexOf('(');
                    int endIndex = commandSplit[1].IndexOf(')');

                    methodName = commandSplit[1].Substring(0, startIndex);
                    currentMethodname = methodName;

                    if (methodName.All(char.IsDigit))
                    {
                        throw new CustomValueException("Please use a valid name for the method.");
                    }

                    if (startIndex == endIndex - 1)
                    {
                        methods.Add(methodName, "");
                    }
                    else
                    {
                        startIndex = startIndex + 1;
                        endIndex = endIndex - startIndex;
                        methodParameter = commandSplit[1].Substring(startIndex, endIndex);
                        methodParameters = methodParameter.Split(',');

                        foreach (string methodParam in methodParameters)
                        {
                            if (methodParam.All(char.IsDigit))
                            {
                                throw new CustomParameterException("Parameter given for the method is not valid.");
                            }
                        }

                        if (methodParameters.Length == 1)
                        {
                            methods.Add(methodName, methodParameters[0]);
                        }
                        else
                        {
                            methods.Add(methodName, methodParameters);
                        }
                    }
                }

                if (commandSplit[0].Equals("endmethod"))
                {
                    foreach (string a in methods.Keys)
                    {
                        Console.WriteLine("This is a Method: " + a);
                    }
                    inMethod = false;
                    methodCount = 0;

                    foreach (var m in methodCommands)
                    {
                        if (m.Value.Remove("method"))
                        {
                            Console.WriteLine("DONE");
                        }
                    }

                }

                if (commandSplit[0].Contains('(') && commandSplit[0].Contains(')') && !commandSplit[0].Contains("method"))
                {
                    string methodName;
                    string methodParameter;
                    string[] methodParameters;

                    bool hasMethod = false;
                    Console.WriteLine("HasMethod: " + hasMethod);
                    int startIndex = commandSplit[0].IndexOf('(');
                    int endIndex = commandSplit[0].IndexOf(')');

                    methodName = commandSplit[0].Substring(0, startIndex);
                    Console.WriteLine("This is the called method: " + methodName);
                    foreach (string method in methods.Keys)
                    {
                        Console.WriteLine("method given: " + methodName + ", method compared to: " + method);
                        if (methodName.Equals(method))
                        {
                            hasMethod = true;
                            Console.WriteLine("method: " + methods[method].Length);
                            if (startIndex == endIndex - 1 && methods[method].Length == 0)
                            {
                                foreach (string command in methodCommands.Keys)
                                {
                                    if (command.Equals(methodName))
                                    {
                                        foreach (string cmd in methodCommands[command])
                                        {
                                            runCommand(cmd);
                                        }
                                    }
                                }
                            }
                            else if (startIndex == endIndex - 1 && methods[method].Length != 0)
                            {
                                throw new CustomParameterException("Please check the parameter and try again.");
                            }
                            else
                            {
                                startIndex = startIndex + 1;
                                endIndex = endIndex - startIndex;
                                methodParameter = commandSplit[0].Substring(startIndex, endIndex);

                                methodParameters = methodParameter.Split(',');

                                if (methods[method].GetType().IsArray)
                                {
                                    string tempValue = "0";

                                    if (methodParameters.Length == methods[method].Length)
                                    {
                                        for (int i = 0; i < methodParameters.Length; i++)
                                        {
                                            if (methodParameters[i].All(char.IsDigit))
                                            {
                                                variable[methods[method][i]] = methodParameters[i];
                                            }
                                            else
                                            {
                                                foreach (string var in variable.Keys)
                                                {
                                                    if (var.Equals(methodParameters[i]))
                                                    {
                                                        tempValue = variable[var];
                                                    }
                                                }
                                                if (tempValue.Equals("0"))
                                                {
                                                    throw new CustomParameterException("Variable does not exists. Please try again.");
                                                }
                                                variable[methods[method][i]] = tempValue;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        throw new CustomParameterException("Please match the number of parameters required in the method.");
                                    }
                                }
                                else if (!string.IsNullOrEmpty(methods[method]) && methods[method] is string)
                                {
                                    string tempValue = "0";
                                    if (methodParameters.Length > 1)
                                    {
                                        throw new CustomParameterException("Method only takes one parameter");
                                    }
                                    if (methodParameters[0].All(char.IsDigit))
                                    {
                                        variable[methods[method]] = methodParameters[0];
                                    }
                                    else
                                    {
                                        foreach (string var in variable.Keys)
                                        {
                                            if (var.Equals(methodParameters[0]))
                                            {
                                                tempValue = variable[var];
                                            }
                                        }
                                        if (tempValue.Equals("0"))
                                        {
                                            throw new CustomParameterException("Variable does not exists. Please try again.");
                                        }
                                        variable[methods[method]] = tempValue;
                                    }
                                }
                                else if (string.IsNullOrEmpty(methods[method]))
                                {
                                    throw new CustomParameterException("Method does not take any parameters");
                                }


                                foreach (string command in methodCommands.Keys)
                                {
                                    if (command.Equals(methodName))
                                    {
                                        foreach (string cmd in methodCommands[command])
                                        {
                                            runCommand(cmd);
                                        }
                                    }
                                }


                            }

                        }
                        if (hasMethod)
                        {
                            break;
                        }
                    }
                    if (!hasMethod)
                    {
                        throw new MethodAccessException("Method does not exist. Please try again.");
                    }

                }

                // Creating two different arrays from the enums to check if the given command is valid and available to be processed
                string[] availableShapeCommands = Enum.GetNames(typeof(ShapeCommands));
                string[] availableOtherCommands = Enum.GetNames(typeof(OtherCommands));

                if (inLoop)
                {
                    loopCommands.Add(instruction);
                }
                else if (inCondition)
                {
                    conditionCommands.Add(instruction);
                }
                else if (inMethod)
                {
                    if (!methodCommands.ContainsKey(currentMethodname))
                    {
                        methodCommands[currentMethodname] = new List<string>();
                    }
                    else
                    {
                        methodCommands[currentMethodname].Add(instruction);
                    }
                }
                else
                {
                    // Runs if any shape related commands have been given
                    if (availableShapeCommands.Contains(commandSplit[0], StringComparer.OrdinalIgnoreCase))
                    {
                        if (variable.Count == 0)
                        {
                            parameter = checkParameter(commandSplit[1], "int");
                        }
                        else
                        {
                            if (commandSplit[1].All(char.IsDigit) || Regex.IsMatch(commandSplit[1], @"^[\d,]+$"))
                            {
                                parameter = checkParameter(commandSplit[1], "int");
                            }
                            else
                            {
                                if (commandSplit[1].Length > 1)
                                {
                                    string[] array = commandSplit[1].Split(',');
                                    string b = "";
                                    foreach (string a in array)
                                    {
                                        if (variable.TryGetValue(a, out dynamic value))
                                        {
                                            b = b + value + ",";
                                        }
                                    }
                                    b = b.Remove(b.Length - 1);
                                    parameter = checkParameter(b, "int");
                                }
                                else
                                {
                                    if ((variable.TryGetValue(commandSplit[1], out dynamic value)))
                                    {
                                        parameter = checkParameter(value.ToString(), "int");
                                    }
                                }
                            }

                        }

                        // Getting the first index of the array commandSplit which is the command
                        string command = commandSplit[0];

                        if (command.Equals("drawto") == true)
                        {
                            if (!flashStatus)
                            {
                                shapeCommands.Add(command + " " + parameter[0] + "," + parameter[1]);
                            }
                            myArtWork.drawLine(parameter[0], parameter[1]);
                        }

                        if (command.Equals("square") == true)
                        {
                            if (!flashStatus)
                            {
                                shapeCommands.Add(command + " " + parameter[0]);
                            }
                            myArtWork.drawSquare(parameter[0]);
                        }

                        if (command.Equals("circle") == true)
                        {
                            if (!flashStatus)
                            {
                                shapeCommands.Add(command + " " + parameter[0]);
                            }
                            myArtWork.drawCircle(parameter[0]);
                        }

                        if (command.Equals("rectangle") == true)
                        {
                            if (!flashStatus)
                            {
                                shapeCommands.Add(command + " " + parameter[0] + "," + parameter[1]);
                            }
                            myArtWork.drawRectangle(parameter[0], parameter[1]);

                        }

                        if (command.Equals("triangle") == true)
                        {
                            if (!flashStatus)
                            {
                                shapeCommands.Add(command + " " + parameter[0] + "," + parameter[1] + "," + parameter[2] + "," + parameter[3]);
                            }
                            Point point1 = new Point(myArtWork.xPosition, myArtWork.yPosition);
                            Point point2 = new Point(parameter[0], parameter[1]);
                            Point point3 = new Point(parameter[2], parameter[3]);

                            Point[] points = {
                               point1,
                               point2,
                               point3
                            };

                            myArtWork.drawTriangle(points);

                        }

                        if (command.Equals("star") == true)
                        {
                            if (!flashStatus)
                            {
                                shapeCommands.Add(command + " " + parameter[0]);
                            }

                            int outerRadius = parameter[0];
                            int innerRadius = outerRadius / 2;
                            Point center = new Point(myArtWork.xPosition, myArtWork.yPosition);

                            List<Point> points = new List<Point>();
                            for (int i = 0; i < 5; i++)
                            {
                                double angle = 4.0 * Math.PI * i / 5.0;
                                int x = (int)(center.X + outerRadius * Math.Cos(angle));
                                int y = (int)(center.Y + outerRadius * Math.Sin(angle));
                                points.Add(new Point(x, y));

                                angle += Math.PI / 5;
                                x = (int)(center.X + innerRadius * Math.Cos(angle));
                                y = (int)(center.Y + innerRadius * Math.Sin(angle));
                                points.Add(new Point(x, y));
                            }

                            Point[] points1 = points.ToArray();

                            myArtWork.drawStar(points1);

                        }

                    }
                    // Runs if any non shape related commands has been given
                    else if (availableOtherCommands.Contains(commandSplit[0], StringComparer.OrdinalIgnoreCase))
                    {
                        dynamic parameter;
                        string command = commandSplit[0];

                        if (command.Equals("clear") == true)
                        {

                            myArtWork.clear();
                            errors.Clear();

                        }

                        if (command.Equals("reset") == true)
                        {

                            myArtWork.reset();

                        }

                        if (commandSplit.Length == 2)
                        {
                            if (command.Equals("moveto") == true)
                            {

                                parameter = checkParameter(commandSplit[1], "int");
                                if (!flashStatus)
                                {
                                    shapeCommands.Add(command + " " + parameter[0] + "," + parameter[1]);
                                }

                                myArtWork.moveTo(parameter[0], parameter[1]);

                            }

                            if (command.Equals("pen") == true)
                            {
                                // Calling the checkParameter to check if the parametes is a valid string
                                parameter = checkParameter(commandSplit[1], "string");

                                myArtWork.changeColor(parameter[0]);

                            }

                            if (command.Equals("fill") == true)
                            {
                                // Calling the checkParameter to check if the parametes is a valid string
                                parameter = checkParameter(commandSplit[1], "string");

                                myArtWork.changeFill(parameter[0]);

                            }

                            if (command.Equals("flash") == true)
                            {
                                flashStatus = true;
                                parameter = checkParameter(commandSplit[1], "string");
                                foreach (string s in shapeCommands)
                                {
                                    Console.WriteLine("SHAPES: " + s);
                                }
                                if (shapeCommands.Count == 0)
                                {
                                    throw new CustomValueException("No shape commands have been given. Please draw a shape and try again");
                                }
                                this.flashingColors = parameter;
                                shapeCommandsCopy = new List<string>(shapeCommands);
                                //flashShapes = new Thread(new ThreadStart(startFlashing));
                                flashShapes = new Thread(() => startFlashing(shapeCommandsCopy));
                                flashShapes.Start();
                                shapeCommands.Clear();
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                errors.Add("Line " + (errorIndex - 1) + ": " + e.Message);
                errors.Add("--------------------------------------");
                return;
            }
        }

        /// <summary>
        /// This method starts flashing the shapes that have been drawn.
        /// It takes a list of shape commands as an input and flashes them in the specified colors. 
        /// The flashing can be stopped by setting the stopFlash variable to true. 
        /// It uses the runCommand method to run the shape commands and the flashing interval can be adjusted by changing the value of the `flashingInterva` variable.
        /// Any errors thrown will be added to the errors list for further handling.
        /// </summary>
        /// <param name="shapeCommandsCopy"></param>
        public void startFlashing(List<string> shapeCommandsCopy)
        {
            stopFlash = false;
            foreach (string s in this.shapeCommandsCopy)
            {
                Console.WriteLine("INSIDE ANOTHER THREAD: " + s);
            }
            try
            {
                string[] colors = new string[] { };
                if (flashingColors.Length == 1)
                {
                    if (flashingColors[0].Equals("redgreen"))
                    {
                        colors = new string[] { "red", "green" };
                    }
                    else if (flashingColors[0].Equals("blueyellow"))
                    {
                        colors = new string[] { "blue", "yellow" };
                    }
                    else if (flashingColors[0].Equals("blackwhite"))
                    {
                        colors = new string[] { "black", "white" };
                    }
                }
                else
                {
                    colors = flashingColors;
                }

                while (!stopFlash)
                {
                    colorIndex = (colorIndex + 1) % colors.Length;
                    string currentColor = colors[colorIndex];
                    runCommand("pen " + currentColor);
                    runCommand("fill on");
                    foreach (string shape in this.shapeCommandsCopy)
                    {
                        runCommand(shape);
                    }
                    myArtWork.DrawNow();
                    refreshMethod();
                    Thread.Sleep(flashingInterval);

                }
            }
            catch (Exception e)
            {
                errors.Add("Flashing Stopped");
                errors.Add("--------------------------------------");
            }
        }

        /// <summary>
        /// This function is used to stop the flashing of the shapes on the screen. 
        /// It sets the stopFlash flag to true, flashStatus flag to false, reset the fill and color, and waits for the flashShapes thread to complete.
        /// </summary>
        public void stopFlashing()
        {
            stopFlash = true;
            flashStatus = false;
            resetFill();
            resetColor();
            flashShapes.Join();
        }

        /// <summary>
        /// This method assigns a method to be used as the refresh method for the current object.
        /// </summary>
        /// <param name="method">The method to be used as the refresh method.</param>
        public void refresh(Action method)
        {
            this.refreshMethod = method;
        }

        /// <summary>
        /// This method checks the syntax of the given commands by verifying whether the command is an assignment statement.
        /// If not, it checks whether the command is a valid shape command or other command. If the command is a shape command or other available command, it checks the
        /// number of parameters passed to the command and whether they are valid parameters. If any errors are found, they are
        /// added to the errors list. If errors had been found it does not forward the commands to `runCommand` function.
        /// </summary>
        /// <param name="commands">The list of commands to be checked for syntax errors</param>
        public void checkSyntax(List<string> commands)
        {
            errorIndex = 1;
            foreach (string command in commands)
            {
                errorIndex++;
                try
                {
                    if (command.Contains('=') && !command.Contains("==") && !command.Contains("<=") && !command.Contains(">="))
                    {
                        assignVariables(command);
                    }
                    else
                    {
                        commandSplit = command.Split(' ');
                    }

                    if (Enum.IsDefined(typeof(ShapeCommands), commandSplit[0]))
                    {
                        if (variable.Count == 0)
                        {
                            parameter = checkParameter(commandSplit[1], "int");
                        }
                        else
                        {
                            if (commandSplit[1].All(char.IsDigit) || Regex.IsMatch(commandSplit[1], @"^[\d,]+$"))
                            {
                                parameter = checkParameter(commandSplit[1], "int");
                            }
                            else
                            {
                                if (commandSplit[1].Length > 1)
                                {
                                    string[] array = commandSplit[1].Split(',');
                                    string b = "";
                                    foreach (string a in array)
                                    {
                                        if (variable.TryGetValue(a, out dynamic value))
                                        {
                                            b = b + value + ",";
                                        }
                                    }
                                    b = b.Remove(b.Length - 1);
                                    parameter = checkParameter(b, "int");
                                }
                                else
                                {
                                    if ((variable.TryGetValue(commandSplit[1], out dynamic value)))
                                    {
                                        parameter = checkParameter(value.ToString(), "int");
                                    }
                                }
                            }
                        }

                        if (!(parameter is Array))
                        {
                            throw new CustomParameterException(parameter.Message);
                        }

                        switch (commandSplit[0])
                        {
                            case "circle":
                                if (!checkCommandLength(parameter.Length, 1))
                                {
                                    throw new CustomParameterException("Invalid Number of parameter is given for the circle command. Please try with one parameter only.");
                                }
                                break;
                            case "square":
                                if (!checkCommandLength(parameter.Length, 1))
                                {
                                    throw new CustomParameterException("Invalid Number of parameter is given for the square command. Please try with one parameter only");
                                }
                                break;
                            case "rectangle":
                                if (!checkCommandLength(parameter.Length, 2))
                                {
                                    throw new CustomParameterException("Invalid Number of parameter is given for the rectangle command. Please try with two parameters only");
                                }
                                break;
                            case "triangle":
                                if (!checkCommandLength(parameter.Length, 4))
                                {
                                    throw new CustomParameterException("Invalid Number of parameter is given for the triangle command. Please try with four parameters only.");
                                }
                                break;
                            case "star":
                                if (!checkCommandLength(parameter.Length, 1))
                                {
                                    throw new CustomParameterException("Invalid Number of parameter is given for the star command. Please try with one parameter only.");
                                }
                                break;
                            case "drawto":
                                if (!checkCommandLength(parameter.Length, 2))
                                {
                                    throw new CustomParameterException("Invalid Number of parameter is given for the drawto command. Please try with two parameters only.");
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else if (Enum.IsDefined(typeof(OtherCommands), commandSplit[0]))
                    {
                        switch (commandSplit[0])
                        {
                            case "clear":
                                if (!checkCommandLength(commandSplit.Length, 1))
                                {
                                    throw new CustomParameterException("clear command is not supposed to have any parameters");
                                }
                                break;
                            case "reset":
                                if (!checkCommandLength(commandSplit.Length, 1))
                                {
                                    throw new CustomParameterException("reset command is not supposed to have any parameters");
                                }
                                break;
                            case "pen":
                                parameter = checkParameter(commandSplit[1], "string");
                                if (!checkCommandLength(parameter.Length, 1))
                                {
                                    throw new CustomParameterException("Invalid Number of parameter is given for the pen command. Please try with one parameter only.");
                                }
                                if (checkColor(parameter[0]) == false)
                                {
                                    throw new CustomParameterException(parameter[0] + " is not a valid color. Please try something else");
                                }
                                break;
                            case "fill":
                                parameter = checkParameter(commandSplit[1], "string");
                                if (!checkCommandLength(parameter.Length, 1))
                                {
                                    throw new CustomParameterException("Invalid Number of parameter is given for the fill command. Please try with one parameter only.");
                                }
                                if (parameter[0].Equals("on") == true || parameter[0].Equals("off") == true)
                                {

                                }
                                else
                                {
                                    throw new CustomParameterException("Invalid Parameter given. Please try with 'on' and 'off' only.");
                                }
                                break;
                            case "moveto":
                                parameter = checkParameter(commandSplit[1], "int");
                                if (!checkCommandLength(parameter.Length, 2))
                                {
                                    throw new CustomParameterException("Invalid Number of parameter is given for the moveto command. Please try with two parameter only.");
                                }
                                break;
                            case "flash":
                                parameter = checkParameter(commandSplit[1], "string");

                                if (commandSplit[1].Equals("redgreen") || commandSplit[1].Equals("blueyellow") || commandSplit[1].Equals("blackwhite"))
                                {

                                }
                                else
                                {
                                    if (!checkCommandLength(parameter.Length, 2))
                                    {
                                        throw new CustomParameterException("Invalid Number of color is given for the flash command. Please try with two colors only.");
                                    }
                                    Console.WriteLine("first-color: " + checkColor(parameter[0]) + "," + "second-color: " + checkColor(parameter[1]));
                                    if (!checkColor(parameter[0]) || !checkColor(parameter[1]))
                                    {
                                        throw new CustomParameterException(parameter[0] + " or " + parameter[1] + " is not a valid color. Please verify and try again.");
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (variable.TryGetValue(commandSplit[0], out dynamic value)) { }
                        else if (commandSplit[0].Equals("while") || commandSplit[0].Equals("endloop") || commandSplit[0].Equals("if") || commandSplit[0].Equals("endif") || commandSplit[0].Equals("method") || commandSplit[0].Equals("endmethod"))
                        {
                            if (commandSplit[0].Equals("method"))
                            {
                                int startIndex = commandSplit[1].IndexOf('(');
                                int endIndex = commandSplit[1].IndexOf(')');
                                if (startIndex != endIndex - 1)
                                {
                                    string methodParameter;
                                    string[] methodParameters;
                                    startIndex = startIndex + 1;
                                    endIndex = endIndex - startIndex;
                                    methodParameter = commandSplit[1].Substring(startIndex, endIndex);
                                    methodParameters = methodParameter.Split(',');
                                    foreach (string methodParam in methodParameters)
                                    {
                                        if (!methodParam.All(char.IsDigit))
                                        {
                                            if (methodParameters.Length == 1)
                                            {
                                                assignVariables(methodParameters[0] + "=" + "0");
                                                break;
                                            }
                                            else
                                            {
                                                assignVariables(methodParam + "=" + "0");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (commandSplit[0].Contains('(') && commandSplit[0].Contains(')')) { }
                        else
                        {
                            throw new CustomCommandNotFoundException(command + " Command is not available. Please read the instructions and try again");
                        }
                    }
                }
                catch (Exception e)
                {
                    errors.Add("Line " + (errorIndex - 1) + ": " + e.Message);
                    errors.Add("--------------------------------------");
                }

            }
            if (errors.Count == 0)
            {
                //No error so command is to be executed
                errorIndex = 0;
                myArtWork.shapes.Clear();
                foreach (string command in commands)
                {
                    runCommand(command);
                }
                myArtWork.DrawNow();
            }

        }

        /// <summary>
        /// Assigns a value to a variable or performs arithmetic operations on variables and assigns the result to a variable.
        /// </summary>
        /// <param name="command">The command to assign the value or perform arithmetic operation on</param>
        /// <returns>Empty string if assignment is successful, otherwise returns an exception message</returns>
        public dynamic assignVariables(string command)
        {
            try
            {
                commandSplit = command.Split('=');

                commandSplit[0] = commandSplit[0].Trim();
                commandSplit[1] = commandSplit[1].Trim();

                if (commandSplit[1].Length < 0)
                {
                    throw new CustomValueException("Null value cannot be assigned to the variable. Please try to assign a valid value.");
                }
                else
                {
                    if (!Int32.TryParse(commandSplit[1], out int result))
                    {
                        if (commandSplit[1].Contains('+'))
                        {
                            checkVariables(commandSplit[1], '+');
                        }
                        else if (commandSplit[1].Contains('-'))
                        {
                            checkVariables(commandSplit[1], '-');
                        }
                        else if (commandSplit[1].Contains('*'))
                        {
                            checkVariables(commandSplit[1], '*');
                        }
                        else if (commandSplit[1].Contains('/'))
                        {
                            checkVariables(commandSplit[1], '/');
                        }
                    }
                    else
                    {
                        if (!variable.ContainsKey(commandSplit[0]))
                        {
                            variable.Add(commandSplit[0], commandSplit[1]);
                        }
                        else
                        {
                            variable[commandSplit[0]] = commandSplit[1];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return e;
            }
            return "";
        }

        /// <summary>
        /// This method checks the variables in the command string that is passed in and performs mathematical operations on them, such as addition, subtraction, multiplication, and division, based on the operator passed in.
        /// The result of these operations is then assigned to a variable.
        /// </summary>
        /// <param name="values">A string that contains the variable names and values to be used in the mathematical operations.</param>
        /// <param name="Operator">A char that represents the mathematical operation to be performed on the variables. Can be '+', '-', '*', or '/'.</param>
        /// <returns>A dynamic type that returns a CustomValueException if an error occurs, or 'true' if the operations are successful.</returns>
        public dynamic checkVariables(string values, char Operator)
        {
            string[] newCommand = values.Split(Operator);
            int tempValue = 0;
            if (Operator.Equals('*') || Operator.Equals('/'))
            {
                tempValue = 1;
            }
            foreach (string parm in newCommand)
            {
                if (!parm.All(char.IsDigit))
                {
                    if (variable.TryGetValue(parm, out dynamic output))
                    {
                        if (Operator.Equals('+'))
                        {
                            tempValue = tempValue + Int32.Parse(output);
                        }
                        if (Operator.Equals('-'))
                        {
                            if (tempValue != 0)
                            {
                                tempValue = tempValue - Int32.Parse(output);
                            }

                            tempValue = Int32.Parse(output) - tempValue;
                        }
                        if (Operator.Equals('*'))
                        {
                            tempValue = tempValue * Int32.Parse(output);
                        }
                        if (Operator.Equals('/'))
                        {
                            if (tempValue != 1)
                            {
                                tempValue = tempValue / Int32.Parse(output);
                            }
                            else
                            {
                                tempValue = Int32.Parse(output) / tempValue;
                            }

                        }

                    }
                    else
                    {
                        return new CustomValueException("The variable trying to be assigned does not exist. Please try again.");
                    }
                }
                else
                {
                    if (Operator.Equals('+'))
                    {
                        tempValue = tempValue + Int32.Parse(parm);
                    }
                    else if (Operator.Equals('-'))
                    {
                        tempValue = Int32.Parse(parm) - tempValue;
                    }
                    else if (Operator.Equals('*'))
                    {
                        tempValue = tempValue * Int32.Parse(parm);
                    }
                    else if (Operator.Equals('/'))
                    {
                        tempValue = Int32.Parse(parm) / tempValue;
                    }

                }
            }
            if (!variable.ContainsKey(commandSplit[0]))
            {
                variable.Add(commandSplit[0], tempValue.ToString());
            }
            else
            {
                variable[commandSplit[0]] = tempValue.ToString();
            }
            return true;
        }

        /// <summary>
        /// This method clears all the variables, loop commands, loop count, condition commands, if count, method count, methods, method commands, and current method name.
        /// </summary>
        public void clearVariables()
        {
            variable.Clear();
            loopCommands.Clear();
            loopCount = 0;
            conditionCommands.Clear();
            ifCount = 0;
            methodCount = 0;
            methods.Clear();
            methodCommands.Clear();
            currentMethodname = "";
        }

        /// <summary>
        /// This method checks if the length of the command given is equal to the expected length
        /// </summary>
        /// <param name="length">The length of the given command</param>
        /// <param name="tobeLength">The expected length of the command</param>
        /// <returns>returns true if the length of the command is equal to the expected length, otherwise false</returns>
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

        /// <summary>
        /// checkColor method is used to check whether the given color name is a known color or not.
        /// </summary>
        /// <param name="color">string color name to be checked</param>
        /// <returns>returns true if the color name is known color and false if it is not a known color</returns>
        public Boolean checkColor(string color)
        {
            if (Color.FromName(color).IsKnownColor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method is used to reset the fill of the shape.
        /// </summary>
        public void resetFill()
        {
            myArtWork.changeFill("off");
        }

        /// <summary>
        /// This method is used to reset the color of the shape to black.
        /// </summary>
        public void resetColor()
        {
            myArtWork.changeColor("black");
        }

        /// <summary>
        /// This method is used to return the list of errors.
        /// </summary>
        /// <returns>A list of errors that occurred during the execution of the commands</returns>
        public List<string> showError()
        {
            errorIndex = 0;
            return errors;
        }
    }
}