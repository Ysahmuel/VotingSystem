namespace JomaVoting
{
    partial class VoterHomari
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            btnExit = new Button();
            btnVoting = new Button();
            btnPartyList = new Button();
            btnHome = new Button();
            panel3 = new Panel();
            lblUsername = new Label();
            pnlMain = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 56);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.panda__1_;
            pictureBox1.Location = new Point(3, 5);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 43);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(41, 16);
            label1.Name = "label1";
            label1.Size = new Size(94, 22);
            label1.TabIndex = 2;
            label1.Text = "JomaVote";
            // 
            // panel2
            // 
            panel2.BackColor = Color.AliceBlue;
            panel2.Controls.Add(btnExit);
            panel2.Controls.Add(btnVoting);
            panel2.Controls.Add(btnPartyList);
            panel2.Controls.Add(btnHome);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 56);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 717);
            panel2.TabIndex = 2;
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Bottom;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = SystemColors.ControlText;
            btnExit.Location = new Point(0, 675);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(200, 42);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnVoting
            // 
            btnVoting.Dock = DockStyle.Top;
            btnVoting.FlatAppearance.BorderSize = 0;
            btnVoting.FlatStyle = FlatStyle.Flat;
            btnVoting.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVoting.ForeColor = SystemColors.ControlText;
            btnVoting.Location = new Point(0, 150);
            btnVoting.Margin = new Padding(3, 4, 3, 4);
            btnVoting.Name = "btnVoting";
            btnVoting.Size = new Size(200, 60);
            btnVoting.TabIndex = 3;
            btnVoting.Text = "Voting";
            btnVoting.UseVisualStyleBackColor = true;
            btnVoting.Click += btnVoting_Click;
            // 
            // btnPartyList
            // 
            btnPartyList.Dock = DockStyle.Top;
            btnPartyList.FlatAppearance.BorderSize = 0;
            btnPartyList.FlatStyle = FlatStyle.Flat;
            btnPartyList.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPartyList.ForeColor = SystemColors.ControlText;
            btnPartyList.Location = new Point(0, 90);
            btnPartyList.Margin = new Padding(3, 4, 3, 4);
            btnPartyList.Name = "btnPartyList";
            btnPartyList.Size = new Size(200, 60);
            btnPartyList.TabIndex = 2;
            btnPartyList.Text = "Party List";
            btnPartyList.UseVisualStyleBackColor = true;
            btnPartyList.Click += btnPartyList_Click;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = SystemColors.ControlText;
            btnHome.Location = new Point(0, 30);
            btnHome.Margin = new Padding(3, 4, 3, 4);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(200, 60);
            btnHome.TabIndex = 0;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblUsername);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 30);
            panel3.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Tahoma", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(0, 4);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(78, 16);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "lblUsername";
            // 
            // pnlMain
            // 
            pnlMain.AutoScroll = true;
            pnlMain.AutoScrollMargin = new Size(0, 200);
            pnlMain.BackColor = SystemColors.ButtonHighlight;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(200, 56);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(800, 717);
            pnlMain.TabIndex = 3;
            // 
            // VoterHomari
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 773);
            Controls.Add(pnlMain);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "VoterHomari";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btnExit;
        private Button btnVoting;
        private Button btnPartyList;
        private Button btnHome;
        private Panel pnlMain;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Label label1;
        private Label lblUsername;
    }
}
