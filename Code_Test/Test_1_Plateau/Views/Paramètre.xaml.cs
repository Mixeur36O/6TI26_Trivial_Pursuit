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
    /// Logique d'interaction pour Paramètre.xaml
    /// </summary>
    public partial class Paramètre : Page
    {
        TextBlock txtB = new TextBlock();
        int nbrDepart = 2;
        Joueur joueur = new Joueur("",2);
        public Paramètre()
        {
            InitializeComponent();
            PrepareInterface();
        }
        public void PrepareInterface()
        {
            //Variables
            Button[] button = new Button[3];
            ColumnDefinition[] colDef = new ColumnDefinition[3];
            RowDefinition[] rowDef = new RowDefinition[3];
            TextBlock txtJ = new TextBlock();
            grdPara.Background = Brushes.Gray;

            //Faire la grille
            for (int iGrille = 0; iGrille < 3; iGrille++)
            {
                colDef[iGrille] = new ColumnDefinition();
                rowDef[iGrille] = new RowDefinition();
                grdPara.ColumnDefinitions.Add(colDef[iGrille]);
                grdPara.RowDefinitions.Add(rowDef[iGrille]);
            }

            //Bouton pou choisir  nbr joueurs
            for (int iButton = 0; iButton < 3; iButton++)
            {
                button[iButton] = new Button();
                button[iButton].Height = 50;
                button[iButton].Width = 50;
                button[iButton].FontSize = 20;
                button[iButton].FontWeight = FontWeights.Bold;
                grdPara.Children.Add(button[iButton]);
                if (iButton == 0)
                {
                    button[iButton].Content = "<";
                    Grid.SetColumn(button[iButton], 0);
                    Grid.SetRow(button[iButton], 1);
                }
                else if (iButton == 1)
                {
                    button[iButton].Content = ">";
                    Grid.SetColumn(button[iButton], 2);
                    Grid.SetRow(button[iButton], 1);
                }
                else 
                {
                    button[iButton].Content = "Confirmer";
                    button[iButton].Height = 150;
                    button[iButton].Width = 150;
                    Grid.SetColumn(button[iButton], 0);
                    Grid.SetColumnSpan(button[iButton], 3);
                    Grid.SetRow(button[iButton], 2);

                }
            }

            //Event boutton
            button[0].Click += new RoutedEventHandler(Btn_DiminuerJoueur);
            button[1].Click += new RoutedEventHandler(Btn_AugmenterJoueur);
            button[2].Click += new RoutedEventHandler(Btn_Retour);

            //TextBlock qui montre le nombre de joueur
            txtB.Text = $"{nbrDepart}";
            txtB.HorizontalAlignment = HorizontalAlignment.Center;
            txtB.VerticalAlignment = VerticalAlignment.Center;
            txtB.FontSize = 30;
            txtB.FontWeight = FontWeights.Bold;
            grdPara.Children.Add(txtB);
            Grid.SetColumn(txtB, 1);
            Grid.SetRow(txtB, 1);

            //Text
            txtJ.Text = "Choisissez le nombre de joueur pour votre partie";
            txtJ.HorizontalAlignment = HorizontalAlignment.Center;
            txtJ.VerticalAlignment = VerticalAlignment.Center;
            txtJ.FontSize = 30;
            txtJ.FontWeight = FontWeights.Bold;
            grdPara.Children.Add(txtJ);
            Grid.SetColumn(txtJ, 0);
            Grid.SetColumnSpan(txtJ, 3);
            Grid.SetRow(txtJ, 0);
        }
        public void Btn_DiminuerJoueur(object sender, RoutedEventArgs e)
        {
            if (nbrDepart == 1)
            {

            }
            else
            {
                txtB.Text = $"{nbrDepart - 1}";
                nbrDepart += -1;
                joueur.NbrJoueur = nbrDepart;
            }
        }

        public void Btn_AugmenterJoueur(object sender, RoutedEventArgs e)
        {
            if (nbrDepart == 4)
            {

            }
            else
            {
                txtB.Text = $"{nbrDepart + 1}";
                nbrDepart += +1;
                joueur.NbrJoueur = nbrDepart;
            }
        }

        public void Btn_Retour(object sender, RoutedEventArgs e)
        {
            MainWindow para = (MainWindow)App.Current.MainWindow;
            para.Content = new Acceuil();
        }
    }
}
