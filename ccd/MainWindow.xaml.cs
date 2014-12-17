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


        }
    }
}
