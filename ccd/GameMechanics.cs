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

        public bool Attack(Card atkCard, Card defCard)
        {
            if (atkCard.Block || atkCard.Type == CardType.Building || !Player[CurrentPlayer].Table.Contains(atkCard) || !Player[_anotherPlayer].Table.Contains(defCard))
            {
                return false;
            }

            defCard.Hp -= atkCard.Atk;
            atkCard.Hp -= defCard.Atk;

            Player[CurrentPlayer].Gold += defCard.Hp > 0 ? 1 : atkCard.Hp > 0 ? 4 : 3;
            Player[_anotherPlayer].Gold += atkCard.Hp > 0 ? 1 : defCard.Hp > 0 ? 4 : 3;

            atkCard.Block = true;

            if (defCard.Hp <= 0)
            {
                Player[_anotherPlayer].Table.Remove(defCard);
            }
            if (atkCard.Hp <= 0)
            {
                Player[CurrentPlayer].Table.Remove(atkCard);
            }

            return true;
        }

        public bool PlayCard(Card currentCard)
        {
            if (Player[CurrentPlayer].Hand.Contains(currentCard))
            {
                if (currentCard.Type == CardType.Unit && Player[CurrentPlayer].Morale < currentCard.Rang)
                {
                    return false;
                }
                else if (currentCard.Type == CardType.Building && Player[CurrentPlayer].Gold < currentCard.Rang)
                {
                    return false;
                }
                 
                Player[CurrentPlayer].Table.Add(currentCard);
                Player[CurrentPlayer].Hand.Remove(currentCard);
                if (currentCard.Type == CardType.Building)
                {
                    currentCard.Block = false;
                    _getSpecialAbilities(currentCard);
                    Player[CurrentPlayer].Gold -= currentCard.Rang;
                }
                else
                {
                    currentCard.Block = true;
                    Player[CurrentPlayer].Morale -= currentCard.Rang;
                }
                return true;
            }

            return false;
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
