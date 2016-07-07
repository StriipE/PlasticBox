using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Connector
{
    public class Linker
    {
        private const string CONNECTION_STRING = @"server=localhost;uid=root;pwd=;database=";
        private MySqlConnection Connection;

        public MySqlConnection ConnectToDatabase(string databaseName)
        {
            Connection = new MySqlConnection();

            switch(databaseName)
            {
                case "administration":
                case "production":
                case "exportation":
                case "conditionnement":
                    Connection.ConnectionString = CONNECTION_STRING + databaseName + ";";
                    break;
                default:
                    throw new ArgumentException(@"Cette base de données n'existe pas");
            }
            return Connection;
        }


        //static void Main(string[] args)
        //{
        //    // Display the number of command line arguments:
        //    System.Console.WriteLine(args.Length);
        //    Linker link = new Linker();

        //    DataSet setDATA = link.recupDataSet("Select * from _commandePiece ", "_commandepiece");


        //    string query = "UPDATE `production`.`_commandepiece` SET `Id_CommandePiece` = 3, `Nb_CommandePiece` = 45000 WHERE `Id_CommandePiece` = 3; ";


        //    link.executeNonQuery(query, "_commandepiece");
        //    setDATA = link.recupDataSet("Select Nb_CommandePiece from _commandePiece ", "_commandepiece");

        //    link.PrintRows(setDATA);
        //    Console.ReadLine();
        //}


    }
}
