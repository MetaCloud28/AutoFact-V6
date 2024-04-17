using System.Data.SQLite;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace AutoFact
{
    public partial class Page1 : Page
    {
        ObservableCollection<string> clients = new ObservableCollection<string>();

        public Page1()
        {
            InitializeComponent();
            LoadClients();
            clientsListView.ItemsSource = clients;
        }

        private void Newclient_btn_Click(object sender, RoutedEventArgs e)
        {
            // Logique de navigation vers la page de création de nouveaux clients
            NewClients newClientsPage = new NewClients();
            NavigationService.Navigate(newClientsPage);
        }

        private void LoadClients()
        {
            string connectionString = "Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Nom FROM clients";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(reader["Nom"].ToString());
                        }
                    }
                }
            }
        }
        private void DevisClick(object sender, MouseButtonEventArgs e)
        {
            // Vérifiez d'abord si un élément a été réellement sélectionné
            if (clientsListView.SelectedItem != null)
            {
                // Créez une nouvelle instance de la page "Devis"
                Devis devisPage = new Devis();

                // Naviguez vers la page "Devis"
                NavigationService.Navigate(devisPage);
            }
        }


    }
}
