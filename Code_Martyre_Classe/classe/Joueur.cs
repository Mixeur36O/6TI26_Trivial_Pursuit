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



        //Construct
        public Joueur(string pseudo)
        { 
            _pseudo = pseudo;
        }

        //Méthode
        public void PlayerAug()
        {
            _nbrJoueur += 1;
        }

        public void PlayerDec()
        {
            _nbrJoueur -= 1;
        }


    }
}
