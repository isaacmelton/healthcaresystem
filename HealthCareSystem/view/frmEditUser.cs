using HealthCareSystem.controller;
using HealthCareSystem.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareSystem.view
{
    public partial class frmEditUser : Form
    {
        User oldUser;
        private int userID = -1;
        private List<Control> controls = new List<Control>();

        public frmEditUser(int userID)
        {
            InitializeComponent();

            this.userID = userID;

            controls.Add(tbUserName);
            controls.Add(cbUserRole);
            controls.Add(tbLastName);
            controls.Add(tbFirstName);
            controls.Add(cbGender);
            controls.Add(tbSSN);
            controls.Add(tbAddress);
            controls.Add(tbCity);
            controls.Add(cbState);
            controls.Add(tbZip);
            controls.Add(tbPhone);
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
            numShown++;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            numShown--;
        }

        #endregion CanShow Implementation

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            oldUser = UserController.GetUserByID(userID);

            cbUserRole.Items.IndexOf(oldUser.UserRole);

            tbUserName.Text = oldUser.UserName;
            tbLastName.Text = oldUser.LastName;
            tbMiddleInitial.Text = oldUser.MiddleInitial.ToString();
            tbFirstName.Text = oldUser.FirstName;
            tbBirthdate.Value = oldUser.DateOfBirth;
            cbGender.SelectedIndex = oldUser.Gender.ToString().ToLower().Equals("m") ? 0 : 1;
            tbSSN.Text = oldUser.Ssn;
            tbAddress.Text = oldUser.Address;
            tbCity.Text = oldUser.City;
            cbState.Text = oldUser.State;
            tbZip.Text = oldUser.Zip;
            tbPhone.Text = oldUser.Phone;
        }

        #endregion Overrides

        #region Event Handlers

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validator.AreAllPresent(controls))
                {
                    User newUser = new User();
                    newUser.LastName = tbLastName.Text;
                    if (tbMiddleInitial.Text != "")
                    {
                        newUser.MiddleInitial = tbMiddleInitial.Text.ToCharArray()[0];
                    }
                    newUser.FirstName = tbFirstName.Text;
                    newUser.DateOfBirth = tbBirthdate.Value;
                    newUser.Gender = cbGender.SelectedItem.ToString().ToCharArray()[0];

                    tbSSN.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    newUser.Ssn = tbSSN.Text;
                    tbSSN.TextMaskFormat = MaskFormat.IncludeLiterals;

                    newUser.Address = tbAddress.Text;
                    if (tbAptNum.Text != "")
                    {
                        newUser.Address += " Apt. #: " + tbAptNum.Text;
                    }
                    newUser.City = tbCity.Text;
                    newUser.State = cbState.Text;

                    tbZip.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    newUser.Zip = tbZip.Text;
                    tbZip.TextMaskFormat = MaskFormat.IncludeLiterals;

                    tbPhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    newUser.Phone = tbPhone.Text;
                    tbPhone.TextMaskFormat = MaskFormat.IncludeLiterals;

                    newUser.UserRole = oldUser.UserRole;

                    newUser.UserName = oldUser.UserName;

                    bool edited = UserController.UpdateUser(oldUser, newUser);

                    if (!edited)
                        throw new Exception("Update unsuccessful!");

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Event Handlers
    }
}
