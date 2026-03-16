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

        //Props
        public int Face
        {
            get { return _face; }
            set { _face = value; }
        }

        //Construct
        public De(int face)
        {
            _face = face;
        }

        //Méthode
        public int Btn_DonneUnNbrAleaD()
        {
            Random rnd = new Random();
            _face = rnd.Next(1, 7);
            return _face;
        }

    }
}
