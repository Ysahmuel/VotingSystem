namespace JomaVoting
{
    partial class AdminHomari
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
            txtSearch = new TextBox();
            btnSearch = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            btnCandidates = new Button();
            btnPositions = new Button();
            btnExit = new Button();
            btnVoters = new Button();
            btnVotes = new Button();
            btnDashboard = new Button();
            panel3 = new Panel();
            pictureBox2 = new PictureBox();
            pnlMain = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.Cornsilk;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1257, 52);
            panel1.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.ForeColor = Color.Black;
            txtSearch.Location = new Point(947, 14);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(239, 20);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Search";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Gray;
            btnSearch.FlatAppearance.BorderColor = Color.Gray;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Location = new Point(1192, 9);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(57, 31);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.panda__1_;
            pictureBox1.Location = new Point(3, 5);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 43);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(41, 16);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
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
            panel2.Size = new Size(200, 721);
            panel2.TabIndex = 2;
            // 
            // btnCandidates
            // 
            btnCandidates.Dock = DockStyle.Top;
            btnCandidates.FlatAppearance.BorderSize = 0;
            btnCandidates.FlatStyle = FlatStyle.Flat;
            btnCandidates.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCandidates.ForeColor = SystemColors.ControlText;
            btnCandidates.Image = Properties.Resources.people;
            btnCandidates.ImageAlign = ContentAlignment.MiddleLeft;
            btnCandidates.Location = new Point(0, 240);
            btnCandidates.Margin = new Padding(3, 4, 3, 4);
            btnCandidates.Name = "btnCandidates";
            btnCandidates.Size = new Size(200, 60);
            btnCandidates.TabIndex = 6;
            btnCandidates.Text = " Candidates";
            btnCandidates.TextAlign = ContentAlignment.MiddleLeft;
            btnCandidates.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCandidates.UseVisualStyleBackColor = true;
            btnCandidates.Click += btnCandidates_Click;
            // 
            // btnPositions
            // 
            btnPositions.Dock = DockStyle.Top;
            btnPositions.FlatAppearance.BorderSize = 0;
            btnPositions.FlatStyle = FlatStyle.Flat;
            btnPositions.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPositions.ForeColor = SystemColors.ControlText;
            btnPositions.Image = Properties.Resources.job_offer;
            btnPositions.ImageAlign = ContentAlignment.MiddleLeft;
            btnPositions.Location = new Point(0, 180);
            btnPositions.Margin = new Padding(3, 4, 3, 4);
            btnPositions.Name = "btnPositions";
            btnPositions.Size = new Size(200, 60);
            btnPositions.TabIndex = 5;
            btnPositions.Text = " Positions";
            btnPositions.TextAlign = ContentAlignment.MiddleLeft;
            btnPositions.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPositions.UseVisualStyleBackColor = true;
            btnPositions.Click += btnPositions_Click;
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Bottom;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = SystemColors.ControlText;
            btnExit.Image = Properties.Resources.log_out;
            btnExit.ImageAlign = ContentAlignment.MiddleLeft;
            btnExit.Location = new Point(0, 664);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(200, 57);
            btnExit.TabIndex = 4;
            btnExit.Text = " Exit";
            btnExit.TextAlign = ContentAlignment.MiddleLeft;
            btnExit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnVoters
            // 
            btnVoters.Dock = DockStyle.Top;
            btnVoters.FlatAppearance.BorderSize = 0;
            btnVoters.FlatStyle = FlatStyle.Flat;
            btnVoters.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVoters.ForeColor = SystemColors.ControlText;
            btnVoters.Image = Properties.Resources.user;
            btnVoters.ImageAlign = ContentAlignment.MiddleLeft;
            btnVoters.Location = new Point(0, 120);
            btnVoters.Margin = new Padding(3, 4, 3, 4);
            btnVoters.Name = "btnVoters";
            btnVoters.Size = new Size(200, 60);
            btnVoters.TabIndex = 3;
            btnVoters.Text = " Voter";
            btnVoters.TextAlign = ContentAlignment.MiddleLeft;
            btnVoters.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVoters.UseVisualStyleBackColor = true;
            btnVoters.Click += btnVoters_Click;
            // 
            // btnVotes
            // 
            btnVotes.Dock = DockStyle.Top;
            btnVotes.FlatAppearance.BorderSize = 0;
            btnVotes.FlatStyle = FlatStyle.Flat;
            btnVotes.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVotes.ForeColor = SystemColors.ControlText;
            btnVotes.Image = Properties.Resources.archive;
            btnVotes.ImageAlign = ContentAlignment.MiddleLeft;
            btnVotes.Location = new Point(0, 60);
            btnVotes.Margin = new Padding(3, 4, 3, 4);
            btnVotes.Name = "btnVotes";
            btnVotes.Size = new Size(200, 60);
            btnVotes.TabIndex = 2;
            btnVotes.Text = " Votes";
            btnVotes.TextAlign = ContentAlignment.MiddleLeft;
            btnVotes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVotes.UseVisualStyleBackColor = true;
            btnVotes.Click += btnVotes_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = SystemColors.ControlText;
            btnDashboard.Image = Properties.Resources.dashboard;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(0, 0);
            btnDashboard.Margin = new Padding(3, 4, 3, 4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(200, 60);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = " Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 721);
            panel3.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.dashboard;
            pictureBox2.Location = new Point(0, 8);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(41, 44);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // pnlMain
            // 
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlMain.Location = new Point(200, 52);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1057, 721);
            pnlMain.TabIndex = 3;
            pnlMain.Paint += pnlMain_Paint;
            // 
            // AdminHomari
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 773);
            Controls.Add(pnlMain);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AdminHomari";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JomaVote - Admin";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox txtSearch;
        private Button btnSearch;
    }
}
