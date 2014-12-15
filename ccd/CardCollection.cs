using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccd
{
    public static class CardCollection
    {
        public static List<Card> Collection;
        public static Card test1 = new Card("test1", 1, 2, 1);
        public static Card test2 = new Card("test2", 2, 1, 1);

        public static Card GetRandomCard()
        {
            if (Collection == null || !Collection.Any())
            {
                
            }

            return test1;
        }
    }
}
