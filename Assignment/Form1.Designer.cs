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
            this.outputBoxLabel = new System.Windows.Forms.Label();
            this.logsLabel = new System.Windows.Forms.Label();
            this.programInputWindowLabel = new System.Windows.Forms.Label();
            this.singleCommandWindowLabel = new System.Windows.Forms.Label();
            this.programLogWindow = new System.Windows.Forms.RichTextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.clearCodeButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // outputWindow
            // 
            this.outputWindow.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.outputWindow.Location = new System.Drawing.Point(12, 115);
            this.outputWindow.Name = "outputWindow";
            this.outputWindow.Size = new System.Drawing.Size(1201, 1110);
            this.outputWindow.TabIndex = 0;
            this.outputWindow.TabStop = false;
            this.outputWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.outputWindow_Paint);
            // 
            // singleCommandLine
            // 
            this.singleCommandLine.Location = new System.Drawing.Point(1230, 1224);
            this.singleCommandLine.Name = "singleCommandLine";
            this.singleCommandLine.Size = new System.Drawing.Size(798, 31);
            this.singleCommandLine.TabIndex = 1;
            this.singleCommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.singleCommand_KeyDown);
            // 
            // programInputWindow
            // 
            this.programInputWindow.Location = new System.Drawing.Point(1230, 586);
            this.programInputWindow.Name = "programInputWindow";
            this.programInputWindow.Size = new System.Drawing.Size(798, 572);
            this.programInputWindow.TabIndex = 2;
            this.programInputWindow.Text = "";
            // 
            // outputBoxLabel
            // 
            this.outputBoxLabel.AutoSize = true;
            this.outputBoxLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.outputBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputBoxLabel.Location = new System.Drawing.Point(12, 39);
            this.outputBoxLabel.Name = "outputBoxLabel";
            this.outputBoxLabel.Size = new System.Drawing.Size(352, 55);
            this.outputBoxLabel.TabIndex = 4;
            this.outputBoxLabel.Text = "Output Window";
            // 
            // logsLabel
            // 
            this.logsLabel.AutoSize = true;
            this.logsLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logsLabel.Location = new System.Drawing.Point(1229, 39);
            this.logsLabel.Name = "logsLabel";
            this.logsLabel.Size = new System.Drawing.Size(313, 55);
            this.logsLabel.TabIndex = 5;
            this.logsLabel.Text = "Logs Window";
            // 
            // programInputWindowLabel
            // 
            this.programInputWindowLabel.AutoSize = true;
            this.programInputWindowLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.programInputWindowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programInputWindowLabel.Location = new System.Drawing.Point(1234, 508);
            this.programInputWindowLabel.Name = "programInputWindowLabel";
            this.programInputWindowLabel.Size = new System.Drawing.Size(513, 55);
            this.programInputWindowLabel.TabIndex = 6;
            this.programInputWindowLabel.Text = "Program Input Window";
            // 
            // singleCommandWindowLabel
            // 
            this.singleCommandWindowLabel.AutoSize = true;
            this.singleCommandWindowLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.singleCommandWindowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleCommandWindowLabel.Location = new System.Drawing.Point(1230, 1178);
            this.singleCommandWindowLabel.Name = "singleCommandWindowLabel";
            this.singleCommandWindowLabel.Size = new System.Drawing.Size(323, 31);
            this.singleCommandWindowLabel.TabIndex = 7;
            this.singleCommandWindowLabel.Text = "Single Command Window";
            // 
            // programLogWindow
            // 
            this.programLogWindow.BackColor = System.Drawing.Color.White;
            this.programLogWindow.Location = new System.Drawing.Point(1230, 115);
            this.programLogWindow.Name = "programLogWindow";
            this.programLogWindow.ReadOnly = true;
            this.programLogWindow.Size = new System.Drawing.Size(798, 369);
            this.programLogWindow.TabIndex = 8;
            this.programLogWindow.Text = "";
            // 
            // runButton
            // 
            this.runButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.Location = new System.Drawing.Point(1230, 1271);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(391, 61);
            this.runButton.TabIndex = 9;
            this.runButton.Text = "RUN";
            this.runButton.UseVisualStyleBackColor = true;
            // 
            // clearCodeButton
            // 
            this.clearCodeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearCodeButton.Location = new System.Drawing.Point(1637, 1271);
            this.clearCodeButton.Name = "clearCodeButton";
            this.clearCodeButton.Size = new System.Drawing.Size(391, 61);
            this.clearCodeButton.TabIndex = 10;
            this.clearCodeButton.Text = "CLEAR INPUT";
            this.clearCodeButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 1271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(391, 61);
            this.button1.TabIndex = 11;
            this.button1.Text = "CLEAR";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // drawingProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(2052, 1344);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Label outputBoxLabel;
        private System.Windows.Forms.Label logsLabel;
        private System.Windows.Forms.Label programInputWindowLabel;
        private System.Windows.Forms.Label singleCommandWindowLabel;
        private System.Windows.Forms.RichTextBox programLogWindow;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button clearCodeButton;
        private System.Windows.Forms.Button button1;
    }
}

