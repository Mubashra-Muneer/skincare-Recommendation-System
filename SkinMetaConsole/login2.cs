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

namespace SkinMetaConsole
{
        public partial class Login2 : Form
        {
            public Login2()
            {
                InitializeComponent();
            }
        private bool AuthenticateUser(string email, string password)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void OpenUserProfile(string email)
        {
            // Retrieve user details
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                con.Open();

                string query = "SELECT UserID, Name, City, Age FROM Users WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(reader.GetOrdinal("UserID"));
                            string name = reader.GetString(reader.GetOrdinal("Name"));
                            string city = reader.GetString(reader.GetOrdinal("City"));
                            int age = reader.GetInt32(reader.GetOrdinal("Age"));

                            // Open User Profile Form
                            UserProfile profileForm = new UserProfile(userId);
                            profileForm.Show();
                            this.Hide(); // Hide login form
                        }
                    }
                }
            }
        }
        private void login_button2_Click(object sender, EventArgs e)
        {
            string email = emailtextBox.Text.Trim();
            string password = passwordBox.Text;

            // Input validation
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Authenticate user
                if (AuthenticateUser(email, password))
                {
                    // Successful login - open user profile
                    OpenUserProfile(email);
                }
                else
                {
                    // Failed login
                    MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    

}
