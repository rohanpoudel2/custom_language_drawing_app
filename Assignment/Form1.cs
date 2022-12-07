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

        commandParser parser;

        List<string> multiCommands = new List<string>();

        public drawingProgram()
        {
            InitializeComponent();
            myArtWork = new artWork(Graphics.FromImage(bitmapOutput));
            errorArtWork = new artWork(Graphics.FromImage(errorBitMapOutput));
            parser = new commandParser(myArtWork, errorArtWork);
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

        private void programInputWindow_TextChanged(object sender, EventArgs e)
        {
            /*
           string code = programInputWindow.Text.Trim().ToLower();
           multiCommands.Add(code);
           code = "";
           */
         
            List<string> codeLinesList = new List<string>(programInputWindow.Text.Split('\n'));

            foreach (string code in codeLinesList.ToList())
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    codeLinesList.RemoveAt(codeLinesList.IndexOf(code));
                }
                Console.WriteLine(code);
            }

        }

        private void singleCommand_KeyDown(object sender, KeyEventArgs e)
        {
 
            if (e.KeyCode == Keys.Enter)
            {
                string code = singleCommandLine.Text.Trim().ToLower();

                if(code == "run")
                {
                    foreach(string command in multiCommands)
                    {
                        parser.runCommand(command);
                    }
                }
                else
                {
                    parser.runCommand(code);
                }
               
                singleCommandLine.Text = "";
                Refresh();
            }

        }
    }
}
