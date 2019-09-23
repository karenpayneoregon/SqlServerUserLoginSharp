using System;
using System.Windows.Forms;
using LoginLibrary.DataClasses.DataClasses;
using LoginLibrary.SecurityClasses.SecurityClasses;

namespace LoginUserInterface
{
	public partial class LoginForm
	{
		/// <summary>
		/// Toggle visibility of password
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public LoginForm()
		{
			InitializeComponent();
		}

		private void ShowHidePasswordCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (ShowHidePasswordCheckBox.Checked)
			{
				PasswordTextBox.PasswordChar = '*';
			}
			else
			{
				PasswordTextBox.PasswordChar = '\0';
			}
		}
		/// <summary>
		/// Perform login
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoginButton_Click(object sender, EventArgs e)
		{

			if (!string.IsNullOrWhiteSpace(UserNameTextBox.Text) && !string.IsNullOrWhiteSpace(PasswordTextBox.Text))
			{

				var ops = new DatabaseUser("KARENS-PC", "UserLoginExample");
                var encryption = new Encryption();
                // encrypt user name and password
                var userNameBytes = encryption.Encrypt(UserNameTextBox.Text, "111");
                var passwordBytes = encryption.Encrypt(PasswordTextBox.Text, "111");

                var results = ops.Login(userNameBytes, passwordBytes);

                //
                // Login recognized (does not know if the user has proper permissions to the tables at this point)
                //
                if (results.Success)
                {
	                Hide();
	                var mainForm = new MainForm(userNameBytes, passwordBytes);
	                mainForm.ShowDialog();
                }
                else
                {
	                MessageBox.Show(results.Message);
                }
			}
			else
			{
				MessageBox.Show("Incomplete information to continue.");
			}
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private static LoginForm _DefaultInstance;
		public static LoginForm DefaultInstance
		{
			get
			{
				if (_DefaultInstance == null || _DefaultInstance.IsDisposed)
					_DefaultInstance = new LoginForm();

				return _DefaultInstance;
			}
		}
	}

}