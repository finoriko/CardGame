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

namespace BlackJackCard
{
    public class BustRule : GameRule
    {
        List<BlackjackPlayer> players;

        /// <summary>
        /// Creates a new instance of the <see cref="BustRule"/> class.
        /// </summary>
        /// <param name="players">A list of players participating in the game.</param>
        public BustRule(List<Player> players)
        {
            this.players = new List<BlackjackPlayer>();
            for (int playerIndex = 0; playerIndex < players.Count; playerIndex++)
            {
                this.players.Add((BlackjackPlayer)players[playerIndex]);
            }
        }

        /// <summary>
        /// Check if any of the players has exceeded 21 in any of their hands.
        /// </summary>
        public override void Check()
        {
            for (int playerIndex = 0; playerIndex < players.Count; playerIndex++)
            {
                players[playerIndex].CalculateValues();

                if (!players[playerIndex].Bust)
                {
                    if (!players[playerIndex].FirstValueConsiderAce && players[playerIndex].FirstValue > 21)
                    {
                        FireRuleMatch(new BlackjackGameEventArgs()
                        {
                            Player = players[playerIndex],
                            Hand = HandTypes.First
                        });
                    }
                }
                if (!players[playerIndex].SecondBust)
                {
                    if ((players[playerIndex].IsSplit &&
                        !players[playerIndex].SecondValueConsiderAce &&
                         players[playerIndex].SecondValue > 21))
                    {
                        FireRuleMatch(new BlackjackGameEventArgs()
                        {
                            Player = players[playerIndex],
                            Hand = HandTypes.Second
                        });
                    }
                }
            }
        }
    }
}