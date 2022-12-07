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
        Bitmap errorBitMapOutput = new Bitmap(bitmapWidth, bitmapHeight);
        artWork myArtWork;
        artWork errorArtWork;

        public drawingProgram()
        {
            InitializeComponent();
            myArtWork = new artWork(Graphics.FromImage(bitmapOutput));
            errorArtWork = new artWork(Graphics.FromImage(errorBitMapOutput));
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
                            throw new ArgumentException();
                        }
                        myArtWork.drawLine(checkedParametersArrays[0], checkedParametersArrays[1]);

                    }

                    if(command.Equals("circle") == true)
                    {
                        if(checkedParametersArrays.Length != 1)
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
                foreach(string error in errors)
                {
                    Console.WriteLine(error);
                    errorArtWork.showError(error, x, y);
                    y = y + 50;
                }
            }
            
        }

        private void outputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics currentIllustration = e.Graphics;
            currentIllustration.DrawImageUnscaled(bitmapOutput, 0, 0);
        }

        private void errorWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics currentIllustration = e.Graphics;
            currentIllustration.DrawImageUnscaled(errorBitMapOutput, 0, 0);

            Graphics g = Graphics.FromImage(errorBitMapOutput);
            g.Clear(Color.White);
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
