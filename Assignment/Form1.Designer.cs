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
            this.errorWindow = new System.Windows.Forms.PictureBox();
            this.outputBoxLabel = new System.Windows.Forms.Label();
            this.logsLabel = new System.Windows.Forms.Label();
            this.programInputWindowLabel = new System.Windows.Forms.Label();
            this.singleCommandWindowLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.outputWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // outputWindow
            // 
            this.outputWindow.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.outputWindow.Location = new System.Drawing.Point(12, 115);
            this.outputWindow.Name = "outputWindow";
            this.outputWindow.Size = new System.Drawing.Size(1201, 1043);
            this.outputWindow.TabIndex = 0;
            this.outputWindow.TabStop = false;
            this.outputWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.outputWindow_Paint);
            // 
            // singleCommandLine
            // 
            this.singleCommandLine.Location = new System.Drawing.Point(1230, 1184);
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
            // errorWindow
            // 
            this.errorWindow.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.errorWindow.Location = new System.Drawing.Point(1230, 115);
            this.errorWindow.Name = "errorWindow";
            this.errorWindow.Size = new System.Drawing.Size(798, 362);
            this.errorWindow.TabIndex = 3;
            this.errorWindow.TabStop = false;
            this.errorWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.errorWindow_Paint);
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
            this.singleCommandWindowLabel.Location = new System.Drawing.Point(890, 1184);
            this.singleCommandWindowLabel.Name = "singleCommandWindowLabel";
            this.singleCommandWindowLabel.Size = new System.Drawing.Size(323, 31);
            this.singleCommandWindowLabel.TabIndex = 7;
            this.singleCommandWindowLabel.Text = "Single Command Window";
            // 
            // drawingProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(2052, 1309);
            this.Controls.Add(this.singleCommandWindowLabel);
            this.Controls.Add(this.programInputWindowLabel);
            this.Controls.Add(this.logsLabel);
            this.Controls.Add(this.outputBoxLabel);
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
        private System.Windows.Forms.Label outputBoxLabel;
        private System.Windows.Forms.Label logsLabel;
        private System.Windows.Forms.Label programInputWindowLabel;
        private System.Windows.Forms.Label singleCommandWindowLabel;
    }
}

