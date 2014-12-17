using System;
using System.Collections.Generic;

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
                newDeck.Add(allCards[rnd.Next(0, allCards.Count)].Copy());
            }

            return newDeck;
        }

        public static Uri GetImageByName(string name)
        {
            switch (name)
            {
                case "mag":
                    return new Uri("/Resource/mag.png", UriKind.Relative);
                default:
                    return new Uri("/Resource/Image1.png", UriKind.Relative);
            }
        }
    }
}
