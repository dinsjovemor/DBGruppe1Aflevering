using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.Data.Sqlite;

namespace DBgruppe1Zoo.Repositories
{
    public class PersonRepository
    {

        string path = Path.Combine(AppContext.BaseDirectory, "gruppe1.db");


        public PersonRepository()
        {
        }

        public void GetAll()
        {
            try
            {
                SqliteConnection connection = new SqliteConnection($"Data Source=gruppe1.db;");
                connection.Open();



                SqliteCommand command = new SqliteCommand("SELECT * FROM animals", connection);

                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Debug.WriteLine($"{reader["name"]}");
                }

                connection.Close();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
