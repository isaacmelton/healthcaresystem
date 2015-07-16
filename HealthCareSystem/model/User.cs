using HealthCareSystem.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.model
{
    /// <summary>
    /// Model of a user.
    /// </summary>
    public class User : Person
    {
        private int userID;
        private String userName;
        private String userRole;
        private byte[] userPassword;
        private Boolean loggedIn;

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public void SetPassword(String plainTextPassword)
        {
            userPassword = HashPasswordString(plainTextPassword);
        }

        public void SetPassword(byte[] hashedPassword)
        {
            userPassword = hashedPassword;
        }

        public byte[] GetPasswordHash()
        {
            return userPassword;
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }



        /// <summary>
        /// Public getter/setter
        /// </summary>
        public String UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public Boolean LoggedIn
        {
            get { return loggedIn; }
            set { loggedIn = value; }
        }

        /// <summary>
        /// Logs the user in.
        /// </summary>
        /// <param name="userName">The user's username</param>
        /// <param name="password">The user's password</param>
        public void LogIn(String userName, String password)
        {
            try
            {
                Boolean passwordMatch = CheckPassword(userName, password);

                if (passwordMatch)
                {
                    LoggedIn = true;
                    UserName = userName;
                    UserID   = UserController.DetermineUserID(userName);
                    UserRole = UserController.DetermineUserRole(userName);
                }
                else if (!passwordMatch)
                {
                    throw new Exception("Incorrect username or password.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Logs the user out.
        /// </summary>
        public void LogOut()
        {
            UserID = -1;
            UserName = "";
            UserRole = "";
            LoggedIn = false;
        }

        /// <summary>
        /// Determines a person's role and ID.
        /// </summary>
        /// <param name="userName">The user name to look up</param>
        /// <returns>A dictionary containing the user ID and user role</returns>
        public Dictionary<int, String> GetUserRoleAndID(String userName)
        {
            return UserController.DetermineUserRoleAndID(userName);
        }

        /// <summary>
        /// Allows the user to change their password if it is not the same as their current password.
        /// </summary>
        /// <param name="id">The user's ID.</param>
        /// <param name="newPassword">The new password.</param>
        public void ChangePassword(String userName, String newPassword)
        {
            try
            {
                //if the password is not their old password, store it
                if (!CheckPassword(userName, newPassword))
                    UserController.ChangePasswordForUser(userName, HashPasswordString(newPassword));
                else
                    throw new InvalidPasswordException("Invalid password, please try a different password.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Checks the user input password.
        /// </summary>
        /// <param name="id">The user's ID.</param>
        /// <param name="plainTextPassword">The password the user input.</param>
        /// <returns>True IFF the input password digest is equal to the digest stored in the DB.</returns>
        public Boolean CheckPassword(String userName, String plainTextPassword)
        {
            //do some password checking in the dbAccess layer
            try
            {
                byte[] digestFromDB = UserController.GetPasswordForUser(userName);
                byte[] digestFromInput = HashPasswordString(plainTextPassword);

                Boolean passwordCheck = digestFromDB.SequenceEqual(digestFromInput);

                //Just testing - this will be useful to see in the console
                //DebugPasswords(digestFromDB, "Database");
                //DebugPasswords(digestFromInput, "User input");

                return passwordCheck;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Hashes a string using SHA256.
        /// </summary>
        /// <param name="plainTextPassword">The string to hash.</param>
        /// <returns>A byte array of the hashed string.</returns>
        private byte[] HashPasswordString(String plainTextPassword)
        {
            try
            {
                SHA256Managed crypt = new SHA256Managed();
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(plainTextPassword);
                byte[] digestBytes = crypt.ComputeHash(textBytes);

                return digestBytes;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Private debug method.
        /// </summary>
        /// <param name="digest">The password digest</param>
        /// <param name="digestOrigin">Where the digest originated</param>
        private void DebugPasswords(byte[] digest, String digestOrigin)
        {
            Console.WriteLine(digestOrigin + ": ");
            for (int i = 0; i < digest.Length; i++)
            {
                Console.Write(String.Format("{0:X2}", digest[i]));
                if ((i % 4) == 3) Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
