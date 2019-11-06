using System;
using System.Data.SqlClient;
using System.Security;

namespace MinimalApproachExample
{
    public class DatabaseUser
    {
        private string serverName;
        private string catalogName;
        public DatabaseUser(string pServerName, string pCatalogName)
        {
            serverName = pServerName;
            catalogName = pCatalogName;
        }
        public bool SqlCredentialLogin(string pUserName, string pPassword)
        {

            string connectionString = $"Data Source={serverName};" +
                                      $"Initial Catalog={catalogName};";


            var securePassword = new SecureString();

            foreach (var character in pPassword)
            {
                securePassword.AppendChar(character);
            }

            securePassword.MakeReadOnly();

            var credentials = new SqlCredential(pUserName, securePassword);

            using (var cn = new SqlConnection { ConnectionString = connectionString })
            {
                try
                {
                    cn.Credential = credentials;
                    cn.Open();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Create a table only when the table does not currently exists.
        /// If the user does not have permissions this will fail. Permissions
        /// are set under the security table in Object Explorer. Select the database
        /// then set the permissions.
        /// </summary>
        /// <param name="pUserNName"></param>
        /// <param name="pPassword"></param>
        /// <returns></returns>
        public string DoWork(string pUserNName, string pPassword)
        {

            string connectionString = $"Data Source={serverName};" +
                                      $"Initial Catalog={catalogName};";


            var securePassword = new SecureString();

            foreach (var character in pPassword)
            {
                securePassword.AppendChar(character);
            }

            securePassword.MakeReadOnly();

            var credentials = new SqlCredential(pUserNName, securePassword);

            using (var cn = new SqlConnection { ConnectionString = connectionString })
            {
                using (var cmd = new SqlCommand { Connection = cn })
                {
                    try
                    {
                        // Table name to create
                        var tableName = "Person";

                        cmd.CommandText = "SELECT CASE WHEN exists((SELECT * FROM information_schema.tables " + 
                                          $"WHERE table_name = '{tableName}')) THEN 1 ELSE 0 END;";

                        cn.Credential = credentials;
                        cn.Open();

                        // check to see if table currently exists, if not create the table
                        var exists = (int)cmd.ExecuteScalar() == 1;

                        if (exists == false)
                        {
                            /*
                             * Must have db_owner permissions to database
                             */
                            cmd.CommandText ="CREATE TABLE Person (PersonIdentifier INT PRIMARY KEY," +
                                             "FirstName VARCHAR(50) NOT NULL," +
                                             "LastName VARCHAR(50) NOT NULL);";

                            cmd.ExecuteNonQuery();
                        }

                        return "";
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
            }


        }
    }
}
