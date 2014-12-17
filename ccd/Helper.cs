using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccd
{
    public static class Helper
    {
        public static int DeckCount = 25;
        public static int HandCount = 5;

        public static List<Card> CreateNewDeck(int count)
        {
            List<Card> newDeck = new List<Card>();

            var allCards = DatabaseWorker.GetAllCards();
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                newDeck.Add(allCards[rnd.Next(0, allCards.Count)]);
            }

            return newDeck;
        }
    }
}
