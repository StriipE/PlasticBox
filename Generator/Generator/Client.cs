using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Generator
{
    public class Client
    {
        private const int PHONE_DIGITS_NUMBERS = 8;

        private static string PROJECT_PATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private static string PRENOM_PATH = PROJECT_PATH + @"\..\Generator\Samples\Prenoms.txt";
        private static string NOM_PATH = PROJECT_PATH + @"\..\Generator\Samples\Noms.txt";
        private static string ADRESSE_PATH = PROJECT_PATH + @"\..\Generator\Samples\Adresses.txt";
        private static string NUMBERS = "0123456789";

        public int ID { get; set; }
        public string Adresse { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public DateTime DateInscription { get; set; }
        public int CompteClient { get; set; }
        public int TypeClient { get; set; }
        public int Pays { get; set; }


        public static String GenerateNewClient()
        {
            string xml;
            Random random = new Random();
            char[] phoneNumber = new char[PHONE_DIGITS_NUMBERS];

            XmlSerializer serializer = new XmlSerializer(typeof(Client));

            Client client = new Client();

            client.Adresse = random.Next(100).ToString() + " " + File.ReadLines(ADRESSE_PATH).Skip(random.Next(File.ReadLines(ADRESSE_PATH).Count() - 1)).Take(1).First(); // Récupère l'adresse
            client.Prenom = File.ReadLines(PRENOM_PATH).Skip(random.Next(File.ReadLines(PRENOM_PATH).Count() - 1)).Take(1).First(); // Récupère le prénom dans le dictionnaire de prénoms
            client.Nom = File.ReadLines(NOM_PATH).Skip(random.Next(File.ReadLines(NOM_PATH).Count() - 1)).Take(1).First(); // Récupère le nom dans le dictionnaire
            client.Mail = client.Prenom.ToLower() + "." + client.Nom.ToLower() + "@gmail.com";

            for (int i = 0; i < PHONE_DIGITS_NUMBERS; i++)  // Generation aléatoire du numéro de téléphone 
                phoneNumber[i] = NUMBERS[random.Next(PHONE_DIGITS_NUMBERS)];

            client.Telephone = "06" + new string(phoneNumber); 
            client.Mobile = client.Telephone;
            client.DateInscription = DateTime.Now;
            client.CompteClient = 1; // Tous les comptes client sont actifs à la génération 
            client.TypeClient = random.Next(100) <= 5 ? 1 : 2; // On génère 5% de comptes premium

            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, client);
                xml = writer.ToString();
            }

            return xml;
        }
    }
}
