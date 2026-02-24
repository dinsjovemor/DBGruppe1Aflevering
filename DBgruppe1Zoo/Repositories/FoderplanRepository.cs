using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;

namespace DBgruppe1Zoo.Repositories
{
    internal class FoderplanRepository
    {
        string path = Path.Combine(AppContext.BaseDirectory, "gruppe1.db");


        public FoderplanRepository()
        {
        }

        public void GetAll()
        {
            try
            {
                SqliteConnection connection = new SqliteConnection($"Data Source=gruppe1.db;");
                connection.Open();



                SqliteCommand command = new SqliteCommand("SELECT * FROM Foderplan", connection);

                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Debug.WriteLine($"{reader["foder"]}");
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
