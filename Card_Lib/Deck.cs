/**Deck.cs - deck of cards class
 * 
 * Author: Group #2
 * Since : 2020 - 03 - 03
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card_Lib
{
    public class Deck : ICloneable
    {
        /// <summary>
        /// minRange attribute
        /// </summary>
        private int minRange=1;
        public int MinRange
        {
            set
            {
                //add validation
                if(value >= 1 && value <= 14)
                {
                    minRange = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid value for minimum range.");
                }
            }
            get
            {
                return minRange;
            }
        }
        /// <summary>
        /// maxRange attribute
        /// </summary>
        private int maxRange=14;
        public int MaxRange
        {
            set
            {
                if (value >= 1 && value <= 14 && minRange<maxRange)
                {
                    maxRange = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid value for maximum range.");
                }
            }
            get
            {
                return maxRange;
            }
        }
        /// <summary>
        /// CardsRemaining,
        /// will return int of how many cards remaining
        /// </summary>
        public int CardsRemaining { get{ return cards.Count; } }

        /// <summary>
        /// LastCardDrawn event declaration, that will be triggered once the last card was drawn
        /// </summary>
        public event EventHandler LastCardDrawn;

        /// <summary>
        /// Parameterized Constructor - that will initialize Deck object with card
        /// </summary>
        /// <param name="deckSize">deck size</param>
        public Deck(int deckSize)
        {
            // declare new cards object
            cards = new Cards();
            if (deckSize == 36) // check if the deck size == 36
            {
                MinRange = 5;
                for (int suitVal = 0; suitVal < 4; suitVal++)
                {
                    for (int rankVal = MinRange; rankVal < 14; rankVal++)
                    {
                        cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                    }
                }
            }
            else if (deckSize == 20) // check if the deck size == 20
            {
                MinRange = 9;
                for (int suitVal = 0; suitVal < 4; suitVal++)
                {
                    for (int rankVal = MinRange; rankVal < 14; rankVal++)
                    {
                        cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                    }
                }
            }
            else if (deckSize == 52) // check if the deck size == 52
            {
                for (int suitVal = 0; suitVal < 4; suitVal++)
                {
                    for (int rankVal = MinRange; rankVal < 14; rankVal++)
                    {
                        cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                    }
                }
            }

        }

        /// <summary>
        /// Clone - clone the deck of card
        /// </summary>
        /// <returns>object of the deck</returns>
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }

        private Deck(Cards newCards)
        {
            cards = newCards;
        }
        private Cards cards = new Cards();
        /// <summary>
        /// Default Constructor - create a deck of 52 cards
        /// </summary>
        public Deck()
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = MinRange; rankVal < MaxRange; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }
        /// <summary>
        /// GetCard - get card at position index
        /// </summary>
        /// <param name="cardNum">position index</param>
        /// <returns>card on that index</returns>
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= ((MaxRange - MinRange) * 4)) 
            {
                if ((cardNum == ((MaxRange - MinRange) * 4)-1) && (LastCardDrawn != null)) 
                    LastCardDrawn(this, EventArgs.Empty);
                return cards[cardNum];
            }
            else
                throw new CardOutOfRangeException((Cards)cards.Clone());
        }
        /// <summary>
        /// Shuffle - randomize the sequence of the deck
        /// </summary>
        public void Shuffle(int deckSize)
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[deckSize];
            Random sourceGen = new Random();
            for (int i = 0; i < deckSize; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(deckSize);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);
        }
        /// <summary>
        /// ChangePosition method, that used to move card to the very back of the deck.
        /// </summary>
        /// <param name="oldIndex">index of the card</param>
        /// <param name="newCard">card object</param>
        public void ChangePosition(int oldIndex, Card newCard)
        {
            cards.RemoveAt(oldIndex);
            cards.Add(newCard);
        }
        
    }
}