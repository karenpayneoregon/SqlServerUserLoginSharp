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
        public bool SqlCredentialLogin(string pUserNName, string pPassword)
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
                try
                {
                    cn.Credential = credentials;
                    cn.Open();
                    // do work here
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
