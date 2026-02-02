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


    }
}
