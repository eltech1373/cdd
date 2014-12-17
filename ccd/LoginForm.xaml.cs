using System;
using System.Windows;
using System.Windows.Input;

namespace ccd
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            loginButton.Click += LoginButtonOnClick;
            passwordBox.KeyUp += PasswordBoxOnKeyUp;
        }

        private void PasswordBoxOnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginButtonOnClick(this, e);
            }
        }

        private void LoginButtonOnClick(object sender, RoutedEventArgs e)
        {
            errorTextBox.Visibility = Visibility.Collapsed;
            User user = new User()
                {
                    Name = loginTextBox.Text,
                    Pass = passwordBox.Password
                };

            bool success;
            try
            {
                success = DatabaseWorker.Login(user);
            }
            catch (Exception ex)
            {
                errorTextBox.Visibility = Visibility.Visible;
                return;
            }

            if (user.Id != Guid.Empty && success)
            {
                DialogResult = true;
            }
            else
            {
                errorTextBox.Visibility = Visibility.Visible;
            }
        }
    }
}
