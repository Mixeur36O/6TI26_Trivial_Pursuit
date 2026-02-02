using Limet_Maxence_CodagePion.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Logique d'interaction pour Pseudo.xaml
    /// </summary>
    public partial class Pseudo : Page
    {
        TextBlock[] txtBCouleur = new TextBlock[6];
        int colorChang = 0;
        int itxtBCL = 1;
        public Pseudo()
        {
            InitializeComponent();
            Prepareinterface();
        }

        public void Prepareinterface()
        {

            //Variable 
            int itxtBL = 0;
            int itxtB = 0;
            int iBChCL = 1;
            Joueur joueur = new Joueur("", 4);
            TextBlock[] txtBTxtpseudo = new TextBlock[joueur.NbrJoueur];
            TextBox[] txtPseudo = new TextBox[joueur.NbrJoueur];
            Button btnJouer = new Button();
            Button[] btnchangC = new Button[joueur.NbrJoueur];
            ColumnDefinition[] colDef = new ColumnDefinition[2];
            RowDefinition[] rowDef = new RowDefinition[9];

            grdPseudo.Background = new LinearGradientBrush(
                    Color.FromRgb(30, 30, 60),
                    Color.FromRgb(15, 15, 30),
                    new System.Windows.Point(0, 0),
                    new System.Windows.Point(0, 1)
            );

            //Grille
            for (int iC = 0; iC < 2; iC++)
            {
                colDef[iC] = new ColumnDefinition();
                grdPseudo.ColumnDefinitions.Add(colDef[iC]);

            }
            for (int iL = 0; iL < 9; iL++)
            {
                rowDef[iL] = new RowDefinition();
                grdPseudo.RowDefinitions.Add(rowDef[iL]);
            }

            //TxtBlock pseudo
            for (int itxtBP = 0; itxtBP < joueur.NbrJoueur; itxtBP++)
            {
                txtBTxtpseudo[itxtBP] = new TextBlock();
                txtBTxtpseudo[itxtBP].Foreground = Brushes.Aqua;
                if (itxtBP == 0)
                {
                    txtBTxtpseudo[itxtBP].Text = "Pseudo1 :";
                }
                else if (itxtBP == 1)
                {
                    txtBTxtpseudo[itxtBP].Text = "Pseudo2 :";
                }
                else if (itxtBP == 2)
                {
                    txtBTxtpseudo[itxtBP].Text = "Pseudo3 :";
                }
                else if (itxtBP == 3)
                {
                    txtBTxtpseudo[itxtBP].Text = "Pseudo4 :";
                }
                txtBTxtpseudo[itxtBP].HorizontalAlignment = HorizontalAlignment.Center;
                txtBTxtpseudo[itxtBP].VerticalAlignment = VerticalAlignment.Center;
                grdPseudo.Children.Add(txtBTxtpseudo[itxtBP]);
                Grid.SetColumn(txtBTxtpseudo[itxtBP], 0);
                Grid.SetRow(txtBTxtpseudo[itxtBP], itxtBL);
                itxtBL += 2;
            }

            //TextBlock couleur en dessous des pseudo
            for (int itxtBoxC = 0; itxtBoxC < 4; itxtBoxC++)
            {
                txtBCouleur[itxtBoxC] = new TextBlock();
                txtBCouleur[itxtBoxC].Text = "Couleur";
                txtBCouleur[itxtBoxC].Height = 80;
                txtBCouleur[itxtBoxC].Width = 100;
                txtBCouleur[itxtBoxC].Foreground = Brushes.Aqua;
                grdPseudo.Children.Add(txtBCouleur[itxtBoxC]);
                Grid.SetColumn(txtBCouleur[itxtBoxC], 0);
                Grid.SetRow(txtBCouleur[itxtBoxC], itxtBCL);
                itxtBCL += 2;
            }

            //Button switch color

            for (int iBChang = 0; iBChang < joueur.NbrJoueur; iBChang++)
            {
                btnchangC[iBChang] = new Button();
                btnchangC[iBChang].Content = ">";
                btnchangC[iBChang].Height = 50;
                btnchangC[iBChang].Width = 50;
                btnchangC[iBChang].Click += new RoutedEventHandler(Btn_ChangeColor);
                grdPseudo.Children.Add(btnchangC[iBChang]);
                Grid.SetColumn(btnchangC[iBChang], 1);
                Grid.SetRow(btnchangC[iBChang], iBChCL);
                iBChCL += 2;
            }


            //TextBox
            for (int itxtBox = 0; itxtBox < joueur.NbrJoueur; itxtBox++)
            {
                txtPseudo[itxtBox] = new TextBox();
                //txtPseudo[itxtBox].PreviewTextInput += new TextCompositionEventHandler();
                txtPseudo[itxtBox].Height = 80;
                txtPseudo[itxtBox].Width = 100;
                grdPseudo.Children.Add(txtPseudo[itxtBox]);
                Grid.SetColumn(txtPseudo[itxtBox], 1);
                Grid.SetRow(txtPseudo[itxtBox], itxtB);
                itxtB += 2;
            }

            btnJouer.Content = "Confirmer";
            btnJouer.Height = 80;
            btnJouer.Width = 150;
            btnJouer.Click += new RoutedEventHandler(Btn_GoPlateau);
            grdPseudo.Children.Add(btnJouer);
            Grid.SetColumn(btnJouer, 0);
            Grid.SetColumnSpan(btnJouer, 2);
            Grid.SetRow(btnJouer, 8);
        }

        public void Btn_GoPlateau(object sender, RoutedEventArgs e)
        {
            MainWindow pseudo = (MainWindow)App.Current.MainWindow;
            pseudo.Content = null;
            pseudo.Content = new PlateauJeu();
        }
        public void Btn_ChangeColor(object sender, RoutedEventArgs e)
        {

            for (int itxtBoxC = 0; itxtBoxC < 6; itxtBoxC++)
            {
                if (itxtBoxC == 0)
                {
                    txtBCouleur[itxtBoxC].Text = "Rouge";
                    txtBCouleur[itxtBoxC].Background = Brushes.Red;
                    Grid.SetColumn(txtBCouleur[itxtBoxC], 0);
                    Grid.SetRow(txtBCouleur[itxtBoxC], 1);
                }
                else if (itxtBoxC == 1)
                {
                    txtBCouleur[itxtBoxC].Text = "Bleu";
                    txtBCouleur[itxtBoxC].Background = Brushes.Blue;
                    Grid.SetColumn(txtBCouleur[itxtBoxC], 0);
                    Grid.SetRow(txtBCouleur[itxtBoxC], 1);
                }
                else if (itxtBoxC == 2)
                {
                    txtBCouleur[itxtBoxC].Text = "Vert";
                    txtBCouleur[itxtBoxC].Background = Brushes.Green;
                    Grid.SetColumn(txtBCouleur[itxtBoxC], 0);
                    Grid.SetRow(txtBCouleur[itxtBoxC], 1);
                }
                else if (itxtBoxC == 3)
                {
                    txtBCouleur[itxtBoxC].Text = "Jaune";
                    txtBCouleur[itxtBoxC].Background = Brushes.Yellow;
                    Grid.SetColumn(txtBCouleur[itxtBoxC], 0);
                    Grid.SetRow(txtBCouleur[itxtBoxC], 1);
                }
                else if (itxtBoxC == 4)
                {
                    txtBCouleur[itxtBoxC].Text = "Orange";
                    txtBCouleur[itxtBoxC].Background = Brushes.Orange;
                    Grid.SetColumn(txtBCouleur[itxtBoxC], 0);
                    Grid.SetRow(txtBCouleur[itxtBoxC], 1);
                }
                else if (itxtBoxC == 5)
                {
                    txtBCouleur[itxtBoxC].Text = "Mauve";
                    txtBCouleur[itxtBoxC].Background = Brushes.Purple;
                    Grid.SetColumn(txtBCouleur[itxtBoxC], 0);
                    Grid.SetRow(txtBCouleur[itxtBoxC], 1);
                    itxtBoxC = 0;
                }
            }
        }

        
    }
   
}
