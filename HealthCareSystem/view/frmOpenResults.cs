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
    public partial class frmOpenResults : Form
    {

        private List<Result> resultList;
        private Result theTest = new Result();
        private List<Result> openTestList;

        public frmOpenResults()
        {
            InitializeComponent();
        }

        private void frmOpenResults_Load(object sender, EventArgs e)
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

                resultList = ResultController.GetOpenTestsByAppointment();
                cbAppId.DataSource = resultList;
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


                openTestList = ResultController.GetOpenTestList(appointmentID);
                dataGridView1.DataSource = openTestList;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean success = false ;
            if (e.ColumnIndex == 3)
            {
                try
                {
                    int i = e.RowIndex;
                    DataGridViewRow row = dataGridView1.Rows[i];
                    Result result = (Result)row.DataBoundItem;

                    Result newResult = new Result();

                    newResult.AppointmentId = result.AppointmentId;
                    newResult.TestId = result.TestId;
                    newResult.TestResult = dataGridView1.Rows[i].Cells[2].Value.ToString();

                    success = ResultController.UpdateTestResult(result, newResult);

                    if (success == true)
                    {
                        GetResultList();
                        MessageBox.Show("Test result has been successfully updated", "Success!", MessageBoxButtons.OK);

                    }

                    else
                    {
                        MessageBox.Show("There has been an error. Your test result has not been updated.", "Error!", MessageBoxButtons.OK);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());

                }
            }
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
