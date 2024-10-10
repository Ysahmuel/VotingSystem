namespace JomaVoting
{
    partial class Positions
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
            label1 = new Label();
            dataGridView1 = new DataGridView();
            Position = new DataGridViewTextBoxColumn();
            MaximumVote = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewTextBoxColumn();
            Delete = new DataGridViewTextBoxColumn();
            label2 = new Label();
            textBox1 = new TextBox();
            btnAddVoter = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Sans Serif Collection", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(180, 102);
            label1.TabIndex = 2;
            label1.Text = "Positions";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Position, MaximumVote, Edit, Delete });
            dataGridView1.Location = new Point(36, 86);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(611, 272);
            dataGridView1.TabIndex = 3;
            // 
            // Position
            // 
            Position.HeaderText = "Position";
            Position.MinimumWidth = 6;
            Position.Name = "Position";
            Position.Width = 125;
            // 
            // MaximumVote
            // 
            MaximumVote.HeaderText = "MaximumVote";
            MaximumVote.MinimumWidth = 6;
            MaximumVote.Name = "MaximumVote";
            MaximumVote.Width = 125;
            // 
            // Edit
            // 
            Edit.HeaderText = "Edit";
            Edit.MinimumWidth = 6;
            Edit.Name = "Edit";
            Edit.Width = 125;
            // 
            // Delete
            // 
            Delete.HeaderText = "Delete";
            Delete.MinimumWidth = 6;
            Delete.Name = "Delete";
            Delete.Width = 125;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(618, 33);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 9;
            label2.Text = "Search";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(428, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(184, 27);
            textBox1.TabIndex = 8;
            // 
            // btnAddVoter
            // 
            btnAddVoter.Location = new Point(168, 28);
            btnAddVoter.Name = "btnAddVoter";
            btnAddVoter.Size = new Size(131, 29);
            btnAddVoter.TabIndex = 10;
            btnAddVoter.Text = "Add Position";
            btnAddVoter.UseVisualStyleBackColor = true;
            // 
            // Positions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAddVoter);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "Positions";
            Size = new Size(700, 400);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Position;
        private DataGridViewTextBoxColumn MaximumVote;
        private DataGridViewTextBoxColumn Edit;
        private DataGridViewTextBoxColumn Delete;
        private Label label2;
        private TextBox textBox1;
        private Button btnAddVoter;
    }
}
