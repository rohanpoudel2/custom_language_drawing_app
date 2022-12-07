using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class commandParser
    {

        artWork myArtWork, errorArtWork;

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
                }

            }
            catch (Exception e)
            {
                errors.Add(e.Message);
            }
            finally
            {
                int x = 0;
                int y = 0;
                foreach (string error in errors)
                {
                    Console.WriteLine(error);
                    errorArtWork.showError(error, x, y);
                    y = y + 50;
                }
            }
        }
    }
}
