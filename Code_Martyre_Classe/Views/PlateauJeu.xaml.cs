using Code_Martyre_Classe.Config;
using Limet_Maxence_CodagePion.Classe;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Code_Martyre_Classe.Views
{
    /// <summary>
    /// Logique d'interaction pour PlateauJeu.xaml
    /// </summary>
    public partial class PlateauJeu : Page
    {
        TextBlock[,] txtBlock = new TextBlock[13, 13];
        Button[] txtBCarte = new Button[6];
        TextBlock[] txtBPseudo = new TextBlock[4];
        TextBlock txtDe = new TextBlock();
        De cDe = new De(6);
        connectDB bdd = new connectDB();
        DataSet donnees = new DataSet();
        Image imgPion = new Image();
        Button buttonLeave = new Button();
        private Image[] pions;
        private int nbrJoueurs;
        private int joueurActuel = 0;


        private int currentPlayerIndex = 0; // Ajout d'un index pour le joueur courant

        public PlateauJeu()
        {
            InitializeComponent();
            pions = new Image[Plateau.nbrJoueur];
            prepareInterface();
            DeplacerPion(imgPion, 0); 
        }

        


        public void prepareInterface()
        {
            //Instancier variables et tableau
            int indicateurLC = 0;
            int indicateurLJ = 15;
            Button de = new Button();
            
            BitmapImage itn = new BitmapImage();
            itn.BeginInit();
            itn.UriSource = new Uri("assets/ITN-Logo-quadri-DEF.jpg", UriKind.Relative);


            itn.EndInit();
            StackPanel stkBlock = new StackPanel();
            grdPlateau.Background = new LinearGradientBrush(
                    Color.FromRgb(30, 30, 60),
                    Color.FromRgb(15, 15, 30),
                    new System.Windows.Point(0, 0),
                    new System.Windows.Point(0, 1)
            );

            //Faire le dé et les chiffres
            de.Content = "Lancer le Dé";
            de.FontSize = 25;
            de.Height = 100;
            de.Width = 250;
            de.FontWeight = FontWeights.Bold;
            de.Click += new RoutedEventHandler(Btn_De);
            txtDe.Background = new SolidColorBrush(Color.FromArgb(30, 255, 255, 255));
            txtDe.Foreground = Brushes.White;
            txtDe.Padding = new Thickness(10);
            de.Margin = new Thickness(10);
            txtDe.Margin = new Thickness(10);
            grdDroite.Children.Add(de);

            // Ajouter un arrondi au txtDe en l'enveloppant dans un Border si nécessaireoueur

            txtDe.FontSize = 25;
            txtDe.FontWeight = FontWeights.Bold;
            txtDe.Foreground = Brushes.Black;
            txtDe.Background = Brushes.White;
            txtDe.HorizontalAlignment = HorizontalAlignment.Center;
            txtDe.VerticalAlignment = VerticalAlignment.Center;
            grdDroite.Children.Add(txtDe);


            for (int iJoueur = 0; iJoueur < Plateau.nbrJoueur; iJoueur++)
            {
                txtBPseudo[iJoueur] = new TextBlock();
                bdd.PrendrePseudo(out donnees);
                txtBPseudo[iJoueur].Text = donnees.Tables[0].Rows[iJoueur]["joueurPseudo"].ToString();
                txtBPseudo[iJoueur].FontSize = 35;
                txtBPseudo[iJoueur].Foreground = Brushes.White;
                txtBPseudo[iJoueur].FontWeight = FontWeights.Bold;
                grdPseudo.Children.Add(txtBPseudo[iJoueur]);
                indicateurLJ += 1;
            }

            //Pions des joueurs

            for (int i = 0; i < Plateau.nbrJoueur; i++)
            {
                Image nouveauPion = new Image();
                nouveauPion.Source = new BitmapImage(new Uri("/assets/Pion_Bleu.png", UriKind.Relative));
                nouveauPion.Width = 60;
                nouveauPion.Height = 60;
                imgPion = nouveauPion;
                imgPion.Tag = i;
                grdPlateau.Children.Add(nouveauPion);
                DeplacerPion(imgPion, 0);
                ChangerDeJoueur(joueurActuel, nbrJoueurs);
            }


            //Coter des Cartes
            for (int iCarte = 0; iCarte < txtBCarte.Length; iCarte++)
            {
                txtBCarte[iCarte] = new Button();
                if (iCarte == 0)
                {
                    txtBCarte[iCarte].Background = Brushes.Red;
                    txtBCarte[iCarte].Content = "MATH";
                    txtBCarte[iCarte].Click += new RoutedEventHandler(CarteMath_Click);
                }
                else if (iCarte == 1)
                {
                    txtBCarte[iCarte].Content = "FRANCAIS";
                    txtBCarte[iCarte].Background = Brushes.Blue;
                    txtBCarte[iCarte].Click += new RoutedEventHandler(CarteFr_Click);
                }
                else if (iCarte == 2)
                {
                    txtBCarte[iCarte].Content = "GEO";
                    txtBCarte[iCarte].Background = Brushes.Yellow;
                    txtBCarte[iCarte].Click += new RoutedEventHandler(CarteGeo_Click);
                }
                else if (iCarte == 3)
                {
                    txtBCarte[iCarte].Content = "HISTOIRE";
                    txtBCarte[iCarte].Background = Brushes.Orange;
                    txtBCarte[iCarte].Click += new RoutedEventHandler(CarteHist_Click);
                }
                else if (iCarte == 4)
                {
                    txtBCarte[iCarte].Content = "ANGLAIS";
                    txtBCarte[iCarte].Background = Brushes.Purple;
                    txtBCarte[iCarte].Click += new RoutedEventHandler(CarteAng_Click);
                }
                else if (iCarte == 5)
                {
                    txtBCarte[iCarte].Content = "SCIENCE";
                    txtBCarte[iCarte].Background = Brushes.Green;
                    txtBCarte[iCarte].Click += new RoutedEventHandler(CarteSc_Click);
                }

                txtBCarte[iCarte].FontSize = 36;
                txtBCarte[iCarte].Margin = new Thickness(5);
                txtBCarte[iCarte].FontWeight = FontWeights.Bold;
                grdDroite.Children.Add(txtBCarte[iCarte]);
                indicateurLC += 2;
            }

            buttonLeave.Content = "Leave";
            buttonLeave.FontSize = 25;
            buttonLeave.Click += new RoutedEventHandler(Btn_Quitter);
        }

        public void Btn_Quitter(object sender, RoutedEventArgs e)
        {
            MainWindow plateau = (MainWindow)App.Current.MainWindow;
            plateau.Content = new Acceuil();
        }
        public void Btn_De(object sender, RoutedEventArgs e)
        {
            // 1. On lance le dé
            cDe.Btn_DonneUnNbrAleaD();

            // 2. On affiche le résultat
            txtDe.Text = $"{cDe.Face}";

            // 3. ON DÉPLACE LE PION !
            // On récupère la valeur du dé (cDe.Face) et on fait bouger imgPion
            JouerTour(cDe.Face);
        }
        public void ChangerDeJoueur(int joueurActuel, int nbrJoueur)
        {
            joueurActuel++;
            if (joueurActuel > nbrJoueur) joueurActuel = 1;
        }

        public void DeplacerPion(Image imgPion, int caseActuelle)
        {
            int max = 8; // Index max (pour une grille 9x9, c'est de 0 à 8)
            int ligne = 0;
            int colonne = 0;

            // On boucle l'index si on dépasse 31 (modulo)
            int position = caseActuelle % 32;

            if (position <= max) // Bas : de (8,0) à (8,8)
            {
                ligne = max;
                colonne = max - position;
            }
            else if (position <= max * 2) // Gauche : remonte de (7,0) à (0,0)
            {
                ligne = max - (position - max);
                colonne = 0;
            }
            else if (position <= max * 3) // Haut : de (0,1) à (0,8)
            {
                ligne = 0;
                colonne = position - (max * 2);
            }
            else // Droite : descend de (1,8) à (7,8)
            {
                ligne = position - (max * 3);
                colonne = max;
            }

            // Application immédiate dans la Grid
            Grid.SetRow(imgPion, ligne);
            Grid.SetColumn(imgPion, colonne);
        }
        int [] positionActuelle = [0];

        public void JouerTour(int scoreDes)
        {
            Image pionQuiDoitBouger = listePions[joueurActuel];
            positionActuelle[joueurActuel] += scoreDes;
            DeplacerPion(imgPion, positionActuelle[joueurActuel]);
            ChangerDeJoueur(joueurActuel, nbrJoueurs);
        }




        public void CarteMath_Click(object sender, RoutedEventArgs e)
        {
            MainWindow plateau = (MainWindow)App.Current.MainWindow;
            plateau.Content = new AfficheCarte.CMath();
        }
        public void CarteFr_Click(object sender, RoutedEventArgs e)
        {
            MainWindow plateau = (MainWindow)App.Current.MainWindow;
            plateau.Content = new AfficheCarte.CFr();
        }
        public void CarteGeo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow plateau = (MainWindow)App.Current.MainWindow;
            plateau.Content = new AfficheCarte.CGeo();
        }
        public void CarteHist_Click(object sender, RoutedEventArgs e)
        {
            MainWindow plateau = (MainWindow)App.Current.MainWindow;
            plateau.Content = new AfficheCarte.CHist();
        }
        public void CarteAng_Click(object sender, RoutedEventArgs e)
        {
            MainWindow plateau = (MainWindow)App.Current.MainWindow;
            plateau.Content = new AfficheCarte.CAng();
        }
        public void CarteSc_Click(object sender, RoutedEventArgs e)
        {
            MainWindow plateau = (MainWindow)App.Current.MainWindow;
            plateau.Content = new AfficheCarte.CSc();
        }
  
    }
}