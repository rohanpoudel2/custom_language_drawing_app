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
            this.outputBoxLabel = new System.Windows.Forms.Label();
            this.logsLabel = new System.Windows.Forms.Label();
            this.programInputWindowLabel = new System.Windows.Forms.Label();
            this.singleCommandWindowLabel = new System.Windows.Forms.Label();
            this.programLogWindow = new System.Windows.Forms.RichTextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.clearCodeButton = new System.Windows.Forms.Button();
            this.clearScreenButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputWindow
            // 
            this.outputWindow.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.outputWindow.Location = new System.Drawing.Point(12, 187);
            this.outputWindow.Name = "outputWindow";
            this.outputWindow.Size = new System.Drawing.Size(1201, 1110);
            this.outputWindow.TabIndex = 0;
            this.outputWindow.TabStop = false;
            this.outputWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.outputWindow_Paint);
            // 
            // singleCommandLine
            // 
            this.singleCommandLine.Location = new System.Drawing.Point(1230, 1296);
            this.singleCommandLine.Name = "singleCommandLine";
            this.singleCommandLine.Size = new System.Drawing.Size(798, 31);
            this.singleCommandLine.TabIndex = 1;
            this.singleCommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.singleCommand_KeyDown);
            // 
            // programInputWindow
            // 
            this.programInputWindow.Location = new System.Drawing.Point(1230, 658);
            this.programInputWindow.Name = "programInputWindow";
            this.programInputWindow.Size = new System.Drawing.Size(798, 572);
            this.programInputWindow.TabIndex = 2;
            this.programInputWindow.Text = "";
            // 
            // outputBoxLabel
            // 
            this.outputBoxLabel.AutoSize = true;
            this.outputBoxLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(78)))), ((int)(((byte)(52)))));
            this.outputBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputBoxLabel.Location = new System.Drawing.Point(12, 111);
            this.outputBoxLabel.Name = "outputBoxLabel";
            this.outputBoxLabel.Padding = new System.Windows.Forms.Padding(5);
            this.outputBoxLabel.Size = new System.Drawing.Size(375, 65);
            this.outputBoxLabel.TabIndex = 4;
            this.outputBoxLabel.Text = "Output Window";
            // 
            // logsLabel
            // 
            this.logsLabel.AutoSize = true;
            this.logsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(78)))), ((int)(((byte)(52)))));
            this.logsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logsLabel.Location = new System.Drawing.Point(1229, 111);
            this.logsLabel.Name = "logsLabel";
            this.logsLabel.Padding = new System.Windows.Forms.Padding(5);
            this.logsLabel.Size = new System.Drawing.Size(334, 65);
            this.logsLabel.TabIndex = 5;
            this.logsLabel.Text = "Logs Window";
            // 
            // programInputWindowLabel
            // 
            this.programInputWindowLabel.AutoSize = true;
            this.programInputWindowLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(78)))), ((int)(((byte)(52)))));
            this.programInputWindowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programInputWindowLabel.Location = new System.Drawing.Point(1230, 580);
            this.programInputWindowLabel.Name = "programInputWindowLabel";
            this.programInputWindowLabel.Padding = new System.Windows.Forms.Padding(5);
            this.programInputWindowLabel.Size = new System.Drawing.Size(543, 65);
            this.programInputWindowLabel.TabIndex = 6;
            this.programInputWindowLabel.Text = "Program Input Window";
            // 
            // singleCommandWindowLabel
            // 
            this.singleCommandWindowLabel.AutoSize = true;
            this.singleCommandWindowLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(78)))), ((int)(((byte)(52)))));
            this.singleCommandWindowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleCommandWindowLabel.Location = new System.Drawing.Point(1230, 1243);
            this.singleCommandWindowLabel.Name = "singleCommandWindowLabel";
            this.singleCommandWindowLabel.Padding = new System.Windows.Forms.Padding(5);
            this.singleCommandWindowLabel.Size = new System.Drawing.Size(354, 41);
            this.singleCommandWindowLabel.TabIndex = 7;
            this.singleCommandWindowLabel.Text = "Single Command Window";
            // 
            // programLogWindow
            // 
            this.programLogWindow.BackColor = System.Drawing.Color.White;
            this.programLogWindow.Location = new System.Drawing.Point(1230, 187);
            this.programLogWindow.Name = "programLogWindow";
            this.programLogWindow.ReadOnly = true;
            this.programLogWindow.Size = new System.Drawing.Size(798, 369);
            this.programLogWindow.TabIndex = 8;
            this.programLogWindow.Text = "";
            // 
            // runButton
            // 
            this.runButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.Location = new System.Drawing.Point(1230, 1343);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(391, 61);
            this.runButton.TabIndex = 9;
            this.runButton.Text = "RUN";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // clearCodeButton
            // 
            this.clearCodeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearCodeButton.Location = new System.Drawing.Point(1637, 1343);
            this.clearCodeButton.Name = "clearCodeButton";
            this.clearCodeButton.Size = new System.Drawing.Size(391, 61);
            this.clearCodeButton.TabIndex = 10;
            this.clearCodeButton.Text = "CLEAR INPUT";
            this.clearCodeButton.UseVisualStyleBackColor = true;
            this.clearCodeButton.Click += new System.EventHandler(this.clearCodeButton_Click);
            // 
            // clearScreenButton
            // 
            this.clearScreenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearScreenButton.Location = new System.Drawing.Point(12, 1343);
            this.clearScreenButton.Name = "clearScreenButton";
            this.clearScreenButton.Size = new System.Drawing.Size(391, 61);
            this.clearScreenButton.TabIndex = 11;
            this.clearScreenButton.Text = "CLEAR";
            this.clearScreenButton.UseVisualStyleBackColor = true;
            this.clearScreenButton.Click += new System.EventHandler(this.clearScreenButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2052, 42);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCodeToolStripMenuItem,
            this.loadCodeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(71, 38);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.commandsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(84, 38);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.commandsToolStripMenuItem.Text = "Commands";
            // 
            // saveCodeToolStripMenuItem
            // 
            this.saveCodeToolStripMenuItem.Name = "saveCodeToolStripMenuItem";
            this.saveCodeToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.saveCodeToolStripMenuItem.Text = "Save Code";
            // 
            // loadCodeToolStripMenuItem
            // 
            this.loadCodeToolStripMenuItem.Name = "loadCodeToolStripMenuItem";
            this.loadCodeToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.loadCodeToolStripMenuItem.Text = "Load Code";
            // 
            // drawingProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(236)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(2052, 1432);
            this.Controls.Add(this.clearScreenButton);
            this.Controls.Add(this.clearCodeButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.programLogWindow);
            this.Controls.Add(this.singleCommandWindowLabel);
            this.Controls.Add(this.programInputWindowLabel);
            this.Controls.Add(this.logsLabel);
            this.Controls.Add(this.outputBoxLabel);
            this.Controls.Add(this.programInputWindow);
            this.Controls.Add(this.singleCommandLine);
            this.Controls.Add(this.outputWindow);
            this.Controls.Add(this.menuStrip1);
            this.Name = "drawingProgram";
            this.Text = "Command Drawing Program";
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox outputWindow;
        private System.Windows.Forms.TextBox singleCommandLine;
        private System.Windows.Forms.RichTextBox programInputWindow;
        private System.Windows.Forms.Label outputBoxLabel;
        private System.Windows.Forms.Label logsLabel;
        private System.Windows.Forms.Label programInputWindowLabel;
        private System.Windows.Forms.Label singleCommandWindowLabel;
        private System.Windows.Forms.RichTextBox programLogWindow;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button clearCodeButton;
        private System.Windows.Forms.Button clearScreenButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
    }
}

