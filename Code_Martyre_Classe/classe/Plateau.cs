using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Limet_Maxence_CodagePion.Classe
{
    internal class Plateau
    {
        //Attributs
<<<<<<< HEAD
        private int _nbrJoueur;
=======
        private PaquetCarte _paquetCartes;
        private Joueur _joueurs;
        private int _nbrJoueurs;
        private De _leDe;
        private Pion _pions;
        private Point _points;
>>>>>>> 11be9d2c315736f734541120d29a24459551633d

        public int NbrJoueur
        {

            get { return _nbrJoueur; }
            set { _nbrJoueur = value; }
        }

<<<<<<< HEAD
        //Constructeur
        public Plateau(int nbrJoueur)
        {
            _nbrJoueur += nbrJoueur;
=======
        public int NbrJoueur
        {
            get { return _nbrJoueurs; }
            set { _nbrJoueurs = value; }
>>>>>>> 11be9d2c315736f734541120d29a24459551633d
        }



        //Constructeur
        //public Plateau(PaquetCarte paquetCarte, Joueur joueurs, De leDe, Pion pions, Point points)
        //{
        //    _paquetCartes = paquetCarte;
        //    _joueurs = joueurs;
        //    _leDe = leDe;
        //    _pions = pions;
        //    _points = points;
        //}

        //Méthodes

        public int PlayerInc()
        {
            _nbrJoueur += 1;
            return _nbrJoueur;
        }

        public int PlayerDec()
        {
            _nbrJoueur -= 1;
            return _nbrJoueur;
        }

        public void PlayerInc()
        {

        }

        public void PlayerDec()
        {

        }

        
    }
}
