using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Threading;

namespace Multiple_Choice_Generator
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginConfigButton_Click(object sender, EventArgs e)
        {
            loginFunction();           
        }

        //CODE LINKLABEL FOR NAVIGATE TO SIGNUP URL
        private void LoginSignupLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://users.it.teithe.gr/~it154453/exam-generator-website1/register.php");   //navigate to URL
        }

        //disable maximazied
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            try
            {

            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("There was an error." +
                    "Check the path to the bitmap.");
            }
        }

        public void RotateWheelEvent(object sender, EventArgs args)
        {

        }
            //show password
            private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            this.loginPasswordTextbox.PasswordChar = '\0';
        }

        //hidepassword
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            this.loginPasswordTextbox.PasswordChar = '*';
        }

        //go to social website
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox social = (PictureBox)sender;

            if(social.Name.Equals("facebookPictureBox"))
                System.Diagnostics.Process.Start("https://www.facebook.com");   //navigate to URL
            else if(social.Name.Equals("twitterPictureBox"))
                System.Diagnostics.Process.Start("https://www.twitter.com");   //navigate to URL
            else if(social.Name.Equals("linkedinPictureBox"))
                System.Diagnostics.Process.Start("https://www.linkedin.com");   //navigate to URL

        }

        //social media mouse enter
        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox social = (PictureBox)sender;

            social.Size = new Size(47,47);  //change size
        }

        //grow up social media icons when hover
        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox social = (PictureBox)sender;

            social.Size = new Size(45,45);  //change size
        }

        //send email with password
        private void label1_Click(object sender, EventArgs e)
        {
            database db = new database();
            List<string> sendMail = new List<string>();
            sendMail = db.qUserEmail(loginUsernameTextbox.Text);
            if (!this.loginUsernameTextbox.Text.Equals(""))
            {
                if (sendMail == null)
                    MessageBox.Show("Δεν βρέθηκε χρήστης με το όνομα " + this.loginUsernameTextbox.Text + "!");
                else
                {
                    try
                    {
                        MailMessage message = new MailMessage();
                        SmtpClient smtp = new SmtpClient();

                        message.From = new MailAddress("multiple.choice.exam.generator@gmail.com");
                        message.IsBodyHtml = true;
                        message.To.Add(new MailAddress(sendMail.ElementAt(0)));
                        message.Subject = "noreply - Υπενθύμιση κωδικού πρόσβασης - Multiple Choice Exam Generator";
                        if(sendMail.ElementAt(3).Equals("Άντρας"))
                            message.Body = "<div><div style=\"background-color:#2196F3; text-align: center; font-family: sans-serif; padding:20px;\">" +
                                               "<img src=\"https://users.it.teithe.gr/~it154551/exam-generator-website1/logo.png\">" +
                                               "<h3 style=\"color: white\">Αγαπητέ κύριε " + sendMail.ElementAt(2) + "</h3>" +
                                               "<p style=\"color: white; line-height: 1.3em\">Ο κωδικός πρόσβασης σας για την εφαρμογή <br> " +
                                               "<a style=\"color: white\" href=\"https://users.it.teithe.gr/~it154551/exam-generator-website1/\">Multiple Choice Exam Generator</a>" +
                                               " είναι <span style=\"display:block; font-weight: bold; margin: 10px; font-size:1.5em\">" + sendMail.ElementAt(1) +
                                               "</p></div>" +
                                               "<div style=\"background-color: #eee; padding: 10px; font-family: sans-serif; color: #333; font-size: .8em; text-align: center\">" +
                                               "<p style=\"margin: 0\">Παρακαλούμε να μην απαντήσετε σε αυτό το email, καθώς δεν παρακολουθείται</p>" +
                                               "</div></div>";
                        //message.Body = "<h3>Αγαπητέ κύριε " + sendMail.ElementAt(2) + " ο κωδικός σας πρόσβασης για την εφαρμογή <a href=\"https://users.it.teithe.gr/~it154551/exam-generator-website1/\">Multiple Choise Exam Generator</a> είναι </h3><h2 style=\"color: red;\"><b>" + sendMail.ElementAt(1) + "</b></h2><h3> <br>Παρακαλούμε μην απαντήσετε σε αυτο το mail. Ευχαριστούμε!!!</h3>";
                        else
                            message.Body = "<div><div style=\"background-color:#2196F3; text-align: center; font-family: sans-serif; padding:20px;\">" +
                                               "<img src=\"https://users.it.teithe.gr/~it154551/exam-generator-website1/logo.png\">" +
                                               "<h3 style=\"color: white\">Αγαπητέ κυρία " + sendMail.ElementAt(2) + "</h3>" +
                                               "<p style=\"color: white; line-height: 1.3em\">Ο κωδικός πρόσβασης σας για την εφαρμογή <br> " +
                                               "<a style=\"color: white\" href=\"https://users.it.teithe.gr/~it154551/exam-generator-website1/\">Multiple Choice Exam Generator</a>" +
                                               " είναι <span style=\"display:block; font-weight: bold; margin: 10px; font-size:1.5em\">" + sendMail.ElementAt(1) +
                                               "</p></div>" +
                                               "<div style=\"background-color: #eee; padding: 10px; font-family: sans-serif; color: #333; font-size: .8em; text-align: center\">" +
                                               "<p style=\"margin: 0\">Παρακαλούμε να μην απαντήσετε σε αυτό το email, καθώς δεν παρακολουθείται</p>" +
                                               "</div></div>";
                        //message.Body = "<h3>Αγαπητή κυρία " + sendMail.ElementAt(2) + " ο κωδικός σας πρόσβασης για την εφαρμογή <a href=\"https://users.it.teithe.gr/~itit154551/exam-generator-website1/\">Multiple Choise Exam Generator</a> είναι </h3><h2 style=\"color: red;\"><b>" + sendMail.ElementAt(1) + "</b></h2><h3> <br>Παρακαλούμε μην απαντήσετε σε αυτο το mail. Ευχαριστούμε!!!</h3>";
                        smtp.Port = 587;
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("multiple.choice.exam.generator@gmail.com", "dream-team");
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(message);
                        
                        MessageBox.Show("Ο κωδικός σας στάλθηκε στο email σας!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("err: " + ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("Δεν δώσατε όνομα χρήστη στο πεδίο!");
        }

        //login with press enter
        private void loginUsernameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                loginFunction();
            }
        }

        //login
        private void loginFunction()
        {
            errorLabel.Text = "";   //delete errors in label
            String username = this.loginUsernameTextbox.Text;
            String password = this.loginPasswordTextbox.Text;

            if (String.IsNullOrEmpty(username) || String.IsNullOrWhiteSpace(username) || String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password))
            {
                //error in login cause blank fields
                errorLabel.Text = "Συμπληρώστε τα απαιτούμενα πεδία και ξαναπροσπαθήστε.";
            }
            else
            {
                //send to database
                database db = new database();
                List<string> list = new List<string>();
                list = db.login(username, password);
                if (list == null)
                    errorLabel.Text = "Λάθος κωδικός ή όνομα χρήστη. Προσπαθήστε ξανά.";
                else
                {
                    Form1 main = new Form1(list);
                    main.Show();
                    this.Hide();
                }
            }
        }

        //show password button
        private void loginPasswordTextbox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.loginPasswordTextbox.Text) || String.IsNullOrEmpty(this.loginPasswordTextbox.Text))
                this.showPasswordPictureBox.Visible = false;
            else
                this.showPasswordPictureBox.Visible = true;
        }

    }
}
