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

     private void processCommand(String instruction)
        {
            if (instruction.Equals("line") == true)
            {
                myArtWork.DrawLine(160, 150);
            }
            else if (instruction.Equals("square") == true)
            {
                myArtWork.DrawSquare(30);
            }
            singleCommandLine.Text = "";
            Refresh();
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
            
                processCommand(singleCommandLine.Text.Trim().ToLower());
              
            }

        }
    }
}
