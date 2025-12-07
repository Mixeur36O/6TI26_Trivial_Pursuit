using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limet_Maxence_CodagePion.Classe
{
    internal class De
    {
        
        //Méthode
        public void Btn_DonneUnNbrAleaD(out int randomD)
        {
            Random rnd = new Random();
            randomD = rnd.Next(1, 7);

        }
        
    }
}
