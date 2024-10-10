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
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            panel3 = new Panel();
            label3 = new Label();
            panel4 = new Panel();
            label4 = new Label();
            panel5 = new Panel();
            label5 = new Label();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            label6 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(22, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(164, 74);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 28);
            label1.Name = "label1";
            label1.Size = new Size(153, 17);
            label1.TabIndex = 0;
            label1.Text = "No. of regestered voters";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Controls.Add(label2);
            panel2.Location = new Point(192, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(164, 74);
            panel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(5, 28);
            label2.Name = "label2";
            label2.Size = new Size(156, 17);
            label2.TabIndex = 1;
            label2.Text = "No. of anonymous voters";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(label3);
            panel3.Location = new Point(362, 32);
            panel3.Name = "panel3";
            panel3.Size = new Size(164, 74);
            panel3.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(36, 28);
            label3.Name = "label3";
            label3.Size = new Size(76, 17);
            label3.TabIndex = 1;
            label3.Text = "Total voters";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveBorder;
            panel4.Controls.Add(label4);
            panel4.Location = new Point(532, 32);
            panel4.Name = "panel4";
            panel4.Size = new Size(165, 74);
            panel4.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(9, 28);
            label4.Name = "label4";
            label4.Size = new Size(112, 17);
            label4.TabIndex = 2;
            label4.Text = "No. of candidates";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveBorder;
            panel5.Controls.Add(label5);
            panel5.Location = new Point(22, 128);
            panel5.Name = "panel5";
            panel5.Size = new Size(164, 74);
            panel5.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 28);
            label5.Name = "label5";
            label5.Size = new Size(102, 17);
            label5.TabIndex = 1;
            label5.Text = "No. of positions";
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1.25F;
            formsPlot1.Location = new Point(192, 139);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(489, 243);
            formsPlot1.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(349, 116);
            label6.Name = "label6";
            label6.Size = new Size(177, 20);
            label6.TabIndex = 4;
            label6.Text = "Ranking of Each Positions";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label6);
            Controls.Add(formsPlot1);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Dashboard";
            Size = new Size(700, 400);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
