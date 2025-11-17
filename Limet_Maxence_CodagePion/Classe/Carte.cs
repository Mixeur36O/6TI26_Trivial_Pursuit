using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limet_Maxence_CodagePion.Classe
{
    internal class Carte : Pion
    {
        //Attributs
        private string _question;

        //Propriétées
        public string Couleur
        {
            get { return _couleur; }
        }

        public string question
        {
            get { return _question; }
        }

        //Constructeur
        public Carte(string couleur, string question) : base (couleur)
        {
            _question = question;
        }

        //Méthodes

    }
}
