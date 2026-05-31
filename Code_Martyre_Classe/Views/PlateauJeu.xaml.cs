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
        Button[] txtBCarte = new Button[6];
        TextBlock[] txtBPseudo = new TextBlock[4];
        TextBlock txtDe = new TextBlock();
        De cDe = new De(6);
        connectDB bdd = new connectDB();
        DataSet donnees = new DataSet();
        Button buttonLeave = new Button();
        private Image[] listePions;
        private int[] positionActu;
        private int joueurActuel = 0;

        public PlateauJeu()
        {
            InitializeComponent();
            listePions = new Image[Plateau.nbrJoueur];
            positionActu = new int[Plateau.nbrJoueur];
            prepareInterface();

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


            //// 1. Déclaration de source dans un tableau
            //string[] imageCentr = {
            //    "/assets/Victor_hugo.png.jpg",
            //    "/assets/pense.png.jpg",
            //    "/assets/ITN-Logo-quadri-DEF.jpg",
            //    "/assets/ITN-Logo-quadri-DEF.jpg"
            //};

            //int[] rows = { 1, 5, 1, 5 };
            //int[] cols = { 1, 5, 5, 1 };

            //// 2. Boucle for pour générer les 4 images
            //for (int i = 0; i < 4; i++)
            //{
            //    Image imgCentrale = new Image();

            //    // Attribution de la source directement
            //    imgCentrale.Source = new BitmapImage(new Uri(imageCentr[i], UriKind.Relative));

            //    // Dimensions et style
            //    imgCentrale.Height = 270;
            //    imgCentrale.Width = 270;
            //    imgCentrale.Stretch = Stretch.Uniform;

            //    // Positionnement dans la Grid
            //    Grid.SetRow(imgCentrale, rows[i]);
            //    Grid.SetColumn(imgCentrale, cols[i]);
            //    Grid.SetRowSpan(imgCentrale, 3);
            //    Grid.SetColumnSpan(imgCentrale, 3);

            //    // Priorité d'affichage (devant les cases)
            //    Panel.SetZIndex(imgCentrale, 10);

            //    // Ajout à l'interface
            //    grdPlateau.Children.Add(imgCentrale);
            //}

            //Pions des joueurs

            //Tableau de 4 couleur différentes
            string[] couleursPions = {
                 "/assets/Pion_Bleu.png",
                 "/assets/Pion_Jaune.png",
                 "/assets/Pion_Rouge.png",
                "/assets/Pion_Mauve.png",
                "/assets/Pion_Orange.png",
                "/assets/Pion_Vert.png"
            };

            // 
            for (int i = 0; i < Plateau.nbrJoueur; i++)
            {
                Image nouveauPion = new Image();
                nouveauPion.Source = new BitmapImage(new Uri(couleursPions[i], UriKind.Relative));
                nouveauPion.Width = 60;
                nouveauPion.Height = 60;
                //Le Tag sert a donner comme un id, on lui assigne un lettre ou un nombre et là c'est un nombre( i pour avoir les 4 joueurs maximum).
                nouveauPion.Tag = i;

                grdPlateau.Children.Add(nouveauPion);
                listePions[i] = nouveauPion; //Pour mettre les pions et les ranger sur le plateau
                positionActu[i] = 0;
                DeplacerPion(nouveauPion, 0);
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
        public void ChangerDeJoueur()
        {
            joueurActuel = (joueurActuel + 1) % Plateau.nbrJoueur;
        }

        public void DeplacerPion(Image pionABouger, int caseActuelle)
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
            Grid.SetRow(pionABouger, ligne);
            Grid.SetColumn(pionABouger, colonne);
        }

        public void JouerTour(int scoreDes)
        {
            Image pionQuiDoitBouger = listePions[joueurActuel];
            positionActu[joueurActuel] += scoreDes;
            DeplacerPion(pionQuiDoitBouger, positionActu[joueurActuel]);
            joueurActuel = (joueurActuel + 1) % Plateau.nbrJoueur;
        }
        public void Btn_De(object sender, RoutedEventArgs e)
        {
            cDe.Btn_DonneUnNbrAleaD();
            txtDe.Text = $"{cDe.Face}";

            // On lance le tour avec le score du dé
            JouerTour(cDe.Face);
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