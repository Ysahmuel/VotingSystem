namespace JomaVoting
{
    partial class AddVoter
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            txtMiddleInitial = new TextBox();
            txtVoterID = new TextBox();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 24);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Last Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 97);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 1;
            label2.Text = "First Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 170);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 2;
            label3.Text = "Middle Initial:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 243);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 3;
            label4.Text = "VoterID";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(45, 57);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(276, 27);
            txtLastName.TabIndex = 4;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(45, 130);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(276, 27);
            txtFirstName.TabIndex = 5;
            // 
            // txtMiddleInitial
            // 
            txtMiddleInitial.Location = new Point(45, 203);
            txtMiddleInitial.Name = "txtMiddleInitial";
            txtMiddleInitial.Size = new Size(276, 27);
            txtMiddleInitial.TabIndex = 6;
            // 
            // txtVoterID
            // 
            txtVoterID.Location = new Point(45, 276);
            txtVoterID.Name = "txtVoterID";
            txtVoterID.Size = new Size(173, 27);
            txtVoterID.TabIndex = 7;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(45, 330);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // AddVoter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 378);
            Controls.Add(btnSubmit);
            Controls.Add(txtVoterID);
            Controls.Add(txtMiddleInitial);
            Controls.Add(txtFirstName);
            Controls.Add(txtLastName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddVoter";
            Text = "AddVotercs";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtMiddleInitial;
        private TextBox txtVoterID;
        private Button btnSubmit;
    }
}