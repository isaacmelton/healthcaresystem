using HealthCareSystem.dbAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareSystem.model;

namespace HealthCareSystem.controller
{
    /// <summary>
    /// UserController controls the flow of user data.
    /// </summary>
    class UserController
    {
        /// <summary>
        /// Gets the password digest as a byte array.
        /// </summary>
        /// <param name="userName">The user name to look up</param>
        /// <returns>A byte array representing the password digest</returns>
        public static byte[] GetPasswordForUser(String userName)
        {
            byte[] digest = new byte[64];

            Dictionary<int, String> info = DetermineUserRoleAndID(userName);
            int id = info.First().Key;
            String role = info.First().Value;

            try
            {
                switch (role)
                {
                    case "Nurse":
                        digest = NurseDB.GetPasswordForUser(id);
                        break;
                    case "Doctor":
                        digest = DoctorDB.GetPasswordForUser(id);
                        break;
                    case "Administrator":
                        digest = AdministratorDB.GetPasswordForUser(id);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return digest;
        }

        /// <summary>
        /// Gets the password digest as a byte array.
        /// </summary>
        /// <param name="userName">The user name to look up</param>
        /// <returns>A byte array representing the password digest</returns>
        public static User GetUserByID(int userID)
        {
            String role = PersonDB.GetPersonRole(userID);
            User theUser = new User();

            try
            {
                switch (role)
                {
                    case "Nurse":
                        theUser = NurseDB.GetNurseByID(userID);
                        break;
                    case "Doctor":
                        theUser = DoctorDB.GetDoctorByID(userID);
                        break;
                    case "Administrator":
                        theUser = AdministratorDB.GetAdministratorByID(userID);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return theUser;
        }

        /// <summary>
        /// Changes the password for the specified user to the specified password.
        /// </summary>
        /// <param name="userName">The user to look up</param>
        /// <param name="password">The new password</param>
        public static void ChangePasswordForUser(String userName, byte[] password)
        {
            Dictionary<int, String> info = DetermineUserRoleAndID(userName);
            int id = info.First().Key;
            String role = info.First().Value;

            try
            {
                switch (role)
                {
                    case "Nurse":
                        NurseDB.ChangePassword(id, password);
                        break;
                    case "Doctor":
                        DoctorDB.ChangePassword(id, password);
                        break;
                    case "Administrator":
                        AdministratorDB.ChangePassword(id, password);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Determines a person's role and ID.
        /// </summary>
        /// <param name="userName">The user name to look up</param>
        /// <returns>A dictionary containing the user ID and user role</returns>
        public static Dictionary<int, String> DetermineUserRoleAndID(String userName)
        {
            return PersonDB.GetPersonRoleAndID(userName);
        }

        /// <summary>
        /// Determines a person's ID.
        /// </summary>
        /// <param name="userName">The user name to look up</param>
        /// <returns>The user ID</returns>
        public static int DetermineUserID(String userName)
        {
            return DetermineUserRoleAndID(userName).First().Key;
        }

        /// <summary>
        /// Determines a person's role.
        /// </summary>
        /// <param name="userName">The user name to look up</param>
        /// <returns>The user role</returns>
        public static String DetermineUserRole(String userName)
        {
            return DetermineUserRoleAndID(userName).First().Value;
        }


        internal static bool UpdateUser(User oldUser, User newUser)
        {
            bool success = false;

            try
            {
                success = PersonDB.UpdateUser(oldUser, newUser);
            }
            catch (Exception)
            {
                throw;
            }

            return success;
        }
    }
}
