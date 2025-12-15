using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limet_Maxence_CodagePion.Classe
{
    internal class Joueur
    {
        //Attributs
        private string _pseudo;
        private int _nbrJoueur;

        //Props

        public string Pseudo
        {
            get { return _pseudo; }
            set { _pseudo = value; }
        }

        public int NbrJoueur
        {
            get { return _nbrJoueur; }
            set { _nbrJoueur = value; }
        }


        //Construct
        public Joueur(string pseudo, int nbrJoueur)
        {
            _pseudo = pseudo;
            _nbrJoueur = nbrJoueur;
        }

        //Méthode

    }
}
