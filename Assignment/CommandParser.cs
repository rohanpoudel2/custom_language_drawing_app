using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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

        //For Commands
        string[] commandSplit;
        //For Commands parameters
        dynamic parameter = "";

        //Creating a new List to store the errors that might occure in scope of this class
        List<string> errors = new List<string>();

        //For Variables
        IDictionary<string, dynamic> variable = new Dictionary<string, dynamic>();

        //For Loop Functionality
        bool validLoop;
        bool inLoop;
        int loopInterval = 0;
        string loopStatement;
        List<string> loopCommands = new List<string>();
        int loopCount = 0;

        //For Condition Functionality
        int ifCount = 0;
        bool inCondition;
        bool validIf;
        List<string> conditionCommands = new List<string>();

        //For Method Functionality
        int methodCount = 0;
        bool inMethod;
        string calledMethod = "";
        IDictionary<string, dynamic> methods = new Dictionary<string, dynamic>();
        List<string> methodCommands = new List<string>();
        string currentMethodname = "";

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

        // Function responsible to check the command and call the appopriate function related to that command in the ArtWork class
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
                    if (commandSplit[1].Contains('<'))
                    {
                        loopCondition = commandSplit[1].Split('<');
                        operatorr = "<";
                    }
                    else if (commandSplit[1].Contains('>'))
                    {
                        loopCondition = commandSplit[1].Split('>');
                        operatorr = ">";
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
                    if (commandSplit[1].Contains('<'))
                    {
                        ifCondition = commandSplit[1].Split('<');
                        operatorr = "<";
                    }
                    else if (commandSplit[1].Contains('>'))
                    {
                        ifCondition = commandSplit[1].Split('>');
                        operatorr = ">";
                    }
                    else if (commandSplit[1].Contains("=="))
                    {
                        ifCondition = commandSplit[1].Split(new string[] {
              "=="
            }, StringSplitOptions.None);
                        operatorr = "==";
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
                    inMethod = false;
                    foreach(string m in methodCommands)
                    {
                        if (m.Contains("method"))
                        {
                            methodCommands.Remove(m);
                            break;
                        }
                    }
                }

                if (commandSplit[0].Contains('(') && commandSplit[0].Contains(')') && !commandSplit[0].Contains("method")) 
                {
                    string methodName;
                    string methodParameter;
                    string[] methodParameters;

                    int startIndex = commandSplit[0].IndexOf('(');
                    int endIndex = commandSplit[0].IndexOf(')');

                    methodName = commandSplit[0].Substring(0, startIndex);

                    foreach(string method in methods.Keys)
                    {
                        if (methodName.Equals(method))
                        {
                            if (startIndex == endIndex - 1)
                            {
                                foreach(string command in methodCommands)
                                {
                                   runCommand(command);
                                }
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
                                        for (int i = 0; i<methodParameters.Length; i++)
                                        {
                                            if (methodParameters[i].All(char.IsDigit))
                                            {
                                                variable[methods[method][i]] = methodParameters[i];
                                            }
                                            else
                                            {
                                                foreach(string var in variable.Keys)
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
                                    if(methodParameters.Length > 1)
                                    {
                                        throw new CustomParameterException("Method only takes one parameter");
                                    }
                                    if (methodParameters[0].All(char.IsDigit))
                                    {
                                        variable[methods[method]] = methodParameters[0];
                                    }
                                    else
                                    {
                                        foreach(string var in variable.Keys)
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


                                foreach (string command in methodCommands)
                                {
                                    runCommand(command);
                                }


                            }
                            break;
                        }
                        else
                        {
                            throw new MethodAccessException("Method does not exist. Please try again.");
                        }
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
                    methodCommands.Add(instruction);
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

                            myArtWork.drawLine(parameter[0], parameter[1]);

                        }

                        if (command.Equals("square") == true)
                        {

                            myArtWork.drawSquare(parameter[0]);

                        }

                        if (command.Equals("circle") == true)
                        {
                            myArtWork.drawCircle(parameter[0]);
                        }

                        if (command.Equals("rectangle") == true)
                        {

                            myArtWork.drawRectangle(parameter[0], parameter[1]);

                        }

                        if (command.Equals("triangle") == true)
                        {

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

        public void checkSyntax(List<string> commands)
        {
            errorIndex = 1;
            foreach (string command in commands)
            {
                errorIndex++;
                try
                {
                    if (command.Contains('=') && !command.Contains("=="))
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
                                if (myArtWork.changeColor(parameter[0]) == false)
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
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (variable.TryGetValue(commandSplit[0], out dynamic value)) { }
                        else if (commandSplit[0].Equals("while") || commandSplit[0].Equals("endloop") || commandSplit[0].Equals("if") || commandSplit[0].Equals("endif") || commandSplit[0].Equals("method") || commandSplit[0].Equals("endmethod")) {
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
                                                assignVariables(methodParameters[0]+"="+"0");
                                                break;
                                            }
                                            else
                                            {
                                                assignVariables(methodParam+"="+"0");
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
                foreach (string command in commands)
                {
                    runCommand(command);
                }
            }

        }

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