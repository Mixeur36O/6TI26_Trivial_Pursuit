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
        TextBlock txtBCouleur = new TextBlock();
        int nbrPseudo = Plateau.nbrJoueur;
        Button confirmation;
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
            TextBlock txtBTxtpseudo = new TextBlock();
            TextBox txtPseudo = new TextBox();
            Button btnJouer = new Button();
            Button btnchangC = new Button();
            ColumnDefinition[] colDef = new ColumnDefinition[4];
            RowDefinition[] rowDef = new RowDefinition[4];
            grdPseudo.Background = Brushes.Gray;
            

            //Grille
            for (int iC = 0; iC < 4; iC++)
            {
                colDef[iC] = new ColumnDefinition();
                grdPseudo.ColumnDefinitions.Add(colDef[iC]);
                rowDef[iC] = new RowDefinition();
                grdPseudo.RowDefinitions.Add(rowDef[iC]);

            }

            //TxtBlock pseudo

            txtBTxtpseudo.Text = "Pseudo";
            txtBTxtpseudo.HorizontalAlignment = HorizontalAlignment.Center;
            txtBTxtpseudo.VerticalAlignment = VerticalAlignment.Center;
            grdPseudo.Children.Add(txtBTxtpseudo);
            Grid.SetColumn(txtBTxtpseudo, 1);
            Grid.SetRow(txtBTxtpseudo, 1);

            //Button switch color
            btnchangC.Content = ">";
            btnchangC.Height = 50;
            btnchangC.Width = 50;
            btnchangC.Click += new RoutedEventHandler(Btn_ChangeColor);
            grdPseudo.Children.Add(btnchangC);
            Grid.SetColumn(btnchangC, 2);
            Grid.SetRow(btnchangC, 2);
            txtBCouleur.Text = "Couleur";
            txtBCouleur.Height = 80;
            txtBCouleur.Width = 100;
            grdPseudo.Children.Add(txtBCouleur);
            Grid.SetColumn(txtBCouleur, 1);
            Grid.SetRow(txtBCouleur, 2);

            //TextBox
            txtPseudo.PreviewTextInput += new TextCompositionEventHandler(AjouterPseudo_Text);
            txtPseudo.Height = 80;
            txtPseudo.Width = 300;
            confirmation = new Button();
            confirmation.Height = 50;
            confirmation.Width = 200;
            confirmation.Content = "Veuiller confirmer votre pseudo";
            grdPseudo.Children.Add(txtPseudo);
            Grid.SetColumn(txtPseudo, 1);
            Grid.SetRow(txtPseudo, 0);
            grdPseudo.Children.Add(confirmation);
            Grid.SetColumn(confirmation, 2);
            Grid.SetRow(confirmation, 2);
            confirmation.Click += new RoutedEventHandler(AjouterPseudo_Click);

            btnJouer.Content = "Confirmer";
            btnJouer.Height = 80;
            btnJouer.Width = 150;
            btnJouer.Click += new RoutedEventHandler(Btn_GoPlateau);
            grdPseudo.Children.Add(btnJouer);
            Grid.SetColumn(btnJouer, 1);
            Grid.SetRow(btnJouer, 8);
        }

        //BDD
        public void Btn_GoPlateau(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("CCCC");
            int nbrPS = 1;
            MainWindow pseudo = (MainWindow)App.Current.MainWindow;
            if (nbrPS <= nbrPseudo)
            {
                nbrPS += 1;
                pseudo.Content = null;
                pseudo.Content = new Pseudo();
            }
            else
            {
                pseudo.Content = null;
                pseudo.Content = new PlateauJeu();
            }

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

        public void Btn_ChangeColor(object sender, RoutedEventArgs e)
        {

            if (Plateau.nbrJoueur == 2)
            {
                if (colorChang == 0)
                {
                    txtBCouleur.Text = "Rouge";
                    txtBCouleur.Background = Brushes.Red;
                    colorChang += 1;
                }
                else if (colorChang == 1)
                {
                    txtBCouleur.Text = "Bleu";
                    txtBCouleur.Background = Brushes.Blue;
                    colorChang = 0;
                }
                if (btnChangeCou == 0)
                {
                    Grid.SetColumn(txtBCouleur, 0);
                    Grid.SetRow(txtBCouleur, 1);
                    btnChangeCou += 1;
                }
                else if (btnChangeCou == 1)
                {
                    Grid.SetColumn(txtBCouleur, 0);
                    Grid.SetRow(txtBCouleur, 3);
                    btnChangeCou = 0;
                }
            }

            else if (Plateau.nbrJoueur == 3)
            {
                if (colorChang == 0)
                {
                    txtBCouleur.Text = "Rouge";
                    txtBCouleur.Background = Brushes.Red;
                    colorChang += 1;
                }
                else if (colorChang == 1)
                {
                    txtBCouleur.Text = "Bleu";
                    txtBCouleur.Background = Brushes.Blue;
                    colorChang += 1;
                }
                else if (colorChang == 2)
                {
                    txtBCouleur.Text = "Vert";
                    txtBCouleur.Background = Brushes.Green;
                    colorChang = 0;
                }
                if (btnChangeCou == 0)
                {
                    Grid.SetColumn(txtBCouleur, 0);
                    Grid.SetRow(txtBCouleur, 1);
                    btnChangeCou += 1;
                }
                else if (btnChangeCou == 1)
                {
                    Grid.SetColumn(txtBCouleur, 0);
                    Grid.SetRow(txtBCouleur, 3);
                    btnChangeCou += 1;
                }
                else if (btnChangeCou == 2)
                {
                    Grid.SetColumn(txtBCouleur, 0);
                    Grid.SetRow(txtBCouleur, 5);
                    btnChangeCou = 0;
                }
            }

            else if (Plateau.nbrJoueur == 4)
            {
                if (colorChang == 0)
                {
                    txtBCouleur.Text = "Rouge";
                    txtBCouleur.Background = Brushes.Red;
                    colorChang += 1;
                }
                else if (colorChang == 1)
                {
                    txtBCouleur.Text = "Bleu";
                    txtBCouleur.Background = Brushes.Blue;
                    colorChang += 1;
                }
                else if (colorChang == 2)
                {
                    txtBCouleur.Text = "Vert";
                    txtBCouleur.Background = Brushes.Green;
                    colorChang += 1;
                }
                else if (colorChang == 3)
                {
                    txtBCouleur.Text = "Jaune";
                    txtBCouleur.Background = Brushes.Yellow;
                    colorChang = 0;
                }
                if (btnChangeCou == 0)
                {
                    Grid.SetColumn(txtBCouleur, 0);
                    Grid.SetRow(txtBCouleur, 1);
                    btnChangeCou += 1;
                }
                else if (btnChangeCou == 1)
                {
                    Grid.SetColumn(txtBCouleur, 0);
                    Grid.SetRow(txtBCouleur, 3);
                    btnChangeCou += 1;
                }
                else if (btnChangeCou == 2)
                {
                    Grid.SetColumn(txtBCouleur, 0);
                    Grid.SetRow(txtBCouleur, 5);
                    btnChangeCou += 1;
                }
                else if (btnChangeCou == 3)
                {
                    Grid.SetColumn(txtBCouleur, 0);
                    Grid.SetRow(txtBCouleur, 7);
                    btnChangeCou = 0;
                }
            }

        }
    }
}



