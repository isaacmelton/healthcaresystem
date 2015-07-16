namespace HealthCareSystem.view
{
    partial class frmEditPatient
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
            this.cbState = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbSSN
            // 
            this.tbSSN.Location = new System.Drawing.Point(487, 38);
            this.tbSSN.Mask = "000-00-0000";
            this.tbSSN.Name = "tbSSN";
            this.tbSSN.Size = new System.Drawing.Size(66, 20);
            this.tbSSN.TabIndex = 35;
            this.tbSSN.Tag = "SSN";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(391, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "Social Security #:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(478, 127);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 47;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(15, 127);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 45;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // tbAptNum
            // 
            this.tbAptNum.Location = new System.Drawing.Point(507, 64);
            this.tbAptNum.Name = "tbAptNum";
            this.tbAptNum.Size = new System.Drawing.Size(46, 20);
            this.tbAptNum.TabIndex = 37;
            this.tbAptNum.Tag = "Apt No.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(465, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "Apt #:";
            // 
            // tbZip
            // 
            this.tbZip.Location = new System.Drawing.Point(378, 90);
            this.tbZip.Mask = "00000";
            this.tbZip.Name = "tbZip";
            this.tbZip.Size = new System.Drawing.Size(37, 20);
            this.tbZip.TabIndex = 42;
            this.tbZip.Tag = "Zip";
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(45, 90);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(197, 20);
            this.tbCity.TabIndex = 39;
            this.tbCity.Tag = "City";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(347, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "Zip:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(248, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "State:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "City:";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(97, 64);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(362, 20);
            this.tbAddress.TabIndex = 36;
            this.tbAddress.Tag = "Street Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Street Address:";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(478, 90);
            this.tbPhone.Mask = "(999) 000-0000";
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(75, 20);
            this.tbPhone.TabIndex = 43;
            this.tbPhone.Tag = "Phone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(421, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Phone #:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Gender:";
            // 
            // cbGender
            // 
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbGender.Location = new System.Drawing.Point(324, 37);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(61, 21);
            this.cbGender.TabIndex = 33;
            this.cbGender.Tag = "Gender";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Birth Date:";
            // 
            // tbBirthdate
            // 
            this.tbBirthdate.Location = new System.Drawing.Point(79, 38);
            this.tbBirthdate.Name = "tbBirthdate";
            this.tbBirthdate.Size = new System.Drawing.Size(188, 20);
            this.tbBirthdate.TabIndex = 32;
            this.tbBirthdate.Tag = "Birth Date";
            // 
            // tbMiddleInitial
            // 
            this.tbMiddleInitial.Location = new System.Drawing.Point(305, 12);
            this.tbMiddleInitial.MaxLength = 1;
            this.tbMiddleInitial.Name = "tbMiddleInitial";
            this.tbMiddleInitial.Size = new System.Drawing.Size(30, 20);
            this.tbMiddleInitial.TabIndex = 29;
            this.tbMiddleInitial.Tag = "Middle Initial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Middle Initial:";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(413, 12);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(140, 20);
            this.tbFirstName.TabIndex = 30;
            this.tbFirstName.Tag = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "First Name:";
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(79, 12);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(140, 20);
            this.tbLastName.TabIndex = 28;
            this.tbLastName.Tag = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Last Name:";
            // 
            // cbState
            // 
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
            this.cbState.Location = new System.Drawing.Point(289, 89);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(52, 21);
            this.cbState.TabIndex = 53;
            this.cbState.Tag = "State";
            // 
            // frmEditPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 162);
            this.Controls.Add(this.cbState);
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
            this.Name = "frmEditPatient";
            this.Text = "Edit Patient";
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
        private System.Windows.Forms.ComboBox cbState;
    }
}