using Connector;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class QueryBuilder : IDataManager
    {
        private Linker Linker = new Linker();
        private string databaseName;

        public QueryBuilder(string _databaseName)
        {
            databaseName = _databaseName;
        }

        public DataSet ExecuteQuery(string query, string nomTable, bool isNonQuery)
        {
            MySqlConnection Connection = Linker.ConnectToDatabase(databaseName);
            MySqlDataAdapter Adapter;
            DataSet DataSet = new DataSet();
            try
            {
                Connection.Open();
                if (isNonQuery)
                {
                    MySqlCommand oCommand = new MySqlCommand(query, Connection); // Insertion en base avec une commande
                    oCommand.ExecuteNonQuery();
                    DataSet = null;
                }
                else
                {
                    Adapter = new MySqlDataAdapter(query, Connection);
                    Adapter.Fill(DataSet, nomTable); // Remplissage du dataset avec le résultat de la requête
                }
                Connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur SQL:\n" + e.Message);
                Console.WriteLine("La connexion n'a pas été établie");
            }

            return DataSet;
        }
    }
}

