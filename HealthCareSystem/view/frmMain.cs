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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            debugInfoToolStripMenuItem.Visible = false;
            //debugInfoToolStripMenuItem.Visible = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            //set our main icon
            this.Icon = Properties.Resources.MainIcon;

            //set our userLabel to reflect no user logged in
            //TODO: use a controller for these possibly
            this.userLabel.Text = "User: none";
            this.statusLabel.Text = " ";

            base.OnLoad(e);

            //show the login form
            ShowLoginForm();
        }

        #region Helper Methods

        private static void CloseAllForms()
        {
            Form parent = frmMain.ActiveForm;
            foreach (Form frm in parent.MdiChildren)
	        {
                if (frm.GetType() != parent.GetType())
                    frm.Close();
	        }
        }

        private void ShowLoginForm()
        {
            frmLogin frm = new frmLogin();
            DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
        }

        private void DisplayChild(Form frm, DockStyle style, FormStartPosition startPos, bool canShow)
        {
            if (canShow)
            {
                frm.MdiParent = this;
                frm.Dock = style;
                frm.StartPosition = startPos;
                frm.Show();
            }
        }

        private Boolean UserLoggedInWithRole(String userRole)
        {
            return GlobalVars.Instance.CurrentUser.LoggedIn && GlobalVars.Instance.CurrentUser.UserRole == userRole;
        }

        public void DisplayUser()
        {
            userLabel.Text = GlobalVars.Instance.CurrentUser.LoggedIn ? "User: " + GlobalVars.Instance.CurrentUser.UserName : "";
        }

        #endregion Helper Methods

        #region Event Handlers

        /// <summary>
        /// Event handler for the click event on the Exit button.
        /// Exits the application.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
        }

        private void searchPatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Nurse"))
            {
                frmSearch frm = new frmSearch();
                DisplayChild(frm, DockStyle.Fill, FormStartPosition.WindowsDefaultLocation, frm.CanShow());
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } 

        private void addPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Nurse"))
            {
                frmAddPatient frm = new frmAddPatient();
                DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void addCheckupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Nurse"))
            {
                frmAddCheckup frm = new frmAddCheckup();
                DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void scheduleAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Nurse"))
            {
                frmAddAppointment frm = new frmAddAppointment();
                DisplayChild(frm, DockStyle.Fill, FormStartPosition.WindowsDefaultLocation, frm.CanShow());
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void searchAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Administrator"))
            {
                frmSearchAll frm = new frmSearchAll();
                DisplayChild(frm, DockStyle.Fill, FormStartPosition.WindowsDefaultLocation, frm.CanShow());  
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Administrator"))
            {
                frmAddUser frm = new frmAddUser();
                DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void addTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Nurse"))
            {
                frmAddTest frm = new frmAddTest();
                DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void userLabel_Click(object sender, EventArgs e)
        {
            if (!GlobalVars.Instance.CurrentUser.LoggedIn)
                ShowLoginForm();
            else
                GlobalVars.Instance.CurrentUser.LogOut();

            DisplayUser();
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!GlobalVars.Instance.CurrentUser.LoggedIn)
                ShowLoginForm();
            else
                GlobalVars.Instance.CurrentUser.LogOut();

            DisplayUser();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String userName = GlobalVars.Instance.CurrentUser.UserName;

            if (GlobalVars.Instance.CurrentUser.LoggedIn)
            {
                GlobalVars.Instance.CurrentUser.LogOut();
                CloseAllForms();
                ShowLoginForm();
            }
            else
            {
                MessageBox.Show("No user logged in.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DisplayUser();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("== CurrentUser Info ==");
            Console.WriteLine("UserName: " + GlobalVars.Instance.CurrentUser.UserName);
            Console.WriteLine("UserRole: " + GlobalVars.Instance.CurrentUser.UserRole);
            Console.WriteLine("LoggedIn: " + GlobalVars.Instance.CurrentUser.LoggedIn);
        }

        public void EditPatient(int patientID)
        {
            if (UserLoggedInWithRole("Nurse"))
            {
                frmEditPatient frm = new frmEditPatient(patientID);
                DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void addTestResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Nurse"))
            {
                frmOpenResults frm = new frmOpenResults();
                DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void addDiagnosisToAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Nurse"))
            {
                frmUpdateAppointmentDiagnosis frm = new frmUpdateAppointmentDiagnosis();
                DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void editDeleteDoctor_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Administrator"))
            {
                frmViewDoctors frm = new frmViewDoctors();
                DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsEditDelNurse_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Administrator"))
            {
                frmViewNurses frm = new frmViewNurses();
                DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void editRemoveAdministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Administrator"))
            {
                frmViewAdministrators frm = new frmViewAdministrators();
                DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void addLabTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Administrator"))
            {
                frmAddLabTest frm = new frmAddLabTest();
                DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void editRemoveLabTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Administrator")){
                frmViewLabTests frm = new frmViewLabTests();
                DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
            }
            else
            {
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }


        #endregion Event Handlers

        private void showAppointmentSummartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Nurse"))
            {
                frmAppointmentSummary frm = new frmAppointmentSummary();
                DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());

            }
            else
            {
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void appointmentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserLoggedInWithRole("Administrator"))
            {
                frmAdminReport frm = new frmAdminReport();
                DisplayChild(frm, DockStyle.None, FormStartPosition.CenterScreen, frm.CanShow());
            }
            else
                MessageBox.Show("Insufficient priveleges... Please speak with your administrator.", "Permission Issue!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
