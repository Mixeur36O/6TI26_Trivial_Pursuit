using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limet_Maxence_CodagePion.Classe
{
    internal class De
    {
        //Attributs 
        private int _face;

        //Propriétées

        public int Face
        {
            get { return _face; }
            set { _face = value; }
        }

        //Constructeur

        public De(int face)
        {
            _face = face;
        }

        //Méthode
    }
}
