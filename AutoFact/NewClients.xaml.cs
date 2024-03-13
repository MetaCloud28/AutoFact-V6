using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace AutoFact
{
    public partial class NewClients : Page
    {
        public NewClients()
        {
            InitializeComponent();
        }

        private void SubmitClientData(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;"; // Mettez à jour avec votre chaîne de connexion
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string nom = nomTextBox.Text;
                string telephone = telephoneTextBox.Text;
                string adresse = adresseTextBox.Text;
                string email = emailTextBox.Text;

                string sql = "INSERT INTO clients (Nom, Téléphone, adresse, email) VALUES (@Nom, @Telephone, @Adresse, @Email)";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nom", nom);
                    cmd.Parameters.AddWithValue("@Telephone", telephone);
                    cmd.Parameters.AddWithValue("@Adresse", adresse);
                    cmd.Parameters.AddWithValue("@Email", email);

                    cmd.ExecuteNonQuery();
                }
            }

            // Nettoyer les champs du formulaire
            nomTextBox.Text = "";
            telephoneTextBox.Text = "";
            adresseTextBox.Text = "";
            emailTextBox.Text = "";

            // Naviguer vers la page d'accueil
            if (this.NavigationService != null)
            {
                this.NavigationService.Navigate(new Page1());
            }
        }
    }
}
