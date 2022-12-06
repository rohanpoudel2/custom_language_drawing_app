using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class drawingProgram : Form
    {
        const int bitmapWidth = 650, bitmapHeight = 500; 

        Bitmap bitmapOutput = new Bitmap(bitmapWidth, bitmapHeight);
        artWork myArtWork;

        public drawingProgram()
        {
            InitializeComponent();
            myArtWork = new artWork(Graphics.FromImage(bitmapOutput));
        }

     private void processCommandLine(String instruction)
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
                            errors.Add("Invalid Number of parameters provided");
                            throw new ArgumentException();
                        }
                        myArtWork.DrawLine(checkedParametersArrays[0], checkedParametersArrays[1]);

                    }
                }

                if (instruction.Equals("line") == true)
                {
                    myArtWork.DrawLine(160, 150);
                }
                else if (instruction.Equals("square") == true)
                {
                    myArtWork.DrawSquare(30);
                }
            }
            catch (Exception e)
            {
                errors.Add(e.Message);
            }
            finally
            {
                foreach(string error in errors)
                {
                    Console.WriteLine(error);
                }
            }
            
        }

        private void outputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics currentIllustration = e.Graphics;
            currentIllustration.DrawImageUnscaled(bitmapOutput, 0, 0);
        }

        private void singleCommand_KeyDown(object sender, KeyEventArgs e)
        {
 
            if (e.KeyCode == Keys.Enter)
            {
                processCommandLine(singleCommandLine.Text.Trim().ToLower());
                singleCommandLine.Text = "";
                Refresh();
            }

        }
    }
}
