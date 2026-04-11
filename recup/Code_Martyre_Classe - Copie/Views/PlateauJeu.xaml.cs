using Code_Martyre_Classe.Config;
using Limet_Maxence_CodagePion.Classe;
using MySql.Data.MySqlClient;
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
        int tourJ = 1;

        public PlateauJeu()
        {
            InitializeComponent();
            prepareInterface();
            this.KeyDown += MainWindow_KeyDown;
        }

        public void prepareInterface()
        {
            //Instancier variables et tableau
            int indicateurC = 0;
            int indicateurL = 0;
            int indicateurLC = 0;
            int indicateurLJ = 15;
            
            Button de = new Button();
            BitmapImage pionB = new BitmapImage();
            BitmapImage pionJ = new BitmapImage();
            BitmapImage pionM = new BitmapImage();
            BitmapImage pionO = new BitmapImage();
            BitmapImage pionR = new BitmapImage();
            BitmapImage pionV = new BitmapImage();
            pionB.BeginInit();
            pionB.UriSource = new Uri("assets/Pion_Bleu.png", UriKind.Relative);
            pionB.EndInit();
            pionJ.BeginInit();
            pionJ.UriSource = new Uri("assets/Pion_Jaune.png", UriKind.Relative);
            pionJ.EndInit();
            pionM.BeginInit();
            pionM.UriSource = new Uri("assets/Pion_Mauve.png", UriKind.Relative);
            pionM.EndInit();
            pionO.BeginInit();
            pionO.UriSource = new Uri("assets/Pion_Orange.png", UriKind.Relative);
            pionO.EndInit();
            pionR.BeginInit();
            pionR.UriSource = new Uri("assets/Pion_Rouge.png", UriKind.Relative);
            pionR.EndInit();
            pionV.BeginInit();
            pionV.UriSource = new Uri("assets/Pion_Vert.png", UriKind.Relative);
            pionV.EndInit();
            StackPanel stkBlock = new StackPanel();
            ColumnDefinition[] colDef = new ColumnDefinition[20];
            RowDefinition[] rowDef = new RowDefinition[20];
            grdPlateau.Background = Brushes.Gray;
            

            //Faire la grille
            for (int i = 0; i < 20; i++)
            {
                colDef[i] = new ColumnDefinition();
                rowDef[i] = new RowDefinition();
                grdPlateau.ColumnDefinitions.Add(colDef[i]);
                grdPlateau.RowDefinitions.Add(rowDef[i]);
            }
            
            //Faire le dé et les chiffres
            de.Content = "Lancer le Dé";
            de.FontSize = 25;
            de.FontWeight = FontWeights.Bold;
            de.Click += new RoutedEventHandler(Btn_De);
            grdPlateau.Children.Add(de);
            Grid.SetColumn(de, 17);
            Grid.SetRow(de, 17);
            Grid.SetColumnSpan(de, 3);
            Grid.SetRowSpan(de, 17);

            txtDe.FontSize = 25;
            txtDe.FontWeight = FontWeights.Bold;
            txtDe.Background  = Brushes.White;
            txtDe.HorizontalAlignment = HorizontalAlignment.Center;
            txtDe.VerticalAlignment = VerticalAlignment.Center;
            grdPlateau.Children.Add(txtDe);
            Grid.SetColumn(txtDe, 15);
            Grid.SetRow(txtDe, 17);


            //Coter Joueur
            for (int iJoueur = 0; iJoueur < Plateau.nbrJoueur; iJoueur++)
            {
                string pseudoJ = "";
                txtBPseudo[iJoueur] = new TextBlock();
                bdd.PrendrePseudo(out donnees);
                txtBPseudo[iJoueur].Text = donnees.Tables[0].Rows[iJoueur]["joueurPseudo"].ToString();
                txtBPseudo[iJoueur].FontSize = 35;
                if (tourJ == 1)
                {
                    if (iJoueur == 1)
                    {
                        txtBPseudo[iJoueur].FontWeight = FontWeights.Bold;
                    }
                        
                }
                grdPlateau.Children.Add(txtBPseudo[iJoueur]);
                Grid.SetColumn(txtBPseudo[iJoueur], 0);
                Grid.SetRow(txtBPseudo[iJoueur], indicateurLJ);
                Grid.SetColumnSpan(txtBPseudo[iJoueur], 3);
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
                txtBCarte[iCarte].FontWeight = FontWeights.Bold;
                grdPlateau.Children.Add(txtBCarte[iCarte]);
                Grid.SetColumn(txtBCarte[iCarte], 18);
                Grid.SetRow(txtBCarte[iCarte], indicateurLC);
                Grid.SetColumnSpan(txtBCarte[iCarte], 2);
                Grid.SetRowSpan(txtBCarte[iCarte], 2);
                indicateurLC += 2;
            }



            //Plateau de jeu principale
            for (int iColonne = 0; iColonne < txtBlock.GetLength(0); iColonne++)
            {

                for (int iLigne = 0; iLigne < txtBlock.GetLength(1); iLigne++)
                {
                    if (indicateurC == 0 || indicateurL == 0 || indicateurC == 6 || indicateurL == 6 || indicateurC == 12 || indicateurL == 12)
                    {
                        Random rnd = new Random();
                        int randomC = rnd.Next(0, 6);
                        txtBlock[iColonne, iLigne] = new TextBlock();
                        txtBlock[iColonne, iLigne].FontSize = 50;
                        txtBlock[iColonne, iLigne].Height = 90;
                        txtBlock[iColonne, iLigne].Width = 90;
                        if (randomC == 0)
                        {
                            txtBlock[iColonne, iLigne].Background = Brushes.Red;
                            txtBlock[iColonne, iLigne].Text = "Math";
                        }
                        else if (randomC == 1)
                        {
                            txtBlock[iColonne, iLigne].Background = Brushes.Blue;
                            txtBlock[iColonne, iLigne].Text = "Fr";
                        }
                        else if (randomC == 2)
                        {
                            txtBlock[iColonne, iLigne].Background = Brushes.Yellow;
                            txtBlock[iColonne, iLigne].Text = "Géo";
                        }
                        else if (randomC == 3)
                        {
                            txtBlock[iColonne, iLigne].Background = Brushes.Orange;
                            txtBlock[iColonne, iLigne].Text = "Hist";
                        }
                        else if (randomC == 4)
                        {
                            txtBlock[iColonne, iLigne].Background = Brushes.Purple;
                            txtBlock[iColonne, iLigne].Text = "Anglais";
                        }
                        else if (randomC == 5)
                        {
                            txtBlock[iColonne, iLigne].Background = Brushes.Green;
                            txtBlock[iColonne, iLigne].Text = "Sc";
                        }
                        txtBlock[iColonne, iLigne].FontSize = 20;
                        txtBlock[iColonne, iLigne].FontWeight = FontWeights.Bold;


                        Grid.SetColumn(txtBlock[iColonne, iLigne], indicateurC);
                        Grid.SetRow(txtBlock[iColonne, iLigne], indicateurL);
                        grdPlateau.Children.Add(txtBlock[iColonne, iLigne]);
                    }
                    indicateurC += 1;
                }
                indicateurC = 0;
                indicateurL += 1;
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


        /// <summary>
        /// Procédure permettant de lancer un dé, et faire avancer le pion du joueur
        /// </summary>
        /// <param name = "symboleJoueur" > Symbole marquant la position du joueur</param>
        /// <param name = "numeroJoueur" > numero du joueur(1 ou 2)</param>
        /// <param name = "totalJoueur" > Compte cumulé des dés sortis</param>
        /// <param name = "positionPionJoueur" > Première place = numéro de ligne, seconde place = numéro de colonne</param>
        /// <param name = "ancienneValeur" > valeur numérique de la case où se trouve le joueur</param>
        //public void TourJoueur(string symboleJoueur, int numeroJoueur, ref int totalJoueur, ref int[] positionPionJoueur, ref string ancienneValeur)
        //{
        //    Random alea = new Random();         // nombre aléatoire
        //    int taille = btnCases.GetLength(0); // nombre de lignes dans le plateau
        //    int maxCases = taille * taille;     // nombre de cases maximum

        //    dé sorti
        //    int de = alea.Next(1, 7);

        //    modification de l'interface pour l'affichage du numéro du joueur et du dé
        //    txtQuiJoue.Text = "Joueur " + numeroJoueur;
        //    txtDe.Text = "Dé : " + de;

        //    calcul total déjà parcouru par le joueur
        //   totalJoueur += de;

        //    Si on dépasse le nombre total de cases, on fixe à la dernière possible
        //    if (totalJoueur > maxCases)
        //    {
        //        totalJoueur = maxCases;
        //    }

        //    Retirer le symbole du joueur à l'ancienne position et faire apparaître le numéro qu'il cachait
        //    btnCases[positionPionJoueur[0], positionPionJoueur[1]].Content = ancienneValeur;
        //    btnCases[positionPionJoueur[0], positionPionJoueur[1]].Foreground = Brushes.Black;

        //    recherche de la nouvelle position du joueur
        //    int index = totalJoueur - 1;

        //    int ligneDepuisBas = index / taille;
        //    int colonneDansLigne = index % taille;

        //    positionPionJoueur[0] = taille - 1 - ligneDepuisBas;

        //    bool gaucheVersDroite = ligneDepuisBas % 2 == 0;

        //    positionPionJoueur[1] = gaucheVersDroite
        //        ? colonneDansLigne
        //        : taille - 1 - colonneDansLigne;

        //    Fin de partie
        //    if (totalJoueur == maxCases)
        //    {
        //        txtQuiJoue.Text = "Fin !";
        //        btnAvancer.IsEnabled = false;
        //    }

        //    mémorisation du numéro de la case sur laquelle on va placer le symbole du joueur
        //    + affichage de ce symbole
        //   ancienneValeur = btnCases[positionPionJoueur[0], positionPionJoueur[1]].Content.ToString();
        //        btnCases[positionPionJoueur[0], positionPionJoueur[1]].Content = symboleJoueur;
        //        btnCases[positionPionJoueur[0], positionPionJoueur[1]].Foreground = Brushes.Gold;
        //    }
        }
}
