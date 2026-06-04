using Code_Martyre_Classe.Config;
using Limet_Maxence_CodagePion.Classe;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Code_Martyre_Classe.Views.AfficheCarte
{
    /// <summary>
    /// Logique d'interaction pour CSc.xaml
    /// </summary>
    public partial class CSc : Page
    {
        string joueurR = "";
        string reponseComp = "";
        connectDB bdd = new connectDB();
        DataSet qSc = new DataSet();
        TextBox txtBox = new TextBox();
        int rndQ = 0;
        DataSet contenuRep = new DataSet();
        Carte carteS = new Carte();
        string reponseQ;
        public CSc()
        {
            InitializeComponent();
            PrepareInterface();
        }

        public void PrepareInterface()
        {
            //Variables
            TextBlock txtBlockQ = new TextBlock();
            TextBlock txtBlockTitre = new TextBlock();
            Button btnSubmit = new Button();
            ColumnDefinition[] colDef = new ColumnDefinition[2];
            RowDefinition[] rowDef = new RowDefinition[4];
            Random rnd = new Random();
            rndQ = rnd.Next(1, 10);


            //Faire la grille
            for (int iCol = 0; iCol < 2; iCol++)
            {
                colDef[iCol] = new ColumnDefinition();
                grdSc.ColumnDefinitions.Add(colDef[iCol]);
            }

            for (int iLi = 0; iLi < 2; iLi++)
            {
                rowDef[iLi] = new RowDefinition();
                grdSc.RowDefinitions.Add(rowDef[iLi]);
            }

            //Titre
            txtBlockTitre.Text = "Carte de Science";
            txtBlockTitre.FontSize = 30;
            txtBlockTitre.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlockTitre.FontWeight = FontWeights.Bold;
            txtBlockTitre.Height = 40;
            grdSc.Children.Add(txtBlockTitre);
            Grid.SetColumn(txtBlockTitre, 0);
            Grid.SetColumnSpan(txtBlockTitre, 2);
            Grid.SetRow(txtBlockTitre, 0);

            //TextBlock question
            carteS.QuestionSc(out DataSet qSc);
            txtBlockQ.Text = qSc.Tables[0].Rows[rndQ]["carteQ"].ToString();
            txtBlockQ.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlockQ.FontWeight = FontWeights.Bold;
            grdSc.Children.Add(txtBlockQ);
            Grid.SetColumn(txtBlockQ, 0);
            Grid.SetColumnSpan(txtBlockQ, 2);
            Grid.SetRow(txtBlockQ, 2);

            //TextBox
            carteS.ReponseSc(out contenuRep);
            reponseQ = contenuRep.Tables[0].Rows[rndQ]["carteR"].ToString();
            txtBox.Height = 50;
            txtBox.Width = 300;
            txtBox.HorizontalAlignment = HorizontalAlignment.Center;
            txtBox.PreviewTextInput += new TextCompositionEventHandler(SoumetRep_Text);
            grdSc.Children.Add(txtBox);
            Grid.SetColumn(txtBox, 0);
            Grid.SetRow(txtBox, 3);

            //Btn submit
            btnSubmit.Content = "Submit";
            btnSubmit.Height = 50;
            btnSubmit.Width = 50;
            btnSubmit.HorizontalAlignment = HorizontalAlignment.Center;
            btnSubmit.Click += new RoutedEventHandler(Submit_Click);
            grdSc.Children.Add(btnSubmit);
            Grid.SetColumn(btnSubmit, 1);
            Grid.SetRow(btnSubmit, 3);
        }

        public void SoumetRep_Text(object sender, TextCompositionEventArgs e)
        {
            joueurR = e.Text;
            reponseComp += joueurR;
            if (joueurR == "_")
            {
                reponseComp = "";
                joueurR = "";
            }
        }
        public void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (reponseComp == reponseQ)
            {
                txtBox.Text = "Bravo c'est la bonne réponse +1 point";
            }
            else
            {
                txtBox.Text = "Désoler ceci n'est pas la bonne réponse tu ne gagne pas de point";
                txtBox.TextWrapping = TextWrapping.Wrap;
            }

            MainWindow carteSc = (MainWindow)App.Current.MainWindow;
            carteSc.Content = new PlateauJeu();
        }
    }
}