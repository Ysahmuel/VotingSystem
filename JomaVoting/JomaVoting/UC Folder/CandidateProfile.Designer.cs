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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(31, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(199, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(7, 68);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 1;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // lblCandidateName
            // 
            lblCandidateName.AutoSize = true;
            lblCandidateName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCandidateName.Location = new Point(236, 61);
            lblCandidateName.Name = "lblCandidateName";
            lblCandidateName.Size = new Size(186, 31);
            lblCandidateName.TabIndex = 2;
            lblCandidateName.Text = "Candidate Name";
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(313, 6);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(92, 20);
            lblPosition.TabIndex = 3;
            lblPosition.Text = "CandidateID";
            // 
            // CandidateProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(lblPosition);
            Controls.Add(lblCandidateName);
            Controls.Add(checkBox1);
            Controls.Add(pictureBox1);
            Name = "CandidateProfile";
            Size = new Size(650, 148);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private CheckBox checkBox1;
        private Label lblCandidateName;
        private Label lblPosition;
    }
}
