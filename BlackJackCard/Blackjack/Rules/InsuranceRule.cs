using System;
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

namespace BlackJackCard
{
    class InsuranceRule : GameRule
    {
        Hand dealerHand;
        bool done = false;

        /// <summary>
        /// Creates a new instance of the <see cref="InsuranceRule"/> class.
        /// </summary>
        /// <param name="dealerHand">The dealer's hand.</param>
        public InsuranceRule(Hand dealerHand)
        {
            this.dealerHand = dealerHand;
        }

        /// <summary>
        /// Checks whether or not the dealer's revealed card is an ace.
        /// </summary>
        public override void Check()
        {
            if (!done)
            {
                if (dealerHand.Count > 0)
                {
                    if (dealerHand[0].Value == CardValue.Ace)
                    {
                        FireRuleMatch(EventArgs.Empty);
                    }
                    done = true;
                }
            }
        }
    }
}