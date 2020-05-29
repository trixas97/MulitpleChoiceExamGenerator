namespace Multiple_Choice_Generator
{
    partial class EditLessonForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.unitsDataGridView = new System.Windows.Forms.DataGridView();
            this.unitCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.unitsDataGridViewPanel = new System.Windows.Forms.Panel();
            this.questionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            this.lessonTextbox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.deleteLessonButton = new System.Windows.Forms.Button();
            this.errorTittleLabel = new System.Windows.Forms.Label();
            this.errorsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.unitsDataGridView)).BeginInit();
            this.unitsDataGridViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // unitsDataGridView
            // 
            this.unitsDataGridView.AllowUserToDeleteRows = false;
            this.unitsDataGridView.AllowUserToResizeColumns = false;
            this.unitsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            this.unitsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.unitsDataGridView.BackgroundColor = System.Drawing.Color.DimGray;
            this.unitsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.unitsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.unitsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 14.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.unitsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.unitsDataGridView.ColumnHeadersHeight = 30;
            this.unitsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.unitsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.unitCol,
            this.deleteCol});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.unitsDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.unitsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitsDataGridView.EnableHeadersVisualStyles = false;
            this.unitsDataGridView.GridColor = System.Drawing.Color.DimGray;
            this.unitsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.unitsDataGridView.MultiSelect = false;
            this.unitsDataGridView.Name = "unitsDataGridView";
            this.unitsDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.unitsDataGridView.RowHeadersVisible = false;
            this.unitsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.unitsDataGridView.RowTemplate.Height = 30;
            this.unitsDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.unitsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.unitsDataGridView.Size = new System.Drawing.Size(831, 250);
            this.unitsDataGridView.TabIndex = 17;
            this.unitsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.unitsDataGridView_CellContentClick);
            this.unitsDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.unitsDataGridView_CellMouseClick);
            // 
            // unitCol
            // 
            this.unitCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.unitCol.HeaderText = "Επεξεργασία";
            this.unitCol.Name = "unitCol";
            this.unitCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // deleteCol
            // 
            this.deleteCol.FillWeight = 80F;
            this.deleteCol.HeaderText = "Διαγραφή";
            this.deleteCol.MinimumWidth = 80;
            this.deleteCol.Name = "deleteCol";
            this.deleteCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.deleteCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // unitsDataGridViewPanel
            // 
            this.unitsDataGridViewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitsDataGridViewPanel.Controls.Add(this.unitsDataGridView);
            this.unitsDataGridViewPanel.Location = new System.Drawing.Point(30, 185);
            this.unitsDataGridViewPanel.Name = "unitsDataGridViewPanel";
            this.unitsDataGridViewPanel.Size = new System.Drawing.Size(831, 250);
            this.unitsDataGridViewPanel.TabIndex = 18;
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.questionLabel.Location = new System.Drawing.Point(27, 9);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(73, 18);
            this.questionLabel.TabIndex = 19;
            this.questionLabel.Text = "Μάθημα:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(27, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "Ενότητες:";
            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextbox.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.descriptionTextbox.Location = new System.Drawing.Point(30, 102);
            this.descriptionTextbox.Multiline = true;
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.Size = new System.Drawing.Size(831, 59);
            this.descriptionTextbox.TabIndex = 22;
            // 
            // lessonTextbox
            // 
            this.lessonTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lessonTextbox.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.lessonTextbox.Location = new System.Drawing.Point(30, 31);
            this.lessonTextbox.Name = "lessonTextbox";
            this.lessonTextbox.Size = new System.Drawing.Size(831, 33);
            this.lessonTextbox.TabIndex = 23;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.OrangeRed;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(617, 462);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(119, 45);
            this.cancelButton.TabIndex = 24;
            this.cancelButton.Text = "Ακύρωση";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.BackColor = System.Drawing.Color.LimeGreen;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.okButton.ForeColor = System.Drawing.Color.White;
            this.okButton.Location = new System.Drawing.Point(742, 462);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(119, 45);
            this.okButton.TabIndex = 25;
            this.okButton.Text = "Επιβεβαίωση";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // deleteLessonButton
            // 
            this.deleteLessonButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteLessonButton.BackColor = System.Drawing.Color.Red;
            this.deleteLessonButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteLessonButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.deleteLessonButton.ForeColor = System.Drawing.Color.White;
            this.deleteLessonButton.Location = new System.Drawing.Point(492, 462);
            this.deleteLessonButton.Name = "deleteLessonButton";
            this.deleteLessonButton.Size = new System.Drawing.Size(119, 45);
            this.deleteLessonButton.TabIndex = 26;
            this.deleteLessonButton.Text = "Διαγραφή Μαθήματος";
            this.deleteLessonButton.UseVisualStyleBackColor = false;
            this.deleteLessonButton.Click += new System.EventHandler(this.deleteLessonButton_Click);
            // 
            // errorTittleLabel
            // 
            this.errorTittleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.errorTittleLabel.AutoSize = true;
            this.errorTittleLabel.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.errorTittleLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorTittleLabel.Location = new System.Drawing.Point(27, 462);
            this.errorTittleLabel.Name = "errorTittleLabel";
            this.errorTittleLabel.Size = new System.Drawing.Size(371, 18);
            this.errorTittleLabel.TabIndex = 28;
            this.errorTittleLabel.Text = "Βρέθηκαν σφάλματα. Προσπαθήστε ξανά.";
            this.errorTittleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.errorTittleLabel.Visible = false;
            // 
            // errorsLabel
            // 
            this.errorsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorsLabel.AutoEllipsis = true;
            this.errorsLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.errorsLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorsLabel.Location = new System.Drawing.Point(27, 480);
            this.errorsLabel.Name = "errorsLabel";
            this.errorsLabel.Size = new System.Drawing.Size(455, 30);
            this.errorsLabel.TabIndex = 27;
            this.errorsLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(27, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "Περιγραφή:";
            // 
            // EditLessonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 519);
            this.Controls.Add(this.errorTittleLabel);
            this.Controls.Add(this.errorsLabel);
            this.Controls.Add(this.deleteLessonButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.lessonTextbox);
            this.Controls.Add(this.descriptionTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.unitsDataGridViewPanel);
            this.MinimumSize = new System.Drawing.Size(900, 558);
            this.Name = "EditLessonForm";
            this.Text = "Επεξεργασία μαθήματος";
            this.Load += new System.EventHandler(this.EditLessonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.unitsDataGridView)).EndInit();
            this.unitsDataGridViewPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView unitsDataGridView;
        private System.Windows.Forms.Panel unitsDataGridViewPanel;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descriptionTextbox;
        private System.Windows.Forms.TextBox lessonTextbox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button deleteLessonButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn deleteCol;
        private System.Windows.Forms.Label errorTittleLabel;
        private System.Windows.Forms.Label errorsLabel;
        private System.Windows.Forms.Label label2;
    }
}