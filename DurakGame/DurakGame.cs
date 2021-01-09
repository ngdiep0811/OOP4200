/**
 * DurakGame.cs - The DurakGame is the logic behind the game, how it cordinate defend, attack, switch turn etc.
 * 
 * @author      Group 02
 * @version     1.0
 * @since       2020-03-15
 * @see 
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardBox;
using Card_Lib;

namespace DurakGame
{
    public partial class frmDurakGame : Form
    {
        #region VARIABLE
        // Variable for RealignCard Method
        static private Size regularSize = new Size(89, 109);
        static private Size discardedSize = new Size(25, 30);
        private const int POP = 20;

        // Counter Declaration
        private int roundNumber = 0;
        private int currentCard = 0;
        private int discardedCardCount = 0;

        // Player Declaration
        private Player HumanPlayer = new Player("Player One", true);
        private Player ComputerPlayer = new Player("Computer", false);

        // Default Deck Size
        static int deckSize = 36;

        // Game Variable
        private Deck playDeck = new Deck(deckSize);
        private Cards onFieldCards = new Cards();
        private Cards discardedCards;
        private bool cardRemaining = true;
        private bool successfulDefense;
        private Card trumpCard = new Card();
        #endregion

        #region FORM AND CONTROL EVENT HANDLER
        /// <summary>
        /// initialize components of the form
        /// </summary>
        public frmDurakGame()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Event that occurs before a form is displayed for the first time, that call StartGame method.
        /// </summary>
        private void frmDurakGame_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        /// <summary>
        /// Start game button click event, that reset and start a new game.
        /// </summary>
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            ResetGame();
            StartGame();
        }

        /// <summary>
        /// Button pick up click event, is clicked to ends human turn and picks up cards 
        /// </summary>
        private void btnPickUp_Click(object sender, EventArgs e)
        {
            PickUpRiver(pnlHumanHand);
        }

        /// <summary>
        /// Button cease attack click event, is to cease attack button ends human turn and computer starts attacking
        /// </summary>
        private void btnCeaseAttack_Click(object sender, EventArgs e)
        {
            EndTurn();
        }

        /// <summary>
        /// LastCardDrawn event, that trigger when there is no remaining card to drawn from the deck.
        /// </summary>
        private void LastCardDrawn(object source, EventArgs args)
        {
            pbDeck.Image = null;
            cardRemaining = false;
            txtDeckCardsRemaining.Text = "0";
        }
        #endregion

        #region CARDBOX EVENT HANDLER
        /// <summary>
        ///  CardBox controls grow in size when the mouse is over it.
        /// </summary>
        void CardBox_MouseEnter(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox.CardBox aCardBox = sender as CardBox.CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                aCardBox.Size = new Size(regularSize.Width + POP, regularSize.Height + POP);// Enlarge the card for visual effect
                aCardBox.Top = 0;// move the card to the top edge of the panel.
            }
        }

        /// <summary>
        /// CardBox control shrinks to regular size when the mouse leaves.
        /// </summary>
        void CardBox_MouseLeave(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox.CardBox aCardBox = sender as CardBox.CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                aCardBox.Size = regularSize;// resize the card back to regular size
                aCardBox.Top = POP;// move the card down to accommodate for the smaller size.

            }
        }

        /// <summary>
        /// CardBox Click event,
        /// </summary>
        void CardBox_Click(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox.CardBox aCardBox = sender as CardBox.CardBox;
            // If the conversion worked
            if (aCardBox != null)
            {
                // if the card is in the home panel...
                if (aCardBox.Parent == pnlHumanHand)
                {
                    if (HumanPlayer.IsAttacking)
                    {
                        if (ValidAttack(aCardBox.Card)) // check if the attack is valid
                        {
                            pnlHumanHand.Controls.Remove(aCardBox); // Remove the card from the home panel
                            aCardBox.Enabled = false; // disable the card box
                            onFieldCards.Add(aCardBox.Card); // add cardbox to the field
                            flowRiver.Controls.Add(aCardBox); // Add the control to the play panel
                            System.Diagnostics.Debug.Write("Human Attacked With " + aCardBox.ToString() + "\n");
                            ComputerDefence(aCardBox); // call ComputerDefence method
                        }
                        btnCeaseAttack.Enabled = true; // enable btnCeaseAttack
                    }
                    else
                    {
                        if (ValidDefend(aCardBox.Card)) // check if the defend is valid
                        {
                            pnlHumanHand.Controls.Remove(aCardBox); // Remove the card from the home panel
                            aCardBox.Enabled = false; // disable the cardbox
                            onFieldCards.Add(aCardBox.Card); // add cardbox to the field 
                            flowRiver.Controls.Add(aCardBox); // Add the control to the play panel
                            System.Diagnostics.Debug.Write("Human Defended With " + aCardBox.ToString() + "\n");
                            ComputerAttack(); // call ComputerAttack method
                        }
                        btnCeaseAttack.Enabled = false; // disable btnCeaseAttack
                    }
                }
                // update river card text counter
                txtRiverCardsRemaning.Text = flowRiver.Controls.Count.ToString();

                // Realign the cards 
                RealignCards(pnlHumanHand);
            }

            if (!cardRemaining) // check if there is any card remaining to draw
            {
                CheckWinner(); // call CheckWinner method
            }
        }
        #endregion

        #region GAME METHOD
        /// <summary>
        /// StartGame method,
        /// is a method to initialize game
        /// </summary>
        private void StartGame()
        {
            //Reset all the counter
            currentCard = 0;
            discardedCardCount = 0;
            roundNumber = 0;

            //Set the Image of card box
            pbDeck.Image = (new Card()).GetCardImage();
            //MessageBox.Show(playDeck.CardsRemaining.ToString());

            //Create a new deck
            playDeck = new Deck(deckSize);
            playDeck.Shuffle(deckSize); //shuffle the deck
            playDeck.LastCardDrawn += LastCardDrawn; //wire LastCardDrawn to playDeck.LastCardDrawn
            discardedCards = new Cards();

            //Update the text
            txtRoundNumber.Text = roundNumber.ToString();
            txtRiverCardsRemaning.Text = "0";
            txtDeckCardsRemaining.Text = (playDeck.CardsRemaining - currentCard).ToString();
            txtDicardCardsRemaining.Text = "0";

            //Set cardRemaining to true
            cardRemaining = true;

            DealHands(cardRemaining); //Deal the deck to players
            DisplayTrumpCards();      //Display the trump card of the game
            CheckDeckSize();          //Checked decksize on menu strip

            //Modify form properties
            btnPickUp.Enabled = false;
            lblHumanAttacking.Visible = true;
            lblComputerAttacking.Visible = false;
        }

        /// <summary>
        /// CheckDeckSize method, is to checked the decksize thats being played on the menustrip.
        /// </summary>
        public void CheckDeckSize()
        {
            //Check if deckSize == 20
            if (deckSize == 20)
            {
                new20Deck.Checked = true;
                new36Deck.Checked = false;
                new52Deck.Checked = false;
            }
            else if (deckSize == 36) // or deckSize == 36
            {
                new20Deck.Checked = false;
                new36Deck.Checked = true;
                new52Deck.Checked = false;
            }
            else if (deckSize == 52) // or deckSize == 52
            {
                new20Deck.Checked = false;
                new36Deck.Checked = false;
                new52Deck.Checked = true;
            }
        }
        /// <summary>
        /// CheckWinner method, is to find the winner of the game or its a draw.
        /// </summary>
        public void CheckWinner()
        {
            //check if the playDeck have 0 card remaining.
            if (!cardRemaining)
            {
                //Check for draw by checking the control count in both panel
                if (pnlComputerHand.Controls.Count == 0 && pnlHumanHand.Controls.Count == 0)
                {
                    //Display message box
                    DialogResult d = MessageBox.Show("It's a draw!", "New game?", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes) // Check the dialog result
                    {
                        ResetGame(); // call ResetGame method
                        StartGame(); // call StartGame method
                    }
                    else
                    {
                        this.Close(); // close the form
                    }
                }
                else if (pnlComputerHand.Controls.Count == 0) // or if computer won the game
                {
                    //Display message box
                    DialogResult d = MessageBox.Show("Computer has won the game", "New game?", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes) // Check the dialog result
                    {
                        ResetGame(); // call ResetGame method
                        StartGame(); // call StartGame method
                    }
                    else
                    {
                        this.Close(); // close the form
                    }
                }
                else if (pnlHumanHand.Controls.Count == 0) // or if human won the game
                {
                    //Display message box
                    DialogResult d = MessageBox.Show("Player has won the game", "New game?", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes) // Check the dialog result
                    {
                        ResetGame(); // call ResetGame method
                        StartGame(); // call StartGame method
                    }
                    else
                    {
                        this.Close(); // close the form
                    }
                }
            }
        }

        /// <summary>
        /// ResetGame method, clear all panel on the game.
        /// </summary>
        public void ResetGame()
        {
            pnlComputerHand.Controls.Clear();  // clear pnlComputerHand
            pnlHumanHand.Controls.Clear();     // clear pnlHumanHand
            flowRiver.Controls.Clear();        // clear flowRiver
            flowTrumpCard.Controls.Clear();    // clear flowTrumpCard
            pnlDiscardPile.Controls.Clear();   // clear pnlDiscardPile
        }

        /// <summary>
        /// DisplayTrumpCards method,
        /// is to draw trump card, set the image of trump card and set it as the last card.
        /// </summary>
        public void DisplayTrumpCards()
        {
            /*The reason of number 12, is because the program is designed to accomodate 2 players. 
             *  Which makes the trump card is always been on 12th position.*/

            //create a new cardbox object
            CardBox.CardBox aCardBox = new CardBox.CardBox(playDeck.GetCard(12), true);

            trumpCard = playDeck.GetCard(12);
            // add the cardbox to flowTrumpCard
            flowTrumpCard.Controls.Add(aCardBox);
            // set the trumpSuit to the 12th card suit
            playDeck.GetCard(12).TrumpSuit = playDeck.GetCard(12).Suit;
            // move the 12th card to last card on the deck
            playDeck.ChangePosition(12, playDeck.GetCard(12));
            // set the trump card
        }

        /// <summary>
        /// DealHands method, is to deal hands at the end of every turn.
        /// </summary>
        /// <param name="cardRemaining">boolean for checking if there is card remaining to draw</param>
        private void DealHands(bool cardRemaining)
        {
            //check if there is card remaining to draw
            if (cardRemaining)
            {
                if (playDeck.CardsRemaining > 1) // check if deck card remaining > 1
                {
                    //make sure that human have 6 cards
                    for (int c = pnlHumanHand.Controls.Count; c < 6 && playDeck.CardsRemaining > 0; c++)
                    {
                        DrawCard(pnlHumanHand);
                    }
                    //make sure that computer have 6 cards
                    for (int c = pnlComputerHand.Controls.Count; c < 6 && playDeck.CardsRemaining > 0; c++)
                    {
                        DrawCard(pnlComputerHand);
                    }
                    //realign cards in both panel
                    RealignCards(pnlHumanHand);
                    RealignCards(pnlComputerHand);
                }
                else if (playDeck.CardsRemaining == 1) // check if deck card remaining == 1
                {
                    if (HumanPlayer.IsAttacking) // check if human is attacking
                        DrawCard(pnlHumanHand); // draw card to human
                    else
                        DrawCard(pnlComputerHand); // draw card to computer
                }
            }
        }

        /// <summary>
        /// DrawCard method,
        /// draw card into player panel and hand
        /// </summary>
        /// <param name="panel">panel to draw card into</param>
        private void DrawCard(Panel panel)
        {
            // check which panel to draw card into
            if (panel == pnlHumanHand) // if its human
            {
                // add to human hand
                HumanPlayer.PlayHand.Add(playDeck.GetCard(currentCard));
                // create new cardbox object
                CardBox.CardBox aCardBox = new CardBox.CardBox(playDeck.GetCard(currentCard), true);
                // Event for the cardbox
                aCardBox.Click += CardBox_Click;
                aCardBox.MouseEnter += CardBox_MouseEnter;// wire CardBox_MouseEnter for the "POP" visual effect
                aCardBox.MouseLeave += CardBox_MouseLeave;// wire CardBox_MouseLeave for the regular visual effect
                // add cardbox object to the human panel
                pnlHumanHand.Controls.Add(aCardBox);
                currentCard++; // increment current hand
            }
            if (panel == pnlComputerHand) // if its computer
            {
                // add to computer hand
                ComputerPlayer.PlayHand.Add(playDeck.GetCard(currentCard));
                // create new cardbox object
                CardBox.CardBox aCardBox = new CardBox.CardBox(playDeck.GetCard(currentCard), false);
                // add cardbox object to computer panel
                pnlComputerHand.Controls.Add(aCardBox);
                currentCard++; // increment current hand
            }
            // update the card remaining text
            txtDeckCardsRemaining.Text = (playDeck.CardsRemaining - currentCard).ToString();

        }

        /// <summary>
        /// RemoveRiverCard method,
        /// is to move every card on the field to the discarded card panel.
        /// </summary>
        private void RemoveRiverCard()
        {
            try
            {
                // set count to the number of control in flowRiver
                int count = (flowRiver.Controls.Count - 1);
                for (int i = count; i >= 0; i--)
                {
                    onFieldCards = new Cards();
                    //flowRiver.Controls[i].Size = new Size(discardedSize.Width + POP, discardedSize.Height + POP);
                    flowRiver.Controls[i].Enabled = false;
                    pnlDiscardPile.Controls.Add(flowRiver.Controls[i]);
                    discardedCardCount++;
                }
            }
            catch (Exception ex)
            {
                // write exception to debug
                System.Diagnostics.Debug.Write(ex.ToString());
            }
            finally
            {
                // update the discarded card remaining card
                txtDicardCardsRemaining.Text = (discardedCardCount).ToString();
                flowRiver.Controls.Clear();   // clear the flowRiver
                RealignCards(pnlDiscardPile); // realign pnlDiscardPile
            }

        }

        /// <summary>
        /// Valid Attack method,
        /// check whether the attack is valid or not.
        /// </summary>
        /// <param name="attackCard">card object</param>
        /// <returns>boolean, true or flase</returns>
        public bool ValidAttack(Card attackCard)
        {
            if (flowRiver.Controls.Count > 1) // Check if its not the first attack
            {
                // loop through to validate the attack by comparing the rank
                foreach (CardBox.CardBox playedCard in flowRiver.Controls)
                {
                    // compare the played card rank with the attack rank
                    if (playedCard.Rank == attackCard.Rank)
                    {
                        // if true, its a valid attack
                        return true;
                    }
                }
            }
            else if (flowRiver.Controls.Count == 0) // Check if its the first attack
            {
                // if so, then any attack is valid
                return true;
            }
            // it's not valid attack
            return false;
        }

        /// <summary>
        /// ValidDefend method, 
        /// is to check whether the defend is valid or not
        /// </summary>
        /// <param name="defendCard">card object</param>
        /// <returns>boolean, true or false</returns>
        public bool ValidDefend(Card defendCard)
        {
            // get the last card
            Card lastCard = onFieldCards[onFieldCards.Count - 1];
            // check if the defend is valid
            if ((defendCard.Suit == lastCard.Suit && defendCard.Rank > lastCard.Rank) || (defendCard.Suit == trumpCard.Suit && lastCard.Suit != trumpCard.Suit))
            {
                // if so return true
                return true;
            }
            // it's not valid defend
            return false;
        }

        /// <summary>
        /// ComputerDefence method,
        /// Computer checks to see if it has a card that can be used to defend the attack card 
        /// and chooses the lowest card possible in the deck to denfend with
        /// </summary>
        /// <param name="attackCard"></param>
        public void ComputerDefence(CardBox.CardBox attackCard)
        {
            // set valid defend to false
            bool validDefend = false;
            // create cardbox object
            CardBox.CardBox defendCard = new CardBox.CardBox();
            foreach (CardBox.CardBox aCardBox in pnlComputerHand.Controls)
            {
                // check if card suit is the same with attack card suit
                if (aCardBox.Card.Suit == attackCard.Card.Suit)
                {
                    // check if the card rank is higher than attack card suit
                    if (aCardBox.Card.Rank > attackCard.Card.Rank)
                    {
                        // if true set the defendCard 
                        defendCard = aCardBox;
                        // find the lowest possible defend card
                        if (aCardBox.Rank < defendCard.Rank)
                        {
                            // set the defendCard
                            defendCard = aCardBox;
                        }
                        // set validDefend to true
                        validDefend = true;
                    }
                }
                else if (aCardBox.Card.Suit == trumpCard.Suit && attackCard.Card.Suit != trumpCard.Suit) // check if the defend card suit is trump
                {
                    defendCard = aCardBox;
                    validDefend = true;
                }
            }
            // check if there is valid defend
            if (validDefend)
            {
                // if true, play the defend card
                ComputerPlaysCard(defendCard);
            }
            else
            {
                // if false, pick up the card on the field
                PickUpRiver(pnlComputerHand);
            }
        }

        /// <summary>
        /// ComputerAttack method,
        /// if the deck still has a card remaing the computer will attack with it's lowest card
        /// and if the card is empty the computer will attack with it's highest cards first
        /// or if cards have been played the computer will attack with a valid card
        /// </summary>
        public void ComputerAttack()
        {
            // check if the computer first attack
            if (flowRiver.Controls.Count == 0)
            {
                // check if card remaining is more than 0
                if (playDeck.CardsRemaining > 0)
                {
                    // get the lowest attackCard to initlize the round
                    CardBox.CardBox attackCard = pnlComputerHand.Controls.OfType<CardBox.CardBox>().First();
                    foreach (CardBox.CardBox card in pnlComputerHand.Controls)
                    {
                        if (card.Rank < attackCard.Rank)
                        {
                            attackCard = card;
                        }
                    }
                    ComputerPlaysCard(attackCard);
                    System.Diagnostics.Debug.Write("Computer Lowest Attack.");
                }
                else
                {
                    // get the highest attackCard to initilize the round
                    CardBox.CardBox attackCard = pnlComputerHand.Controls.OfType<CardBox.CardBox>().First();
                    foreach (CardBox.CardBox card in pnlComputerHand.Controls)
                    {
                        if (card.Rank > attackCard.Rank)
                        {
                            attackCard = card;
                        }
                    }
                    ComputerPlaysCard(attackCard);
                    System.Diagnostics.Debug.Write("Computer Highest Attack.");
                }

            }
            else
            {
                // continues attack after the first attack
                foreach (CardBox.CardBox fieldCard in flowRiver.Controls)
                {
                    foreach (CardBox.CardBox attackCard in pnlComputerHand.Controls)
                    {
                        if (fieldCard.Card.Rank == attackCard.Card.Rank) // validating the attack
                        {
                            ComputerPlaysCard(attackCard); // computer play the card
                            System.Diagnostics.Debug.Write("Computer Attacked.");

                            return;
                        }
                    }
                }
                EndTurn();
            }
        }

        /// <summary>
        /// ComputerPlaysCard method,
        /// Takes the attack or defened card the computer has chosen and places it on the river after removing it from the computers hand
        /// </summary>
        /// <param name="aCardBox"></param>
        public void ComputerPlaysCard(CardBox.CardBox aCardBox)
        {
            pnlComputerHand.Controls.Remove(aCardBox); // remove the card from the panel
            aCardBox.Enabled = false; // disable the card
            aCardBox.FaceUp = true; // set the FaceUp property to true
            onFieldCards.Add(aCardBox.Card); // add the card to on field
            flowRiver.Controls.Add(aCardBox); // add cardbox to the field
            RealignCards(pnlComputerHand); // realign computer panel
            System.Diagnostics.Debug.Write("Computer Played " + aCardBox.ToString() + " ");

            if (!cardRemaining) // check if there is card remaning
            {
                CheckWinner(); // check the winner
            }
        }

        /// <summary>
        /// PickUpRiver method,
        /// is to move every card on the field into hand
        /// </summary>
        /// <param name="panel"></param>
        public void PickUpRiver(Panel panel)
        {
            // Check if the defense is sucessful by getting the control count modulus by 2 
            // since the card come in pair (1 attack, 1 defense), if the result is 0 meaning the attack is repelled
            if (flowRiver.Controls.Count % 2 != 0)
            {
                successfulDefense = false; // set successfulDefense to false
            }
            else
            {
                successfulDefense = true; // set successfulDefense to true
            }

            for (int i = flowRiver.Controls.Count - 1; i >= 0; i--)
            {
                CardBox.CardBox card = flowRiver.Controls[i] as CardBox.CardBox;
                // move the card to the panel
                panel.Controls.Add(card);
                // remove from the field
                flowRiver.Controls.Remove(card);
                if (panel == pnlComputerHand)
                {
                    card.FaceUp = false; // set FaceUp property to false
                    card.Enabled = false; // disable card
                }
                if (panel == pnlHumanHand)
                {
                    // wire the event to the card box
                    card.Enabled = true;
                    card.Click += CardBox_Click;
                    card.MouseEnter += CardBox_MouseEnter;
                    card.MouseLeave += CardBox_MouseLeave;

                }
                // remove the card
                onFieldCards.Remove(card.Card);
                System.Diagnostics.Debug.Write(panel.Name + " Picked Up " + card.ToString() + "\n");
            }
            //realign both panel
            RealignCards(panel);
            RealignCards(pnlDiscardPile);

            if (successfulDefense)// check if its a successful defense
            {
                EndTurn(); // call EndTurn method
            }
            else
            {
                roundNumber++; // increment roundNumber

                // update text
                txtRoundNumber.Text = roundNumber.ToString();
                txtRiverCardsRemaning.Text = flowRiver.Controls.Count.ToString();

                DealHands(cardRemaining); // deal hand
                RemoveRiverCard(); // remove river card

                if (!HumanPlayer.IsAttacking) // check who's turn to attack
                    ComputerAttack();
            }


        }
        /// <summary>
        /// EndTurn method,
        /// is to end the turn for both player. It will switch the attacking position, remove card on the playing field
        /// update the text, set form properties
        /// </summary>
        public void EndTurn()
        {
            roundNumber++; // increment roundNumber

            // update text
            txtRoundNumber.Text = roundNumber.ToString();
            txtRiverCardsRemaning.Text = flowRiver.Controls.Count.ToString();

            DealHands(cardRemaining); // deal card
            RemoveRiverCard();        // remove on field card
            // check who's attack turn is it
            if (HumanPlayer.IsAttacking) // computer attacking
            {
                // modify form properties
                HumanPlayer.IsAttacking = false;
                lblHumanAttacking.Visible = false;
                ComputerPlayer.IsAttacking = true;
                lblComputerAttacking.Visible = true;
                btnCeaseAttack.Enabled = false;
                btnPickUp.Enabled = true;
                ComputerAttack();
            }
            else // human attacking
            {
                // modify form properties
                HumanPlayer.IsAttacking = true;
                lblHumanAttacking.Visible = true;
                ComputerPlayer.IsAttacking = false;
                lblComputerAttacking.Visible = false;
                btnPickUp.Enabled = false;

                // doesn't allow to skip attack
                if (flowRiver.Controls.Count >= 1)
                {
                    btnCeaseAttack.Enabled = true;
                }
            }

        }
        #endregion

        #region HELPER METHOD
        /// <summary>
        /// RealignCards method,
        /// is to realign card in the panel.
        /// </summary>
        /// <param name="panelHand">panel to be realigned</param>
        private void RealignCards(Panel panelHand)
        {
            // Determine the number of cards/controls in the panel.
            int myCount = panelHand.Controls.Count;
            // check if the panel is pnlDiscardPile
            if (panelHand == pnlDiscardPile)
            {
                // loop through the panel
                for (int index = 0; index < myCount; index++)
                {
                    // set the size to discarded size
                    pnlDiscardPile.Controls[index].Size = new Size(discardedSize.Width + POP, discardedSize.Height + POP);
                }
            }

            // If there are any cards in the panel
            if (myCount > 0)
            {
                // Determine how wide one card/control is.
                int cardWidth = panelHand.Controls[0].Width;


                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = (panelHand.Width - cardWidth) / 2;

                // An offset for the remaining cards
                int offset = 0;

                // If there are more than one cards/controls in the panel
                if (myCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = (panelHand.Width - cardWidth - 2 * POP) / (myCount - 1);

                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                        offset = cardWidth;

                    // Determine width of all the cards/controls 
                    int allCardWidth = (myCount - 1) * offset + cardWidth;

                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (panelHand.Width - allCardWidth) / 2;
                }
                // Aligning the cards: Note that I align them in reserve order from how they
                // are stored in the controls collection. This is so that cards on the left 
                // appear underneath cards to the right. This allows the user to see the rank
                // and suit more easily.

                // Align the "first" card (which is the last control in the collection)
                panelHand.Controls[myCount - 1].Top = POP;
                System.Diagnostics.Debug.Write(panelHand.Controls[myCount - 1].Top.ToString() + "\n");
                panelHand.Controls[myCount - 1].Left = startPoint;

                // for each of the remaining controls, in reverse order.
                for (int index = myCount - 2; index >= 0; index--)
                {
                    // Align the current card
                    panelHand.Controls[index].Top = POP;
                    panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;

                }
            }
        }

        #endregion

        #region MENU STRIP EVENT
        /// <summary>
        /// new 20 deck click event,
        /// change the decksize to 20 and start a new game.
        /// </summary>
        private void new20Deck_Click(object sender, EventArgs e)
        {
            deckSize = 20;
            ResetGame();
            StartGame();
        }

        /// <summary>
        /// new 36 deck click event,
        /// change the decksize to 36 and start a new game.
        /// </summary>
        private void new36Deck_Click(object sender, EventArgs e)
        {
            deckSize = 36;
            ResetGame();
            StartGame();
        }

        /// <summary>
        /// new 52 deck click event,
        /// change the decksize to 52 and start a new game.
        /// </summary>
        private void new52Deck_Click(object sender, EventArgs e)
        {
            deckSize = 52;
            ResetGame();
            StartGame();
        }

        /// <summary>
        /// Quit tool strip click event,
        /// close the form
        /// </summary>
        private void quitToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region TESTING METHOD

        private void pbDeck_Click(object sender, EventArgs e)
        {
            //DrawCard(pnlComputerHand);
            //DisplayOnFieldCards();
            DisplayAllCardLists();
        }

        /// <summary>
        /// DisplayAllCardLists method,
        /// is to set all card on the game to face up
        /// *It's for testing purposes
        /// </summary>
        public void DisplayAllCardLists()
        {
            DisplayDiscardCards();
            DisplayPlayerOneCards();
            DisplayPlayerTwoCards();
            DisplayRiverCards();
        }

        /// <summary>
        /// DisplayDiscardCards method,
        /// is to set all card on the pnlDiscardedCard to face up
        /// *It's for testing purposes
        /// </summary>
        public void DisplayDiscardCards()
        {
            foreach (Control control in pnlDiscardPile.Controls)
            {
                CardBox.CardBox card = control as CardBox.CardBox;
                card.FaceUp = true;
            }
        }

        /// <summary>
        /// DisplayOnFieldCards method,
        /// is to show all card on field
        /// *It's for testing purposes
        /// </summary>
        public void DisplayOnFieldCards()
        {
            foreach (Card card in onFieldCards)
            {
                MessageBox.Show(card.ToString());
            }
        }

        /// <summary>
        /// DisplayPlayerOneCards method,
        /// is to set all card on the pnlHumanHand to face up
        /// *It's for testing purposes
        /// </summary>
        public void DisplayPlayerOneCards()
        {
            foreach (Control control in pnlHumanHand.Controls)
            {
                CardBox.CardBox card = control as CardBox.CardBox;
                card.FaceUp = true;
            }
        }

        /// <summary>
        /// DisplayPlayerTwoCards method,
        /// is to set all card on the pnlComputerHand to face up
        /// *It's for testing purposes
        /// </summary>
        public void DisplayPlayerTwoCards()
        {
            foreach (Control control in pnlComputerHand.Controls)
            {
                CardBox.CardBox card = control as CardBox.CardBox;
                card.FaceUp = true;
            }
        }

        /// <summary>
        /// DisplayRiverCards method,
        /// is to set all card on the flowRiver to face up
        /// *It's for testing purposes
        /// </summary>
        public void DisplayRiverCards()
        {
            foreach (Control control in flowRiver.Controls)
            {
                CardBox.CardBox card = control as CardBox.CardBox;
                card.FaceUp = true;
            }

        }
        #endregion
    }
}
