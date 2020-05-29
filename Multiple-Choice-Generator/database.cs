using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Multiple_Choice_Generator
{
    public class database
    {
        //Aetos database
/*        private readonly string server = "dblabs.it.teithe.gr";
        private readonly string db = "it154551";
        private readonly string uid = "it154551";
        private readonly string password = "123456";*/

/*        local database*/
        private string server = "localhost";
        private string db = "multiple";
        private string uid = "root";
        private string password = "";

        MySqlConnection dbcon = null;

        public database()
        {
            
        }
        //Συνδέση με βάση δεδομένων
        public bool connection()
        {
            string conn = "SERVER=" + server + ";" + "DATABASE=" + db + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";charset=utf8;";
            dbcon = new MySqlConnection(conn);
            try
            {
                dbcon.Open();
                Console.WriteLine("Επιτυχής σύνδεση στην βάση " + db + " του σέρβερ " + server + "!!!");
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 1045:
                        Console.WriteLine("Λάθος όνομα χρήστη και/ή κωδικός του σερβερ!!!");
                        break;

                    case 0:
                        Console.WriteLine("Δεν μπόρεσε να συνδεθεί στον σέρβερ!!");
                        break;
                }
                return false;
            }
        }

        //Σύνδεση χρήστη και επιστροφή των στοιχείων του σε λιστα
        public List<string> login(string username, string password)
        {
            int exist = 0;
            if (connection() == true)
            {
                List<string> list = new List<string>();

                string query = "Select * From users where username='" + username + "' and password='" + password + "'";
                MySqlCommand cmd = new MySqlCommand(query, dbcon);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list.Add(dataReader["username"] + "");
                    list.Add(dataReader["password"] + "");
                    list.Add(dataReader["surname"] + "");
                    list.Add(dataReader["name"] + "");
                    list.Add(dataReader["email"] + "");
                    list.Add(dataReader["gender"] + "");
                    list.Add(dataReader["birth"] + "");
                    list.Add(dataReader["school"] + "");
                    exist++;
                }
                dataReader.Close();
                if (exist == 1)
                    return list;
                else
                    return null;
            }
            else
                return null;
        }

        public List<string> qUserEmail(string username)
        { 
            if (connection() == true)
            {
                int exist = 0;
                List<string> list = new List<string>();
                string query = "Select * From users where username='" + username + "'";
                MySqlCommand cmd = new MySqlCommand(query, dbcon);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list.Add(dataReader["email"] + "");
                    list.Add(dataReader["password"] + "");
                    list.Add(dataReader["name"] + "");
                    list.Add(dataReader["gender"] + "");
                    exist++;
                }
                dataReader.Close();
                if (exist == 0)
                    return null;
                else
                    return list;
            }
            else
                return null;
        }


        public List<string> qQuestions(string username, string lesson, string unit)
        {
            int exist = 0;
            if (connection() == true)
            {
                List<string> list = new List<string>();
                int unit_id = convertUnit(unit, username, lesson);
                string query = "Select * From questions where owner='" + username + "' and lesson='" + lesson + "' and unit_id=" + unit_id ; 
                MySqlCommand cmd = new MySqlCommand(query, dbcon);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list.Add(dataReader["text"] + "");
                    exist++;
                }
                dataReader.Close();
                if (exist == 0)
                    return null;
                else
                    return list;
            }
            else
                return null;
        }

        public List<string> qQuestions(string username, string lesson, string unit, int dif)
        {
            int exist = 0;
            if (connection() == true)
            {
                List<string> list = new List<string>();
                int unit_id = convertUnit(unit, username, lesson);
                string query = "Select * From questions where owner='" + username + "' and lesson='" + lesson + "' and unit_id=" + unit_id + " and dif=" + dif;
                MySqlCommand cmd = new MySqlCommand(query, dbcon);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list.Add(dataReader["text"] + "");
                    exist++;
                }
                dataReader.Close();
                if (exist == 0)
                    return null;
                else
                    return list;
            }
            else
                return null;
        }

        public List<string>[] qQuestionsMore(string username, string lesson, List<string> units, List<int> difs)
        {
                int exist = 0;
                if (connection() == true)
                {
                    List<string>[] list = new List<string>[4];
                    int unit_id;
                    list[0] = new List<string>();
                    list[1] = new List<string>();
                    list[2] = new List<string>();
                    list[3] = new List<string>();
                    string query = "";
                    foreach(string unit in units)
                    {
                        foreach (int dif in difs)
                        {
                            unit_id = convertUnit(unit, username, lesson);
                            query = "Select Q.*, U.name From questions Q JOIN units U ON Q.unit_id=U.id where Q.owner='" + username + "' and Q.lesson='" + lesson + "' and Q.unit_id=" + unit_id + " and Q.dif=" + dif;

                            MySqlCommand cmd = new MySqlCommand(query, dbcon);
                            MySqlDataReader dataReader = cmd.ExecuteReader();
                            Console.WriteLine(query);
                            while (dataReader.Read())
                            {
                                list[0].Add(dataReader["text"] + "");
                                list[1].Add(dataReader["lesson"] + "");
                                list[2].Add(dataReader["name"] + "");
                                list[3].Add(dataReader["dif"] + "");
                                exist++;
                            }
                            dataReader.Close();
                        }
                    }
                    if (exist == 0)
                        return null;
                    else
                        return list;
                }
                else
                    return null;
        }

        public List<string>[] qQuestionsMore(string username, string lesson)
        {
            int exist = 0;
            if (connection() == true)
            {
                List<string>[] list = new List<string>[4];
                list[0] = new List<string>();
                list[1] = new List<string>();
                list[2] = new List<string>();
                list[3] = new List<string>();
                string query = "";
                query = "Select Q.*, U.name From questions Q JOIN units U ON Q.unit_id=U.id where Q.owner='" + username + "' and Q.lesson='" + lesson + "'";
                MySqlCommand cmd = new MySqlCommand(query, dbcon);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Console.WriteLine(query);
                while (dataReader.Read())
                    {
                        list[0].Add(dataReader["text"] + "");
                        list[1].Add(dataReader["lesson"] + "");
                        list[2].Add(dataReader["name"] + "");
                        list[3].Add(dataReader["dif"] + "");
                        exist++;
                    }
                dataReader.Close();
                if (exist == 0)
                    return null;
                else
                    return list;
            }
            else
                return null;
        }

        public List<string>[] qQuestionsMore(string username, string lesson, List<int> difs)
        {
                int exist = 0;
                if (connection() == true)
                {
                    List<string>[] list = new List<string>[4];
                    list[0] = new List<string>();
                    list[1] = new List<string>();
                    list[2] = new List<string>();
                    list[3] = new List<string>();
                    string query = "";
                    foreach(int dif in difs)
                    {                   

                        query = "Select Q.*, U.name From questions Q JOIN units U ON Q.unit_id=U.id where Q.owner='" + username + "' and Q.lesson='" + lesson + "' and Q.dif=" + dif;

                        MySqlCommand cmd = new MySqlCommand(query, dbcon);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        Console.WriteLine(query);
                        while (dataReader.Read())
                        {
                            list[0].Add(dataReader["text"] + "");
                            list[1].Add(dataReader["lesson"] + "");
                            list[2].Add(dataReader["name"] + "");
                            list[3].Add(dataReader["dif"] + "");
                            exist++;
                        }
                        dataReader.Close();
                    }
                    if (exist == 0)
                        return null;
                    else
                        return list;
                }
                else
                    return null;
        }

        public List<string>[] qQuestionsMore(string username, string lesson, List<string> units)
        {
            int exist = 0;
            if (connection() == true)
            {
                List<string>[] list = new List<string>[4];
                int unit_id;
                list[0] = new List<string>();
                list[1] = new List<string>();
                list[2] = new List<string>();
                list[3] = new List<string>();
                string query = "";
                foreach (string unit in units)
                {
                    unit_id = convertUnit(unit, username, lesson);
                    query = "Select Q.*, U.name From questions Q JOIN units U ON Q.unit_id=U.id where Q.owner='" + username + "' and Q.lesson='" + lesson + "' and Q.unit_id=" + unit_id;

                    MySqlCommand cmd = new MySqlCommand(query, dbcon);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    Console.WriteLine(query);
                    while (dataReader.Read())
                    {
                        list[0].Add(dataReader["text"] + "");
                        list[1].Add(dataReader["lesson"] + "");
                        list[2].Add(dataReader["name"] + "");
                        list[3].Add(dataReader["dif"] + "");
                        exist++;
                    }
                    dataReader.Close();
                }
                if (exist == 0)
                    return null;
                else
                    return list;
            }
            else
                return null;
        }

        public List<string> qAnswers(string question, string unit, string username, string lesson)
        {
            int exist = 0;
            if (connection() == true)
            {
                List<string> list = new List<string>();
                int id_que = convertQuestion(question, convertUnit(unit, username, lesson), username, lesson);
                string query = "Select * From answers where id_q=" + id_que;
                MySqlCommand cmd = new MySqlCommand(query, dbcon);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list.Add(dataReader["text"] + "");
                    exist++;
                }
                dataReader.Close();
                if (exist == 0)
                    return null;
                else
                    return list;
            }
            else
                return null;
        }

        //Επιστροφή των τίτλων των μαθημάτων του συνδεδεμένου χρήστη σε λιστα
        public List<string> qLessons(string username)
        {
            int exist = 0;
            if (connection() == true)
            {
                List<string> list = new List<string>();

                string query = "Select * From lessons where owner='" + username + "'";
                MySqlCommand cmd = new MySqlCommand(query, dbcon);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list.Add(dataReader["name"] + "");
                    exist++;
                }
                dataReader.Close();
                if (exist == 0)
                    return null;
                else
                    return list;
            }
            else
                return null;
        }

        public string qLessonDesc(string username, string lesson)
        {
            int exist = 0;
            if (connection() == true)
            {
                List<string> list = new List<string>();
                string query = "Select description From lessons where owner='" + username + "' and name='" + lesson + "'";
                MySqlCommand cmd = new MySqlCommand(query, dbcon);
                return cmd.ExecuteScalar() + "";              
            }
            else
                return null;
        }

        //Επιστροφή των ενοτήτων ενός μαθήματος του συνδεδεμένου χρήστη σε λιστα
        public List<string> qUnits(string owner, string lesson)
        {
            int exist = 0;
            if (connection() == true)
            {
                List<string> list = new List<string>();

                string query = "Select * From units where owner='" + owner + "' and lesson='" + lesson + "'";
                MySqlCommand cmd = new MySqlCommand(query, dbcon);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list.Add(dataReader["name"] + "");
                    exist++;
                }
                dataReader.Close();
                if (exist == 0)
                    return null;
                else
                    return list;
            }
            else
                return null;
        }

        public List<string> qTest(string owner, string lesson)
        {
            int exist = 0;
            if (connection() == true)
            {
                List<string> list = new List<string>();

                string query = "Select distinct name From tests where owner='" + owner + "' and lesson='" + lesson +"'";
                MySqlCommand cmd = new MySqlCommand(query, dbcon);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list.Add(dataReader["name"] + "");
                    exist++;
                }
                dataReader.Close();
                if (exist == 0)
                    return null;
                else
                    return list;
            }
            else
                return null;
        }

        public List<string>[] qTest(string owner, string lesson, string name)
        {
            int exist = 0;
            if (connection() == true)
            {
                List<string>[] list = new List<string>[3];
                list[0] = new List<string>();
                list[1] = new List<string>();
                list[2] = new List<string>();
                List<int> listint = new List<int>();
                string query = "Select id_q From tests where owner='" + owner + "' and lesson='" + lesson + "' and name='" + name + "'";
                MySqlCommand cmd = new MySqlCommand(query, dbcon);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    listint.Add(int.Parse(dataReader["id_q"] + ""));
                    exist++;
                }
                dataReader.Close();
                if (exist == 0)
                    return null;
                foreach (int id_q in listint)
                {
                    query = "Select Q.text, Q.lesson, U.name From questions Q join units U ON Q.unit_id=U.id where Q.id=" + id_q;
                    Console.WriteLine(query);
                    cmd = new MySqlCommand(query, dbcon);
                    dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        list[0].Add(dataReader["text"] + "");
                        list[1].Add(dataReader["name"] + "");
                        list[2].Add(dataReader["lesson"] + "");
                        exist++;
                    }
                    
                    dataReader.Close();
                }
                return list;
            }
            else
                return null;
        }

        //Καταχώρηση ερώτησης στην βάση + τις απαντησεις της
        public int iQuestion(string username, string question, List<string> answers, string lesson, string unit, int dif)
        {
            if (connection() == true)
            {
                try
                {
                    List<string> list = new List<string>();
                    int unit_id = convertUnit(unit, username, lesson);
                    if (unit_id == -2)
                        return 0;
                    else if (unit_id == -1)
                        return -1;
                    else
                    {
                        int exist = 0;
                        string queryex = "Select * From questions where owner='" + username + "' and lesson='" + lesson + "' and unit_id=" + unit_id + " and text='" + question + "'";
                        Console.WriteLine(queryex);
                        MySqlCommand cmdex = new MySqlCommand(queryex, dbcon);
                        MySqlDataReader dataReader = cmdex.ExecuteReader();

                        while (dataReader.Read())
                        {
                            exist++;
                        }
                        dataReader.Close();
                        if (exist != 0)
                            return -5;
                        string query = "Insert into questions values (NULL, '" + question + "', '" + username + "', '" + lesson + "', " + unit_id + ", " + dif + ")";
                        Console.WriteLine(query);
                        MySqlCommand cmd = new MySqlCommand(query, dbcon);

                        cmd.ExecuteNonQuery();

                        int id_que = convertQuestion(question,unit_id, username, lesson);
                        query = "";
                        for (int i=0; i < answers.Count; i++)
                        {
                            query = "Insert into answers values(NULL, '" + answers.ElementAt(i) + "', " + id_que + ", 0)";
                            cmd = new MySqlCommand(query, dbcon);
                            cmd.ExecuteNonQuery();
                        }
                        return 1;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;

        }

        public int iAnswer(string username, string lesson, string unit, string question, string text)
        {
            if (connection() == true)
            {
                try
                {
                    int unit_id = convertUnit(unit, username, lesson);
                    if (unit_id == -2)
                        return 0;
                    else if (unit_id == -1)
                        return -1;
                    else
                    {
                        int exist = 0;
                        int id_q = convertQuestion(question, unit_id, username, lesson);
                        string queryex = "Select * From answers where id_q=" + id_q + " and text='" + text + "'";
                        Console.WriteLine(queryex);
                        MySqlCommand cmdex = new MySqlCommand(queryex, dbcon);
                        MySqlDataReader dataReader = cmdex.ExecuteReader();
                        while (dataReader.Read())
                        {
                            exist++;
                        }
                        dataReader.Close();
                        if (exist != 0)
                            return -5;
                        string query = "Insert into answers values (NULL, '" + text + "', " + id_q + ", 0)";
                        Console.WriteLine(query);
                        MySqlCommand cmd = new MySqlCommand(query, dbcon);

                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;

        }

        public int iLesson(string username, string lesson, string desc)
        {
            if (connection() == true)
            {
                try
                {
                    int exist = 0;
                    string queryex = "Select * From lessons where owner='" + username + "' and name='" + lesson + "'";
                    Console.WriteLine(queryex);
                    MySqlCommand cmdex = new MySqlCommand(queryex, dbcon);
                    MySqlDataReader dataReader = cmdex.ExecuteReader();

                    while (dataReader.Read())
                    {
                        exist++;
                    }
                    dataReader.Close();
                    if (exist != 0)
                        return -5;
                    string query = "Insert into lessons values ('" + lesson + "', '" + username + "', '" + desc +"')";
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }

        public int iUnit(string unit, string username, string lesson)
        {
            if (connection() == true)
            {
                try
                {
                    int exist = 0;
                    string queryex = "Select * From units where owner='" + username + "' and lesson='" + lesson + "' and name='" + unit + "'";
                    Console.WriteLine(queryex);
                    MySqlCommand cmdex = new MySqlCommand(queryex, dbcon);
                    MySqlDataReader dataReader = cmdex.ExecuteReader();

                    while (dataReader.Read())
                    {
                        exist++;
                    }
                    dataReader.Close();
                    if (exist != 0)
                        return -5;
                    string query = "Insert into units values (NULL, '" + unit + "', '" + username + "', '" + lesson + "')";
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }

        public int iTest(List<string> questions, string username, string lesson, string name)
        {
            if (connection() == true)
            {
                try
                {
                    int existex = 0;
                    string queryex = "Select distinct * From tests where owner='" + username + "' and name='" + name + "' and lesson='" + lesson + "'";
                    Console.WriteLine(queryex);
                    MySqlCommand cmdex = new MySqlCommand(queryex, dbcon);
                    MySqlDataReader dataReaderex = cmdex.ExecuteReader();

                    while (dataReaderex.Read())
                    {
                        existex++;
                    }
                    dataReaderex.Close();
                    if (existex != 0)
                        return -5;
                    int question = 0;
                    int unit_id = 0;
                    Console.WriteLine(questions.Count.ToString());    
                    for (int i=0; i < questions.Count; i++)
                    {
                            string queryUnit = "select unit_id, id from questions where text='" + questions.ElementAt(i) + "' and owner='" + username + "' and lesson='" + lesson + "'";
                            MySqlCommand cmdUnit = new MySqlCommand(queryUnit, dbcon);
                            MySqlDataReader dataReader = cmdUnit.ExecuteReader();
                            int exist = 0;
                            while (dataReader.Read())
                            {
                                unit_id = int.Parse(dataReader["unit_id"] + "");
                                question = int.Parse(dataReader["id"] + ""); 
                                exist++;
                            }
                            dataReader.Close();
                            if (question == 0)
                                return -2;

                            Console.WriteLine("Unit: " +unit_id);
                            Console.WriteLine("Question: " + question);

                            question = convertQuestion(questions.ElementAt(i), unit_id, username, lesson);
                            
                            
                            string query = "Insert into tests (name,id_q,owner,unit_id,lesson) values ('" + name + "', " + question + ", '" + username + "', " + unit_id + ", '" + lesson + "')";
                            Console.WriteLine(query);
                            MySqlCommand cmd = new MySqlCommand(query, dbcon);

                            cmd.ExecuteNonQuery();
                        
                    }
                       
                    return 1;
                    
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;

            
        }

        public int uUser(string username, string surname, string name, string email, string school, string gender, string birth)
        {
            if (connection() == true)
            {
                try
                {
                    string query = "Update users set surname='" + surname + "', name='" + name + "', email='" + email + "', school='" + school + "', gender='" + gender + "', birth='" + birth + "' where username='" + username + "'";
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }

        public int uLesson(string username, string desc, string newname, string oldname)
        {
            if (connection() == true)
            {
                try
                {
                    int exist = 0;
                    string queryex = "Select * From lessons where owner='" + username + "' and name='" + newname + "'";
                    Console.WriteLine(queryex);
                    MySqlCommand cmdex = new MySqlCommand(queryex, dbcon);
                    MySqlDataReader dataReader = cmdex.ExecuteReader();

                    while (dataReader.Read())
                    {
                        exist++;
                    }
                    dataReader.Close();
                    if (exist != 0)
                        return -5;
                    string query = "Update lessons set name='" + newname + "', description='" + desc + "' where owner='" + username + "' and name='" + oldname + "'";
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }

        public int uLesson(string username, string desc, string name)
        {
            if (connection() == true)
            {
                try
                {
                    string query = "Update lessons set description='" + desc + "' where owner='" + username + "' and name='" + name + "'";
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }

        public int uUnit(string username, string lesson, string newname, string oldname)
        {
            if (connection() == true)
            {
                try
                {
                    int exist = 0;
                    string queryex = "Select * From units where owner='" + username + "' and lesson='" + lesson + "' and name='" + newname + "'";
                    Console.WriteLine(queryex);
                    MySqlCommand cmdex = new MySqlCommand(queryex, dbcon);
                    MySqlDataReader dataReader = cmdex.ExecuteReader();

                    while (dataReader.Read())
                    {
                        exist++;
                    }
                    dataReader.Close();
                    if (exist != 0)
                        return -5;
                    int id = convertUnit(oldname,username,lesson);
                    string query = "Update units set name='" + newname + "' where id=" + id;
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }

        public int uQuestion(string username, string lesson, string unit, string newname, string oldname, int dif, List<string> newanswers, List<string> oldanswers)
        {
            if (connection() == true)
            {
                try
                {
                    int exist = 0;
                    int id_unit = convertUnit(unit, username, lesson);
                    int id_que = convertQuestion(oldname, id_unit, username, lesson);
                    string queryex = "Select * From questions where owner='" + username + "' and lesson='" + lesson + "' and unit_id=" + id_unit + " and text='" + newname + "'";
                    Console.WriteLine(queryex);
                    MySqlCommand cmdex = new MySqlCommand(queryex, dbcon);
                    MySqlDataReader dataReader = cmdex.ExecuteReader();

                    while (dataReader.Read())
                    {
                        exist++;
                    }
                    dataReader.Close();
                    if (exist != 0)
                        return -5;
                    string query = "Update questions set text='" + newname + "', dif=" + dif + " where id=" + id_que;
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();

                    for(int i=0; i < oldanswers.Count; i++)
                    {
                        query = "Update answers set text='" + newanswers.ElementAt(i) + "' where id_q=" + id_que + " and text='" + oldanswers.ElementAt(i) + "'";
                        cmd = new MySqlCommand(query, dbcon);
                        cmd.ExecuteNonQuery();
                    }
                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }

        public int uQuestion(string username, string lesson, string newunit, string oldunit, string newname, string oldname, int dif, List<string> newanswers, List<string> oldanswers)
        {
            if (connection() == true)
            {
                try
                {
                    int exist = 0;
                    int id_unit = convertUnit(newunit, username, lesson);
                    int id_unitold = convertUnit(oldunit, username, lesson);
                    int id_que = convertQuestion(oldname, id_unitold, username, lesson);
                    string queryex = "Select * From questions where owner='" + username + "' and lesson='" + lesson + "' and unit_id=" + id_unit + " and text='" + newname + "'";
                    Console.WriteLine(queryex);
                    MySqlCommand cmdex = new MySqlCommand(queryex, dbcon);
                    MySqlDataReader dataReader = cmdex.ExecuteReader();

                    while (dataReader.Read())
                    {
                        exist++;
                    }
                    dataReader.Close();
                    if (exist != 0)
                        return -5;
                    string query = "Update questions set text='" + newname + "', unit_id=" + id_unit + ", dif=" + dif + " where id=" + id_que;
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < oldanswers.Count; i++)
                    {
                        query = "Update answers set text='" + newanswers.ElementAt(i) + "' where id_q=" + id_que + " and text='" + oldanswers.ElementAt(i) + "'";
                        Console.WriteLine(query);
                        cmd = new MySqlCommand(query, dbcon);
                        cmd.ExecuteNonQuery();
                    }
                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }

        public int uQuestionWithoutName(string username, string lesson, string unit, string name, int dif, List<string> newanswers, List<string> oldanswers)
        {
            if (connection() == true)
            {
                try
                {
                    int id_unit = convertUnit(unit, username, lesson);
                    int id_que = convertQuestion(name, id_unit, username, lesson);
                    string query = "Update questions set dif=" + dif + " where id=" + id_que;
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < oldanswers.Count; i++)
                    {
                        query = "Update answers set text='" + newanswers.ElementAt(i) + "' where id_q=" + id_que + " and text='" + oldanswers.ElementAt(i) + "'";
                        cmd = new MySqlCommand(query, dbcon);
                        cmd.ExecuteNonQuery();
                    }
                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }

        public int uQuestionWithoutName(string username, string lesson, string newunit, string oldunit, string name, int dif, List<string> newanswers, List<string> oldanswers)
        {
            if (connection() == true)
            {
                try
                {
                    int exist = 0;
                    int id_unit = convertUnit(newunit, username, lesson);
                    int id_unitold = convertUnit(oldunit, username, lesson);
                    int id_que = convertQuestion(name, id_unitold, username, lesson);
                    
                    string query = "Update questions set unit_id=" + id_unit + ", dif=" + dif + " where id=" + id_que;
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < oldanswers.Count; i++)
                    {
                        query = "Update answers set text='" + newanswers.ElementAt(i) + "' where id_q=" + id_que + " and text='" + oldanswers.ElementAt(i) + "'";
                        cmd = new MySqlCommand(query, dbcon);
                        cmd.ExecuteNonQuery();
                    }
                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }

            public int uAnswer(string username, string lesson, string unit, string question, string newname, string oldname)
        {
            if (connection() == true)
            {
                try
                {
                    int exist = 0;
                    int id_unit = convertUnit(unit, username, lesson);
                    int id_que = convertQuestion(question, id_unit, username, lesson);
                    string queryex = "Select * From answers where id_q=" + id_que + " and text='" + newname + "'";
                    Console.WriteLine(queryex);
                    MySqlCommand cmdex = new MySqlCommand(queryex, dbcon);
                    MySqlDataReader dataReader = cmdex.ExecuteReader();
                    while (dataReader.Read())
                    {
                        exist++;
                    }
                    dataReader.Close();
                    if (exist != 0)
                        return -5;

                    string query = "Update answers set text='" + newname + "' where id_q=" + id_que + " and text='" + oldname + "'";
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }

        public int dLesson(string username, string name)
        {
            if (connection() == true)
            {
                try
                {
                    string query = "Delete from lessons where owner='" + username + "' and name='" + name + "'";
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }


        public int dUnit(string username, string lesson, string name)
        {
            if (connection() == true)
            {
                try
                {
                    int id = convertUnit(name, username, lesson);
                    string query = "Delete from units where id=" + id;
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }


        public int dQuestion(string username, string lesson, string unit, string name)
        {
            if (connection() == true)
            {
                try
                {
                    int id_unit = convertUnit(unit, username, lesson);
                    int id_que = convertQuestion(name, id_unit, username, lesson);
                    string query = "Delete from questions where id=" + id_que;
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();

                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }

        public int dAnswer(string username, string lesson, string unit, string question, string text)
        {
            if (connection() == true)
            {
                try
                {
                    int id_unit = convertUnit(unit, username, lesson);
                    int id_que = convertQuestion(question, id_unit, username, lesson);
                    string query = "Delete from answers where id_q=" + id_que + " and text='" + text + "'"; ;
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();

                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }

        public int dTest(string username, string name, string lesson)
        {
            if (connection() == true)
            {
                try
                {
                    string query = "Delete from tests where name='" + name + "' and owner='" + username + "' and lesson='" + lesson + "'";
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, dbcon);

                    cmd.ExecuteNonQuery();

                    return 1;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }
            }
            else
                return 0;
        }


        //Βοηθητική συνάρτηση που μετατρέπει το όνομα της ενότητας σε id
        public int convertUnit(string name, string owner, string lesson)
        {
            if (connection() == true)
            {
                int exist=0;
                int id = 0;
                string query = "Select id From units where name='" + name + "' and owner='" + owner + "' and lesson='" + lesson + "'";
                MySqlCommand cmd = new MySqlCommand(query, dbcon);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    id = int.Parse(dataReader["id"] + "");
                    exist++;
                }
                dataReader.Close();
                if (exist == 0)
                    return -1;
                else
                    return id;
            }
            else
                return -2;
        }

        public int convertQuestion(string text, int unit, string owner, string lesson)
        {
            if (connection() == true)
            {
                int exist = 0;
                int id = 0;
                string query = "Select id From questions where text='" + text + "' and unit_id=" + unit + " and owner='" + owner + "' and lesson='" + lesson + "'";
                Console.WriteLine(query);
                MySqlCommand cmd = new MySqlCommand(query, dbcon);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    id = int.Parse(dataReader["id"] + "");
                    exist++;
                }
                dataReader.Close();
                if (exist == 0)
                    return -3;
                else
                    return id;
            }
            else
                return -2;
        }
    }
}
