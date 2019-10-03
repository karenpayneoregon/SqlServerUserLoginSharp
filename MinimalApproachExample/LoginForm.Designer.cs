using System.Windows.Forms;

//INSTANT C# NOTE: Formerly VB project-level imports:

namespace MinimalApproachExample
{
	public partial class LoginForm : System.Windows.Forms.Form
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.CancelLoginButton = new System.Windows.Forms.Button();
            this.ShowHidePasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(32, 31);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(58, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "User name";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(32, 65);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(53, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Password";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(96, 28);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(135, 20);
            this.UserNameTextBox.TabIndex = 2;
            this.UserNameTextBox.Text = "KarenPayne";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(96, 62);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(135, 20);
            this.PasswordTextBox.TabIndex = 3;
            this.PasswordTextBox.Text = "password1";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(35, 105);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "OK";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // CancelLoginButton
            // 
            this.CancelLoginButton.Location = new System.Drawing.Point(156, 105);
            this.CancelLoginButton.Name = "CancelLoginButton";
            this.CancelLoginButton.Size = new System.Drawing.Size(75, 23);
            this.CancelLoginButton.TabIndex = 5;
            this.CancelLoginButton.Text = "Cancel";
            this.CancelLoginButton.UseVisualStyleBackColor = true;
            this.CancelLoginButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ShowHidePasswordCheckBox
            // 
            this.ShowHidePasswordCheckBox.AutoSize = true;
            this.ShowHidePasswordCheckBox.Checked = true;
            this.ShowHidePasswordCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowHidePasswordCheckBox.Location = new System.Drawing.Point(237, 65);
            this.ShowHidePasswordCheckBox.Name = "ShowHidePasswordCheckBox";
            this.ShowHidePasswordCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ShowHidePasswordCheckBox.TabIndex = 6;
            this.ShowHidePasswordCheckBox.UseVisualStyleBackColor = true;
            this.ShowHidePasswordCheckBox.CheckedChanged += new System.EventHandler(this.ShowHidePasswordCheckBox_CheckedChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 163);
            this.Controls.Add(this.ShowHidePasswordCheckBox);
            this.Controls.Add(this.CancelLoginButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login code sample";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		internal Label Label1;
		internal Label Label2;
		internal TextBox UserNameTextBox;
		internal TextBox PasswordTextBox;
		internal Button LoginButton;
		internal Button CancelLoginButton;
		internal CheckBox ShowHidePasswordCheckBox;
	}

}