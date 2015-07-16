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
    public partial class frmAddCheckup : Form
    {
        private Vitals newVitals;
        private List<Control> controls = new List<Control>();

        public frmAddCheckup()
        {
            InitializeComponent();

            controls.Add(bloodPressureTextBox);
            controls.Add(cbAppointmentID);
            controls.Add(bodyTempTextBox);
            controls.Add(pulseTextBox);
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

        private void frmAddCheckup_Load(object sender, EventArgs e)
        {
            cbAppointmentID.DataSource = AppointmentController.GetAppointmentsWithoutVitals();
            cbAppointmentID.DisplayMember = "AppointmentID";
            cbAppointmentID.ValueMember = "AppointmentID";

        }

        #endregion Helper Methods

        #region Event Handlers

        /// <summary>
        /// Closes the add checkup form and makes no changes.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Processes the checkup and adds it to the database.
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            //Validates required fields.
            if (Validator.AreAllPresent(controls) && Validator.IsDecimal(bodyTempTextBox) && Validator.IsDecimal(pulseTextBox))
            {
                newVitals = new Vitals();
                newVitals.AppointmentId = Convert.ToInt32(cbAppointmentID.SelectedValue);
                newVitals.BloodPressure = bloodPressureTextBox.Text;
                newVitals.BodyTemperature = Convert.ToDecimal(bodyTempTextBox.Text);
                newVitals.Pulse = Convert.ToDecimal(pulseTextBox.Text);

                int newVitalsID = VitalsController.AddVitals(newVitals);
                if (newVitalsID > -1)
                {
                    MessageBox.Show("Checkup vitals added.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllControls();
                }
                else
                {
                    MessageBox.Show("Checkup vitals not added.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        #endregion Event Handlers


    }
}
