using System;
using System.Windows;

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
