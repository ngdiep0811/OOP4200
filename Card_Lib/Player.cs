/**Player.cs - Player class, for creating player for the game
 * 
 * Author: Group #2
 * Since : 2020 - 02 - 25
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Lib
{
    public class Player
    {
        //Player Attribute
        public string Name { get; set; }
        public Cards PlayHand { get; set; }
        public bool IsAttacking { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Player()
        {
        }
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="name"></param>
        public Player(string name, bool attacking)
        {
            Name = name;
            PlayHand = new Cards();
            IsAttacking = attacking;
        }
        /// <summary>
        /// HasWon - check if player have win
        /// </summary>
        /// <returns></returns>
        public bool HasWon()
        {
            bool won = true;
            Suit match = PlayHand[0].Suit;
            for (int i = 1; i < PlayHand.Count; i++)
            {
                won &= PlayHand[i].Suit == match;
            }
            return won;
        }
    }
}