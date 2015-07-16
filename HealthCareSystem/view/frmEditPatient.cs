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
    public partial class frmEditPatient : Form
    {
        Patient oldPatient;
        private int patientID = -1;
        private List<Control> controls = new List<Control>();

        public frmEditPatient(int patientID)
        {
            InitializeComponent();

            this.patientID = patientID;

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

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            oldPatient = PatientController.GetPatientByID(patientID);

            tbLastName.Text = oldPatient.LastName;
            tbMiddleInitial.Text = oldPatient.MiddleInitial.ToString();
            tbFirstName.Text = oldPatient.FirstName;
            tbBirthdate.Value = oldPatient.DateOfBirth;
            cbGender.SelectedIndex = oldPatient.Gender.ToString().ToLower().Equals("m") ? 0 : 1;
            tbSSN.Text = oldPatient.Ssn;
            tbAddress.Text = oldPatient.Address;
            tbCity.Text = oldPatient.City;
            cbState.Text = oldPatient.State;
            tbZip.Text = oldPatient.Zip;
            tbPhone.Text = oldPatient.Phone;
        }

        #endregion Overrides

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

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validator.AreAllPresent(controls) && Validator.IsStateZipCode(tbZip) && Validator.IsPhoneNumber(tbPhone))
                {
                    Patient newPatient = new Patient();
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

                    bool edited = PatientController.UpdatePatient(oldPatient, newPatient);

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

        #endregion Event Handlers
    }
}
