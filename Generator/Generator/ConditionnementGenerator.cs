using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class ConditionnementGenerator
    {
        private Random random;
        public void GenererConditionnement(Produit produit)
        {
            Conditionnement conditionnement = new Conditionnement();
            conditionnement.IdLigne = SelectionnerLigneProd();


            GenererActivitesConditionnement(conditionnement.IdLigne);
        }

        public void GenererActivitesConditionnement(int IdLigne)
        {
            switch(IdLigne)
            {
                case 1:
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }

        public int SelectionnerLigneProd() // Génère l'ID d'une ligne de conditionnement
        {
            int IdLigne = random.Next(3) + 1;
            return IdLigne;
        }
    }
}
