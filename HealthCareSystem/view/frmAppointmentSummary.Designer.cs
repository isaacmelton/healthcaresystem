namespace HealthCareSystem.view
{
    partial class frmAppointmentSummary
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbAppId = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDiagnosis = new System.Windows.Forms.TextBox();
            this.tbSymptoms = new System.Windows.Forms.TextBox();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.tbNurse = new System.Windows.Forms.TextBox();
            this.tbPatient = new System.Windows.Forms.TextBox();
            this.tbDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Appointment ID";
            // 
            // cbAppId
            // 
            this.cbAppId.DisplayMember = "appointmentID";
            this.cbAppId.FormattingEnabled = true;
            this.cbAppId.Location = new System.Drawing.Point(222, 13);
            this.cbAppId.Name = "cbAppId";
            this.cbAppId.Size = new System.Drawing.Size(121, 21);
            this.cbAppId.TabIndex = 1;
            this.cbAppId.Tag = "Appointment ID";
            this.cbAppId.ValueMember = "appointmentID";
            this.cbAppId.SelectedIndexChanged += new System.EventHandler(this.cbAppId_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(72, 195);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(404, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patient:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nurse:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Doctor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Symptoms:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Diagnosis:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Tests:";
            // 
            // tbDiagnosis
            // 
            this.tbDiagnosis.Location = new System.Drawing.Point(72, 146);
            this.tbDiagnosis.Multiline = true;
            this.tbDiagnosis.Name = "tbDiagnosis";
            this.tbDiagnosis.ReadOnly = true;
            this.tbDiagnosis.Size = new System.Drawing.Size(404, 43);
            this.tbDiagnosis.TabIndex = 12;
            // 
            // tbSymptoms
            // 
            this.tbSymptoms.Location = new System.Drawing.Point(72, 103);
            this.tbSymptoms.Multiline = true;
            this.tbSymptoms.Name = "tbSymptoms";
            this.tbSymptoms.ReadOnly = true;
            this.tbSymptoms.Size = new System.Drawing.Size(404, 37);
            this.tbSymptoms.TabIndex = 13;
            // 
            // tbDoctor
            // 
            this.tbDoctor.Location = new System.Drawing.Point(376, 71);
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.ReadOnly = true;
            this.tbDoctor.Size = new System.Drawing.Size(100, 20);
            this.tbDoctor.TabIndex = 14;
            // 
            // tbNurse
            // 
            this.tbNurse.Location = new System.Drawing.Point(222, 71);
            this.tbNurse.Name = "tbNurse";
            this.tbNurse.ReadOnly = true;
            this.tbNurse.Size = new System.Drawing.Size(100, 20);
            this.tbNurse.TabIndex = 15;
            // 
            // tbPatient
            // 
            this.tbPatient.Location = new System.Drawing.Point(72, 71);
            this.tbPatient.Name = "tbPatient";
            this.tbPatient.ReadOnly = true;
            this.tbPatient.Size = new System.Drawing.Size(100, 20);
            this.tbPatient.TabIndex = 16;
            // 
            // tbDate
            // 
            this.tbDate.Enabled = false;
            this.tbDate.Location = new System.Drawing.Point(163, 42);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(207, 20);
            this.tbDate.TabIndex = 17;
            // 
            // frmAppointmentSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 359);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.tbPatient);
            this.Controls.Add(this.tbNurse);
            this.Controls.Add(this.tbDoctor);
            this.Controls.Add(this.tbSymptoms);
            this.Controls.Add(this.tbDiagnosis);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbAppId);
            this.Controls.Add(this.label1);
            this.Name = "frmAppointmentSummary";
            this.Text = "Appointment Summary";
            this.Load += new System.EventHandler(this.frmAppointmentSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAppId;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDiagnosis;
        private System.Windows.Forms.TextBox tbSymptoms;
        private System.Windows.Forms.TextBox tbDoctor;
        private System.Windows.Forms.TextBox tbNurse;
        private System.Windows.Forms.TextBox tbPatient;
        private System.Windows.Forms.DateTimePicker tbDate;
    }
}