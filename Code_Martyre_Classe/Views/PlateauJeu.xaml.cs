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


        public PlateauJeu()
        {
            InitializeComponent();
            prepareInterface();
            this.KeyDown += MainWindow_KeyDown;
        }
        //Pions
        public void PositionPion()
        {
            int iLigne = 3;
            int iColonne = 0;
            for (int i = 0; i < Plateau.nbrJoueur; i++)
            {
                    Image imgPion = new Image();
                    BitmapImage bitmap = new BitmapImage(new Uri("assets/Pion_Bleu.png", UriKind.Relative));
                    imgPion.Source = bitmap;
                    imgPion.Width = 60;
                    imgPion.Height = 60;
                    Grid.SetRow(imgPion, iLigne);
                    Grid.SetColumn(imgPion, iColonne);
                    grdPlateau.Children.Add(imgPion);
            }
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
                string pseudoJ = "";
                txtBPseudo[iJoueur] = new TextBlock();
                bdd.PrendrePseudo(out donnees);
                txtBPseudo[iJoueur].Text = donnees.Tables[0].Rows[iJoueur]["joueurPseudo"].ToString();
                txtBPseudo[iJoueur].FontSize = 35;
                txtBPseudo[iJoueur].Foreground = Brushes.White;
                txtBPseudo[iJoueur].FontWeight = FontWeights.Bold;
                grdPseudo.Children.Add(txtBPseudo[iJoueur]);
                indicateurLJ += 1;
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
        }
  


        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MainWindow plateau = (MainWindow)App.Current.MainWindow;
                plateau.Content = new Acceuil();
            }
        }
        public void Btn_De(object sender, RoutedEventArgs e)
        {
            cDe.Btn_DonneUnNbrAleaD();
            txtDe.Text = $"{cDe.Face}";
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

        //public string PseudoJ(string pseudoJ)
        // {

        //     bdd.PrendrePseudo(out donnees); 
        //     for (int i = Plateau.nbrJoueur; i < donnees.Tables[0].Rows.Count; i++)
        //     {
        //         pseudoJ = donnees.Tables[0].Rows[i]["joueurPseudo"].ToString();
        //     }
        //     return pseudoJ;
        // }


        ///// <summary>
        ///// Procédure permettant de lancer un dé, et faire avancer le pion du joueur
        ///// </summary>
        ///// <param name="symboleJoueur">Symbole marquant la position du joueur</param>
        ///// <param name="numeroJoueur">numero du joueur (1 ou 2)</param>
        ///// <param name="totalJoueur">Compte cumulé des dés sortis</param>
        ///// <param name="positionPionJoueur">Première place = numéro de ligne, seconde place = numéro de colonne</param>
        ///// <param name="ancienneValeur">valeur numérique de la case où se trouve le joueur</param>
        //public void TourJoueur(string symboleJoueur, int numeroJoueur, ref int totalJoueur, ref int[] positionPionJoueur, ref string ancienneValeur)
        //{
        //    Random alea = new Random();         // nombre aléatoire
        //    int taille = btnCases.GetLength(0); // nombre de lignes dans le plateau
        //    int maxCases = taille * taille;     // nombre de cases maximum

        //    // dé sorti
        //    int de = alea.Next(1, 7);

        //    // modification de l'interface pour l'affichage du numéro du joueur et du dé
        //    txtQuiJoue.Text = "Joueur " + numeroJoueur;
        //    txtDe.Text = "Dé : " + de;

        //    // calcul total déjà parcouru par le joueur
        //    totalJoueur += de;

        //    // Si on dépasse le nombre total de cases, on fixe à la dernière possible
        //    if (totalJoueur > maxCases)
        //    {
        //        totalJoueur = maxCases;
        //    }

        //    // Retirer le symbole du joueur à l'ancienne position et faire apparaître le numéro qu'il cachait
        //    btnCases[positionPionJoueur[0], positionPionJoueur[1]].Content = ancienneValeur;
        //    btnCases[positionPionJoueur[0], positionPionJoueur[1]].Foreground = Brushes.Black;

        //    // recherche de la nouvelle position du joueur
        //    int index = totalJoueur - 1;

        //    int ligneDepuisBas = index / taille;
        //    int colonneDansLigne = index % taille;

        //    positionPionJoueur[0] = taille - 1 - ligneDepuisBas;

        //    bool gaucheVersDroite = ligneDepuisBas % 2 == 0;

        //    positionPionJoueur[1] = gaucheVersDroite
        //        ? colonneDansLigne
        //        : taille - 1 - colonneDansLigne;

        //    // Fin de partie
        //    if (totalJoueur == maxCases)
        //    {
        //        txtQuiJoue.Text = "Fin !";
        //        btnAvancer.IsEnabled = false;
        //    }

        //    // mémorisation du numéro de la case sur laquelle on va placer le symbole du joueur
        //    // + affichage de ce symbole
        //    ancienneValeur = btnCases[positionPionJoueur[0], positionPionJoueur[1]].Content.ToString();
        //    btnCases[positionPionJoueur[0], positionPionJoueur[1]].Content = symboleJoueur;
        //    btnCases[positionPionJoueur[0], positionPionJoueur[1]].Foreground = Brushes.Gold;
        //}

        // Ajoute une image (pion) au Grid à la position ligne/colonne
  
    }
}