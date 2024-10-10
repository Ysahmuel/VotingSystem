namespace JomaVoting
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            btnCandidates = new Button();
            btnPositions = new Button();
            btnExit = new Button();
            btnVoters = new Button();
            btnVotes = new Button();
            btnDashboard = new Button();
            panel3 = new Panel();
            pnlMain = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSlateGray;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(899, 52);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sans Serif Collection", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(86, 44);
            label1.TabIndex = 0;
            label1.Text = "JomaVote";
            // 
            // panel2
            // 
            panel2.BackColor = Color.AliceBlue;
            panel2.Controls.Add(btnCandidates);
            panel2.Controls.Add(btnPositions);
            panel2.Controls.Add(btnExit);
            panel2.Controls.Add(btnVoters);
            panel2.Controls.Add(btnVotes);
            panel2.Controls.Add(btnDashboard);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 52);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 427);
            panel2.TabIndex = 2;
            // 
            // btnCandidates
            // 
            btnCandidates.Dock = DockStyle.Top;
            btnCandidates.FlatStyle = FlatStyle.Flat;
            btnCandidates.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCandidates.ForeColor = SystemColors.ControlText;
            btnCandidates.Location = new Point(0, 278);
            btnCandidates.Margin = new Padding(3, 4, 3, 4);
            btnCandidates.Name = "btnCandidates";
            btnCandidates.Size = new Size(200, 60);
            btnCandidates.TabIndex = 6;
            btnCandidates.Text = "Candidates";
            btnCandidates.UseVisualStyleBackColor = true;
            btnCandidates.Click += btnCandidates_Click;
            // 
            // btnPositions
            // 
            btnPositions.Dock = DockStyle.Top;
            btnPositions.FlatStyle = FlatStyle.Flat;
            btnPositions.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPositions.ForeColor = SystemColors.ControlText;
            btnPositions.Location = new Point(0, 218);
            btnPositions.Margin = new Padding(3, 4, 3, 4);
            btnPositions.Name = "btnPositions";
            btnPositions.Size = new Size(200, 60);
            btnPositions.TabIndex = 5;
            btnPositions.Text = "Positions";
            btnPositions.UseVisualStyleBackColor = true;
            btnPositions.Click += btnPositions_Click;
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Bottom;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = SystemColors.ControlText;
            btnExit.Location = new Point(0, 385);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(200, 42);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnVoters
            // 
            btnVoters.Dock = DockStyle.Top;
            btnVoters.FlatStyle = FlatStyle.Flat;
            btnVoters.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVoters.ForeColor = SystemColors.ControlText;
            btnVoters.Location = new Point(0, 158);
            btnVoters.Margin = new Padding(3, 4, 3, 4);
            btnVoters.Name = "btnVoters";
            btnVoters.Size = new Size(200, 60);
            btnVoters.TabIndex = 3;
            btnVoters.Text = "Voter";
            btnVoters.UseVisualStyleBackColor = true;
            btnVoters.Click += btnVoters_Click;
            // 
            // btnVotes
            // 
            btnVotes.Dock = DockStyle.Top;
            btnVotes.FlatStyle = FlatStyle.Flat;
            btnVotes.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVotes.ForeColor = SystemColors.ControlText;
            btnVotes.Location = new Point(0, 98);
            btnVotes.Margin = new Padding(3, 4, 3, 4);
            btnVotes.Name = "btnVotes";
            btnVotes.Size = new Size(200, 60);
            btnVotes.TabIndex = 2;
            btnVotes.Text = "Votes";
            btnVotes.UseVisualStyleBackColor = true;
            btnVotes.Click += btnVotes_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = SystemColors.ControlText;
            btnDashboard.Location = new Point(0, 38);
            btnDashboard.Margin = new Padding(3, 4, 3, 4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(200, 60);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 38);
            panel3.TabIndex = 1;
            // 
            // pnlMain
            // 
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(200, 52);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(699, 427);
            pnlMain.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 479);
            Controls.Add(pnlMain);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button btnExit;
        private Button btnVoters;
        private Button btnVotes;
        private Button btnDashboard;
        private Panel panel3;
        private Panel pnlMain;
        private Button btnCandidates;
        private Button btnPositions;
    }
}
