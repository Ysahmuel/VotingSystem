namespace JomaVoting.UC_Folder
{
    partial class CandidateProfile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            checkBox1 = new CheckBox();
            lblCandidateName = new Label();
            lblPosition = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(80, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(199, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(27, 26);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 1;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // lblCandidateName
            // 
            lblCandidateName.AutoSize = true;
            lblCandidateName.Font = new Font("Tahoma", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCandidateName.Location = new Point(294, 54);
            lblCandidateName.Name = "lblCandidateName";
            lblCandidateName.Size = new Size(297, 41);
            lblCandidateName.TabIndex = 2;
            lblCandidateName.Text = "Candidate Name";
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Font = new Font("Tahoma", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPosition.Location = new Point(294, 12);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(107, 22);
            lblPosition.TabIndex = 3;
            lblPosition.Text = "CandidateID";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(checkBox1);
            panel1.Location = new Point(3, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(71, 67);
            panel1.TabIndex = 4;
            // 
            // CandidateProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(panel1);
            Controls.Add(lblPosition);
            Controls.Add(lblCandidateName);
            Controls.Add(pictureBox1);
            Name = "CandidateProfile";
            Size = new Size(704, 148);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private CheckBox checkBox1;
        private Label lblCandidateName;
        private Label lblPosition;
        private Panel panel1;
    }
}
