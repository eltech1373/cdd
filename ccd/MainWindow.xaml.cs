using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace ccd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameMechanics _game;
        private Card _gamingCard;

        public MainWindow()
        {
            InitializeComponent();

            var login = new LoginWindow();
            login.ShowDialog();

            if (login.DialogResult == true)
            {
                _startGame();
                _initEvents();
            }
            else
            {
                this.Close();
            }
        }

        private void _initEvents()
        {
            endTurnButton.Click += EndTurnButtonOnClick;
            _updateEvents();
        }

        private void _updateEvents()
        {
            if (_game.CurrentPlayer == 0)
            {
                //hand
                for (int i = 0; i < handStackPanel1.Children.Count; i++)
                {
                    var child = handStackPanel1.Children[i];
                    child.MouseUp += HandOnMouseUp;
                }

                //hand
                for (int i = 0; i < handStackPanel2.Children.Count; i++)
                {
                    var child = handStackPanel2.Children[i];
                    child.MouseUp -= HandOnMouseUp;
                }
                
                buildsStackPanel1.MouseUp += TableOnMouseUp;
                unitStackPanel1.MouseUp += TableOnMouseUp;
                buildsStackPanel2.MouseUp -= TableOnMouseUp;
                unitStackPanel2.MouseUp -= TableOnMouseUp;
            }
            else
            {
                //hand
                for (int i = 0; i < handStackPanel1.Children.Count; i++)
                {
                    var child = handStackPanel1.Children[i];
                    child.MouseUp -= HandOnMouseUp;
                }

                buildsStackPanel1.MouseUp -= TableOnMouseUp;
                unitStackPanel1.MouseUp -= TableOnMouseUp;
                buildsStackPanel2.MouseUp += TableOnMouseUp;
                unitStackPanel2.MouseUp += TableOnMouseUp;
            }
        }

        private void TableOnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_gamingCard != null)
            {
                _game.PlayCard(_gamingCard);
                _updateLabels();
            }
        }

        private void HandOnMouseUp(object sender, MouseButtonEventArgs e)
        {
            var image = (sender as Image);
            if (image.Visibility == Visibility.Visible && image.Tag != null)
            {
                if (_gamingCard == null)
                {
                    image.Effect = new DropShadowEffect();
                    _gamingCard = (Card)image.Tag;
                }
                else if (_gamingCard == (Card)image.Tag)
                {
                    image.Effect = null;
                    _gamingCard = null;
                }
            }
        }

        private void EndTurnButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            _game.EndTurn();
            _updateLabels();
            _updateEvents();
        }

        private void _startGame()
        {
            _game = new GameMechanics();
            _updateLabels();
        }

        private void _updateLabels()
        {
            _gamingCard = null;

            hp1.Content = _game.Player[0].Hp;
            moraleLabel1.Content = _game.Player[0].Morale;
            goldLabel1.Content = _game.Player[0].Gold;

            hp2.Content = _game.Player[1].Hp;
            moraleLabel2.Content = _game.Player[1].Morale;
            goldLabel2.Content = _game.Player[1].Gold;

            //hand
            for (int i = 0; i < handStackPanel1.Children.Count; i++)
            {
                var child = handStackPanel1.Children[i] as Image;
                child.Visibility = _game.Player[0].Hand[i].Hp > 0 ? Visibility.Visible : Visibility.Hidden;
                child.Tag = _game.Player[0].Hand[i].Hp > 0 ? _game.Player[0].Hand[i] : null;
                child.Effect = null;
            }

            //building
            var buildings = _game.Player[0].Table.FindAll(card => card.Type == CardType.Building);
            for (int i = 0; i < buildsStackPanel1.Children.Count; i++)
            {
                var child = buildsStackPanel1.Children[i] as Image;
                child.Visibility = buildings.Count > i && buildings[i].Hp > 0 ? Visibility.Visible : Visibility.Hidden;
                child.Opacity = buildings.Count > i && buildings[i].Block ? 50 : 100;
                child.Tag = buildings.Count > i && buildings[i].Hp > 0 ? buildings[i] : null;
                child.Effect = null;
            }

            //unit
            var units = _game.Player[0].Table.FindAll(card => card.Type == CardType.Unit);
            for (int i = 0; i < unitStackPanel1.Children.Count; i++)
            {
                var child = unitStackPanel1.Children[i] as Image;
                child.Visibility = units.Count > i && units[i].Hp > 0 ? Visibility.Visible : Visibility.Hidden;
                child.Opacity = units.Count > i && units[i].Block ? 50 : 100;
                child.Tag = units.Count > i && units[i].Hp > 0 ? units[i] : null;
                child.Effect = null;
            }

            //hand
            for (int i = 0; i < handStackPanel2.Children.Count; i++)
            {
                var child = handStackPanel2.Children[i] as Image;
                child.Visibility = _game.Player[1].Hand[i].Hp > 0 ? Visibility.Visible : Visibility.Hidden;
                child.Tag = _game.Player[1].Hand[i].Hp > 0 ? _game.Player[1].Hand[i] : null;
                child.Effect = null;
            }

            //buid
            buildings = _game.Player[1].Table.FindAll(card => card.Type == CardType.Building);
            for (int i = 0; i < buildsStackPanel2.Children.Count; i++)
            {
                var child = buildsStackPanel2.Children[i] as Image;
                child.Visibility = buildings.Count > i && buildings[i].Hp > 0 ? Visibility.Visible : Visibility.Hidden;
                child.Opacity = buildings.Count > i && buildings[i].Block ? 50 : 100;
                child.Tag = buildings.Count > i && buildings[i].Hp > 0 ? buildings[i] : null;
                child.Effect = null;
            }

            //unit
            units = _game.Player[0].Table.FindAll(card => card.Type == CardType.Unit);
            for (int i = 0; i < unitStackPanel2.Children.Count; i++)
            {
                var child = unitStackPanel2.Children[i] as Image;
                child.Visibility = units.Count > i && units[i].Hp > 0 ? Visibility.Visible : Visibility.Hidden;
                child.Opacity = units.Count > i && units[i].Block ? 50 : 100;
                child.Tag = units.Count > i && units[i].Hp > 0 ? units[i] : null;
                child.Effect = null;
            }
        }
    }
}
