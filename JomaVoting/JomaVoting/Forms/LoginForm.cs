using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JomaVoting.Voting;

namespace JomaVoting
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    // SQL query to check if the username and password match (use hashed password)
                    string query = "SELECT COUNT(*) FROM TBL_Voter WHERE Username=@Username AND Password=@Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count == 1)
                        {
                            // SQL query to retrieve the full name of the voter
                            string fullNameQuery = "SELECT CONCAT(FirstName, ' ', MiddleInitial, '. ', LastName) AS FullName FROM TBL_Voter WHERE Username=@Username";

                            using (SqlCommand fullNameCommand = new SqlCommand(fullNameQuery, connection))
                            {
                                fullNameCommand.Parameters.AddWithValue("@Username", username);

                                string fullName = fullNameCommand.ExecuteScalar()?.ToString();

                                if (!string.IsNullOrEmpty(fullName))
                                {
                                    VoterSession.LoggedInVoterFullName = fullName;

                                    this.Hide();
                                    VoterHomari mainForm = new VoterHomari(username);
                                    mainForm.FormClosed += (s, args) => this.Close();
                                    mainForm.Show();
                                    MessageBox.Show("Login successful!");
                                }
                                else
                                {
                                    MessageBox.Show("Error retrieving voter's full name.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during login. Please try again later.");
            }
        }


        public static class VoterSession
        {
            public static string LoggedInVoterFullName { get; set; }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}

