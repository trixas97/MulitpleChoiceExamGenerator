namespace Multiple_Choice_Generator
{
    partial class settingsForm
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
            this.leftPanel = new System.Windows.Forms.Panel();
            this.systemButton = new System.Windows.Forms.Button();
            this.personalButton = new System.Windows.Forms.Button();
            this.personalPanel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.settingsSchoolTextbox = new System.Windows.Forms.TextBox();
            this.settingsConfButton = new System.Windows.Forms.Button();
            this.settingsEditButton = new System.Windows.Forms.Button();
            this.settingsGenderRadioButton2 = new System.Windows.Forms.RadioButton();
            this.settingsGenderRadioButton1 = new System.Windows.Forms.RadioButton();
            this.settingsBirthTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.settingsLastnameTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.settingsFirstnameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsEmailTextbox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.settingsUsernameTextbox = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.systemPanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.OSLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.changeThemeButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.leftPanel.SuspendLayout();
            this.personalPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.systemPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.leftPanel.Controls.Add(this.systemButton);
            this.leftPanel.Controls.Add(this.personalButton);
            this.leftPanel.Location = new System.Drawing.Point(0, 1);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(200, 458);
            this.leftPanel.TabIndex = 0;
            this.leftPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // systemButton
            // 
            this.systemButton.FlatAppearance.BorderSize = 0;
            this.systemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.systemButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.systemButton.ForeColor = System.Drawing.Color.White;
            this.systemButton.Location = new System.Drawing.Point(0, 174);
            this.systemButton.Name = "systemButton";
            this.systemButton.Size = new System.Drawing.Size(200, 45);
            this.systemButton.TabIndex = 1;
            this.systemButton.Text = "Σύστημα";
            this.systemButton.UseVisualStyleBackColor = true;
            this.systemButton.Click += new System.EventHandler(this.systemButton_Click);
            // 
            // personalButton
            // 
            this.personalButton.FlatAppearance.BorderSize = 0;
            this.personalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.personalButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.personalButton.ForeColor = System.Drawing.Color.White;
            this.personalButton.Location = new System.Drawing.Point(0, 123);
            this.personalButton.Name = "personalButton";
            this.personalButton.Size = new System.Drawing.Size(200, 45);
            this.personalButton.TabIndex = 0;
            this.personalButton.Text = "Προσωπικά Στοιχεία";
            this.personalButton.UseVisualStyleBackColor = true;
            this.personalButton.Click += new System.EventHandler(this.personalButton_Click);
            // 
            // personalPanel
            // 
            this.personalPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.personalPanel.Controls.Add(this.label12);
            this.personalPanel.Controls.Add(this.settingsSchoolTextbox);
            this.personalPanel.Controls.Add(this.settingsConfButton);
            this.personalPanel.Controls.Add(this.settingsEditButton);
            this.personalPanel.Controls.Add(this.settingsGenderRadioButton2);
            this.personalPanel.Controls.Add(this.settingsGenderRadioButton1);
            this.personalPanel.Controls.Add(this.settingsBirthTextBox);
            this.personalPanel.Controls.Add(this.label6);
            this.personalPanel.Controls.Add(this.label3);
            this.personalPanel.Controls.Add(this.label4);
            this.personalPanel.Controls.Add(this.settingsLastnameTextbox);
            this.personalPanel.Controls.Add(this.label5);
            this.personalPanel.Controls.Add(this.settingsFirstnameTextbox);
            this.personalPanel.Controls.Add(this.label1);
            this.personalPanel.Controls.Add(this.settingsEmailTextbox);
            this.personalPanel.Controls.Add(this.label14);
            this.personalPanel.Controls.Add(this.settingsUsernameTextbox);
            this.personalPanel.Location = new System.Drawing.Point(0, 0);
            this.personalPanel.Name = "personalPanel";
            this.personalPanel.Size = new System.Drawing.Size(601, 458);
            this.personalPanel.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label12.Location = new System.Drawing.Point(23, 304);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 18);
            this.label12.TabIndex = 20;
            this.label12.Text = "Σχολή-Σχολέιο:";
            // 
            // settingsSchoolTextbox
            // 
            this.settingsSchoolTextbox.Enabled = false;
            this.settingsSchoolTextbox.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.settingsSchoolTextbox.Location = new System.Drawing.Point(163, 296);
            this.settingsSchoolTextbox.Name = "settingsSchoolTextbox";
            this.settingsSchoolTextbox.Size = new System.Drawing.Size(414, 33);
            this.settingsSchoolTextbox.TabIndex = 19;
            // 
            // settingsConfButton
            // 
            this.settingsConfButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsConfButton.BackColor = System.Drawing.Color.LimeGreen;
            this.settingsConfButton.Enabled = false;
            this.settingsConfButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsConfButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.settingsConfButton.ForeColor = System.Drawing.Color.White;
            this.settingsConfButton.Location = new System.Drawing.Point(395, 370);
            this.settingsConfButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.settingsConfButton.Name = "settingsConfButton";
            this.settingsConfButton.Size = new System.Drawing.Size(182, 60);
            this.settingsConfButton.TabIndex = 18;
            this.settingsConfButton.Text = "Εφαρμογή";
            this.settingsConfButton.UseVisualStyleBackColor = false;
            this.settingsConfButton.Click += new System.EventHandler(this.settingsConfButton_Click);
            // 
            // settingsEditButton
            // 
            this.settingsEditButton.BackColor = System.Drawing.Color.Gold;
            this.settingsEditButton.FlatAppearance.BorderSize = 0;
            this.settingsEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsEditButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.settingsEditButton.ForeColor = System.Drawing.Color.White;
            this.settingsEditButton.Image = global::Multiple_Choice_Generator.Properties.Resources.edit1;
            this.settingsEditButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsEditButton.Location = new System.Drawing.Point(434, 20);
            this.settingsEditButton.Name = "settingsEditButton";
            this.settingsEditButton.Size = new System.Drawing.Size(143, 40);
            this.settingsEditButton.TabIndex = 17;
            this.settingsEditButton.Text = "Επεξεργασία";
            this.settingsEditButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settingsEditButton.UseVisualStyleBackColor = false;
            this.settingsEditButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // settingsGenderRadioButton2
            // 
            this.settingsGenderRadioButton2.AutoSize = true;
            this.settingsGenderRadioButton2.Enabled = false;
            this.settingsGenderRadioButton2.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.settingsGenderRadioButton2.Location = new System.Drawing.Point(265, 335);
            this.settingsGenderRadioButton2.Name = "settingsGenderRadioButton2";
            this.settingsGenderRadioButton2.Size = new System.Drawing.Size(102, 29);
            this.settingsGenderRadioButton2.TabIndex = 16;
            this.settingsGenderRadioButton2.TabStop = true;
            this.settingsGenderRadioButton2.Text = "Γυναίκα";
            this.settingsGenderRadioButton2.UseVisualStyleBackColor = true;
            // 
            // settingsGenderRadioButton1
            // 
            this.settingsGenderRadioButton1.AutoSize = true;
            this.settingsGenderRadioButton1.Enabled = false;
            this.settingsGenderRadioButton1.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.settingsGenderRadioButton1.Location = new System.Drawing.Point(163, 335);
            this.settingsGenderRadioButton1.Name = "settingsGenderRadioButton1";
            this.settingsGenderRadioButton1.Size = new System.Drawing.Size(97, 29);
            this.settingsGenderRadioButton1.TabIndex = 15;
            this.settingsGenderRadioButton1.TabStop = true;
            this.settingsGenderRadioButton1.Text = "Άντρας";
            this.settingsGenderRadioButton1.UseVisualStyleBackColor = true;
            // 
            // settingsBirthTextBox
            // 
            this.settingsBirthTextBox.Enabled = false;
            this.settingsBirthTextBox.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.settingsBirthTextBox.Location = new System.Drawing.Point(163, 256);
            this.settingsBirthTextBox.Mask = "00/00/0000";
            this.settingsBirthTextBox.Name = "settingsBirthTextBox";
            this.settingsBirthTextBox.Size = new System.Drawing.Size(100, 33);
            this.settingsBirthTextBox.TabIndex = 14;
            this.settingsBirthTextBox.Text = "21081997";
            this.settingsBirthTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label6.Location = new System.Drawing.Point(100, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Φύλο:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.Location = new System.Drawing.Point(34, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ημ. Γέννησης:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.Location = new System.Drawing.Point(81, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Επίθετο:";
            // 
            // settingsLastnameTextbox
            // 
            this.settingsLastnameTextbox.Enabled = false;
            this.settingsLastnameTextbox.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.settingsLastnameTextbox.Location = new System.Drawing.Point(163, 178);
            this.settingsLastnameTextbox.Name = "settingsLastnameTextbox";
            this.settingsLastnameTextbox.Size = new System.Drawing.Size(414, 33);
            this.settingsLastnameTextbox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label5.Location = new System.Drawing.Point(89, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Όνομα:";
            // 
            // settingsFirstnameTextbox
            // 
            this.settingsFirstnameTextbox.Enabled = false;
            this.settingsFirstnameTextbox.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.settingsFirstnameTextbox.Location = new System.Drawing.Point(163, 217);
            this.settingsFirstnameTextbox.Name = "settingsFirstnameTextbox";
            this.settingsFirstnameTextbox.Size = new System.Drawing.Size(414, 33);
            this.settingsFirstnameTextbox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(97, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Email:";
            // 
            // settingsEmailTextbox
            // 
            this.settingsEmailTextbox.Enabled = false;
            this.settingsEmailTextbox.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.settingsEmailTextbox.Location = new System.Drawing.Point(163, 116);
            this.settingsEmailTextbox.Name = "settingsEmailTextbox";
            this.settingsEmailTextbox.Size = new System.Drawing.Size(414, 33);
            this.settingsEmailTextbox.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label14.Location = new System.Drawing.Point(25, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 18);
            this.label14.TabIndex = 2;
            this.label14.Text = "Όνομα Χρήστη:";
            // 
            // settingsUsernameTextbox
            // 
            this.settingsUsernameTextbox.Enabled = false;
            this.settingsUsernameTextbox.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.settingsUsernameTextbox.Location = new System.Drawing.Point(163, 77);
            this.settingsUsernameTextbox.Name = "settingsUsernameTextbox";
            this.settingsUsernameTextbox.Size = new System.Drawing.Size(414, 33);
            this.settingsUsernameTextbox.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Controls.Add(this.personalPanel);
            this.mainPanel.Controls.Add(this.systemPanel);
            this.mainPanel.Location = new System.Drawing.Point(196, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(601, 458);
            this.mainPanel.TabIndex = 16;
            // 
            // systemPanel
            // 
            this.systemPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.systemPanel.Controls.Add(this.label11);
            this.systemPanel.Controls.Add(this.dateLabel);
            this.systemPanel.Controls.Add(this.label10);
            this.systemPanel.Controls.Add(this.label9);
            this.systemPanel.Controls.Add(this.OSLabel);
            this.systemPanel.Controls.Add(this.label8);
            this.systemPanel.Controls.Add(this.label7);
            this.systemPanel.Controls.Add(this.changeThemeButton);
            this.systemPanel.Controls.Add(this.comboBox1);
            this.systemPanel.Location = new System.Drawing.Point(0, 0);
            this.systemPanel.Name = "systemPanel";
            this.systemPanel.Size = new System.Drawing.Size(604, 458);
            this.systemPanel.TabIndex = 1;
            this.systemPanel.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label11.Location = new System.Drawing.Point(33, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 23);
            this.label11.TabIndex = 21;
            this.label11.Text = "Ημερομηνία:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic);
            this.dateLabel.Location = new System.Drawing.Point(34, 311);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(15, 18);
            this.dateLabel.TabIndex = 20;
            this.dateLabel.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label10.Location = new System.Drawing.Point(34, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 18);
            this.label10.TabIndex = 19;
            this.label10.Text = "1.0.0.0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label9.Location = new System.Drawing.Point(33, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(228, 23);
            this.label9.TabIndex = 18;
            this.label9.Text = "Έκδοση Εφαρμογής:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // OSLabel
            // 
            this.OSLabel.AutoSize = true;
            this.OSLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.OSLabel.Location = new System.Drawing.Point(34, 241);
            this.OSLabel.Name = "OSLabel";
            this.OSLabel.Size = new System.Drawing.Size(15, 18);
            this.OSLabel.TabIndex = 17;
            this.OSLabel.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label8.Location = new System.Drawing.Point(33, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(245, 23);
            this.label8.TabIndex = 16;
            this.label8.Text = "Λειτουργικό Σύστημα:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(33, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Θέμα:";
            // 
            // changeThemeButton
            // 
            this.changeThemeButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.changeThemeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeThemeButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.changeThemeButton.ForeColor = System.Drawing.Color.White;
            this.changeThemeButton.Location = new System.Drawing.Point(209, 80);
            this.changeThemeButton.Name = "changeThemeButton";
            this.changeThemeButton.Size = new System.Drawing.Size(111, 27);
            this.changeThemeButton.TabIndex = 14;
            this.changeThemeButton.Text = "Αλλαγή";
            this.changeThemeButton.UseVisualStyleBackColor = false;
            this.changeThemeButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Normal",
            "Dark"});
            this.comboBox1.Location = new System.Drawing.Point(37, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 26);
            this.comboBox1.TabIndex = 13;
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.leftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "settingsForm";
            this.Text = "Ρυθμίσεις";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.settingsForm_FormClosing);
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.leftPanel.ResumeLayout(false);
            this.personalPanel.ResumeLayout(false);
            this.personalPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.systemPanel.ResumeLayout(false);
            this.systemPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Button personalButton;
        private System.Windows.Forms.Button systemButton;
        private System.Windows.Forms.Panel personalPanel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox settingsUsernameTextbox;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel systemPanel;
        private System.Windows.Forms.Button changeThemeButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox settingsLastnameTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox settingsFirstnameTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox settingsEmailTextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button settingsEditButton;
        private System.Windows.Forms.RadioButton settingsGenderRadioButton2;
        private System.Windows.Forms.RadioButton settingsGenderRadioButton1;
        private System.Windows.Forms.Button settingsConfButton;
        private System.Windows.Forms.MaskedTextBox settingsBirthTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label OSLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox settingsSchoolTextbox;
    }
}