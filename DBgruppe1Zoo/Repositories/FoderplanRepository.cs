using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;

namespace DBgruppe1Zoo.Repositories
{
    public class Foderplan
    {
        public int foderplanID {  get; set; }
        public string foder {  get; set; }
        public string tid { get; set; }
    }

    public class FoderplanRepository
    {
        string path = Path.Combine(AppContext.BaseDirectory, "gruppe1.db");
        public List<Foderplan> GetAll()
        {
            SqliteConnection connection = new SqliteConnection($"Data Source=gruppe1.db;");
            connection.Open();

            SqliteCommand command = new SqliteCommand("SELECT * FROM Foderplan", connection);
            SqliteDataReader reader = command.ExecuteReader();

            List<Foderplan> foderplanList = new List<Foderplan>();
            while (reader.Read())
            {
                Foderplan fp = new Foderplan();
                fp.foderplanID = Convert.ToInt32(reader["foderplan_ID"]);
                fp.foder = reader["foder"] as string;
                fp.tid = reader["tid"] as string;

                foderplanList.Add(fp);
            }
            return foderplanList;

            connection.Close();

        }
    }

}

