using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Data.SQLite;
using System.Windows;
using System.ComponentModel;

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

                            if (long.TryParse(reader["Téléphone"].ToString(), out long tel))
                                entrepreneur.Tel = tel;
                            else
                                entrepreneur.Tel = 0; // Ou une valeur par défaut

                            entrepreneur.Nom = reader["Nom"].ToString();
                            entrepreneur.Email = reader["email"].ToString();
                            entrepreneur.Adresse = reader["adresse"].ToString();

                            autoEntrepreneurs.Add(entrepreneur);
                        }
                        while (reader.Read())
                        {
                            AutoEntrepreneur entrepreneur = new AutoEntrepreneur();

                            if (!reader.IsDBNull(reader.GetOrdinal("id")) && long.TryParse(reader["id"].ToString(), out long id))
                                entrepreneur.Id = id;
                            else
                                entrepreneur.Id = 0; // Ou une valeur par défaut

                            if (!reader.IsDBNull(reader.GetOrdinal("Téléphone")) && long.TryParse(reader["Téléphone"].ToString(), out long tel))
                                entrepreneur.Tel = tel;
                            else
                                entrepreneur.Tel = 0; // Ou une valeur par défaut

                            entrepreneur.Nom = reader["Nom"].ToString();
                            entrepreneur.Email = reader["email"].ToString();
                            entrepreneur.Adresse = reader["adresse"].ToString();

                            autoEntrepreneurs.Add(entrepreneur);
                        }

                    }
                }
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





        private void ModifierAutoEntrepreneur(AutoEntrepreneur entrepreneur)
        {
            try
            {
                // Mise à jour dans la base de données
                string connectionString = "Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;";
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE auto_entrepreneur SET Nom = @Nom, Téléphone = @Tel, email = @Email, adresse = @Adresse WHERE id = @Id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nom", entrepreneur.Nom);
                        cmd.Parameters.AddWithValue("@Tel", entrepreneur.Tel);
                        cmd.Parameters.AddWithValue("@Email", entrepreneur.Email);
                        cmd.Parameters.AddWithValue("@Adresse", entrepreneur.Adresse);
                        cmd.Parameters.AddWithValue("@Id", entrepreneur.Id);
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
    }

    public class AutoEntrepreneur
    {
        public long Id { get; set; }
        public long Siret { get; set; }
        public long Tel { get; set; }
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
                   Tel == other.Tel &&
                   string.Equals(Nom, other.Nom, StringComparison.Ordinal) &&
                   string.Equals(Email, other.Email, StringComparison.Ordinal) &&
                   string.Equals(Adresse, other.Adresse, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((long)Id, (long)Tel, Nom, Email, Adresse);
        }

    }


}