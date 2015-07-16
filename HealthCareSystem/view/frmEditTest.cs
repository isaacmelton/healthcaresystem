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
    public partial class frmEditTest : Form
    {
        LabTest oldTest = new LabTest();

        public frmEditTest(int testID)
        {
            InitializeComponent();
            oldTest = LabTestController.GetLabTestByID(testID);
            tbTestID.Text = "" + testID;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool edited = false;

            try
            {
                LabTest newTest = new LabTest();
                newTest.TestId = oldTest.TestId;
                if(Validator.IsPresent(tbTestType))
                {
                    newTest.TestType = tbTestType.Text;
                    edited = LabTestController.UpdateLabTest(oldTest, newTest);
                }

                if (!edited)
                {
                    throw new Exception("The lab test was not updated.");
                }

                MessageBox.Show("The lab test was updated successfully.", "Update Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
