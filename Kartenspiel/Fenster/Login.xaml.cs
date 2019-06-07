using System;
using System.Windows;
using System.Windows.Controls;

namespace Kartenspiel.Fenster
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public static Login window;

        public Login()
        {
            InitializeComponent();
            window = this;
        }

        private void BtnSpielStarte_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Fenster/Spielfeld.xaml", UriKind.Relative));
        }
    }
}
