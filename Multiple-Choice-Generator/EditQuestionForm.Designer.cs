namespace Multiple_Choice_Generator
{
    partial class EditQuestionForm
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
            this.questionTextbox = new System.Windows.Forms.TextBox();
            this.questionLabel = new System.Windows.Forms.Label();
            this.anwersLabel = new System.Windows.Forms.Label();
            this.lessonLabel = new System.Windows.Forms.Label();
            this.unitLabel = new System.Windows.Forms.Label();
            this.diffLabel = new System.Windows.Forms.Label();
            this.deleteQuestionButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorTittleLabel = new System.Windows.Forms.Label();
            this.errorsLabel = new System.Windows.Forms.Label();
            this.diffRadioButton1 = new System.Windows.Forms.RadioButton();
            this.diffRadioButton3 = new System.Windows.Forms.RadioButton();
            this.diffRadioButton2 = new System.Windows.Forms.RadioButton();
            this.lessonTextbox = new System.Windows.Forms.TextBox();
            this.unitsComboBox = new System.Windows.Forms.ComboBox();
            this.editQuestionDGVPanel = new System.Windows.Forms.Panel();
            this.editQuestionsDataGridView = new System.Windows.Forms.DataGridView();
            this.unitCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.editQuestionDGVPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editQuestionsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // questionTextbox
            // 
            this.questionTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionTextbox.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.questionTextbox.Location = new System.Drawing.Point(15, 39);
            this.questionTextbox.Multiline = true;
            this.questionTextbox.Name = "questionTextbox";
            this.questionTextbox.Size = new System.Drawing.Size(816, 84);
            this.questionTextbox.TabIndex = 25;
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.questionLabel.Location = new System.Drawing.Point(12, 18);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(80, 18);
            this.questionLabel.TabIndex = 24;
            this.questionLabel.Text = "Ερώτηση:";
            // 
            // anwersLabel
            // 
            this.anwersLabel.AutoSize = true;
            this.anwersLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.anwersLabel.Location = new System.Drawing.Point(12, 137);
            this.anwersLabel.Name = "anwersLabel";
            this.anwersLabel.Size = new System.Drawing.Size(98, 18);
            this.anwersLabel.TabIndex = 26;
            this.anwersLabel.Text = "Απαντήσεις:";
            // 
            // lessonLabel
            // 
            this.lessonLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lessonLabel.AutoSize = true;
            this.lessonLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lessonLabel.Location = new System.Drawing.Point(15, 280);
            this.lessonLabel.Name = "lessonLabel";
            this.lessonLabel.Size = new System.Drawing.Size(73, 18);
            this.lessonLabel.TabIndex = 27;
            this.lessonLabel.Text = "Μάθημα:";
            // 
            // unitLabel
            // 
            this.unitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitLabel.AutoSize = true;
            this.unitLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.unitLabel.Location = new System.Drawing.Point(15, 347);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.Size = new System.Drawing.Size(74, 18);
            this.unitLabel.TabIndex = 28;
            this.unitLabel.Text = "Ενότητα:";
            // 
            // diffLabel
            // 
            this.diffLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diffLabel.AutoSize = true;
            this.diffLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.diffLabel.Location = new System.Drawing.Point(15, 415);
            this.diffLabel.Name = "diffLabel";
            this.diffLabel.Size = new System.Drawing.Size(85, 18);
            this.diffLabel.TabIndex = 29;
            this.diffLabel.Text = "Δυσκολία:";
            // 
            // deleteQuestionButton
            // 
            this.deleteQuestionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteQuestionButton.BackColor = System.Drawing.Color.Red;
            this.deleteQuestionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteQuestionButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.deleteQuestionButton.ForeColor = System.Drawing.Color.White;
            this.deleteQuestionButton.Location = new System.Drawing.Point(466, 490);
            this.deleteQuestionButton.Name = "deleteQuestionButton";
            this.deleteQuestionButton.Size = new System.Drawing.Size(119, 45);
            this.deleteQuestionButton.TabIndex = 32;
            this.deleteQuestionButton.Text = "Διαγραφή Ερώτησης";
            this.deleteQuestionButton.UseVisualStyleBackColor = false;
            this.deleteQuestionButton.Click += new System.EventHandler(this.deleteQuestionButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.BackColor = System.Drawing.Color.LimeGreen;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.okButton.ForeColor = System.Drawing.Color.White;
            this.okButton.Location = new System.Drawing.Point(716, 490);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(119, 45);
            this.okButton.TabIndex = 31;
            this.okButton.Text = "Επιβεβαίωση";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.OrangeRed;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(591, 490);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(119, 45);
            this.cancelButton.TabIndex = 30;
            this.cancelButton.Text = "Ακύρωση";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // errorTittleLabel
            // 
            this.errorTittleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.errorTittleLabel.AutoSize = true;
            this.errorTittleLabel.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.errorTittleLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorTittleLabel.Location = new System.Drawing.Point(12, 479);
            this.errorTittleLabel.Name = "errorTittleLabel";
            this.errorTittleLabel.Size = new System.Drawing.Size(371, 18);
            this.errorTittleLabel.TabIndex = 34;
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
            this.errorsLabel.Location = new System.Drawing.Point(12, 497);
            this.errorsLabel.Name = "errorsLabel";
            this.errorsLabel.Size = new System.Drawing.Size(448, 30);
            this.errorsLabel.TabIndex = 33;
            this.errorsLabel.Visible = false;
            // 
            // diffRadioButton1
            // 
            this.diffRadioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diffRadioButton1.AutoSize = true;
            this.diffRadioButton1.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.diffRadioButton1.Location = new System.Drawing.Point(16, 437);
            this.diffRadioButton1.Name = "diffRadioButton1";
            this.diffRadioButton1.Size = new System.Drawing.Size(96, 29);
            this.diffRadioButton1.TabIndex = 37;
            this.diffRadioButton1.TabStop = true;
            this.diffRadioButton1.Text = "Εύκολη";
            this.diffRadioButton1.UseVisualStyleBackColor = true;
            // 
            // diffRadioButton3
            // 
            this.diffRadioButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diffRadioButton3.AutoSize = true;
            this.diffRadioButton3.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.diffRadioButton3.Location = new System.Drawing.Point(260, 437);
            this.diffRadioButton3.Name = "diffRadioButton3";
            this.diffRadioButton3.Size = new System.Drawing.Size(111, 29);
            this.diffRadioButton3.TabIndex = 38;
            this.diffRadioButton3.TabStop = true;
            this.diffRadioButton3.Text = "Δύσκολη";
            this.diffRadioButton3.UseVisualStyleBackColor = true;
            // 
            // diffRadioButton2
            // 
            this.diffRadioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diffRadioButton2.AutoSize = true;
            this.diffRadioButton2.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.diffRadioButton2.Location = new System.Drawing.Point(140, 437);
            this.diffRadioButton2.Name = "diffRadioButton2";
            this.diffRadioButton2.Size = new System.Drawing.Size(95, 29);
            this.diffRadioButton2.TabIndex = 39;
            this.diffRadioButton2.TabStop = true;
            this.diffRadioButton2.Text = "Μέτρια";
            this.diffRadioButton2.UseVisualStyleBackColor = true;
            // 
            // lessonTextbox
            // 
            this.lessonTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lessonTextbox.Enabled = false;
            this.lessonTextbox.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.lessonTextbox.Location = new System.Drawing.Point(18, 301);
            this.lessonTextbox.Name = "lessonTextbox";
            this.lessonTextbox.Size = new System.Drawing.Size(813, 33);
            this.lessonTextbox.TabIndex = 35;
            // 
            // unitsComboBox
            // 
            this.unitsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitsComboBox.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.unitsComboBox.FormattingEnabled = true;
            this.unitsComboBox.Location = new System.Drawing.Point(18, 368);
            this.unitsComboBox.Name = "unitsComboBox";
            this.unitsComboBox.Size = new System.Drawing.Size(813, 33);
            this.unitsComboBox.TabIndex = 40;
            // 
            // editQuestionDGVPanel
            // 
            this.editQuestionDGVPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editQuestionDGVPanel.Controls.Add(this.editQuestionsDataGridView);
            this.editQuestionDGVPanel.Location = new System.Drawing.Point(18, 159);
            this.editQuestionDGVPanel.Name = "editQuestionDGVPanel";
            this.editQuestionDGVPanel.Size = new System.Drawing.Size(813, 108);
            this.editQuestionDGVPanel.TabIndex = 41;
            // 
            // editQuestionsDataGridView
            // 
            this.editQuestionsDataGridView.AllowUserToDeleteRows = false;
            this.editQuestionsDataGridView.AllowUserToResizeColumns = false;
            this.editQuestionsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            this.editQuestionsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.editQuestionsDataGridView.BackgroundColor = System.Drawing.Color.DimGray;
            this.editQuestionsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editQuestionsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.editQuestionsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 14.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.editQuestionsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.editQuestionsDataGridView.ColumnHeadersHeight = 30;
            this.editQuestionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.editQuestionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.unitCol,
            this.deleteCol});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.editQuestionsDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.editQuestionsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editQuestionsDataGridView.EnableHeadersVisualStyles = false;
            this.editQuestionsDataGridView.GridColor = System.Drawing.Color.DimGray;
            this.editQuestionsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.editQuestionsDataGridView.MultiSelect = false;
            this.editQuestionsDataGridView.Name = "editQuestionsDataGridView";
            this.editQuestionsDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.editQuestionsDataGridView.RowHeadersVisible = false;
            this.editQuestionsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.editQuestionsDataGridView.RowTemplate.Height = 30;
            this.editQuestionsDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.editQuestionsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.editQuestionsDataGridView.Size = new System.Drawing.Size(813, 108);
            this.editQuestionsDataGridView.TabIndex = 18;
            this.editQuestionsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.editQuestionsDataGridView_CellContentClick);
            this.editQuestionsDataGridView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.editQuestionsDataGridView_CellLeave);
            this.editQuestionsDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.editQuestionsDataGridView_RowsAdded);
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
            // EditQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 547);
            this.Controls.Add(this.editQuestionDGVPanel);
            this.Controls.Add(this.unitsComboBox);
            this.Controls.Add(this.diffRadioButton2);
            this.Controls.Add(this.diffRadioButton3);
            this.Controls.Add(this.diffRadioButton1);
            this.Controls.Add(this.lessonTextbox);
            this.Controls.Add(this.errorTittleLabel);
            this.Controls.Add(this.errorsLabel);
            this.Controls.Add(this.deleteQuestionButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.diffLabel);
            this.Controls.Add(this.unitLabel);
            this.Controls.Add(this.lessonLabel);
            this.Controls.Add(this.anwersLabel);
            this.Controls.Add(this.questionTextbox);
            this.Controls.Add(this.questionLabel);
            this.MinimumSize = new System.Drawing.Size(861, 586);
            this.Name = "EditQuestionForm";
            this.Text = "Επεξεργασία ερώτησης";
            this.Load += new System.EventHandler(this.EditQuestionForm_Load);
            this.editQuestionDGVPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editQuestionsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox questionTextbox;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Label anwersLabel;
        private System.Windows.Forms.Label lessonLabel;
        private System.Windows.Forms.Label unitLabel;
        private System.Windows.Forms.Label diffLabel;
        private System.Windows.Forms.Button deleteQuestionButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label errorTittleLabel;
        private System.Windows.Forms.Label errorsLabel;
        private System.Windows.Forms.RadioButton diffRadioButton1;
        private System.Windows.Forms.RadioButton diffRadioButton3;
        private System.Windows.Forms.RadioButton diffRadioButton2;
        private System.Windows.Forms.TextBox lessonTextbox;
        private System.Windows.Forms.ComboBox unitsComboBox;
        private System.Windows.Forms.Panel editQuestionDGVPanel;
        private System.Windows.Forms.DataGridView editQuestionsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn deleteCol;
    }
}