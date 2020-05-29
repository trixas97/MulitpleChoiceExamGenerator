using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Choice_Generator
{
    class Utils
    {
        //check if fields of createQuestion are okey to send to database
        public bool[] createQuestionConfirmation(String question, String lesson, String category, int difficulty, String[] answers)
        {
            /*
             errors[0] -> question text is empty             
             errors[1] -> lesson text is empty
             errors[2] -> one or more answers are empty, null or only whitespace
             errrors[3] -> category is empty
             */
            bool[] errors = {false, false, false, false};                                       

            if (String.IsNullOrEmpty(question) || String.IsNullOrWhiteSpace(question))  //need upgrading
                errors[0] = true;

            if(lesson.Equals(""))
                errors[1] = true;

            if (String.IsNullOrEmpty(category) || String.IsNullOrWhiteSpace(category))
                errors[3] = true;

            for(int i=0; i<answers.Length; i++)
            {
                if (String.IsNullOrEmpty(answers[i]) || string.IsNullOrWhiteSpace(answers[i]))
                    errors[2] = true;
            }

            return errors;
        }

        //check if fields of createAUtotest are okey to send to database
        public bool[] createAutoTestConfirmation(String lesson, int difficulty, int category, String title)
        {
            bool[] errors = {false, false, false, false};
            /*
             errors[0] -> no lesson has choosen
             errors[1] -> no difficulty levels have choosen
             errors[2] -> no categories have choosen  
             errors[3] -> empty title
             */

            if (lesson.Equals("") || lesson == null
)
                errors[0] = true;
            if (difficulty == 0)
                errors[1] = true;
            if (category == 0)
                errors[2] = true;
            if (String.IsNullOrEmpty(title) || String.IsNullOrWhiteSpace(title))
                errors[3] = true;

            return errors;
        }

        //check if fields of createLesson are okey to send to database
        public bool[] createLessonConfirmation(String title, String[] category)
        {
            bool[] errors = {false, false};
            /*
             errors[0] -> emprty title lesson
             errors[1] -> one or more categories are empty             
            */

            //check if title is empty or blank
            if (String.IsNullOrEmpty(title) || String.IsNullOrWhiteSpace(title))
                errors[0] = true;

            //check if one or more categories are empty or blank            
                for (int i = 0; i < category.Length; i++)
                {
                    if (String.IsNullOrWhiteSpace(category[i]) || String.IsNullOrEmpty(category[i]))
                    {
                        errors[1] = true;
                        break;
                    }
                }
            
            
            return errors;
        }

        database db = new database();

        //reutn lessons
        public List<string> loadlessons(String user)
        {            
            List<string> lessons = new List<string>();

            //get lessons
            lessons = db.qLessons(user);

            return lessons;
        }



        //return categories
        public List<string> loadcategories(String user, String lesson)
        {
            List<string> categories = new List<string>();
            categories =  db.qUnits(user, lesson);
            
            return categories;
        }

        //return filter questions
        public List<string> loadquestions(String user, String lesson, List<string> categories, List<int> diff)
        {
            List<string> questions = new List<string>();
            
            foreach(String category in categories){
                foreach(int differ in diff)
                {
                    try
                    {
                        questions.AddRange(db.qQuestions(user, lesson, category, differ));
                    }
                    catch
                    {
                        //δεν υπήρχαν αρκετες ερωτήσεις
                    }
                    
                }              
            }            

            return questions;   //return all questions with my filters
        }

        //return a string list with checked items of checkedlistbox
        public List<String> getStringCheckedList(CheckedListBox list)
        {
            List<string> checkedList = new List<string>();

            foreach(String checkedItem in list.CheckedItems)
            {                
                checkedList.Add(checkedItem.ToString());
            }

            return checkedList;
        }

        //return int list for difficulty
        public List<int> getIntCheckedList(CheckedListBox list)
        {
            List<int> checkedList = new List<int>();

            foreach (String checkedItem in list.CheckedItems)
            {
                if(checkedItem.Equals("Εύκολες"))
                    checkedList.Add(1);
                else if(checkedItem.Equals("Μεσαίες"))
                    checkedList.Add(2);
                else
                    checkedList.Add(3);
            }

            return checkedList;
        }

       //return a list with searching list
       public List<string> searchTextBox(List<string>[] list, String text)
        {
            List<string> newlist = new List<string>();
            try
            {
                newlist = list[0].FindAll(x => x.Contains(text));
            }
            catch { }
            return newlist;
        }

        //clear a array string list
        public List<string>[] getClearArrayList(List<string>[] list)
        {
            int columns = list.Length;

            try
            {
            for (int i = 0; i < columns; i++)
                list[i].Clear();

            return list;
            }catch
            {
                return list;
            }
        }


    }
}
