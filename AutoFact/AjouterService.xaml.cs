using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
using System.Data;

namespace AutoFact
{
    public partial class AjouterService : Window
    {
        public AjouterService()
        {
            InitializeComponent();
        }

        // Supprimez cette méthode car elle n'est pas utilisée
        // private void AjouterServiceALaBaseDeDonnees(string nomService, double prixService)


        private void SupprimerServiceDeLaBaseDeDonnees(int serviceId)
        {
            try
            {
                string connectionString = "Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM services WHERE id = @ServiceId";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceId", serviceId);
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression du service : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SupprimerButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DataRowView row = btn.CommandParameter as DataRowView;

            if (row != null && MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce service?", "Confirmer", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                int serviceId = Convert.ToInt32(row["id"]);
                SupprimerServiceDeLaBaseDeDonnees(serviceId);

                // Rafraîchir l'affichage pour montrer que le service a été supprimé
                // (Cela peut dépendre de la façon dont vous gérez les données dans votre ListView)
            }
        }




        private void AjouterServiceButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer les données du formulaire AjouterService
            string nomService = NomTextBox.Text;

            // Assurez-vous de valider et récupérer le prix correctement
            if (double.TryParse(PrixTextBox.Text, out double prixService))
            {
                // Appeler une méthode pour ajouter le service à la base de données
                AjouterServiceALaBaseDeDonnees(nomService, prixService);

                // Fermer le formulaire AjouterService
                Close();
            }
            else
            {
                // Gérer l'erreur de conversion du prix
                MessageBox.Show("Veuillez saisir un prix valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AjouterServiceALaBaseDeDonnees(string nomService, double prixService)
        {
            try
            {
                string connectionString = "Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO services (libelle, prix_unitaire) VALUES (@NomService, @PrixService)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NomService", nomService);
                        command.Parameters.AddWithValue("@PrixService", prixService);

                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout du service : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
