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
            SuspendLayout();
            // 
            // txtMiddleInitial
            // 
            txtMiddleInitial.Location = new Point(25, 189);
            txtMiddleInitial.Name = "txtMiddleInitial";
            txtMiddleInitial.Size = new Size(276, 27);
            txtMiddleInitial.TabIndex = 14;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(25, 118);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(276, 27);
            txtFirstName.TabIndex = 13;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(25, 47);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(276, 27);
            txtLastName.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 300);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 11;
            label4.Text = "PositionID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 157);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 10;
            label3.Text = "Middle Initial:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 86);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 9;
            label2.Text = "First Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 15);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 8;
            label1.Text = "Last Name:";
            // 
            // cmbPositionsID
            // 
            cmbPositionsID.FormattingEnabled = true;
            cmbPositionsID.Location = new Point(25, 332);
            cmbPositionsID.Name = "cmbPositionsID";
            cmbPositionsID.Size = new Size(276, 28);
            cmbPositionsID.TabIndex = 15;
            cmbPositionsID.SelectedIndexChanged += cmbPositionsID_SelectedIndexChanged;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(25, 399);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 16;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // cmbSection
            // 
            cmbSection.FormattingEnabled = true;
            cmbSection.Location = new Point(25, 260);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(276, 28);
            cmbSection.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 228);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 17;
            label5.Text = "Section:";
            // 
            // AddCandidate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 451);
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
            Text = "AddCandidate";
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
    }
}