using System;
using System.Windows;

namespace Kartenspiel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            this.main.Navigate(new Uri("Fenster/Login.xaml", UriKind.Relative));
        }
    }
}
