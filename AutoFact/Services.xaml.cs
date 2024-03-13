// Services.xaml.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace AutoFact
{
    public partial class Services : Page
    {
        public Services()
        {
            InitializeComponent();
            LoadServicesFromDatabase();
        }




        private void SupprimerButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DataRowView row = btn.CommandParameter as DataRowView;

            if (row != null && MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce service?", "Confirmer", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                int serviceId = Convert.ToInt32(row["id"]);
                SupprimerServiceDeLaBaseDeDonnees(serviceId);
                LoadServicesFromDatabase(); // Méthode pour recharger les données dans la ListView
            }
        }




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

        private void LoadServicesFromDatabase()
        {
            try
            {
                string connectionString = "Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;"; // Mettez à jour avec votre propre chaîne de connexion SQLite

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, libelle AS Nom, prix_unitaire AS Prix FROM services";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Lier la DataTable à la ListView
                        Services_lv.ItemsSource = dataTable.DefaultView;
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des services : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }





        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = Services_lv.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                ModifierService modifierServiceWindow = new ModifierService(selectedRow);
                modifierServiceWindow.ShowDialog();
                LoadServicesFromDatabase();

            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un service à modifier.", "Aucun service sélectionné", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void ListViewClients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Assuming you're handling double-clicks on the ListView itself
            // Call the same method as when the button is clicked
            ModifierButton_Click(sender, e);
        }



        private void AjouterServiceButton_Click(object sender, RoutedEventArgs e)
        {
            // Ouvrir le formulaire AjouterService en tant que fenêtre modale
            AjouterService ajouterServiceWindow = new AjouterService();

            // Attacher un gestionnaire d'événements pour être informé lorsque le formulaire est fermé
            ajouterServiceWindow.Closed += AjouterServiceWindow_Closed;

            // Afficher le formulaire en tant que fenêtre modale
            ajouterServiceWindow.ShowDialog();
        }

        // Gestionnaire d'événements appelé lorsque le formulaire AjouterService est fermé
        private void AjouterServiceWindow_Closed(object sender, EventArgs e)
        {
            // Recharger les services après la fermeture du formulaire pour afficher les mises à jour
            LoadServicesFromDatabase();
        }

    }
}
