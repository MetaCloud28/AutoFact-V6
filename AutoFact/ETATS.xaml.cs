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
using System.Data.SQLite;


namespace AutoFact
{
    /// <summary>
    /// Logique d'interaction pour ETATS.xaml
    /// </summary>
    public partial class ETATS : Page
    {
        public ETATS()
        {
            InitializeComponent();
            LoadClientNames();
        }
        private void LoadClientNames()
        {
            List<string> clientNames = GetClientNames();
            // Ici, listViewClients est un contrôle ListView ajouté dans le fichier XAML de la page.
            // Remplacez-le par le nom de votre contrôle d'interface utilisateur.
            listViewClients.ItemsSource = clientNames;
        }

        private List<string> GetClientNames()
        {
            List<string> names = new List<string>();
            string connectionString = "Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Nom FROM clients";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            names.Add(reader["Nom"].ToString());
                        }
                    }
                }
            }
            return names;
        }
    }
}
