using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace AutoFact
{
    public partial class ModifierService : Window
    {
        private DataRowView _selectedService;

        public ModifierService(DataRowView selectedService)
        {
            InitializeComponent();
            _selectedService = selectedService;
            Nametxt.Text = _selectedService["Nom"].ToString();
            Prixtxt.Text = _selectedService["Prix"].ToString();
        }





        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérez les données du formulaire de modification
            string nouveauNomService = Nametxt.Text;
            double nouveauPrixService;

            if (double.TryParse(Prixtxt.Text, out nouveauPrixService))
            {
                // Récupérez l'ID du service à modifier (vous devez le récupérer d'une manière appropriée)
                int serviceId = Convert.ToInt32(_selectedService["id"]);

                // Mettez à jour le service dans la base de données
                ModifierServiceDansLaBaseDeDonnees(serviceId, nouveauNomService, nouveauPrixService);

                // Fermez la fenêtre de modification
                Close();
            }
            else
            {
                MessageBox.Show("Veuillez saisir un prix valide.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


      private void ModifierServiceDansLaBaseDeDonnees(int serviceId, string nouveauNomService, double nouveauPrixService)
{
    try
    {
        string connectionString = "Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;";
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = "UPDATE services SET libelle = @NouveauNomService, prix_unitaire = @NouveauPrixService WHERE id = @ServiceId";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NouveauNomService", nouveauNomService);
                command.Parameters.AddWithValue("@NouveauPrixService", nouveauPrixService);
                command.Parameters.AddWithValue("@ServiceId", serviceId);

                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Erreur lors de la modification du service : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}


        // Méthode fictive pour récupérer l'ID du service à modifier (vous devez implémenter cette méthode selon votre logique)
        private int GetServiceId()
        {
            // Implémentez votre logique pour récupérer l'ID du service à modifier
            return 0;
        }
    }
}
