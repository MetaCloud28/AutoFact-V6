using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace AutoFact
{
    public partial class ModifierAutoEntrepreneurPage : Page
    {
        public AutoEntrepreneur Entrepreneur { get; set; }

        public ModifierAutoEntrepreneurPage(AutoEntrepreneur entrepreneur)
        {
            InitializeComponent();
            Entrepreneur = entrepreneur;
            DataContext = Entrepreneur;
        }

        private void Enregistrer_Click(object Sender, RoutedEventArgs e)
        {
            try
            {
                // Clone the original entrepreneur to compare changes
                AutoEntrepreneur originalEntrepreneur = new AutoEntrepreneur
                {
                    Id = Entrepreneur.Siret,
                    Nom = Entrepreneur.Nom,
                    Tel = Entrepreneur.Tel,
                    Email = Entrepreneur.Email,
                    Adresse = Entrepreneur.Adresse
                };

                // Update the entrepreneur with the new values
                Entrepreneur.Nom = txtNom.Text;
                Entrepreneur.Tel = int.Parse(txtTelephone.Text);
                Entrepreneur.Email = txtEmail.Text;
                Entrepreneur.Adresse = txtAdresse.Text;
                Entrepreneur.Id= int.Parse(txtid.Text);

                // Debug output for comparison
                Console.WriteLine("Original Entrepreneur: " + originalEntrepreneur.ToString());
                Console.WriteLine("Update Entrepreneur: " + Entrepreneur.ToString());

                // Compare the original and updated entrepreneurs
                if (originalEntrepreneur.Id != Entrepreneur.Id ||
                    originalEntrepreneur.Nom != Entrepreneur.Nom ||
                    originalEntrepreneur.Tel != Entrepreneur.Tel ||
                    originalEntrepreneur.Email != Entrepreneur.Email ||
                    originalEntrepreneur.Adresse != Entrepreneur.Adresse)
                {
                    // Mettez à jour la base de données avec les nouvelles informations
                    string connexionString = "Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;";
                    using (SQLiteConnection conn = new SQLiteConnection(connexionString))
                    {
                        conn.Open();
                        string query = "UPDATE auto_entrepreneur SET Nom = @Nom, Téléphone = @Tel, email = @Email, adresse = @Adresse";
                        //using (SQLiteCommand cmd = new SQLiteCommand(" update auto_entrepreneur SET Nom ='" + txtNom.Text + "', Téléphone = '" + txtTelephone.Text + "', email='" + txtEmail.Text + "', adresse = '" + txtAdresse.Text + "', WHERE id = @Id ", conn))
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Nom", Entrepreneur.Nom);
                            cmd.Parameters.AddWithValue("@Tel", Entrepreneur.Tel);
                            cmd.Parameters.AddWithValue("@Email", Entrepreneur.Email);
                            cmd.Parameters.AddWithValue("@Adresse", Entrepreneur.Adresse);
                            cmd.Parameters.AddWithValue("@Id", Entrepreneur.Id);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Mise à jour réussie
                                Console.WriteLine("Mise à jour réussie.");
                                MessageBox.Show("Mise à jour réussie.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

                                if (NavigationService != null)
                                {
                                    NavigationService.Navigate(new parametres());
                                }
                                else
                                {
                                    MessageBox.Show("NavigationService is not available.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                // Aucune ligne mise à jour
                                Console.WriteLine("Aucune ligne mise à jour.");
                                MessageBox.Show("Aucune ligne mise à jour.", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }
                    }
                }
                else
                {
                    // Aucune modification n'a été apportée
                    Console.WriteLine("Aucune modification n'a été apportée.");
                    MessageBox.Show("Aucune modification n'a été apportée.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating auto-entrepreneur: {ex.Message}");
                MessageBox.Show($"Error updating auto-entrepreneur: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            // Naviguer vers la page parametres
            if (NavigationService != null)
            {
                NavigationService.Navigate(new parametres());
            }
            else
            {
                MessageBox.Show("NavigationService is not available.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }

}
