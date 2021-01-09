namespace DurakGame
{
    partial class frmDurakGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDurakGame));
            this.lblGameDeck = new System.Windows.Forms.Label();
            this.lblHumanPlayer = new System.Windows.Forms.Label();
            this.lblComputerPlayer = new System.Windows.Forms.Label();
            this.lblRiver = new System.Windows.Forms.Label();
            this.lblComputerAttacking = new System.Windows.Forms.Label();
            this.lblHumanAttacking = new System.Windows.Forms.Label();
            this.lblTrumpCard = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnPickUp = new System.Windows.Forms.Button();
            this.flowTrumpCard = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDiscardPile = new System.Windows.Forms.Label();
            this.txtDeckCardsRemaining = new System.Windows.Forms.TextBox();
            this.txtDicardCardsRemaining = new System.Windows.Forms.TextBox();
            this.txtRiverCardsRemaning = new System.Windows.Forms.TextBox();
            this.btnCeaseAttack = new System.Windows.Forms.Button();
            this.lblRoundNumber = new System.Windows.Forms.Label();
            this.txtRoundNumber = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.new20Deck = new System.Windows.Forms.ToolStripMenuItem();
            this.new36Deck = new System.Windows.Forms.ToolStripMenuItem();
            this.new52Deck = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.pbDeck = new System.Windows.Forms.PictureBox();
            this.pnlHumanHand = new System.Windows.Forms.Panel();
            this.pnlDiscardPile = new System.Windows.Forms.Panel();
            this.pnlComputerHand = new System.Windows.Forms.Panel();
            this.flowRiver = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGameDeck
            // 
            this.lblGameDeck.AutoSize = true;
            this.lblGameDeck.BackColor = System.Drawing.Color.YellowGreen;
            this.lblGameDeck.Location = new System.Drawing.Point(26, 102);
            this.lblGameDeck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGameDeck.Name = "lblGameDeck";
            this.lblGameDeck.Size = new System.Drawing.Size(61, 13);
            this.lblGameDeck.TabIndex = 0;
            this.lblGameDeck.Text = "GameDeck";
            // 
            // lblHumanPlayer
            // 
            this.lblHumanPlayer.AutoSize = true;
            this.lblHumanPlayer.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblHumanPlayer.Location = new System.Drawing.Point(744, 421);
            this.lblHumanPlayer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHumanPlayer.Name = "lblHumanPlayer";
            this.lblHumanPlayer.Size = new System.Drawing.Size(103, 13);
            this.lblHumanPlayer.TabIndex = 1;
            this.lblHumanPlayer.Text = "Human Player Cards";
            // 
            // lblComputerPlayer
            // 
            this.lblComputerPlayer.AutoSize = true;
            this.lblComputerPlayer.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblComputerPlayer.Location = new System.Drawing.Point(744, 84);
            this.lblComputerPlayer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComputerPlayer.Name = "lblComputerPlayer";
            this.lblComputerPlayer.Size = new System.Drawing.Size(114, 13);
            this.lblComputerPlayer.TabIndex = 2;
            this.lblComputerPlayer.Text = "Computer Player Cards";
            // 
            // lblRiver
            // 
            this.lblRiver.AutoSize = true;
            this.lblRiver.BackColor = System.Drawing.Color.YellowGreen;
            this.lblRiver.Location = new System.Drawing.Point(739, 210);
            this.lblRiver.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRiver.Name = "lblRiver";
            this.lblRiver.Size = new System.Drawing.Size(62, 13);
            this.lblRiver.TabIndex = 3;
            this.lblRiver.Text = "River Cards";
            // 
            // lblComputerAttacking
            // 
            this.lblComputerAttacking.AutoEllipsis = true;
            this.lblComputerAttacking.AutoSize = true;
            this.lblComputerAttacking.BackColor = System.Drawing.Color.Red;
            this.lblComputerAttacking.Location = new System.Drawing.Point(744, 60);
            this.lblComputerAttacking.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComputerAttacking.Name = "lblComputerAttacking";
            this.lblComputerAttacking.Size = new System.Drawing.Size(100, 13);
            this.lblComputerAttacking.TabIndex = 4;
            this.lblComputerAttacking.Text = "Computer Attacking";
            // 
            // lblHumanAttacking
            // 
            this.lblHumanAttacking.AutoSize = true;
            this.lblHumanAttacking.BackColor = System.Drawing.Color.Red;
            this.lblHumanAttacking.Location = new System.Drawing.Point(744, 444);
            this.lblHumanAttacking.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHumanAttacking.Name = "lblHumanAttacking";
            this.lblHumanAttacking.Size = new System.Drawing.Size(89, 13);
            this.lblHumanAttacking.TabIndex = 5;
            this.lblHumanAttacking.Text = "Human Attacking";
            // 
            // lblTrumpCard
            // 
            this.lblTrumpCard.AutoSize = true;
            this.lblTrumpCard.BackColor = System.Drawing.Color.YellowGreen;
            this.lblTrumpCard.Location = new System.Drawing.Point(26, 249);
            this.lblTrumpCard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTrumpCard.Name = "lblTrumpCard";
            this.lblTrumpCard.Size = new System.Drawing.Size(62, 13);
            this.lblTrumpCard.TabIndex = 6;
            this.lblTrumpCard.Text = "Trump Card";
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(9, 47);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(104, 39);
            this.btnStartGame.TabIndex = 7;
            this.btnStartGame.Text = "Start/New Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnPickUp
            // 
            this.btnPickUp.Location = new System.Drawing.Point(833, 201);
            this.btnPickUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnPickUp.Name = "btnPickUp";
            this.btnPickUp.Size = new System.Drawing.Size(56, 54);
            this.btnPickUp.TabIndex = 8;
            this.btnPickUp.Text = "Pick Up River Cards";
            this.btnPickUp.UseVisualStyleBackColor = true;
            this.btnPickUp.Click += new System.EventHandler(this.btnPickUp_Click);
            // 
            // flowTrumpCard
            // 
            this.flowTrumpCard.BackColor = System.Drawing.Color.Transparent;
            this.flowTrumpCard.Enabled = false;
            this.flowTrumpCard.Location = new System.Drawing.Point(20, 276);
            this.flowTrumpCard.Margin = new System.Windows.Forms.Padding(2);
            this.flowTrumpCard.Name = "flowTrumpCard";
            this.flowTrumpCard.Size = new System.Drawing.Size(93, 120);
            this.flowTrumpCard.TabIndex = 13;
            // 
            // lblDiscardPile
            // 
            this.lblDiscardPile.AutoSize = true;
            this.lblDiscardPile.BackColor = System.Drawing.Color.YellowGreen;
            this.lblDiscardPile.Location = new System.Drawing.Point(26, 411);
            this.lblDiscardPile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiscardPile.Name = "lblDiscardPile";
            this.lblDiscardPile.Size = new System.Drawing.Size(60, 13);
            this.lblDiscardPile.TabIndex = 14;
            this.lblDiscardPile.Text = "DiscardPile";
            // 
            // txtDeckCardsRemaining
            // 
            this.txtDeckCardsRemaining.Enabled = false;
            this.txtDeckCardsRemaining.Location = new System.Drawing.Point(114, 166);
            this.txtDeckCardsRemaining.Margin = new System.Windows.Forms.Padding(2);
            this.txtDeckCardsRemaining.Name = "txtDeckCardsRemaining";
            this.txtDeckCardsRemaining.ReadOnly = true;
            this.txtDeckCardsRemaining.Size = new System.Drawing.Size(18, 20);
            this.txtDeckCardsRemaining.TabIndex = 16;
            // 
            // txtDicardCardsRemaining
            // 
            this.txtDicardCardsRemaining.Enabled = false;
            this.txtDicardCardsRemaining.Location = new System.Drawing.Point(114, 454);
            this.txtDicardCardsRemaining.Margin = new System.Windows.Forms.Padding(2);
            this.txtDicardCardsRemaining.Name = "txtDicardCardsRemaining";
            this.txtDicardCardsRemaining.ReadOnly = true;
            this.txtDicardCardsRemaining.Size = new System.Drawing.Size(18, 20);
            this.txtDicardCardsRemaining.TabIndex = 17;
            // 
            // txtRiverCardsRemaning
            // 
            this.txtRiverCardsRemaning.Enabled = false;
            this.txtRiverCardsRemaning.Location = new System.Drawing.Point(805, 210);
            this.txtRiverCardsRemaning.Margin = new System.Windows.Forms.Padding(2);
            this.txtRiverCardsRemaning.Name = "txtRiverCardsRemaning";
            this.txtRiverCardsRemaning.ReadOnly = true;
            this.txtRiverCardsRemaning.Size = new System.Drawing.Size(18, 20);
            this.txtRiverCardsRemaning.TabIndex = 18;
            // 
            // btnCeaseAttack
            // 
            this.btnCeaseAttack.Enabled = false;
            this.btnCeaseAttack.Location = new System.Drawing.Point(833, 260);
            this.btnCeaseAttack.Margin = new System.Windows.Forms.Padding(2);
            this.btnCeaseAttack.Name = "btnCeaseAttack";
            this.btnCeaseAttack.Size = new System.Drawing.Size(59, 52);
            this.btnCeaseAttack.TabIndex = 19;
            this.btnCeaseAttack.Text = "Cease Attack";
            this.btnCeaseAttack.UseVisualStyleBackColor = true;
            this.btnCeaseAttack.Click += new System.EventHandler(this.btnCeaseAttack_Click);
            // 
            // lblRoundNumber
            // 
            this.lblRoundNumber.AutoSize = true;
            this.lblRoundNumber.BackColor = System.Drawing.Color.YellowGreen;
            this.lblRoundNumber.Location = new System.Drawing.Point(744, 32);
            this.lblRoundNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoundNumber.Name = "lblRoundNumber";
            this.lblRoundNumber.Size = new System.Drawing.Size(79, 13);
            this.lblRoundNumber.TabIndex = 25;
            this.lblRoundNumber.Text = "Round Number";
            // 
            // txtRoundNumber
            // 
            this.txtRoundNumber.Enabled = false;
            this.txtRoundNumber.Location = new System.Drawing.Point(833, 28);
            this.txtRoundNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtRoundNumber.Name = "txtRoundNumber";
            this.txtRoundNumber.ReadOnly = true;
            this.txtRoundNumber.Size = new System.Drawing.Size(18, 20);
            this.txtRoundNumber.TabIndex = 26;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenu,
            this.quitToolStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(905, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenu
            // 
            this.newToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.new20Deck,
            this.new36Deck,
            this.new52Deck});
            this.newToolStripMenu.Name = "newToolStripMenu";
            this.newToolStripMenu.Size = new System.Drawing.Size(77, 20);
            this.newToolStripMenu.Text = "New Game";
            // 
            // new20Deck
            // 
            this.new20Deck.Name = "new20Deck";
            this.new20Deck.Size = new System.Drawing.Size(180, 22);
            this.new20Deck.Text = "20 Cards";
            this.new20Deck.Click += new System.EventHandler(this.new20Deck_Click);
            // 
            // new36Deck
            // 
            this.new36Deck.Name = "new36Deck";
            this.new36Deck.Size = new System.Drawing.Size(180, 22);
            this.new36Deck.Text = "36 Cards";
            this.new36Deck.Click += new System.EventHandler(this.new36Deck_Click);
            // 
            // new52Deck
            // 
            this.new52Deck.Name = "new52Deck";
            this.new52Deck.Size = new System.Drawing.Size(180, 22);
            this.new52Deck.Text = "52 Cards";
            this.new52Deck.Click += new System.EventHandler(this.new52Deck_Click);
            // 
            // quitToolStrip
            // 
            this.quitToolStrip.Name = "quitToolStrip";
            this.quitToolStrip.Size = new System.Drawing.Size(42, 20);
            this.quitToolStrip.Text = "Quit";
            this.quitToolStrip.Click += new System.EventHandler(this.quitToolStrip_Click);
            // 
            // pbDeck
            // 
            this.pbDeck.Location = new System.Drawing.Point(20, 119);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Size = new System.Drawing.Size(75, 107);
            this.pbDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDeck.TabIndex = 28;
            this.pbDeck.TabStop = false;
            // 
            // pnlHumanHand
            // 
            this.pnlHumanHand.BackColor = System.Drawing.Color.Transparent;
            this.pnlHumanHand.Location = new System.Drawing.Point(167, 436);
            this.pnlHumanHand.Name = "pnlHumanHand";
            this.pnlHumanHand.Size = new System.Drawing.Size(555, 141);
            this.pnlHumanHand.TabIndex = 29;
            // 
            // pnlDiscardPile
            // 
            this.pnlDiscardPile.Location = new System.Drawing.Point(20, 444);
            this.pnlDiscardPile.Name = "pnlDiscardPile";
            this.pnlDiscardPile.Size = new System.Drawing.Size(93, 133);
            this.pnlDiscardPile.TabIndex = 30;
            // 
            // pnlComputerHand
            // 
            this.pnlComputerHand.BackColor = System.Drawing.Color.Transparent;
            this.pnlComputerHand.Location = new System.Drawing.Point(167, 32);
            this.pnlComputerHand.Name = "pnlComputerHand";
            this.pnlComputerHand.Size = new System.Drawing.Size(555, 83);
            this.pnlComputerHand.TabIndex = 31;
            // 
            // flowRiver
            // 
            this.flowRiver.BackColor = System.Drawing.Color.Transparent;
            this.flowRiver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowRiver.Location = new System.Drawing.Point(204, 136);
            this.flowRiver.Margin = new System.Windows.Forms.Padding(2);
            this.flowRiver.Name = "flowRiver";
            this.flowRiver.Size = new System.Drawing.Size(500, 270);
            this.flowRiver.TabIndex = 10;
            // 
            // frmDurakGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DurakGame.Properties.Resources.bg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(905, 589);
            this.Controls.Add(this.pnlComputerHand);
            this.Controls.Add(this.pnlDiscardPile);
            this.Controls.Add(this.pnlHumanHand);
            this.Controls.Add(this.pbDeck);
            this.Controls.Add(this.txtRoundNumber);
            this.Controls.Add(this.lblRoundNumber);
            this.Controls.Add(this.btnCeaseAttack);
            this.Controls.Add(this.txtRiverCardsRemaning);
            this.Controls.Add(this.txtDicardCardsRemaining);
            this.Controls.Add(this.txtDeckCardsRemaining);
            this.Controls.Add(this.lblDiscardPile);
            this.Controls.Add(this.flowTrumpCard);
            this.Controls.Add(this.flowRiver);
            this.Controls.Add(this.btnPickUp);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.lblTrumpCard);
            this.Controls.Add(this.lblHumanAttacking);
            this.Controls.Add(this.lblComputerAttacking);
            this.Controls.Add(this.lblRiver);
            this.Controls.Add(this.lblComputerPlayer);
            this.Controls.Add(this.lblHumanPlayer);
            this.Controls.Add(this.lblGameDeck);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmDurakGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak Game";
            this.Load += new System.EventHandler(this.frmDurakGame_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGameDeck;
        private System.Windows.Forms.Label lblHumanPlayer;
        private System.Windows.Forms.Label lblComputerPlayer;
        private System.Windows.Forms.Label lblRiver;
        private System.Windows.Forms.Label lblComputerAttacking;
        private System.Windows.Forms.Label lblHumanAttacking;
        private System.Windows.Forms.Label lblTrumpCard;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnPickUp;
        private System.Windows.Forms.FlowLayoutPanel flowTrumpCard;
        private System.Windows.Forms.Label lblDiscardPile;
        private System.Windows.Forms.TextBox txtDeckCardsRemaining;
        private System.Windows.Forms.TextBox txtDicardCardsRemaining;
        private System.Windows.Forms.TextBox txtRiverCardsRemaning;
        private System.Windows.Forms.Button btnCeaseAttack;
        private System.Windows.Forms.Label lblRoundNumber;
        private System.Windows.Forms.TextBox txtRoundNumber;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem new20Deck;
        private System.Windows.Forms.ToolStripMenuItem new36Deck;
        private System.Windows.Forms.ToolStripMenuItem new52Deck;
        private System.Windows.Forms.ToolStripMenuItem quitToolStrip;
        private System.Windows.Forms.PictureBox pbDeck;
        private System.Windows.Forms.Panel pnlHumanHand;
        private System.Windows.Forms.Panel pnlDiscardPile;
        private System.Windows.Forms.Panel pnlComputerHand;
        private System.Windows.Forms.FlowLayoutPanel flowRiver;
    }
}