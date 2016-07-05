using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class Client
    {
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
    }
}
