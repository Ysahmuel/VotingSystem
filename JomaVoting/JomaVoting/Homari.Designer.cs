namespace JomaVote
{
    partial class Homari
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
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            btnExit = new Button();
            btnVoting = new Button();
            btnParty = new Button();
            btnHome = new Button();
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
            panel1.Name = "panel1";
            panel1.Size = new Size(938, 39);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(62, 13);
            label1.TabIndex = 0;
            label1.Text = "JomaVote";
            // 
            // panel2
            // 
            panel2.BackColor = Color.AliceBlue;
            panel2.Controls.Add(btnExit);
            panel2.Controls.Add(btnVoting);
            panel2.Controls.Add(btnParty);
            panel2.Controls.Add(btnHome);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 39);
            panel2.Name = "panel2";
            panel2.Size = new Size(175, 452);
            panel2.TabIndex = 1;
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Bottom;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = SystemColors.ControlText;
            btnExit.Location = new Point(0, 420);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(175, 32);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnVoting
            // 
            btnVoting.Dock = DockStyle.Top;
            btnVoting.FlatStyle = FlatStyle.Flat;
            btnVoting.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVoting.ForeColor = SystemColors.ControlText;
            btnVoting.Location = new Point(0, 118);
            btnVoting.Name = "btnVoting";
            btnVoting.Size = new Size(175, 45);
            btnVoting.TabIndex = 3;
            btnVoting.Text = "Vote";
            btnVoting.UseVisualStyleBackColor = true;
            btnVoting.Click += btnVoting_Click;
            // 
            // btnParty
            // 
            btnParty.Dock = DockStyle.Top;
            btnParty.FlatStyle = FlatStyle.Flat;
            btnParty.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnParty.ForeColor = SystemColors.ControlText;
            btnParty.Location = new Point(0, 73);
            btnParty.Name = "btnParty";
            btnParty.Size = new Size(175, 45);
            btnParty.TabIndex = 2;
            btnParty.Text = "Party List";
            btnParty.UseVisualStyleBackColor = true;
            btnParty.Click += btnParty_Click;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = SystemColors.ControlText;
            btnHome.Location = new Point(0, 28);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(175, 45);
            btnHome.TabIndex = 0;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(175, 28);
            panel3.TabIndex = 1;
            // 
            // pnlMain
            // 
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(175, 39);
            pnlMain.Margin = new Padding(3, 2, 3, 2);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(763, 452);
            pnlMain.TabIndex = 2;
            // 
            // Homari
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(938, 491);
            Controls.Add(pnlMain);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Homari";
            Text = "JomaVote - User";
            Load += Homari_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnHome;
        private Button btnVoting;
        private Button btnParty;
        private Panel pnlMain;
        private Button btnExit;
    }
}