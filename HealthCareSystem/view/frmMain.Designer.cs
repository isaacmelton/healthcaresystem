namespace HealthCareSystem.view
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCheckupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTestResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleAnAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDiagnosisToAppointmentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showAppointmentSummartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLabTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editDeleteDoctor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEditDelNurse = new System.Windows.Forms.ToolStripMenuItem();
            this.editRemoveAdministratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRemoveLabTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.appointmentReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrativePanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchPatientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.springRightLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.userLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.patientToolStripMenuItem,
            this.appointmentToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.debugInfoToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mainMenuStrip.Size = new System.Drawing.Size(1189, 28);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInToolStripMenuItem,
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logInToolStripMenuItem
            // 
            this.logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            this.logInToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.logInToolStripMenuItem.Text = "Log In";
            this.logInToolStripMenuItem.Click += new System.EventHandler(this.logInToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // patientToolStripMenuItem
            // 
            this.patientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPatientToolStripMenuItem,
            this.addCheckupToolStripMenuItem,
            this.addTestToolStripMenuItem,
            this.addTestResultsToolStripMenuItem});
            this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            this.patientToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.patientToolStripMenuItem.Text = "Patient";
            // 
            // addPatientToolStripMenuItem
            // 
            this.addPatientToolStripMenuItem.Name = "addPatientToolStripMenuItem";
            this.addPatientToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.addPatientToolStripMenuItem.Text = "Add Patient";
            this.addPatientToolStripMenuItem.Click += new System.EventHandler(this.addPatientToolStripMenuItem_Click);
            // 
            // addCheckupToolStripMenuItem
            // 
            this.addCheckupToolStripMenuItem.Name = "addCheckupToolStripMenuItem";
            this.addCheckupToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.addCheckupToolStripMenuItem.Text = "Add Checkup";
            this.addCheckupToolStripMenuItem.Click += new System.EventHandler(this.addCheckupToolStripMenuItem_Click);
            // 
            // addTestToolStripMenuItem
            // 
            this.addTestToolStripMenuItem.Name = "addTestToolStripMenuItem";
            this.addTestToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.addTestToolStripMenuItem.Text = "Add Test";
            this.addTestToolStripMenuItem.Click += new System.EventHandler(this.addTestToolStripMenuItem_Click);
            // 
            // addTestResultsToolStripMenuItem
            // 
            this.addTestResultsToolStripMenuItem.Name = "addTestResultsToolStripMenuItem";
            this.addTestResultsToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.addTestResultsToolStripMenuItem.Text = "Update Test Results";
            this.addTestResultsToolStripMenuItem.Click += new System.EventHandler(this.addTestResultsToolStripMenuItem_Click);
            // 
            // appointmentToolStripMenuItem
            // 
            this.appointmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleAnAppointmentToolStripMenuItem,
            this.addDiagnosisToAppointmentToolStripMenuItem1,
            this.showAppointmentSummartToolStripMenuItem});
            this.appointmentToolStripMenuItem.Name = "appointmentToolStripMenuItem";
            this.appointmentToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.appointmentToolStripMenuItem.Text = "Appointment";
            // 
            // scheduleAnAppointmentToolStripMenuItem
            // 
            this.scheduleAnAppointmentToolStripMenuItem.Name = "scheduleAnAppointmentToolStripMenuItem";
            this.scheduleAnAppointmentToolStripMenuItem.Size = new System.Drawing.Size(285, 24);
            this.scheduleAnAppointmentToolStripMenuItem.Text = "Schedule an Appointment";
            this.scheduleAnAppointmentToolStripMenuItem.Click += new System.EventHandler(this.scheduleAppointmentToolStripMenuItem_Click);
            // 
            // addDiagnosisToAppointmentToolStripMenuItem1
            // 
            this.addDiagnosisToAppointmentToolStripMenuItem1.Name = "addDiagnosisToAppointmentToolStripMenuItem1";
            this.addDiagnosisToAppointmentToolStripMenuItem1.Size = new System.Drawing.Size(285, 24);
            this.addDiagnosisToAppointmentToolStripMenuItem1.Text = "Add Diagnosis to Appointment";
            this.addDiagnosisToAppointmentToolStripMenuItem1.Click += new System.EventHandler(this.addDiagnosisToAppointmentToolStripMenuItem_Click);
            // 
            // showAppointmentSummartToolStripMenuItem
            // 
            this.showAppointmentSummartToolStripMenuItem.Name = "showAppointmentSummartToolStripMenuItem";
            this.showAppointmentSummartToolStripMenuItem.Size = new System.Drawing.Size(285, 24);
            this.showAppointmentSummartToolStripMenuItem.Text = "Show Appointment Summary";
            this.showAppointmentSummartToolStripMenuItem.Click += new System.EventHandler(this.showAppointmentSummartToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.addLabTestToolStripMenuItem,
            this.toolStripSeparator1,
            this.editDeleteDoctor,
            this.tsEditDelNurse,
            this.editRemoveAdministratorToolStripMenuItem,
            this.editRemoveLabTestToolStripMenuItem,
            this.toolStripSeparator2,
            this.appointmentReportToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(259, 24);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // addLabTestToolStripMenuItem
            // 
            this.addLabTestToolStripMenuItem.Name = "addLabTestToolStripMenuItem";
            this.addLabTestToolStripMenuItem.Size = new System.Drawing.Size(259, 24);
            this.addLabTestToolStripMenuItem.Text = "Add Lab Test";
            this.addLabTestToolStripMenuItem.Click += new System.EventHandler(this.addLabTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(256, 6);
            // 
            // editDeleteDoctor
            // 
            this.editDeleteDoctor.Name = "editDeleteDoctor";
            this.editDeleteDoctor.Size = new System.Drawing.Size(259, 24);
            this.editDeleteDoctor.Text = "Edit/Remove Doctor";
            this.editDeleteDoctor.Click += new System.EventHandler(this.editDeleteDoctor_Click);
            // 
            // tsEditDelNurse
            // 
            this.tsEditDelNurse.Name = "tsEditDelNurse";
            this.tsEditDelNurse.Size = new System.Drawing.Size(259, 24);
            this.tsEditDelNurse.Text = "Edit/Remove Nurse";
            this.tsEditDelNurse.Click += new System.EventHandler(this.tsEditDelNurse_Click);
            // 
            // editRemoveAdministratorToolStripMenuItem
            // 
            this.editRemoveAdministratorToolStripMenuItem.Name = "editRemoveAdministratorToolStripMenuItem";
            this.editRemoveAdministratorToolStripMenuItem.Size = new System.Drawing.Size(259, 24);
            this.editRemoveAdministratorToolStripMenuItem.Text = "Edit/Remove Administrator";
            this.editRemoveAdministratorToolStripMenuItem.Click += new System.EventHandler(this.editRemoveAdministratorToolStripMenuItem_Click);
            // 
            // editRemoveLabTestToolStripMenuItem
            // 
            this.editRemoveLabTestToolStripMenuItem.Name = "editRemoveLabTestToolStripMenuItem";
            this.editRemoveLabTestToolStripMenuItem.Size = new System.Drawing.Size(259, 24);
            this.editRemoveLabTestToolStripMenuItem.Text = "Edit/Remove Lab Test";
            this.editRemoveLabTestToolStripMenuItem.Click += new System.EventHandler(this.editRemoveLabTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(256, 6);
            // 
            // appointmentReportToolStripMenuItem
            // 
            this.appointmentReportToolStripMenuItem.Name = "appointmentReportToolStripMenuItem";
            this.appointmentReportToolStripMenuItem.Size = new System.Drawing.Size(259, 24);
            this.appointmentReportToolStripMenuItem.Text = "Test Result Report";
            this.appointmentReportToolStripMenuItem.Click += new System.EventHandler(this.appointmentReportToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrativePanelToolStripMenuItem,
            this.searchPatientsToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // administrativePanelToolStripMenuItem
            // 
            this.administrativePanelToolStripMenuItem.Name = "administrativePanelToolStripMenuItem";
            this.administrativePanelToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.administrativePanelToolStripMenuItem.Text = "Search All";
            this.administrativePanelToolStripMenuItem.Click += new System.EventHandler(this.searchAllToolStripMenuItem_Click);
            // 
            // searchPatientsToolStripMenuItem
            // 
            this.searchPatientsToolStripMenuItem.Name = "searchPatientsToolStripMenuItem";
            this.searchPatientsToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.searchPatientsToolStripMenuItem.Text = "Search Patients";
            this.searchPatientsToolStripMenuItem.Click += new System.EventHandler(this.searchPatientsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // debugInfoToolStripMenuItem
            // 
            this.debugInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem});
            this.debugInfoToolStripMenuItem.Name = "debugInfoToolStripMenuItem";
            this.debugInfoToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.debugInfoToolStripMenuItem.Text = "Debug Info";
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.currentUserInfoToolStripMenuItem.Text = "Current User Info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.springRightLabel,
            this.statusLabel,
            this.userLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 680);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.mainStatusStrip.Size = new System.Drawing.Size(1189, 25);
            this.mainStatusStrip.TabIndex = 2;
            this.mainStatusStrip.Text = "mainStatusStrip";
            // 
            // springRightLabel
            // 
            this.springRightLabel.Name = "springRightLabel";
            this.springRightLabel.Size = new System.Drawing.Size(1133, 20);
            this.springRightLabel.Spring = true;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(18, 20);
            this.statusLabel.Text = "...";
            // 
            // userLabel
            // 
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(18, 20);
            this.userLabel.Text = "...";
            this.userLabel.Click += new System.EventHandler(this.userLabel_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 705);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Cobra Caduceus";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel springRightLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel userLabel;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchPatientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrativePanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCheckupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTestResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDeleteDoctor;
        private System.Windows.Forms.ToolStripMenuItem tsEditDelNurse;
        private System.Windows.Forms.ToolStripMenuItem editRemoveAdministratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLabTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRemoveLabTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleAnAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDiagnosisToAppointmentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showAppointmentSummartToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem appointmentReportToolStripMenuItem;
    }
}