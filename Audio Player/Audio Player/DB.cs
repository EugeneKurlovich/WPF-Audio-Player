using System;
using System.Data.SQLite;
using System.Windows;

namespace Audio_Player
{
    class DB
    {
        public static string login;
        private static string query;
        private static string databaseName = @"AP.db";
        private bool errors = false;
        static SQLiteConnection connectionStr = new SQLiteConnection(string.Format("Data Source={0};", databaseName));

        public DB(string q)
        {
            query = q;
        }

        public DB()
        {

        }

        public void checkReg(string log, string pass)
        {
            connectToDataBase();
            errors = true;
            if (log.Length > 10 || log.Length < 6)
            {
                errors = false;
                MessageBox.Show("Логин дoлжен быть от 6 до 10 символов.");
            }
            if (pass.Length < 6 || pass.Length > 10)
            {
                errors = false;
                MessageBox.Show("Пароль дoлжен быть от 6 до 10 символов.");
            }
            closeConnection();
        }

        public void reg(string log, string pass)
        {
            connectToDataBase();
            SQLiteCommand myCommand = new SQLiteCommand(query, connectionStr);
            myCommand.Parameters.AddWithValue("@log", log);
            myCommand.Parameters.AddWithValue("@pass", pass);

            try
            {
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Ваш профиль зарегестрирован.");
            }

            catch
            {
                MessageBox.Show("Пользователь существует!");
            }
            closeConnection();
        }

        public void connectToDataBase()
        {
            try
            {
                connectionStr.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public bool getErrors()
        {
            return errors;
        }

        public void closeConnection()
        {
            connectionStr.Close();
        }

        public void savePl(string name)
        {
            connectToDataBase();
            SQLiteCommand myCommand = new SQLiteCommand(query, connectionStr);
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@log", DB.login);
            myCommand.ExecuteNonQuery();
            closeConnection();
        }

        public bool checkUserPL(string namePl)
        {
            bool res = false;
            connectToDataBase();
            SQLiteCommand myCommand = new SQLiteCommand(query, connectionStr);
            SQLiteDataReader dr = myCommand.ExecuteReader();


            while (dr.Read())
            {
                if (dr[0].ToString() == namePl )
                {
                    res = true;
                }
            }

            closeConnection();
            return res;
        }

        public void likeSong()
        {
            connectToDataBase();



            closeConnection();
        }

        public void saveSongPl(string name, SongElements obj)
        {

            connectToDataBase();
            SQLiteCommand myCommand = new SQLiteCommand(query, connectionStr);
            myCommand.Parameters.AddWithValue("@sn", obj.song);
            myCommand.Parameters.AddWithValue("@s", obj.Singer);
            myCommand.Parameters.AddWithValue("@al", obj.album);
            myCommand.Parameters.AddWithValue("@am", obj.mark);
            myCommand.Parameters.AddWithValue("@np", name);
            myCommand.Parameters.AddWithValue("@p", obj.path);
            myCommand.Parameters.AddWithValue("@ul", DB.login);
            myCommand.ExecuteNonQuery();
            closeConnection();
        }

        public void deleteSongsPl()
        {
            connectToDataBase();
            SQLiteCommand myCommand = new SQLiteCommand(query, connectionStr);
            myCommand.ExecuteNonQuery();
            closeConnection();
        }

        public void  deletePl()
        {
            connectToDataBase();
            SQLiteCommand myCommand = new SQLiteCommand(query, connectionStr);
            myCommand.ExecuteNonQuery();
            closeConnection();
        }

        public int getCountPl()
        {
            connectToDataBase();
            SQLiteCommand myCommand = new SQLiteCommand(query, connectionStr);
            string ress =   myCommand.ExecuteScalar().ToString();
            int res = Convert.ToInt32(ress, 10);
            closeConnection();
            return res;
        }

        public void Authorization( string login, string password)
        {
            errors = false;
            connectToDataBase();
            SQLiteCommand myCommand = new SQLiteCommand(query, connectionStr);
            SQLiteDataReader dr = myCommand.ExecuteReader();


            while (dr.Read())
            {
                if (dr[0].ToString() == login && dr[1].ToString() == password)
                {
                   errors = true;
                }
            }

            if (!errors)
                MessageBox.Show("Неверный логин или пароль.");
            
            closeConnection();
        }

        public void loadPlayList()
        {
            connectToDataBase();
            SQLiteCommand myCommand = new SQLiteCommand(query, connectionStr);
            SQLiteDataReader dr = myCommand.ExecuteReader();
            Files.forPlay.Clear();
            Files.PlayList.Clear();

            while (dr.Read())
            {
                SongElements SE = new SongElements(dr[4].ToString(), dr[3].ToString());
                Files.forPlay.Add(dr[4].ToString());
                Files.PlayList.Add(SE);
            }

            closeConnection();
        }

        public void getDbPlayList()
        {
            connectToDataBase();
            SQLiteCommand myCommand = new SQLiteCommand(query, connectionStr);
            SQLiteDataReader dr = myCommand.ExecuteReader();

            while (dr.Read())
            {
              Files.allNamePl.Add(dr[0].ToString());

            }

            closeConnection();
        }
    }
}
