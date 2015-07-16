namespace HealthCareSystem.view
{
    partial class frmEditUser
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
            this.tbSSN = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.tbAptNum = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbZip = new System.Windows.Forms.MaskedTextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBirthdate = new System.Windows.Forms.DateTimePicker();
            this.tbMiddleInitial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbUserRole = new System.Windows.Forms.ComboBox();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbSSN
            // 
            this.tbSSN.Location = new System.Drawing.Point(649, 80);
            this.tbSSN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSSN.Mask = "000-00-0000";
            this.tbSSN.Name = "tbSSN";
            this.tbSSN.Size = new System.Drawing.Size(87, 22);
            this.tbSSN.TabIndex = 8;
            this.tbSSN.Tag = "SSN";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(521, 84);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 17);
            this.label12.TabIndex = 78;
            this.label12.Text = "Social Security #:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(637, 190);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(20, 190);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // tbAptNum
            // 
            this.tbAptNum.Location = new System.Drawing.Point(676, 112);
            this.tbAptNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbAptNum.Name = "tbAptNum";
            this.tbAptNum.Size = new System.Drawing.Size(60, 22);
            this.tbAptNum.TabIndex = 10;
            this.tbAptNum.Tag = "Apt No.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(620, 116);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 17);
            this.label11.TabIndex = 77;
            this.label11.Text = "Apt #:";
            // 
            // tbZip
            // 
            this.tbZip.Location = new System.Drawing.Point(504, 144);
            this.tbZip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbZip.Mask = "00000";
            this.tbZip.Name = "tbZip";
            this.tbZip.Size = new System.Drawing.Size(48, 22);
            this.tbZip.TabIndex = 13;
            this.tbZip.Tag = "Zip";
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(60, 144);
            this.tbCity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(261, 22);
            this.tbCity.TabIndex = 11;
            this.tbCity.Tag = "City";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(463, 148);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 17);
            this.label10.TabIndex = 76;
            this.label10.Text = "Zip:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(331, 148);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 17);
            this.label9.TabIndex = 75;
            this.label9.Text = "State:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 148);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 17);
            this.label8.TabIndex = 74;
            this.label8.Text = "City:";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(129, 112);
            this.tbAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(481, 22);
            this.tbAddress.TabIndex = 9;
            this.tbAddress.Tag = "Street Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 116);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 17);
            this.label7.TabIndex = 72;
            this.label7.Text = "Street Address:";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(637, 144);
            this.tbPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPhone.Mask = "(999) 000-0000";
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(99, 22);
            this.tbPhone.TabIndex = 14;
            this.tbPhone.Tag = "Phone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(561, 148);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 70;
            this.label6.Text = "Phone #:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 67;
            this.label5.Text = "Gender:";
            // 
            // cbGender
            // 
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbGender.Location = new System.Drawing.Point(432, 79);
            this.cbGender.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(80, 24);
            this.cbGender.TabIndex = 7;
            this.cbGender.Tag = "Gender";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 64;
            this.label4.Text = "Birth Date:";
            // 
            // tbBirthdate
            // 
            this.tbBirthdate.Location = new System.Drawing.Point(105, 80);
            this.tbBirthdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbBirthdate.Name = "tbBirthdate";
            this.tbBirthdate.Size = new System.Drawing.Size(249, 22);
            this.tbBirthdate.TabIndex = 6;
            this.tbBirthdate.Tag = "Birth Date";
            // 
            // tbMiddleInitial
            // 
            this.tbMiddleInitial.Location = new System.Drawing.Point(407, 48);
            this.tbMiddleInitial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMiddleInitial.MaxLength = 1;
            this.tbMiddleInitial.Name = "tbMiddleInitial";
            this.tbMiddleInitial.Size = new System.Drawing.Size(39, 22);
            this.tbMiddleInitial.TabIndex = 4;
            this.tbMiddleInitial.Tag = "Middle Initial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 60;
            this.label3.Text = "Middle Initial:";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(551, 48);
            this.tbFirstName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(185, 22);
            this.tbFirstName.TabIndex = 5;
            this.tbFirstName.Tag = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(463, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 57;
            this.label2.Text = "First Name:";
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(105, 48);
            this.tbLastName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(185, 22);
            this.tbLastName.TabIndex = 3;
            this.tbLastName.Tag = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "Last Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 20);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 17);
            this.label13.TabIndex = 79;
            this.label13.Text = "User Name:";
            // 
            // tbUserName
            // 
            this.tbUserName.Enabled = false;
            this.tbUserName.Location = new System.Drawing.Point(105, 16);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(292, 22);
            this.tbUserName.TabIndex = 1;
            this.tbUserName.Tag = "User name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(407, 20);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 17);
            this.label14.TabIndex = 81;
            this.label14.Text = "User Role:";
            // 
            // cbUserRole
            // 
            this.cbUserRole.Enabled = false;
            this.cbUserRole.FormattingEnabled = true;
            this.cbUserRole.Items.AddRange(new object[] {
            "Administrator",
            "Doctor",
            "Patient",
            "Nurse"});
            this.cbUserRole.Location = new System.Drawing.Point(491, 15);
            this.cbUserRole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbUserRole.Name = "cbUserRole";
            this.cbUserRole.Size = new System.Drawing.Size(245, 24);
            this.cbUserRole.TabIndex = 2;
            this.cbUserRole.Tag = "Role";
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "AL",
            "AK",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"});
            this.cbState.Location = new System.Drawing.Point(385, 143);
            this.cbState.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(68, 24);
            this.cbState.TabIndex = 12;
            this.cbState.Tag = "State";
            // 
            // frmEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 229);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.cbUserRole);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbSSN);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tbAptNum);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbZip);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbBirthdate);
            this.Controls.Add(this.tbMiddleInitial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmEditUser";
            this.Text = "Edit User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tbSSN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox tbAptNum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox tbZip;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox tbPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker tbBirthdate;
        private System.Windows.Forms.TextBox tbMiddleInitial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbUserRole;
        private System.Windows.Forms.ComboBox cbState;
    }
}