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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            AcceptButton = loginButton;
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
            passTextBox.UseSystemPasswordChar = true;
        }

        #endregion Overrides

        #region Event Handlers

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!GlobalVars.Instance.CurrentUser.LoggedIn)
                    GlobalVars.Instance.CurrentUser.LogIn(userTextBox.Text, passTextBox.Text);
                else
                    MessageBox.Show(GlobalVars.Instance.CurrentUser.UserName + " is logged in.\r\nPlease log out before attempting to log in.", "User Logged In", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmMain parent = MdiParent as frmMain;
                parent.DisplayUser();
                Close();
            }
            catch (Exception ex)
            {
                String message = ex.Message == "Sequence contains no elements" ? "Incorrect username or password." : ex.Message;
                MessageBox.Show(message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Event Handlers

    }
}
