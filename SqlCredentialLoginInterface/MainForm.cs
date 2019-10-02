using System;
using System.Windows.Forms;
using LoginLibrary.DataClasses.DataClasses;

namespace SqlCredentialLoginInterface
{
	public partial class MainForm
	{

		private readonly byte[] _userNameBytes;
		private readonly byte[] _userPasswordBytes;

		private readonly BindingSource _productBindingSource = new BindingSource();

		public MainForm(byte[] pNameBytes, byte[] pPasswordBytes)
		{

			InitializeComponent();

			_userNameBytes = pNameBytes;
			_userPasswordBytes = pPasswordBytes;

		}
		private void MainForm_Load(object sender, EventArgs e)
		{

			var ops = new DataOperations(
			    _userNameBytes, 
			    _userPasswordBytes, 
			    ".\\SQLEXPRESS", 
			    "UserLoginExample");

			var productTable = ops.ReadProductsByCategory(1);
			if (ops.IsSuccessFul)
			{
				_productBindingSource.DataSource = productTable;
				ProductsDataGridView.DataSource = _productBindingSource;
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