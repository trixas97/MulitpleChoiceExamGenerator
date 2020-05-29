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
    public partial class ShowQuestionForm : Form
    {
        //fields
        private String question;
        private String lesson;
        private String unit;
        private String diff;
        private String user;
        private database db = new database();


        public ShowQuestionForm(String question, String lesson, String unit, String diff, String user)
        {
            InitializeComponent();
            this.question = question;
            this.lesson = lesson;
            this.unit = unit;
            this.diff = diff;
            this.user = user;
        }
        
        private void ShowQuestionForm_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;   //set maximized button disable            

            this.questionTextbox.Text = this.question;    //set question Textbox
            this.lessonLabel.Text = this.lesson;    //set lessons


            this.unitLabel.Text = this.unit;        //set unit
            this.diffLabel.Text = this.diff;        //set diff level

            //get answers
            List<string> answers = new List<string>();
            answers = db.qAnswers(question, unit, user, lesson);
            //answers.Add("Πρώτη απάντηση");
            //answers.Add("Δεύτερη απάντηση");
            //answers.Add("Τρίτη απάντηση");

            //fill answers to datagridview
            int i = 0;
            try
            {
                foreach (String ans in answers)
                {
                    this.showAnswersDataGridView.Rows.Add();
                    this.showAnswersDataGridView.Rows[i].SetValues(ans);
                    i++;
                    this.showAnswersPanel.Height = this.showAnswersDataGridView.Rows[0].Height * this.showAnswersDataGridView.Rows.Count;   //set datagridview height
                }
            }
            catch
            {
                Console.Write("error on fill answers");
            }
        
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
