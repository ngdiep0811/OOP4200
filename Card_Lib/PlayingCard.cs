/**
 * PlayingCard.cs - The PlayingCard Class
 * 
 * @author Gabriel Nathan Legawa
 * @version 1.0
 * @since 2020-03-18
 * 
 */
/**ATTRIBUTION
 * ===========
 * The card images used in this class were created by Resource Center American Contract Bridge League
 * http://acbl.mybigcommerce.com/52-playing-cards/
 */
using System;
using System.Drawing;

namespace Card_Lib
{
    /// <summary>
    /// Used to represent a standard "French"  playing card that can be used
    /// in several card game projects.
    /// </summary>
    public class PlayingCard : ICloneable, // Supports cloning, which creates a new
                                           // instance of a class with the same value as an existing instance.
                               IComparable // Defines a generalized type specific
                                           // comparison method that a class implements
                                           // to sort its instances.
    {
        #region FIELDS AND PROPERTIES
        /// <summary>
        /// Suit Property
        /// Used to set or get the Card Suit
        /// </summary>
        protected Suit mySuit;
        public Suit Suit
        {
            get { return mySuit; }
            set { mySuit = value; }
        }
        /// <summary>
        /// Rank Property
        /// Used to set or get the Card Rank
        /// </summary>
        protected Rank myRank;
        public Rank Rank
        {
            get { return myRank; }
            set { myRank = value; }
        }
        /// <summary>
        /// CardValue Property
        /// Used to set or get the Card Value
        /// </summary>
        protected int myValue;
        public int cardValue
        {
            get { return myValue; }
            set { myValue = value; }
        }
        /// <summary>
        /// Alternate Value Property
        /// Used to set ot get an alternate value for certain games. Set to null by default.
        /// </summary>
        protected int? altValue = null; // nullable type
        public int? AlternateValue
        {
            get { return altValue; }
            set { altValue = value; }
        }
        /// <summary>
        /// FaceUp Property
        /// Used to set or get whether the card is face up.
        /// Set to false by default. 
        /// </summary>
        protected bool faceUp = false;
        public bool FaceUp
        {
            get { return faceUp; }
            set { faceUp = value; }
        }
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Card Constructor
        /// Initializes the playing card object. By default, card is face down, with no alternate value
        /// </summary>
        /// <param name="rank">The playing card rank. Default to 'Ace'</param>
        /// <param name="suit">The playing card suit. Default to 'Hearts'</param>
        public PlayingCard(Rank rank = Rank.Ace, Suit suit = Suit.Heart)
        {
            // Set the rank, suit
            this.myRank = rank;
            this.mySuit = suit;
            // Set the default card value
            this.myValue = (int)rank;
        }
        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// CompareTo Method
        /// Card-Specific comparison method used to sort Card instances. Compares this instance 
        /// </summary>
        /// <param name="obj">The object this card is being compared to.</param>
        /// <returns>an integer that indicates whether this Card precedes, follows, or occurs</returns>
        public virtual int CompareTo(object obj)
        {
            // is the argument null?
            if (obj == null)
            {
                throw new ArgumentNullException("Unable to compare a Card to a null object.");
            }
            // convert the argument to a Card
            PlayingCard comparedCard = obj as PlayingCard;
            // if the conversion worked
            if (comparedCard != null)
            {
                // compare based on Value first, the Suit.
                int thisSort = this.myValue * 10 + (int)this.mySuit;
                int compareCardSort = comparedCard.myValue * 10 + (int)comparedCard.mySuit;
                return (thisSort.CompareTo(compareCardSort));
            }
            else // otherwise, the conversation failed
            {
                // throw an argument exception
                throw new ArgumentException("Object being compared cannot be converted to a Card.");
            }
        } // end of CompareTo

        /// <summary>
        /// Clone Method
        /// To support the ICloneable interface. Used for deep copying in card collection classes.
        /// </summary>
        /// <returns>A copy of the card as System.Object</returns>
        public object Clone()
        {
            return this.MemberwiseClone(); // return a memberwise clone.
        }

        /// <summary>
        /// ToString: Overrides System.Object.ToString()
        /// </summary>
        /// <returns>the name of the card as a string</returns>
        public override string ToString()
        {
            string cardString;  // holds the playing card name.
            // if the card is face up
            if (faceUp)
            {
                // set the card name string to {Rank} of {Suit}
                cardString = myRank.ToString() + " of " + mySuit.ToString();
            }
            // otherwise, the card is face down
            else
            {
                // set the card name is face down
                cardString = "Face Down";
            }
            // return the appropriate card name string
            return cardString;
        }

        /// <summary>
        /// Equals: Overrides System.Object.Equals()
        /// </summary>
        /// <param name="obj">true if the card values are equal</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (this.cardValue == ((PlayingCard)obj).cardValue);
        }

        /// <summary>
        /// GetHashCode: Overrides System.Object.GetHashCode()
        /// </summary>
        /// <returns>Card value  * 10 + suit number</returns>
        public override int GetHashCode()
        {
            return this.myValue * 10 + (int)this.mySuit;
        }

        /// <summary>
        /// GetCardImage
        /// Gets the image associated with the card from the resource file.
        /// </summary>
        /// <returns>an Image corresponding to the playing card.</returns>
        public Image GetCardImage()
        {
            string imageName; // the name of the image in the resouces file
            Image cardImage; // holds the image
            // if the card is not face up
            if (!faceUp)
            {
                //set the image name to "Back"
                imageName = "Back"; //  sets it to the image name for the back of the card
            }
            else // otherwise, the card is face up and not joker
            {
                // set the image name to {suit}_{rank}
                imageName = mySuit.ToString() + "_" + myRank.ToString(); // enumerations are handy!
            }
            // Set the image to the appropriate object we get from the resources file
            cardImage = Properties.Resources.ResourceManager.GetObject(imageName) as Image;
            //return the image
            return cardImage;
        }

        /// <summary>
        /// DebugString
        /// Generates a string showing the state of the card object; useful for debug purposes.
        /// </summary>
        /// <returns>a string showing the state of this card object</returns>
        public String DebugString()
        {
            string cardState = (string)(myRank.ToString() + " of " + mySuit.ToString()).PadLeft(20);
            cardState += (string)((faceUp) ? "(Face Up)" : "(Face Down)").PadLeft(12);
            cardState += " Value: " + myValue.ToString().PadLeft(2);
            cardState += ((altValue != null) ? "/" + altValue.ToString() : "");
            return cardState;
        }
        #endregion

        #region RELATIONAL OPERATORS
        public static bool operator ==(PlayingCard left, PlayingCard right)
        {
            return (left.cardValue == right.cardValue);
        }
        public static bool operator !=(PlayingCard left, PlayingCard right)
        {
            return (left.cardValue != right.cardValue);
        }
        public static bool operator <(PlayingCard left, PlayingCard right)
        {
            return (left.cardValue < right.cardValue);
        }
        public static bool operator <=(PlayingCard left, PlayingCard right)
        {
            return (left.cardValue <= right.cardValue);
        }
        public static bool operator >(PlayingCard left, PlayingCard right)
        {
            return (left.cardValue > right.cardValue);
        }
        public static bool operator >=(PlayingCard left, PlayingCard right)
        {
            return (left.cardValue >= right.cardValue);
        }
        #endregion
    } // end of class

} // end of namespace block
