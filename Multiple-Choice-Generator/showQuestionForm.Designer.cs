namespace Multiple_Choice_Generator
{
    partial class ShowQuestionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.questionLabel = new System.Windows.Forms.Label();
            this.lessonTitleLabel = new System.Windows.Forms.Label();
            this.diffTitleLabel = new System.Windows.Forms.Label();
            this.unitTitleLabel = new System.Windows.Forms.Label();
            this.questionTextbox = new System.Windows.Forms.TextBox();
            this.answersLabel = new System.Windows.Forms.Label();
            this.showAnswersDataGridView = new System.Windows.Forms.DataGridView();
            this.Questions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.diffLabel = new System.Windows.Forms.Label();
            this.unitLabel = new System.Windows.Forms.Label();
            this.lessonLabel = new System.Windows.Forms.Label();
            this.showAnswersPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.showAnswersDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.showAnswersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.questionLabel.Location = new System.Drawing.Point(36, 21);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(80, 18);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "Ερώτηση:";
            // 
            // lessonTitleLabel
            // 
            this.lessonTitleLabel.AutoSize = true;
            this.lessonTitleLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic);
            this.lessonTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.lessonTitleLabel.Name = "lessonTitleLabel";
            this.lessonTitleLabel.Size = new System.Drawing.Size(73, 18);
            this.lessonTitleLabel.TabIndex = 2;
            this.lessonTitleLabel.Text = "Μάθημα:";
            // 
            // diffTitleLabel
            // 
            this.diffTitleLabel.AutoSize = true;
            this.diffTitleLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic);
            this.diffTitleLabel.Location = new System.Drawing.Point(-2, 110);
            this.diffTitleLabel.Name = "diffTitleLabel";
            this.diffTitleLabel.Size = new System.Drawing.Size(85, 18);
            this.diffTitleLabel.TabIndex = 4;
            this.diffTitleLabel.Text = "Δυσκολία:";
            // 
            // unitTitleLabel
            // 
            this.unitTitleLabel.AutoSize = true;
            this.unitTitleLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic);
            this.unitTitleLabel.Location = new System.Drawing.Point(-1, 53);
            this.unitTitleLabel.Name = "unitTitleLabel";
            this.unitTitleLabel.Size = new System.Drawing.Size(74, 18);
            this.unitTitleLabel.TabIndex = 5;
            this.unitTitleLabel.Text = "Ενότητα:";
            // 
            // questionTextbox
            // 
            this.questionTextbox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.questionTextbox.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.questionTextbox.Location = new System.Drawing.Point(37, 42);
            this.questionTextbox.Multiline = true;
            this.questionTextbox.Name = "questionTextbox";
            this.questionTextbox.ReadOnly = true;
            this.questionTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.questionTextbox.ShortcutsEnabled = false;
            this.questionTextbox.Size = new System.Drawing.Size(713, 81);
            this.questionTextbox.TabIndex = 9;
            // 
            // answersLabel
            // 
            this.answersLabel.AutoSize = true;
            this.answersLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic);
            this.answersLabel.Location = new System.Drawing.Point(36, 136);
            this.answersLabel.Name = "answersLabel";
            this.answersLabel.Size = new System.Drawing.Size(91, 18);
            this.answersLabel.TabIndex = 13;
            this.answersLabel.Text = "Απαντήσεις";
            // 
            // showAnswersDataGridView
            // 
            this.showAnswersDataGridView.AllowUserToAddRows = false;
            this.showAnswersDataGridView.AllowUserToDeleteRows = false;
            this.showAnswersDataGridView.AllowUserToResizeColumns = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Teal;
            this.showAnswersDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.showAnswersDataGridView.BackgroundColor = System.Drawing.Color.DimGray;
            this.showAnswersDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.showAnswersDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.showAnswersDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.showAnswersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showAnswersDataGridView.ColumnHeadersVisible = false;
            this.showAnswersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Questions});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.showAnswersDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.showAnswersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showAnswersDataGridView.GridColor = System.Drawing.Color.DimGray;
            this.showAnswersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.showAnswersDataGridView.MultiSelect = false;
            this.showAnswersDataGridView.Name = "showAnswersDataGridView";
            this.showAnswersDataGridView.ReadOnly = true;
            this.showAnswersDataGridView.RowHeadersVisible = false;
            this.showAnswersDataGridView.RowTemplate.Height = 30;
            this.showAnswersDataGridView.RowTemplate.ReadOnly = true;
            this.showAnswersDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.showAnswersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.showAnswersDataGridView.Size = new System.Drawing.Size(713, 61);
            this.showAnswersDataGridView.TabIndex = 16;
            // 
            // Questions
            // 
            this.Questions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Questions.HeaderText = "Column1";
            this.Questions.Name = "Questions";
            this.Questions.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Controls.Add(this.questionLabel);
            this.panel1.Controls.Add(this.answersLabel);
            this.panel1.Controls.Add(this.infoPanel);
            this.panel1.Controls.Add(this.showAnswersPanel);
            this.panel1.Controls.Add(this.questionTextbox);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 523);
            this.panel1.TabIndex = 17;
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.diffLabel);
            this.infoPanel.Controls.Add(this.unitLabel);
            this.infoPanel.Controls.Add(this.lessonLabel);
            this.infoPanel.Controls.Add(this.diffTitleLabel);
            this.infoPanel.Controls.Add(this.lessonTitleLabel);
            this.infoPanel.Controls.Add(this.unitTitleLabel);
            this.infoPanel.Location = new System.Drawing.Point(36, 318);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(729, 200);
            this.infoPanel.TabIndex = 19;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.Red;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(646, 470);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(119, 45);
            this.closeButton.TabIndex = 21;
            this.closeButton.Text = "Κλείσιμο";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // diffLabel
            // 
            this.diffLabel.AutoSize = true;
            this.diffLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.diffLabel.Location = new System.Drawing.Point(-4, 128);
            this.diffLabel.Name = "diffLabel";
            this.diffLabel.Size = new System.Drawing.Size(0, 25);
            this.diffLabel.TabIndex = 20;
            // 
            // unitLabel
            // 
            this.unitLabel.AutoSize = true;
            this.unitLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.unitLabel.Location = new System.Drawing.Point(-4, 71);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.Size = new System.Drawing.Size(0, 25);
            this.unitLabel.TabIndex = 19;
            // 
            // lessonLabel
            // 
            this.lessonLabel.AutoSize = true;
            this.lessonLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.lessonLabel.Location = new System.Drawing.Point(-2, 18);
            this.lessonLabel.Name = "lessonLabel";
            this.lessonLabel.Size = new System.Drawing.Size(0, 25);
            this.lessonLabel.TabIndex = 18;
            // 
            // showAnswersPanel
            // 
            this.showAnswersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showAnswersPanel.Controls.Add(this.showAnswersDataGridView);
            this.showAnswersPanel.Location = new System.Drawing.Point(39, 157);
            this.showAnswersPanel.Name = "showAnswersPanel";
            this.showAnswersPanel.Size = new System.Drawing.Size(713, 61);
            this.showAnswersPanel.TabIndex = 17;
            // 
            // ShowQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 528);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ShowQuestionForm";
            this.Text = "Ερώτηση";
            this.Load += new System.EventHandler(this.ShowQuestionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showAnswersDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.showAnswersPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Label lessonTitleLabel;
        private System.Windows.Forms.Label diffTitleLabel;
        private System.Windows.Forms.Label unitTitleLabel;
        private System.Windows.Forms.TextBox questionTextbox;
        private System.Windows.Forms.Label answersLabel;
        private System.Windows.Forms.DataGridView showAnswersDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel showAnswersPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Questions;
        private System.Windows.Forms.Label lessonLabel;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label diffLabel;
        private System.Windows.Forms.Label unitLabel;
    }
}