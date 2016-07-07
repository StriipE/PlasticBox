using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class CommandeGenerator
    {
        private QueryBuilder builder = new QueryBuilder("administration");
        private int currentId;
        private Random random = new Random();

        public void GenerateNewOrder(int nbCommandes, int nbProduitDemade)
        {
            Commande commande = new Commande();

            string queryCommande = "INSERT INTO _commande ( DateCommande, DateFinPreparation, DateExpedition, IdFacture, IdEtatCommande) VALUES ";
            string queryComposition = "INSERT INTO _compose VALUES ";
            string queryFacture = "INSERT INTO _facture ( montant ) VALUES ";

            int idCommande = getIDCommande() + 1;
            int idFacture = getIDFacture() + 1;

            for (int i = 0; i < nbCommandes; i++)
            {
                int[] products = new int[nbProduitDemade];
                products = selectRandomProducts(nbProduitDemade);

                commande.Date = DateTime.Now;
                commande.DateFinPreparation = DateTime.Now;
                commande.DateExpedition = DateTime.Now;
                commande.IdFacture = idFacture;
                commande.IdEtatCommande = 1; // 1 = En cours;

                queryCommande += String.Format(@"('{0}','{1}','{2}',{3},{4}), ", commande.Date.ToString("yyyy-MM-dd HH:mm:ss"), commande.DateFinPreparation.ToString("yyyy-MM-dd HH:mm:ss"), commande.DateExpedition.ToString("yyyy-MM-dd HH:mm:ss"), commande.IdFacture, commande.IdEtatCommande);
                queryComposition += creerComposition(idCommande, products);
                queryFacture += "(4.20), ";

                idCommande++;
                idFacture++;
            }

            queryCommande = queryCommande.Remove(queryCommande.Length - 2); // Enlève la virgule et l'espace en trop à la génération de la requête;
            builder.ExecuteQuery(queryCommande, "_commande", true);

            queryComposition = queryComposition.Remove(queryComposition.Length - 2); // Enlève la virgule et l'espace en trop à la génération de la requête;
            builder.ExecuteQuery(queryComposition, "_compose", true);

            queryFacture = queryFacture.Remove(queryFacture.Length - 2); // Enlève la virgule et l'espace en trop à la génération de la requête;
            builder.ExecuteQuery(queryFacture, "_facture", true);
        }

        private string creerComposition(int idCommande, int[] products)
        {
            string composition = ""; 

            for (int i = 0; i < products.Length; i++)
                composition += String.Format("({0}, {1}), ", idCommande, products[i]);

            return composition;
        }

        private int[] selectRandomProducts(int nbProduitDemade)
        {
            int[] randomProducts = new int[nbProduitDemade];
            int lastIDProduct = getIDProduit();

            for (int i = 0; i < nbProduitDemade; i++)
                randomProducts[i] = random.Next(1, lastIDProduct);

            return randomProducts;
        } 

        private int getIDCommande() // retourne l'ID de la commande précédente A FINIR
        {
            String query = "SELECT COUNT(*) FROM _commande;"; // pas sure
            int id = builder.ExecuteScalarInt(query);

            return id;
        }
        private int getIDFacture() // retourne l'ID de la commande précédente A FINIR
        {
            String query = "SELECT COUNT(*) FROM _facture;"; // pas sure
            int id = builder.ExecuteScalarInt(query);

            return id;

        }
        // Sélectionne un ID au hasard pour les clients
        private int getIDClient()
        {
            string query = "SELECT COUNT(*) FROM _client;";// pas sure
            int id = builder.ExecuteScalarInt(query);
            return id;
        }
        private int getIDProduit()
        {
            string query = "SELECT COUNT(*) FROM _produit;";// pas sure
            int id = builder.ExecuteScalarInt(query);
            return id;
        }
    }
}
