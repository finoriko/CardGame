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
using GameStateManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace BlackJackCard
{
    class InstructionScreen : GameplayScreen
    {
        #region Fields
        Texture2D background;
        SpriteFont font;
        GameplayScreen gameplayScreen;
        string theme;
        bool isExit = false;
        bool isExited = false;
        #endregion

        #region Initialization
        public InstructionScreen(string theme)
            : base("")
        {
            TransitionOnTime = TimeSpan.FromSeconds(0.0);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

            this.theme = theme;
#if ANDROID
            EnabledGestures = GestureType.Tap;
#endif
        }
        #endregion

        #region Loading
        /// <summary>
        /// Load the screen resources
        /// </summary>
        public override void LoadContent()
        {
            background = Load<Texture2D>(@"Images\instructions");
            font = Load<SpriteFont>(@"Fonts\MenuFont");

            // Create a new instance of the gameplay screen
            gameplayScreen = new GameplayScreen(theme);
        }
        #endregion

        #region Update and Render
        /// <summary>
        /// Exit the screen after a tap or click
        /// </summary>
        /// <param name="input"></param>
        private void HandleInput(MouseState mouseState, GamePadState padState)
        {
            if (!isExit)
            {
                if (ScreenManager.input.Gestures.Count > 0 &&
                    ScreenManager.input.Gestures[0].GestureType == GestureType.Tap)
                {
                    isExit = true;
                }
            }
        }

        /// <summary>
        /// Screen update logic
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="otherScreenHasFocus"></param>
        /// <param name="coveredByOtherScreen"></param>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            if (isExit && !isExited)
            {
                // Move on to the gameplay screen
                foreach (GameScreen screen in ScreenManager.GetScreens())
                    screen.ExitScreen();

                gameplayScreen.ScreenManager = ScreenManager;
                ScreenManager.AddScreen(gameplayScreen, null);
                isExited = true;
            }

            HandleInput(Mouse.GetState(), GamePad.GetState(PlayerIndex.One));

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        /// <summary>
        /// Render screen 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            // Draw Background
            spriteBatch.Draw(background, ScreenManager.GraphicsDevice.Viewport.Bounds,
                 Color.White * TransitionAlpha);

            if (isExit)
            {
                Rectangle safeArea = ScreenManager.SafeArea;
                string text = "Loading...";
                Vector2 measure = font.MeasureString(text);
                Vector2 textPosition = new Vector2(safeArea.Center.X - measure.X / 2,
                    safeArea.Center.Y - measure.Y / 2);
                spriteBatch.DrawString(font, text, textPosition, Color.Black);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
        #endregion
    }
}