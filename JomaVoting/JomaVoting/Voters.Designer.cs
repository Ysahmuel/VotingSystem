namespace JomaVoting
{
    partial class Voters
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
            LastName = new DataGridViewTextBoxColumn();
            MiddleInitial = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            VoterID = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewTextBoxColumn();
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
            label1.Size = new Size(138, 102);
            label1.TabIndex = 2;
            label1.Text = "Voters";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { LastName, MiddleInitial, FirstName, VoterID, Edit });
            dataGridView1.Location = new Point(15, 79);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(682, 293);
            dataGridView1.TabIndex = 3;
            // 
            // LastName
            // 
            LastName.HeaderText = "LastName";
            LastName.MinimumWidth = 6;
            LastName.Name = "LastName";
            LastName.Width = 125;
            // 
            // MiddleInitial
            // 
            MiddleInitial.HeaderText = "MiddleInitial";
            MiddleInitial.MinimumWidth = 6;
            MiddleInitial.Name = "MiddleInitial";
            MiddleInitial.Width = 125;
            // 
            // FirstName
            // 
            FirstName.HeaderText = "FirstName";
            FirstName.MinimumWidth = 6;
            FirstName.Name = "FirstName";
            FirstName.Width = 125;
            // 
            // VoterID
            // 
            VoterID.HeaderText = "VoterID";
            VoterID.MinimumWidth = 6;
            VoterID.Name = "VoterID";
            VoterID.Width = 125;
            // 
            // Edit
            // 
            Edit.HeaderText = "Delete";
            Edit.MinimumWidth = 6;
            Edit.Name = "Edit";
            Edit.Width = 125;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(621, 33);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 7;
            label2.Text = "Search";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(431, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(184, 27);
            textBox1.TabIndex = 6;
            // 
            // btnAddVoter
            // 
            btnAddVoter.Location = new Point(130, 28);
            btnAddVoter.Name = "btnAddVoter";
            btnAddVoter.Size = new Size(107, 29);
            btnAddVoter.TabIndex = 8;
            btnAddVoter.Text = "Add Voter";
            btnAddVoter.UseVisualStyleBackColor = true;
            // 
            // Voters
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAddVoter);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "Voters";
            Size = new Size(700, 400);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn MiddleInitial;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn VoterID;
        private DataGridViewTextBoxColumn Edit;
        private Label label2;
        private TextBox textBox1;
        private Button btnAddVoter;
    }
}
