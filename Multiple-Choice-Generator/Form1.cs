/*Ο κώδικας είναι οργανωμένος κατά ενότητες. Κάθε ενότητα χωρίζεται ξεκινάει με τον τίτλο της σε σχόλιο και "-----" στην επόμενη γραμμή.
 * Κάθε μέθοδος έχει μια σύντομη περίληψη στην ακριβώς πάνω γραμμή σαν σχόλιο.
   Επίσης υπάρχουν επιπλέον βοηθητικά σχόλια*/


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Multiple_Choice_Generator.Properties;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using System.IO;
using Rectangle = System.Drawing.Rectangle;

namespace Multiple_Choice_Generator
{
    public partial class Form1 : Form
    {
        database db = new database();

        //lists from database
        private List<string> user = new List<string>();
        private List<string> lessons = new List<string>();
        private List<string> categories = new List<string>();
        private List<string> questions = new List<string>();
        private List<string> tests = new List<string>();

        //object for Utils
        Utils myutils = new Utils();


        public Form1(List<string> a)
        {
            InitializeComponent();
            user = a;
            this.DoubleBuffered = true; //fix gradiend resize problem
            temp = this.showTestsPanel;
        }

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true; //fix gradiend resize problem
            temp = this.showTestsPanel;
        }

        Panel temp; //which of main panels is visible now

        //Array for newsLabel text
        String[] newsArr = {"Για οποιαδίποτε απορία ή πρόβλημα επικοινωνήστε μαζί μας στο email example@gmail.com",
            "Για οποιαδίποτε πληροφορία συμβουλευτείτε τον οδηγό. Θα τον βρείτε κάτω αριστερά.",
            "Multiple Choice Generator, η καλύτερη πλατφόρμα για δημιουργία, αποθήκευση και οργάνωση ερωτήσεων και διαγωνισμάτων πολλαπλής επιλογής.",
            "Μπορείτε να πραγματοποιήσετε αλλαγές στην εμφάνιση του συστήματος από τις ρυθμίσεις.",
            "Μπορείτε να κάνετε αλλαγές στα προσωπικά σας στοιχεία από τις ρυθμίσεις."};
        



        //LOAD FORM1 AND DO SOME THINGS IN THE START OF APP
        //-----------------------------------------------------------------------
        int mov;
        int movX;
        int movY;
        //load my screen and workingarea location
        private void Form1_Load(object sender, EventArgs e)
        {
            //load my screen and workingarea location
            this.Location = Screen.AllScreens[0].WorkingArea.Location;

            //button ellipes
            System.Drawing.Drawing2D.GraphicsPath ellipseRadius = new System.Drawing.Drawing2D.GraphicsPath();
            ellipseRadius.StartFigure();
            ellipseRadius.AddArc(new Rectangle(0, 0, 20, 20), 180, 90);
            ellipseRadius.AddLine(20, 0, createQuestionConfigButton.Width - 20, 0);
            ellipseRadius.AddArc(new Rectangle(createQuestionConfigButton.Width - 20, 0, 20, 20), -90, 90);
            ellipseRadius.AddLine(createQuestionConfigButton.Width, 20, createQuestionConfigButton.Width, createQuestionConfigButton.Height - 20);
            ellipseRadius.AddArc(new Rectangle(createQuestionConfigButton.Width - 20, createQuestionConfigButton.Height - 20, 20, 20), 0, 90);
            ellipseRadius.AddLine(createQuestionConfigButton.Width - 20, createQuestionConfigButton.Height, 20, createQuestionConfigButton.Height);
            ellipseRadius.AddArc(new Rectangle(0, createQuestionConfigButton.Height - 20, 20, 20), 90, 90);
            ellipseRadius.CloseFigure();
            createQuestionConfigButton.Region = new Region(ellipseRadius);

            //leftmenu news bar
            this.newsLabel.Text = newsArr[0];
            this.newsTimer.Start();
            
            
            this.loadLessons(); //call loadLessons            


            //declare teamViewQuestion array of list
            this.tempViewQuestions[0] = new List<string>();
            this.tempViewQuestions[1] = new List<string>();
            this.tempViewQuestions[2] = new List<string>();
            this.tempViewQuestions[3] = new List<string>();

            //declare teamViewQuestion array of list
            this.tempViewQuestionsEQ[0] = new List<string>();
            this.tempViewQuestionsEQ[1] = new List<string>();
            this.tempViewQuestionsEQ[2] = new List<string>();
            this.tempViewQuestionsEQ[3] = new List<string>();

            //user to label
            this.userLabel.Text += this.user.ElementAt(0);
        }

        public void setUser(List<string> listUser)
        {
            this.user = listUser;
        }

        //LOAD LESSONS FROM DATABASE AND FILL COMBOBOXES
        public void loadLessons()
        {
            //load lessons     
            try
            {
                this.lessons = myutils.loadlessons(user.ElementAt(0));
            }
            catch
            {
                //no lessons
            }
            

            this.createAutoTestLessonComboBox.Items.Clear();
            this.createQuestionLessonCombobox.Items.Clear();
            this.createManualTestComboBox.Items.Clear();
            this.showQuestionLessonCombobox.Items.Clear();
            this.editQuestionLessonsCombobox.Items.Clear();
            this.showTestsLessonComboBox.Items.Clear();
            try
            {
                foreach (String lesson in this.lessons)
                {
                    this.createAutoTestLessonComboBox.Items.Add(lesson);
                    this.createQuestionLessonCombobox.Items.Add(lesson);
                    this.createManualTestComboBox.Items.Add(lesson);
                    this.showQuestionLessonCombobox.Items.Add(lesson);
                    this.editQuestionLessonsCombobox.Items.Add(lesson);
                    this.showTestsLessonComboBox.Items.Add(lesson);
                }
            }
            catch
            {
                Console.Write("No lessons");
            }
           
            //delete datagridviews data
            this.showQuestionDataGridView.Rows.Clear();
            this.editLessonsDataGridView.Rows.Clear();
            this.editQuestionGridView.Rows.Clear();
            this.createManualTestDataGridView.Rows.Clear();


            this.fillLessonDataGridView(this.editLessonsDataGridView, this.lessons);
        }

        public void fillTestDataGridView(String lesson)
        {
            this.tests = db.qTest(user.ElementAt(0), lesson);
            this.showTestsDataGridView.Rows.Clear();

            //check if tests are not empty or empty
            if((this.tests != null) && (this.tests.Any()))
            {
                for (int i = 0; i < this.tests.Count; i++)
                {
                    this.showTestsDataGridView.Rows.Add();
                    this.showTestsDataGridView.Rows[i].Cells[0].Value = this.tests.ElementAt(i);;
                }
            }
                
           

            
        }



        //EXIT APLLICATION WHEN THIS FORM CLOSE
        //-----------------------------------------------------------------------
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        //SELECTED THEME COLORS
        //-----------------------------------------------------------------------
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            leftmenuP.BackColor = (Color)Settings.Default["BackColor"];
            topmenuP.BackColor = (Color)Settings.Default["BackColor"];
            showQuestionsFilterButton.BackColor = (Color)Settings.Default["Filters"];
            showQuestionsFilterPanel.BackColor = (Color)Settings.Default["Filters"];
            createQuestionConfigButton.BackColor = (Color)Settings.Default["ButtonColor1"];
            questionsB.BackColor = (Color)Settings.Default["ButtonColor1"];
            testB.BackColor = (Color)Settings.Default["ButtonColor1"];

