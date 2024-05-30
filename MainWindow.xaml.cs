using FBGroupPublisher.ViewModels;
using FBGroupPublisher.Views;
using System.Windows;
using System.Windows.Input;

namespace FBGroupPublisher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            MainView.Navigate(new MainView { DataContext = DataContext });
        }
    }
}