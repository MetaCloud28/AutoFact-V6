using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using AutoFact;
using System.Data.SQLite;
using System.Windows.Input;

namespace RegistrationLoginConcept
{
    public partial class LoginPage : Window
    {
        private SQLiteConnection sqliteConnection;
        public LoginPage()
        {
            InitializeComponent();
            ConnectToDatabase();
        }

        private void ConnectToDatabase()
        {
            try
            {
                string connectionString = "Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;";
                sqliteConnection = new SQLiteConnection(connectionString);
                sqliteConnection.Open();
                // Perform database operations here
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to database: {ex.Message}");
            }
        }

        // Add additional methods for executing queries, retrieving data, etc.

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Close the database connection when the window is closing
            sqliteConnection?.Close();
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            // Check if the pressed key is Enter
            if (e.Key == Key.Enter)
            {
                // Invoke the button click event programmatically
                Button_Click(sender, e);
            }
        }

        private void txtid_KeyUp(object sender, KeyEventArgs e)
        {
            // Check if the pressed key is Enter
            if (e.Key == Key.Enter && sender == txtid)
            {
                // Invoke the button click event programmatically
                Button_Click(sender, e);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtid.Text.Length == 0)
            {
                errormessage.Text = "Enter an SIRET";
                txtid.Focus();
            }
            else if (!Regex.IsMatch(txtid.Text, "[0-9]{14}"))
            {
                errormessage.Text = "Enter a valid SIRET.";
                txtid.Select(0, txtid.Text.Length);
                txtid.Focus();
            }
            else
            {
                string id = txtid.Text;

                using (SQLiteConnection con = new SQLiteConnection("Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;"))
                {
                    con.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM auto_entrepreneur WHERE Id = @Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                MainWindow mm = new MainWindow();
                                mm.Show();
                                Close();
                            }
                            else
                            {
                                errormessage.Text = "Sorry! Please enter an existing SIRET.";
                            }
                        }
                    }
                }
            }
        }




        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage mm = new RegisterPage();
            mm.Show();
            Close();
        }
       
    }
}