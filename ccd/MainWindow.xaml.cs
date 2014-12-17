using System.Windows;

namespace ccd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var login = new LoginWindow();
            login.ShowDialog();

            if (DialogResult == true)
            {
                //загружаем данные
            }
            else
            {
                this.Close();
            }
        }
    }
}
