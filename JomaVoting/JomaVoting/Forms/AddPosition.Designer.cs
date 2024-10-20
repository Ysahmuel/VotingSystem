namespace JomaVoting
{
    partial class AddPosition
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
            txtPosition = new TextBox();
            label2 = new Label();
            cmbMaximumVote = new ComboBox();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 32);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Position:";
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(45, 75);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(481, 27);
            txtPosition.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 125);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 2;
            label2.Text = "Maximum Vote:";
            // 
            // cmbMaximumVote
            // 
            cmbMaximumVote.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaximumVote.FormattingEnabled = true;
            cmbMaximumVote.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cmbMaximumVote.Location = new Point(45, 168);
            cmbMaximumVote.Name = "cmbMaximumVote";
            cmbMaximumVote.Size = new Size(139, 28);
            cmbMaximumVote.TabIndex = 3;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(405, 167);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 9;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // AddPosition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 230);
            Controls.Add(btnSubmit);
            Controls.Add(cmbMaximumVote);
            Controls.Add(label2);
            Controls.Add(txtPosition);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddPosition";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPosition;
        private Label label2;
        private ComboBox cmbMaximumVote;
        private Button btnSubmit;
    }
}