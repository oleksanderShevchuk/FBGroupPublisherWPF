using Facebook;
using System.Windows;

namespace FBGroupPublisher.Services
{
    public class FacebookService
    {
        private readonly string _appId;
        private readonly string _appSecret;
        private FacebookClient _facebookClient;

        public FacebookService(string appId, string appSecret)
        {
            _appId = appId;
            _appSecret = appSecret;
        }

        public async Task<bool> LoginAsync()
        {
            try
            {
                _facebookClient = new FacebookClient();

                // Отримайте доступ до токену доступу через веб-браузер
                dynamic result = await _facebookClient.GetTaskAsync("oauth/access_token", new
                {
                    client_id = _appId,
                    client_secret = _appSecret,
                    grant_type = "client_credentials"
                });

                _facebookClient.AccessToken = result.access_token;

                // Перевірка токену доступу
                var isValid = await ValidateTokenAsync();

                if (isValid)
                {
                    // Отримайте інформацію про користувача із Facebook
                    dynamic fbUser = await _facebookClient.GetTaskAsync("me", new { fields = "id,name,email" });

                    string userId = fbUser.id;
                    string userName = fbUser.name;
                    string email = fbUser.email;

                    MessageBox.Show($"Ви успішно увійшли через Facebook! User ID: {userId}, Name: {userName}, Email: {email}");

                    return true;
                }
                else
                {
                    MessageBox.Show("Токен доступу недійсний.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка входу через Facebook: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> ValidateTokenAsync()
        {
            try
            {
                dynamic result = await _facebookClient.GetTaskAsync("debug_token", new
                {
                    input_token = _facebookClient.AccessToken,
                    access_token = _appId + "|" + _appSecret
                });

                bool isValid = result.data.is_valid;
                return isValid;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка перевірки токену доступу: {ex.Message}");
                return false;
            }
        }
    }
}
