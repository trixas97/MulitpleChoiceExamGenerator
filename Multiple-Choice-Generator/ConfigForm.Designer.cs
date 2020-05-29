namespace Multiple_Choice_Generator
{
    partial class ConfigForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.textLabel = new System.Windows.Forms.Label();
            this.confButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.Control;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cancelButton.Location = new System.Drawing.Point(347, 133);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(119, 45);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Ακύρωση";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(12, 58);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(35, 13);
            this.textLabel.TabIndex = 1;
            this.textLabel.Text = "label1";
            // 
            // confButton
            // 
            this.confButton.BackColor = System.Drawing.Color.Red;
            this.confButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.confButton.ForeColor = System.Drawing.Color.White;
            this.confButton.Location = new System.Drawing.Point(222, 133);
            this.confButton.Name = "confButton";
            this.confButton.Size = new System.Drawing.Size(119, 45);
            this.confButton.TabIndex = 2;
            this.confButton.Text = "Κλείσιμο";
            this.confButton.UseVisualStyleBackColor = false;
            this.confButton.Click += new System.EventHandler(this.confButton_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(478, 190);
            this.Controls.Add(this.confButton);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConfigForm";
            this.Text = "Επιβεβαίωση";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Button confButton;
    }
}