﻿using System;
using System.Data.SqlClient;
using LoginLibrary.SecurityClasses;
using LoginLibrary.SecurityClasses.SecurityClasses;
using LoginLibrary.SupportClasses;

namespace LoginLibrary.DataClasses
{
	namespace DataClasses
	{
		/// <summary>
		/// Responsible to validating a user has permissions 
		/// to access the database, not tables.
		/// </summary>
		public class DatabaseUser
		{
			private string serverName;
			private string catalogName;
			public DatabaseUser(string pServerName, string pCatalogName)
			{
				serverName = pServerName;
				catalogName = pCatalogName;
			}
			public SqlServerLoginResult Login(byte[] pNameBytes, byte[] pPasswordBytes)
			{
				var loginResult = new SqlServerLoginResult();

				var secureOperations = new Encryption();
				var userName = secureOperations.Decrypt(pNameBytes, "111");
				var userPassword = secureOperations.Decrypt(pPasswordBytes, "111");


				string ConnectionString = 
				    $"Data Source={serverName};" +
				    $"Initial Catalog={catalogName};" + 
				    $"User Id={userName};Password={userPassword};" +
				    "Integrated Security=False";

				using (var cn = new SqlConnection {ConnectionString = ConnectionString})
				{
					try
					{
						cn.Open();
						loginResult.Success = true;
					}
					catch (SqlException failedLoginException) when (failedLoginException.Number == 18456)
					{
						loginResult.Success = false;
						loginResult.GenericException = false;
						loginResult.Message = "Can not access data.";
					}
					catch (SqlException genericSqlException)
					{
						loginResult.Success = false;
						loginResult.GenericException = false;
						loginResult.Message = "Can not access data.";
					}
					catch (Exception ex)
					{
						loginResult.Success = false;
						loginResult.GenericException = true;
						loginResult.Message = ex.Message;
					}
				}

				return loginResult;

			}
		}
	}
}