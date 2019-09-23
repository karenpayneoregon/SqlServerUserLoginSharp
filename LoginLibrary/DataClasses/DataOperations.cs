using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using LoginLibrary.SecurityClasses.SecurityClasses;
using SupportLibrary;

namespace LoginLibrary.DataClasses
{
	namespace DataClasses
	{

		public class DataOperations : BaseExceptionProperties
		{
			private string ConnectionString;
			
			public DataOperations(byte[] pNameBytes, byte[] pPasswordBytes, string pServerName, string pCatalogName)
			{

				var secureOperations = new Encryption();

				ConnectionString = 
				    $"Data Source={pServerName};Initial Catalog={pCatalogName};" + 
				    $"User Id={secureOperations.Decrypt(pNameBytes, "111")};" + 
				    $"Password={secureOperations.Decrypt(pPasswordBytes, "111")};" +
				    "Integrated Security=False";

				Console.WriteLine();
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