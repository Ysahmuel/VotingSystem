namespace JomaVoting
{
    partial class Voting
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
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            btnVote = new Button();
            panelContainer = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(902, 72);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(412, 26);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 3;
            label1.Text = "2024 Election";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnVote);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 485);
            panel2.Name = "panel2";
            panel2.Size = new Size(902, 32);
            panel2.TabIndex = 5;
            // 
            // btnVote
            // 
            btnVote.Location = new Point(412, 0);
            btnVote.Name = "btnVote";
            btnVote.Size = new Size(96, 29);
            btnVote.TabIndex = 0;
            btnVote.Text = "Vote";
            btnVote.UseVisualStyleBackColor = true;
            btnVote.Click += btnVote_Click;
            // 
            // panelContainer
            // 
            panelContainer.AutoScroll = true;
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 72);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(902, 413);
            panelContainer.TabIndex = 6;
            // 
            // Voting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelContainer);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Voting";
            Size = new Size(902, 517);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button btnVote;
        private FlowLayoutPanel panelContainer;
    }
}
