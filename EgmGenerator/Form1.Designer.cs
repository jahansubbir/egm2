namespace EgmGenerator
{
    partial class Form1
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
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.EgmButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SheetNameTextBox = new System.Windows.Forms.TextBox();
            this.OceanRadio = new System.Windows.Forms.RadioButton();
            this.ScmRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilePathTextBox.Location = new System.Drawing.Point(154, 50);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(294, 26);
            this.FilePathTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "File";
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.SkyBlue;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseButton.Location = new System.Drawing.Point(454, 50);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(117, 26);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // EgmButton
            // 
            this.EgmButton.BackColor = System.Drawing.Color.LightBlue;
            this.EgmButton.FlatAppearance.BorderSize = 0;
            this.EgmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EgmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EgmButton.Location = new System.Drawing.Point(154, 146);
            this.EgmButton.Name = "EgmButton";
            this.EgmButton.Size = new System.Drawing.Size(294, 37);
            this.EgmButton.TabIndex = 3;
            this.EgmButton.Text = "EGM XML";
            this.EgmButton.UseVisualStyleBackColor = false;
            this.EgmButton.Click += new System.EventHandler(this.EgmButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Worksheet";
            // 
            // SheetNameTextBox
            // 
            this.SheetNameTextBox.Enabled = false;
            this.SheetNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SheetNameTextBox.Location = new System.Drawing.Point(154, 82);
            this.SheetNameTextBox.Name = "SheetNameTextBox";
            this.SheetNameTextBox.Size = new System.Drawing.Size(294, 26);
            this.SheetNameTextBox.TabIndex = 4;
            this.SheetNameTextBox.Text = "Sheet1";
            // 
            // OceanRadio
            // 
            this.OceanRadio.AutoSize = true;
            this.OceanRadio.FlatAppearance.BorderSize = 0;
            this.OceanRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OceanRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OceanRadio.ForeColor = System.Drawing.Color.SteelBlue;
            this.OceanRadio.Location = new System.Drawing.Point(154, 114);
            this.OceanRadio.Name = "OceanRadio";
            this.OceanRadio.Size = new System.Drawing.Size(87, 24);
            this.OceanRadio.TabIndex = 6;
            this.OceanRadio.TabStop = true;
            this.OceanRadio.Text = "OCEAN";
            this.OceanRadio.UseVisualStyleBackColor = true;
            this.OceanRadio.CheckedChanged += new System.EventHandler(this.OceanRadio_CheckedChanged);
            // 
            // ScmRadio
            // 
            this.ScmRadio.AutoSize = true;
            this.ScmRadio.FlatAppearance.BorderSize = 0;
            this.ScmRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScmRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScmRadio.ForeColor = System.Drawing.Color.SteelBlue;
            this.ScmRadio.Location = new System.Drawing.Point(384, 114);
            this.ScmRadio.Name = "ScmRadio";
            this.ScmRadio.Size = new System.Drawing.Size(64, 24);
            this.ScmRadio.TabIndex = 7;
            this.ScmRadio.TabStop = true;
            this.ScmRadio.Text = "SCM";
            this.ScmRadio.UseVisualStyleBackColor = true;
            this.ScmRadio.CheckedChanged += new System.EventHandler(this.ScmRadio_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 253);
            this.Controls.Add(this.ScmRadio);
            this.Controls.Add(this.OceanRadio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SheetNameTextBox);
            this.Controls.Add(this.EgmButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilePathTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button EgmButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SheetNameTextBox;
        private System.Windows.Forms.RadioButton OceanRadio;
        private System.Windows.Forms.RadioButton ScmRadio;
    }
}

