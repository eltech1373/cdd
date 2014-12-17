using System.Linq;
using System.Threading.Tasks;

namespace ccd
{
    public class GameMechanics
    {
        public Player[] Player { get; private set; }
        private int _currentPlayer = 0; //attacker
        private int _anotherPlayer
        {
            get { return _currentPlayer == 0 ? 1 : 0; }
        }
        
        public GameMechanics()
        {
            Player = new Player[2];
            Player[0] = new Player();
            Player[1] = new Player();
        }

        public void Attack(Card atkCard, Card defCard)
        {
            if (atkCard.Block || atkCard.Type == CardType.Building)
            {
                return;
            }

            defCard.Hp -= atkCard.Atk;
            atkCard.Hp -= defCard.Atk;

            Player[_currentPlayer].Gold += defCard.Hp > 0 ? 1 : atkCard.Hp > 0 ? 4 : 3;
            Player[_anotherPlayer].Gold += atkCard.Hp > 0 ? 1 : defCard.Hp > 0 ? 4 : 3;

            if (defCard.Hp <= 0)
            {
                Player[_anotherPlayer].Table.Remove(defCard);
            }
            if (atkCard.Hp <= 0)
            {
                Player[_currentPlayer].Table.Remove(atkCard);
            }
        }

        public void PlayCard(Card currentCard)
        {
            Player[_currentPlayer].Table.Add(currentCard);
            Player[_currentPlayer].Hand.Remove(currentCard);
            if (currentCard.Type == CardType.Building)
            {
                currentCard.Block = false;
                _getSpecialAbilities(currentCard);
            }
            else
            {
                currentCard.Block = true;
            }
        }

        public void EndTurn()
        {
            _currentPlayer = _anotherPlayer;
            Player[_currentPlayer].Morale += 3;
            if (Player[_currentPlayer].Deck.Count > 0)
            {
                Card cardGoToHand = Player[_currentPlayer].Deck.First();
                Player[_currentPlayer].Hand.Add(cardGoToHand);
                Player[_currentPlayer].Deck.Remove(cardGoToHand);
            }
            foreach (Card card in Player[_currentPlayer].Table)
            {
                card.Block = false;
            }
        }

        private void _getSpecialAbilities(Card card)
        {
            switch (card.SpecialType)
            {
                case CardSpecType.AddAtk:
                    Parallel.ForEach(Player[_currentPlayer].Table, (c) => { c.Atk += card.SpecialValue; });
                    break;
                case CardSpecType.AddHp:
                    Parallel.ForEach(Player[_currentPlayer].Table, (c) => { c.Hp += card.SpecialValue; });
                    break;
                default:
                    break;
            }
        }
    }
}
