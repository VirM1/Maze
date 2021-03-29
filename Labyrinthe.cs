using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;
using System.IO;

namespace Maze
{
    class Labyrinthe
    {
        private int taillex;
        private int tailley;
        private List<Case> cases_laby;

        public Labyrinthe(int x, int y)
        {
            this.taillex = x;
            this.tailley = y;
            this.cases_laby = genererMaillage(x,y);
            this.associerVoisins();
            this.genererLabyrinthe();
            this.generatePattern();
            this.GenerateImage();
        }
        /*
        public List<int> getSize()
        {
            List<int> taille = new List<int>();
            taille.Add(taillex);
            taille.Add(tailley);
            return taille;
        }*/

        public List<Case> getAllLabCase()
        {
            return this.cases_laby;
        }

        public List<Case> genererMaillage(int tx, int ty)
        {
            List<Case> maillage = new List<Case>();
            for(int y =0; y < ty; y++)
            {
                for(int x =0;x< tx; x++)
                {
                    maillage.Add(new Case(x, y));
                }
            }
            return maillage;
        }

        //addCase est inutile puisque les cases sont générées lors de la création du Maillage

        public Case getcasefromindex(int x,int y)//on récupère une case depuis les coos
        {
            return this.cases_laby[((y*(this.taillex))+x)];
        }

        public void associerVoisins()
        {
            foreach(Case element in cases_laby)
            {
                List<int> coo = element.getcoor();
                int index = ((coo[1] * (taillex))+coo[0]);
                if (coo[0] == 0 )
                {
                    if(coo[1] == 0)
                    {
                        element.addVoisins(cases_laby[index+1]);
                        element.addVoisins(cases_laby[index+taillex]);
                    }else if (coo[1] == tailley-1)
                    {
                        element.addVoisins(cases_laby[index+1]);
                        element.addVoisins(cases_laby[index - taillex]);
                    }
                    else
                    {
                        element.addVoisins(cases_laby[index+1]);
                        element.addVoisins(cases_laby[index + taillex]);
                        element.addVoisins(cases_laby[index - taillex]); 
                    }
                }else if(coo[0] == taillex - 1)
                {
                    if (coo[1] == 0)
                    {
                        element.addVoisins(cases_laby[index - 1]);
                        element.addVoisins(cases_laby[index + taillex]);
                    }
                    else if (coo[1] == tailley - 1)
                    {
                        element.addVoisins(cases_laby[index - 1]);
                        element.addVoisins(cases_laby[index - taillex]);
                    }
                    else
                    {
                        element.addVoisins(cases_laby[index - 1]);
                        element.addVoisins(cases_laby[index + taillex]);
                        element.addVoisins(cases_laby[index - taillex]);
                    }
                }
                else
                {
                    if(coo[1] == 0)
                    {
                        element.addVoisins(cases_laby[index - 1]);
                        element.addVoisins(cases_laby[index + 1]);
                        element.addVoisins(cases_laby[index + taillex]);
                    }
                    else if(coo[1] == tailley - 1)
                    {
                        element.addVoisins(cases_laby[index - 1]);
                        element.addVoisins(cases_laby[index + 1]);
                        element.addVoisins(cases_laby[index - taillex]);
                    }
                    else
                    {
                        element.addVoisins(cases_laby[index - 1]);
                        element.addVoisins(cases_laby[index + 1]);
                        element.addVoisins(cases_laby[index + taillex]);
                        element.addVoisins(cases_laby[index - taillex]);
                    }
                }

            }
        }

        public void genererLabyrinthe()
        {
            List<Case> Cvisites = new List<Case>();
            List<Case> ActualPath = new List<Case>();
            Random random = new Random();
            cases_laby[0].addOuveture(1);
            cases_laby[(taillex*tailley)-1].addOuveture(2);
            ActualPath.Add(cases_laby[0]);//Prepend("valeur") pour ajouter au tt début
            Cvisites.Add(cases_laby[0]);
            while (Cvisites.Count != cases_laby.Count)
            {
                List<Case> voisins = ActualPath[0].getVoisins();
                foreach(Case element in voisins.ToArray())
                {
                    foreach(Case voisin_el in Cvisites.ToList())
                    {
                        if (voisin_el.Equals(element))
                        {
                            voisins.Remove(element);
                            
                        }
                    }
                }
                if(voisins.Count != 0)
                {
                    Case chosen = voisins[random.Next(voisins.Count)];
                    List<int> cooComp = new List<int>();
                    List<int> cooChosen = new List<int>();
                    List<int> cooActual = new List<int>();
                    cooChosen = chosen.getcoor();
                    cooActual = ActualPath[0].getcoor();
                    cooComp.Add(cooChosen[0] - cooActual[0]);
                    cooComp.Add(cooChosen[1] - cooActual[1]);
                    if (cooComp[0] == 0)
                    {
                        if(cooComp[1] == -1)
                        {
                            //haut
                            cases_laby[cooChosen[0] + cooChosen[1] * taillex].addOuveture(4);
                            cases_laby[cooActual[0] + cooActual[1] * taillex].addOuveture(3);
                        }
                        else
                        {
                            cases_laby[cooChosen[0] + cooChosen[1] * taillex].addOuveture(3);
                            cases_laby[cooActual[0] + cooActual[1]*taillex].addOuveture(4);
                            //bas
                        }
                    }
                    else
                    {
                        if (cooComp[0] == -1)
                        {
                            //gauche
                            cases_laby[cooChosen[0] + cooChosen[1] * taillex].addOuveture(2);
                            cases_laby[cooActual[0] + cooActual[1] * taillex].addOuveture(1);
                        }
                        else
                        {
                            //droite
                            cases_laby[cooChosen[0] + cooChosen[1] * taillex].addOuveture(1);
                            cases_laby[cooActual[0] + cooActual[1] * taillex].addOuveture(2);
                        }
                    }
                    Cvisites.Add(chosen);
                    ActualPath = ActualPath.Prepend(chosen).ToList();
                    
                }
                else
                {
                    ActualPath.RemoveAt(0);
                }
            }

        }
        public void generatePattern()
        {
            foreach(Case element in cases_laby)
            {
                element.setPattern();
                if(element.getPattern().getType() == 0)
                {
                    List<int> coo = element.getcoor();
                    List<Ouverture> ouvertures = element.getOuvertures();
                    Console.WriteLine("Anomalie");
                    Console.WriteLine("x = " + coo[0]);
                    Console.WriteLine("y = " + coo[1]);
                    Console.WriteLine("Nombre d'ouvertures :" + ouvertures.Count);
                    foreach(Ouverture ouvertureindiv in ouvertures)
                    {
                        Console.WriteLine(ouvertureindiv.getType());
                    }
                }
            }
        }
        public void GenerateImage()
        {
            var bitmap = new Bitmap(13*taillex, 13*tailley);
            string repository = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                for(int y = 0; y < tailley; y++)
                {
                    for(int x = 0;x < taillex; x++)
                    {
                        Image i = Image.FromFile(repository+"\\img\\" + cases_laby[x+y*taillex].getPattern().getType()+".png");
                        g.DrawImage(i, 13 * x, 13*y, 13, 13);
                    }
                }

            }
            bitmap.Save(repository + "\\results\\"+taillex+"_"+tailley+"_"+DateTime.Now.ToString("yyyyMMdd_hhmmss") +".png");
            Console.WriteLine("Image sauvegardée");
        }
    }
}

