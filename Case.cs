using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    class Case
    {
        private Pattern pattern;
        private int coox;
        private int cooy;
        private List<Case> voisins;
        private List<Ouverture> liste_ouvertures;


        public Case(int x, int y)
        {
            this.coox = x;
            this.cooy = y;
            this.voisins = new List<Case>();
            this.liste_ouvertures = new List<Ouverture>();
            /*on definit les différentes coordonnées
             *et le pattern de base, les voisins seront
             *ajoutés plus tard ainsi que les ouvertures.
             */
        }

        public List<int> getcoor()
        {
            List<int> coo = new List<int>();
            coo.Add(coox);
            coo.Add(cooy);
            return coo;
        }

        public void addVoisins(Case nouveauVoisin)
        {
            this.voisins.Add(nouveauVoisin);
            /*On ajoute un voisin à la case
             * cette fonction est appelée à la génération du labyrinthe
             */

        }
        
        /*Pour l'instant on a pas de méthode pour suppr un voisin pour la simple
         * et bonne raison que c'est une méthode éphémère (pour l'instant)
         * vu que ça supprime que sur le chemin et pas sur le côté par exemple
         * On continue donc sans méthode pour suppr(pour l'instant.).
         */

        public List<Case> getVoisins()
        {
            return this.voisins;//On récup les voisins de la case
        }

        public void addOuveture(int dir)
        {
            this.liste_ouvertures.Add(new Ouverture(dir));
            /*on ajoute une nouvelle ouverture
             * à la collection destinées à générer un pattern
             */
        }

        public List<Ouverture> getOuvertures()
        {
            return this.liste_ouvertures;
            /*On récup la liste des ouvertures de la case 
             * pour ensuite générer le pattern
             */
        }

        public void setPattern()
        {
            this.pattern = new Pattern(liste_ouvertures);//on génère un nouveau pattern grâce aux ouvertures
        }

        public Pattern getPattern()
        {
            return this.pattern;
        }
    }
}
