using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareSystem.controller;
using HealthCareSystem.model;

namespace HealthCareSystem.view
{
    public partial class frmViewDoctors : Form
    {
        private List<User> users;
        private int selectedUser;

        public frmViewDoctors()
        {
            InitializeComponent();
        }

        #region CanShow Implementation

        private static int numShown = 0;

        /// <summary>
        /// Returns a boolean that is true IFF the form is not already shown.
        /// </summary>
        /// <returns>a boolean that is true IFF the form is not already shown</returns>
        public bool CanShow()
        {
            return numShown == 0;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ShowDoctors();
            numShown++;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            numShown--;
        }

        #endregion CanShow Implementation

        private void ShowDoctors()
        {
            users = DoctorController.GetDoctorsList();
            lbUsers.Items.Clear();
            if (users.Count > 0)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    lbUsers.Items.Add(users[i].FullName);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedIndex >=0)
            {
                selectedUser = lbUsers.SelectedIndex;
                if (MessageBox.Show("Are you sure you want to delete " + users[selectedUser].FullName, "Confirm Delete?",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {

                        bool success = DoctorController.DeleteDoctorByID(users[selectedUser].PersonId);
                        if (success)
                        {
                            MessageBox.Show("Successfully removed user: " + users[selectedUser].FullName, "Success",
                                MessageBoxButtons.OK);
                            ShowDoctors();
                        }
                        else
                        {
                            MessageBox.Show("Failed to remove user: " + users[selectedUser].FullName, "Failure",
                                MessageBoxButtons.OK);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);

                    }

                }

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedIndex >= 0)
            {
                selectedUser = lbUsers.SelectedIndex;
                frmEditUser edit = new frmEditUser(users[selectedUser].PersonId);
                edit.Show();
            }
        }
    }
}
