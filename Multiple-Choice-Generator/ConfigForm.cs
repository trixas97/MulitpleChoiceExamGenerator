using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Choice_Generator
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        public ConfigForm(String l, String cancelText, String confText, Color confColor, String title)
        {
            InitializeComponent();

            this.textLabel.Text = l;
            this.Text = title;
            this.cancelButton.Text = cancelText;
            this.confButton.Text = confText;
            this.confButton.BackColor = confColor;
        }

        private void confButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }
    }
}
