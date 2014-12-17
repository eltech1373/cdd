using System.Linq;
using System.Threading.Tasks;

namespace ccd
{
    public class GameMechanics
    {
        public Player[] Player { get; private set; }
        public int CurrentPlayer { get; private set; } //attacker
        private int _anotherPlayer
        {
            get { return CurrentPlayer == 0 ? 1 : 0; }
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

            Player[CurrentPlayer].Gold += defCard.Hp > 0 ? 1 : atkCard.Hp > 0 ? 4 : 3;
            Player[_anotherPlayer].Gold += atkCard.Hp > 0 ? 1 : defCard.Hp > 0 ? 4 : 3;

            if (defCard.Hp <= 0)
            {
                Player[_anotherPlayer].Table.Remove(defCard);
            }
            if (atkCard.Hp <= 0)
            {
                Player[CurrentPlayer].Table.Remove(atkCard);
            }
        }

        public void PlayCard(Card currentCard)
        {
            Player[CurrentPlayer].Table.Add(currentCard);
            Player[CurrentPlayer].Hand.Remove(currentCard);
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
            CurrentPlayer = _anotherPlayer;
            Player[CurrentPlayer].Morale += 3;
            if (Player[CurrentPlayer].Deck.Count > 0 && Player[CurrentPlayer].Hand.Count < 5)
            {
                Card cardGoToHand = Player[CurrentPlayer].Deck.First();
                Player[CurrentPlayer].Hand.Add(cardGoToHand);
                Player[CurrentPlayer].Deck.Remove(cardGoToHand);
            }
            foreach (Card card in Player[CurrentPlayer].Table)
            {
                card.Block = false;
            }
        }

        private void _getSpecialAbilities(Card card)
        {
            switch (card.SpecialType)
            {
                case CardSpecType.AddAtk:
                    Parallel.ForEach(Player[CurrentPlayer].Table, (c) => { c.Atk += card.SpecialValue; });
                    break;
                case CardSpecType.AddHp:
                    Parallel.ForEach(Player[CurrentPlayer].Table, (c) => { c.Hp += card.SpecialValue; });
                    break;
                default:
                    break;
            }
        }
    }
}
