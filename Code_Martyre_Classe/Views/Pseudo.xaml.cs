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
            for (int itxtBP = 0; itxtBP < joueur.NbrJoueur; itxtBP++)
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
                txtBCouleur[itxtBoxC] = new TextBlock();
                txtBCouleur[itxtBoxC].Text = "Couleur";
                txtBCouleur[itxtBoxC].Height = 80;
                txtBCouleur[itxtBoxC].Width = 100;
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
                grdPseudo.Children.Add(btnchangC[iBChang]);
                Grid.SetColumn(btnchangC[iBChang], 1);
                Grid.SetRow(btnchangC[iBChang], iBChCL);
                iBChCL += 2;
            }
            btnchangC[0].Click += new RoutedEventHandler(Btn_ChangeColor);
            //btnchangC[1].Click += new RoutedEventHandler(Btn_ChangeColor1);
            //btnchangC[2].Click += new RoutedEventHandler(Btn_ChangeColor2);
            //btnchangC[3].Click += new RoutedEventHandler(Btn_ChangeColor3);




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
            int colorChang = 0;
            if (colorChang == 0)
            {
                txtBCouleur[colorChang].Text = "Rouge";
                txtBCouleur[colorChang].Background = Brushes.Red;
                Grid.SetColumn(txtBCouleur[colorChang], 0);
                Grid.SetRow(txtBCouleur[colorChang], 1);
                colorChang += 1;
            }
            else if (colorChang == 1)
            {
                txtBCouleur[colorChang].Text = "Bleu";
                txtBCouleur[colorChang].Background = Brushes.Blue;
                Grid.SetColumn(txtBCouleur[colorChang], 0);
                Grid.SetRow(txtBCouleur[colorChang], 1);
                colorChang += 1;
            }
            else if (colorChang == 2)
            {
                txtBCouleur[colorChang].Text = "Vert";
                txtBCouleur[colorChang].Background = Brushes.Green;
                Grid.SetColumn(txtBCouleur[colorChang], 0);
                Grid.SetRow(txtBCouleur[colorChang], 1);
                colorChang += 1;
            }
            else if (colorChang == 3)
            {
                txtBCouleur[colorChang].Text = "Jaune";
                txtBCouleur[colorChang].Background = Brushes.Yellow;
                Grid.SetColumn(txtBCouleur[colorChang], 0);
                Grid.SetRow(txtBCouleur[colorChang], 1);
                colorChang += 1;
            }
            else if (colorChang == 4)
            {
                txtBCouleur[colorChang].Text = "Orange";
                txtBCouleur[colorChang].Background = Brushes.Orange;
                Grid.SetColumn(txtBCouleur[colorChang], 0);
                Grid.SetRow(txtBCouleur[colorChang], 1);
                colorChang += 1;
            }
            else if (colorChang == 5)
            {
                txtBCouleur[colorChang].Text = "Mauve";
                txtBCouleur[colorChang].Background = Brushes.Purple;
                Grid.SetColumn(txtBCouleur[colorChang], 0);
                Grid.SetRow(txtBCouleur[colorChang], 1);
            }

        }
        //public void Btn_ChangeColor1(object sender, RoutedEventArgs e)
        //{
        //    int colorChang = 0;
        //    if (colorChang == 0)
        //    {
        //        txtBCouleur[colorChang].Text = "Rouge";
        //        txtBCouleur[colorChang].Background = Brushes.Red;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 3);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 1)
        //    {
        //        txtBCouleur[colorChang].Text = "Bleu";
        //        txtBCouleur[colorChang].Background = Brushes.Blue;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 3);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 2)
        //    {
        //        txtBCouleur[colorChang].Text = "Vert";
        //        txtBCouleur[colorChang].Background = Brushes.Green;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 3);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 3)
        //    {
        //        txtBCouleur[colorChang].Text = "Jaune";
        //        txtBCouleur[colorChang].Background = Brushes.Yellow;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 3);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 4)
        //    {
        //        txtBCouleur[colorChang].Text = "Orange";
        //        txtBCouleur[colorChang].Background = Brushes.Orange;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 3);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 5)
        //    {
        //        txtBCouleur[colorChang].Text = "Mauve";
        //        txtBCouleur[colorChang].Background = Brushes.Purple;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 3);
        //    }

        //}
        //public void Btn_ChangeColor2(object sender, RoutedEventArgs e)
        //{
        //    int colorChang = 0;
        //    if (colorChang == 0)
        //    {
        //        txtBCouleur[colorChang].Text = "Rouge";
        //        txtBCouleur[colorChang].Background = Brushes.Red;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 5);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 1)
        //    {
        //        txtBCouleur[colorChang].Text = "Bleu";
        //        txtBCouleur[colorChang].Background = Brushes.Blue;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 5);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 2)
        //    {
        //        txtBCouleur[colorChang].Text = "Vert";
        //        txtBCouleur[colorChang].Background = Brushes.Green;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 5);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 3)
        //    {
        //        txtBCouleur[colorChang].Text = "Jaune";
        //        txtBCouleur[colorChang].Background = Brushes.Yellow;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 5);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 4)
        //    {
        //        txtBCouleur[colorChang].Text = "Orange";
        //        txtBCouleur[colorChang].Background = Brushes.Orange;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 5);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 5)
        //    {
        //        txtBCouleur[colorChang].Text = "Mauve";
        //        txtBCouleur[colorChang].Background = Brushes.Purple;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 5);
        //    }

        //}
        //public void Btn_ChangeColor3(object sender, RoutedEventArgs e)
        //{
        //    int colorChang = 0;
        //    if (colorChang == 0)
        //    {
        //        txtBCouleur[colorChang].Text = "Rouge";
        //        txtBCouleur[colorChang].Background = Brushes.Red;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 7);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 1)
        //    {
        //        txtBCouleur[colorChang].Text = "Bleu";
        //        txtBCouleur[colorChang].Background = Brushes.Blue;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 7);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 2)
        //    {
        //        txtBCouleur[colorChang].Text = "Vert";
        //        txtBCouleur[colorChang].Background = Brushes.Green;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 7);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 3)
        //    {
        //        txtBCouleur[colorChang].Text = "Jaune";
        //        txtBCouleur[colorChang].Background = Brushes.Yellow;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 7);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 4)
        //    {
        //        txtBCouleur[colorChang].Text = "Orange";
        //        txtBCouleur[colorChang].Background = Brushes.Orange;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 7);
        //        colorChang += 1;
        //    }
        //    else if (colorChang == 5)
        //    {
        //        txtBCouleur[colorChang].Text = "Mauve";
        //        txtBCouleur[colorChang].Background = Brushes.Purple;
        //        Grid.SetColumn(txtBCouleur[colorChang], 0);
        //        Grid.SetRow(txtBCouleur[colorChang], 7);
        //    }

        //}


    }

}
