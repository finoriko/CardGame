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
using Microsoft.Xna.Framework;

namespace CardFramework
{
    /// <summary>
    /// An <see cref="AnimatedGameComponent"/> implemented for a card game
    /// </summary>
    public class AnimatedCardsGameComponent : AnimatedGameComponent
    {
        public TraditionalCard Card { get; private set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="card">The card associated with the animation component.</param>
        /// <param name="cardGame">The associated game.</param>
        public AnimatedCardsGameComponent(TraditionalCard card, CardsGame cardGame)
            : base(cardGame, null)
        {
            Card = card;
        }

        #region Update and Render
        /// <summary>
        /// Updates the component.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


            CurrentFrame = IsFaceDown ? CardGame.cardsAssets["CardBack_" + CardGame.Theme] :
                CardGame.cardsAssets[UIUtilty.GetCardAssetName(Card)];
        }

        /// <summary>
        /// Draws the component.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            CardGame.SpriteBatch.Begin();

            // Draw the current at the designated destination, or at the initial 
            // position if a destination has not been set
            if (CurrentFrame != null)
            {
                if (CurrentDestination.HasValue)
                {
                    CardGame.SpriteBatch.Draw(CurrentFrame,
                        CurrentDestination.Value, Color.White);
                }
                else
                {
                    CardGame.SpriteBatch.Draw(CurrentFrame,
                        CurrentPosition, Color.White);
                }
            }

            CardGame.SpriteBatch.End();
        }
        #endregion
    }
}