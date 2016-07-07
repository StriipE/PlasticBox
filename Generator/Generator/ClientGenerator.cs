using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Generator
{
    public class ClientGenerator
    {
        private QueryBuilder builder = new QueryBuilder("administration");

        private const int PHONE_DIGITS_NUMBERS = 8;
        private const string NUMBERS = "0123456789";

        private static string PROJECT_PATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private static string PRENOM_PATH = PROJECT_PATH + @"\..\Generator\Samples\Prenoms.txt";
        private static string NOM_PATH = PROJECT_PATH + @"\..\Generator\Samples\Noms.txt";
        private static string ADRESSE_PATH = PROJECT_PATH + @"\..\Generator\Samples\Adresses.txt";

        private Random random = new Random();

        public void GenerateNewClients(int NumberOfClients)
        {
            string query = @"INSERT INTO administration._client (Adresse, Nom, Prenom, Mail, Telephone, Mobile, DateInscription, Compte, Type, Id_Pays) VALUES ";
            //  List<Client> clients = new List<Client>();
            for (int i = 0; i < NumberOfClients; i++)
            {
                Client client = new Client();

                client.Adresse = GenerationAdresse(); // Récupère l'adresse
                client.Prenom = GenerationPrenom(); // Récupère le prénom dans le dictionnaire de prénoms
                client.Nom = GenerationNom(); // Récupère le nom dans le dictionnaire
                client.Mail = client.Prenom.ToLower() + "." + client.Nom.ToLower() + "@gmail.com";
                client.Telephone = GenerationTelephone(); // Génération du numéro de téléphone
                client.Mobile = client.Telephone;
                client.DateInscription = DateTime.Now; // TODO Gérer les timestamps
                client.CompteClient = "Actif"; // Tous les comptes client sont actifs à la génération 
                client.TypeClient = GenerationTypeClient(5); // On génère 5% de comptes premium
                client.Pays = GenerationPays();

                query += String.Format(@"('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}), ", client.Adresse, client.Nom, client.Prenom, client.Mail, 
                               client.Telephone, client.Mobile, client.DateInscription.ToString("yyyy-MM-dd HH:mm:ss"), client.CompteClient, client.TypeClient, client.Pays);
              
                //   clients.Add(client);
            }
            query = query.Remove(query.Length - 2); // Enlève la virgule et l'espace en trop à la génération de la requête;

            builder.ExecuteQuery(query, "_client", true);
            //return clients;
        }

        private string GenerationAdresse()
        {
            string adresse = (random.Next(100) + 1).ToString() + " " + File.ReadLines(ADRESSE_PATH).Skip(random.Next(File.ReadLines(ADRESSE_PATH).Count() - 1)).Take(1).First();
            return adresse; 
        }
        private string GenerationPrenom()
        {
            string prenom = File.ReadLines(PRENOM_PATH).Skip(random.Next(File.ReadLines(PRENOM_PATH).Count() - 1)).Take(1).First();
            return prenom;
        }
        private string GenerationNom()
        {
            string nom = File.ReadLines(NOM_PATH).Skip(random.Next(File.ReadLines(NOM_PATH).Count() - 1)).Take(1).First();
            return nom;
        }
        private string GenerationTelephone()
        {
            char[] phoneNumber = new char[PHONE_DIGITS_NUMBERS];

            for (int i = 0; i < PHONE_DIGITS_NUMBERS; i++)  // Generation aléatoire du numéro de téléphone 
                phoneNumber[i] = NUMBERS[random.Next(PHONE_DIGITS_NUMBERS)];

            string telephone = "06" + new string(phoneNumber);
            return telephone;
        }
        private string GenerationTypeClient(int pourcentagePremium)
        {
            string typeClient = random.Next(100) + 1 <= pourcentagePremium ? "Premium" : "Normal";
            return typeClient;
        }
        private int GenerationPays()
        {
            // TODO trouver dynamiquement le nombre de pays en base
            int paysClient = random.Next(5) + 1;
            return paysClient;
        }

    }
}
