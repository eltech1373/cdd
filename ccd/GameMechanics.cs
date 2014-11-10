using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccd
{
    public class GameMechanics
    {
        private Player _player1;
        private Player _player2;

        public GameMechanics()
        {
            _player1.Deck = _createNewDeck();
            _player2.Deck = _createNewDeck();
        }

        private List<Card> _createNewDeck()
        {
            List<Card> newDeck = new List<Card>();
            newDeck.Add(new Card() {Atk = 1, Hp = 2});
            newDeck.Add(new Card() {Atk = 2, Hp = 1});

            return newDeck;
        }
    }
}
