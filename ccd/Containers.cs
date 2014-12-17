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
            Hand = Helper.CreateNewDeck(Helper.HandCount);
            Deck = Helper.CreateNewDeck(Helper.DeckCount);
            Table = new List<Card>();
        }
    }

    public class Card
    {
        public Guid Id;
        public string Name;
        public int Hp;
        public int Atk;
        public int Rang = 1;
        public CardSpecType SpecialType = CardSpecType.Nothing;
        public CardType Type = CardType.Unit;
        public bool Block;
        public int SpecialValue;

        public Card(string name, int hp, int atk, int rang)
        {
            Name = name;
            Hp = hp;
            Atk = atk;
            Rang = rang;
        }

        public Card()
        {
            
        }
    }

    public class User
    {
        public string Name;
        public string Pass;
        public UserAccessType Type;
        public Guid Id;
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

    public enum UserAccessType
    {
        Admin = 0,
        User = 1
    }
}
