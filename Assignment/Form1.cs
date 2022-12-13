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

        List<string> multiCommands = new List<string>();

        public drawingProgram()
        {
            InitializeComponent();
            Size = new Size(1040, 770);

            myArtWork = new ArtWork(Graphics.FromImage(bitmapOutput));

            parser = new CommandParser(myArtWork);
        }

        private void outputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics currentIllustration = e.Graphics;
            currentIllustration.DrawImageUnscaled(bitmapOutput, 0, 0);
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            runCode();
            programLogWindow.Lines = parser.showError().ToArray();
            multiCommands.Clear();
            Refresh();
        }

        private void singleCommand_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                
                string code = singleCommandLine.Text.Trim().ToLower();

                if (code == "run")
                {
                    runCode();
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

        private void clearCodeButton_Click(object sender, EventArgs e)
        {
            multiCommands.Clear();
            programInputWindow.Clear();
        }

        private void clearScreenButton_Click(object sender, EventArgs e)
        {
            parser.runCommand("clear");
            Refresh();
        }

        private void saveCodeButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.DefaultExt = "*.rtf";
            saveFile.Filter = "RTF Files|*.rtf";

            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length > 0)
            {
                programInputWindow.SaveFile(saveFile.FileName);
            }
        }

        private void loadCodeButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if(openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFile.CheckFileExists == true)
            {
                programInputWindow.LoadFile(openFile.FileName);
            }

        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            string aboutMessage = "Hello World 👋 This Program is made by Rohan Poudel";
            MessageBox.Show(aboutMessage, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void commandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string availableCommands = "moveto int, int\r\ndrawto int, int\r\ncircle int\r\nsquare int\r\nrectangle int int\r\ntriangle point1, point2\r\nfill string \r\npen string\r\nreset\r\nclear\r\nrun\r\n\r\n";
            MessageBox.Show(availableCommands, "Available Commands", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void runCode()
        {
            parser.runCommand("clear");

            for (int i = 0; i < programInputWindow.Lines.Length; i++)
            {
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
    }
}
