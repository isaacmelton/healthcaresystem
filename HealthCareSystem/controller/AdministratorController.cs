using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HealthCareSystem.dbAccess;
using HealthCareSystem.model;

namespace HealthCareSystem.controller
{
    /// <summary>
    /// AdministratorController controls the flow of administrator data.
    /// </summary>
    class AdministratorController
    {
        public static int AddAdministrator(User admin)
        {
            int adminID = -1;
            try
            {
                adminID = PersonDB.AddPerson((Person) admin);
                if (adminID != -1)
                {
                    AdministratorDB.AddAdministrator(adminID, admin);
                }
                else
                {
                    throw new Exception("Error adding the administrator to the Database");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Administrator Controller: " + ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
            return adminID;
        }

        public static List<User> GetAdministratorsList()
        {
            List<User> administrators = new List<User>();
            try
            {
                administrators = AdministratorDB.GetAllAdministrators();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
            return administrators;
        }

        public bool UpdateAdministrator(User oldAdministrator, User newAdministrator)
        {
            return PersonDB.UpdateUser(oldAdministrator, newAdministrator);
        }

        public static bool DeleteAdministratorByID(int id)
        {
            try
            {
                bool userDel = AdministratorDB.DeleteAdministrator(id);
                return userDel;
            }
            catch
            {
                throw;
            }

        }
    }
}
