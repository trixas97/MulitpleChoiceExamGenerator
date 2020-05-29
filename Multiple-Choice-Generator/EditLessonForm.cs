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
    public partial class EditLessonForm : Form
    {
        //fields
        private Form1 father;
        private String lesson;
        private String user;
        private String desc = "";
        private List<string> units;
        private database db = new database();

        public EditLessonForm(String user, String lesson, Form1 father)
        {
            InitializeComponent();

            this.father = father;
            this.lesson = lesson;
            this.user = user;
        }

        //load
        private void EditLessonForm_Load(object sender, EventArgs e)
        {
            this.lessonTextbox.Text = this.lesson;  //set title of lesson to textbox
            this.Text = "Επεξεργασία μαθήματος - " + this.lesson; //set title

            this.desc = db.qLessonDesc(user,lesson);
            this.descriptionTextbox.Text = this.desc;   //set desc to texbox
            

            this.units = db.qUnits(user, lesson);    //get units
            this.fillUnitsDataGridView();   //fill datagridview

            this.unitsDataGridView.ReadOnly = false;
        }



        //fill datagridview with units
        private void fillUnitsDataGridView()
        {
            this.unitsDataGridView.Rows.Clear();    //clear datagridview

            try
            {
                int i = 0;
                foreach (String unit in this.units)
                {
                    this.unitsDataGridView.Rows.Add();
                    this.unitsDataGridView.Rows[i].Cells[0].Value = unit;
                    i++;
                }
            }
            catch
            {
                Console.Write("No units!");
            }
            


        }

        //cancel
        private void cancelButton_Click(object sender, EventArgs e)
        {
            ConfigForm conf = new ConfigForm("Είστε σίγουρος ότι θέλετε να ακυρώσετε την επεξεργασία;\nΌποια αλλαγή έχετε κάνει θα χαθεί!", "Όχι", "Ναι", Color.OrangeRed, "Ακύρωση επεξεργασίας");

            if (conf.ShowDialog(this) == DialogResult.OK)
            {

                this.Close();
                this.Dispose();
            }
            conf.Dispose();
        }

        //config changes
        private void okButton_Click(object sender, EventArgs e)
        {
            this.clearErrors();//clear error message
            ConfigForm conf = new ConfigForm("Είστε σίγουρος ότι θέλετε να επιβεβαιώσετε τις αλλαγές σας;\nΟι αλλαγές θα είναι οριστικές!", "Όχι", "Ναι", Color.LimeGreen, "Επιβεβαίωση επεξεργασίας");            

            //he want to do the changes
            if (conf.ShowDialog(this) == DialogResult.OK)
            {
                String newTitle = this.lessonTextbox.Text;  //get new title
                String newDesc = this.descriptionTextbox.Text;  //get new description
                bool closeFlag = true;  //flag for no close this form, true close, false= there is error not close
                int check;
                //disable error labels
                this.clearErrors();

                

                //change title and desc                
                if (!this.lesson.Equals(newTitle))
                {
                    if(!(String.IsNullOrEmpty(newTitle) || String.IsNullOrWhiteSpace(newTitle)))    //if title is empty then don't call database
                    {
                        check = 0;
                        check = db.uLesson(user, this.descriptionTextbox.Text, this.lessonTextbox.Text, lesson);                       
                        if (check == 1) //everything was okey
                        {
                            this.lesson = newTitle;
                            this.desc = newDesc;
                        }
                        else if (check == -5)
                        {
                            errorsLabel.Text = "Υπάρχει ήδη μάθημα με αυτόν τον τίτλο.\n";
                            closeFlag = false;
                        }
                    }
                    else
                    {
                        errorsLabel.Text = "Δεν μπορείτε να εισάγεται κενό τίτλο μαθήματος!\n";
                        closeFlag = false;
                    }
                }
                else
                {
                    check = 0;
                    check = db.uLesson(user, this.descriptionTextbox.Text, lesson);
                    if (check == 1) //everything was okey
                    {
                        this.lesson = newTitle;
                        this.desc = newDesc;
                    }
                    else
                    {
                        errorsLabel.Text = "Κάτι πήγε στραβά στην επεξεργασία περιγραφής.\n";
                        closeFlag = false;
                    }
                    
                }

                //delete units
                for(int i=0; i<units.Count; i++)
                {
                    //check if checkbox is checked
                    bool flag = false;
                    try
                    {
                        flag = (bool)this.unitsDataGridView.Rows[i].Cells[1].Value;
                    }
                    catch   //it was null
                    {}
                    
                    if (flag)
                    {                        
                        check = db.dUnit(this.user, this.lesson, units.ElementAt(i));
                        if (check != 1)
                        {
                            closeFlag = false;
                            errorsLabel.Text += "Κάτι πήγε στραβά στη διαγραφή ενότητα\n";
                        }
                    }else //change name of unit
                    {
                        String editUnitFlag = "";
                        try
                        {
                            editUnitFlag = (String)this.unitsDataGridView.Rows[i].Cells[0].Value.ToString();
                        }
                        catch
                        {
                            
                        }

                        //there was null exception. now there is only blank or empty string with try catch and this field/flag
                        if (!(String.IsNullOrEmpty(editUnitFlag) || String.IsNullOrWhiteSpace(editUnitFlag))){
                            String newUnit = this.unitsDataGridView.Rows[i].Cells[0].Value.ToString();

                            //new name != old name
                            if (!newUnit.Equals(units.ElementAt(i).ToString()))
                            {
                                check = db.uUnit(user, lesson, newUnit, units.ElementAt(i));
                                if (check == -5)
                                {
                                    Console.Write(check);
                                    closeFlag = false;
                                    errorsLabel.Text += "Δε μπορείτε να έχετε το ίδιο όνομα σε παραπάνω απο μία ενότητα.\n";
                                }
                                else if (check != 1)
                                {
                                    Console.Write(check);
                                    closeFlag = false;
                                    errorsLabel.Text += "Κάτι πήγε λάθος στη μετονομασία ενότητας.\n";
                                }
                            }                            
                        }
                        else
                        {
                            closeFlag = false;
                            errorsLabel.Text += "Δε μπορείτε να αποθηκεύσετε κενό τίτλο ενότητας.\n";
                        }                                                                   
                    }
                }

                //create units
                if(units.Count < this.unitsDataGridView.Rows.Count - 1)
                {
                    for(int i=units.Count; i<this.unitsDataGridView.Rows.Count-1; i++)
                    {                        
                        String unitName = this.unitsDataGridView.Rows[i].Cells[0].Value.ToString();
                        if (!String.IsNullOrEmpty(unitName) && !String.IsNullOrWhiteSpace(unitName))
                        {
                            check = db.iUnit(unitName, user, lesson);

                            if (check != 1)
                            {
                                closeFlag = false;
                                this.errorsLabel.Text += "Υπήρξε πρόβλημα με την δημιουργία ενότητας.\n";
                            }
                        }else
                        {
                            this.errorsLabel.Text += "Δε μπορείτε να εισάγεται κενό όνομα ενότητας.";
                            closeFlag = false;
                        }
                                 
                    }
                }

                father.loadLessons();   //load lessons, refresh them

                if (closeFlag)  //all good
                {
                    MessageBox.Show("Η επεξεργασία μαθήμητος πραγματοποιήθηκε με επιτυχία.");
                    this.Close();
                    this.Dispose();
                }
                else   //there are errors
                {
                    errorsLabel.Visible = true;
                    errorTittleLabel.Visible = true;
                }         
            }
                conf.Dispose();
        }

        //delete the lesson
        private void deleteLessonButton_Click(object sender, EventArgs e)
        {
            ConfigForm conf = new ConfigForm("Είστε σίγουρος ότι θέλετε να διαγράψετε το μάθημα;\nΜαζί με το μάθημα θα διαγραφούν και οι ερωτήσεις του!\nΑύτό το βήμα είναι οριστικό και δεν υπάρχει δυνατότητα ανάκτησης των δεδομένων!", "Ακύρωση", "Διαγραφή!", Color.Red, "Διαγραφή μαθήματος!");

            if (conf.ShowDialog(this) == DialogResult.OK)
            {
                //delete lesson
                int check = db.dLesson(user, this.lesson);

                if (check == 1)
                {
                    father.loadLessons();

                    conf.Dispose();
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    this.errorsLabel.Text = "Το μάθημα δε διαγράφτηκε!";
                    this.errorsLabel.Visible = true;
                    this.errorTittleLabel.Visible = true;
                }
                
                
            }
            
        }

        private void unitsDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           

                
                
        }

        //checkbox code
        private void unitsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //fonts
            Font strikout = new System.Drawing.Font("Verdana", 12F, (System.Drawing.FontStyle.Regular | System.Drawing.FontStyle.Strikeout), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            Font normal = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));

            //strickout or not
            if (e.ColumnIndex == 1)
            {
                //check if checkbox is checked or not
                bool flag = false;
                try
                {
                    flag = (bool)this.unitsDataGridView.Rows[e.RowIndex].Cells[1].Value;
                }
                catch
                { }

                if (flag)
                {
                    this.unitsDataGridView.Rows[e.RowIndex].Cells[1].Value = false;
                    this.unitsDataGridView.Rows[e.RowIndex].Cells[0].Style.Font = normal;
                }
                else
                {
                    this.unitsDataGridView.Rows[e.RowIndex].Cells[1].Value = true;
                    this.unitsDataGridView.Rows[e.RowIndex].Cells[0].Style.Font = strikout;
                }
            }
        }

        private void clearErrors()
        {
            this.errorsLabel.Visible = false;
            this.errorTittleLabel.Visible = false;
            this.errorsLabel.Text = "";
        }
    }   
}
