using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Data.SQLite;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;

namespace AutoFact
{
    public partial class parametres : Page
    {
        private SQLiteConnection database;


        public parametres()
        {
            InitializeComponent();
            LoadAuto_Entrepreneur();

        }

        private void LoadAuto_Entrepreneur()
        {
            try
            {
                // Annuler la liaison de la source de données actuelle
                listViewClients.ItemsSource = null;

                // Obtenir les nouvelles données
                List<AutoEntrepreneur> autoEntrepreneurs = GetAuto_Entrepreneur();

                // Définir la nouvelle source de données
                listViewClients.ItemsSource = autoEntrepreneurs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading auto-entrepreneurs: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<AutoEntrepreneur> GetAuto_Entrepreneur()
        {
            List<AutoEntrepreneur> autoEntrepreneurs = new List<AutoEntrepreneur>();
            string connectionString = "Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM auto_entrepreneur";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AutoEntrepreneur entrepreneur = new AutoEntrepreneur();

                                if (long.TryParse(reader["id"].ToString(), out long id))
                                    entrepreneur.Id = id;
                                else
                                    entrepreneur.Id = 0; // Ou une valeur par défaut

                                entrepreneur.Tel = reader["Tel"].ToString(); // Correction ici
                                entrepreneur.Nom = reader["Nom"].ToString();
                                entrepreneur.Email = reader["email"].ToString();
                                entrepreneur.Adresse = reader["adresse"].ToString();
                                entrepreneur.Siret = reader["Siret"].ToString();

                                autoEntrepreneurs.Add(entrepreneur);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading auto-entrepreneurs: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return autoEntrepreneurs;
        }

        private void ModifierAutoEntrepreneur_Click(object sender, RoutedEventArgs e)
        {
            if (listViewClients.SelectedItem != null)
            {
                AutoEntrepreneur entrepreneurSelectionne = (AutoEntrepreneur)listViewClients.SelectedItem;

                // Make sure you are using the correct navigation service
                if (NavigationService != null)
                {
                    ModifierAutoEntrepreneurPage modifierPage = new ModifierAutoEntrepreneurPage(entrepreneurSelectionne);
                    NavigationService.Navigate(modifierPage);
                }
                else
                {
                    // Handle the case where NavigationService is null (e.g., navigation outside of a frame)
                    MessageBox.Show("NavigationService is not available.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void ListViewClients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Assuming you're handling double-clicks on the ListView itself
            // Call the same method as when the button is clicked
            ModifierAutoEntrepreneur_Click(sender, e);
        }

                private void ModifierAutoEntrepreneur(AutoEntrepreneur entrepreneur)
        {
            try
            {
                string connectionString = "Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;";
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE auto_entrepreneur SET Nom = @Nom, Tel = @Tel, email = @Email, adresse = @Adresse WHERE Siret = @Siret";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nom", entrepreneur.Nom);
                        cmd.Parameters.AddWithValue("@Tel", entrepreneur.Tel);
                        cmd.Parameters.AddWithValue("@Email", entrepreneur.Email);
                        cmd.Parameters.AddWithValue("@Adresse", entrepreneur.Adresse);
                        cmd.Parameters.AddWithValue("@Siret", entrepreneur.Siret);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating auto-entrepreneur: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void listViewClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        internal void Show()
        {
            throw new NotImplementedException();
        }
        private void SupprimerAutoEntrepreneur_Click(object sender, RoutedEventArgs e)
        {
            if (listViewClients.SelectedItem != null)
            {
                AutoEntrepreneur entrepreneurSelectionne = (AutoEntrepreneur)listViewClients.SelectedItem;

                if (MessageBox.Show($"Voulez-vous vraiment supprimer l'auto-entrepreneur {entrepreneurSelectionne.Nom} ?", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SupprimerAutoEntrepreneur(entrepreneurSelectionne);
                    LoadAuto_Entrepreneur();
                }
            }
        }

        private void SupprimerAutoEntrepreneur(AutoEntrepreneur entrepreneur)
        {
            try
            {
                string connectionString = "Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;";
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM auto_entrepreneur WHERE Siret = @Siret";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Siret", entrepreneur.Siret);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting auto-entrepreneur: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



    }

    public class AutoEntrepreneur
{
    public long Id { get; set; }
    public string Siret { get; set; }
    public string Tel { get; set; }
    public string Nom { get; set; }
    public string Email { get; set; }
    public string Adresse { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        AutoEntrepreneur other = (AutoEntrepreneur)obj;
        return Id == other.Id &&
               string.Equals(Siret, other.Siret, StringComparison.Ordinal) &&
               string.Equals(Tel, other.Tel, StringComparison.Ordinal) &&
               string.Equals(Nom, other.Nom, StringComparison.Ordinal) &&
               string.Equals(Email, other.Email, StringComparison.Ordinal) &&
               string.Equals(Adresse, other.Adresse, StringComparison.Ordinal);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Siret, Tel, Nom, Email, Adresse);
    }
}



}