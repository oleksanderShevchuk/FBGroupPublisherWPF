using FBGroupPublisher.Services;
using FBGroupPublisher.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace FBGroupPublisher.Components
{
    /// <summary>
    /// Interaction logic for LoginWithFacebook.xaml
    /// </summary>
    public partial class LoginWithFacebook : UserControl
    {
        public LoginWithFacebook()
        {
            InitializeComponent();
            DataContext = new LoginWithFacebookViewModel();
        }
    }
}
