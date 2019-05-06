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
using Microsoft.Xna.Framework.Graphics;

namespace CardFramework
{
    public class FlipGameComponentAnimation : AnimatedGameComponentAnimation
    {
        #region Fields
        protected int percent = 0;
        public bool IsFromFaceDownToFaceUp = true;
        #endregion

        /// <summary>
        /// Runs the flip animation, which makes the component appear as if it has
        /// been flipped.
        /// </summary>
        /// <param name="gameTime">Game time information.</param>
        public override void Run(GameTime gameTime)
        {
            Texture2D texture;
            if (IsStarted())
            {
                if (IsDone())
                {
                    // Finish tha animation
                    Component.IsFaceDown = !IsFromFaceDownToFaceUp;
                    Component.CurrentDestination = null;
                }
                else
                {
                    texture = Component.CurrentFrame;
                    if (texture != null)
                    {
                        // Calculate the completion percent of the animation
                        percent += (int)(((gameTime.ElapsedGameTime.TotalMilliseconds /
                            (Duration.TotalMilliseconds / AnimationCycles)) * 100));

                        if (percent >= 100)
                        {
                            percent = 0;
                        }

                        int currentPercent;
                        if (percent < 50)
                        {
                            // On the first half of the animation the component is
                            // on its initial size
                            currentPercent = percent;
                            Component.IsFaceDown = IsFromFaceDownToFaceUp;
                        }
                        else
                        {
                            // On the second half of the animation the component
                            // is flipped
                            currentPercent = 100 - percent;
                            Component.IsFaceDown = !IsFromFaceDownToFaceUp;
                        }
                        // Shrink and widen the component to look like it is flipping
                        Component.CurrentDestination =
                            new Rectangle((int)(Component.CurrentPosition.X +
                                    texture.Width * currentPercent / 100),
                                (int)Component.CurrentPosition.Y,
                                (int)(texture.Width - texture.Width *
                                    currentPercent / 100 * 2),
                                texture.Height);
                    }
                }
            }
        }
    }
}