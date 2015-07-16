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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HealthCareSystem.view
{
    public partial class frmAddTest : Form
    {
        private Result newResult;
        private List<Appointment> appointmentsList;
        private List<LabTest> testList;
        private List<AppointmentInfo> appointmentInfos; 

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
            GetAppointmentIDsAndTests();
            numShown++;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            numShown--;
        }

        #endregion CanShow Implementation

        public frmAddTest()
        {
            InitializeComponent();
        }

        private void GetAppointmentIDsAndTests()
        {
            this.Clear();

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Select Test";
            ComboBox cbTests = new ComboBox();
            foreach (LabTest test in testList)
            {
                cmb.Items.Add(test.TestType);
            }
            dgvAddTest.Columns.Add(cmb);

            

            //cbAppointmentID.SelectedIndexChanged -= cbAppointmentID_SelectedIndexChanged;
            //cbAppointmentID.DataSource = null;
            //cbAppointmentID.Items.Clear();
            //cbAppointmentID.SelectedIndexChanged += cbAppointmentID_SelectedIndexChanged;

            //appointmentsList = AppointmentController.GetAppointmentsWithoutDiagnosis();
            //cbAppointmentID.DataSource = appointmentsList;
            //cbAppointmentID.DisplayMember = "AppointmentID";
            //cbAppointmentID.ValueMember = "AppointmentID";

            //cbTest.SelectedIndexChanged -= cbTest_SelectedIndexChanged;
            //cbTest.DataSource = null;
            //cbTest.Items.Clear();
            //cbTest.SelectedIndexChanged += cbTest_SelectedIndexChanged;

            //testList = LabTestController.GetAllLabTests();
            //cbTest.DataSource = testList;
            //cbTest.DisplayMember = "TestType";
            //cbTest.ValueMember = "TestId";
        }

        private int getTestId(String testName)
        {
            for (int i = 0; i < testList.Count; i++)
            {
                if (testName == testList[i].TestType)
                {
                    return testList[i].TestId;
                }
            }
            return -1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataGridViewRow row in dgvAddTest.Rows)
            {
                if ((row.Cells[3].Value) != null)
                {
                    int testid = getTestId(row.Cells[3].Value.ToString());
                    if (testid != -1)
                    {
                        newResult = new Result();
                    
                        newResult.AppointmentId = appointmentInfos[i].AppointmentId;
                        newResult.TestId = testid; 
                        int newResultID = ResultController.AddTestToAppointment(newResult);

                        if (newResultID == -1)
                        {
                            MessageBox.Show("Error adding test to appointment", "Error!", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Test " + row.Cells[3].Value + " ordered for " + appointmentInfos[i].Person.FullName + "!", "Success!", MessageBoxButtons.OK);
                        }
                    }
                }
                i++;
            }
            this.Clear();
        }

        private void Clear()
        {
            testList = LabTestController.GetAllLabTests();

            appointmentInfos = AppointmentController.GetAppointmentAndPersonInfoWithoutDiagnosis();

            dgvAddTest.Rows.Clear();

            foreach (AppointmentInfo info in appointmentInfos)
            {
                DataGridViewRow row = (DataGridViewRow)dgvAddTest.Rows[0].Clone();
                //appointmentDate
                //patientName
                //symptom
                //test
                row.Cells[0].Value = info.AppointmentDate.ToString("d");
                row.Cells[1].Value = info.Person.FullName;
                row.Cells[2].Value = info.Symptom;
                dgvAddTest.Rows.Add(row);
            }            
        }
             
  

        private void PutResultData(Result result)
        {
            //result.AppointmentId = (int)cbAppointmentID.SelectedValue;
            //result.TestId = (int)cbTest.SelectedValue;

        }

        private void btnTestCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbAppointmentID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbTest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvAddTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
       

    }
}
