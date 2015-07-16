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
    public partial class frmSearch : Form
    {
        private Boolean dobEntered = false;

        public frmSearch()
        {
            InitializeComponent();
            AcceptButton = searchButton;
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
            searchResultLabel.Text = "";
        }

        #endregion Overrides

        #region Event Handlers
        
        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (lastNameTextBox.Text != "" && firstNameTextBox.Text != "" && !dobEntered)
                {
                    searchGrid.DataSource = PatientController.SearchPatient(lastNameTextBox.Text, firstNameTextBox.Text);
                }
                else if (lastNameTextBox.Text != "" && dobEntered)
                {
                    searchGrid.DataSource = PatientController.SearchPatient(DateTime.Parse(birthdateTextBox.Text), lastNameTextBox.Text);
                }
                else if (dobEntered)
                {
                    searchGrid.DataSource = PatientController.SearchPatient(DateTime.Parse(birthdateTextBox.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void birthdateTextBox_ValueChanged(object sender, EventArgs e)
        {
            dobEntered = true;
        }

        private void editPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = searchGrid.SelectedRows;
            DataGridViewRow row = rows[0];
            int patientID = Convert.ToInt32(row.Cells[0].Value);

            frmMain parent = MdiParent as frmMain;
            parent.EditPatient(patientID);
        }

        private void searchGrid_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = searchGrid.SelectedRows;
            DataGridViewRow row = rows[0];
            int patientID = Convert.ToInt32(row.Cells[0].Value);

            frmMain parent = MdiParent as frmMain;
            parent.EditPatient(patientID);
        }

        #endregion Event Handlers

    }
}
