namespace HealthCareSystem.view
{
    partial class frmAddTest
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnTestCancel = new System.Windows.Forms.Button();
            this.dgvAddTest = new System.Windows.Forms.DataGridView();
            this.appointmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symptom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddTest)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(570, 292);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(176, 28);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Schedule Test(s)";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnTestCancel
            // 
            this.btnTestCancel.Location = new System.Drawing.Point(13, 292);
            this.btnTestCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTestCancel.Name = "btnTestCancel";
            this.btnTestCancel.Size = new System.Drawing.Size(100, 28);
            this.btnTestCancel.TabIndex = 5;
            this.btnTestCancel.Text = "Cancel";
            this.btnTestCancel.UseVisualStyleBackColor = true;
            this.btnTestCancel.Click += new System.EventHandler(this.btnTestCancel_Click);
            // 
            // dgvAddTest
            // 
            this.dgvAddTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appointmentDate,
            this.patientName,
            this.symptom});
            this.dgvAddTest.Location = new System.Drawing.Point(13, 13);
            this.dgvAddTest.Name = "dgvAddTest";
            this.dgvAddTest.RowTemplate.Height = 24;
            this.dgvAddTest.Size = new System.Drawing.Size(733, 268);
            this.dgvAddTest.TabIndex = 6;
            this.dgvAddTest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddTest_CellContentClick);
            // 
            // appointmentDate
            // 
            this.appointmentDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.appointmentDate.FillWeight = 99F;
            this.appointmentDate.HeaderText = "Appointment Date";
            this.appointmentDate.Name = "appointmentDate";
            this.appointmentDate.ReadOnly = true;
            this.appointmentDate.Width = 133;
            // 
            // patientName
            // 
            this.patientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.patientName.HeaderText = "Patient Name";
            this.patientName.Name = "patientName";
            this.patientName.ReadOnly = true;
            this.patientName.Width = 108;
            // 
            // symptom
            // 
            this.symptom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.symptom.HeaderText = "Symptom";
            this.symptom.Name = "symptom";
            this.symptom.ReadOnly = true;
            // 
            // frmAddTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 333);
            this.Controls.Add(this.dgvAddTest);
            this.Controls.Add(this.btnTestCancel);
            this.Controls.Add(this.btnSubmit);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAddTest";
            this.Text = "Add Test";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnTestCancel;
        private System.Windows.Forms.DataGridView dgvAddTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn symptom;
    }
}