            //topmenu
            createL.BackColor = (Color)Settings.Default["BackColor"];
            createQuestionL.BackColor = (Color)Settings.Default["BackColor"];
            createLessonL.BackColor = (Color)Settings.Default["BackColor"];
            createTestL.BackColor = (Color)Settings.Default["BackColor"];
            editL.BackColor = (Color)Settings.Default["BackColor"];
            editQuestionL.BackColor = (Color)Settings.Default["BackColor"];
            editLessonL.BackColor = (Color)Settings.Default["BackColor"];
            editTestL.BackColor = (Color)Settings.Default["BackColor"];

        }



        //SET FOCUS TO ITEMS WHEN THEY DON'T TAKE IT AUTOMATIC
        //-----------------------------------------------------------------------
        private void setfocus_Click(object sender, EventArgs e)
        {
            //we set focus to components only if a subMenu or filterPanel is open
            if (createSubMenuP.Height != 0 || editSubMenuP.Height != 0 || showQuestionsFilterPanel.Width != 0 || createManualTestFilterPanel.Width != 0)
            {
                if (sender.Equals(leftmenuP))
                    leftmenuP.Focus();
                else if (sender.Equals(topmenuP))
                    topmenuP.Focus();
                else if (sender.Equals(titleL))
                    titleL.Focus();
                else if (sender.Equals(createQuestionPanel))
                    createQuestionPanel.Focus();
                else if (sender.Equals(createManualTestPanel))
                    createManualTestPanel.Focus();
                else if (sender.Equals(createAutoTestPanel))
                    createAutoTestPanel.Focus();
                else if (sender.Equals(showQuestionsPanel))
                    showQuestionsPanel.Focus();
                else if (sender.Equals(createLessonPanel))
                    createLessonPanel.Focus();
                else if (sender.Equals(createTestPanel))
                    createTestPanel.Focus();
            }
        }


        #region CODE FOR MOVE FORM WITH DRAG AND BUTTON DESIGN
        
        //set movX and movY with mouse current possition when mouse is down
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        // set mov 0 to stop move the form when mouse is up
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        //while mouse is down (mov=1) when mouse move, move form
        //-10 and -31 because there is some problem with exatly possition
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
                this.SetDesktopLocation(MousePosition.X - movX-10, MousePosition.Y - movY - 31);
        }
        #endregion


        #region TOP MENU BAR EFFECTS

        bool createflag = false;
        bool editflag = false;
        //when left clicked pressed call timer
        private void topmenu_MouseClick(object sender, MouseEventArgs e)
        {
            Label temp = (Label)sender;
            temp.Focus();   //set focus to selected label
            //check if ckicked was left
            if (e.Button == MouseButtons.Left)
            {
                if (sender.Equals(createL))
                    timer1.Start();
                else if (sender.Equals(editL))
                    timer2.Start();
            }
        }

        //when it loose focus call timer to close submenu
        private void topmenu_Leave(object sender, EventArgs e)
        {
            Label temp = (Label)sender;
            if (createflag)
                timer1.Start();
            else if (editflag)
                timer2.Start();
        }

        //effect for create submenu (createSubMenuP)
        private void createSubMenuTimer(object sender, EventArgs e)
        {
            //if dropdown menu is open then close
            if(createflag)
            {
                createSubMenuP.Height -= 21;
                if (createSubMenuP.Height == 0)
                {
                    timer1.Stop();
                    createflag = false;
                    //return to blue background, we put the code here because it happend after close dropdown effect
                    createL.BackColor = (Color)Settings.Default["BackColor"];
                    createL.ForeColor = Color.White;
                }
            }
            //if dropdown menu is close then open
            else if(!createflag)
            {
                createSubMenuP.Height += 21;
                if(createSubMenuP.Height==105)
                {
                    timer1.Stop();
                    createflag = true;
                }
            }
        }

        //effect for edit submenu (editSubMenuP)
        private void editSubMenuTimer(object sender, EventArgs e)
        {
            //if dropdown menu is open then close
            if (editflag)
            {
                editSubMenuP.Height -= 21;
                if (editSubMenuP.Height == 0)
                {
                    timer2.Stop();
                    editflag = false;
                    //return to blue background, we put the code here because it happend after close dropdown effect
                    editL.BackColor = (Color)Settings.Default["BackColor"];
                    editL.ForeColor = Color.White;
                }
            }
            //if dropdown menu is close then open
            else if (!editflag)
            {
                editSubMenuP.Height += 21;
                if (editSubMenuP.Height == 63)
                {
                    timer2.Stop();
                    editflag = true;
                }
            }
        }

        //top menu, change font size when enter
        private void topmenu_MouseEnter(object sender, EventArgs e)
        {
            Label temp = (Label)sender;
                temp.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));            
        }

        //reset font when leave
        private void topmenu_MouseLeave(object sender, EventArgs e)
        {
            Label temp = (Label)sender;
            temp.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));            
        }

        //change color when click in top bar menu
        private void topmenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label temp = (Label)sender;
                temp.BackColor = Color.White;
                temp.ForeColor = Color.DodgerBlue;
            }
        }
     
        //placeholder for topbar search textbox and set text to empty when we enter
        private void searchTBPLaceholder_Enter(object sender, EventArgs e)
        {
            if(searchTB.Text.Equals("Search..."))
            searchTB.Text = "";
        }

        //reset placeholder on topbar menu when we leave and textbox is empty
        private void searchTBPlaceholder_Leave(object sender, EventArgs e)
        {
            if (searchTB.Text.Equals(""))
                searchTB.Text = "Search...";
        }
        #endregion


        #region CODE BUTTONS TO CALL FORMS

        //call logooutForm or focus
        private void logoutB_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm("Είστε σίγουρος ότι θέλετε να κλείσετε την εφαρμογή;", "Ακύρωση", "Κλείσιμο", Color.Red, "Κλείσιμο");
            if (configForm.ShowDialog(this) == DialogResult.OK)
            {
                Application.Exit();                
            }            
            configForm.Dispose();
        }


        //call settingsForm or set focus  
        private Form sett = null;
        public Form setterSett
        {
            //need this setter to sett=null from settingsForm
            set
            {
                sett = value;
            }
        }
        private void settingsB_Click(object sender, EventArgs e)
        {
            if (sett != null)
            {
                if (sett.WindowState == FormWindowState.Minimized)
                    sett.WindowState = FormWindowState.Normal;
                else
                    sett.Focus();
            }
            else
            {
                sett = new settingsForm(this, user);
                sett.Show();
            }
        }

        //open infoForm or focus
        private Form info = null;
        public Form setterinfo
        {
            //need this setter to info=null from infoForm
            set
            {
                info = value;
            }
        }
        private void helpB_Click(object sender, EventArgs e)
        {
            if (info != null)
            {
                if (info.WindowState == FormWindowState.Minimized)
                    info.WindowState = FormWindowState.Normal;
                else
                    info.Focus();
            }
            else
            {
                info = new infoForm(this);
                info.Show();
            }
        }

        #endregion


        #region CODE SUBMENUS BUTTONS AND OTHER BUTTONS TO CALL THEIR PANELS

        //call createqiestionPanel  and close submenu
        private void create_questionL_Click(object sender, EventArgs e)
        {
            temp.Visible = false;   //set current panel not visible
            createQuestionPanel.Visible = true; //set createQuestionPanel visible            
            temp = createQuestionPanel; //set new temp panel
            timer1.Start(); //close createSubMenuP
        }

        //call createLessonPanel and close submenu
        private void lessonL_Click(object sender, EventArgs e)
        {
            temp.Visible = false;   //set current panel not visible
            createLessonPanel.Visible = true;   //set createLessonPanel visible            
            temp = createLessonPanel; //set new temp panel
            timer1.Start(); //close createSubMenuP
        }

        //call createTestPanel and close submenu
        private void createTestL_Click(object sender, EventArgs e)
        {
            temp.Visible = false;
            createTestPanel.Visible = true;            
            temp = createTestPanel;
            timer1.Start(); //close createSubMenuP
        }

        //call editLessonPanel and close submenu
        private void editLessonL_Click(object sender, EventArgs e)
        {
            this.temp.Visible = false;
            this.editLessonsPanel.Visible = true;            
            temp = this.editLessonsPanel;

            timer2.Start(); //close editSubMenuP
        }

        //call editQuestionPanel and close submenu
        private void editQuestionL_Click(object sender, EventArgs e)
        {
            this.temp.Visible = false;
            this.editQuestionPanel.Visible = true;
            temp = this.editQuestionPanel;
            timer2.Start(); //close editSubMenuP
        }

        //call editTestPanel and close submenu
        private void editTestL_Click(object sender, EventArgs e)
        {
            timer2.Start(); //close editSubMenuP
        }

        //call showQuestionsPanel
        private void questionsB_Click(object sender, EventArgs e)
        {
            temp.Visible = false;
            showQuestionsPanel.Visible = true;
            temp = showQuestionsPanel;
        }
        
        //call createAutoTestPanel
        private void button1_Click(object sender, EventArgs e)
        {
            temp.Visible = false;
            createAutoTestPanel.Visible = true;
            temp = createAutoTestPanel;
        }

        //call createManualTestPanel
        private void button2_Click(object sender, EventArgs e)
        {
            createManualTestPanel.Visible = true;
            temp.Visible = false;
            temp = createManualTestPanel;
        }

        #endregion


        #region METHODS OF showQuestionsPanel        
        //code showQuestionsFilterConfButton
        int countRow = 0; //count for add questions to row (dld einai h seira poy 8a ginei add)
        private void showQuestionsFilterConfButton_Click(object sender, EventArgs e)
        {
            this.showQuestionErrorLabel.Visible = false;
            checkedUnits = myutils.getStringCheckedList(this.showQuestionCategoryCheckbox); //get checked items in string list
            checkedDifficulty = myutils.getStringCheckedList(this.showQuestionDifficultyCheckbox); //get checked items in int list     
            countRow = 0;

            this.showQuestionDataGridView.Rows.Clear(); //delete rows 

            //clear tempViewQuestions
            this.tempViewQuestions[0].Clear();
            this.tempViewQuestions[1].Clear();
            this.tempViewQuestions[2].Clear();
            this.tempViewQuestions[3].Clear();



            this.showQuestionsSearchTextbox.Text = ""; //delete search box text


            if (this.checkedUnits.Count != 0 && this.checkedDifficulty.Count != 0)    //both filters used
            {
                foreach (String checkedFieldU in this.checkedUnits)  //foreach element in checkedUnit list
                {
                    foreach (String checkedFieldD in this.checkedDifficulty)  //foreach element in checkedUnit list
                    {
                        String temp = "0";

                        if (checkedFieldD.Equals("Εύκολες"))
                            temp = "1";
                        else if (checkedFieldD.Equals("Μέτριες"))
                            temp = "2";
                        else if (checkedFieldD.Equals("Δύσκολες"))
                            temp = "3";

                        for (int i = 0; i < viewQuestions[0].Count; i++)    //for every question
                        {
                            if (viewQuestions[3].ElementAt(i).Equals(temp) && viewQuestions[2].ElementAt(i).Equals(checkedFieldU)) //if checkedField == unit   then...
                            {
                                addQuestionToDataGridView(this.viewQuestions, this.showQuestionDataGridView, countRow, i);    //call method to add question
                                countRow++;
                            }
                        }
                    }                   
                }
            }
            else //one of the filters used
            {
                if (this.checkedUnits.Count != 0)  //only unit filters
                {
                    foreach (String checkedField in this.checkedUnits)  //foreach element in checkedUnit list
                    {
                        for (int i = 0; i < viewQuestions[0].Count; i++)    //for every question
                        {
                            if (viewQuestions[2].ElementAt(i).Equals(checkedField))  //if checkedField == unit   then...
                            {
                                addQuestionToDataGridView(this.viewQuestions, this.showQuestionDataGridView, countRow, i);    //call method to add question
                                countRow++;
                            }
                        }
                    }
                } else if (this.checkedDifficulty.Count != 0)   //only difficulty filter
                {
                    foreach (String checkedField in this.checkedDifficulty)  //foreach element in checkedUnit list
                    {
                        String temp = "0";

                        if (checkedField.Equals("Εύκολες"))
                            temp = "1";
                        else if (checkedField.Equals("Μέτριες"))
                            temp = "2";
                        else if (checkedField.Equals("Δύσκολες"))
                            temp = "3";


                        for (int i = 0; i < viewQuestions[0].Count; i++)    //for every question
                        {
                            if (viewQuestions[3].ElementAt(i).Equals(temp)) //if checkedField == unit   then...
                            {                                
                                addQuestionToDataGridView(this.viewQuestions, this.showQuestionDataGridView, countRow, i);    //call method to add question
                                countRow++;
                            }
                        }
                    }
                } else  //no filters
                {
                    for (int i = 0; i < viewQuestions[0].Count; i++)    //for every question
                    {                            
                        addQuestionToDataGridView(this.viewQuestions, this.showQuestionDataGridView, i, i);    //call method to add question
                        countRow++;
                    }
                }
            }

            filtersButtonFlag = 'S';
            filtersTimer.Start();
        }


        //add question to the showQuestionDataGridView
        //η πρώτη μεταβλητή ειναι για το με ποια λιστα θα γεμισουμε το gridview, η δευτερη ειναι για το ποιο gridview θα γεμισουμε, η τρίτη είναι σε ποια σειρα βρισκόμαστε και η τεταρτη ειναι ποιο element θα παρουμε
        //χρησιμοποιούμε το tempViewQuestion για να κανει search τις φιλτραρισμένες ερωτήσεις
        public void addQuestionToDataGridView(List<string>[] list, DataGridView dgv, int count, int i)
        {
            try
            {
                dgv.Rows.Add();
                dgv.Rows[count].Cells[0].Value = list[0].ElementAt(i);
                dgv.Rows[count].Cells[1].Value = list[1].ElementAt(i);
                dgv.Rows[count].Cells[2].Value = list[2].ElementAt(i);
                switch (int.Parse(list[3].ElementAt(i)))
                {
                    case 1:
                        dgv.Rows[count].Cells[3].Value = "Εύκολη";
                        break;
                    case 2:
                        dgv.Rows[count].Cells[3].Value = "Μέτρια";
                        break;
                    case 3:
                        dgv.Rows[count].Cells[3].Value = "Δύσκολη";
                        break;
                }

                if (dgv.Name.Equals(this.showQuestionDataGridView.Name))
                {
                    if (!list.SequenceEqual(this.tempViewQuestions))
                    {
                        this.tempViewQuestions[0].Add(this.viewQuestions[0].ElementAt(i));
                        this.tempViewQuestions[1].Add(this.viewQuestions[1].ElementAt(i));
                        this.tempViewQuestions[2].Add(this.viewQuestions[2].ElementAt(i));
                        this.tempViewQuestions[3].Add(this.viewQuestions[3].ElementAt(i));
                    }
                }
                else if (dgv.Name.Equals(this.editQuestionGridView.Name))
                {
                    Console.WriteLine(dgv.Name.Equals(this.editQuestionGridViewPanel.Name));
                    if (!list.SequenceEqual(this.tempViewQuestionsEQ))
                    {
                        this.tempViewQuestionsEQ[0].Add(this.viewQuestionsEQ[0].ElementAt(i));
                        this.tempViewQuestionsEQ[1].Add(this.viewQuestionsEQ[1].ElementAt(i));
                        this.tempViewQuestionsEQ[2].Add(this.viewQuestionsEQ[2].ElementAt(i));
                        this.tempViewQuestionsEQ[3].Add(this.viewQuestionsEQ[3].ElementAt(i));
                    }
                }

               
            }
            catch
            {
            }
        }

        //close filter panel when pess comboboxx
        private void showQuestionLessonCombobox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.showQuestionsFilterPanel.Size.Width > 0)
            {
                filtersButtonFlag = 'S';
                filtersTimer.Start();
            }
        }


        //open filter panel of showQuestionPanel
        private void showQuestionsFilterButton_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            temp.BringToFront();
            this.showQuestionsFilterPanel.BringToFront();
            
            this.filtersButtonFlag = 'S';
            filtersTimer.Start();
        }

        //fill datagrid view and units for showQuestions
        List<string> checkedUnits = new List<string>(); //list with checked categoreis
        List<string> checkedDifficulty = new List<string>();  //list with cheked difficulty levels
        List<string>[] viewQuestions = new List<string>[4]; //list[] where will have the data of datagridview
        List<string>[] tempViewQuestions = new List<string>[4]; //list[] where will have the afterfilter questions  

        //fill datagrid view and units for 
        List<string> checkedUnitsEQ = new List<string>(); //list with checked categoreis
        List<string> checkedDifficultyEQ = new List<string>();  //list with cheked difficulty levels
        List<string>[] viewQuestionsEQ = new List<string>[4]; //list[] where will have the data of datagridview
        List<string>[] tempViewQuestionsEQ = new List<string>[4]; //list[] where will have the afterfilter questions  
        private void showQuestionLessonCombobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            CheckedListBox categorieschecklistbox = null;
            CheckedListBox diffchecklistbox = null;
            DataGridView dgv = null;
            Label errorLabel = null;
            TextBox searchbox = null;
            List<string> checkdunits = null;
            List<string> checkedDifficulty = null;
            List<string>[] viewQuestions = new List<string>[4];
            List<string>[] tempViewQuestions = new List<string>[4];

            if (combo.Name.Equals(this.showQuestionLessonCombobox.Name))    //show question
            {
                diffchecklistbox = this.showQuestionDifficultyCheckbox;
                dgv = this.showQuestionDataGridView;
                categorieschecklistbox = this.showQuestionCategoryCheckbox;
                errorLabel = this.showQuestionErrorLabel;
                checkdunits = this.checkedUnits;
                checkedDifficulty = this.checkedDifficulty;
                viewQuestions = this.viewQuestions;
                tempViewQuestions = this.tempViewQuestions;
                searchbox = this.showQuestionsSearchTextbox;
            }
            else if (combo.Name.Equals(this.editQuestionLessonsCombobox.Name))      //edit question
            {
                diffchecklistbox = this.editQuestionsDiffCheckListbox;
                dgv = this.editQuestionGridView;
                categorieschecklistbox = this.editQuestionsCategoryCheckListBox;
                errorLabel = this.editQuestionsErrorLabel;
                checkdunits = this.checkedUnitsEQ;
                checkedDifficulty = this.checkedDifficultyEQ;
                viewQuestions = this.viewQuestionsEQ;
                tempViewQuestions = this.tempViewQuestionsEQ;
                searchbox = this.editQuestionSearchTextbox;
            }

            //clear previus diff levels           
            foreach (int i in diffchecklistbox.CheckedIndices)
            {
                diffchecklistbox.SetItemCheckState(i, CheckState.Unchecked);
            }

            //load units on checkbox
            categorieschecklistbox.Items.Clear();    //clear previus units
            diffchecklistbox.SelectedItems.Clear();  //clear previus dif levels

            categories = myutils.loadcategories(user.ElementAt(0), combo.Text);

            try
            {
                foreach (String category in categories)
                {
                    categorieschecklistbox.Items.Add(category);      //add unit in checkbox
                }
            }
            catch
            {
                //no categories
            }
           

            dgv.Rows.Clear(); //remove all rows

            //an to viewQuestions einai null tote mh kaneis to for kai emfanisi minima oti de bre8ikan erwtiseis
            try
            {
                //call method to take questions
                viewQuestions = db.qQuestionsMore(user.ElementAt(0), combo.Text); //no filters                

                //save questions
                if (combo.Name.Equals(this.showQuestionLessonCombobox.Name))    //show question
                {
                    this.viewQuestions = viewQuestions;

                    for (int i = 0; i < 4; i++)
                        this.tempViewQuestions[i].Clear();

                    this.tempViewQuestions = tempViewQuestions;
                }
                else if (combo.Name.Equals(this.editQuestionLessonsCombobox.Name))      //edit question
                {
                    this.viewQuestionsEQ = viewQuestions;

                    for (int i = 0; i < 4; i++)
                        this.tempViewQuestionsEQ[i].Clear();

                    this.tempViewQuestionsEQ = tempViewQuestions;
                }

                //clear textbox
                searchbox.Text = "";

                for (int i = 0; i < viewQuestions[0].Count; i++)
                {
                    this.addQuestionToDataGridView(viewQuestions, dgv, i, i);
                }                
            }
            catch
            {
                errorLabel.Text = "Δεν υπάρχουν ερωτήσεις σε αυτό το μάθημα με αυτά τα φίλτρα. Προσπαθήστε ξανά.";
            }            
        }

        //call showQuestionLessonCombobox_SelectionChangeCommitted(object sender, EventArgs e) from edit question class
        public void loadQuestions()
        {
            this.showQuestionLessonCombobox_SelectionChangeCommitted(this.editQuestionLessonsCombobox, null);
            if(this.showQuestionLessonCombobox.Text.Equals(this.editQuestionLessonsCombobox.Text))
                this.showQuestionLessonCombobox_SelectionChangeCommitted(this.showQuestionLessonCombobox, null);
        }

        //search on questions
        private void showQuestionsSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            TextBox searchtextbox = (TextBox)sender;
            DataGridView dgv = null;
            List<string> checkdunits = null;
            List<string> checkedDifficulty = null;
            List<string>[] tempViewQuestions = new List<string>[4];

            if (searchtextbox.Name.Equals(this.showQuestionsSearchTextbox.Name))
            {
                dgv = this.showQuestionDataGridView;
                checkdunits = this.checkedUnits;
                checkedDifficulty = this.checkedDifficulty;
                tempViewQuestions = this.tempViewQuestions;
            }else if (searchtextbox.Name.Equals(this.editQuestionSearchTextbox.Name))
            {
                dgv = this.editQuestionGridView;
                checkdunits = this.checkedUnitsEQ;
                checkedDifficulty = this.checkedDifficultyEQ;
                tempViewQuestions = this.tempViewQuestionsEQ;
            }


            dgv.Rows.Clear(); //clear rows
            

            if (String.IsNullOrEmpty(searchtextbox.Text) || String.IsNullOrWhiteSpace(searchtextbox.Text))
            {
                for(int i=0; i<tempViewQuestions[0].Count; i++)
                {
                    this.addQuestionToDataGridView(tempViewQuestions, dgv, i, i);
                }
            }
            else   //search when textbox isn't empty or blank
            {
                List<string> newlist = myutils.searchTextBox(tempViewQuestions, searchtextbox.Text);//call method to return list with correct questions
                this.countRow = 0;

                for (int i = 0; i < tempViewQuestions[0].Count; i++)
                {
                    foreach (String obj2 in newlist)
                    {
                        if (obj2.Equals(tempViewQuestions[0].ElementAt(i)))
                        {
                            addQuestionToDataGridView(tempViewQuestions, dgv, countRow, i);
                            countRow++;
                        }
                    }
                }
            }
        }

        //open questionForm edit or show
        private void showQuestionDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            try
            {
                String questionCell = dgv[0, e.RowIndex].Value.ToString(); //take row's question
                String lessonCell = dgv[1, e.RowIndex].Value.ToString(); //take row's lesson
                String unitCell = dgv[2, e.RowIndex].Value.ToString(); //take row's unit
                String diffCell = dgv[3, e.RowIndex].Value.ToString(); //take row's diff level

                //open ShowQuestionForm
                if (dgv.Name.Equals(this.showQuestionDataGridView.Name))
                {
                    ShowQuestionForm question = new ShowQuestionForm(questionCell, lessonCell, unitCell, diffCell, user.ElementAt(0));
                    question.Show();
                }   else if (dgv.Name.Equals(this.editQuestionGridView.Name))
                {
                    EditQuestionForm question = new EditQuestionForm(user.ElementAt(0), questionCell, lessonCell, unitCell, diffCell, this);
                    question.Show();
                }
                    

            }
            catch
            {
                Console.Write("Πατήθηκε header");
            }
        }
        #endregion


        #region METHODS OF createQuestionPanel
        //set richTextBox test to webBrowser
        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = createQuestionRichTextBox.Text;
        }

        //number of max answers
        private static int maxAnswers = 4;  //max answers allowed-1, (ex if maxAnswers=4 then the real maxAnswers are 6 cause first 2 textboxes don't content in array)
        TextBox[] textboxes = new TextBox[maxAnswers];    //array with textboxes (first and second textboxes don't content in array) 
        int n = 0;        
        int textboxY; //last textbox height location
       // bool flagerrorsVisible = false;  //need this flag for corrext errors location

        //create textboxes when pess the button createTextBoxButton
        private void createTextBoxButton_Click(object sender, EventArgs e)
        {
            if (n < maxAnswers)
            {
                //get the locationY from last textBox
                if(n > 0)
                {
                    textboxY = textboxes[n-1].Location.Y;
                }
                else
                {
                    textboxY = createQuestionTextBox2.Location.Y;
                }

                //create textbox and set propeties
                textboxes[n] = new TextBox();
                this.createQuestionPanel.Controls.Add(textboxes[n]);
                this.textboxes[n].Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                this.textboxes[n].Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
                this.textboxes[n].Location = new System.Drawing.Point(createQuestionTextBox2.Location.X, textboxY+54);                 
                this.textboxes[n].Margin = new System.Windows.Forms.Padding(22, 3, 22, 3);
                this.textboxes[n].Multiline = true;
                this.textboxes[n].Name = "createQuestionTextBox" + (n+3);
                this.textboxes[n].ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                this.textboxes[n].Size = new System.Drawing.Size(createQuestionTextBox2.Size.Width, createQuestionTextBox2.Size.Height);
                this.textboxes[n].TabIndex = n + 9;

                this.createQuestionConfigButton.Location = new System.Drawing.Point(createQuestionConfigButton.Location.X, textboxY + 167); //move config button down              
                this.createTextboxPictureBox.Location = new System.Drawing.Point(createTextboxPictureBox.Location.X, textboxY + 108); //move add textbox button down
                this.deleteTextboxPictureBox.Location = new System.Drawing.Point(deleteTextboxPictureBox.Location.X, textboxY + 108); //move dellete textbox button down

                

                this.deleteTextboxPictureBox.Enabled = true; //set deleteTextBoxButton enable

                //enable deleteTextBoxButton if disable
                if (!this.deleteTextboxPictureBox.Enabled)
                    this.deleteTextboxPictureBox.Enabled = true;

                //disable createTextBoxButton if textBoxes == max answers
                if (n == maxAnswers - 1)
                    this.createTextboxPictureBox.Enabled = false;

                n++;                
            }            
        }       

        //delete textboxes when pressthe button deleteTextBoxButton
        private void deleteTextBoxButton_Click(object sender, EventArgs e)
        {
            if(n>0)
            {
                n--;
                textboxes[n].Visible = false;
                textboxes[n] = null;
                this.createQuestionConfigButton.Location = new System.Drawing.Point(createQuestionConfigButton.Location.X, createQuestionConfigButton.Location.Y-54); //move config button up
                this.createTextboxPictureBox.Location = new System.Drawing.Point(createTextboxPictureBox.Location.X, createTextboxPictureBox.Location.Y-54); //move add textbox button up               
                this.deleteTextboxPictureBox.Location = new System.Drawing.Point(deleteTextboxPictureBox.Location.X, deleteTextboxPictureBox.Location.Y-54); //move deleteTextButton up

               

                //enabe createTextBoxButton when delete 1 textbox if disable
                if (!this.createTextboxPictureBox.Enabled)
                    this.createTextboxPictureBox.Enabled = true;

                //disable add button to when you have 2 answers
                if (n == 0)
                {
                    this.deleteTextboxPictureBox.Enabled = false;
                }
            }            
        }

        //createQuestionConfigButton Code
        private void createQuestionConfigButton_Click(object sender, EventArgs e)
        {
            createQuestionPanel.Focus();    //set focus to panel so button not stay focus

            createQuestionErrorsLabel.Visible = false;
            label18.Visible = false;

            //get question's lesson
            String lesson = createQuestionLessonCombobox.Text;

            //get question's category
            String category = createQuestionCategoryCombobox.Text;

            //get question's difficulty
            int difficulty;
            if (createQuestionRadioButton1.Checked)
                difficulty = 1;
            else if (createQuestionRadioButton2.Checked)
                difficulty = 2;
            else
                difficulty = 3;

            //get question
            String question = createQuestionRichTextBox.Text;

            //get answers            
            String[] answers = new String[n+2];
            answers[0] = createQuestionTextBox1.Text;
            answers[1] = createQuestionTextBox2.Text;            
            for(int i=0; i<n; i++)
            {
                answers[i + 2] = textboxes[i].Text;
            }

            //check if we there are errors
            bool checkflag = true;
            bool[] errors = myutils.createQuestionConfirmation(question, lesson, category, difficulty, answers);

            //if there are errors write them to label
            this.createQuestionErrorsLabel.Text = "";
            if(errors[0])
            {
                checkflag = false;
                createQuestionErrorsLabel.Text += "Δεν μπορείτε να καταχωρήσετε κενή ερώτηση.\n";
            }
            if (errors[1])
            {
                checkflag = false;
                createQuestionErrorsLabel.Text += "Πρέπει να επιλέξετε μάθημα για την εισαγωγή ερώτησης.\n";
            }
            if (errors[2])
            {
                checkflag = false;
                createQuestionErrorsLabel.Text += "Δε μπορείτε να καταχωρήσετε κενή απάντηση, σβήστε την ή συμπληρώστε την.\n";
            }
            if (errors[3])
            {
                checkflag = false;
                this.createQuestionErrorsLabel.Text += "Η ερώτηση σας πρέπει να ανείκει οπωσδίποτε σε μία ενότητα.";
            }

            if (!checkflag)
            {                
                //code for error
                label18.Visible = true;
                createQuestionErrorsLabel.Visible = true;                
            }
            else
            {
                //code for send to database
                List<string> answerslist = new List<string>();
                
                answerslist.Add(this.createQuestionTextBox1.Text);
                answerslist.Add(this.createQuestionTextBox2.Text);
                for(int i=0; i<n; i++)
                    answerslist.Add(this.textboxes[i].Text);

                int check = db.iQuestion(user.ElementAt(0),question, answerslist, lesson, category, difficulty); //send to database


                if (check == 1)
                {
                    //set some fields to blank
                    this.createQuestionRichTextBox.Text = "";
                    this.createQuestionTextBox1.Text = "";
                    this.createQuestionTextBox2.Text = "";
                    for (int i = 0; i < n; i++)
                        textboxes[i].Text = "";
                    
                    MessageBox.Show("Η ερώτηση καταχωρήθηκε με επιτυχία!");
                } else if (check == 0)
                    createQuestionErrorsLabel.Text = "Αδυναμία σύνδεσης στη βάση!";
                else if (check == -1)
                    createQuestionErrorsLabel.Text = "Δεν υπάρχει η ενότητα!";
                else
                    createQuestionErrorsLabel.Text = "Υπήρξε πρόβλημα. Δεν καταχωρήθηκε η ερώτηση!!";
            }

            

           

        }        
        //change image when mouse enter
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
            temp.Image = Resources.icon_plus_enter;
        }

        //reset image when mouse leave
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
            temp.Image = Resources.icon_plus;
        }

        //set image when mouse is down
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
            temp.Image = Resources.icon_plus_pressed;
        }

        //change img when mouse is up
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
                temp.Image = Resources.icon_plus;

        }

        //change img when mouse enter
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
            temp.Image = Resources.icon_negative_enter;
        }

        //change img when mouse leave
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
            this.deleteTextboxPictureBox.Image = Resources.icon_negative;
        }

        //change img when mouse is down
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
            temp.Image = Resources.icon_negative_press;
        }

        //change img ehen mouse is up
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
            temp.Image = Resources.icon_negative;
        }



        //load categories when we choose lesson
        private void createQuestionLessonCombobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.createQuestionCategoryCombobox.Items.Clear();
            String lesson = this.createQuestionLessonCombobox.Text;
            //load categories
            categories = myutils.loadcategories(user.ElementAt(0), lesson);
            foreach (String category in this.categories)
            {
                this.createQuestionCategoryCombobox.Items.Add(category);
            }
        }

        #endregion

        #region METHODS OF createLessonPanel
        //methods of add and delete buttons for change the image (eg mouseover) are on createQuestionPanel region cause they first created there!


        //code for add category textbox and move buttons
        TextBox[] createLessonCategoriesTextboxes = new TextBox[50];
        int createLessonCategoriesMax = 50;
        int createLessonCategoriesCount = 0;
        private void createLessonAddPictureBox_Click(object sender, EventArgs e)
        {
            if(createLessonCategoriesCount < createLessonCategoriesMax)
            {

                //get last textbox Y
                int textboxY;
                if (createLessonCategoriesCount > 0)
                    textboxY = this.createLessonCategoriesTextboxes[createLessonCategoriesCount - 1].Location.Y;
                else
                    textboxY = this.createLessonCategoryTextbox.Location.Y;

                //create category textbox
                createLessonCategoriesTextboxes[createLessonCategoriesCount] = new TextBox();
                this.createLessonPanel.Controls.Add(createLessonCategoriesTextboxes[createLessonCategoriesCount]);
                createLessonCategoriesTextboxes[createLessonCategoriesCount].Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                createLessonCategoriesTextboxes[createLessonCategoriesCount].Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
                createLessonCategoriesTextboxes[createLessonCategoriesCount].Location = new System.Drawing.Point(41, textboxY + 36);
                createLessonCategoriesTextboxes[createLessonCategoriesCount].Margin = new System.Windows.Forms.Padding(22, 3, 22, 3);
                createLessonCategoriesTextboxes[createLessonCategoriesCount].MaxLength = 100;
                createLessonCategoriesTextboxes[createLessonCategoriesCount].Name = "createLessonCategoryTextbox" + (this.createLessonCategoriesCount + 2);                
                createLessonCategoriesTextboxes[createLessonCategoriesCount].Size = new System.Drawing.Size(this.createLessonCategoryTextbox.Size.Width, this.createLessonCategoryTextbox.Size.Height);
                createLessonCategoriesTextboxes[createLessonCategoriesCount].TabIndex = this.createLessonCategoriesCount + 3;

                createLessonCategoriesCount++;  //count++

                //move objects down
                this.createLessonDeletePictureBox.Location = new Point(this.createLessonDeletePictureBox.Location.X, this.createLessonDeletePictureBox.Location.Y + 36); //move delete button
                this.createLessonAddPictureBox.Location = new Point(this.createLessonAddPictureBox.Location.X, this.createLessonAddPictureBox.Location.Y + 36);  //move add button
                this.createLessonErrorLabel.Location = new Point(this.createLessonErrorLabel.Location.X, this.createLessonErrorLabel.Location.Y + 36);     //move error label
                this.createLessonErrorTitleLabel.Location = new Point(this.createLessonErrorTitleLabel.Location.X, this.createLessonErrorTitleLabel.Location.Y + 36);       //move error titlelabel
                this.createLessonConfButton.Location = new Point(this.createLessonConfButton.Location.X, this.createLessonConfButton.Location.Y + 36);     //move config


                //enable delete button if it's not
                if (!this.createLessonDeletePictureBox.Enabled)
                    this.createLessonDeletePictureBox.Enabled = true;

                //disable when count = max number
                if (createLessonCategoriesCount == createLessonCategoriesMax)
                    this.createLessonAddPictureBox.Enabled = false;
            }
        }

        //code for delete category textbox and move buttons
        private void createLessonDeletePictureBox_Click(object sender, EventArgs e)
        {
            if (this.createLessonCategoriesCount > 0)
            {
                this.createLessonCategoriesCount--;

                //delete last textbox
                this.createLessonCategoriesTextboxes[this.createLessonCategoriesCount].Dispose();
                this.createLessonCategoriesTextboxes[this.createLessonCategoriesCount] = null;

                //move objects up
                this.createLessonDeletePictureBox.Location = new Point(this.createLessonDeletePictureBox.Location.X, this.createLessonDeletePictureBox.Location.Y - 36); //move delete button
                this.createLessonAddPictureBox.Location = new Point(this.createLessonAddPictureBox.Location.X, this.createLessonAddPictureBox.Location.Y - 36);  //move add button
                this.createLessonErrorLabel.Location = new Point(this.createLessonErrorLabel.Location.X, this.createLessonErrorLabel.Location.Y - 36);     //move error label
                this.createLessonErrorTitleLabel.Location = new Point(this.createLessonErrorTitleLabel.Location.X, this.createLessonErrorTitleLabel.Location.Y - 36);       //move error titlelabel
                this.createLessonConfButton.Location = new Point(this.createLessonConfButton.Location.X, createLessonConfButton.Location.Y - 36);     //move config button


                //enable add category button if it's not
                if (!this.createLessonAddPictureBox.Enabled)
                    createLessonAddPictureBox.Enabled = true;


                //disable when you have 1 category
                if (this.createLessonCategoriesCount == 0)
                    this.createLessonDeletePictureBox.Enabled = false;

            }
        }

        //code fore createLesson Config Button
        private void createLessonConfButton_Click(object sender, EventArgs e)
        {
            //get fields
            String title = this.createLessonTitleTextbox.Text;  //get  title
            String description = this.createLessonDescriptionTextbox.Text;  //get description

            //get categories            
            String[] tempcategories = new string[this.createLessonCategoriesCount + 1];
            tempcategories[0] = this.createLessonCategoryTextbox.Text;
            for(int i=0; i< this.createLessonCategoriesCount; i++)
            {
                tempcategories[i+1] = this.createLessonCategoriesTextboxes[i].Text;               
            }

            //call confirmation for createLesson to check if fields are okey
            bool[] errors = myutils.createLessonConfirmation(title, tempcategories);

            bool checkflag = false; //flag=true if there are errors, else flag=false
            createLessonErrorLabel.Text = "";
            createLessonErrorLabel.Visible = false;
            createLessonErrorTitleLabel.Visible = false;

            if (errors[0])
            {
                checkflag = true;
                createLessonErrorLabel.Text += "Ο τίτλος είναι κενός, συμπληρώστε τον και ξαναπροσπαθήστε.\n";
            }
            if (errors[1])
            {
                checkflag = true;
                createLessonErrorLabel.Text += "Μία ή περισσότερες κατηγορίες είναι κενές, συμπληρώστε ή διαγράψτε τες και ξαναπροσπαθήστε.\n";
            }
            

            if (checkflag)
            {
                this.createLessonErrorTitleLabel.Visible = true;
                this.createLessonErrorLabel.Visible = true;
            }
            else
            {
                // all good, code for send to database
                int check = db.iLesson(user.ElementAt(0), title, description);

                if (check == 1)
                {
                    check = db.iUnit(this.createLessonCategoryTextbox.Text, user.ElementAt(0), title);
                    for (int i = 0; i < createLessonCategoriesCount; i++)
                    {
                        check = db.iUnit(this.createLessonCategoriesTextboxes[i].Text, user.ElementAt(0), title);
                    }
                    MessageBox.Show("Το μάθημα καταχωρήθηκε!");                    

                    //delete all fields
                    this.createLessonCategoryTextbox.Text = "";
                    this.createLessonDescriptionTextbox.Text = "";
                    this.createLessonTitleTextbox.Text = "";
                    for (int i = 0; i < createLessonCategoriesCount; i++)
                    {
                        this.createLessonCategoriesTextboxes[i].Text = "";                                              
                    }                   

                }
                else
                {
                    //errors
                    this.createLessonErrorLabel.Text = "Υπήρξε πρόβλημα, προσπαθήστε ξανά.";
                    this.createLessonErrorLabel.Visible = true;
                    this.createLessonErrorTitleLabel.Visible = true;                    
                }
                this.loadLessons();


            }

        }

        #endregion

        #region METHODS OF createManualTestPanel

        //open filter panel of createManualTestPanel
        private void createTestFilterButton_Click(object sender, EventArgs e)
        {
            this.filtersButtonFlag = 'C';
            filtersTimer.Start();
        }

        //code createManualTestFilterConfButton    
        private void createManualTestFilterConfButton_Click(object sender, EventArgs e)
        {
            filtersButtonFlag = 'C';
            filtersTimer.Start();
        }

        //code button for choose lesson
        private void createManualTestLessonButton_Click(object sender, EventArgs e)
        {
            //code button to choose a lesson
            if (this.createManualTestComboBox.Enabled)
            {
                this.createManualTestDataGridView.Enabled = true;
                this.createManualTestConfButton.Enabled = true;
                this.createManualTestSearchTextbox.Enabled = true;
                this.createTestFilterButton.Enabled = true;
                this.createManualTestComboBox.Enabled = false;
                this.createManualTestLessonButton.Text = "Αλλαγή";

                //load categories when we choose lesson
                categories = myutils.loadcategories(user.ElementAt(0), this.createManualTestComboBox.Text);
                this.createManualTestCatagoryCheckbox.Items.Clear();
                foreach (String category in categories)
                {
                    this.createManualTestCatagoryCheckbox.Items.Add(category);
                }
            }
            //call showDialog and reset
            else
            {
                this.createManualTestDataGridView.Enabled = false;
                this.createManualTestConfButton.Enabled = false;
                this.createManualTestSearchTextbox.Enabled = false;
                this.createTestFilterButton.Enabled = false;
                this.createManualTestComboBox.Enabled = true;
                this.createManualTestLessonButton.Text = "Επιλογή";
                //if filter panel is open then close it
                if (createManualQuestionFilterFlag)
                {
                    filtersButtonFlag = 'C';
                    filtersTimer.Start();
                }                
            }

            
            
            

            //call showDialog
            /*List<string> que = new List<string>();
            que.Add("Τί είναι το FTP;");
            que.Add("Τί είναι το SMTP;");
            que.Add("Τί είναι το HTTP;");

            int check = db.iTest(que, user.ElementAt(0), "Δίκτυα", "Επίπεδο Εφαρμογής");

            if (check == 1)
                MessageBox.Show("Το διαγώνισμα καταχωρήθηκε!!");
            else if (check == 0)
                MessageBox.Show("Αδυναμία σύνδεσης στη βάση!!");
            else if (check == -1)
                MessageBox.Show("Δεν υπάρχει η ενότητα!!");
            else if (check == -3)
                MessageBox.Show("Δεν υπάρχει η ερώτηση!!");
            else
                MessageBox.Show("Υπήρξε πρόβλημα. Δεν καταχωρήθηκε η ερώτηση!!");*/

        }



        #endregion

        #region METHODS OF createAutoTestPanel
        //create Auto test conf button
        private void createAutoTestConfButton_Click(object sender, EventArgs e)
        {
            //set false errors
            bool errorflag = false; //flag for errors
            createAutoTestErrorsTitleLabel.Visible = false;
            createAutoTestErrorsLabel.Visible = false;
            createAutoTestErrorsLabel.Text = "";            

            //get fields
            String lesson = this.createAutoTestLessonComboBox.Text;//get lesson
            int number = Convert.ToInt32(createAutoTestNumericUpDown.Value);    //get number of questions
            String title = this.createAutoTestTitleTextbox.Text;    //get tiitle lesson

            //get categories and difficulty levels
            List<string> categories = this.createAutoTestCategoryCheckedListBox.CheckedItems.OfType<string>().ToList();
            List<string> diffString = this.createAutoTestDifficultyCheckedListBox.CheckedItems.OfType<string>().ToList();
            List<int> diff = new List<int>();
            foreach (String checkedItem in diffString)
            {
                if (checkedItem.Equals("Εύκολες"))
                    diff.Add(1);
                else if (checkedItem.Equals("Δύσκολες"))
                    diff.Add(3);
                else
                    diff.Add(2);
            }

            //call confiration util method to check if all are okey
            bool[] errors = myutils.createAutoTestConfirmation(lesson, diff.Count, categories.Count, this.createAutoTestTitleTextbox.Text);

            if (errors[0])
            {
                errorflag = true;
                this.createAutoTestErrorsLabel.Text += "Δεν έχετε επιλέξει μάθημα.\n";
            }            
            if (errors[1])
            {
                errorflag = true;
                this.createAutoTestErrorsLabel.Text += "Πρέπει να διαλέξετε τουλάχιστον ένα επίπεδο δυσκολίας.\n";
            }                
            if (errors[2])
            {
                errorflag = true;
                this.createAutoTestErrorsLabel.Text += "Πρέπει να επιλέξετε τουλάχιστον μία κατηγορία μαθήματος.\n";
            }
            if (errors[3])
            {
                errorflag = true;
                this.createAutoTestErrorsLabel.Text += "Δε μπορείτε να καταηγορήσετε κενό τίτλο.\n";
            }

            //check if is is okey to send or do visible error labels
            if (errorflag)
            {
                createAutoTestErrorsTitleLabel.Visible = true;
                createAutoTestErrorsLabel.Visible = true;
            }
            else //οκευ, code to send to database
            {
                //find questions
                List<string> questions = myutils.loadquestions(user.ElementAt(0),lesson,categories,diff); //get questions with filters

                //check if there are are enough questions to create test
                if(questions.Count < number)
                {
                    this.createAutoTestErrorsLabel.Text = "Δεν υπάρχουν αρκετές ερωτήσεις για την δημιουργία διαγωνίσματος με αυτό το μάθημα και αυτά τα φίλτρα.";
                    this.createAutoTestErrorsLabel.Visible = true;
                    this.createAutoTestErrorsTitleLabel.Visible = true;
                }
                else
                {
                    //get random questions
                    List<string> test = new List<string>();

                    Random rand = new Random();

                    for(int i=0; i<number; i++)
                    {
                        int index = rand.Next(0, questions.Count);
                        test.Add(questions.ElementAt(index));
                        questions.RemoveAt(index);
                    }
                    Console.WriteLine();
                    int check = db.iTest(test, user.ElementAt(0), lesson, this.createAutoTestTitleTextbox.Text);

                    if (check == 1)
                    {
                        MessageBox.Show("Το διαγώνισμα δημιουργήθηκε");
                        this.createAutoTestDifficultyCheckedListBox.SelectedItems.Clear();
                        this.createAutoTestCategoryCheckedListBox.SelectedItems.Clear();
                        this.createAutoTestTitleTextbox.Text = "";
                        this.createAutoTestNumericUpDown.Value = 1;
                    }
                    else
                    {
                        this.createAutoTestErrorsLabel.Text = "Υπήρξε πρόβλημα, προσπαθήστε ξανά.";
                        this.createAutoTestErrorsLabel.Visible = true;
                        this.createAutoTestErrorsTitleLabel.Visible = true;
                    }
                }

                
            }
           
        }

        //load categories when we select lesson in createAutoTestPanel
        private void createAutoTestLessonComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.createAutoTestCategoryCheckedListBox.Items.Clear();
            //load categories            
            categories = myutils.loadcategories(user.ElementAt(0), this.createAutoTestLessonComboBox.Text);
            foreach (String category in categories)
            {
                this.createAutoTestCategoryCheckedListBox.Items.Add(category);
            }

        }
        #endregion

        #region METHOS OF editLessonsPanel
        //open lesson editForm
        private void editLessonsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;    //get datagridview

            String lesson = dgv[0, e.RowIndex].Value.ToString();
                
            EditLessonForm form = new EditLessonForm(user.ElementAt(0), lesson, this);
            form.Show();
        }

        //fill lesson DataGridView
        private void fillLessonDataGridView(DataGridView dgv, List<string>list)
        {
            dgv.Rows.Clear();
            
            int i = 0;
            try
            {
                foreach (String lesson in list)
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells[0].Value = lesson;
                    i++;
                }
            }
            catch
            {
                Console.Write("No lessons.");
            }
           
        }
        #endregion


        #region FILTERS PANEL EFFECT
        //-----------------------------------------------------------------------
        private char filtersButtonFlag; //flag to see which filter button pressed
        bool showQuestionFiltrerflag = false;  //flag to see if panel is open or not
        bool createManualQuestionFilterFlag = false; //flag to see if panel is open or not
        bool editQuestionFilterFlag = false;    //flag to see if panel is open or not
        private void filtrersPanelTimer(object sender, EventArgs e)
        {
            //temps to code the right panel
            Panel tempPanel = null;
            Button tempButton = null;
            bool tempFlag = false;

            //check whick fliter panel we need to code
            if (filtersButtonFlag == 'S')
            {
                tempPanel = this.showQuestionsFilterPanel;
                tempButton = this.showQuestionsFilterButton;
                tempFlag = this.showQuestionFiltrerflag;
            }
            else if (filtersButtonFlag == 'C')
            {
                tempPanel = this.createManualTestFilterPanel;
                tempButton = this.createTestFilterButton;
                tempFlag = this.createManualQuestionFilterFlag;
            }else if(filtersButtonFlag == 'E')
            {
                tempPanel = this.editQuestionFilterPanel;
                tempButton = this.editQuestionFilterButton;
                tempFlag = this.editQuestionFilterFlag;
            }

            //if panel is open then close
            if (tempFlag)
            {
                tempPanel.Width -= 22;
                tempButton.Location = new Point(tempButton.Location.X - 22, tempButton.Location.Y);
                if (tempPanel.Width == 0)
                {
                    filtersTimer.Stop();
                    if (filtersButtonFlag == 'S')
                        this.showQuestionFiltrerflag = false;
                    else if (filtersButtonFlag == 'C')
                        this.createManualQuestionFilterFlag = false;
                    else if (filtersButtonFlag == 'E')
                        this.editQuestionFilterFlag = false; ;

                }
            }
            //if panel is close then open
            else
            {
                tempPanel.Width += 22;
                tempButton.Location = new Point(tempButton.Location.X + 22, tempButton.Location.Y);

                if (tempPanel.Width == 242)
                {
                    filtersTimer.Stop();
                    if (filtersButtonFlag == 'S')
                        this.showQuestionFiltrerflag = true;
                    else if (filtersButtonFlag == 'C')
                        this.createManualQuestionFilterFlag = true;
                    else if (filtersButtonFlag == 'E')
                        this.editQuestionFilterFlag = true;
                }
            }
        }

        #endregion


        #region NEWS LABEL TO LEFTPANEL FROM RIGHT TO LEFT
        private void newstimer_Tick(object sender, EventArgs e)
        {
            this.newsLabel.Location = new Point(this.newsLabel.Location.X - 1, this.newsLabel.Location.Y);
            if (this.newsLabel.Location.X + this.newsLabel.Width < 0)
            {
                newsTimer.Stop();
                this.newsLabel.Location = new Point(224, this.newsLabel.Location.Y);
                this.newsLabel.Text = this.newsArr[new Random().Next(0, 4)];
                this.sleepTimer.Start();    //call sleepTimer to sleep for X seconds 

            }


        }
        //sleep for x seconds and then start again newsTimer
        private void sleepTimer_Tick(object sender, EventArgs e)
        {
            newsTimer.Start();
            sleepTimer.Stop();
        }


        #endregion


        #region KONAMI CODE EGG

        //Click the titleL in leftmenuP and then the Konami code (UP,UP,DOWN,DOWN,LEFT,RIGHT,LEFT,RIGHT,B,A,ENTER) and Gradius theme song will play.
        Keys[] konami = { Keys.Up, Keys.Up, Keys.Down, Keys.Down, Keys.Left, Keys.Right, Keys.Left, Keys.Right, Keys.B, Keys.A, Keys.Enter };
        int konamiCounter = 0;

        private void konamiTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == konami[konamiCounter])
            {
                konamiCounter++;
                if (konamiCounter == konami.Length)
                {
                    SoundPlayer audio = new SoundPlayer(Resources.gradius_nes_music_1_); 
                    audio.Play();
                    konamiCounter = 0;    
                }

            }
            else
                konamiCounter = 0;
        }

        private void konamiTextbox_Leave(object sender, EventArgs e)
        {
            konamiCounter = 0;
        }

        private void titleL_Click(object sender, EventArgs e)
        {
            konamiTextbox.Focus();
        }





        #endregion

        private void createManualTestConfButton_Click(object sender, EventArgs e)
        {

        }

        //call filter effect panel of edit question
        private void editQuestionFilterButton_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            temp.BringToFront();
            this.editQuestionFilterPanel.BringToFront();

            this.filtersButtonFlag = 'E';
            filtersTimer.Start();
        }

        private void showTestsLessonComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.fillTestDataGridView(this.showTestsLessonComboBox.Text);
        }

        //showtests
        private void testB_Click(object sender, EventArgs e)
        {
            this.temp.Visible = false;
            this.showTestsPanel.Visible = true;
            this.temp = this.showTestsPanel;
        }

        private void test_pdf(string lesson, string name)
        {
            //Το foreach γινεται για την προβολή των απαντησεων της ερωτησης. Η ερωστηση ειναι το questions[0].ElementAt(i) (για την i ερωτηση) και οι απαντησεις της μεσα στο foreach η μεταβλητη answer ειναι η καθε απαντηση της
            List<string>[] questions = new List<string>[3];
            List<string> answers = new List<string>();
            string html = "<div style =\"text-align: left; display: inline-block; font-family: Arial, serif; font-weight: bold;\">" +
                                        "<div style=\"position: absolute; text-align: right; margin-right: 50px; top: 0; right: 0\"><img height=\"110px\" width=\"110px\" style=\"margin-right: 50px;\" src=\"logo.png\" alt=\"logo\"></div>" +
                                        "<h3>" + user.ElementAt(7) + "</h3>" +
                                        "Μάθημα: " + lesson + "<br><br>Καθηγητής: " + user.ElementAt(2) + " " + user.ElementAt(3) + "<br><br>Ονοματεπώνυμο:" +
                                        "</div>" +
                                        "<div style=\"font-family: Arial, serif; display:block\">" +
                                        "<ol>";
            questions = db.qTest(user.ElementAt(0), lesson, name);
            for (int i = 0; i < questions[0].Count; i++)
            {
                html += "<li style=\"margin-top: 20px;\">";
                answers = db.qAnswers(questions[0].ElementAt(i), questions[1].ElementAt(i), user.ElementAt(0), questions[2].ElementAt(i));
                Console.WriteLine("Ερώτηση: " + questions[0].ElementAt(i));
                html += "<h4>" + questions[0].ElementAt(i) + "</h4>" +
                       "<ol type =\"a\" style=\"font-weight:normal; margin-top: 10px\">";
                try
                {
                    foreach (string answer in answers)
                    {
                        html += "<li>" + answer + "</li>";
                        Console.WriteLine(answer);
                    }
                    html += "</ol>" +
                           "</li>";
                    answers.Clear();
                }
                catch
                {

                }
                
            }
            html += "</ol>" +
                    "</div> ";
            WebBrowser myWebBrowser = new WebBrowser();
            myWebBrowser.DocumentText = html;
            Console.WriteLine(html);
            MessageBox.Show("Θέλετε να αποθηκεύσετε το τεστ με όνομα " + name + ";");

            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.Filter = "PDF|*.pdf";
                savefile.Title = "Αποθήκευση διαγωνίσματος " + name + " σε pdf αρχείο";
                savefile.FileName = name + ".pdf";
                try
                { savefile.ShowDialog(); }
                catch { }
                pdf.Save(new FileStream(savefile.FileName, FileMode.Create));
                Console.WriteLine("mphke");
            }
        }

        private void test_print(string lesson, string name)
        {
            //Το foreach γινεται για την προβολή των απαντησεων της ερωτησης. Η ερωστηση ειναι το questions[0].ElementAt(i) (για την i ερωτηση) και οι απαντησεις της μεσα στο foreach η μεταβλητη answer ειναι η καθε απαντηση της
            List<string>[] questions = new List<string>[3];
            List<string> answers = new List<string>();
            string html = "<div style =\"text-align: left; display: inline-block; font-family: Arial, serif; font-weight: bold;\">" +
                                        "<div style=\"position: absolute; text-align: right; margin-right: 50px; top: 0; right: 0\"><img height=\"110px\" width=\"110px\" style=\"margin-right: 50px;\" src=\"logo.png\" alt=\"logo\"></div>" +
                                        "<h3>" + user.ElementAt(7) + "</h3>" +
                                        "Μάθημα: " + lesson + "<br><br>Καθηγητής: " + user.ElementAt(2) + " " + user.ElementAt(3) + "<br><br>Ονοματεπώνυμο:" +
                                        "</div>" +
                                        "<div style=\"font-family: Arial, serif; display:block\">" +
                                        "<ol>";
            questions = db.qTest(user.ElementAt(0), lesson, name);
            for (int i = 0; i < questions[0].Count; i++)
            {
                html += "<li style=\"margin-top: 20px;\">";
                answers = db.qAnswers(questions[0].ElementAt(i), questions[1].ElementAt(i), user.ElementAt(0), questions[2].ElementAt(i));
                Console.WriteLine("Ερώτηση: " + questions[0].ElementAt(i));
                html += "<h4>" + questions[0].ElementAt(i) + "</h4>" +
                        "<ol type =\"a\" style=\"font-weight:normal; margin-top: 10px\">";
                try
                {
                    foreach (string answer in answers)
                    {
                        html += "<li>" + answer + "</li>";
                        Console.WriteLine(answer);
                    }
                    html += "</ol>" +
                           "</li>";
                    answers.Clear();
                }
                catch
                {

                }
                
            }
            html += "</ol>" +
                    "</div> ";
            WebBrowser myWebBrowser = new WebBrowser();
            myWebBrowser.DocumentText = html;
            Console.WriteLine(html);
            MessageBox.Show("Θέλετε να εκτυπώσετε το τεστ με όνομα " + name + ";");
            myWebBrowser.ShowPrintPreviewDialog();
        }
        private void showTestsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //pdf
            if(e.RowIndex != -1)
            {
                    if (e.ColumnIndex == 1)
                    {
                        String pdf = this.showTestsDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                        this.test_pdf(this.showTestsLessonComboBox.Text, pdf);
                    }
                    else if (e.ColumnIndex == 2)    //print
                    {
                        String print = this.showTestsDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                        this.test_print(this.showTestsLessonComboBox.Text, print);
                        Console.WriteLine(print);
                    }
               
            }
           
        }


    }    
}
