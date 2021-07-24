using System;
using System.Linq;
using System.Windows.Forms;
using LoginLibrary.DataClasses.DataClasses;
using LoginLibrary.SupportClasses;
using SupportLibrary;
using static SupportLibrary.EnumExtensions;

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
                "UserLoginExample", true);

            

            var productTable = ops.ReadProductsByCategory(1);
            if (ops.IsSuccessFul)
            {

                _productBindingSource.DataSource = productTable;
                ProductsDataGridView.DataSource = _productBindingSource;

                var controls = this.ButtonList();

                Text = ops.User.Name;
                if (ops.User.RoleType == RoleTypes.Admin)
                {
                    controls.ForEach(b => b.Enabled = true);
                }
                else
                {
                    controls.Where(b => EnumParser<RoleTypes>(b.Tag.ToString()) == RoleTypes.User).ToList().ForEach(b => b.Enabled = true);
                }
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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}