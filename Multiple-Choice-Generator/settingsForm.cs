using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multiple_Choice_Generator.Properties;


namespace Multiple_Choice_Generator
{
    public partial class settingsForm : Form
    {
        database db = new database();
        List<string> user = new List<string>();
        Form1 father = new Form1();    //father form
        public settingsForm(Form1 a, List<string> b)
        {
            user = b;
            InitializeComponent();
            this.father = a;
            this.MaximizeBox = false;
        }

        //SET sett IN FORM1 NULL
        private void settingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((Form1)this.father).setterSett = null;
        }


        //CHANGE THEME
        private void button2_Click(object sender, EventArgs e)
        {
            int temp = comboBox1.SelectedIndex;
            if (temp == 1)
            {
                Settings.Default["BackColor"] = Color.DimGray;
                Settings.Default["Filters"] = Color.Gray;
                Settings.Default["ButtonColor1"] = Color.Goldenrod;
            }
            else            
            {
                Settings.Default["BackColor"] = Color.DodgerBlue;
                Settings.Default["Filters"] = Color.SkyBlue;
                Settings.Default["ButtonColor1"] = Color.DodgerBlue;
            }                
            Settings.Default.Save();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if(settingsConfButton.Enabled == false)
            {
                this.settingsEmailTextbox.Enabled = true;
                this.settingsFirstnameTextbox.Enabled = true;
                this.settingsLastnameTextbox.Enabled = true;
                this.settingsGenderRadioButton1.Enabled = true;
                this.settingsGenderRadioButton2.Enabled = true;
                this.settingsBirthTextBox.Enabled = true;
                this.settingsConfButton.Enabled = true;
                this.settingsSchoolTextbox.Enabled = true;
                this.settingsEditButton.Text = "Ακύρωση";
                
            } else
            {
                ConfigForm configForm = new ConfigForm("Είστε σίγουρος ότι θέλετε να επιβεβαιώσετε την ακύρωση της επεξεργασίας; \nΌλες οι αλλαγές σας θα χαθούν.", "Ακύρωση", "Επιβεβαίωση", Color.Red, "Κλείσιμο");
                if (configForm.ShowDialog(this) == DialogResult.OK)
                {
                    this.settingsUsernameTextbox.Enabled = false;
                    this.settingsEmailTextbox.Enabled = false;
                    this.settingsFirstnameTextbox.Enabled = false;
                    this.settingsLastnameTextbox.Enabled = false;
                    this.settingsGenderRadioButton1.Enabled = false;
                    this.settingsGenderRadioButton2.Enabled = false;
                    this.settingsBirthTextBox.Enabled = false;
                    this.settingsConfButton.Enabled = false;
                    this.settingsSchoolTextbox.Enabled = false;
                    this.settingsEditButton.Text = "Επεξεργασία";
                }
                configForm.Dispose();

            }
        }

        private void personalButton_Click(object sender, EventArgs e)
        {
            if(!this.personalPanel.Visible)
            {
                this.personalPanel.Visible= true;
                this.systemPanel.Visible = false;
            }
        }

        private void systemButton_Click(object sender, EventArgs e)
        {
            if(!this.systemPanel.Visible)
            {
                this.personalPanel.Visible = false;
                this.systemPanel.Visible = true;
            }
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            this.OSLabel.Text = System.Environment.OSVersion.ToString();
            this.dateLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.settingsUsernameTextbox.Text = this.user.ElementAt(0);
            this.settingsEmailTextbox.Text = this.user.ElementAt(4);
            this.settingsLastnameTextbox.Text = this.user.ElementAt(2);
            this.settingsFirstnameTextbox.Text = this.user.ElementAt(3);
            this.settingsBirthTextBox.Text = this.user.ElementAt(6);
            this.settingsSchoolTextbox.Text = this.user.ElementAt(7);
            if (user.ElementAt(5).Equals("Άντρας"))
                settingsGenderRadioButton1.Checked = true;
            else
                settingsGenderRadioButton2.Checked = true;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void settingsConfButton_Click(object sender, EventArgs e)
        {
            ConfigForm conf = new ConfigForm("Είστει σίγουρος ότι θέλετε να πραγματοποιήσετε τις αλλαγές;\nΑυτό το βήμα είναι οριστικό.", "Ακύρωση", "Επιβεβαίωση", Color.LimeGreen, "Επεξεργασία Προσωπικών Στοιχείων");
            
            if(conf.ShowDialog(this) == DialogResult.OK)
            {
                if (settingsEmailTextbox.Text.Contains("@"))
                {
                    if (settingsEmailTextbox.Text.Contains("."))
                    {
                        List<string> listUpdatedUser = new List<string>();
                        listUpdatedUser.Add(this.user.ElementAt(0));
                        listUpdatedUser.Add(this.user.ElementAt(1));
                        listUpdatedUser.Add(settingsLastnameTextbox.Text);
                        listUpdatedUser.Add(settingsFirstnameTextbox.Text);
                        listUpdatedUser.Add(settingsEmailTextbox.Text);
                        if (settingsGenderRadioButton1.Checked == true)
                            listUpdatedUser.Add("Άντρας");
                        else
                            listUpdatedUser.Add("Γυναίκα");
                        listUpdatedUser.Add(settingsBirthTextBox.Text);
                        listUpdatedUser.Add(settingsSchoolTextbox.Text);
                        father.setUser(listUpdatedUser);

                        int i = db.uUser(listUpdatedUser.ElementAt(0), listUpdatedUser.ElementAt(2), listUpdatedUser.ElementAt(3), listUpdatedUser.ElementAt(4), listUpdatedUser.ElementAt(7), listUpdatedUser.ElementAt(5), listUpdatedUser.ElementAt(6));
                        if (i == 1)
                        {
                            this.settingsEmailTextbox.Enabled = false;
                            this.settingsFirstnameTextbox.Enabled = false;
                            this.settingsLastnameTextbox.Enabled = false;
                            this.settingsGenderRadioButton1.Enabled = false;
                            this.settingsGenderRadioButton2.Enabled = false;
                            this.settingsBirthTextBox.Enabled = false;
                            this.settingsConfButton.Enabled = false;
                            this.settingsSchoolTextbox.Enabled = false;
                            this.settingsEditButton.Text = "Επεξεργασία";
                            MessageBox.Show("Τα στοιχεία σας ενημερώθηκαν με επιτυχία!");
                        }
                        else
                            MessageBox.Show("Κάτι πήγε στραβά!! :(");
                    }
                }
                else
                {
                    MessageBox.Show("Παρακαλούμε δώστε ενα έγκυρο email όπως example@gmail.com");
                }
            }
            
            
        }
    }
}
