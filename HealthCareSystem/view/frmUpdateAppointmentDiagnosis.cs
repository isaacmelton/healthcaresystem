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
    public partial class frmUpdateAppointmentDiagnosis : Form
    {
        private List<Appointment> appointmentList;
        private Appointment oldApp;
        private Appointment newApp;

        public frmUpdateAppointmentDiagnosis()
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
            GetUndiagnosedAppointments();
            numShown++;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            numShown--;
        }

        #endregion CanShow Implementation

        private void GetUndiagnosedAppointments()
        {
            tbDiagnosis.Text = "";

            cbAppointments.SelectedIndexChanged -= cbAppointments_SelectedIndexChanged;
            cbAppointments.DataSource = null;
            cbAppointments.Items.Clear();
            cbAppointments.SelectedIndexChanged += cbAppointments_SelectedIndexChanged;

            appointmentList = AppointmentController.GetAppointmentsWithoutDiagnosis();
            cbAppointments.DataSource = appointmentList;
            cbAppointments.DisplayMember = "AppointmentID";
            cbAppointments.ValueMember = "AppointmentID";
        }

        private void SetAppointmentFields()
        {
            oldApp = AppointmentController.GetAppointmentInfo(appointmentList[cbAppointments.SelectedIndex].AppointmentId);

            tbNurse.Text = NurseController.GetNurseByID(oldApp.NurseId).UserName;
            tbPatient.Text = PatientController.GetPatientByID(oldApp.PersonId).FullName;
            tbSymptoms.Text = oldApp.Symptom;
            tbDate.Value = oldApp.AppointmentDate;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool success = false;

            try
            {
                newApp = oldApp;
                if (Validator.IsPresent(tbDiagnosis))
                {
                    newApp.Diagnosis = tbDiagnosis.Text;
                    success = AppointmentController.UpdateAppointmentDiagnosis(oldApp, newApp);
                    GetUndiagnosedAppointments();
                }
                if (success)
                {
                    MessageBox.Show("Diagnosis has been successfully updated!", "Appointment Updated!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                    MessageBox.Show("The appointment has not been updated.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAppointmentFields();
        }
    }
}
