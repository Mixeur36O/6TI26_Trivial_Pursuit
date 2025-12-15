using Limet_Maxence_CodagePion.Classe;
using System;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_1_Plateau.Views;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;


namespace Test_1_Plateau
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Button[] button = new Button[3];

        public MainWindow()
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
            for (int iGrille = 0; iGrille < 3 ; iGrille++)
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
            this.Content = new Pseudo();
        }

        public void Btn_Para(object sender, RoutedEventArgs e)
        {
            this.Content = new Paramètre();

        }

        public void Btn_Leave(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}