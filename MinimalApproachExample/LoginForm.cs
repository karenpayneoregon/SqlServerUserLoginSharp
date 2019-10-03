using System;
using System.Windows.Forms;

namespace MinimalApproachExample
{
	public partial class LoginForm
	{
		public LoginForm()
		{
			InitializeComponent();
		}
		private void ShowHidePasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTextBox.PasswordChar = ShowHidePasswordCheckBox.Checked ? '*' : '\0';
        }
		private void LoginButton_Click(object sender, EventArgs e)
		{

			if (!string.IsNullOrWhiteSpace(UserNameTextBox.Text) && !string.IsNullOrWhiteSpace(PasswordTextBox.Text))
			{

				var ops = new DatabaseUser("KARENS-PC", "UserLoginExample"); 

                // perform login
                var loginResults = ops.SqlCredentialLogin(UserNameTextBox.Text, PasswordTextBox.Text);

                if (loginResults)
                {

                    var successValue = ops.DoWork(UserNameTextBox.Text, PasswordTextBox.Text);
                    var workResult = string.IsNullOrWhiteSpace(successValue);

                    if (workResult)
                    {
                        // operation was successful
                        MessageBox.Show("Work complete");
                    }
                    else
                    {
                        // operation has failed
                        MessageBox.Show(successValue);
                    }
                }
                else
                {
                    // login failed for one or more reasons
                    MessageBox.Show("Login failed");
                }
			}
			else
			{
                // missing user name and or user password
				MessageBox.Show("Incomplete information to continue.");
			}
		}
		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}