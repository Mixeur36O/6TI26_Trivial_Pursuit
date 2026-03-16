using Code_Martyre_Classe.Views;
using Limet_Maxence_CodagePion.Classe;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Martyre_Classe.Config
{
    class connectDB
    {
        public string DefinirCheminBD() // détermine la chaîne de connexion
        {
            try
            {
                //return "server=localhost;database=projet_tfe;port=3306;User Id=root;password=root";
                return "server=10.10.51.98;database=maxence;port=3306;User Id=Maxence;password=root";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public bool AjouteJoueur(string pseudo)
        {
            bool ok = false;
            MySqlConnection maConnexion = new MySqlConnection(DefinirCheminBD());
            string query = "";
            try
            {
                maConnexion.Open();
                query = "INSERT INTO joueur (joueurPseudo) values (@joueurPseudo);";

                MySqlCommand insertCommand = new MySqlCommand(query, maConnexion);

                insertCommand.Parameters.AddWithValue("@joueurPseudo", pseudo);


                // Ajout des données à la source de données
                if (insertCommand.ExecuteNonQuery() > 0)
                {
                    ok = true;
                }
                maConnexion.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            return ok;
        }

        public bool PrendrePseudo(out DataSet contenuTable)
        {
            bool ok = false;
            MySqlConnection maConnection = new MySqlConnection(DefinirCheminBD());
            string query = "";
            try
            {
                maConnection.Open();

                query = $"SELECT * FROM joueur;";

                MySqlDataAdapter da = new MySqlDataAdapter(query, maConnection);
                contenuTable = new DataSet();
                da.Fill(contenuTable, "infoTable");

                maConnection.Close();

                if (contenuTable.Tables[0].Rows.Count >= 1)
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            return ok;
        }
    }
}
