using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Limet_Maxence_CodagePion.Classe
{
    static class Plateau
    {
        //Attributs

        public static int nbrJoueur = 2;

        //Méthodes

        public static int PlayerInc()
        {
            nbrJoueur += 1;
            return nbrJoueur;
        }

        public static int PlayerDec()
        {
            nbrJoueur -= 1;
            return nbrJoueur;
        }


    }
}
