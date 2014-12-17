using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ccd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameMechanics _game;

        public MainWindow()
        {
            InitializeComponent();
            endTurnButton.Click += EndTurnButtonOnClick;

            var login = new LoginWindow();
            login.ShowDialog();

            if (login.DialogResult == true)
            {
                _startGame();
            }
            else
            {
                this.Close();
            }
        }

        private void EndTurnButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            _game.EndTurn();
            _updateLabels();
        }

        private void _startGame()
        {
            _game = new GameMechanics();
            _updateLabels();
        }

        private void _updateLabels()
        {
            hp1.Content = _game.Player[0].Hp;
            moraleLabel1.Content = _game.Player[0].Morale;
            goldLabel1.Content = _game.Player[0].Gold;

            hp2.Content = _game.Player[1].Hp;
            moraleLabel2.Content = _game.Player[1].Morale;
            goldLabel2.Content = _game.Player[1].Gold;

            for (int i = 0; i < handStackPanel1.Children.Count; i++)
            {
                var child = handStackPanel1.Children[i];
                child.Visibility = _game.Player[0].Hand[i].Hp > 0 ? Visibility.Visible : Visibility.Hidden;
            }

            for (int i = 0; i < buildsStackPanel1.Children.Count; i++)
            {
                var child = buildsStackPanel1.Children[i];
                child.Visibility = _game.Player[0].Hand[i].Hp < 0 ? Visibility.Visible : Visibility.Hidden;
            }

            for (int i = 0; i < unitStackPanel1.Children.Count; i++)
            {
                var child = unitStackPanel1.Children[i];
                child.Visibility = _game.Player[0].Hand[i].Hp > 0 ? Visibility.Visible : Visibility.Hidden;
            }

            for (int i = 0; i < handStackPanel2.Children.Count; i++)
            {
                var child = handStackPanel2.Children[i];
                child.Visibility = _game.Player[1].Hand[i].Hp > 0 ? Visibility.Visible : Visibility.Hidden;
            }

            for (int i = 0; i < buildsStackPanel2.Children.Count; i++)
            {
                var child = buildsStackPanel2.Children[i];
                child.Visibility = _game.Player[1].Hand[i].Hp > 0 ? Visibility.Visible : Visibility.Hidden;
            }

            for (int i = 0; i < unitStackPanel2.Children.Count; i++)
            {
                var child = unitStackPanel2.Children[i];
                child.Visibility = _game.Player[1].Hand[i].Hp > 0 ? Visibility.Visible : Visibility.Hidden;
            }
        }
    }
}
