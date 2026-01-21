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
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;


namespace Code_Martyre_Classe.Views
{
    /// <summary>
    /// Logique d'interaction pour Pseudo.xaml
    /// </summary>
    public partial class Pseudo : Page
    {
        TextBlock[] txtBCouleur = new TextBlock[6];

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
            Joueur joueur = new Joueur("");
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

        //BDD
        public void Btn_GoPlateau(object sender, RoutedEventArgs e)
        {
            MainWindow pseudo = (MainWindow)App.Current.MainWindow;
            pseudo.Content = null;
            pseudo.Content = new PlateauJeu();
        }
        public void Btn_ChangeColor(object sender, RoutedEventArgs e)
        {

            
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
                colorChang = 0;

            }

        }
        //public void Btn_ChangeColor1(object sender, RoutedEventArgs e)
        //{
            

        //    if (colorChang1 == 0)
        //    {
        //        txtBCouleur[colorChang1].Text = "Rouge";
        //        txtBCouleur[colorChang1].Background = Brushes.Red;
        //        Grid.SetColumn(txtBCouleur[colorChang1], 0);
        //        Grid.SetRow(txtBCouleur[colorChang1], 3);
        //        colorChang1 += 1;
        //    }
        //    else if (colorChang1 == 1)
        //    {
        //        txtBCouleur[colorChang1].Text = "Bleu";
        //        txtBCouleur[colorChang1].Background = Brushes.Blue;
        //        Grid.SetColumn(txtBCouleur[colorChang1], 0);
        //        Grid.SetRow(txtBCouleur[colorChang1], 3);
        //        colorChang1 += 1;
        //    }
        //    else if (colorChang1 == 2)
        //    {
        //        txtBCouleur[colorChang1].Text = "Vert";
        //        txtBCouleur[colorChang1].Background = Brushes.Green;
        //        Grid.SetColumn(txtBCouleur[colorChang1], 0);
        //        Grid.SetRow(txtBCouleur[colorChang1], 3);
        //        colorChang1 += 1;
        //    }
        //    else if (colorChang1 == 3)
        //    {
        //        txtBCouleur[colorChang1].Text = "Jaune";
        //        txtBCouleur[colorChang1].Background = Brushes.Yellow;
        //        Grid.SetColumn(txtBCouleur[colorChang1], 0);
        //        Grid.SetRow(txtBCouleur[colorChang1], 3);
        //        colorChang1 += 1;
        //    }
        //    else if (colorChang1 == 4)
        //    {
        //        txtBCouleur[colorChang1].Text = "Orange";
        //        txtBCouleur[colorChang1].Background = Brushes.Orange;
        //        Grid.SetColumn(txtBCouleur[colorChang1], 0);
        //        Grid.SetRow(txtBCouleur[colorChang1], 3);
        //        colorChang1 += 1;
        //    }
        //    else if (colorChang1 == 5)
        //    {
        //        txtBCouleur[colorChang1].Text = "Mauve";
        //        txtBCouleur[colorChang1].Background = Brushes.Purple;
        //        Grid.SetColumn(txtBCouleur[colorChang1], 0);
        //        Grid.SetRow(txtBCouleur[colorChang1], 3);
        //        colorChang1 = 0;
        //    }

        //}
        //public void Btn_ChangeColor2(object sender, RoutedEventArgs e)
        //{
            
