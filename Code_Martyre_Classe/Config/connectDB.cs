using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Martyre_Classe.Config
{
    class connectDB
    {
        static string DefinirCheminBD() // détermine la chaîne de connexion
        {
            try
            {
                //return "server=localhost;database=projet_tfe;port=3306;User Id=root;password=root";
                return "server=localhost;database=maxence;port=3306;User Id=Maxence;password=root";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
