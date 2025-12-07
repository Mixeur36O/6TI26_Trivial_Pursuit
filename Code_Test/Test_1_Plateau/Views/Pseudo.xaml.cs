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
    /// Logique d'interaction pour Pseudo.xaml
    /// </summary>
    public partial class Pseudo : Page
    {
        
        public Pseudo()
        {
            InitializeComponent();
            Prepareinterface();
        }

        public void Prepareinterface()
        {

            //Variable 
            TextBlock[] txtBTxtpseudo = new TextBlock[4];
            TextBox[] txtPseudo = new TextBox[4];
            Button btnJouer = new Button();
            ColumnDefinition[] colDef = new ColumnDefinition[2];
            RowDefinition[] rowDef = new RowDefinition[5];
            grdPseudo.Background = Brushes.Gray;

            //Grille
            for (int iC = 0; iC < 2;  iC++)
            {
                colDef[iC] = new ColumnDefinition();
                grdPseudo.ColumnDefinitions.Add(colDef[iC]);
                
            }
            for (int iL = 0; iL < 5; iL++)
            {
                rowDef[iL] = new RowDefinition();
                grdPseudo.RowDefinitions.Add(rowDef[iL]);
            }

            //TxtBlock
            for (int itxtB = 0; itxtB < 4; itxtB++)
            {
                txtBTxtpseudo[itxtB] = new TextBlock();
                if (itxtB == 0)
                {
                    txtBTxtpseudo[itxtB].Text = "Pseudo1 :";
                }
                else if (itxtB == 1)
                {
                    txtBTxtpseudo[itxtB].Text = "Pseudo2 :";
                }
                else if (itxtB == 2)
                {
                    txtBTxtpseudo[itxtB].Text = "Pseudo3 :";
                }
                else if (itxtB == 3)
                {
                    txtBTxtpseudo[itxtB].Text = "Pseudo4 :";
                }
                txtBTxtpseudo[itxtB].HorizontalAlignment = HorizontalAlignment.Center;
                txtBTxtpseudo[itxtB].VerticalAlignment = VerticalAlignment.Center;
                grdPseudo.Children.Add(txtBTxtpseudo[itxtB]);
                Grid.SetColumn(txtBTxtpseudo[itxtB], 0);
                Grid.SetRow(txtBTxtpseudo[itxtB], itxtB);

            }

            //TextBox
            for (int itxtBox = 0; itxtBox < 4; itxtBox++)
            {
                txtPseudo[itxtBox] = new TextBox();
                //txtPseudo[itxtBox].PreviewTextInput += new TextCompositionEventHandler();
                txtPseudo[itxtBox].Height = 80;
                txtPseudo[itxtBox].Width = 100;
                grdPseudo.Children.Add(txtPseudo[itxtBox]);
                Grid.SetColumn(txtPseudo[itxtBox], 1);
                Grid.SetRow(txtPseudo[itxtBox], itxtBox);

            }

            btnJouer.Content = "Confirmer";
            btnJouer.Height = 80;
            btnJouer.Width = 150;
            btnJouer.Click += new RoutedEventHandler(Btn_GoPlateau);
            grdPseudo.Children.Add(btnJouer);
            Grid.SetColumn(btnJouer, 0);
            Grid.SetColumnSpan(btnJouer, 2);
            Grid.SetRow(btnJouer, 4);
        }

        public void Btn_GoPlateau(object sender, RoutedEventArgs e)
        {
            MainWindow pseudo = (MainWindow)App.Current.MainWindow;
            pseudo.Content = null;
            pseudo.Content = new PlateauJeu();
        }
    }
}