        //    if (colorChang2 == 0)
        //    {
        //        txtBCouleur[colorChang2].Text = "Rouge";
        //        txtBCouleur[colorChang2].Background = Brushes.Red;
        //        Grid.SetColumn(txtBCouleur[colorChang2], 0);
        //        Grid.SetRow(txtBCouleur[colorChang2], 5);
        //        colorChang2 += 1;
        //    }
        //    else if (colorChang2 == 1)
        //    {
        //        txtBCouleur[colorChang2].Text = "Bleu";
        //        txtBCouleur[colorChang2].Background = Brushes.Blue;
        //        Grid.SetColumn(txtBCouleur[colorChang2], 0);
        //        Grid.SetRow(txtBCouleur[colorChang2], 5);
        //        colorChang2 += 1;
        //    }
        //    else if (colorChang2 == 2)
        //    {
        //        txtBCouleur[colorChang2].Text = "Vert";
        //        txtBCouleur[colorChang2].Background = Brushes.Green;
        //        Grid.SetColumn(txtBCouleur[colorChang2], 0);
        //        Grid.SetRow(txtBCouleur[colorChang2], 5);
        //        colorChang2 += 1;
        //    }
        //    else if (colorChang2 == 3)
        //    {
        //        txtBCouleur[colorChang2].Text = "Jaune";
        //        txtBCouleur[colorChang2].Background = Brushes.Yellow;
        //        Grid.SetColumn(txtBCouleur[colorChang2], 0);
        //        Grid.SetRow(txtBCouleur[colorChang2], 5);
        //        colorChang2 += 1;
        //    }
        //    else if (colorChang2 == 4)
        //    {
        //        txtBCouleur[colorChang2].Text = "Orange";
        //        txtBCouleur[colorChang2].Background = Brushes.Orange;
        //        Grid.SetColumn(txtBCouleur[colorChang2], 0);
        //        Grid.SetRow(txtBCouleur[colorChang2], 5);
        //        colorChang2 += 1;
        //    }
        //    else if (colorChang2 == 5)
        //    {
        //        txtBCouleur[colorChang2].Text = "Mauve";
        //        txtBCouleur[colorChang2].Background = Brushes.Purple;
        //        Grid.SetColumn(txtBCouleur[colorChang2], 0);
        //        Grid.SetRow(txtBCouleur[colorChang2], 5);
        //        colorChang2 = 0;
        //    }

        //}
        //public void Btn_ChangeColor3(object sender, RoutedEventArgs e)
        //{
            
        //    if (colorChang3 == 0)
        //    {
        //        txtBCouleur[colorChang3].Text = "Rouge";
        //        txtBCouleur[colorChang3].Background = Brushes.Red;
        //        Grid.SetColumn(txtBCouleur[colorChang3], 0);
        //        Grid.SetRow(txtBCouleur[colorChang3], 7);
        //        colorChang3 += 1;
        //    }
        //    else if (colorChang3 == 1)
        //    {
        //        txtBCouleur[colorChang3].Text = "Bleu";
        //        txtBCouleur[colorChang3].Background = Brushes.Blue;
        //        Grid.SetColumn(txtBCouleur[colorChang3], 0);
        //        Grid.SetRow(txtBCouleur[colorChang3], 7);
        //        colorChang3 += 1;
        //    }
        //    else if (colorChang3 == 2)
        //    {
        //        txtBCouleur[colorChang3].Text = "Vert";
        //        txtBCouleur[colorChang3].Background = Brushes.Green;
        //        Grid.SetColumn(txtBCouleur[colorChang3], 0);
        //        Grid.SetRow(txtBCouleur[colorChang3], 7);
        //        colorChang3 += 1;
        //    }
        //    else if (colorChang3 == 3)
        //    {
        //        txtBCouleur[colorChang3].Text = "Jaune";
        //        txtBCouleur[colorChang3].Background = Brushes.Yellow;
        //        Grid.SetColumn(txtBCouleur[colorChang3], 0);
        //        Grid.SetRow(txtBCouleur[colorChang3], 7);
        //        colorChang3 += 1;
        //    }
        //    else if (colorChang3 == 4)
        //    {
        //        txtBCouleur[colorChang3].Text = "Orange";
        //        txtBCouleur[colorChang3].Background = Brushes.Orange;
        //        Grid.SetColumn(txtBCouleur[colorChang3], 0);
        //        Grid.SetRow(txtBCouleur[colorChang3], 7);
        //        colorChang3 += 1;
        //    }
        //    else if (colorChang3 == 5)
        //    {
        //        txtBCouleur[colorChang3].Text = "Mauve";
        //        txtBCouleur[colorChang3].Background = Brushes.Purple;
        //        Grid.SetColumn(txtBCouleur[colorChang3], 0);
        //        Grid.SetRow(txtBCouleur[colorChang3], 7);
        //        colorChang3 = 0;
        //    }

        }
    }

