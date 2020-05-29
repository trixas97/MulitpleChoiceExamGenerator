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
    public partial class infoForm : Form
    {
        Form father;

        public infoForm(Form father)
        {
            InitializeComponent();
            this.father = father;
        }

        private void infoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((Form1)this.father).setterinfo = null;
        }

        private void infoForm_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }
    }
}
