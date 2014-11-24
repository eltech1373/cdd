using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccd
{
    public static class Helper
    {
        public static List<Card> CreateNewDeck()
        {
            List<Card> newDeck = new List<Card>();
            newDeck.Add(new Card() { Atk = 1, Hp = 2 });
            newDeck.Add(new Card() { Atk = 2, Hp = 1 });

            return newDeck;
        }
    }
}
