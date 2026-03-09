using Code_Martyre_Classe.Config;
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
        int nbrPseudo = Plateau.nbrJoueur;
        Button[] confirmation = new Button[Plateau.nbrJoueur];
        string pseudoInt = "";
        string pseudoj = "";
        Joueur joueur = new Joueur("");
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
            DataSet infos = new DataSet();
            int itxtBL = 0;
            int itxtB = 0;
            int iBChCL = 1;
            TextBlock[] txtBTxtpseudo = new TextBlock[Plateau.nbrJoueur];
            TextBox[] txtPseudo = new TextBox[Plateau.nbrJoueur];
            Button btnJouer = new Button();
            Button[] btnchangC = new Button[Plateau.nbrJoueur];
            ColumnDefinition[] colDef = new ColumnDefinition[3];
            RowDefinition[] rowDef = new RowDefinition[9];

            grdPseudo.Background = new LinearGradientBrush(
                    Color.FromRgb(30, 30, 60),
                    Color.FromRgb(15, 15, 30),
                    new System.Windows.Point(0, 0),
                    new System.Windows.Point(0, 1)
            );

            //Grille
            for (int iC = 0; iC < 3; iC++)
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
                txtBTxtpseudo[itxtBP].Foreground = Brushes.Red;
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
            for (int itxtBoxC = 0; itxtBoxC < Plateau.nbrJoueur; itxtBoxC++)
            {
                txtBCouleur[itxtBoxC] = new TextBlock();
                txtBCouleur[itxtBoxC].Text = "Couleur";
                txtBCouleur[itxtBoxC].Height = 80;
                txtBCouleur[itxtBoxC].Width = 100;
                txtBCouleur[itxtBoxC].Foreground = Brushes.Red;
                grdPseudo.Children.Add(txtBCouleur[itxtBoxC]);
                Grid.SetColumn(txtBCouleur[itxtBoxC], 0);
                Grid.SetRow(txtBCouleur[itxtBoxC], itxtBCL);
                itxtBCL += 2;
            }

            //Button switch color

            for (int iBChang = 0; iBChang < Plateau.nbrJoueur; iBChang++)
            {
                btnchangC[iBChang] = new Button();
                btnchangC[iBChang].Background = new LinearGradientBrush(
                    Color.FromRgb(30, 30, 60),
                    Color.FromRgb(15, 15, 30),
                    new System.Windows.Point(0, 0),
                    new System.Windows.Point(0, 1)
                );
                btnchangC[iBChang].Content = ">";
                btnchangC[iBChang].Foreground = Brushes.Red;
                btnchangC[iBChang].Height = 50;
                btnchangC[iBChang].Width = 50;
                btnchangC[iBChang].Click += new RoutedEventHandler(Btn_ChangeColor);
                grdPseudo.Children.Add(btnchangC[iBChang]);
                Grid.SetColumn(btnchangC[iBChang], 1);
                Grid.SetRow(btnchangC[iBChang], iBChCL);
                iBChCL += 2;
            }


            //TextBox
            for (int itxtBox = 0; itxtBox < Plateau.nbrJoueur; itxtBox++)
            {
                txtPseudo[itxtBox] = new TextBox();
                txtPseudo[itxtBox].PreviewTextInput += new TextCompositionEventHandler(AjouterPseudo_Text);
                txtPseudo[itxtBox].Height = 80;
                txtPseudo[itxtBox].Width = 300;
                confirmation[itxtBox] = new Button();
                confirmation[itxtBox].Height = 50;
                confirmation[itxtBox].Width = 200;
                confirmation[itxtBox].Content = "Veuiller confirmer votre pseudo";
                confirmation[itxtBox].Click += new RoutedEventHandler(AjouterPseudo_Click);
                grdPseudo.Children.Add(txtPseudo[itxtBox]);
                Grid.SetColumn(txtPseudo[itxtBox], 1);
                Grid.SetRow(txtPseudo[itxtBox], itxtB);
                grdPseudo.Children.Add(confirmation[itxtBox]);
                Grid.SetColumn(confirmation[itxtBox], 3);
                Grid.SetRow(confirmation[itxtBox], itxtB);
                itxtB += 2;
            }

            btnJouer.Content = "Confirmer";
            btnJouer.Foreground = Brushes.Red;
            btnJouer.Background = new LinearGradientBrush(
                    Color.FromRgb(30, 30, 60),
                    Color.FromRgb(15, 15, 30),
                    new System.Windows.Point(0, 0),
                    new System.Windows.Point(0, 1)
            );

            btnJouer.Height = 80;
            btnJouer.Width = 150;
            btnJouer.Click += new RoutedEventHandler(Btn_GoPlateau);
            grdPseudo.Children.Add(btnJouer);
            Grid.SetColumn(btnJouer, 0);
            Grid.SetColumnSpan(btnJouer, 2);
            Grid.SetRow(btnJouer, 8);
        }
        public void AjouterPseudo_Click(object sender, RoutedEventArgs e)
        {
            joueur.AjoutePseudo();
            pseudoInt = "";
            pseudoj = "";
        }

        public void AjouterPseudo_Text(object sender, TextCompositionEventArgs e)
        {

            pseudoj = e.Text;
            pseudoInt += pseudoj;
            joueur.Pseudo = pseudoInt;


        }
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
                    txtBCouleur[btnChangeCou].Text = "Rouge";
                    txtBCouleur[btnChangeCou].Background = Brushes.Red;
                    colorChang += 1;
                }
                else if (colorChang == 1)
                {
                    txtBCouleur[btnChangeCou].Text = "Bleu";
                    txtBCouleur[btnChangeCou].Background = Brushes.Blue;
                    colorChang = 0;
                }
                if (btnChangeCou == 0)
                {
                    Grid.SetColumn(txtBCouleur[btnChangeCou], 0);
                    Grid.SetRow(txtBCouleur[btnChangeCou], 1);
                    btnChangeCou += 1;
                }
                else if (btnChangeCou == 1)
                {
                    Grid.SetColumn(txtBCouleur[btnChangeCou], 0);
                    Grid.SetRow(txtBCouleur[btnChangeCou], 3);
                    btnChangeCou = 0;
                }
            }

            else if (Plateau.nbrJoueur == 3)
            {
                if (colorChang == 0)
                {
                    txtBCouleur[btnChangeCou].Text = "Rouge";
                    txtBCouleur[btnChangeCou].Background = Brushes.Red;
                    colorChang += 1;
                }
                else if (colorChang == 1)
                {
                    txtBCouleur[btnChangeCou].Text = "Bleu";
                    txtBCouleur[btnChangeCou].Background = Brushes.Blue;
                    colorChang += 1;
                }
                else if (colorChang == 2)
                {
                    txtBCouleur[btnChangeCou].Text = "Vert";
                    txtBCouleur[btnChangeCou].Background = Brushes.Green;
                    colorChang = 0;
                }
                if (btnChangeCou == 0)
                {
                    Grid.SetColumn(txtBCouleur[btnChangeCou], 0);
                    Grid.SetRow(txtBCouleur[btnChangeCou], 1);
                    btnChangeCou += 1;
                }
                else if (btnChangeCou == 1)
                {
                    Grid.SetColumn(txtBCouleur[btnChangeCou], 0);
                    Grid.SetRow(txtBCouleur[btnChangeCou], 3);
                    btnChangeCou += 1;
                }
                else if (btnChangeCou == 2)
                {
                    Grid.SetColumn(txtBCouleur[btnChangeCou], 0);
                    Grid.SetRow(txtBCouleur[btnChangeCou], 5);
                    btnChangeCou = 0;
                }
            }

            else if (Plateau.nbrJoueur == 4)
            {
                if (colorChang == 0)
                {
                    txtBCouleur[btnChangeCou].Text = "Rouge";
                    txtBCouleur[btnChangeCou].Background = Brushes.Red;
                    colorChang += 1;
                }
                else if (colorChang == 1)
                {
                    txtBCouleur[btnChangeCou].Text = "Bleu";
                    txtBCouleur[btnChangeCou].Background = Brushes.Blue;
                    colorChang += 1;
                }
                else if (colorChang == 2)
                {
                    txtBCouleur[btnChangeCou].Text = "Vert";
                    txtBCouleur[btnChangeCou].Background = Brushes.Green;
                    colorChang += 1;
                }
                else if (colorChang == 3)
                {
                    txtBCouleur[btnChangeCou].Text = "Jaune";
                    txtBCouleur[btnChangeCou].Background = Brushes.Yellow;
                    colorChang = 0;
                }
                if (btnChangeCou == 0)
                {
                    Grid.SetColumn(txtBCouleur[btnChangeCou], 0);
                    Grid.SetRow(txtBCouleur[btnChangeCou], 1);
                    btnChangeCou += 1;
                }
                else if (btnChangeCou == 1)
                {
                    Grid.SetColumn(txtBCouleur[btnChangeCou], 0);
                    Grid.SetRow(txtBCouleur[btnChangeCou], 3);
                    btnChangeCou += 1;
                }
                else if (btnChangeCou == 2)
                {
                    Grid.SetColumn(txtBCouleur[btnChangeCou], 0);
                    Grid.SetRow(txtBCouleur[btnChangeCou], 5);
                    btnChangeCou += 1;
                }
                else if (btnChangeCou == 3)
                {
                    Grid.SetColumn(txtBCouleur[btnChangeCou], 0);
                    Grid.SetRow(txtBCouleur[btnChangeCou], 7);
                    btnChangeCou = 0;
                }
            }

        
    }


    }
}



