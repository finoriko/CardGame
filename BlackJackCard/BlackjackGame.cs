using BlackJackCard.Misc;
using GameStateManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BlackJackCard
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class BlackjackGame : Game
    {
        GraphicsDeviceManager graphics;

        ScreenManager screenManager;

        public static float HeightScale = 1.0f;
        public static float WidthScale = 1.0f;

        public BlackjackGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            screenManager = new ScreenManager(this);
            screenManager.AddScreen(new BackgroundScreen(), null);
            screenManager.AddScreen(new MainMenuScreen(), null);
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
            Components.Add(screenManager);
#if WINDOWS
            IsMouseVisible = true;l
#elif ANDROID
            TargetElapsedTime = TimeSpan.FromTicks(333333);
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
#else
            Coponents.Add(new GameServiceComponent(this));
#endif
            AudioManager.Initialize(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            graphics.ApplyChanges();

            Rectangle bounds = graphics.GraphicsDevice.Viewport.TitleSafeArea;
            HeightScale = bounds.Height / 480f;
            WidthScale = bounds.Width / 800f;
            //HeightScale = 480;
            //WidthScale = 800;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            AudioManager.LoadSounds();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
