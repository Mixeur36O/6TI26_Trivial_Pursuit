using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Limet_Maxence_CodagePion.Classe
{
    internal class Plateau
    {
        //Attributs
        private int _nbrJoueur;

        public int NbrJoueur
        {

            get { return _nbrJoueur; }
            set { _nbrJoueur = value; }
        }

        //Constructeur
        public Plateau(int nbrJoueur)
        {
            _nbrJoueur += nbrJoueur;
        }

        //Méthodes

        public int PlayerInc()
        {
            _nbrJoueur += 1;
            return _nbrJoueur;
        }

        public int PlayerDec()
        {
            _nbrJoueur -= 1;
            return _nbrJoueur;
        }
        
    }
}
