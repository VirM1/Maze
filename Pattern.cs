using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    class Pattern
    {
        private int type;

        public Pattern(List<Ouverture> liste_ouvertures)
        {
            switch (liste_ouvertures.Count)
            {
                case 1:
                    if(liste_ouvertures.Exists(element => element.getType() == 1)){
                        this.type = 3;
                    }
                    else if (liste_ouvertures.Exists(element => element.getType() == 2)){
                        this.type = 4;
                    }
                    else if (liste_ouvertures.Exists(element => element.getType() == 3)){
                        this.type = 1;
                    }
                    else if (liste_ouvertures.Exists(element => element.getType() == 4)){
                        this.type = 2;
                    }
                    break;
                case 2:
                    if (liste_ouvertures.Exists(element => element.getType() == 3)
                        && liste_ouvertures.Exists(element => element.getType() == 4))
                    {
                        this.type = 5;
                    }
                    else if (liste_ouvertures.Exists(element => element.getType() == 2)
                       && liste_ouvertures.Exists(element => element.getType() == 4))
                    {
                        this.type = 6;
                    }
                    else if (liste_ouvertures.Exists(element => element.getType() == 1)
                       && liste_ouvertures.Exists(element => element.getType() == 4))
                    {
                        this.type = 7;
                    }
                    else if (liste_ouvertures.Exists(element => element.getType() == 2)
                       && liste_ouvertures.Exists(element => element.getType() == 3))
                    {
                        this.type = 8;
                    }
                    else if (liste_ouvertures.Exists(element => element.getType() == 1)
                       && liste_ouvertures.Exists(element => element.getType() == 3))
                    {
                        this.type = 9;
                    }
                    else if (liste_ouvertures.Exists(element => element.getType() == 1)
                       && liste_ouvertures.Exists(element => element.getType() == 2))
                    {
                        this.type = 10;
                    }
                    break;
                case 3:
                    if (liste_ouvertures.Exists(element => element.getType() == 1)
                       && liste_ouvertures.Exists(element => element.getType() == 2)
                       && liste_ouvertures.Exists(element => element.getType() == 4)){
                        this.type = 11;

                    }else if (liste_ouvertures.Exists(element => element.getType() == 3)
                       && liste_ouvertures.Exists(element => element.getType() == 2)
                       && liste_ouvertures.Exists(element => element.getType() == 4)){
                        this.type = 12;
                    }
                    else if(liste_ouvertures.Exists(element => element.getType() == 1)
                       && liste_ouvertures.Exists(element => element.getType() == 2)
                       && liste_ouvertures.Exists(element => element.getType() == 3)){
                        this.type = 13;
                    }
                    else if(liste_ouvertures.Exists(element => element.getType() == 1)
                      && liste_ouvertures.Exists(element => element.getType() == 3)
                      && liste_ouvertures.Exists(element => element.getType() == 4)){
                        this.type = 14;
                    }
                    break;

                case 4:
                    this.type = 15;
                    break;
            }
           //résultat des différents switchs : le type
        }

        public int getType()
        {
            return this.type;
        }
    }
}
