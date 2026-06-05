using Code_Martyre_Classe.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limet_Maxence_CodagePion.Classe
{
    internal class Carte
    {
        //Attributs

        //Propriétées

        //Constructeur
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
        public void QuestionHist(out DataSet qHist)
        {
            bdd.PrendreQuestionHist(out qHist);
        }
        public void ReponseHist(out DataSet rHist)
        {
            bdd.PrendreReponseHist(out rHist);
        }
        public void QuestionSc(out DataSet qSc)
        {
            bdd.PrendreQuestionSc(out qSc);
        }
        public void ReponseSc(out DataSet rSc)
        {
            bdd.PrendreReponseSc(out rSc);
        }
        public void QuestionGeo(out DataSet qGeo)
        {
            bdd.PrendreQuestionSc(out qGeo);
        }
        public void ReponseGeo(out DataSet rGeo)
        {
            bdd.PrendreReponseSc(out rGeo);
        }
    }
}