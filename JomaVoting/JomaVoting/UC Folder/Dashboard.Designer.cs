namespace JomaVoting
{
    partial class Dashboard
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
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            label6 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            lblDate = new Label();
            lblTime = new Label();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.BackColor = SystemColors.ControlDarkDark;
            formsPlot1.DisplayScale = 1.25F;
            formsPlot1.ForeColor = Color.White;
            formsPlot1.Location = new Point(235, 218);
            formsPlot1.Margin = new Padding(3, 2, 3, 2);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(673, 274);
            formsPlot1.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(517, 175);
            label6.Name = "label6";
            label6.Size = new Size(183, 20);
            label6.TabIndex = 4;
            label6.Text = "Ranking of Each Positions";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(150, 37);
            label1.TabIndex = 5;
            label1.Text = "Dashboard";
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ButtonFace;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 72);
            label2.Name = "label2";
            label2.Padding = new Padding(5, 5, 0, 0);
            label2.Size = new Size(202, 128);
            label2.TabIndex = 6;
            label2.Text = "Registered Voters";
            // 
            // label3
            // 
            label3.BackColor = SystemColors.ButtonFace;
            label3.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Image = Properties.Resources.user__1_;
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(89, 121);
            label3.Name = "label3";
            label3.Size = new Size(123, 71);
            label3.TabIndex = 7;
            label3.Text = "0";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.BackColor = SystemColors.ButtonFace;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(18, 218);
            label4.Name = "label4";
            label4.Padding = new Padding(5, 5, 0, 0);
            label4.Size = new Size(202, 128);
            label4.TabIndex = 8;
            label4.Text = "Anonymous Voters";
            // 
            // label5
            // 
            label5.BackColor = SystemColors.ButtonFace;
            label5.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Image = Properties.Resources.anonymous;
            label5.ImageAlign = ContentAlignment.MiddleLeft;
            label5.Location = new Point(89, 266);
            label5.Name = "label5";
            label5.Size = new Size(123, 71);
            label5.TabIndex = 9;
            label5.Text = "0";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.BackColor = SystemColors.ButtonFace;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(18, 364);
            label7.Name = "label7";
            label7.Padding = new Padding(5, 5, 0, 0);
            label7.Size = new Size(202, 128);
            label7.TabIndex = 10;
            label7.Text = "Candidates";
            // 
            // label8
            // 
            label8.BackColor = SystemColors.ButtonFace;
            label8.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Image = Properties.Resources.approved;
            label8.ImageAlign = ContentAlignment.MiddleLeft;
            label8.Location = new Point(89, 413);
            label8.Name = "label8";
            label8.Size = new Size(121, 71);
            label8.TabIndex = 11;
            label8.Text = "0";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.BackColor = SystemColors.ButtonFace;
            label9.BorderStyle = BorderStyle.FixedSingle;
            label9.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(235, 72);
            label9.Name = "label9";
            label9.Padding = new Padding(5, 5, 0, 0);
            label9.Size = new Size(202, 128);
            label9.TabIndex = 12;
            label9.Text = "Votes";
            // 
            // label10
            // 
            label10.BackColor = SystemColors.ButtonFace;
            label10.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Image = Properties.Resources.archive__1_;
            label10.ImageAlign = ContentAlignment.MiddleLeft;
            label10.Location = new Point(307, 121);
            label10.Name = "label10";
            label10.Size = new Size(122, 71);
            label10.TabIndex = 13;
            label10.Text = "0";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(733, 23);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(45, 20);
            lblDate.TabIndex = 14;
            lblDate.Text = "Date:";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.Location = new Point(783, 49);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(46, 20);
            lblTime.TabIndex = 15;
            lblTime.Text = "Time:";
            // 
            // Dashboard
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(lblTime);
            Controls.Add(lblDate);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(formsPlot1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Dashboard";
            Size = new Size(923, 517);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Label label6;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label lblDate;
        private Label lblTime;
    }
}
