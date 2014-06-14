﻿// GermanWhistPlayer.cs
// <copyright file="GermanWhistPlayer.cs"> This code is protected under the MIT License. </copyright>
using System.Collections.Generic;
using System.Linq;
using CardsLibrary;

namespace CardGames.Whist.GermanWhist
{
    /// <summary>
    /// An abstract super-class of every <see cref="GermanWhist"/> player.
    /// </summary>
    public abstract class GermanWhistPlayer : Player<GermanWhistInfo>
    {
        /// <summary>
        /// Detects the valid cards that could be played.
        /// </summary>
        /// <param name="args"> The current game info. </param>
        /// <returns> A list of valid cards. </returns>
        protected List<Card> DetectValidCards(GermanWhistInfo args)
        {
            // Can the hand follow suit
            bool followSuit = Hand.Any(c => c.Suit == args.FirstSuitLaid);

            if (followSuit && args.FirstSuitLaid != Suit.Null)
            {
                // If the hand can follow suit, return only cards of the correct suit
                return this.Hand.Where(c => c.Suit == args.FirstSuitLaid).ToList();
            }
            else
            {
                // Else return all cards
                return this.Hand;
            }
        }
    }
}
