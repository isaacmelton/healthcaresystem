using HealthCareSystem.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareSystem.model;

namespace HealthCareSystem.view
{
    public partial class frmAddPatient : Form
    {
        private Patient newPatient;
        private List<Control> controls = new List<Control>();

        public frmAddPatient()
        {
            InitializeComponent();

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

        #region Helper Methods

        private void ClearAllControls()
        {
            foreach (Control control in controls)
            {
                String controlType = control.GetType().Name;
                if(controlType == "TextBox" || controlType == "MaskedTextBox")
                    control.Text = "";
            }
            tbMiddleInitial.Text = "";
        }

        #endregion Helper Methods

        #region Event Handlers

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Validates required fields.
            //TODO validate datetime for DOB
            if (Validator.AreAllPresent(controls) && Validator.IsStateZipCode(tbZip) && Validator.IsPhoneNumber(tbPhone))
            {
                int newPatientID = -1;

                newPatient = new Patient();
                newPatient.LastName = tbLastName.Text;
                if (tbMiddleInitial.Text != "")
                {
                    newPatient.MiddleInitial = tbMiddleInitial.Text.ToCharArray()[0];
                }
                newPatient.FirstName = tbFirstName.Text;
                newPatient.DateOfBirth = tbBirthdate.Value;
                newPatient.Gender = cbGender.SelectedItem.ToString().ToCharArray()[0];

                tbSSN.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                newPatient.Ssn = tbSSN.Text;
                tbSSN.TextMaskFormat = MaskFormat.IncludeLiterals;

                newPatient.Address = tbAddress.Text;
                if (tbAptNum.Text != "")
                {
                    newPatient.Address += " Apt. #: " + tbAptNum.Text;
                }
                newPatient.City = tbCity.Text;
                newPatient.State = cbState.Text;

                tbZip.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                newPatient.Zip = tbZip.Text;
                tbZip.TextMaskFormat = MaskFormat.IncludeLiterals;
           
                
                tbPhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                newPatient.Phone = tbPhone.Text;
                tbPhone.TextMaskFormat = MaskFormat.IncludeLiterals;
                
                //This doesn't properly handle the masked form fields and null instances.
                /**
                int newPatientID = PatientController.AddPatient(
                    PatientController.CreatePatient(
                        tbLastName.Text,
                        tbMiddleInitial.Text[0],
                        tbFirstName.Text,
                        tbBirthdate.Text,
                        cbGender.Text[0],
                        tbSSN.Text,
                        tbAddress.Text + " Apt#: " + tbAptNum.Text,
                        tbCity.Text,
                        tbState.Text,
                        tbZip.Text,
                        tbPhone.Text
                    )
                );
                 */

                newPatientID = PatientController.AddPatient(newPatient);
                if(newPatientID > -1)
                    MessageBox.Show("Patient successfully added.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Patient not added.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClearAllControls();
            }
        }
        #endregion Event Handlers
    }
}
