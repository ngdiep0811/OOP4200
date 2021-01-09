/**
 * CardBox.cs - The CardBox class used picture box to display card on the game.
 * 
 * @author      Group 02
 * @version     1.0
 * @since       2020-03-15
 * @see 
 * 
 */
/**ATTRIBUTION
* ===========
* The card images used in this class were created by Resource Center American Contract Bridge League
* http://acbl.mybigcommerce.com/52-playing-cards/
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Card_Lib;

namespace CardBox
{
    /// <summary>
    /// A control to use in a Windows Forms Application that displays a playing card.
    /// </summary>
    public partial class CardBox : UserControl
    {
        #region FIELDS AND PROPERTIES
        /// <summary>
        /// Card property: sets/gets the underlying Card object.
        /// </summary>
        private Card myCard;
        public Card Card
        {
            set
            {
                myCard = value;
                UpdateCardImage(); // update the card image
            }
            get { return myCard; }
        }

        /// <summary>
        /// Suit property: sets/gets the underlying Card object's Suit.
        /// </summary>
        public Suit Suit
        {
            set
            {
                Card.Suit = value;
                UpdateCardImage(); // update the card image
            }
            get { return Card.Suit; }
        }

        /// <summary>
        /// Rank property: sets/gets the underlying Card object's Rank.
        /// </summary>
        public Rank Rank
        {
            set
            {
                Card.Rank = value;
                UpdateCardImage(); // update the card image
            }
            get { return Card.Rank; }
        }

        /// <summary>
        /// FaceUp property: sets/gets the underlying Card object's FaceUp property.
        /// </summary>
        public bool FaceUp
        {
            set
            {
                // if value is different than the underlying card's FaceUp property
                if (myCard.FaceUp != value) // then the card is flipping over
                {
                    myCard.FaceUp = value; // change the card's FaceUp property

                    UpdateCardImage(); // update the card iamge (back or front)

                    // if there is an event handler for CardFlipped in the client program
                    if (CardFlipped != null)
                        CardFlipped(this, new EventArgs()); // call it
                }
            }
            get { return Card.FaceUp; }
        }

        /// <summary>
        /// CardOrientation Property: sets/gets the Orientation of the card.
        /// If setting this property changes the state of control, swaps
        /// the height and width of the control and updates the image.
        /// </summary>
        private Orientation myOrientation;
        public Orientation CardOrientation
        {
            set
            {
                // if value is different than myOrientation
                if (myOrientation != value)
                {
                    myOrientation = value; // change the orientation
                    // swap the height and width of the control
                    this.Size = new Size(Size.Height, Size.Width);
                    UpdateCardImage(); //update the card image
                }
            }
            get { return myOrientation; }
        }

        public void UpdateCardImage()
        {
            // set the image using the underlying card
            pbMyPictureBox.Image = myCard.GetCardImage();

            // if orientation is horizontal
            //if (myOrientation == Orientation.Horizontal)
            //{
            //    // rotate the image
            //    pbMyPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            //}
        }
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Constructor (Default): Constructs the control with a new card, oriented vertically.
        /// </summary>
        public CardBox()
        {
            InitializeComponent(); // required method for Designer support
            myOrientation = Orientation.Vertical; // set the orientation to vertical
            Card = new Card(); // create a new underlying card.
        }

        /// <summary>
        /// Constructor (PlayingCard, Orientation): Constructs the control using parameters.
        /// </summary>
        /// <param name="card">Underlying Card Object</param>
        /// <param name="orientation">Orientation enumeration. Vertical by default</param>
        public CardBox(Card card, bool faceUp, Orientation orientation = Orientation.Vertical)
        {
            InitializeComponent(); // required method for Designer support
            myOrientation = orientation; // set the orientation
            card.FaceUp = faceUp;
            Card = card; // set the underlying card
            
        }
        #endregion

        #region EVENTS AND EVENT HANDLER
        /// <summary>
        /// An event handler for the load event
        /// </summary>
        private void CardBox_Load(object sender, EventArgs e)
        {
            UpdateCardImage();
        }

        /// <summary>
        /// An event the client program can handle when the card flips face up/down
        /// </summary>
        public event EventHandler CardFlipped;

        /// <summary>
        /// An event the client program can handle when the user click on the control
        /// </summary>
        new public event EventHandler Click;
        new public event EventHandler MouseLeave;
        new public event EventHandler MouseEnter;

        private void pbMyPictureBox_Click(object sender, EventArgs e)
        {
            if (Click != null) // if there is a handler for clicking the control in the client program
                Click(this, e); // call it
        }
        private void pbMyPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (MouseLeave != null) // if there is a handler for clicking the control in the client program
                MouseLeave(this, e); // call it
        }

        private void pbMyPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (MouseEnter != null) // if there is a handler for clicking the control in the client program
                MouseEnter(this, e); // call it
        }
        #endregion

        #region OTHER METHODS
        /// <summary>
        /// ToString: Overrides System.Object.ToString()
        /// </summary>
        /// <returns>the name of the card as a string</returns>
        public override string ToString()
        {
            return myCard.ToString();
        }



        #endregion

        
    }
}
