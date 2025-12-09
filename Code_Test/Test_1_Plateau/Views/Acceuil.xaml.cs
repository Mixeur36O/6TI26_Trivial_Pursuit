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
    /// Logique d'interaction pour Acceuil.xaml
    /// </summary>
    public partial class Acceuil : Page
    {
            
        Button[] button = new Button[3];

        public Acceuil()
        {
            InitializeComponent();
            PrepareInterface();
        }
        public void PrepareInterface()
        {
            //Variables
            ColumnDefinition[] colDef = new ColumnDefinition[3];
            RowDefinition[] rowDef = new RowDefinition[3];
            grdMain.Background = Brushes.Gray;

            //Faire la grille
            for (int iGrille = 0; iGrille < 3; iGrille++)
            {
                colDef[iGrille] = new ColumnDefinition();
                rowDef[iGrille] = new RowDefinition();
                grdMain.ColumnDefinitions.Add(colDef[iGrille]);
                grdMain.RowDefinitions.Add(rowDef[iGrille]);
            }

            //Placer les boutons
            for (int iButton = 0; iButton < button.Length; iButton++)
            {
                button[iButton] = new Button();
                if (iButton == 0)
                {
                    button[iButton].Content = "Jouer";
                }
                else if (iButton == 1)
                {
                    button[iButton].Content = "Paramètre";
                }
                else if (iButton == 2)
                {
                    button[iButton].Content = "Quitter";
                }
                button[iButton].Height = 80;
                button[iButton].Width = 150;
                grdMain.Children.Add(button[iButton]);
                Grid.SetColumnSpan(button[iButton], 3);
                Grid.SetRow(button[iButton], iButton);
            }
            button[0].Click += new RoutedEventHandler(Btn_Play);
            button[1].Click += new RoutedEventHandler(Btn_Para);
            button[2].Click += new RoutedEventHandler(Btn_Leave);
        }
        public void Btn_Play(object sender, RoutedEventArgs e)
        {
            MainWindow acceuil = (MainWindow)App.Current.MainWindow;
            acceuil.Content = new Pseudo();
        }

        public void Btn_Para(object sender, RoutedEventArgs e)
        {
            MainWindow acceuil = (MainWindow)App.Current.MainWindow;
            acceuil.Content = new Paramètre();

        }

        public void Btn_Leave(object sender, RoutedEventArgs e)
        {
            MainWindow para = (MainWindow)App.Current.MainWindow;
            //this.Close();
        }


    }
}
