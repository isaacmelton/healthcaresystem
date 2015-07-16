using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareSystem.dbAccess;
using HealthCareSystem.model;

namespace HealthCareSystem.controller
{
    /// <summary>
    /// NurseController controls the flow of nurse data.
    /// </summary>
    class NurseController
    {
        public static int AddNurse(User nurse)
        {
            int nurseId = -1;
            try
            {
                nurseId = PersonDB.AddPerson((Person) nurse);

                if (nurseId == -1)
                {
                    throw new Exception("Error adding the nurse to the Database");
                }
                else
                {
                    NurseDB.AddNurse(nurseId, nurse);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

            return nurseId;
        }

        public static Nurse GetNurseByID(int nurseID)
        {
            return NurseDB.GetNurseByID(nurseID);
        }

        public static List<User> GetNursesList()
        {
            List<User> nurses = new List<User>();
            try
            {
                nurses = NurseDB.GetAllNurses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
            return nurses;
        }

        public bool UpdateNurse(User oldNurse, User newNurse)
        {
            return PersonDB.UpdateUser(oldNurse, newNurse);
        }

        public static bool DeleteNurseByID(int id)
        {
            try
            {
                bool userDel = NurseDB.DeleteNurse(id);
                return userDel;
            }
            catch 
            {
                throw;
            }

        }
    }
}
