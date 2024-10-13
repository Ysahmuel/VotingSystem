namespace JomaVoting
{
    partial class AddCandidate
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
            txtMiddleInitial = new TextBox();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbPositionsID = new ComboBox();
            btnSubmit = new Button();
            cmbSection = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            btnCancel = new Button();
            pictureBox1 = new PictureBox();
            btnInsertImage = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtMiddleInitial
            // 
            txtMiddleInitial.Location = new Point(358, 123);
            txtMiddleInitial.Name = "txtMiddleInitial";
            txtMiddleInitial.Size = new Size(30, 27);
            txtMiddleInitial.TabIndex = 14;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(235, 123);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(115, 27);
            txtFirstName.TabIndex = 13;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(395, 123);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(115, 27);
            txtLastName.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label4.Location = new Point(234, 249);
            label4.Name = "label4";
            label4.Size = new Size(105, 25);
            label4.TabIndex = 11;
            label4.Text = "PositionID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label3.Location = new Point(353, 93);
            label3.Name = "label3";
            label3.Size = new Size(41, 25);
            label3.TabIndex = 10;
            label3.Text = "MI:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label2.Location = new Point(232, 93);
            label2.Name = "label2";
            label2.Size = new Size(111, 25);
            label2.TabIndex = 9;
            label2.Text = "First Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label1.Location = new Point(394, 93);
            label1.Name = "label1";
            label1.Size = new Size(108, 25);
            label1.TabIndex = 8;
            label1.Text = "Last Name:";
            // 
            // cmbPositionsID
            // 
            cmbPositionsID.FormattingEnabled = true;
            cmbPositionsID.Location = new Point(235, 279);
            cmbPositionsID.Name = "cmbPositionsID";
            cmbPositionsID.Size = new Size(276, 28);
            cmbPositionsID.TabIndex = 15;
            cmbPositionsID.SelectedIndexChanged += cmbPositionsID_SelectedIndexChanged;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.Black;
            btnSubmit.FlatAppearance.BorderColor = Color.RoyalBlue;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(400, 335);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 47);
            btnSubmit.TabIndex = 16;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // cmbSection
            // 
            cmbSection.FormattingEnabled = true;
            cmbSection.Location = new Point(235, 200);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(275, 28);
            cmbSection.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label5.Location = new Point(231, 167);
            label5.Name = "label5";
            label5.Size = new Size(80, 25);
            label5.TabIndex = 17;
            label5.Text = "Section:";
            // 
            // label6
            // 
            label6.BackColor = SystemColors.ActiveCaptionText;
            label6.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(0, -1);
            label6.Name = "label6";
            label6.Padding = new Padding(6, 13, 0, 0);
            label6.Size = new Size(527, 59);
            label6.TabIndex = 19;
            label6.Text = "Add Candidate";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(224, 224, 224);
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(281, 335);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 47);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Generic_Profile_Placeholder1;
            pictureBox1.Location = new Point(8, 79);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnInsertImage
            // 
            btnInsertImage.Location = new Point(37, 294);
            btnInsertImage.Name = "btnInsertImage";
            btnInsertImage.Size = new Size(128, 29);
            btnInsertImage.TabIndex = 21;
            btnInsertImage.Text = "Insert Image";
            btnInsertImage.UseVisualStyleBackColor = true;
            btnInsertImage.Click += btnInsertImage_Click;
            // 
            // AddCandidate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(526, 411);
            Controls.Add(btnInsertImage);
            Controls.Add(pictureBox1);
            Controls.Add(btnCancel);
            Controls.Add(label6);
            Controls.Add(cmbSection);
            Controls.Add(label5);
            Controls.Add(btnSubmit);
            Controls.Add(cmbPositionsID);
            Controls.Add(txtMiddleInitial);
            Controls.Add(txtFirstName);
            Controls.Add(txtLastName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddCandidate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddCandidate";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtMiddleInitial;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cmbPositionsID;
        private Button btnSubmit;
        private ComboBox cmbSection;
        private Label label5;
        private Label label6;
        private Button btnCancel;
        private PictureBox pictureBox1;
        private Button btnInsertImage;
    }
}