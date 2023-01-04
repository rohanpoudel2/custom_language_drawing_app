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

        // Generic List of string type to store the multiline commands
        List<string> multiCommands = new List<string>();

        /*Constructor for drawingProgram class which calls the InitializeComponent method , sets size for the main screen 
         *and created object references for both ArtWork and CommandParser class*/
        public drawingProgram()
        {
            InitializeComponent();
            Size = new Size(1040, 770);

            //Assigning object reference and passing the outout bitmap to ArtWork class constructor
            myArtWork = new ArtWork(Graphics.FromImage(bitmapOutput));

            //Assigning object reference and passing ArtWork class's object reference to the CommandParser class constructor
            parser = new CommandParser(myArtWork);
        }

        //Function responsible to get the current graphics from the pictureBox and draw an unscaled image using bitmapOutput
        private void outputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics currentIllustration = e.Graphics;
            currentIllustration.DrawImageUnscaled(bitmapOutput, 0, 0);
        }

        //Function responsible to call the runCode function when user presses run button in the UI
        private void runButton_Click(object sender, EventArgs e)
        {
            runCode();
            programLogWindow.Lines = parser.showError().ToArray();
            multiCommands.Clear();
            Refresh();
        }

        //Function responsible to trim and lower the case of users input and pass the code accordingly
        private void singleCommand_KeyDown(object sender, KeyEventArgs e)
        {
            //Goes to this scope if user presses enter key
            if (e.KeyCode == Keys.Enter)
            {
                // Triming and Lowering the case of the user input code to make the code incase sensitive
                string code = singleCommandLine.Text.Trim().ToLower();

                // Calls the runCode function if user types run
                if (code == "run")
                {
                    runCode();
                }
                else
                {
                    //If the users input was not run then it is assumed to be a single command. So, the code it passed to the CommandParser class
                    parser.runCommand(code);
                }

                // Reseting Every thing for next time
                singleCommandLine.Text = "";
                
                programLogWindow.Lines = parser.showError().ToArray();

                multiCommands.Clear();

                Refresh();
            }

        }

        //Function responsible to Clear the RichTextBox where user clicks Clear Input Button
        private void clearCodeButton_Click(object sender, EventArgs e)
        {
            multiCommands.Clear();
            programInputWindow.Clear();
        }

        //Function responsible to Clear the Output screen when user clicks Clear Screen Button
        private void clearScreenButton_Click(object sender, EventArgs e)
        {
            parser.runCommand("clear");
            Refresh();
        }

        //Function responsible to Save the given multiline code to the users desired location in the system as a RichTextFile
        private void saveCodeButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.DefaultExt = "*.rtf";
            saveFile.Filter = "RTF Files|*.rtf";

            // Checking if user had given a valid name for the file and selected OK in the dialog window
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length > 0)
            {
                programInputWindow.SaveFile(saveFile.FileName);
            }
        }

        //Funciton responsible to Load Code from a RTF file in the system to the multiline code input textarea
        private void loadCodeButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            //Checking if the user saved file had been saved properly and if the user selected ok in the dialog window
            if(openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFile.CheckFileExists == true)
            {
                programInputWindow.LoadFile(openFile.FileName);
            }

        }

        //Function responsible to open a new MessageBox showing an about message.
        private void aboutButton_Click(object sender, EventArgs e)
        {
            string aboutMessage = "Hello World 👋 This Program is made by Rohan Poudel \n Designed in Visual Studio 2022\n\r\nSupported Platform: Windows\n\r\nThis program is a kind of programming language allowing the user to draw different shapes at different positions in the ouput screen.\n\r\nUser also have the ability to save or load the commands written to the multi line command window into a RichTextFile in the system\n\r\nPlease read the commands in the Help menu to learn about the commands available";
            MessageBox.Show(aboutMessage, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Function responsible to open a new MessageBox showing the available commands
        private void commandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string availableCommands = "moveto <positionX: int> <positionY: int>\r\ndrawto <positionX: int> <positionY: int>\r\ncircle <radius: int>\r\nsquare <size: int>\r\nrectangle <width: int> <height: int>\r\ntriangle <pointX: int> <pointY: int> <pointX: int> <pointY: int>\r\nfill <on: string> | <off: string>\r\npen <color: string>\r\nreset\r\nclear\r\nrun";
            MessageBox.Show(availableCommands, "Available Commands", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Function responsible to reset the position of the cursor when the user presses reset position button
        private void resetPositionButton_Click(object sender, EventArgs e)
        {
            parser.runCommand("reset");
        }

        //Function responsible to send the multi line commands at a time to the CommandParser class
        private void runCode()
        {
            //Clearing the output screen for every rerun of the code
            parser.runCommand("clear");

            // Adding every line of code in the multi line Rich Text Box to the multiCommands Generic List
            for (int i = 0; i < programInputWindow.Lines.Length; i++)
            {
                multiCommands.Add(programInputWindow.Lines[i]);
            }

            //Using loop to loop through the Generic List containing all the multiline code
            foreach (string command in multiCommands.ToList())
            {
                // Checking if the line is Null or has a whitespace to Removeit from the GenericList
                if (string.IsNullOrWhiteSpace(command))
                {
                    multiCommands.RemoveAt(multiCommands.IndexOf(command));
                }
                else
                {
                    //Sending the code one at a time to the CommandParser Class
                    parser.runCommand(command);
                }
            }
            // Reseting everthing for the next run
            parser.resetFill();
            parser.resetColor();
            parser.runCommand("reset");
            parser.clearVariables();
        }
    }
}
