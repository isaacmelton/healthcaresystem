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

    public partial class frmAddLabTest : Form
    {
        private LabTest newTest;
        private List<Control> controls = new List<Control>();

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
        
        public frmAddLabTest()
        {
            InitializeComponent();
            controls.Add(tbTestType);

        }



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

     
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Validates required fields.
            if (Validator.AreAllPresent(controls))
            {
                newTest = new LabTest();
                newTest.TestType = tbTestType.Text;

                try
                {
                    int newTestID = LabTestController.AddLabTest(newTest);
                    MessageBox.Show("Success!", "Lab Test successfully added.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        #endregion Event Handlers

       
    }
}
