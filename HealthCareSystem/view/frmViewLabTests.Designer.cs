namespace HealthCareSystem.view
{
    partial class frmViewLabTests
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
            this.lbLabTests = new System.Windows.Forms.ListBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbLabTests
            // 
            this.lbLabTests.FormattingEnabled = true;
            this.lbLabTests.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.lbLabTests.Location = new System.Drawing.Point(9, 10);
            this.lbLabTests.Margin = new System.Windows.Forms.Padding(2);
            this.lbLabTests.Name = "lbLabTests";
            this.lbLabTests.Size = new System.Drawing.Size(522, 290);
            this.lbLabTests.TabIndex = 0;
            this.lbLabTests.Tag = "Lab test grid";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(322, 314);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(103, 19);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit Lab Test";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(430, 314);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 19);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete Lab Test";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmViewLabTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 342);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lbLabTests);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmViewLabTests";
            this.Text = "View Lab Tests";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbLabTests;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}