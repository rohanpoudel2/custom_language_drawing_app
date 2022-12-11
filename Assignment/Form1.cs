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
        const int bitmapWidth = 700, bitmapHeight = 700; 

        Bitmap bitmapOutput = new Bitmap(bitmapWidth, bitmapHeight);

        ArtWork myArtWork;

        CommandParser parser;

        public drawingProgram()
        {
            InitializeComponent();
            Size = new Size(1100, 700);

            myArtWork = new ArtWork(Graphics.FromImage(bitmapOutput));

            parser = new CommandParser(myArtWork);
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
                List<string> multiCommands = new List<string>();

                string code = singleCommandLine.Text.Trim().ToLower();

                if (code == "run")
                {
                    parser.runCommand("clear");

                    for (int i = 0; i < programInputWindow.Lines.Length; i++)
                    {
                        Console.WriteLine(programInputWindow.Lines[i]);
                        multiCommands.Add(programInputWindow.Lines[i]);
                    }

                    foreach (string command in multiCommands.ToList())
                    {
                        if (string.IsNullOrWhiteSpace(command))
                        {
                            multiCommands.RemoveAt(multiCommands.IndexOf(command));
                        }
                        else
                        {
                            parser.runCommand(command);
                        }    
                    }
                }
                else
                {
                    parser.runCommand(code);
                }

                singleCommandLine.Text = "";
                programLogWindow.Lines = parser.showError().ToArray();

                multiCommands.Clear();


                Refresh();
            }

        }
    }
}
