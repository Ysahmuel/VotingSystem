namespace JomaVoting
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label1 = new Label();
            label2 = new Label();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(55, 63);
            label1.Name = "label1";
            label1.Size = new Size(80, 18);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(55, 136);
            label2.Name = "label2";
            label2.Size = new Size(74, 18);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Tahoma", 10.8F);
            txtUserName.Location = new Point(55, 84);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(298, 29);
            txtUserName.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Tahoma", 10.8F);
            txtPassword.Location = new Point(55, 157);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(298, 29);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ActiveCaption;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Tahoma", 10.8F);
            btnLogin.Location = new Point(55, 215);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(115, 37);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(219, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(158, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(txtUserName);
            panel1.Controls.Add(txtPassword);
            panel1.Location = new Point(95, 253);
            panel1.Name = "panel1";
            panel1.Size = new Size(406, 273);
            panel1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(112, 18);
            label4.Name = "label4";
            label4.Size = new Size(193, 18);
            label4.TabIndex = 5;
            label4.Text = "Sign in to start your session.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(196, 183);
            label3.Name = "label3";
            label3.Size = new Size(204, 36);
            label3.TabIndex = 7;
            label3.Text = "Voters Login";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(582, 553);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private Button btnLogin;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label3;
        private Label label4;
    }
}