using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using LoginLibrary.SecurityClasses.SecurityClasses;
using LoginLibrary.SupportClasses;
using SupportLibrary;

namespace LoginLibrary.DataClasses
{
	namespace DataClasses
	{

		public class DataOperations : BaseExceptionProperties
		{
			private string ConnectionString;

            private readonly User _user = new User();
            public User User => _user;
            public bool AdminUserSwitch { get; set; }
            
            /// <summary>
            /// Initialize class along with for one project get user role.
            /// </summary>
            /// <param name="pNameBytes">user name encrypted</param>
            /// <param name="pPasswordBytes">user password encrypted</param>
            /// <param name="pServerName"></param>
            /// <param name="pCatalogName"></param>
            /// <param name="pAdminUserSwitch">For demo purposes, see comments below</param>
			public DataOperations(byte[] pNameBytes, byte[] pPasswordBytes, string pServerName, string pCatalogName, bool pAdminUserSwitch = false)
            {

                AdminUserSwitch = pAdminUserSwitch;

				var secureOperations = new Encryption();
                var userName = secureOperations.Decrypt(pNameBytes, "111");
                _user.Name = userName;


				ConnectionString = 
				    $"Data Source={pServerName};Initial Catalog={pCatalogName};" + 
				    $"User Id={userName};" + 
				    $"Password={secureOperations.Decrypt(pPasswordBytes, "111")};" +
				    "Integrated Security=False";

                /*
                 * This is only used for project SqlCredentialLoginInterface
				 * For a real app, this is not needed. This is because there
				 * are three projects using this method and only SqlCredentialLoginInterface
                 * uses this functionality.
                 */
                if (AdminUserSwitch)
                {
					GetCurrentUser();
				}

            }
            /// <summary>
            /// Get user role, admin or user for use in main form of the project
            /// SqlCredentialLoginInterface
            /// </summary>
            private void GetCurrentUser()
            {
                using (var cn = new SqlConnection {ConnectionString = ConnectionString})
                {
                    using (var cmd = new SqlCommand {Connection = cn})
                    {
                        cmd.CommandText = "SELECT RoleType FROM dbo.Users WHERE UserName = @UserName;";
                        cmd.Parameters.AddWithValue("@UserName", _user.Name);
                        
                        cn.Open();
                        
                        var role = (int) cmd.ExecuteScalar();
                        _user.RoleType = (RoleTypes) role;
                        
                    }

				}

			}
			/// <summary>
			/// Connect to database via validated user name and password passed in the
			/// new constructor.
			/// 
			/// There are still failure points which include permissions to the tables
			/// for the user.
			/// </summary>
			/// <param name="pCategoryIdentifier"></param>
			/// <returns></returns>
			public DataTable ReadProductsByCategory(int pCategoryIdentifier)
			{

				mHasException = false;

				var productDataTable = new DataTable();
			    var selectStatement = 
			        "SELECT " + 
			        "P.ProductID , P.ProductName , P.SupplierID , P.CategoryID , " +
			        "P.QuantityPerUnit , P.UnitPrice , P.UnitsInStock , " +
			        "S.CompanyName AS Supplier FROM dbo.Products AS P " +
			        "INNER JOIN dbo.Categories AS C ON P.CategoryID = C.CategoryID " + 
			        "INNER JOIN dbo.Suppliers AS S ON P.SupplierID = S.SupplierID " + 
			        "WHERE(P.CategoryID = @CategoryID); ";

				using (var cn = new SqlConnection {ConnectionString = ConnectionString})
				{
					using (var cmd = new SqlCommand {Connection = cn})
					{

						cmd.Parameters.AddWithValue("@CategoryID", pCategoryIdentifier);
						cmd.CommandText = selectStatement;

						try
						{
							cn.Open();
							productDataTable.Load(cmd.ExecuteReader());

							var identifiers = productDataTable
							    .Columns.Cast<DataColumn>()
							    .Where((column) => column.ColumnName.EndsWith("ID"))
							    .Select((item) => item.ColumnName).ToList();

							foreach (string columnName in identifiers)
							{
								productDataTable.Columns[columnName].ColumnMapping = MappingType.Hidden;
							}

						}
						catch (Exception ex)
						{
							mHasException = true;
							mLastException = ex;
						}
					}
				}

				return productDataTable;

			}
		}
	}

}