using Code_Martyre_Classe.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limet_Maxence_CodagePion.Classe
{
    internal class CarteM
    {
        //Attributs

        //Propriétées

        //Constructeur
        public CarteM() 
        { 
        }
        connectDB bdd = new connectDB();

        //Méthodes
        public void QuestionMath(out DataSet qMath)
        {
            bdd.PrendreQuestionMath(out qMath);
        }

        public void ReponseMath(out DataSet rMAth)
        {
            bdd.PrendreReponseMath(out rMAth);
        }

        public void QuestionFr(out DataSet qFr)
        {
            bdd.PrendreQuestionFr(out qFr);
        }

        public void ReponseFr(out DataSet rFr)
        {
            bdd.PrendreReponseFr(out rFr);
        }

        public void QuestionEn(out DataSet qEn)
        {
            bdd.PrendreQuestionEn(out qEn);
        }

        public void ReponseEn(out DataSet rEn)
        {
            bdd.PrendreReponseEn(out rEn);
        }
    }
}
