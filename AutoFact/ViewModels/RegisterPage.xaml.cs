using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data.SQLite;
using AutoFact;

namespace RegistrationLoginConcept
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        private SQLiteConnection con;
        public RegisterPage()
        {
            InitializeComponent();

        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            // Check if the pressed key is Enter
            if (e.Key == Key.Enter)
            {
                // Invoke the button click event programmatically
                btnSubmit_Click(sender, e);
            }
            if (e.Key == Key.Delete)
            {
                // Invoke the button click event programmatically
                btnReset_Click(sender, e);
            }
        }



        private void txtid_KeyUp(object sender, KeyEventArgs e)
        {
            // Check if the pressed key is Enter
            if (e.Key == Key.Enter && sender == btnSubmit)
            {
                // Invoke the button click event programmatically
                btnSubmit_Click(sender, e);
            }
        }

        //SqlConnection con;
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            lblmessage.Content = "";
            con = new SQLiteConnection("Data Source=C:\\Users\\brunel\\Documents\\test autofact\\AutoFactV2-main\\AutoFactV2-main\\AutoFact\\database.db;Version=3;");


            if (txtUserName.Text.Length == 0)
            {
                lblmessage.Visibility = System.Windows.Visibility.Visible;
                lblmessage.Foreground = Brushes.Red;
                lblmessage.Content = "Enter an Name.";

                txtUserName.Focus();
            }
            else
            {
                if (txtsiret.Text.Length == 0)
                {
                    lblmessage.Visibility = System.Windows.Visibility.Visible;
                    lblmessage.Foreground = Brushes.Red;
                    lblmessage.Content = "Enter an siret.";

                    txtsiret.Focus();
                }
                else if (!Regex.IsMatch(txtsiret.Text, "[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]"))
                {
                    lblmessage.Visibility = System.Windows.Visibility.Visible;
                    lblmessage.Foreground = Brushes.Red;
                    lblmessage.Content = "Enter a valid siret.";

                    txtsiret.Select(0, txtsiret.Text.Length);

                    txtsiret.Focus();

                }
                else {
                    if (txtsiret.Text.Length == 0)
                    {
                        lblmessage.Visibility = System.Windows.Visibility.Visible;
                        lblmessage.Foreground = Brushes.Red;
                        lblmessage.Content = "Confirme siret.";

                        txtsiret.Focus();
                    }
                    else if (txtsiretconf.Text.Length == 0 || txtsiretconf.Text != txtsiret.Text)
                    {
                        lblmessage.Visibility = System.Windows.Visibility.Visible;
                        lblmessage.Foreground = Brushes.Red;
                        lblmessage.Content = "Confirmation of SIRET does not match.";

                        txtsiretconf.Select(0, txtsiretconf.Text.Length);

                        txtsiretconf.Focus();
                    }
                    else
                    {
                        if (txtemail.Text.Length == 0)

                        {
                            lblmessage.Visibility = System.Windows.Visibility.Visible;
                            lblmessage.Foreground = Brushes.Red;
                            lblmessage.Content = "Enter an email.";

                            txtemail.Focus();

                        }

                        else if (!Regex.IsMatch(txtemail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                        {
                            lblmessage.Visibility = System.Windows.Visibility.Visible;
                            lblmessage.Foreground = Brushes.Red;
                            lblmessage.Content = "Enter a valid email.";

                            txtemail.Select(0, txtemail.Text.Length);

                            txtemail.Focus();

                        }


                        else
                        {
                            if (txttel.Text.Length == 0)

                            {
                                lblmessage.Visibility = System.Windows.Visibility.Visible;
                                lblmessage.Foreground = Brushes.Red;
                                lblmessage.Content = "Enter an numéro.";

                                txttel.Focus();

                            }

                            else if (!Regex.IsMatch(txttel.Text, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"))
                            {
                                lblmessage.Visibility = System.Windows.Visibility.Visible;
                                lblmessage.Foreground = Brushes.Red;
                                lblmessage.Content = "Enter a valid numéro.";

                                txttel.Select(0, txttel.Text.Length);

                                txttel.Focus();

                            }

                            else
                            {
                                using (SQLiteCommand cmd = new SQLiteCommand("INSERT INTO auto_entrepreneur (Nom, Siret, Tel, adresse, email) VALUES(@Nom, @Siret, @Tel, @adresse, @email)", con))
                                {
                                    cmd.Parameters.AddWithValue("@Nom", txtUserName.Text);
                                    cmd.Parameters.AddWithValue("@Siret", txtsiret.Text);
                                    cmd.Parameters.AddWithValue("@Tel", txttel.Text);
                                    cmd.Parameters.AddWithValue("@adresse", txtaddress.Text);
                                    cmd.Parameters.AddWithValue("@email", txtemail.Text);

                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                    lblmessage.Visibility = System.Windows.Visibility.Visible;
                                    lblmessage.Foreground = Brushes.Green;
                                    lblmessage.Content = "Inscription réussie";
                                    LoginPage mm = new LoginPage();
                                    mm.Show();
                                    Close();
                                }

                            }
                        }
                    }
                }
            }
        }
        // Resert all control
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetAllClear();
        }

        private void ResetAllClear()
        {
            foreach (UIElement ui in ChildGrid.Children)
            {
                if (ui is TextBox)
                {
                    TextBox tt = (TextBox)ui;
                    tt.Text = "";
                }
                if (ui is PasswordBox)
                {
                    PasswordBox pp = (PasswordBox)ui;
                    pp.Password = "";
                }

            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginPage ll = new LoginPage();
            ll.Show();
            Close();
        }
    }

}


