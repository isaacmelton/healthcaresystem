namespace HealthCareSystem.view
{
    partial class frmOpenResults
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
            this.enterResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Appointment ID";
            // 
            // cbAppId
            // 
            this.cbAppId.DisplayMember = "appointmentID";
            this.cbAppId.FormattingEnabled = true;
            this.cbAppId.Location = new System.Drawing.Point(136, 15);
            this.cbAppId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbAppId.Name = "cbAppId";
            this.cbAppId.Size = new System.Drawing.Size(160, 24);
            this.cbAppId.TabIndex = 1;
            this.cbAppId.Tag = "Appointment ID";
            this.cbAppId.ValueMember = "appointmentID";
            this.cbAppId.SelectedIndexChanged += new System.EventHandler(this.cbAppId_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enterResult,
            this.button});
            this.dataGridView1.Location = new System.Drawing.Point(19, 48);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(597, 185);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // enterResult
            // 
            this.enterResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.enterResult.HeaderText = "Enter Test Result";
            this.enterResult.Name = "enterResult";
            // 
            // button
            // 
            this.button.HeaderText = "";
            this.button.Name = "button";
            this.button.Text = "Enter";
            this.button.UseColumnTextForButtonValue = true;
            // 
            // frmOpenResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 249);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbAppId);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmOpenResults";
            this.Text = "Open Tests";
            this.Load += new System.EventHandler(this.frmOpenResults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAppId;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn testIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enterResult;
        private System.Windows.Forms.DataGridViewButtonColumn button;
    }
}