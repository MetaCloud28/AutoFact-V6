using System;
using System.Collections.Generic;
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

namespace AutoFact
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            contentFrame.Navigate(new Page1());
            contentFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden; //Enlever la barre de navigation
        }

        //Deplacer la fenetre
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        // Fin Deplacer la fenetre



        //Navigation pour les vues
        private void home_button_Click(object sender, RoutedEventArgs e)
        {

            contentFrame.Navigate(new Page1()); //PAGE1 = Home

        }


        private void fav_button_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new Favoris());
        }

        private void etats_button_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new ETATS());
        }

        private void para_button_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new parametres());
        }

        private void services_button_Click(object sender, RoutedEventArgs e)
        {
            // Obtenez la référence de NavigationService à partir du Frame
            NavigationService navigationService = contentFrame.NavigationService;

            // Créez une nouvelle instance de la page Services
            Services servicesPage = new Services();

            // Utilisez la NavigationService pour effectuer la navigation
            navigationService.Navigate(servicesPage);
        }

        //Fin navigation pour les vues


        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void reduc_button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

    }

}
