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
    public partial class frmAddAppointment : Form
    {

        private Appointment newAppointment;
        private List<Control> controls = new List<Control>();

        public frmAddAppointment()
        {
            InitializeComponent();

            controls.Add(nurseTextBox);
            controls.Add(dateTextBox);
            controls.Add(comboBoxPatient);
            controls.Add(symptomsTextBox);
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
                if (controlType == "TextBox" || controlType == "MaskedTextBox")
                    control.Text = "";
            }
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
            if (Validator.AreAllPresent(controls))
            {
                newAppointment = new Appointment();
                newAppointment.PersonId = Convert.ToInt32(comboBoxPatient.SelectedValue);
                newAppointment.NurseId = GlobalVars.Instance.CurrentUser.UserID;
                newAppointment.DoctorId = Convert.ToInt32(cbDoctor.SelectedValue);
                newAppointment.AppointmentDate = dateTextBox.Value;
                newAppointment.Symptom = symptomsTextBox.Text;

                int appID = AppointmentController.AddAppointment(newAppointment);
                if (appID > -1)
                    MessageBox.Show("Appointment scheduled.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Appointment not scheduled.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClearAllControls();


            }
        }

        #endregion Event Handlers

        private void frmAddAppointment_Load(object sender, EventArgs e)
        {
            comboBoxPatient.DataSource = PatientController.GetAllPatients();
            comboBoxPatient.DisplayMember = "FullName";
            comboBoxPatient.ValueMember = "PersonId";
            nurseTextBox.Text = GlobalVars.Instance.CurrentUser.UserName;

            cbDoctor.DataSource = DoctorController.GetDoctorsList();
            cbDoctor.DisplayMember = "FullName";
            cbDoctor.ValueMember = "PersonId";

        }

    }
}
