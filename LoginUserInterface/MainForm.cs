using System;
using System.Windows.Forms;
using LoginLibrary.DataClasses.DataClasses;

namespace LoginUserInterface
{
	public partial class MainForm
	{

		private byte[] userNameBytes;
		private byte[] userPasswordBytes;

		private BindingSource ProductBindingSource = new BindingSource();

		public MainForm(byte[] pNameBytes, byte[] pPasswordBytes)
		{

			InitializeComponent();

			userNameBytes = pNameBytes;
			userPasswordBytes = pPasswordBytes;

		}
		private void MainForm_Load(object sender, EventArgs e)
		{

			var ops = new DataOperations(
			    userNameBytes, 
			    userPasswordBytes, 
			    "KARENS-PC", 
			    "UserLoginExample");

			var productTable = ops.ReadProductsByCategory(1);
			if (ops.IsSuccessFul)
			{
				ProductBindingSource.DataSource = productTable;
				ProductsDataGridView.DataSource = ProductBindingSource;
			}
			else
			{
				MessageBox.Show($"Encountered issues: {ops.LastExceptionMessage}");
			}

		}
		private void MainFormClosed(object sender, FormClosedEventArgs e)
		{
			Application.ExitThread();
		}
	}
}