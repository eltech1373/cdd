using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccd
{
    public class Player
    {
        public List<Card> Deck = new List<Card>();
        public List<Card> Hand = new List<Card>();
        public List<Card> Table = new List<Card>();
        public int Hp;
        public int Gold;
        public int Morale;
        
        public Player()
        {
            Hp = 30;
            Gold = 5;
            Morale = 0;
            var newDeck = Helper.CreateNewDeck();
            Hand = new List<Card>();
            Hand.Add(newDeck[0]);
            newDeck.Remove(newDeck[0]);
            Deck = newDeck;
            Table = new List<Card>();
        }
    }

    public class Card
    {
        public int Hp;
        public int Atk;
        public int Rang = 1;
        public CardSpecType SpecialType = CardSpecType.Nothing;
        public CardType Type = CardType.Unit;
        public bool Block;
        public int SpecialValue;
    }

    public enum CardSpecType
    {
        Nothing = 0,
        AtkPlayer = 1,
        AtkAllCards = 2,
        AtkBuilding = 3,
        AddAtk = 4,
        AddHp = 5
    }

    public enum CardType
    {
        Unit = 1,
        Building = 2
    }
}
