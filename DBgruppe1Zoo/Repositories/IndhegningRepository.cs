using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;

namespace DBgruppe1Zoo.Repositories
{
    internal class IndhegningRepository
    {
        string path = Path.Combine(AppContext.BaseDirectory, "gruppe1.db");


        public IndhegningRepository()
        {

        }

        public void GetAll()
        {
            try
            {
                SqliteConnection connection = new SqliteConnection($"Data Source=gruppe1.db;");
                connection.Open();



                SqliteCommand command = new SqliteCommand("SELECT * FROM Indhegning", connection);

                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Debug.WriteLine($"{reader["type"]}");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }


    }
}
