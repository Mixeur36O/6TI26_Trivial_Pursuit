using Limet_Maxence_CodagePion.Classe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test_1_Plateau.Views
{
    /// <summary>
    /// Logique d'interaction pour PlateauJeu.xaml
    /// </summary>
    public partial class PlateauJeu : Page
    {
        TextBlock[,] txtBlock = new TextBlock[13, 13];
        TextBlock[] txtBCarte = new TextBlock[6];
        TextBlock[] txtBPseudo = new TextBlock[4];
        De dee = new De();
        int randomD = 0;
        public PlateauJeu()
        {
            InitializeComponent();
            prepareInterface();
        }

        public void prepareInterface()
        {
            //Instancier variables et tableau
            int indicateurC = 0;
            int indicateurL = 0;
            int indicateurLC = 0;
            int indicateurLJ = 15;
            string pseudo1 = "test1";
            string pseudo2 = "test2";
            string pseudo3 = "test3";
            string pseudo4 = "test4";
            Button de = new Button();
            BitmapImage itn = new BitmapImage();

            itn.BeginInit();
            itn.UriSource = new Uri("assets/ITN-Logo-quadri-DEF.jpg", UriKind.Relative);
            itn.EndInit();
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
            de.Content = "Lancer le Dé";
            de.FontSize = 25;
            de.FontWeight = FontWeights.Bold;

            de.Click += new RoutedEventHandler(Btn_DonneUnNbrAlea);
            grdPlateau.Children.Add(de);
            Grid.SetColumn(de, 17);
            Grid.SetRow(de, 17);
            Grid.SetColumnSpan(de, 3);
            Grid.SetRowSpan(de, 17);


            //Coter Joueur
            for (int iJoueur = 0; iJoueur < txtBPseudo.Length; iJoueur++)
            {
                txtBPseudo[iJoueur] = new TextBlock();
                if (iJoueur == 0)
                {
                    txtBPseudo[iJoueur].Text = pseudo1;
                }
                else if (iJoueur == 1)
                {
                    txtBPseudo[iJoueur].Text = pseudo2;
                }
                else if (iJoueur == 2)
                {
                    txtBPseudo[iJoueur].Text = pseudo3;
                }
                else if (iJoueur == 3)
                {
                    txtBPseudo[iJoueur].Text = pseudo4;
                }
                txtBPseudo[iJoueur].FontSize = 35;
                txtBPseudo[iJoueur].FontWeight = FontWeights.Bold;
                grdPlateau.Children.Add(txtBPseudo[iJoueur]);
                Grid.SetColumn(txtBPseudo[iJoueur], 0);
                Grid.SetRow(txtBPseudo[iJoueur], indicateurLJ);
                Grid.SetColumnSpan(txtBPseudo[iJoueur], 3);
                indicateurLJ += 1;
            }

            //Coter des Cartes
            for (int iCarte = 0; iCarte < txtBCarte.Length; iCarte++)
            {
                txtBCarte[iCarte] = new TextBlock();
                if (iCarte == 0)
                {
                    txtBCarte[iCarte].Background = Brushes.Red;
                    txtBCarte[iCarte].Text = "MATH";

                }
                else if (iCarte == 1)
                {
                    txtBCarte[iCarte].Text = "FRANCAIS";
                    txtBCarte[iCarte].Background = Brushes.Blue;
                }
                else if (iCarte == 2)
                {
                    txtBCarte[iCarte].Text = "GEO";
                    txtBCarte[iCarte].Background = Brushes.Yellow;
                }
                else if (iCarte == 3)
                {
                    txtBCarte[iCarte].Text = "HISTOIRE";
                    txtBCarte[iCarte].Background = Brushes.Orange;
                }
                else if (iCarte == 4)
                {
                    txtBCarte[iCarte].Text = "ANGLAIS";
                    txtBCarte[iCarte].Background = Brushes.Purple;
                }
                else if (iCarte == 5)
                {
                    txtBCarte[iCarte].Text = "SCIENCE";
                    txtBCarte[iCarte].Background = Brushes.Green;
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
        public void Btn_DonneUnNbrAlea(object sender, RoutedEventArgs e)
        {
            dee.Btn_DonneUnNbrAleaD(out randomD);

            ((TextBlock)sender).Text = $"Tu est tomber sur le nombre {randomD}";
        }
    }
}
