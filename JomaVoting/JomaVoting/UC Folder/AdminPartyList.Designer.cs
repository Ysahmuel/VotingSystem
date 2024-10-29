namespace JomaVoting
{
    partial class AdminPartyList
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
            dataGridView1 = new DataGridView();
            btnAddPartyList = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(btnAddPartyList);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(919, 286);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(356, 244);
            label1.Name = "label1";
            label1.Size = new Size(191, 34);
            label1.TabIndex = 2;
            label1.Text = "All Party List";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(157, 82);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(578, 159);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnAddPartyList
            // 
            btnAddPartyList.Location = new Point(175, 21);
            btnAddPartyList.Name = "btnAddPartyList";
            btnAddPartyList.Size = new Size(148, 41);
            btnAddPartyList.TabIndex = 0;
            btnAddPartyList.Text = "Add Party List";
            btnAddPartyList.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 286);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(919, 228);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // AdminPartyList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Name = "AdminPartyList";
            Size = new Size(919, 514);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnAddPartyList;
        private DataGridView dataGridView1;
        private Label label1;
    }
}
