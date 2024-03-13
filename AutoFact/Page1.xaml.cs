using System.Data.SQLite;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;

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
    }
}
