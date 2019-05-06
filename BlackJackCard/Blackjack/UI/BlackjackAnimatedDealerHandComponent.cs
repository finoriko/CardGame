﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CardFramework;
using Microsoft.Xna.Framework;

namespace BlackJackCard
{
    public class BlackjackAnimatedDealerHandComponent : AnimatedHandGameComponent
    {
        /// <summary>
        /// Creates a new instance of the 
        /// <see cref="BlackjackAnimatedDealerHandComponent"/> class.
        /// </summary>
        /// <param name="place">A number indicating the hand's position on the 
        /// game table.</param>
        /// <param name="hand">The dealer's hand.</param>
        /// <param name="cardGame">The associated game.</param>
        public BlackjackAnimatedDealerHandComponent(int place, Hand hand,
            CardsGame cardGame) : base(place, hand, cardGame)
        {
        }

        /// <summary>
        /// Gets the position relative to the hand position at which a specific card
        /// contained in the hand should be rendered.
        /// </summary>
        /// <param name="cardLocationInHand">The card's location in the hand (0 is the
        /// first card in the hand).</param>
        /// <returns>An offset from the hand's location where the card should be 
        /// rendered.</returns>
        public override Vector2 GetCardRelativePosition(int cardLocationInHand)
        {
            return new Vector2(30 * cardLocationInHand, 0);
        }
    }
}