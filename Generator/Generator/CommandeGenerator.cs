using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class CommandeGenerator
    {
      
        public string GenerateNewOrder()
        {
            List<string> products = new List<string>();
            products = SelectRandomProducts(12);




            return "";
        }

        private List<string> SelectRandomProducts(int numberOfProducts)
        {
            List<string> randomProducts = new List<string>();

            for (int i = 0; i < numberOfProducts; i++)
            {
                //TODO récupérer des serial de produit en base

            }

            return randomProducts;
        }

        private string GenererFacture()
        {
            string facture = "";
            return facture;
        }
    }
}
