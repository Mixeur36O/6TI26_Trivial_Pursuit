using Google.Protobuf.WellKnownTypes;
using Limet_Maxence_CodagePion.Classe;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        TextBlock[] txtBCouleur = new TextBlock[Plateau.nbrJoueur];
        int btnChangeCou = 0;
        int itxtBCL = 1;
        int colorChang = 0;
        int colorChang1 = 0;
        int colorChang2 = 0;
        int colorChang3 = 0;

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
            //MySqlConnection maConnection = new MySqlConnection(DefinirCheminBD());
            DataSet infos = new DataSet();
            TextBlock[] txtBTxtpseudo = new TextBlock[Plateau.nbrJoueur];
            TextBox[] txtPseudo = new TextBox[Plateau.nbrJoueur];
            Button btnJouer = new Button();
            Button[] btnchangC = new Button[Plateau.nbrJoueur];
            ColumnDefinition[] colDef = new ColumnDefinition[2];
            RowDefinition[] rowDef = new RowDefinition[9];
            grdPseudo.Background = Brushes.Gray;

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
            for (int itxtBP = 0; itxtBP < Plateau.nbrJoueur; itxtBP++)
            {
                txtBTxtpseudo[itxtBP] = new TextBlock();
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
            for (int itxtBoxC = 0; itxtBoxC < 6; itxtBoxC++)
            {

            }

            //Button switch color

            for (int iBChang = 0; iBChang < Plateau.nbrJoueur; iBChang++)
            {
                btnchangC[iBChang] = new Button();
                btnchangC[iBChang].Content = ">";
                btnchangC[iBChang].Height = 50;
                btnchangC[iBChang].Width = 50;
                if (btnChangeCou == 0)
                {
                    btnchangC[iBChang].Click += new RoutedEventHandler(Btn_ChangeColor);
                    Grid.SetColumn(txtBCouleur[iBChang], 0);
                    Grid.SetRow(txtBCouleur[iBChang], itxtBCL);
                }
                grdPseudo.Children.Add(btnchangC[iBChang]);
                Grid.SetColumn(btnchangC[iBChang], 1);
                Grid.SetRow(btnchangC[iBChang], iBChCL);
                iBChCL += 2;
                txtBCouleur[iBChang] = new TextBlock();
                txtBCouleur[iBChang].Text = "Couleur";
                txtBCouleur[iBChang].Height = 80;
                txtBCouleur[iBChang].Width = 100;
                grdPseudo.Children.Add(txtBCouleur[iBChang]);
                Grid.SetColumn(txtBCouleur[iBChang], 0);
                Grid.SetRow(txtBCouleur[iBChang], itxtBCL);
                itxtBCL += 2;
            }

            //TextBox
            for (int itxtBox = 0; itxtBox < Plateau.nbrJoueur; itxtBox++)
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

        //BDD
        public void Btn_GoPlateau(object sender, RoutedEventArgs e)
        {
            MainWindow pseudo = (MainWindow)App.Current.MainWindow;
            pseudo.Content = null;
            pseudo.Content = new PlateauJeu();
        }
        public void Btn_ChangeColor(object sender, RoutedEventArgs e)
        {

            if (Plateau.nbrJoueur == 2)
            {
                if (colorChang == 0)
                {
                    txtBCouleur[colorChang].Text = "Rouge";
                    txtBCouleur[colorChang].Background = Brushes.Red;
                    colorChang += 1;
                }
                else if (colorChang == 1)
                {
                    txtBCouleur[colorChang].Text = "Bleu";
                    txtBCouleur[colorChang].Background = Brushes.Blue;
                    colorChang = 0;
                }
            }

            else if (Plateau.nbrJoueur == 3)
            {
                if (colorChang == 0)
                {
                    txtBCouleur[colorChang].Text = "Rouge";
                    txtBCouleur[colorChang].Background = Brushes.Red;
                    colorChang += 1;
                }
                else if (colorChang == 1)
                {
                    txtBCouleur[colorChang].Text = "Bleu";
                    txtBCouleur[colorChang].Background = Brushes.Blue;
                    colorChang += 1;
                }
                else if (colorChang == 2)
                {
                    txtBCouleur[colorChang].Text = "Vert";
                    txtBCouleur[colorChang].Background = Brushes.Green;
                    colorChang = 0;
                }
            }

            else if (Plateau.nbrJoueur == 4)
            {
                if (colorChang == 0)
                {
                    txtBCouleur[colorChang].Text = "Rouge";
                    txtBCouleur[colorChang].Background = Brushes.Red;
                    colorChang += 1;
                }
                else if (colorChang == 1)
                {
                    txtBCouleur[colorChang].Text = "Bleu";
                    txtBCouleur[colorChang].Background = Brushes.Blue;
                    colorChang += 1;
                }
                else if (colorChang == 2)
                {
                    txtBCouleur[colorChang].Text = "Vert";
                    txtBCouleur[colorChang].Background = Brushes.Green;
                    colorChang += 1;
                }
                else if (colorChang == 3)
                {
                    txtBCouleur[colorChang].Text = "Jaune";
                    txtBCouleur[colorChang].Background = Brushes.Yellow;
                    colorChang = 0;
                }
            }

        }
    }
}



