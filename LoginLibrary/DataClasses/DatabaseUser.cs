using System;
using System.Data.SqlClient;
using System.Security;
using LoginLibrary.SecurityClasses.SecurityClasses;
using LoginLibrary.SupportClasses.SupportClasses;

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
            /// <summary>
            /// Alternate method to login
            /// SqlCredential Class
            /// https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcredential?view=netframework-4.8
            ///
            /// See full working method below.
            /// </summary>
            public void SqlCredentialExample()
            {
                var ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=UserLoginExample";
                var userName = "KarenPayne";
                var password = "password1";

                var securePassword = new SecureString();

                foreach (var character in password)
                {
                    securePassword.AppendChar(character);
                }

                securePassword.MakeReadOnly();

                var credentials = new SqlCredential(userName, securePassword);

                using (var cn = new SqlConnection { ConnectionString = ConnectionString })
                {
                    cn.Credential = credentials;
                    cn.Open();
                }
            }
            /// <summary>
            /// Alternate method to login
            /// SqlCredential Class
            /// https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcredential?view=netframework-4.8
            /// </summary>
            public SqlServerLoginResult SqlCredentialLogin(byte[] pNameBytes, byte[] pPasswordBytes)
            {
                var loginResult = new SqlServerLoginResult();
                var secureOperations = new Encryption();

                var userName = secureOperations.Decrypt(pNameBytes, "111");
                var userPassword = secureOperations.Decrypt(pPasswordBytes, "111");

                string connectionString = $"Data Source={serverName};" + 
                                          $"Initial Catalog={catalogName};";


                var securePassword = new SecureString();

                foreach (var character in userPassword)
                {
                    securePassword.AppendChar(character);
                }

                securePassword.MakeReadOnly();

                var credentials = new SqlCredential(userName, securePassword);

                using (var cn = new SqlConnection {ConnectionString = connectionString})
                {
                    try
                    {
                        cn.Credential = credentials;
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

                using (var cn = new SqlConnection { ConnectionString = ConnectionString })
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