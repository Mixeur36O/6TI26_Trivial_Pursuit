using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limet_Maxence_CodagePion.Classe
{
    internal class Plateau
    {
        //Attributs
        private PaquetCarte _paquetCartes;
        private Joueur _joueurs;
        private De _leDe;
        private Pion _pions;
        private Point _points;

        //Propriétées
        public PaquetCarte PaquetCartes
        {
            get { return _paquetCartes; }
        }
        public Joueur Joueurs
        {
            get { return _joueurs; }
            set { _joueurs = value; }
        }
        public De LeDe
        {
            get { return _leDe; }
            set { _leDe = value; }
        }
        public Pion Pions
        {
            get { return _pions; }
            set { _pions = value; }
        }
        public Point Points
        {
            get { return _points; }
            set { _points = value; }
        }

        //Constructeur
        public Plateau(PaquetCarte paquetCarte, Joueur joueurs, De leDe, Pion pions, Point points)
        {
            _paquetCartes = paquetCarte;
            _joueurs = joueurs;
            _leDe = leDe;
            _pions = pions;
            _points = points;
        }

        //Méthodes
        public void LancerDe()
        {

            int[] tabDe = new int[6];
            Random alea = new Random();
            int i;
            for (i = 0; i < 6; i++)
            {
                tabDe[i] = alea.Next(1, 7);
            }

        }
        
        public bool VerifEntre()
        { 

        }

        public void AjouterPoint()
        {

        }

        public string AfficherCarte(PaquetCarte carte)
        {

        }
    }
}
