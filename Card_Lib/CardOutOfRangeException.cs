/**CardOutOfRangeException.cs - card out of range exception when the card index step outside the valid range
 * 
 * Author: Group #2
 * Since : 2020 - 03 - 03
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Lib
{
    public class CardOutOfRangeException : Exception
    {
        private Cards deckContents;

        public Cards DeckContents
        {
            get
            {
                return deckContents;
            }
        }

        public CardOutOfRangeException(Cards sourceDeckContents)
           : base("There are only 52 cards in the deck.")
        {
            deckContents = sourceDeckContents;
        }
    }
}
