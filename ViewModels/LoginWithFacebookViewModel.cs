using FBGroupPublisher.Helpers;
using FBGroupPublisher.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace FBGroupPublisher.ViewModels
{
    public class LoginWithFacebookViewModel : INotifyPropertyChanged
    {
        private ICommand _loginCommand;
        private FacebookService _facebookService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new RelayCommand(async (obj) => await LoginAsync())); }
        }
        public LoginWithFacebookViewModel()
        {
            _facebookService = new FacebookService("766531745683171", "72331334afc5e24608ff90d65a1887a9");
        }

        private async Task LoginAsync()
        {
            bool isLoggedIn = await _facebookService.LoginAsync();
            if (isLoggedIn)
            {
                MessageBox.Show("Log in is successful!");
                // Додайте код для переходу на іншу сторінку, відображення вікна або інших дій після успішного входу
            }
            else
            {
                MessageBox.Show("Error log in Facebook.");
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
