using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using HealthCareSystem.controller;
using HealthCareSystem.model;

namespace HealthCareSystem.view
{
    public partial class frmAddUser : Form
    {
        private List<Control> controls = new List<Control>();
        private enum UserType
        {
            ADMINISTRATOR, DOCTOR, PATIENT, NURSE
        }

        public frmAddUser()
        {
            Array userValues = System.Enum.GetValues(typeof (UserType));
            Array userNames = System.Enum.GetNames(typeof (UserType));

            InitializeComponent();

            //Add the enum names to the form
            for (int i = 0; i < userNames.Length; i++)
            {
                ListItem item = new ListItem(userNames.GetValue(i).ToString(), userValues.GetValue(i).ToString());
                cbRole.Items.Add(item);
            }

            //Add the controls to an array for validation
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

        #region Event Handlers

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            User newUser = new User();

            //Add username and password to the validation
            if (isAuthenticatedUser())
            {
                controls.Add(tbUserName);
                controls.Add(tbPassword);
            }

            try
            {
                if (Validator.AreAllPresent(controls))
                {
                    newUser.LastName = tbLastName.Text;
                    if (tbMiddleInitial.Text != "")
                    {
                        newUser.MiddleInitial = tbMiddleInitial.Text.ToCharArray()[0];
                    }
                    newUser.FirstName = tbFirstName.Text;
                    newUser.DateOfBirth = dateBirthDate.Value;
                    newUser.Gender = cbGender.SelectedItem.ToString().ToCharArray()[0];

                    tbSSN.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    newUser.Ssn = tbSSN.Text;
                    tbSSN.TextMaskFormat = MaskFormat.IncludeLiterals;

                    newUser.Address = tbAddress.Text;
                    if (tbApt.Text != "")
                    {
                        newUser.Address += " Apt. #: " + tbApt.Text;
                    }
                    newUser.City = tbCity.Text;
                    newUser.State = cbState.Text;

                    tbZip.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    newUser.Zip = tbZip.Text;
                    tbZip.TextMaskFormat = MaskFormat.IncludeLiterals;

                    tbPhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    newUser.Phone = tbPhone.Text;
                    tbPhone.TextMaskFormat = MaskFormat.IncludeLiterals;


                    int added = addUser(newUser);
                    
                    if (added == -1)
                        throw new Exception("Add unsuccessful!");
                    else
                    {
                        MessageBox.Show("Successfully added " + newUser.FullName + " with User ID of: " + added + "!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                    }

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add User Form: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int addUser(User person)
        {
            int result = -1;

            if (!isAuthenticatedUser())
            {
                Patient newPatient = PatientController.CreatePatient(person.LastName, 'a',
                    person.FirstName, person.DateOfBirth.ToString(), person.Gender, person.Ssn, person.Address, person.City,
                    person.State, person.Zip, person.Phone);
                result = PatientController.AddPatient(newPatient);
            }
            else
            {
                User newUser = person;
                
                newUser.UserName = tbUserName.Text;
                newUser.SetPassword(tbPassword.Text);
                
                if (cbRole.Text == UserType.DOCTOR.ToString())
                {
                    newUser.UserRole = "Doctor";
                    result = DoctorController.AddDoctor(newUser);
                }
                else if (cbRole.Text == UserType.ADMINISTRATOR.ToString())
                {
                    newUser.UserRole = "Administrator";
                    result = AdministratorController.AddAdministrator(newUser);
                }
                else if (cbRole.Text == UserType.NURSE.ToString())
                {
                    newUser.UserRole = "Nurse";
                    result = NurseController.AddNurse(newUser);
                }
            } 
            return result;
        }
        
        #endregion Event Handlers

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
                tbUserName.Enabled = isAuthenticatedUser();
                tbPassword.Enabled = isAuthenticatedUser();
        }

        private bool isAuthenticatedUser()
        {
            string role = cbRole.Text;
            if ((role == UserType.ADMINISTRATOR.ToString() || role == UserType.NURSE.ToString() || role == UserType.DOCTOR.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
