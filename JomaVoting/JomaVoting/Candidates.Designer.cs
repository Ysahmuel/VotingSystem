namespace JomaVoting
{
    partial class Candidates
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
            PositionID = new DataGridViewTextBoxColumn();
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
            label1.Font = new Font("Microsoft Sans Serif", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 17);
            label1.TabIndex = 2;
            label1.Text = "Candidates";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { LastName, MiddleInitial, FirstName, PositionID, Edit, Delete });
            dataGridView1.Location = new Point(11, 63);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(585, 235);
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
            // PositionID
            // 
            PositionID.HeaderText = "PositionID";
            PositionID.MinimumWidth = 6;
            PositionID.Name = "PositionID";
            PositionID.Width = 125;
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
            label2.Location = new Point(545, 25);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 9;
            label2.Text = "Search";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(379, 22);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(162, 23);
            textBox1.TabIndex = 8;
            // 
            // btnAddVoter
            // 
            btnAddVoter.Location = new Point(175, 18);
            btnAddVoter.Margin = new Padding(3, 2, 3, 2);
            btnAddVoter.Name = "btnAddVoter";
            btnAddVoter.Size = new Size(163, 22);
            btnAddVoter.TabIndex = 10;
            btnAddVoter.Text = "Add Candidate";
            btnAddVoter.UseVisualStyleBackColor = true;
            // 
            // Candidates
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAddVoter);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Candidates";
            Size = new Size(612, 300);
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
        private DataGridViewTextBoxColumn PositionID;
        private DataGridViewTextBoxColumn Edit;
        private DataGridViewTextBoxColumn Delete;
        private Label label2;
        private TextBox textBox1;
        private Button btnAddVoter;
    }
}
