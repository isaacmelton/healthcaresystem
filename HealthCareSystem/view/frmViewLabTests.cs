using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareSystem.controller;
using HealthCareSystem.model;

namespace HealthCareSystem.view
{
    public partial class frmViewLabTests : Form
    {
        private List<LabTest> labTests;
        private int selectedTest;

        public frmViewLabTests()
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
            ShowLabTests();
            numShown++;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            numShown--;
        }

        #endregion CanShow Implementation

        private void ShowLabTests()
        {
            labTests = LabTestController.GetAllLabTests();
            lbLabTests.Items.Clear();
            if (labTests.Count > 0)
            {
                for (int i = 0; i < labTests.Count; i++)
                {
                    lbLabTests.Items.Add(labTests[i].TestType);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbLabTests.SelectedIndex >=0)
            {
                selectedTest = lbLabTests.SelectedIndex;
                if (MessageBox.Show("Are you sure you want to delete " + labTests[selectedTest].TestType, "Confirm Delete?",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {

                        bool success = LabTestController.DeleteLabTest(labTests[selectedTest].TestId);
                        if (success)
                        {
                            MessageBox.Show("Successfully removed test: " + labTests[selectedTest].TestType, "Success",
                                MessageBoxButtons.OK);
                            ShowLabTests();
                        }
                        else
                        {
                            MessageBox.Show("Failed to remove lab test: " + labTests[selectedTest].TestType, "Failure",
                                MessageBoxButtons.OK);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);

                    }

                }

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbLabTests.SelectedIndex >= 0)
            {
                selectedTest = lbLabTests.SelectedIndex;
                frmEditTest edit = new frmEditTest(labTests[selectedTest].TestId);
                edit.Show();
            }
        }
    }
}
