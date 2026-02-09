using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limet_Maxence_CodagePion.Classe
{
    internal class Carte
    {
        //Attributs
        private string _question;

        //Propriétées
        public string Question
        {
            get { return _question; }
        }

        public string question
        {
            get { return _question; }
        }

        //Constructeur
        public Carte(string couleur, string question)/* string couleur*//*base (couleur)*/
        {
            _question = question;
        }

        //Méthodes

    }
}
