using System;
using CardFramework;

namespace BlackJackCard
{
    public class BlackjackGameEventArgs : EventArgs
    {
        public Player Player { get; set; }
        public HandTypes Hand { get; set; }
    }
}