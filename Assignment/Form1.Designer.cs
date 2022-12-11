﻿namespace Assignment
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
            this.errorWindow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // outputWindow
            // 
            this.outputWindow.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.outputWindow.Location = new System.Drawing.Point(12, 67);
            this.outputWindow.Name = "outputWindow";
            this.outputWindow.Size = new System.Drawing.Size(1201, 1175);
            this.outputWindow.TabIndex = 0;
            this.outputWindow.TabStop = false;
            this.outputWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.outputWindow_Paint);
            // 
            // singleCommandLine
            // 
            this.singleCommandLine.Location = new System.Drawing.Point(1230, 919);
            this.singleCommandLine.Name = "singleCommandLine";
            this.singleCommandLine.Size = new System.Drawing.Size(798, 31);
            this.singleCommandLine.TabIndex = 1;
            this.singleCommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.singleCommand_KeyDown);
            // 
            // programInputWindow
            // 
            this.programInputWindow.Location = new System.Drawing.Point(1230, 67);
            this.programInputWindow.Name = "programInputWindow";
            this.programInputWindow.Size = new System.Drawing.Size(798, 822);
            this.programInputWindow.TabIndex = 2;
            this.programInputWindow.Text = "";
            // 
            // errorWindow
            // 
            this.errorWindow.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.errorWindow.Location = new System.Drawing.Point(1230, 1058);
            this.errorWindow.Name = "errorWindow";
            this.errorWindow.Size = new System.Drawing.Size(798, 184);
            this.errorWindow.TabIndex = 3;
            this.errorWindow.TabStop = false;
            this.errorWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.errorWindow_Paint);
            // 
            // drawingProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(2052, 1309);
            this.Controls.Add(this.errorWindow);
            this.Controls.Add(this.programInputWindow);
            this.Controls.Add(this.singleCommandLine);
            this.Controls.Add(this.outputWindow);
            this.Name = "drawingProgram";
            this.Text = "Command Drawing Program";
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox outputWindow;
        private System.Windows.Forms.TextBox singleCommandLine;
        private System.Windows.Forms.RichTextBox programInputWindow;
        private System.Windows.Forms.PictureBox errorWindow;
    }
}

