using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Code_Martyre_Classe.Views
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

                Color[] colors = {
                Color.FromRgb(16, 185, 129), // vert pour Jouer
                Color.FromRgb(79, 70, 229),  // violet pour Paramètre
                Color.FromRgb(239, 68, 68)   // rouge pour Quitter
            }; ZoomPercentageConverter z = new ZoomPercentageConverter();

                button[iButton].Width = 200;
                button[iButton].Height = 80;
                button[iButton].Background = new SolidColorBrush(colors[iButton]);
                button[iButton].Foreground = Brushes.White;
                button[iButton].FontSize = 18;
                button[iButton].FontWeight = FontWeights.SemiBold;
                button[iButton].Padding = new Thickness(15, 8, 15, 8);
                button[iButton].BorderThickness = new Thickness(0);
                button[iButton].Cursor = Cursors.Hand;
                button[iButton].HorizontalAlignment = HorizontalAlignment.Center;
                button[iButton].VerticalAlignment = VerticalAlignment.Center;
                button[iButton].Margin = new Thickness(0, 10, 0, 10);
                button[iButton].FontFamily = new FontFamily("Segoe UI Semibold");
                button[iButton].Template = CreateRoundedButtonTemplate(20);

                grdMain.Background = new LinearGradientBrush(
                    Color.FromRgb(30, 30, 60),
                    Color.FromRgb(15, 15, 30),
                    new Point(0, 0),
                    new Point(0, 1)
                );

                grdMain.Children.Add(button[iButton]);
                Grid.SetColumnSpan(button[iButton], 3);
                Grid.SetRow(button[iButton], iButton);
            }
            button[0].Click += new RoutedEventHandler(Btn_Play);
            button[1].Click += new RoutedEventHandler(Btn_Para);
            button[2].Click += new RoutedEventHandler(Btn_Leave);
        }
        private ControlTemplate CreateRoundedButtonTemplate(int radius)
        {
            var template = new ControlTemplate(typeof(Button));

            var border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(Border.CornerRadiusProperty, new CornerRadius(radius));
            border.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(Button.BackgroundProperty));
            border.SetValue(Border.PaddingProperty, new TemplateBindingExtension(Button.PaddingProperty));

            var presenter = new FrameworkElementFactory(typeof(ContentPresenter));
            presenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            presenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);

            border.AppendChild(presenter);
            template.VisualTree = border;

            return template;
        }
        public void Btn_Play(object sender, RoutedEventArgs e)
        {
            MainWindow acceuil = (MainWindow)App.Current.MainWindow;
            acceuil.Content = new Pseudo();
        }
        public void Btn_Para(object sender, RoutedEventArgs e)
        {
            MainWindow acceuil = (MainWindow)App.Current.MainWindow;
            acceuil.Content = new Parametre();

        }
        public void Btn_Leave(object sender, RoutedEventArgs e)
        {
            MainWindow acceuil = (MainWindow)App.Current.MainWindow;
            acceuil.Close();
        }
    }
}
