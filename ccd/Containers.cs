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
        public Card[] Hand = new Card[] {};
        public int Hp;
        public int Resource;
    }

    public class Card
    {
        public int Hp;
        public int Atk;
        public CardSpecType Type = 0;
    }

    public enum CardSpecType
    {
        Nothing = 0,
        AtkPlayer = 1,
        AtkAllCards = 2
    }
}
