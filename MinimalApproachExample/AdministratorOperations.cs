using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApproachExample
{
    /// <summary>
    /// Responsible for 
    /// * Flagging user with failed login
    /// * Unflagging a user (this really belong outside the app in a
    ///   admin tool.
    /// * Checking if a user can login.
    ///
    /// For this to work, another table is needed that only a specific
    /// user other than regular users can perform read and write operations.
    ///
    /// Also consideration is needed to act upon a database on a server vs
    /// a database which is on a user's computer.
    /// </summary>
    public class AdministratorOperations
    {
        public void ReinstateUser(string userName)
        {
            /*
             * TODO clear unauthorized flag from flagged table
             * Should return a bool for success or not
             */
        }

        public void RevokeUser(string userName)
        {
            // TODO user failed with three attempts
        }

        public bool CanLogin(string userName)
        {
            /*
             * TODO query table with flagged users with failed logins
             *
             * Return true if they are not flagged, return false if flagged
             */

            return true; // appease compiler for this mockup
        }
    }
}
