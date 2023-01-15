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
    /// <summary>
    /// The drawingProgram class is the main class that is responsible for creating the UI, handling user inputs and running the code.
    /// It contains all the event handlers and methods necessary to run the commands entered by the user,
    /// display the output and handle saving, loading and clearing of the code.
    /// It creates the objects of ArtWork and CommandParser classes and calls their respective functions accordingly.
    /// </summary>
    public partial class drawingProgram : Form
    {
        /// <summary>
        /// The width of the bitmap that is used to draw the shapes on the output screen.
        /// </summary>
        const int bitmapWidth = 1201;

        /// <summary>
        /// The height of the bitmap that is used to draw the shapes on the output screen.
        /// </summary>
        const int bitmapHeight = 1110;

        /// <summary>
        /// The bitmap object that is used to draw the shapes on the output screen.
        /// </summary>
        Bitmap bitmapOutput = new Bitmap(bitmapWidth, bitmapHeight);

        /// <summary>
        /// The object reference to the ArtWork class, which is responsible for drawing the shapes on the output screen.
        /// </summary>
        ArtWork myArtWork;

        /// <summary>
        /// The object reference to the CommandParser class, which is responsible for parsing the commands.
        /// </summary>
        CommandParser parser;

        /// <summary>
        /// A generic list of strings that is used to store the multiline commands entered by the user.
        /// </summary>
        List<string> multiCommands = new List<string>();


        /// <summary>
        /// Constructor for drawingProgram class which calls the InitializeComponent method, sets size for the main screen
        /// and created object references for both ArtWork and CommandParser class
        /// </summary>
        public drawingProgram()
        {
            InitializeComponent();
            Size = new Size(1040, 770);

            //Assigning object reference and passing the outout bitmap to ArtWork class constructor
            myArtWork = new ArtWork(Graphics.FromImage(bitmapOutput));

            //Assigning object reference and passing ArtWork class's object reference to the CommandParser class constructor
            parser = new CommandParser(myArtWork);
        }

        /// <summary>
        /// This method is used to draw an unscaled image using bitmapOutput on the current graphics of the pictureBox
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments that contains the event data.</param>
        private void outputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics currentIllustration = e.Graphics;
            currentIllustration.DrawImageUnscaled(bitmapOutput, 0, 0);
        }

        /// <summary>
        /// This function is responsible to call the runCode function when the user presses the run button in the UI.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void runButton_Click(object sender, EventArgs e)
        {
            runCode();
            programLogWindow.Lines = parser.showError().ToArray();
            multiCommands.Clear();
            Refresh();
        }

        /// <summary>
        /// Event handler for the singleCommandLine textbox when the enter key is pressed.
        /// Trims and changes the case of the input code and checks if it is "run" or "stopflash".
        /// If it is "run", calls the runCode() function. If it is "stopflash", calls the stopFlashing() function of the CommandParser class.
        /// Otherwise, passes the code to the runCommand() function of the CommandParser class.
        /// Also, clears the singleCommandLine textbox, updates the programLogWindow with the error messages and calls Refresh() to update the output screen.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
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
                else if(code == "stopflash")
                {
                    parser.stopFlashing();
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

        /// <summary>
        /// This function is responsible for clearing the code from the program input window when user clicks the clear code button.
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void clearCodeButton_Click(object sender, EventArgs e)
        {
            multiCommands.Clear();
            programInputWindow.Clear();
        }

        /// <summary>
        /// This function is responsible to clear the Output screen when user clicks Clear Screen Button.
        /// It calls the runCommand function of the CommandParser class and passes "clear" as the argument.
        /// Refresh function is also called to make the changes appear on the screen.
        /// </summary>
        /// <param name="sender">The object which raised the event.</param>
        /// <param name="e">Event argument which contains the data related to the event.</param>
        private void clearScreenButton_Click(object sender, EventArgs e)
        {
            parser.runCommand("clear");
            Refresh();
        }

        /// <summary>
        /// Handles the event when the user clicks the 'Save Code' button. 
        /// It opens a SaveFileDialog for the user to select the location and name of the file and saves the contents of the programInputWindow in RichTextFormat.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
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

        /// <summary>
        /// Method responsible for forcing the refresh of the output screen.
        /// </summary>
        public void forceRefresh()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(forceRefresh));
            }
            else
            {
                Refresh();
            }
        }


        /// <summary>
        ///  Handles the click event of the load code button. 
        ///  It allows the user to load a previously saved code file in RTF format
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void loadCodeButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            //Checking if the user saved file had been saved properly and if the user selected ok in the dialog window
            if(openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFile.CheckFileExists == true)
            {
                programInputWindow.LoadFile(openFile.FileName);
            }

        }

        /// <summary>
        ///  This method handles the click event of the about button, it displays a message box containing information about the program
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void aboutButton_Click(object sender, EventArgs e)
        {
            string aboutMessage = "Hello World 👋 This Program is made by Rohan Poudel \n Designed in Visual Studio 2022\n\r\nSupported Platform: Windows\n\r\nThis program is a kind of programming language allowing the user to draw different shapes at different positions in the ouput screen.\n\r\nUser also have the ability to save or load the commands written to the multi line command window into a RichTextFile in the system\n\r\nPlease read the commands in the Help menu to learn about the commands available";
            MessageBox.Show(aboutMessage, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        ///  This method is responsible to open a new MessageBox showing the available commands to the user.
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void commandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string availableCommands = "moveto <positionX: int> <positionY: int>\r\ndrawto <positionX: int> <positionY: int>\r\ncircle <radius: int>\r\nsquare <size: int>\r\nrectangle <width: int> <height: int>\r\ntriangle <pointX: int> <pointY: int> <pointX: int> <pointY: int>\r\nfill <on: string> | <off: string>\r\npen <color: string>\r\nreset\r\nclear\r\nrun";
            MessageBox.Show(availableCommands, "Available Commands", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        ///  This method is responsible to reset the position of the cursor when the user presses reset position button.
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">Event arguments</param>
        private void resetPositionButton_Click(object sender, EventArgs e)
        {
            parser.runCommand("reset");
        }


        /// <summary>
        /// This method is responsible for running the code entered by the user in the multi-line input window. 
        /// It clears the output screen for every rerun of the code, trims the input code of any whitespaces and empty lines,
        /// and sends each line of code to the CommandParser class for execution. It also calls the resetFill and resetColor method 
        /// of the CommandParser class and clears all the variables stored by the program.
        /// </summary>
        private void runCode()
        {
            //Clearing the output screen for every rerun of the code
            List<string> commands = new List<string>();
            parser.runCommand("clear");
            parser.refresh(forceRefresh);
            commands.Clear();

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
                    //parser.runCommand(command);
                    commands.Add(command);
                }
            }
            parser.checkSyntax(commands);
            // Reseting everthing for the next run
            parser.resetFill();
            parser.resetColor();
            parser.runCommand("reset");
            parser.clearVariables();
        }

        
    }
}
