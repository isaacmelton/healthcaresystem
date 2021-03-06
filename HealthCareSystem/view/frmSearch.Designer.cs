﻿namespace HealthCareSystem.view
{
    partial class frmSearch
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ssnTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.birthdateTextBox = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.patientIDTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.searchGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.springRightLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.searchResultLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            this.searchGridMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(79, 12);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(274, 20);
            this.lastNameTextBox.TabIndex = 1;
            this.lastNameTextBox.Tag = "Last name";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNameTextBox.Location = new System.Drawing.Point(423, 12);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(274, 20);
            this.firstNameTextBox.TabIndex = 7;
            this.firstNameTextBox.Tag = "First name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "First Name:";
            // 
            // ssnTextBox
            // 
            this.ssnTextBox.Location = new System.Drawing.Point(381, 38);
            this.ssnTextBox.Mask = "000-00-0000";
            this.ssnTextBox.Name = "ssnTextBox";
            this.ssnTextBox.Size = new System.Drawing.Size(67, 20);
            this.ssnTextBox.TabIndex = 8;
            this.ssnTextBox.Tag = "Social security number";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Social Security #:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Birth date:";
            // 
            // birthdateTextBox
            // 
            this.birthdateTextBox.Location = new System.Drawing.Point(79, 38);
            this.birthdateTextBox.Name = "birthdateTextBox";
            this.birthdateTextBox.Size = new System.Drawing.Size(200, 20);
            this.birthdateTextBox.TabIndex = 11;
            this.birthdateTextBox.Tag = "Date of birth";
            this.birthdateTextBox.ValueChanged += new System.EventHandler(this.birthdateTextBox_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(454, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Patient ID:";
            // 
            // patientIDTextBox
            // 
            this.patientIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientIDTextBox.Location = new System.Drawing.Point(517, 38);
            this.patientIDTextBox.Name = "patientIDTextBox";
            this.patientIDTextBox.Size = new System.Drawing.Size(99, 20);
            this.patientIDTextBox.TabIndex = 13;
            this.patientIDTextBox.Tag = "Patient ID";
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(622, 36);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 14;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchGrid
            // 
            this.searchGrid.AllowUserToAddRows = false;
            this.searchGrid.AllowUserToDeleteRows = false;
            this.searchGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchGrid.ContextMenuStrip = this.searchGridMenu;
            this.searchGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.searchGrid.Location = new System.Drawing.Point(15, 64);
            this.searchGrid.MultiSelect = false;
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(682, 370);
            this.searchGrid.TabIndex = 15;
            this.searchGrid.DoubleClick += new System.EventHandler(this.searchGrid_DoubleClick);
            // 
            // searchGridMenu
            // 
            this.searchGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editPatientToolStripMenuItem});
            this.searchGridMenu.Name = "searchGridMenu";
            this.searchGridMenu.Size = new System.Drawing.Size(130, 26);
            // 
            // editPatientToolStripMenuItem
            // 
            this.editPatientToolStripMenuItem.Name = "editPatientToolStripMenuItem";
            this.editPatientToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.editPatientToolStripMenuItem.Text = "Edit Patient";
            this.editPatientToolStripMenuItem.Click += new System.EventHandler(this.editPatientToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.springRightLabel,
            this.searchResultLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 437);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(709, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // springRightLabel
            // 
            this.springRightLabel.Name = "springRightLabel";
            this.springRightLabel.Size = new System.Drawing.Size(675, 17);
            this.springRightLabel.Spring = true;
            // 
            // searchResultLabel
            // 
            this.searchResultLabel.Name = "searchResultLabel";
            this.searchResultLabel.Size = new System.Drawing.Size(19, 17);
            this.searchResultLabel.Text = "...";
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 459);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.searchGrid);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.patientIDTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.birthdateTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ssnTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "frmSearch";
            this.Text = "Search Patients";
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            this.searchGridMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox ssnTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker birthdateTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox patientIDTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel springRightLabel;
        private System.Windows.Forms.ToolStripStatusLabel searchResultLabel;
        private System.Windows.Forms.ContextMenuStrip searchGridMenu;
        private System.Windows.Forms.ToolStripMenuItem editPatientToolStripMenuItem;
    }
}