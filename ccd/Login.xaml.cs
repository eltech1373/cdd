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

        private void LoginButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            errorTextBox.Visibility = Visibility.Collapsed;
            User user = new User()
                {
                    Name = loginTextBox.Text,
                    Pass = passwordBox.Password
                };

            try
            {
                DatabaseWorker.Login(user);
            }
            catch (Exception ex)
            {
                errorTextBox.Visibility = Visibility.Visible;
                return;
            }

            if (user.Id != Guid.Empty)
            {
                //success
            }
            else
            {
                errorTextBox.Visibility = Visibility.Visible;
            }
        }
    }
}
