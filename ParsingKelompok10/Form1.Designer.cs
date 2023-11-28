namespace ParsingKelompok10
{
    partial class ParsingKelompok10
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.textBoxJsonContent = new System.Windows.Forms.TextBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.lblSourceCode = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 46);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(130, 47);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse File";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(148, 46);
            this.textBoxFilePath.Multiline = true;
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(504, 47);
            this.textBoxFilePath.TabIndex = 1;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(658, 46);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(130, 47);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // textBoxJsonContent
            // 
            this.textBoxJsonContent.Location = new System.Drawing.Point(12, 148);
            this.textBoxJsonContent.Multiline = true;
            this.textBoxJsonContent.Name = "textBoxJsonContent";
            this.textBoxJsonContent.ReadOnly = true;
            this.textBoxJsonContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxJsonContent.Size = new System.Drawing.Size(392, 290);
            this.textBoxJsonContent.TabIndex = 3;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(410, 148);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(378, 290);
            this.textBoxOutput.TabIndex = 4;
            // 
            // lblSourceCode
            // 
            this.lblSourceCode.AutoSize = true;
            this.lblSourceCode.Location = new System.Drawing.Point(12, 125);
            this.lblSourceCode.Name = "lblSourceCode";
            this.lblSourceCode.Size = new System.Drawing.Size(110, 20);
            this.lblSourceCode.TabIndex = 5;
            this.lblSourceCode.Text = "Source Code :";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(406, 125);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(66, 20);
            this.lblOutput.TabIndex = 6;
            this.lblOutput.Text = "Output :";
            // 
            // ParsingKelompok10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblSourceCode);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.textBoxJsonContent);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.btnBrowse);
            this.MaximizeBox = false;
            this.Name = "ParsingKelompok10";
            this.Text = "ParsingKelompok10";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox textBoxJsonContent;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Label lblSourceCode;
        private System.Windows.Forms.Label lblOutput;
    }
}

