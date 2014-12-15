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
            newDeck.Add(new Card("test1", 1, 2, 1));
            newDeck.Add(new Card("test2", 2, 1, 1));

            return newDeck;
        }
    }
}
