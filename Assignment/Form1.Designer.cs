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
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCodeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCodeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetPositionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).BeginInit();
            this.menuBar.SuspendLayout();
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
            this.programInputWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.programLogWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.runButton.Text = "▶️ RUN";
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
            this.clearCodeButton.Text = "🗑️ CLEAR INPUT";
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
            this.clearScreenButton.Text = "🗑️ CLEAR DRAWING";
            this.clearScreenButton.UseVisualStyleBackColor = true;
            this.clearScreenButton.Click += new System.EventHandler(this.clearScreenButton_Click);
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(236)))), ((int)(((byte)(217)))));
            this.menuBar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuBar.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.helpToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(2048, 57);
            this.menuBar.TabIndex = 12;
            this.menuBar.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCodeButton,
            this.loadCodeButton});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(142, 49);
            this.fileMenuItem.Text = "🗃️ File";
            // 
            // saveCodeButton
            // 
            this.saveCodeButton.Name = "saveCodeButton";
            this.saveCodeButton.Size = new System.Drawing.Size(312, 54);
            this.saveCodeButton.Text = "Save Code";
            this.saveCodeButton.Click += new System.EventHandler(this.saveCodeButton_Click);
            // 
            // loadCodeButton
            // 
            this.loadCodeButton.Name = "loadCodeButton";
            this.loadCodeButton.Size = new System.Drawing.Size(312, 54);
            this.loadCodeButton.Text = "Load Code";
            this.loadCodeButton.Click += new System.EventHandler(this.loadCodeButton_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutButton,
            this.commandsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(160, 49);
            this.helpToolStripMenuItem.Text = "ℹ️ Help";
            // 
            // aboutButton
            // 
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(321, 54);
            this.aboutButton.Text = "About";
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(321, 54);
            this.commandsToolStripMenuItem.Text = "Commands";
            this.commandsToolStripMenuItem.Click += new System.EventHandler(this.commandsToolStripMenuItem_Click);
            // 
            // resetPositionButton
            // 
            this.resetPositionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPositionButton.Location = new System.Drawing.Point(429, 1343);
            this.resetPositionButton.Name = "resetPositionButton";
            this.resetPositionButton.Size = new System.Drawing.Size(391, 61);
            this.resetPositionButton.TabIndex = 13;
            this.resetPositionButton.Text = "🧹 RESET POSITION";
            this.resetPositionButton.UseVisualStyleBackColor = true;
            this.resetPositionButton.Click += new System.EventHandler(this.resetPositionButton_Click);
            // 
            // drawingProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(236)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(2048, 1432);
            this.Controls.Add(this.resetPositionButton);
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
            this.Controls.Add(this.menuBar);
            this.Name = "drawingProgram";
            this.Text = "Command Drawing Program";
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).EndInit();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCodeButton;
        private System.Windows.Forms.ToolStripMenuItem loadCodeButton;
        private System.Windows.Forms.ToolStripMenuItem aboutButton;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.Button resetPositionButton;
    }
}

