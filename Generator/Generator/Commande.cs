using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateFinPreparation { get; set; }
        public DateTime DateExpedition { get; set; }
        public int IdClient { get; set; }
        public int IdFacture { get; set; }
        public int IdEtatCommande { get; set; }
    }
}
