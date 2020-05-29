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
    public partial class EditQuestionForm : Form
    {
        //fields
        private String user;
        private String question;
        private String lesson;
        private String unit;
        private String diff;
        private List<string> answers;
        private int rows;
        private Form1 father;
        private database db = new database();

        public EditQuestionForm(String user, String question, String lesson, String unit, String diff, Form1 father)
        {
            InitializeComponent();

            this.user = user;
            this.question = question;
            this.lesson = lesson;
            this.unit = unit;
            this.diff = diff;
            this.father = father;
        }

        //load form
        private void EditQuestionForm_Load(object sender, EventArgs e)
        {
            //values to textboxes
            this.setTitle();
            this.questionTextbox.Text = this.question;
            this.lessonTextbox.Text = this.lesson;

            //diff level set
            if (this.diff.Equals("Εύκολη"))            
                this.diffRadioButton1.Select();
            else if (this.diff.Equals("Μέτρια"))            
                this.diffRadioButton2.Select();            
            else            
                this.diffRadioButton3.Select();

            //get units
            List<string> units = db.qUnits(user, lesson);

            foreach(String unit in units)
            {
                this.unitsComboBox.Items.Add(unit);

                if (unit.Equals(this.unit))
                    this.unitsComboBox.SelectedIndex = this.unitsComboBox.Items.Count - 1;
            }
            
            


            //load answers
            answers = db.qAnswers(question, unit, user, lesson);

            this.editQuestionsDataGridView.Rows.Clear();
            
            foreach(String answer in answers)
            {
                this.editQuestionsDataGridView.Rows.Add(answer);
            }

            //load rows
            rows = this.answers.Count;

            if (rows == 6)
                this.editQuestionsDataGridView.AllowUserToAddRows = false;

            

        }

        //set title of form the start of question, if question too bigger than 100 char then cut it
        public void setTitle()
        {
            this.Text += " - ";

            int count = this.question.Length;            

            if (count > 100)
            {
                for (int i = 0; i < 100; i++)
                    this.Text += question[i];

                this.Text += "...";
            }
            else
            {
                for (int i = 0; i < question.Length; i++)
                    this.Text += question[i];
            }
        }

        //delete question
        private void deleteQuestionButton_Click(object sender, EventArgs e)
        {
            ConfigForm conf = new ConfigForm("Είστε σίγουρος ότι θέλετε να διαγράψετε αυτή την ερώτηση;\nΑυτό το βήμα είναι ορισικό και δεν υπάρχει δυνατότητα επαναφοράς!", "Ακύρωση", "Διαγραφή", Color.Red, "Διαγραφή Ερώτησης");
            if (conf.ShowDialog(this) == DialogResult.OK)
            {
                int check = db.dQuestion(user, lesson, unit, question); //delete question and check status

                if(check != 1)
                {
                    errorsLabel.Text = "Υπήρξε κάποιο πρόβλημα με την διαγραφή ερώτησης!";
                    errorsLabel.Visible = true;
                    errorTittleLabel.Visible = true;
                }
                else
                {
                    //load questions again
                    father.loadQuestions();

                    this.Close();
                    this.Dispose();
                }
            }
            conf.Dispose();
        }

        //cancel button
        private void cancelButton_Click(object sender, EventArgs e)
        {
            ConfigForm conf = new ConfigForm("Θέλετε να ακυρώσετε την επεξεργασία;\nΟποιαδίποτε αλλαγή πραγματοποιήσατε θα χαθεί!", "Οχι", "Ναι", Color.OrangeRed, "Ακύρωση Επεξεργασίας Ερώτησης");
            if (conf.ShowDialog(this) == DialogResult.OK)
            {
                this.Close();
                this.Dispose();
            }
            conf.Dispose();
        }

        //ok button
        private void okButton_Click(object sender, EventArgs e)
        {
            //error0 = less than 2 questions
            //error1 = empty answer
            //error2 = empty title
            bool[] errors = {false, false, false, false};

            this.clearErrors();

            ConfigForm conf = new ConfigForm("Είστε σίγουρος ότι θέλετε να επιβεβαιώσετε τις αλλαγές σας;\nΟι αλλαγές θα είναι οριστικές!", "Ακύρωση", "Επιβεβαίωση", Color.LimeGreen, "Επιβεβαίωση Επεξεργασίας Ερώτησης");
            if (conf.ShowDialog(this) == DialogResult.OK)
            {
                int check = 0;  //status check from db

                //get number of new answers
                int numberCount = this.editQuestionsDataGridView.Rows.Count;
                int delCount = 0;

                //check if answers are >2
                for(int i=0; i<numberCount-1; i++)
                {
                    //get answer go to delete
                    bool flag = false;
                    try
                    {
                        flag = (bool)this.editQuestionsDataGridView.Rows[i].Cells[1].Value;
                    }
                    catch   //it was null
                    { }

                    if (flag)
                    {
                        delCount++;
                    }
                }

                if (this.editQuestionsDataGridView.Rows.Count - 1 - delCount < 2)
                    errors[0] = true;

                //check if there is empty answer
                for(int i=0; i<this.editQuestionsDataGridView.Rows.Count-1; i++)
                {
                    String temptxt = this.editQuestionsDataGridView.Rows[i].Cells[0].Value.ToString();
                    if (String.IsNullOrEmpty(temptxt) || String.IsNullOrWhiteSpace(temptxt))
                    {
                        errors[1] = true;
                    }
                }

                //check if there is empty title question
                if (String.IsNullOrEmpty(this.questionTextbox.Text) || String.IsNullOrWhiteSpace(this.questionTextbox.Text))
                    errors[2] = true;

                //checkif there are errors
                bool errorFlag = false;

                foreach(bool f in errors)
                {
                    if (f)
                    {
                        errorFlag = true;
                    }
                }

                if (!errorFlag)
                {
                    List<string> newAnswers = new List<string>();
                    int newAnswersCount = this.editQuestionsDataGridView.Rows.Count;

                    //get answers

                        for (int i = 0; i < this.editQuestionsDataGridView.Rows.Count - 1; i++)
                        {
                        bool tempFlag = Convert.ToBoolean(this.editQuestionsDataGridView.Rows[i].Cells[1].Value);
                            if(!(tempFlag))
                                newAnswers.Add(this.editQuestionsDataGridView.Rows[i].Cells[0].Value.ToString());
                        }

                        
                    

                    

                    //check if answers are same
                    foreach(String obj in newAnswers)
                    {
                        foreach(String obj2 in newAnswers)
                        {
                            if (obj.Equals(obj2) && !obj.Equals("") && obj != obj2)
                                errors[3] = true;
                        }
                    }

                    if (errors[3])  //there are errors
                    {
                        this.errorsLabel.Text += "Δε μπορείτε να καταχορήσετε ίδιες ερωτήσεις.";
                        this.errorsLabel.Visible = true;
                        this.errorTittleLabel.Visible = true;
                    }
                    else    //everythinkg okey go to database
                    {
                        int diffLevel;
                        //take diff
                        if (this.diffRadioButton1.Checked)
                            diffLevel = 1;
                        else if (this.diffRadioButton2.Checked)
                            diffLevel = 2;
                        else
                            diffLevel = 3;

                        //new count of answer
                        if(newAnswers.Count < this.answers.Count)
                        {
                            int x = this.answers.Count - newAnswers.Count;
                            for (int i = 0; i < x; i++)
                            {
                                db.dAnswer(this.user, this.lesson, this.unit, this.question, this.answers.ElementAt(0));
                                this.answers.RemoveAt(0);
                            }
                        }else if(newAnswers.Count > this.answers.Count)
                        {
                            int x = newAnswers.Count - this.answers.Count;
                            for (int i = 0; i < x; i++)
                            {
                                this.answers.Add("new temp answer" + i);
                                db.iAnswer(this.user, this.lesson, this.unit, this.question, "new temp answer" + i);
                            }
                        }                        


                        if (!this.question.Equals(this.questionTextbox.Text))
                        {
                            //check question rename
                            check = db.uQuestion(user, lesson, this.unitsComboBox.Text, this.unit, this.questionTextbox.Text, this.question, diffLevel, newAnswers, this.answers);                            
                        }
                        else
                        {
                            check = db.uQuestionWithoutName(user, lesson, this.unitsComboBox.Text, this.unit, this.question, diffLevel, newAnswers, this.answers);
                        }

                        if (check == 1)
                        {
                            father.loadQuestions();
                            MessageBox.Show("Η επεξεργασία ερώτησης ήταν επιτυχής");
                            this.Close();
                            this.Dispose();
                        }
                        else
                        {
                            this.errorsLabel.Text += "Κάτι πήγε στραβά στην επεξεργασία ερώτησης, δοκιμάστε ξανά";
                            this.errorsLabel.Visible = true;
                            this.errorTittleLabel.Visible = true;
                        }

                    }
                        
                }
                else
                {
                    if (errors[0])
                        this.errorsLabel.Text += "Δε μπορείτε να καταχορήσετε λιγότερες από 2 ερωτήσεις";
                    if (errors[1])
                        this.errorsLabel.Text += "Δε μπορείτε να καταχορήσετε κενή απάντηση";
                    if (errors[2])
                        this.errorsLabel.Text += "Δε μπορείτε να καταχορήσετε κενό τίτλο ερώτησης.";

                    this.errorsLabel.Visible = true;
                    this.errorTittleLabel.Visible = true;
                }
            }
            conf.Dispose();
        }

        public void clearErrors()
        {
            this.errorsLabel.Visible = false;
            this.errorTittleLabel.Visible = false;
            this.errorsLabel.Text = "";
        }

        private void editQuestionsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Font strikout = new System.Drawing.Font("Verdana", 12F, (System.Drawing.FontStyle.Regular | System.Drawing.FontStyle.Strikeout), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            Font normal = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));

            //strickout or not
            if (e.ColumnIndex == 1)
            {
                //check if checkbox is checked or not
                bool flag = false;
                try
                {
                    flag = (bool)this.editQuestionsDataGridView.Rows[e.RowIndex].Cells[1].Value;
                }
                catch
                { }

                if (flag)
                {
                    this.editQuestionsDataGridView.Rows[e.RowIndex].Cells[1].Value = false;
                    this.editQuestionsDataGridView.Rows[e.RowIndex].Cells[0].Style.Font = normal;
                }
                else
                {
                    this.editQuestionsDataGridView.Rows[e.RowIndex].Cells[1].Value = true;
                    this.editQuestionsDataGridView.Rows[e.RowIndex].Cells[0].Style.Font = strikout;
                }
            }
        }

        //add row
        private void editQuestionsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            rows++;
        }

        //check if rows are 6 then disable addrow
        private void editQuestionsDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (rows >= 6 && this.editQuestionsDataGridView.AllowUserToAddRows)
                this.editQuestionsDataGridView.AllowUserToAddRows = false;
        }
    }
}
