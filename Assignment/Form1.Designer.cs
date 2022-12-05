namespace Assignment
{
    partial class drawingProgram
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outputWindow = new System.Windows.Forms.PictureBox();
            this.singleCommandLine = new System.Windows.Forms.TextBox();
            this.programInputWindow = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // outputWindow
            // 
            this.outputWindow.Location = new System.Drawing.Point(12, 67);
            this.outputWindow.Name = "outputWindow";
            this.outputWindow.Size = new System.Drawing.Size(1048, 928);
            this.outputWindow.TabIndex = 0;
            this.outputWindow.TabStop = false;
            this.outputWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.outputWindow_Paint);
            // 
            // singleCommandLine
            // 
            this.singleCommandLine.Location = new System.Drawing.Point(1077, 1026);
            this.singleCommandLine.Name = "singleCommandLine";
            this.singleCommandLine.Size = new System.Drawing.Size(798, 31);
            this.singleCommandLine.TabIndex = 1;
            this.singleCommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.singleCommand_KeyDown);
            // 
            // programInputWindow
            // 
            this.programInputWindow.Location = new System.Drawing.Point(1077, 67);
            this.programInputWindow.Name = "programInputWindow";
            this.programInputWindow.Size = new System.Drawing.Size(798, 928);
            this.programInputWindow.TabIndex = 2;
            this.programInputWindow.Text = "";
            // 
            // drawingProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1887, 1281);
            this.Controls.Add(this.programInputWindow);
            this.Controls.Add(this.singleCommandLine);
            this.Controls.Add(this.outputWindow);
            this.Name = "drawingProgram";
            this.Text = "Command Drawing Program";
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox outputWindow;
        private System.Windows.Forms.TextBox singleCommandLine;
        private System.Windows.Forms.RichTextBox programInputWindow;
    }
}

