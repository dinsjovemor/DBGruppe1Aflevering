using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Text;

namespace DBgruppe1Zoo.Repositories
{
    public class Dyr
    {
        public string Art {  get; set; }
        public string Type { get; set; }
        public int Alder { get; set; }
        public int Sikkerhedskrav { get; set; }
    }

    public class DyrRepository
    {

        string path = Path.Combine(AppContext.BaseDirectory, "gruppe1.db");

        public List<Dyr> GetAll()
        {
            SqliteConnection connection = new SqliteConnection($"Data Source=gruppe1.db;");
            connection.Open();

            SqliteCommand command = new SqliteCommand("SELECT * FROM Dyr", connection);
            SqliteDataReader reader = command.ExecuteReader();

            List<Dyr> dyrList = new List<Dyr>();
            while (reader.Read())
            {
                Dyr d = new Dyr();
                d.Art = reader["art"] as string;
                d.Type = reader["type"] as string;
                d.Alder = Convert.ToInt32(reader["alder"]);
                d.Sikkerhedskrav = Convert.ToInt32(reader["sikkerhedskrav"]);

                dyrList.Add(d);
            }
            return dyrList;

            connection.Close();

        }
    }
}
