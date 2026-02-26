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
        public string Art { get; set; }
        public string Type { get; set; }
        public int Alder { get; set; }
        public int Sikkerhedskrav { get; set; }
        public int FoderplanId { get; set; }
    }

    public class DyrRepository
    {
        public List<Dyr> Read() //Læser og printer Dyr tabellen ud fra databasen ind i vores Datagrid
        {
            var dyrList = new List<Dyr>();
            using var connection = new SqliteConnection("Data Source=gruppe1.db;");
            connection.Open();
            using var command = new SqliteCommand("SELECT * FROM Dyr", connection);
            using var reader = command.ExecuteReader();
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
        }

        public void Create(Dyr d) //Metode der tilføjer nyt dyr
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

        public void Delete(Dyr d)
        {
            using var connection = new SqliteConnection("Data Source=gruppe1.db;");
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Dyr WHERE dyr_ID = @id";
            command.Parameters.AddWithValue("@id", d.Id);
            command.ExecuteNonQuery();
        }

        public void Update(Dyr d)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=gruppe1.db;");

            connection.Open();

            SqliteCommand command = new SqliteCommand("UPDATE Dyr SET art = @art, type = @type, alder = @alder, " +
                    "sikkerhedskrav = @sikkerhedskrav WHERE dyr_ID = @id", connection);
            command.Parameters.AddWithValue("@art", d.Art);
            command.Parameters.AddWithValue("@type", d.Type);
            command.Parameters.AddWithValue("@alder", d.Alder);
            command.Parameters.AddWithValue("@sikkerhedskrav", d.Sikkerhedskrav);
            command.Parameters.AddWithValue("@id", d.Id);

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
