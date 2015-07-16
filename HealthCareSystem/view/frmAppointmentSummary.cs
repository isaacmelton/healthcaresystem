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
    public partial class frmAppointmentSummary : Form
    {

        private List<Result> resultList;
        private Result theTest = new Result();
        private List<Result> allTestList;
        private List<Appointment> allAppointments = new List<Appointment>();
        private Appointment oldApp;


        public frmAppointmentSummary()
        {
            InitializeComponent();
        }

        private void frmAppointmentSummary_Load(object sender, EventArgs e)
        {
            this.GetResultList();
            this.GetTestData();

        }

        private void GetResultList()
        {
            try
            {
                cbAppId.SelectedIndexChanged -= cbAppId_SelectedIndexChanged;
                cbAppId.DataSource = null;
                cbAppId.Items.Clear();
                cbAppId.SelectedIndexChanged += cbAppId_SelectedIndexChanged;

                allAppointments = AppointmentController.GetAllAppointments();

                cbAppId.DataSource = allAppointments;
                cbAppId.DisplayMember = "AppointmentID";
                cbAppId.ValueMember = "AppointmentID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void GetTestData()
        {
            int appointmentID = (int)cbAppId.SelectedValue;

            try
            {
                theTest = ResultController.GetTestInfo(appointmentID);


                allTestList = ResultController.GetTestsForAppointment(appointmentID);
                dataGridView1.DataSource = allTestList;
                this.dataGridView1.Columns[1].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }


        private void cbAppId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetTestData();
                this.SetAppointmentFields();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void SetAppointmentFields()
        {
            oldApp = AppointmentController.GetAppointmentInfo(allAppointments[cbAppId.SelectedIndex].AppointmentId);

            tbNurse.Text = NurseController.GetNurseByID(oldApp.NurseId).UserName;
            tbPatient.Text = PatientController.GetPatientByID(oldApp.PersonId).FullName;
            tbSymptoms.Text = oldApp.Symptom;
            tbDate.Value = oldApp.AppointmentDate;
            tbDiagnosis.Text = oldApp.Diagnosis;
            tbDoctor.Text = DoctorController.GetDoctorByID(oldApp.DoctorId).FullName;
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

    

 

     
    }
}
