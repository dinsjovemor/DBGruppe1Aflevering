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
        public int Id { get; set; }
        public string Art {  get; set; }
        public string Type { get; set; }
        public int Alder { get; set; }
        public int Sikkerhedskrav { get; set; }
        public int FoderplanId { get; set; }
    }

    public class DyrRepository
    {
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
                d.Id = Convert.ToInt32(reader["dyr_ID"]);
                d.Art = reader["art"] as string;
                d.Type = reader["type"] as string;
                d.Alder = Convert.ToInt32(reader["alder"]);
                d.Sikkerhedskrav = Convert.ToInt32(reader["sikkerhedskrav"]);
                d.FoderplanId = Convert.ToInt32(reader["foderplan_ID"]);

                dyrList.Add(d);
            }
            return dyrList;

            connection.Close();

        }

        public void Add(Dyr d)
        {
            SqliteConnection connection = new SqliteConnection($"Data Source=gruppe1.db;");
            connection.Open();

            SqliteCommand command = new SqliteCommand("INSERT INTO Dyr (art, type, alder, sikkerhedskrav, foderplan_ID) VALUES (@art, @type, @alder, @sikkerhedskrav, @foderplan_ID)", connection);
            command.Parameters.AddWithValue("@art", d.Art);
            command.Parameters.AddWithValue("@type", d.Type);
            command.Parameters.AddWithValue("@alder", d.Alder);
            command.Parameters.AddWithValue("@sikkerhedskrav", d.Sikkerhedskrav);
            command.Parameters.AddWithValue("@foderplan_ID", d.FoderplanId);

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
